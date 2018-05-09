
# Module 7: Accessing a Database

# Lesson 1:  Creating and Using Entity Data Models

### Demonstration: Creating an Entity Data Model

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

1.  Log on to Windows® 10 as **Student** with the password **Pa\$\$w0rd**. If
    necessary, click **Switch User** to display the list of users.
2.  Switch to the Windows 10 **Start** window and then type Explorer.
3.  In the **Apps** list, click **File Explorer**.
4.  Navigate to the **E:\\Mod07\\Democode\\Databases** folder, and then
    double-click **SetupFourthCoffeeDB.cmd**.
5.  Close File Explorer.
6.  Switch to the Windows 8 **Start** window.
7.  Click **Visual Studio 2012**.
8. In Visual Studio, on the **File** menu, point to **Open**, and then click
    **File**.
9. In the **Open File** dialog box, browse to the
    **E:\\Mod07\\Democode\\Databases** folder, click **FourthCoffee.sql**, and
    then click **Open**.
10. On the **SQL** menu, point to **Transact-SQL Editor**, and then click
    **Execute**.
11. In the **Connect to Server** dialog box, in the **Server name** box, type
    **(localdb)\\v11.0**, and then click **Connect**.
    >**Note :** If the query times out, in the **Connect to Server** dialog box, click **OK**,
and then in the **Connect to Server** dialog box, click **Connect**.
12.  When the query has completed, on the **File** menu, click **Close**.
13.  On the **File** menu, point to **New**, and then click **Project**.
14.  In the **New Project** dialog box, expand **Templates**, click **Visual
    C\#**, and then in the **Template** list, click **Console Application**.
15.  In the **Name** box, type **FourthCoffee.Employees**, in the **Location**
    box, type **E:\\Mod07\\Democode\\Demo1\\Starter**, and then click **OK**.
16.  In Solution Explorer, right-click **FourthCoffee.Employees**, point to
    **Add**, and then click **New Item**.
17.  In the **Add New Item – FourthCoffee.Employees** dialog box, click **ADO.NET
    Entity Data Model**, in the **Name** box, type
    **FourthCoffeeEmployeesModel**, and then click **Add**.
18.  In the Entity Data Model Wizard, on the **Choose Model Contents** page,
    click **Generate from database**, and then click **Next**.
19.  On the **Choose Your Data Connection** page, click **New Connection**.
20.  In the **Choose Data Source** dialog box, in the **Data source** list, click
    **Microsoft SQL Server**, and then click **Continue**.
21.  In the **Connection Properties** dialog box, in the **Server name** box,
    type **(localdb)\\v11.0**, in the **Select or enter a database name** list,
    click **FourthCoffee**, and then click **OK**.
22.  In the Entity Data Model Wizard, on the **Choose Your Data Connection**
    page, click **Next**.
23.  On the **Choose Your Database Objects and Settings** page, expand
    **Tables**, expand **dbo**, select **Branches**, **Employees**, and
    **JobTitles**, and then click **Finish**.
24.  In the **Security Warning** dialog box, select **Do not show this message
    again**, and then click **OK**.
25. On the **Build** menu, click **Build Solution**.
26. Review the three entities that have been generated and the associations
    between them.
27. Right-click the designer surface, and then click **Mapping Details**.
28. In the Designer pane, click **Employee**.
29. In the Mapping Details pane, review the mappings between the entity and the
    data source.
30. In Solution Explorer, expand **FourthCoffeeEmployeesModel.edmx**, expand
    **FourthCoffeeEmployeesModel.Context.tt**, and then double-click
    **FourthCoffeeEmployeesModel.Context.cs**.
31. In the code editor, review the code in the **FourthCoffeeEntities** partial
    class.
32. In Solution Explorer, expand **FourthCoffeeEmployeesModel.tt**, and then
    double-click **Employee.cs**.
33. Review the **Employee** partial class and the properties that have been
    generated.
34.	Leave the solution open so that you can refer to it in the following topics. 



### Demonstration: Reading and Modifying Data in an EDM

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod07\Democode\Demo2\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.

#### Demonstration Steps

1.	Open **Visual Studio 2017**.
2.	In Visual Studio, on the File menu, point to Open, and then click Project/Solution.
1.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
2.  Review the definition of the **DBContext** variable.
3.  Review the code in the **PrintEmployeesList** method that uses the
    **DBContext** variable to access the data in the EDM.
4.  Review the code in the **Main** method that uses the **First** extension
    method to retrieve an employee and then modifies that employee’s
    **LastName** property.
5.  On the **Debug** menu, click **Start Without Debugging**.
6.  Verify that the employees list is displayed, and then press Enter.
7. Verify that the employee named “Diane Prescott” is now named “Diane
    Forsyth,” and then press Enter.
8. Press Enter to close the application.


# Lesson 2:  Querying Data by Using LINQ

### Demonstration: Querying Data

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod07\Democode\Demo1\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.

