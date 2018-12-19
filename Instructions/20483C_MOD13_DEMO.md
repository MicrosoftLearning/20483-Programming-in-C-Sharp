
# Module 13: Encrypting and Decrypting Data

## Lesson 1: Implementing Symmetric Encryption

### Demonstration: Encrypting and Decrypting Data

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]\Allfiles\Mod13\Democode\FourthCoffee.MessageSafe**, and then open the **FourthCoffee.MessageSafe.sln** file.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
3. In **Solution Explorer**, expand **FourthCoffee.MessageSafe** project, double-click **App.config**.
4. Locate the following line:
    ```xml
   <add key="EncryptedFilePath" value="[Repository Root]\Allfiles\Mod13\Democode\Data"/>
    ```
5. Replace **[Repository Root]** with your **Repository Path**.

#### Demonstration Steps

1. In Visual Studio, on the **View** menu, click **Task List**.
2. In the **Task List** window, double-click the **TODO: 01: Instantiate the _algorithm object** task.
3. Explain that the following code creates an instance of the **AesManaged** class.
    ```cs
    this._algorithm = new AesManaged();
    ```
4. Double-click the **TODO: 02: Dispose of the _algorithm object** task.
5. Explain that the following code invokes the **Dispose** method to release any resources that the algorithm may have used after determining that the **_algorithm** object is not null.
    ```cs
    if (this._algorithm != null)
    {
        this._algorithm.Dispose();
    }
    ```
6. Double-click the **TODO: 03: Derive a Rfc2898DeriveBytes object from the password and salt** task.
7. Explain that the following code creates an instance of the **Rfc2898DeriveBytes** class by using a password (that the user provides at run time) and salt (hard-coded value in the application).
    ```cs
    return new Rfc2898DeriveBytes(password, this._salt);
    ```
8. Double-click the **TODO: 04: Generate the secret key by using the Rfc2898DeriveBytes object** task.
9. Explain that the following code uses the **Rfc2898DeriveBytes** object to derive the secret key by using the algorithm’s key size in bytes.
    ```cs
    return passwordHash.GetBytes(this._algorithm.KeySize / 8);
    ```
    > **Note:** The **KeySize** property returns the size of the key in bits, so to get the value in bytes, you divide the value by 8.
10. Double-click the **TODO: 05: Generate the IV by using the Rfc2898DeriveBytes object** task.
11. Explain that the following code uses the **Rfc2898DeriveBytes** object to derive the IV by using the algorithm’s block size in bytes.
    ```cs
    return passwordHash.GetBytes(this._algorithm.BlockSize / 8);
    ```
    > **Note:** The **BlockSize** property returns the size of the block in bits, so to get the value in bytes, you divide the value by 8.
12. Double-click the **TODO: 06: Create a new MemoryStream object** task.
13. Explain that the following code creates an instance of the **MemoryStream** class, which will be used as a buffer for the transformed data.
    ```cs
    var bufferStream = new MemoryStream();
    ```
14. Double-click the **TODO: 07: Create a new CryptoStream object** task.
15. Explain that the following code creates an instance of the **CryptoStream** class, which will transform the data and write it to the underlying memory stream.
    ```cs
    var cryptoStream = new CryptoStream(bufferStream, transformer, CryptoStreamMode.Write);
    ```
16. Double-click the **TODO: 08: Write the bytes to the CryptoStream object** task.
17. Explain that the following code writes the transformed data to the underlying memory stream.
    ```cs
    cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);
    cryptoStream.FlushFinalBlock();
    ```
18. Double-click the **TODO: 09: Read the transformed bytes from the MemoryStream object** task.
19. Explain that the following code uses the **ToArray** method to extract the transformed data from the memory stream as a byte array.
    ```cs
    var transformedBytes = bufferStream.ToArray();
    ```
20. Double-click the **TODO: 10: Close the CryptoStream and MemoryStream objects** task.
21. Explain that the following code closes the **cryptoStream** and **bufferStream** objects.
    ```cs
    cryptoStream.Close();
    bufferStream.Close();
    ```
22. Double-click the **TODO: 11: Use the _algorithm object to create an ICryptoTransform encryptor object** task.
23. Explain that the following code creates an **ICryptoTransform** object that will encrypt data.
    ```cs
    var transformer = this._algorithm.CreateEncryptor(key, iv);
    ```
24. Double-click the **TODO: 12: Invoke the TransformBytes method and return the encrypted bytes** task.
25. Explain that the following code invokes the **TransformBytes** helper method, which will use the **ICryptoTransform** object to encrypt the data.
    ```cs
    return this.TransformBytes(transformer, bytesToEncypt);
    ```
