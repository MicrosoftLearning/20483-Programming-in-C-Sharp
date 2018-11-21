# Module 1:  Developing the Code for a Graphical Application

## Lesson 3:  Visual C# Programming Language Constructs

### Demonstration: Developing the Class Enrollment Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize database:
    - In the **Apps list**, click **File Explorer**.
    - In **File Explorer**, navigate to the **[Repository Root]\AllFiles\Mod01\Labfiles\Databases** folder, and then double-click **SetupSchoolDB.cmd**.
        >**Note:** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
    - Close **File Explorer**.

#### Demonstration Steps

1. From the **[Repository Root]\AllFiles\Mod01\Labfiles\Solution\Exercise 4** folder, open the **School.sln** solution.
    >**Note:** If any security warning appears, click **OK**.
2. Run the application, select a student name, and then press Enter to edit that student’s details.
3. Update the **First Name** and **Last Name** text boxes to contain your name, and then click **OK**. Point out to students that this has updated the information in the main application window.
4. Press **Insert**. Enter information for a new student (ensuring that you type a valid date of birth in the following format: mm/dd/yyyy), and then click **OK**.
5. Point out to students that this has added a new student to the student list for the class, and that the application has correctly translated their date of birth into the age that is displayed.
6. In the student list, click the student that you just added, and then press **Delete**.
7. In the **Confirm** dialog box, click **Yes**, and then point out to students that the student has been removed from the list of students in the class.
8. Close the application.
9. Open **MainWindow.xaml.cs** and locate the **studentsList_KeyDown** method.
10. Explain to students that in Exercises 1, 2, and 3, they will add the code in this method to test which key a user pressed, and then enable the user to edit a student’s details, insert a new student into the class, or remove a student from the class.
11. In **MainWindow.xaml.cs**, locate the **Convert** method in the **AgeConverter** class.
12. Explain to students that during Exercise 4, they will add code to this method to convert the date of birth that a user provides into the age to be displayed in the list of students.
13. Close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
