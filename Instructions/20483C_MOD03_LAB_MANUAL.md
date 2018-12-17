# Module 3: Developing the Code for a Graphical Application

## Lab: Writing the Code for the Grades Prototype Application

### Scenario

The School of Fine Arts has decided that they want to extend their basic class enrollment application to enable teachers to record the grades that students in their class have achieved for each subject, and to allow students to view their own grades.

This functionality necessitates implementing a log on functionality to authenticate the user and to determine whether the user is a teacher or a student.  
You decide to start by developing parts of a prototype application to test proof of concept and to obtain client feedback before developing the final application.  
The prototype application will use basic WPF views rather than separate forms for the user interface. These views have already been designed and you must add the code to navigate through them.  
You also decide to begin by storing the user and grade information in basic structs, and to use a dummy data source in the application to test the log on functionality.

### Objectives

After completing this lab, you will be able to:

- Navigate among views.
- Create and use collections of structs.
- Handle events.

### Lab Setup

Estimated Time: **90 minutes**

### Exercise 1: Adding Navigation Logic to the Grades Prototype Application

#### Scenario

In this exercise, you will add navigation logic to the **Grades Prototype** application.

First, you will examine the window and views in the application so that you are familiar with the existing structure of the application.  
You will define a public event handler named **LogonSuccess** that will be raised when a user successfully logs on to the application.  
You will add dummy code to the **Logon_Click** event handler to store the username and role of the current user and calls the **LogonSuccess** event.  
Then you will add markup to the **LogonPage** XAML code to connect the **Logon** button to the **Logon_Click** event handler.  
Next, you will add code to the **GotoLogon** method to display the log on view and to hide the other views.  
You will implement the **Logon_Success** method to handle a successful log on by displaying the logged-on views, and then you will add markup to the **MainWindow** XAML code to connect the **LogonSuccess** event to the **Logon_Success** method.  
You will add code to **MainWindow** to determine whether the user is a teacher or a student, display their name in the application, and display either the **StudentsPage** view for teachers or the **StudentProfile** view for students.  
You will then add code to the **StudentsPage** view that catches a student name being clicked, calls the **StudentSelected** event for that student, and displays their student profile.  
Finally, you will run the application and verify that the appropriate views are displayed for students and teachers upon a successful log on.

#### Task 1: Examine the window and views in the application

1. Start **Microsoft Visual Studio** and open the **GradesPrototype.sln** solution from the **[Repository Root]\\Allfiles\\Mod03\\Labfiles\\Starter\\Exercise 1** folder.
2. Build the solution.
3. Review **MainWindow.xaml**, which is the main window for the application and will host the following views:
   - LogonPage.xaml
   - StudentProfile.xaml
   - StudentsPage.xaml
4. In the **Views** folder, review **LogonPage.xaml**. Notice that this view contains text boxes for the username and password, a check box to identify the user as a teacher, and a button to log on to the application.
5. In the **Views** folder, review **StudentProfile.xaml**. Notice that this view contains a report card that currently displays a list of dummy grades. The view also contains a back button and a blank space that will display the student’s name. This view is displayed when a student logs on or when a teacher views a student’s profile.
5. In the **Views** folder, review **StudentsPage.xaml**. Notice that this view contains the list of students in a particular class. This view is displayed when a teacher logs on. A teacher can click a student and the **Students Profile** view that contains the selected students' data will be displayed.

#### Task 2: Define the LogonSuccess event and add dummy code for the Logon_Click event

1. In the **LogonPage.xaml.cs** class, in the **Event Members** region, define a public event handler named **LogonSuccess**.
2. In the **Logon Validation** region, add an event handler for the **Logon_Click** event, which takes an **object** parameter named **sender** and a **RoutedEventArgs** parameter named **e**.
3. In the **Logon_Click** event handler, add code to do the following:
   - Save the username and role that the user specified on the form in the relevant properties of the **SessionContext** object.
   - If the user is a student, set the **CurrentStudent** property of the **SessionContext** object to the string **Eric Gruber**.
   - Raise the **LogonSuccess** event.
4. In the **LogonPage.xaml** XAML editor, locate the definition of the **Log on** button.
5. Modify the definition to call the **Logon_Click** method when the button is clicked.

#### Task 3: Add code to display the Log On view

1. In the **MainWindow.xaml.cs** code, locate the **GotoLogon** method, and then add code to display the **logonPage** view and hide **studentsPage** and **studentProfile** views.
2. In the **Event Handlers** region, add code to the **Logon_Success** method to handle a successful log on. This method should take an **object** parameter named **sender** and an **EventArgs** parameter named **e**. The method should update the display and show the data for the current user.
3. In the **MainWindow.xaml** **XAML** editor, locate the definition of the **LogonPage** page.
4. Modify the definition to call the **Logon_Success** method for the **LogonSuccess** event.

#### Task 4: Add code to determine the type of user

