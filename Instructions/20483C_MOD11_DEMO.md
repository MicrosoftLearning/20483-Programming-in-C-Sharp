
# Module 11: Integrating with Unmanaged Code

## Lesson 1: Creating and using Dynamic Objects

### Demonstration: Interoperation with Microsoft Word

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]\Allfiles\Mod11\Democode\Starter\FourthCoffee.ExceptionLogger**, and then open the **FourthCoffee.ExceptionLogger.sln** file.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.

#### Demonstration Steps

1. In **Solution Explorer**, right-click the **FourthCoffee.ExceptionLogger** project, and then click **Add** and then click **Reference**.
2. In the **Reference Manager – FourthCoffee.ExceptionLogger** dialog box, perform the following steps, and then click **OK**:
    - Expand **COM**, and then click **Type Libraries**.
    - In the **Search** text box, type **Word**.
    - In the assembly list, select **Microsoft Word [Version Number] Object Library**, and then select the **Microsoft Word [Version Number] Object Library** check box.
    > **Note :** [Version Number] can be greater than 14.
3. In Visual Studio, on the **View** menu, click **Task List**.
4. In the **Task List** window, double-click the **TODO: 01: Bring the Microsoft.Office.Interop.Word namespace into scope.** task.
5. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    using Microsoft.Office.Interop.Word;
    ```
6. Double-click the **TODO: 02: Declare a global object to encapsulate Microsoft Word** task.
7. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    dynamic _word;
    ```
8. Double-click the **TODO: 03: Instantiate the _word object** task.
9. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._word = new Application();
    ```
10. Double-click the **TODO: 04: Create a blank Word document** task.
11. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._word.Documents.Add().Activate();
    ```
12. In the code editor, look at the following helper methods that wrap the Word COM API:
    - The **GetEndOfDocument** method places the cursor at the end of the document. The **-1** converts the **End** property to a 0-based index value. Without the **-1**, the CLR will throw an **IndexOutOfRange** exception.
    - The **AppendText** method adds text to the end of the document, in the bold and/or italic style.
    - The **InsertCarriageReturn** method inserts a carriage return at the end of the document.
    - The **Save** method deletes any file with the same name and then saves the current Word document.
13. Double-click the **App.config** file inside the **FourthCoffee.ExceptionLogger** project and change the **[Repository Root]** to your repository destination.
14. On the **Build** menu, click **Build Solution**.
15. On the **Debug** menu, click **Start Without Debugging**.
16. In the **Exception Logger** application, click **Export**.
17. In the **Export Successful** dialog box, click **OK**.
18. Close the **Exception Logger** application.
19. Open File Explorer and browse to the **[Repository Root]\Allfiles\Mod11\Democode\Data\Exceptions** folder.
20. Double-click **Exceptions.docx**, and then view the combined exception report in the Word document.
21. Close Microsoft Word.
22. Close File Explorer.
23. Close Visual Studio.

## Lesson 2: Managing the Lifetime of Objects and Controlling Unmanaged Resources

### Demonstration: Upgrading the Grades Report Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize database:
    - In the **Apps list**, click **File Explorer**.
    - In **File Explorer**, navigate to the **[Repository Root]\Allfiles\Mod11\Labfiles\Databases** folder, and then double-click **SetupSchoolGradesDB.cmd**.
        >**Note :** If a Windows protected your PC dialog appears, click More info and then click Run Anyway.
    - Close **File Explorer**.

#### Demonstration Steps

1. Open the **Grades.sln** solution from the **[Repository Root]\Allfiles\Mod11\Labfiles\Solution\Exercise 2** folder.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In **Solution Explorer**, right-click **Solution ‘Grades’**, and then click **Properties**.
3. On the **Startup Project** page, click **Multiple startup projects**. Set **Grades.Web** and **Grades.WPF** to **Start**, and then click **OK**.
4. Build the solution.
5. In the **Grades.Utilities** project, open **WordWrapper.cs**.
6. Review the code in this class and explain to the students that in Exercise 1, they will write some of the code to start Word and create and save a document.
7. Review the class definition and the dispose pattern implementation and explain to the students that in Exercise 2, they will write this code to control the lifetime of the **Word** object.
8. In the **Grades.WPF** project, in the **Views** folder, Expand **StudentProfile.xaml** and then open **StudentProfile.xaml.cs**, and then locate the **GenerateStudentReport** method.
9. Review the code in this method and explain to the students that in Exercise 1, they will write this code to use the **WordWrapper** class to generate the grade reports and then in Exercise 2, they will update the code to ensure that the **WordWrapper** class is disposed correctly.
10. Open **Task Manager**.
11. In the **Task Manager** window, click **More details**.
12. Run the application and log on as **vallee** with the password **password99**.
13. Generate a grade report for **Kevin Liu**. When you click **save report**, in the **Task Manager** window, verify that **Microsoft Word** appears and then disappears from the **Processes** group.
14. Close the application, and then close **Task Manager**.
15. Open Kevin Liu’s grade report in Word, review the report, and then close Word.
16. Close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
