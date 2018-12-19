# Module 13: Encrypting and Decrypting Data

## Lab: Encrypting the Grades Report

### Scenario

You have been asked to update the Grades application to ensure that reports are secure when they are stored on a user's computer.
You decide to use asymmetric encryption to protect the report as it is generated, before it is written to disk.
Administrative staff will need to merge reports for each class into one document, so you decide to develop a separate application that generates a combined report and prints it.

#### Objectives

After completing this lab, you will be able to:

- Encrypt data by using asymmetric encryption.
- Decrypt data.

### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Encrypting the Grades Report

#### Scenario

In this exercise, you will update the reporting functionality to encrypt the report as it is generated, but before it is saved to disk.

First, you will create an asymmetric certificate by using a prewritten batch file. The batch file uses the **MakeCert** tool that ships with the Windows Software Development Kit (SDK).  
You will create a self-signed certificate named **Grades** using the SHA-1 hash algorithm and store it in the LocalMachine certificate store.  
You will then write code in the **Grades** application to retrieve the certificate by looping through the certificates in the LocalMachine store and checking the name of the certificate against the name that is stored in the **App.Config** file.  
Next, you will use the classes that are provided in the **System.Security.Cryptography** and **System.Security.Cryptography.X509Certificates** namespaces to write the **EncryptWithX509** method in the **Grades.Utilities.WordWrapper** class.  
You will get the public key from the certificate that you created and use it to create an instance of the **RSAPKCS1KeyExchangeFormatter** class.  
You will use this to encrypt the data for the report and then return the encrypted buffered data to the calling method as a byte array. You will then write code in the **EncryptAndSaveToDisk** method to write the returned data to the file that the user specifies.  
Finally, you will build and test the application and verify that the reports are now encrypted.

#### Task 1: Create an asymmetric certificate

1. Start File Explorer, navigate to the **[Repository Root]\Allfiles\Mod13\Labfiles\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close File Explorer.
3. Start Visual Studio, from the **[Repository Root]\Allfiles\Mod13\Labfiles\Starter\Exercise 1** folder, open the **Grades.sln** solution .
4. Set the following projects to start at startup:
    - **Grades.Web**
    - **Grades.WPF**
5. In the **Grades.Utilities** project, review the contents of the **CreateCertificate.cmd** file.
6. In a command prompt window running as Administrator, navigate to the **[Repository Root]\Allfiles\Mod13\Labfiles\Starter\Exercise 1\Grades.Utilities** folder, and then run **CreateCertificate.cmd**.
7. Verify that the command returns a success message, and then close the command prompt window.

#### Task 2: Retrieve the Grade certificate

1. In the **Grades.Utilities** project, in the **WordWrapper** class, locate the **GetCertificate** method.
2. Add code to this method to loop through the certificates in the **store.Certificates** collection.
3. Inside the loop, if the **SubjectName.Name** property matches the **\_certificateSubjectName** variable, return the certificate to the calling method.

#### Task 3: Encrypt the data

1. In the **Grades.Utilities** project, in the **WordWrapper** class, locate the **EncryptWithX509** method.
2. Add code to this method to get the public key from the X509 certificate by using the **PublicKey.Key** property, cast it to a **RSACryptoServiceProvider** object, and store it in a variable named **provider**.
3. In the **EncryptWithX509** method, add code to create an instance of the **AesManaged** encryption class named **algorithm**. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
4. Add code to create an instance of the **MemoryStream** class to hold the unencrypted data. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
5. Add the following code to create an AES encryptor based on the key and IV.
    ```cs
    using (var encryptor = algorithm.CreateEncryptor())
    {
        var keyFormatter = new RSAPKCS1KeyExchangeFormatter(provider);
        var encryptedKey = keyFormatter.CreateKeyExchange(algorithm.Key, algorithm.GetType());
    ```
6. Add closing braces for the **using** statement at the end of the method.
7. Add the following code to create byte arrays to get the length of the encryption key and IV.
    ```cs
    var keyLength = BitConverter.GetBytes(encryptedKey.Length);
    var ivLength = BitConverter.GetBytes(algorithm.IV.Length);
    ```
8. Add code to write the following data to the unencrypted memory stream object by using the **Write** method of the **MemoryStream** instance.
    - The length of the secret key.
    - The length of the IV.
    - The encrypted secret key.
    - The IV.
    - The encrypted data.
