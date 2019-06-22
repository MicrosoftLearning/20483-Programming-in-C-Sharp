
# Module 7: Accessing a Database

## Lesson 1: Creating and Using Entity Data Models

### Demonstration: Creating an Entity Data Model

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Navigate to the **[Repository Root]\Allfiles\Mod07\Democode\Databases** folder, and then double-click **SetupFourthCoffeeDB.cmd**.
    >**Note:** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
2. Locate **[Repository Root]\Allfiles\Mod07\Democode\Databases** folder again, right-click **FourthCoffee.sql**, point to **Open With**, click **Microsoft Visual Studio Version Selector**, then click **Open**.
3. Review the SQL query.
4. On the **File** menu, click **Close**.
5. On the **File** menu, point to **New**, and then click **Project**.
6. In the **New Project** dialog box, expand **Templates**, click **Visual C\#**, and then in the **Template** list, click **Console App(.NET Framework)**.
7. In the **Name** text box, type **FourthCoffee.Employees**, in the **Location** text box, type **[Repository Root]\Allfiles\Mod07\Democode\Demo1\Starter**, and then click **OK**.
8. In **Solution Explorer**, right-click **FourthCoffee.Employees**, point to **Add**, and then click **New Item**.
9. In the **Add New Item – FourthCoffee.Employees** dialog box, click **ADO.NET Entity Data Model**, in the **Name** text box, type **FourthCoffeeEmployeesModel**, and then click **Add**.
10. In **Entity Data Model Wizard**, on the **Choose Model Contents** page, click **EF Designer from database**, and then click **Next**.
11. On the **Choose Your Data Connection** page, click **New Connection**.
12. On the **Choose Data Source page**, Select **Microsoft SQL Server** and then click **OK**.
13. In the **Server name** text box, type **(localdb)\MSSQLLocalDB**, in the **Select or enter a database name** list, click **FourthCoffee**, and then click **OK**.
14. In **Entity Data Model Wizard**, on the **Choose Your Data Connection** page, click **Next**.
15. In the **Choose Your Version** page, choose **Entity Framework 6.x** and then click **Next**.
16. On the **Choose Your Database Objects and Settings** page, expand **Tables**, expand **dbo**, select **Branches**, **Employees**, and **JobTitles**, and then click **Finish**.
17. If a **Security Warning** dialog box appears, select **Do not show this message again**, and then click **OK**.
18. On the **Build** menu, click **Build Solution**.
19. Review the three entities that have been generated and the associations between them.
20. Right-click the designer surface, and then click **Mapping Details**.
21. In the **Designer** pane, click **Employee**.
22. In the **Mapping Details** pane, review the mappings between the entity and the data source.
23. In **Solution Explorer**, expand **FourthCoffeeEmployeesModel.edmx**, expand **FourthCoffeeEmployeesModel.Context.tt**, and then double-click **FourthCoffeeEmployeesModel.Context.cs**.
24. In the code editor, review the code in the **FourthCoffeeEntities** partial class.
25. In **Solution Explorer**, expand **FourthCoffeeEmployeesModel.tt**, and then double-click **Employee.cs**.
26. Review the **Employee** partial class and the properties that have been generated.
27. Leave the solution open so that you can refer to it in the following topics.

### Demonstration: Reading and Modifying Data in an EDM

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open File** dialog box to, browse to the **[RepositoryRoot]\Allfiles\Mod07\Democode\Demo2\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.
    >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In **Solution Explorer**, expand **FourthCoffee.Employees**, and then double-click **Program.cs**.
5. Review the definition of the **DBContext** variable.
6. Review the code in the **PrintEmployeesList** method that uses the **DBContext** variable to access the data in the EDM.
7. Review the code in the **Main** method that uses the **First** extension method to retrieve an employee and then modifies that employee’s **LastName** property.
8. On the **Build** menu, click **Build Solution**.
9. On the **Debug** menu, click **Start Without Debugging**.
10. Verify that the employees list is displayed, and then press Enter.
11. Verify that the employee named **Diane Prescott** is now named **Diane Forsyth** and then press Enter.
12. To close the application, press Enter.

## Lesson 2: Querying Data by Using LINQ

### Demonstration: Querying Data

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\Allfiles\Mod07\Democode\Demo3\FourthCoffee.Employees** folder, click **FourthCoffee.Employees.sln**, and then click **Open**.
    >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In **Solution Explorer**, expand **FourthCoffee.Employees**, and then double-click **Program.cs**.
