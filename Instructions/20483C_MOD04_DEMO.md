# Module 4: Creating Classes and Implementing Type-Safe Collections

## Lesson 1: Creating Classes

### Demonstration: Comparing Reference Types and Value Types

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
    >**Note:** If any security warning appears, click **OK**.

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **New**, and then click **Project**.
3. In the **New Project** dialog box, in the **Templates** list, click **Visual C\#**, and then in the **Project Type** list, click **Console App (.NET Framework)**.
4. In the **Name** text box, type **ValuesAndReferences**
5. In the **Location** text box, set the location to **[Repository Root]\Allfiles\Mod04\Democode**, and then click **OK**.
6. Within the **ValuesAndReferences** namespace, add the following code:
    ```cs
    struct MyStruct
    {
       public int Contents;
    }
    ```
7. Immediately below the code you just added, add the following code:
    ```cs
    class MyClass
    {
       public int Contents = 0;
    }
    ```
8. Within the **Program** class, within the **Main** method, add the following code:
    ```cs
    MyStruct struct1 = new MyStruct();
    MyStruct struct2 = struct1;
    struct2.Contents = 100;

    MyClass class1 = new MyClass();
    MyClass class2 = class1;
    class2.Contents = 100;

    Console.WriteLine($"Value types: {struct1.Contents}, {struct2.Contents}");
    Console.WriteLine($"Reference types: {class1.Contents}, {class2.Contents}");
    ```
9. On the **Debug** menu, click **Start without Debugging**. The console window shows the following output:
    ```cs
    Value types: 0, 100
    Reference types: 100, 100
    ```
10. To close the console window, press Enter.
11. Close Visual Studio 2017.

## Lesson 3: Implementing Type-Safe Collections

### Demonstration: Adding Data Validation and Type-Safety to the Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1. From the **[Repository Root]\Allfiles\Mod04\Labfiles\Solution\Exercise 4** folder, open the **GradesPrototype.sln** solution.
    >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In the **Data** folder, open **Grade.cs** and explain to the students that during Exercise 1 they will convert the structs that they created in the previous lab into the classes in this file.
3. In the **Teacher** class, locate the **VerifyPassword** method and explain to the students that they will add this method to both the **Teacher** and **Student** classes to compare the password that the user enters with the password for that user that is currently held in the **DataSource.cs** class.
4. In the **Data** folder, open **DataSource.cs**, and expand the **Sample Data** region.
5. Locate the **Subjects** list definition and explain to the students that during Exercise 2 they will create this list of valid subject names.
6. In **Grade.cs,** locate the **SubjectName** property of the **Grade** class, and then explain to the students that this is where the subject that a user enters is checked against the list of valid subject names before being saved.
7. Explain that they will add similar validation code to ensure that the **AssessmentDate** is not in the future, and that the grade is in the range A+ to E-.
8. In **Grade.cs**, locate the **Student** class definition, and explain to the students that during Exercise 3 they will add code to implement the **IComparable\<Student\>** interface.
9. Locate the **CompareTo** method and explain to the students that they will add this code to compare student names to display them in alphabetical order.
10. In **Grade.cs**, locate the **Teacher** class, and then locate the **EnrolInClass** method.
11. Explain to the students that during Exercise 4 they will add this code to enroll a student in a particular teacher’s class.
12. Locate the **RemoveFromClass** method and explain to the students that they will add this code to remove a student from the user’s class.
13. In the **Controls** folder, open **GradeDialog.xaml**, and then explain to the students that this dialog box is provided for them, but they will add code to take the data entered by the user and add it as a new grade for the student.
14. In the **Views** folder,Expand **StudentProfile.xaml** and then open **StudentProfile.xaml.cs**, locate the **AddGrade_Click** method, and explain to the students that they will add this code to take the data that the user enters in the **GradeDialog** dialog box and save it to the student’s list of grades. Remind them that the data validation code that they add in Exercise 2 will validate the user input here.
15. Run the application and log on as **vallee** with the password **password**.
16. Click **New Student** and add a student named **Darren Parker** with the password **password**.
17. Point out that the student now exists in the data source, but is not yet a member of Class 3C.
18. Click **Enroll Student**, click **Darren Parker**, and then in the **Confirm** message box, click **Yes**, and then click **Close**.
19. Point out that the student now appears in the class list and is a member of this user’s class.
20. Click **Darren Parker**, and then click **Add Grade**.
21. Enter an assessment value that is not valid, type a comment, and then click **OK**.
22. Point out that the data validation code catches the mistake, and then click **OK**.
23. In the **Assessment** box, type **A+**, and then click **OK**.
24. Point out that the grade has been added to the student.
25. Click **Remove Student**, and then in the **Confirm** message box, click **Yes**.
26. Point out that Darren Parker no longer appears in this user’s class.
27. Click **Enroll Student** and explain to the students that even though Darren was removed from this user’s class, he still exists as a student and can be added later to a class.
28. Click **Close**, click **Log off**, and then close the application.
29. Close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