1. In the **MainWindow.xaml.cs** file, in the **Refresh** method, add code to determine the type of user, display **Welcome \<username\>** in the **txtName** text box, and then call either the **GotoStudentProfile** method (for students) or the **GotoStudentsPage** method (for teachers) to display the appropriate view.
2. In the **GotoStudentProfile** method, add code to hide the **studentsPage** view, and then add code to display and refresh the **studentProfile** view.
3. In the **GotoStudentsPage** method, add code to hide the **studentProfile** view, and then add code to display and refresh the **studentsPage** view.
4. In the **StudentProfile.xaml.cs** file, in the **Refresh** method, add code to:
   - Parse the student name into the first name and last name by using a regular expression as shown in the following example.
        ```cs
        Match matchNames = Regex.Match(SessionContext.CurrentStudent, @"([^ ]+) ([^ ]+)");
        ```
   - If a name is successfully parsed, display the first name and last name of the student in the appropriate boxes.
   - If the user is a student, hide the **btnBack** button, or if the user is a teacher, display the **btnBack** button.

#### Task 5: Handle the Student_Click event

1. In the **StudentsPage.xaml.cs** file, in the **StudentsPage** class, locate the **Student_Click** method.
2. Add code to this method to identify which student was clicked by using the**Tag** property of the button, and then raise the **StudentSelected** event, passing the student name as the second parameter.
3. In the **MainWindow.xaml.cs** file, in the **studentsPage_StudentSelected** method, add code to set the **CurrentStudent** property of the **SessionContext** object to the student who was clicked by using the **Child** property of the **e** argument.
4. Call the **GotoStudentProfile** method.
5. In the **MainWindow.xaml** **XAML** editor, locate the definition of the **StudentsPage** page.
6. Modify the definition to call the **studentsPage_StudentSelected** method for the **StudentSelected** event.

#### Task 6: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as the teacher, **vallee**, with the password **password**.
4. Verify that the application displays the **StudentPage** view.
    ![alt text](./Images/20483C_03_StudentsPage.png "The Students page")
5. Click **Kevin Liu** and verify that the application displays the **StudentProfile** view.
    ![alt text](./Images/20483C_03_StudentProfileKevinLiu.png "The Student Profile page")
6.Log off the application.
7. Log on as the student, **Gruber**, with password as the **password**.
8. Verify that the application displays the student profile page for Eric Gruber.
9. Close the application and then close the solution.

>**Result:** After completing this exercise, you should have updated the **Grades Prototype** application to respond to user events and move among the application views appropriately.

### Exercise 2: Creating Data Types to Store User and Grade Information

#### Scenario

In this exercise, you will define basic structs that will hold the teacher, student, and grade information for the application. You will then examine the dummy data source that the application uses to populate the collections in this exercise.

#### Task 1: Define basic structs for holding Grade, Student, and Teacher information

1. Open the **GradesPrototype** solution from the **[Repository Root]\Allfiles\Mod03\Labfiles\Starter\Exercise 2** folder.
2. In the **Data** folder, open **Grade.cs**.
3. In the **GradesPrototype.Data** namespace, create a **struct** named **Grade** that contains the following fields:
   - **StudentID** as an integer
   - **AssessmentDate** as a string
   - **SubjectName** as a string
   - **Assessment** as a string
   - **Comments** as a string
4. In the **GradesPrototype.Data** namespace, create a **struct** named **Student** that contains the following fields:
   - **StudentID** as an integer
   - **UserName** as a string
   - **Password** as a string
   - **TeacherID** as an integer
   - **FirstName** as a string
   - **LastName** as a string
5. In the **GradesPrototype.Data** namespace, create a **struct** named **Teacher** that contains the following fields:
   - **TeacherID** as an integer
   - **UserName** as a string
   - **Password** as a string
   - **FirstName** as a string
   - **LastName** as a string
   - **Class** as a string

#### Task 2: Examine the dummy data source used to populate the collections

1. In the **Data** folder, in the **DataSource.cs** file, expand the **Sample Data** region.
2. Note how the **Teachers ArrayList** is populated with the **Teacher** data, each containing **TeacherID**, **UserName**, **Password**, **FirstName**, **LastName**, and **Class** fields.
3. Note how the **Students ArrayList** is populated with the **Student** data, each containing a **StudentID**, **UserName**, **Password**, **TeacherID**, **FirstName**, and **LastName** fields.
4. Note how the **Grades ArrayList** is populated with the **Grade** data, each containing a **StudentID**, **AssessmentDate**, **SubjectName**, **Assessment**, and **Comments** fields.

>**Result:** After completing this exercise, the application will contain structs for the teacher, student, and grade types.

### Exercise 3: Displaying User and Grade Information

#### Scenario

