
# Module 13:  Encrypting and Decrypting Data

# Lesson 1:  Implementing Symmetric Encryption

### Demonstration: Encrypting and Decryptinh Data

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod13\Democode\FourthCoffee.MessageSafe**, and then open the **FourthCoffee.MessageSafe.sln** file.


#### Demonstration Steps

1.	In Visual Studio, on the **View** menu, click **Task List**.
2.	In the **Task List** window, in the **Categories** list, click **Comments**.
3.	Double-click the **TODO: 01: Instantiate the _algorithm object**. task.
4.	Explain that the following code creates an instance of the **AesManaged** class.
    ```cs
    this._algorithm = new AesManaged();
    ```
5.	Double-click the **TODO: 02: Dispose of the _algorithm object**. task.
6.	Explain that the following code determines whether the **_algorithm** object is not null and then invokes the **Dispose** method to release any resources that the algorithm may have used.
    ```cs
    if (this._algorithm != null)
    {
       this._algorithm.Dispose();
    }
    ```
7.	Double-click the **TODO: 03: Derive a Rfc2898DeriveBytes object from the password and salt**. task.
8.	Explain that the following code creates an instance of the **Rfc2898DeriveBytes** class by using a password (that the user provides at run time) and salt (hard-coded value in the application).
    ```cs
    return new Rfc2898DeriveBytes(password, this._salt);
    ```
9.	Double-click the **TODO: 04: Generate the secret key by using the Rfc2898DeriveBytes object**. task.
10.	Explain that the following code uses the **Rfc2898DeriveBytes** object to derive the secret key by using the algorithm’s key size in bytes.
    ```cs
    return passwordHash.GetBytes(this._algorithm.KeySize / 8);
    ```
    >**Note :** The KeySize property returns the size of the key in bits, so to get the value in bytes, you divide the value by 8.


11.	Double-click the **TODO: 05: Generate the IV by using the Rfc2898DeriveBytes object.** task.
12.	Explain that the following code uses the **Rfc2898DeriveBytes** object to derive the IV by using the algorithm’s block size in bytes.
    ```cs
    return passwordHash.GetBytes(this._algorithm.BlockSize / 8);
    ```
    >**Note :** The BlockSize property returns the size of the block in bits, so to get the value in bytes, you divide the value by 8.

13.	Double-click the **TODO: 06: Create a new MemoryStream object**. task.
14.	Explain that the following code creates an instance of the **MemoryStream** class, which will be used as a buffer for the transformed data.
    ```cs
    var bufferStream = new MemoryStream();
    ```
15.	Double-click the **TODO: 07: Create a new CryptoStream object**. task.
16.	Explain that the following code creates an instance of the **CryptoStream** class, which will transform the data and write it to the underlying memory stream.
    ```cs
    var cryptoStream = new CryptoStream(
       bufferStream, 
       transformer, 
       CryptoStreamMode.Write);
    ```
17.	Double-click the **TODO: 08: Write the bytes to the CryptoStream object**. task.
18.	Explain that the following code writes the transformed data to the underlying memory stream.
    ```cs
    cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
    cryptoStream.FlushFinalBlock();
    ```
19.	Double-click the **TODO: 09: Read the transformed bytes from the MemoryStream object**. task.
20.	Explain that the following code uses the **ToArray** method to extract the transformed data from the memory stream as a byte array.
    ```cs
    var transformedBytes = bufferStream.ToArray();
    ```
21.	Double-click the **TODO: 10: Close the CryptoStream and MemoryStream objects**. task.
22.	Explain that the following code closes the **cryptoStream** and **bufferStream** objects.
    ```cs
    cryptoStream.Close(); 
    bufferStream.Close();
    ```
23.	Double-click the **TODO: 11: Use the _algorithm object to create an ICryptoTransform encryptor object.** task.
24.	Explain that the following code creates an **ICryptoTransform** object that will encrypt data.
    ```cs
    var transformer = this._algorithm.CreateEncryptor(key, iv);
    ```
