# Module 1:  Developing the Code for a Graphical Application

# Lesson 3:  Visual C# Programming Language Constructs

### Demonstration: Developing the Class Enrollment Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles


1.  Read the Lab Scenario to students and point out that they should read each
    scenario before attempting the lab for a module.
2.  Point out to students that the Exercise Scenario for each exercise contains
    a description of what they will accomplish in the exercise, and is also
    essential reading.
3.  Open the **School.sln** solution from the
    **E:\\Mod01\\Labfiles\\Solution\\Exercise 4** folder.
4.  Run the application, select a student name, and then press Enter to edit
    that student’s details.
5.  Update the **First Name** and **Last Name** boxes to contain your name, and
    then click **OK**. Point out to students that this has updated the
    information in the main application window.
6.  Press Insert, enter information for a new student (ensuring that you type a
    valid date of birth in the following format: mm/dd/yyyy), and then click
    **OK**.
7.  Point out to students that this has added a new student to the student list
    for the class, and that the application has correctly translated their date
    of birth into the age that is displayed.
8.  In the student list, click the student that you just added, and press
    Delete.
9.  In the **Confirm** dialog box, click **Yes**, and then point out to students
    that the student has been removed from the class.
10. Close the application.
11. Open **MainWindow.xaml.cs** and locate the **studentsList_KeyDown** method.
12. Explain to students that during Exercises 1, 2, and 3, they will add the
    code in this method to test which key a user pressed, and then enable the
    user to edit a student’s details, insert a new student into the class, or
    remove a student from the class.
13. In **MainWindow.xaml.cs**, locate the **Convert** method in the
    **AgeConverter** class.
14. Explain to students that during Exercise 4, they will add code to this
    method to convert the date of birth that a user enters into the age to be
    displayed in the list of students.
15. Close Visual Studio.






©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