In this exercise, you will first define a public event handler named **LogonFailed** that will be raised when a user fails to log on successfully.  
You will add code to the **Logon_Click** event handler to validate the username and password entered by the user against the Users collection in the **MainWindow** window.  
If the user is a teacher or a student, you will store their details in the global context and then raise the **LogonSuccess** event, but if the user is not validated, you will raise the **LogonFailed** event.  
You will handle logon failure in the **Logon_Failed** method to display a message to the user and then you will add markup to the **MainWindow** XAML code to connect the **LogonFailed** event to the **Logon_Failed** method.  
You will add code to the **StudentsPage** view to display students for the current teacher, and to display the details for a student when the user clicks their name.  
You will then use data binding to display the details and grades for the current student in the **StudentProfile** view, and to display only the **Back** button if the user is a teacher.  
Finally, you will run the application and verify that only valid users can log on and that valid users can see only data appropriate to their role.

#### Task 1: Add the LogonFailed event

1. Open the **GradesPrototype** solution from the **[Repository Root]\Allfiles\Mod03\Labfiles\Starter\Exercise 3** folder.
2. In the **LogonPage.xaml.cs** file, in the **Event Members** region, define an event handler named **LogonFailed**.
3. In the **Logon_Click** event, add code to do the following:
    - Determine whether the user is a teacher by using a LINQ query to retrieve teachers with the same username and password as the current user. If the LINQ query returns a result, then the user is a teacher.
    - If the user is a teacher, set the **UserID**, **UserRole**, **UserName**, and **CurrentTeacher** properties of the **SessionContext** object to the appropriate fields from the data source, and then raise the **LogonSuccess** event.
    - If the user is not a teacher, determine whether the user is a student by using a LINQ query to retrieve students with the same username and password as the current user.
    - If the user is a student, set the **UserID**, **UserRole**, **UserName**, and **CurrentStudent** properties of the **SessionContext** object to the appropriate fields from the data source, and then raise the **LogonSuccess** event.
    - If the credentials do not match any teachers or students, raise the **LogonFailed** event.

#### Task 2: Add the Logon_Failed event handler

1. In the **MainWindow.xaml.cs** class, in the **Event Handlers** region, add an event handler for the **Logon_Failed** event that takes an **object** parameter named **sender** and an **EventArgs** parameter named **e**.
2. In the **Logon_Failed** event handler, add code to display an error message to the user.
3. In the **MainWindow.xaml** **XAML** editor, locate the definition of the **LogonPage** page.
4. Modify the definition to call the **Logon_Failed** method for the **LogonFailed** event.
5. In the **MainWindow.xaml.cs** code, locate the **Refresh** method.
6. In the **case** statement for a student, add code to display the student
    name in **txtName** text box at the top of the page.
7. In the **case** statement for a teacher, add code to display the teacher name in the banner at the top of the page.

#### Task 3: Display the students for the current teacher

1. In **StudentsPage.xaml** **XAML** editor, locate the **ItemsControl** named **list** and note how data binding is used to display the name of each student.
   >**Note:** DataBinding is also used to retrieve the **StudentID** of a student. This binding is used when a user clicks a student on the **Student Page** list to identify which student’s data to display in the **Student Profile** page.
2. In the **StudentsPage.xaml.cs** code, locate the **Refresh** method, and then add code to do the following:
   - Find all the students for the current teacher and store them in a new **ArrayList** object.
   - Bind the collection to the **ItemsSource** property of the **list** control.
   - Display the class name.
   - Locate the **Student_Click** event and then add code to do the following:
     - Identify which student was clicked by using the **Tag** property of the button.
     - Find the details of that student by examining the **DataContext** of the button.
     - Raise the **StudentSelected** event, passing the student as the second parameter.
3. In the **StudentsPage_StudentSelected** event handler, add code to set the **CurrentStudent** property of the **SessionContext** object to the student passed to the event by using the **Child** property of the **e** argument.

#### Task 4: Set the DataContext for the page

1. In the **StudentProfile.xaml.cs** file, in the **Refresh** method, add code to display the details of the current student in the **studentName StackPanel** object and to display the **Back** button only if the user is a teacher.
2. In the **StudentProfile.xaml** **XAML** editor, locate the definition of the **firstName** text block.
3. Modify the definition to bind the **Text** property to the **FirstName** field.
4. Locate the definition of the **lastName** text block.
5. Modify the definition to bind the **Text** property to the **LastName** field.
6. In the **StudentProfile.xaml.cs** file, at the end of the **Refresh** method, add code to iterate the grades for the current student in the **DataSource.Grades** list and then display them in the **studentGrades** control by using data binding.

#### Task 5: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **parkerd** with **password** as the password and verify that the **Logon Failed** message box appears.
4. Log on as **vallee** with **password** as the password and verify that the **Students** page appears.
5. Click **Kevin Liu**, verify that the **Student Profile** page appears, and then log off.
6. Log on as **grubere** with **password** as the password and verify that the **Student Profile** page appears.
7. Close the application and then close the solution.

>**Result:** After completing this exercise, only valid users will be able to log on to the application and they will see only data appropriate to their role.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