25.	Double-click the **TODO: 12: Invoke the TransformBytes method and return the encrypted bytes**. task.
26.	Explain that the following code invokes the **TransformBytes** helper method, which will use the **ICryptoTransform** object to encrypt the data.
    ```cs
    return this.TransformBytes(transformer, bytesToEncypt);
    ```
27.	Double-click the **TODO: 13: Use the _algorithm object to create an ICryptoTransform decryptor object**. task.
28.	Explain that the following code creates an **ICryptoTransform** object that will decrypt data.
    ```cs
    var transformer = this._algorithm.CreateDecryptor(key, iv);
    ```
29.	Double-click the **TODO: 14: Invoke the TransformBytes method and return the decrypted bytes**. task.
30.	Explain that the following code invokes the **TransformBytes** helper method, which will use the **ICryptoTransform** object to decrypt the data.
    ```cs
    return this.TransformBytes(transformer, bytesToDecypt);
    ```
31.	On the **Build** menu, click **Build Solution**.
32.	On the **Debug** menu, click **Start Without Debugging**.
33.	In the **Fourth Coffee Message Safe** application, in the **Password** box, type **Pa$$w0rd**.
34.	In the **Message** box, type This is my **secure message**, and then click **Save**.
35.	Close the Fourth Coffee Message Safe application.
36.	Open File Explorer, and browse to the **Allfiles\Mod13\Democode\Data** folder.
37.	Double-click **protected_message.txt**, and then view the encrypted text in Notepad.
38.	Close Notepad, and then close File Explorer.
39.	In Visual Studio, on the **Debug** menu, click **Start Without Debugging**.
40.	In the **Fourth Coffee Message Safe** application, in the **Password** box, type **Pa$$w0rd**, and then click **Load**.
41.	Verify that the **Message** box now displays the text **This is my secure message**.
42.	Close the Fourth Coffee Message Safe application.
43.	Close Visual Studio 2017.


# Lesson 2:   Implementing Asymmetric Encyption

### Demonstration:  Encryptiong and Decrypting Grade Reports Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Open the **Grades.sln** solution from the
    **[Repository Root]\\Mod13\\Labfiles\\Solution\\Exercise 1** folder.
2.  In Solution Explorer, right-click **Solutions ‘Grades’**, and then click
    **Properties**.
3.  On the **Startup Project** page, click **Multiple startup projects**. Set
    **Grades.Web** and **Grades.WPF** to **Start without debugging**, and then
    click **OK**.
4.  In the **Grades.Utilities** project, open **CreateCertificate.cmd**.
5.  Explain that this command file creates a new certificate that students will
    use to encrypt the grade report.
6.  Point out that students need to run a command window as an administrator for
    the command to succeed.
7.  In the **Grades.Utilities** folder, open **WordWrapper.cs**, and then locate
    the **EncryptWithX509** method.
8.  Explain to students that during Exercise 1, they will add the code in this
    method to encrypt the grade report.
9.  Run the application, and then log on as **vallee** with a password of
    **password99**.
10. Generate grade reports for George Li and Kevin Liu. Save each report in the
    **[Repository Root]\\Mod13\\Labfiles\\Reports** folder.
11. Close the application, and then attempt to open one of the reports that you
    created in the previous step by using Windows Internet Explorer® and Notepad
    to show the encrypted data.
12. Open the **Schools-Reports.sln** solution from the
    **[Repository Root]\\Mod13\\Labfiles\\Solution\\Exercise 2** folder.
13. Open **WordWrapper.cs**, and then locate the **DecryptWithX509** method.
14. Explain to students that during Exercise 2, they will add the code in this
    method to decrypt the reports.
15. Run the application, and then print a composite report that contains the two
    reports that you generated earlier. Save the **CompositeReport.oxps** file
    in the **[Repository Root]\\Mod13\\Labfiles\\Reports\\ClassReport** folder.
16. Close the application, and then close Visual Studio.
17. Open the composite report in the XPS Viewer and review the contents of the
    report.
18. Open File Explorer and delete the contents of th**e**
    [Repository Root]\\Mod13\\Labfiles\\Reports and [Repository Root]\\Mod13\\Labfiles\\Reports\\ClassReport
    folders and then close File Explorer.


©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.   