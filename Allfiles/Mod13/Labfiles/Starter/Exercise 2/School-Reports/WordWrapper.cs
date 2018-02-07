using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Configuration;
using Microsoft.Office.Interop.Word;

namespace School
{
    class WordWrapper : IDisposable 
    {
        X509Certificate2 _certificate;
        string _certificateSubjectName;
        dynamic _word = null;

        public WordWrapper()
        {
            this._word = new Application { Visible = false };
            this._certificateSubjectName = ConfigurationManager.AppSettings.Get("CertificateName");
        }

        #region WordInterop

        /// <summary>
        /// Creates blank word document.
        /// </summary>
        public void CreateBlankDocument()
        {
            var doc = this._word.Documents.Add();
            doc.Activate();
        }

        /// <summary>
        /// Appends text to the end of the current word document.
        /// </summary>
        /// <param name="text">The text to append.</param>
        /// <param name="bold">Indicate whether the text should be bold.</param>
        /// <param name="underLine">Indicate whether the text should be underlined.</param>
        public void AppendText(string text, bool bold, bool underLine)
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.Bold = bold ? 1 : 0;
            currentLocation.Underline = underLine ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;
            currentLocation.InsertAfter(text);
        }

        /// <summary>
        /// Appends text with the Heading 1 style to the end of the current word document.
        /// </summary>
        /// <param name="text">The text to append.</param>
        public void AppendHeading(string text)
        {
            var currentLocation = this.GetEndOfDocument();

            currentLocation.InsertAfter(text);
            currentLocation.set_Style(WdBuiltinStyle.wdStyleHeading1);
            currentLocation.InsertParagraphAfter();
        }

        /// <summary>
        /// Inserts a carriage return to the end of the document.
        /// </summary>
        public void InsertCarriageReturn()
        {
            var currentLocation = this.GetEndOfDocument();
            currentLocation.InsertBreak(WdBreakType.wdLineBreak);
        }

        /// <summary>
        /// Inserts a page break to the end of the document.
        /// </summary>
        public void InsertPageBreak()
        {
            var currentLocation = this.GetEndOfDocument();
            currentLocation.InsertBreak(WdBreakType.wdPageBreak);
        }

        /// <summary>
        /// Finds the end of the current content in the document.
        /// </summary>
        private Range GetEndOfDocument()
        {
            return this._word.ActiveDocument.Range(this._word.ActiveDocument.Content.End - 1);
        }

        /// <summary>
        /// Merges an existing document to the end of the current document.
        /// </summary>
        /// <param name="existingDocumentPath">The path to the existing document.</param>
        public void MergeDocument(string existingDocumentPath)
        {
            if (!File.Exists(existingDocumentPath))
                throw new FileNotFoundException("File not found", existingDocumentPath);

            this.GetEndOfDocument().InsertFile(existingDocumentPath);
        }

        #endregion

        #region Predefined Encryption Code

        public void EncryptReport(string reportPath)
        {
            // Ensure report file exists.
            if (!File.Exists(reportPath))
                throw new FileNotFoundException("File not found", reportPath);

            // Read the report into memory.
            var reportToEncrypt = File.ReadAllBytes(reportPath);

            // Encrypt the report.
            var encryptedReport = Encrypt(reportToEncrypt);

            // Write the encrypyted report to disk.
            File.WriteAllBytes(reportPath, encryptedReport);
        }

        /// <summary>
        /// Encrypts a byte array.
        /// </summary>
        /// <param name="bytesToEncypt">The bytes to encrypt.</param>
        public byte[] Encrypt(byte[] bytesToEncypt)
        {
            // Ensure we have a valid certificate.
            this.ValidateX509Config();

            return this.EncryptWithX509(bytesToEncypt);
        }

