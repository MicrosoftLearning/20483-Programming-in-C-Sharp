# Module 2: Creating Methods, Handling Exceptions, and Monitoring Applications

## Lesson 1: Creating and Invoking Methods

### Demonstration: Creating, Invoking, and Debugging Methods

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]Allfiles/Mod02/Democode/Starter/FourthCoffee.MethodTestHarness**, and then open the **FourthCoffee.MethodTestHarness.sln** file.
    >**Note:** If any security warning appears, click **OK**.

#### Demonstration Steps

1. In Visual Studio, on the **View** menu, click **Task List**.
2. In the **Task List** window, double-click the **TODO: 01: Define the Initialize method.** task.
3. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    bool Initialize()
    {
        var path = GetApplicationPath();

        return !string.IsNullOrEmpty(path);
    }
    ```
4. In the **Task List** window, double-click the **TODO: 02: Invoke the Initialize method.** task.
5. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var isInitialized = Initialize();
    ```
6. Right-click the call to the **Initialize** method, point to **Breakpoint**, and then click **Insert Breakpoint**.
7. On the **Build** menu, click **Build Solution**.
8. On the **Debug** menu, click **Start Debugging**.
9. To step into the **Initialize** method, press F11.
10. To step to the **GetApplicationPath** method call, press F10.
11. To step over the **GetApplicationPath** method call, press F10.
12. To step out of the **Initialize** method, press Shift+F11.
13. To step over the **Initialize** method call, press F10.
14. Place your mouse over the **isInitialized** variable, and verify that the value returned is **true**.
15. On the **Debug** menu, click **Stop Debugging**.
16. On the **File** menu, click **Close Solution**.

## Lesson 4: Monitoring Applications

### Demonstration: Extending the Class Enrollment Application Functionality Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize database:
    - In the **Apps list**, click **File Explorer**.
    - In **File Explorer**, navigate to the **[Repository Root]\AllFiles\Mod02\Labfiles\Databases** folder, and then double-click **SetupSchoolDB.cmd**.
        >**Note:** If a Windows protected your PC dialog appears, click More info and then click Run Anyway.
    - Close **File Explorer**.

#### Demonstration Steps

1. From the **[Repository Root]\Allfiles\Mod02\Labfiles\Solution\Exercise 3** folder, open the **School.sln** solution.
   >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. Open **MainWindow.xaml.cs** and locate the **studentsList_KeyDown** method.
3. Explain to students that in Exercise 1 they will refactor the code that they added to this method in Lab 1 into separate methods that can be called from multiple locations.
4. Show students the refactored code in the **EditStudent**, **AddNewStudent**, and **RemoveStudent** methods.
5. Show students the **studentsList_MouseDoubleClick** method and explain that the call to the **editStudent** method also uses the refactored code.
6. Open **StudentForm.xaml.cs** and locate the **ok_Click** method.
7. Explain to students that in Exercise 2 they will add code to this method to check that the user input is valid before returning to the main form.
8. Open **MainWindow.xaml.cs** and locate the **saveChanges_Click** method.
9. Explain to students that in Exercise 3 they will add code to save the changes back to the database and handle any errors that might occur.
10. Run the application and double-click a student to edit their details. Point out to students that the **studentsList_MouseDoubleClick** method calls the refactored **EditStudent** method.
11. Enter data that is not valid in one of the fields, and then show the students the error message that appears.
12. Enter valid data, and then in the main window, click **Save Changes**.
13. Close the application.
14. Run the application again and show that the changes they made have been saved to the database.
15. Close the application, and then close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