5. Review the LINQ code in each of the methods.
6. On the **Build** menu, click **Build Solution**.
7. On the **Debug** menu, click **Start Without Debugging**.
8. In the console window, review the output of the **QueryingData** method, and then press Enter.
9. Repeat step 8 for each of the following methods:
   - **FilteringDataByRow**
   - **FilteringDataByColumn**
10. To close the application, press Enter.
11. In Visual Studio, on the **File** menu, click **Close Solution**.

### Demonstration: Querying Data by Using Anonymous Types

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\Allfiles\Mod07\Democode\Demo4\FourthCoffee.Employees** folder, click **FourthCoffee.Employees.sln**, and then click **Open**.
    >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In **Solution Explorer**, expand **FourthCoffee.Employees**, and then double-click **Program.cs**.
5. Review the LINQ code in each of the methods.
6. On the **Build** menu, click **Build Solution**.
7. On the **Debug** menu, click **Start Without Debugging**.
8. In the console window, review the output of the **UsingAnonymousTypes** method, and then press Enter.
9. Repeat step 8 for each of the following methods:
   - **GroupingData**
   - **AggregatingData**
   - **NavigatingData**
10. To close the application, press Enter.
11. In Visual Studio, on the **File** menu, click **Close Solution**.

### Demonstration: Retrieving and Modifying Grade Data Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize database:
    - In the **Apps list**, click **File Explorer**.
    - In **File Explorer**, navigate to the **[Repository Root]\Allfiles\Mod07\Labfiles\Databases** folder, and then double-click **SetupSchoolGradesDB.cmd**.
        >**Note:** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
    - Close **File Explorer**.

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\Allfiles\Mod07\Labfiles\Solution\Exercise 3** folder, click **GradesPrototype.sln**, and then click **Open**.
    >**Note :** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In **Server Explorer**, expand **Data Connection**, expend **{YourName}\sqlexpress.SchoolGradesDB.dbo** data connection and then expand **Tables**.
    >**Note :** If **SchoolGradesDB** wasn't appearing in Server Explorer, you can add it manually by clicking on **Add New Database** button.
5. Explain to students that they will be using this database for the labs from this point onwards and show them the data in the following tables:
    - **Students**
    - **Teachers**
    - **Grades**
    - **Subjects**
    - **Users**
6. Set the **GradesPrototype** project to be the startup project.
7. In the **Grades.DataModel** project, open **GradesModel.edmx**.
8. Explain to the students that during Exercise 1, they will generate this model from an existing database.
9. Briefly describe the entities and relationships that are shown in the diagram.
10. In the **GradesPrototype** project, in the **Views** folder, Expand **StudentProfile.xaml** then open **StudentProfile.xaml.cs**, and locate the **Refresh** method.
11. Explain to the students that during Exercise 2, they will add code to find all of the grades for the current student and display them in the **studentGrades ItemsControl** control.
12. Locate the **Convert** method in the **SubjectConverter** class.
13. Explain to the students that during Exercise 2, they will add this code to convert the subject ID that is stored in the grade assigned to a student in the database into a subject name.
14. Locate the **AddGrade_Click** method in the **StudentProfile.xaml.cs** class.
15. Explain to the students that they will also add code to ask the user for grade data and then save the information in the database and display it in the UI.
16. In the **Grades.DataModel** project, open **customTeacher.cs**.
17. Explain to the students that during Exercise 3, they will create this partial class and add validation code to the **EnrollInClass** method to check that there is space in the class before enrolling a student.
18. In the **Grades.DataModel** project, open **customGrade.cs**.
19. Explain to students that they will also create the grade partial class and add validation code to check the date and assessment grade that a user enters before storing it in the database.
20. Run the application, and then log on as **vallee** with the password **password99**.
21. Attempt to enroll a new student into the class, and then verify that an error message is displayed explaining that the class is already full.
22. Click **Kevin Liu**, and then add a new grade for him by using the following information:
    - Date: *tomorrow’s date*
    - Subject: **Math**
    - Assessment: **F+**
    - Comments: **Well done!**
23. Point out that an error message is displayed explaining that the assessment date must be on or before the current date.
24. Modify the new grade date by using the following information:
    - Date: **8/19/2012**
    - Subject: **Math**
    - Assessment: **F+**
    - Comments: **Well done!**
25. Point out that an error message is displayed explaining that the assessment grade must be in the range A+ to E-.
26. Modify the new grade date by using the following information:
    - Date: **8/19/2012**
    - Subject: **Math**
    - Assessment: **A+**
    - Comments: **Well done!**
27. Point out that the new grade is added to the list, and then close the application.
28. Close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
