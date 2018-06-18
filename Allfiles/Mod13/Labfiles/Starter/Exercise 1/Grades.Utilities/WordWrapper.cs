using System;
using System.IO;
using System.Configuration;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Grades.Utilities
{
    /// <summary>
    /// Represents the <see cref="Contoso.Services.WordWrapper"/> class in the object model.
    /// </summary>
    public class WordWrapper : IDisposable
    {
        dynamic _word = null;
        X509Certificate2 _certificate;
        string _certificateSubjectName;

        /// <summary>
        /// Creates an instance of the WordWrapper class.
        /// </summary>
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
        /// Saves the current document.
        /// </summary>
        /// <param name="filePath">The absolute file path.</param>
        public void SaveAs(string filePath)
        {
            var currentDocument = this._word.ActiveDocument;

            currentDocument.SaveAs(filePath);
            currentDocument.Close();
        }

        private Range GetEndOfDocument()
        {
            return this._word.ActiveDocument.Range(this._word.ActiveDocument.Content.End - 1);
        }

        ~WordWrapper()
        {
            this.Dispose(false);
        }

        #endregion

        public byte[] EncryptWithX509(byte[] bytesToEncrypt)
        {

            // TODO: Exercise 1: Task 3a: Get the public key from the X509 certificate.
            throw new NotImplementedException();
            

            // TODO: Exercise 1: Task 3b: Create an instance of the AesManaged algorithm.
            
            // TODO: Exercise 1: Task 3c: Create an underlying stream for the unencrypted data.
                
            // TODO: Exercise 1: Task 3d: Create an AES encryptor based on the key and IV.
                    

            // TODO: Exercise 1: Task 3e: Create byte arrays to get the length of the encryption key and IV. 
                        

            // TODO: Exercise 1: Task 3f: Write the following to the out stream: 
            // 1) the length of the encryption key.
            // 2) the length of the IV.
            // 3) the encryption key.
            // 4) the IV.

                       

            // TODO: Exercise 1: Task 3g: Create a CryptoStream that will write the encypted data to the underlying buffer.
                        
            // TODO: Exercise 1: Task 3h: Write all the data to the stream.
                            

            // TODO: Exercise 1: Task 3i: Return the encrypted buffered data as a byte[].
                           
                       
                   
                
            
        }

        public byte[] Encrypt(byte[] bytesToEncypt)
        {
            // Ensure we have a valid certificate.
            this.ValidateX509Config();

            return this.EncryptWithX509(bytesToEncypt);
        }

        void ValidateX509Config()
        {
            if (string.IsNullOrEmpty(this._certificateSubjectName))
                throw new NotSupportedException("If you are using asymmetric encryption mode you must provide the subject name of the certificate you want to use.");

            // Retrieve the Grades certificate from the certificate store.
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

                // TODO: Exercise 1: Task 2a: Loop through the certificates in the X509 store to return the one matching _certificateSubjectName.

                return null;
            }
            finally
            {
                store.Close();
            }
        }

        public void EncryptAndSaveToDisk(string filePath)
        {
            var currentDocument = this._word.ActiveDocument;

            // Get the current word document as XML.
            var documentAsXml = currentDocument.Content.XML;

            // Get the bytes ready for encryption.
            var rawBytes = Encoding.Default.GetBytes(documentAsXml);

            // Encrypt the raw bytes.
            var encryptedBytes = this.Encrypt(rawBytes);

            // TODO: Exercise 1: Task 4a: Write the encrypted bytes to disk.
            

            // Close the current document and discard changes.
            currentDocument.Close(false);
        }

        #region IDisposable Members

        private bool isDisposed = false;

        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    // Release managed resources here
                    if (this._word != null)
                    {
                        this._word.Quit();
                    }
                }
                try{
                    // Release unmanaged resources here
                    if (this._word != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(this._word);
                    }
                }catch
                {
                
                }
                this.isDisposed = true;
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