#### Demonstration Steps

1.  Log on to Windows 10 as **Student** with the password **Pa\$\$w0rd**. If
    necessary, click **Switch User** to display this list of users.
2.  Switch to the Windows 10 **Start** window.
3.  Click **Visual Studio 2017**.
4.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
5.  In the **Open Project** dialog box, browse to the
    **E:\\Mod07\\Democode\\Demo3\\FourthCoffee.Employees** folder, click
    **FourthCoffee.Employees.sln**, and then click **Open**.
6.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
7.  Review the LINQ code in each of the methods.
8.  On the **Build** menu, click **Build Solution**.
9.  On the **Debug** menu, click **Start Without Debugging**.
10. In the console window, review the output of the **QueryingData** method, and
    then press Enter.
11. Repeat step 12 for each of the following methods:
    -  **FilteringDataByRow**
    -  **FilteringDataByColumn**
12. Press Enter to close the application.
13. In Visual Studio, on the **File** menu, click **Close Solution**.


### Demonstration: Querying Data by Using Anonymous Types

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod07\Democode\Demo2\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.

#### Demonstration Steps

1.  Log on to Windows 10 as **Student** with the password **Pa\$\$w0rd**. If
    necessary, click **Switch User** to display the list of users.
2.  Switch to the Windows 10 **Start** window.
3.  Click **Visual Studio 2017**.
4.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
5.  In the **Open Project** dialog box, browse to the
    **E:\\Mod07\\Democode\\Demo4\\FourthCoffee.Employees** folder, click
    **FourthCoffee.Employees.sln**, and then click **Open**.
6.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
7.  Review the LINQ code in each of the methods.
8.  On the **Build** menu, click **Build Solution**.
9.  On the **Debug** menu, click **Start Without Debugging**.
10. In the console window, review the output of the **UsingAnonymousTypes**
    method, and then press Enter.
11. Repeat step 12 for each of the following methods:
    -  **GroupingData**
    -  **AggregatingData**
    -  **NavigatingData**
12. Press Enter to close the application.
13. In Visual Studio, on the **File** menu, click **Close Solution**.



### Demonstration: Retrieving and Modifying Grade Data Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Open the GradesPrototype.sln solution from the
    E:\\Mod07\\Labfiles\\Solution\\Exercise 3 folder.
2.  In Server Explorer, expand the **sea-dev11** data connection and then expand
    **Tables**.
3.  Explain to students that they will be using this database for the labs from
    this point onwards and show them the data in the following tables:
    - Students
    - Teachers
    - Grades
    - Subjects
    - Users
4.  Set the GradesPrototype project to be the startup project.
5.  In the Grades.DataModel folder, open GradesModel.edmx.
6.  Explain to students that during Exercise 1, they will generate this model
    from an existing database.
7.  Briefly describe the entities and relationships that are shown in the
    diagram.
8.  In the GradesPrototype project, in the Views folder, open
    StudentProfile.xaml.cs, and then locate the **Refresh** method.
9.  Explain to students that during Exercise 2, they will add code to find all
    of the grades for the current student and display them in the
    **studentGrades ItemsControl** control.
10.  Locate the **Convert** method in the **SubjectConverter** class.
11.  Explain to students that during Exercise 2, they will add this code to
    convert the subject ID that is stored in the grade assigned to a student in
    the database into a subject name.
12.  Locate the **AddGrade_Click** method in the **StudentProfile** class.
13. Explain to students that they will also add code to ask the user for grade
    data and then save the information in the database and display it in the UI.
14. In the Grades.DataModel project, open **customTeacher.cs**.
15. Explain to students that during Exercise 3, they will create this partial
    class and add validation code to the **EnrollInClass** method to check that
    there is space in the class before enrolling a student.
16. In the Grades.DataModel project, open **customGrade.cs**.
17. Explain to students that they will also create the grade partial class and
    add validation code to check the date and assessment grade that a user
    enters before storing it in the database.
18. Run the application, and then log on as **vallee** with a password of
    **password99**.
19. Attempt to enroll a new student into the class, and then verify that an
    error message is displayed explaining that the class is already full.
20. Click **Kevin Liu**, and then add a new grade for him by using the following
    information:
    - Date: **tomorrow’s date**
    - Subject: **Math**
    - Assessment: **F+**
    - Comments: **Well done!**
21.  Point out that an error message is displayed explaining that the assessment
    date must be on or before the current date.
22.  Modify the new grade date by using the following information:
     - Date: **8/19/2012**
     - Subject: **Math**
     - Assessment: **F+**
     - Comments: **Well done!**
23.  Point out that an error message is displayed explaining that the assessment
    grade must be in the range A+ to E-.
24.  Modify the new grade date by using the following information:
     - Date: **8/19/2012**
     - Subject: **Math**
     - Assessment: **A+**
     - Comments: **Well done!**
25.  Point out that the new grade is added to the list, and then close the
    application.
26.  Close Visual Studio.


©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