        byte[] EncryptWithX509(byte[] bytesToEncypt)
        {
            // Get the public key from the X509 certificate. This key will be used to encrypt the AesManaged encryption key.
            var provider = (RSACryptoServiceProvider)this._certificate.PublicKey.Key;

            // Create an instance of the AesManaged algorithm which we will use to encrypt the data with.
            using (var algorithm = new AesManaged())
            {
                // Create an underlying stream which the decrypted data will be buffered too.
                using (var outStream = new MemoryStream())
                {
                    // Create an AES encryptor based on the key and IV.
                    using (var encryptor = algorithm.CreateEncryptor())
                    {
                        var keyFormatter = new RSAPKCS1KeyExchangeFormatter(provider);
                        var encryptedKey = keyFormatter.CreateKeyExchange(algorithm.Key, algorithm.GetType());

                        // Create byte arrays to get the length of the encryption key and IV. 
                        var keyLength = BitConverter.GetBytes(encryptedKey.Length);
                        var ivLength = BitConverter.GetBytes(algorithm.IV.Length);

                        // Write the following to the out stream: 
                        // 1) the length of the encryption key.
                        // 2) the length of the IV.
                        // 3) the encryption key.
                        // 4) the IV.
                        // 5) the encrypted data.

                        outStream.Write(keyLength, 0, 4);
                        outStream.Write(ivLength, 0, 4);
                        outStream.Write(encryptedKey, 0, encryptedKey.Length);
                        outStream.Write(algorithm.IV, 0, algorithm.IV.Length);

                        // Create a CryptoStream that will write the encypted data to the underlying buffer.
                        using (var encrypt = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write))
                        {
                            // Write all the data to the stream.
                            encrypt.Write(bytesToEncypt, 0, bytesToEncypt.Length);
                            encrypt.FlushFinalBlock();

                            // Return the encrypted buffered data as a byte[].
                            return outStream.ToArray();
                        }
                    }
                }
            }
        }

        void ValidateX509Config()
        {
            if (string.IsNullOrEmpty(this._certificateSubjectName))
                throw new NotSupportedException("If you are using asymmetric encryption mode you must provide the subject name of the certificate you want to use.");

            this._certificate = this.GetCertificate();

            if (this._certificate == null)
                throw new NotSupportedException(
                    string.Format("If you are using asymmetric encryption mode you must ensure there is a certificate in your local machine store with the subject name '{0}'.", this._certificateSubjectName));

            if (!this._certificate.HasPrivateKey)
                throw new NotSupportedException("Your certificate does not contain a private key.");
        }

        X509Certificate2 GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            try
            {
                store.Open(OpenFlags.ReadOnly);

                foreach (var cert in store.Certificates)
                    if (cert.SubjectName.Name.Equals(this._certificateSubjectName, StringComparison.InvariantCultureIgnoreCase))
                        return cert;

                return null;
            }
            finally
            {
                store.Close();
            }
        }

        #endregion

        public void CombineEncryptedReports(string directoryPath, string combinedReportPath)
        {
            // Ensure the report directory exists.
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException(directoryPath);

            // Get all <report>.xml files.
            var reportsToProcess = Directory.GetFiles(directoryPath, "*.xml");

            // If there are no report files, return.
            if (reportsToProcess.Count() == 0)
                return;

            // Decrypt each of the reports.
            foreach (var report in reportsToProcess)
                this.DecryptReport(report);

            // Combine each report into a single .docx file.
            this.GenerateCombinedReport(reportsToProcess, combinedReportPath);

            // Encrypt the reports.
            foreach (var report in reportsToProcess)
                this.EncryptReport(report);

        }

        
        public byte[] Decrypt(byte[] bytesToDecrypt)
        {
            // Ensure we have a valid certificate.
            ValidateX509Config();

            return this.DecryptWithX509(bytesToDecrypt);
        }

        public void DecryptReport(string reportPath)
        {
            // Ensure report file exists.
            if (!File.Exists(reportPath))
                throw new FileNotFoundException("File not found", reportPath);

            // Read the report into memory.
            var encryptedReport = File.ReadAllBytes(reportPath);

            // Decrypt the report.
            var decryptedReport = Decrypt(encryptedReport);

            // Write the decrypted report to disk.
            File.WriteAllBytes(reportPath, decryptedReport);
        }

        private void GenerateCombinedReport(IEnumerable<string> reportPaths, string combinedReportPath)
        {
            CreateBlankDocument();
            AppendHeading("Class Grade Report: " + DateTime.Now.ToShortDateString());
            InsertPageBreak();

            foreach (var reportPath in reportPaths)
            {
                MergeDocument(reportPath);
                InsertPageBreak();
            }

            Print(combinedReportPath);
        }


        byte[] DecryptWithX509(byte[] bytesToDecrypt)
        {

            // TODO: Exercise 2: Task 1a: Get the private key from the X509 certificate.
             throw new NotImplementedException();
          

            // TODO: Exercise 2: Task 1b: Create an instance of the AesManaged algorithm which the data is encrypted with.
            
            // TODO: Exercise 2: Task 1c: Create a stream to process the bytes.
                
            // TODO: Exercise 2: Task 1d: Create byte arrays to get the length of the encryption key and IV. 
                    

            // TODO: Exercise 2: Task 1e: Read the key and IV lengths starting from index 0 in the in stream.
                    

            // TODO: Exercise 2: Task 1f: Convert the lengths to ints for later use.
                    

            // TODO: Exercise 2: Task 1g: Determine the starting position and length of the data.
                    

            // TODO: Exercise 2: Task 1h: Create the byte arrays for the encrypted key, the IV, and the encrypted data.
                    

            // TODO: Exercise 2: Task 1i: Read the key, IV, and encrypted data from the in stream.
                    

            // TODO: Exercise 2: Task 1j: Decrypt the encrypted AesManaged encryption key. 
                    

            // TODO: Exercise 2: Task 1k: Create an underlying stream for the decrypted data.
                    

            // TODO: Exercise 2: Task 1l: Create an AES decryptor based on the key and IV.
                        

            // TODO: Exercise 2: Task 1m: Create a CryptoStream that will write the decrypted data to the underlying buffer.
                            

            // TODO: Exercise 2: Task 1n: Write all the data to the stream.
                                

            // TODO: Exercise 2: Task 1o: Return the decrypted buffered data as a byte[].
                                
                            
        }

        public void Print(string filePath)
        {
            var currentDocument = this._word.ActiveDocument;
            
            // Call the PrintOut method for the Word document.
            // During development, this will print to the default XPS Document Writer and hence require a filename and path.
            // In production, this will print to the users default printer.
            currentDocument.PrintOut();

            // Close the document without saving it to disk (to avoid storing the confidential report data in an unencrypted state.
            object oFalse = false; 
            currentDocument.Close(ref oFalse);
        }

        #region IDisposable Members

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (this._word != null)
                {
                    this._word.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(this._word);
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