9. Add code to create an instance of a **CryptoStream** object, passing the unencrypted memory stream, the AES encryptor, and the **CryptoStreamMode.Write** constant as parameters. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
10. Add code to call the **Write** and **FlushFinalBlock** methods of the **CryptoStream** object to write all the data to the memory stream.
11. Add code to return the encrypted buffered data to the calling method.

#### Task 4: Write the encrypted data to disk

In the **Grades.Utilities** project, in the **WordWrapper** class, in the **EncryptAndSaveToDisk** method, add code to write the encrypted bytes to the file path passed to the method.

#### Task 5: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with the password as **password99**.
4. Generate grade reports for **George Li** and **Kevin Liu**, saving each report in the **[Repository Root]\Allfiles\Mod13\Labfiles\Reports** folder.
5. Close the application, and then close the solution.
6. Attempt to open one of the reports that you created in the previous step by using Microsoft Edge and Notepad.

> **Result:** After completing this exercise, you should have updated the **Grades** application to encrypt generated reports.

### Exercise 2: Decrypting the Grades Report

#### Scenario

In this exercise, you will create a separate utility to enable users to print reports.
Users will be able to select a folder that contains encrypted reports, and the application will then generate one combined report and send it to the default printer.

First, you will use the classes that are provided in the **System.Security.Cryptography** and **System.Security.Cryptography.X509Certificates** namespaces to write the
**DecryptWithX509** method in the **SchoolReports.WordWrapper** class.  
You will get the private key from the certificate and use it to create an instance of the **RSACryptoServiceProvider** class. You will use this to decrypt the data from
the individual reports and then return the decrypted data to the calling method as a byte array. Finally, you will build and test the application and verify that a printed version of the composite report has been generated.

#### Task 1: Decrypt the data

1. In Visual Studio, open the **School-Reports.sln** solution from the **[Repository Root]\Allfiles\Mod13\Labfiles\Starter\Exercise 2** folder.
2. In the **WordWrapper** class, locate the **DecryptWithX509** method.
3. Add code to this method to get the private key from the X509 certificate by  using the **PrivateKey** property, cast it to a **RSACryptoServiceProvider**  object, and store it in a variable named **provider**.
4. In the **DecryptWithX509** method, add code to create an instance of the **AesManaged** encryption class named **algorithm**. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
5. Add code to create an instance of the **MemoryStream** class, passing the byte array that the method received as a parameter. Enclose this line of code in a **using** statement and add closing braces at the end of themethod.
6. Add the following code to create byte arrays to get the length of the encryption key and IV.
    ```cs
    var keyLength = new byte[4];
    var ivLength = new byte[4];
    ```
7. Add code to read the key and IV lengths from index 0 in the memory stream and then convert the two lengths to integers.
8. Add code to determine the starting position and length of the encrypted data.
9. Add code to create byte arrays to store the encrypted key, the IV, and the encrypted data.
10. Add code to read the key, IV, and encrypted data from the memory stream and store them in the byte arrays that you have just created.
11. Add code to decrypt the encrypted AES managed key by calling the **Decrypt** method of the **provider** object.
12. Add code to create a new instance of the **MemoryStream** class to store the decrypted data. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
13. Add code to create an AES decryptor object, passing the decrypted key and the IV as parameters. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
14. Add code to create an instance of a **CryptoStream** object, passing the memory stream for the decrypted data, the AES decryptor, and the **CryptoStreamMode.Write** constant as parameters. Enclose this line of code in a **using** statement and add closing braces at the end of the method.
15. Add code to call the **Write** and **FlushFinalBlock** methods of the **CryptoStream** object to write all of the data to the memory stream.
16. Add code to return the decrypted buffered data to the calling method.

#### Task 2: Build and test the solution

1. Build the solution, and then resolve any compilation errors.
2. Run the application, and then print a composite report that contains the two reports that you generated earlier. Save the .oxps file in the **[Repository Root]\Allfiles\Mod13\Labfiles\Reports\ClassReport** folder.
3. Close the application, close the solution, and then close Visual Studio.
4. Open the composite report in XPS Viewer and verify that the data has printed correctly.

> **Result:** After completing this exercise, you should have a composite unencrypted report that was generated from the encrypted reports.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