26. Double-click the **TODO: 13: Use the _algorithm object to create an ICryptoTransform decryptor object** task.
27. Explain that the following code creates an **ICryptoTransform** object that will decrypt data.
    ```cs
    var transformer = this._algorithm.CreateDecryptor(key, iv);
    ```
28. Double-click the **TODO: 14: Invoke the TransformBytes method and return the decrypted bytes** task.
29. Explain that the following code invokes the **TransformBytes** helper method, which will use the **ICryptoTransform** object to decrypt the data.
    ```cs
    return this.TransformBytes(transformer, bytesToDecypt);
    ```
30. On the **Build** menu, click **Build Solution**.
31. On the **Debug** menu, click **Start Without Debugging**.
32. In the **Fourth Coffee Message Safe** application, in the **Password** text box, type **Pa$$w0rd**.
33. In the **Message** text box, type **This is my secure message**, and then click **Save**.
34. Close the **Fourth Coffee Message Safe** application.
35. Open File Explorer and browse to the **[Repository Root]\Allfiles\Mod13\Democode\Data** folder.
36. Double-click **protected_message.txt**, and then view the encrypted text in Notepad.
37. Close Notepad, and then close File Explorer.
38. In Visual Studio, on the **Debug** menu, click **Start Without Debugging**.
39. In the **Fourth Coffee Message Safe** application, in the **Password** text box, type **Pa$$w0rd**, and then click **Load**.
40. Verify that the **Message** text box now displays the text **This is my secure message**.
41. Close the **Fourth Coffee Message Safe** application.
42. Close Visual Studio 2017.

## Lesson 2:   Implementing Asymmetric Encryption

### Demonstration:  Encrypting and Decrypting Grade Reports Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize the database.
   - In the **Apps** list, click **File Explorer**.
   - In File Explorer, navigate to the **[Repository Root]\Allfiles\Mod13\Labfiles\Databases** folder, and then double-click **SetupSchoolGradesDB.cmd**.
    > **NOTE :** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
   - Close File Explorer.

#### Demonstration Steps

1. From the **[Repository Root]\Allfiles\Mod13\Labfiles\Solution\Exercise 1** folder, open the **Grades.sln** solution.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In **Solution Explorer**, right-click **Solution ‘Grades’**, and then click **Properties**.
3. On the **Startup Project** page, click **Multiple startup projects**. Set **Grades.Web** and **Grades.WPF** to **Start**, and then click **OK**.
4. Open **Windows Menu** and type **Developer Command Prompt for VS 2017**, right click on the app then select **Run as adiministrator**.
5. Paste the following command and then press **Enter**:
    ```cs
    cd "[Repository Root]\Allfiles\Mod13\Labfiles\Solution\Exercise 1\Grades.Utilities"
    ```
6. Paste the following command and then press **Enter**:
    ```cs
    CreateCertificate.cmd
    ```
7. Explain that this command file creates a new certificate that the students will use to encrypt the grade report.
8. Point out that the students need to run the command prompt window as an administrator for the command to succeed.
9. In the **Grades.Utilities** folder, open **WordWrapper.cs**, and then locate the **EncryptWithX509** method.
10. Explain to the students that during Exercise 1, they will add the code in this method to encrypt the grade report.
11. Run the application, and then log on as **vallee** with the password **password99**.
12. Generate grade reports for **George Li** and **Kevin Liu**. Save each report in the **[Repository Root]\AllFiles\\Mod13\Labfiles\Reports** folder.
13. Close the application, and then attempt to open one of the reports that you created in the previous step by using Notepad to show the encrypted data.
14. From the **[Repository Root]\Allfiles\Mod13\Labfiles\Solution\Exercise 2** folder, open the **Schools-Reports.sln** solution.
15. Open **WordWrapper.cs**, and then locate the **DecryptWithX509** method.
16. Explain to the students that during Exercise 2, they will add the code in this method to decrypt the reports.
17. Run the application, and then print a composite report that contains the two reports that you generated earlier. Save the **CompositeReport** file in the **[Repository Root]\Allfiles\Mod13\Labfiles\Reports\ClassReport** folder.
18. Close the application, click Stop Debugging and then close Visual Studio.
19. Open the composite report by double click on the file.
20. Open File Explorer and delete the contents of the **[Repository Root]\Allfiles\Mod13\Labfiles\Reports** and **[Repository Root]\Allfiles\Mod13\Labfiles\Reports\ClassReport** folders and then close File Explorer.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
