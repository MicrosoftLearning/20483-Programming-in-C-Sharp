
# Module 7: Accessing a Database

## Lab: Retrieving and Modifying Grade Data

### Scenario

You have been asked to upgrade the prototype application to use an existing **Microsoft SQL Server** database. You begin by working with a database that is stored on your local machine and decide to use **Entity Data Model Wizard** to generate an Entity Data Model (EDM) to access the data. You will need to update the data access code for the **Grades** section of the application, to display grades that are assigned to a student and to enable users to assign new grades. You also decide to incorporate validation logic into the EDM to ensure that students cannot be assigned to a full class and that the data that users enter when they assign new grades conform to the required values.

#### Objectives

After completing this lab, you will be able to:

- Create an EDM from an existing database.
- Update data by using .**NET Entity Framework**.
- Extend an EDM to validate data.

### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Creating an Entity Data Model from The School of Fine Arts Database

#### Scenario

In this exercise, you will use the **Entity Data Model Wizard** to generate an EDM from the **SchoolGradesDB** SQL Server database and then review the model and the code that the wizard generates.

#### Task 1: Build and generate an EDM by using a table from the SchoolGradesDB database

1. Start **File Explorer**, navigate to the **[Repository Root]\\Allfiles\\Mod07\\Labfiles\\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close **File Explorer**.
3. Open **Visual Studio 2017**, and from the **[Repository Root]\\Allfiles\\Mod07\\Labfiles\\Starter\\Exercise 1** folder, open the **GradesPrototype.sln** solution.
4. Add a new class library project named **Grades.DataModel** to the solution.
5. Add a new **ADO.NET Entity Data Model** named **GradesModel** to the **Grades.DataModel** project.
6. Generate the model from the **SchoolGradesDB** database on the **(localdb)\MSSQLLocalDB** server and include the following tables:
   - **Grades**
   - **Students**
   - **Subjects**
   - **Teachers**
   - **Users**
7. If the **Security Warning** dialog box appears, click **Do not show this message again**, and then click **OK**.
8. Build the solution.

#### Task 2: Review the generated code

1. In the **Designer** window, review the entities that the wizard generated.
2. Review the properties and navigation properties of the **Grade** entity.
3. Review the mapping details for the **Grade** entity.
4. In the **GradesModel.Context.tt** folder, in the **GradesModel.Context**.cs file, review the code for the **SchoolGradesDBEntities DbContext** object.
5. In the **GradesModel.tt** folder, in the **Grade.cs** file, review the properties of the **Grade** entity.
6. Save all of the files, and then close the solution.

>**Result:** After completing this exercise, the prototype application should include an EDM that you can use to access **The School of Fine Arts** database.

### Exercise 2: Updating Student and Grade Data by Using the Entity Framework

#### Scenario

In this exercise, you will add functionality to the prototype application to display the grades for a user. The grade information in the database stores the subject ID for a grade. Therefore, you will add code to the application to convert this to the subject name for display purposes.  
You will also add code to display the **Add Grade** view to the user and then use the information that the user enters to add a grade for the current student.  
Finally, you will run the application and verify that the grade display and grade-adding functionality works as expected.

#### Task 1: Display grades for the current student

1. In **Visual Studio**, from the **[Repository Root]\Allfiles\Mod07\Labfiles\Starter\Exercise 2** folder, open the **GradesPrototype.sln** solution.
2. Set the **GradesPrototype** project to be the startup project.
3. In the **Views** folder, in **StudentProfile.xaml.cs**, in the **Refresh** method, add code to the end of the method to:
   - Iterate through the grades in the session context object, and if they belong to the current student, add them to a new list of grades.
   - Use data binding to display the list of grades in the **studentGrades ItemsControl** control by setting the **studentGrades.ItemsSource** property to the list of grades that you have just created.
4. Build the solution and resolve any compilation errors.
5. Run the application.
6. Log on as **vallee** with **password99** as the password.
7. Click **Kevin Liu**, and then verify that his grades appear in the list.
8. Note that the subject column uses the subject ID rather than the subject name, and then close the application.

#### Task 2: Display the subject name in the UI

1. In **Visual Studio**, in **StudentProfile.xaml.cs**, in the **SubjectConverter** class, in the **Convert** method, add code to the method to:
   - Convert the subject ID that is passed into the method into the subject name.
   - Return the subject name or, if there is no subject name matching the subject ID, the string **N/A**.

#### Task 3: Display the GradeDialog view and use the input to add a new grade

1. In **StudentProfile.xaml.cs**, in the **AddGrade_Click** method, add code to:
   - Create and display a new instance of the **GradeDialog** view.
   - If the user clicks **OK** in the **GradeDialog** view, retrieve the data they have entered and use it to create a new **Grade** object.
   - Save the grade and refresh the display so that the new grade appears.

#### Task 4: Run the application and test the grade-adding functionality

1. Build the solution, and then resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with **password99** as the password.
4. Click **Kevin Liu**, and verify that the list of grades now displays the subject name, not the subject ID.
5. Add a new grade for Kevin Liu using the following information:
   - Subject: **Geography**
   - Assessment: **A+**
   - Comments: **Well done!**
6. Verify that the new grade is added to the list, and then close the application.
7. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, users can see the grades for the current student and add new grades.

### Exercise 3: Extending the Entity Data Model to Validate Data

#### Scenario

In this exercise, you will update the application to validate data that the user enters.  
First, you will add code to check whether a class is full before enrolling a student and throw an exception if it is.  
Then you will add validation code to check that a user enters a valid date and assessment grade when adding a grade to a student.  
Finally, you will run the application and verify that the data validation works as expected.

#### Task 1: Throw the ClassFullException exception

1. In **Visual Studio**, open the **GradesPrototype.sln** solution from the **[Repository Root]\\Allfiles\\Mod07\\Labfiles\\Starter\\Exercise 3** folder.
2. Set the **GradesPrototype** project to be the startup project.
3. Add a new class named **customTeacher.cs** to the **Grades.DataModel** project.
4. Modify the class declaration to make it a public partial class named **Teacher**.
5. Add a private integer constant named **MAX_CLASS_SIZE** with a value of **8** to the **Teacher** class.
6. Add an **EnrollInClass** method that takes a **Student** object as a parameter and returns **void**.
7. In the **EnrollInClass** method, add code to:
   - Use a LINQ query to determine how many students are currently in the class.  
     You can execute a Count query of the students in a particular class by selecting only those students with a **TeacherUserId** property equal to the contents of the **UserId** variable.
   - If the class is full, throw a new **ClassFullException** exception.
   - If the student who is passed to the method is not already enrolled in a class, set the **TeacherID** property of the **Student** object to the **UserID** of the current teacher.
   - Otherwise, throw a new **ArgumentException** exception.
8. In the **Views** folder, in the **AssignStudentDialog.xaml.cs**, locate the **Student_Click** method.
9. Towards the end of the method, before the call to the **Refresh** method, add code to:
   - Call the **EnrollInClass** method to assign the student to this teacher’s class, passing the student as a parameter.
   - Save the updated student/class information back to the database.

#### Task 2: Add validation logic for the Assessment and AssessmentDate properties

1. Add a new class named **customGrade.cs** to the **Grades.DataModel** project.
2. Modify the class declaration to make it a public partial class named **Grade**.
3. Add a **ValidateAssessmentDate** method that takes a **DateTime** object as a parameter and returns a boolean.
4. In the **ValidateAssessmentDate** method, add code to:
   - Throw a new **ArgumentOutOfRangeException** exception, if the **DateTime** object passed to the method is later than the current date.
   - Otherwise, return **true**.
5. Bring the **System.Text.RegularExpressions** namespace into scope.
6. Add a **ValidateAssessmentGrade** method that takes a string as a parameter and returns a Boolean.
7. In the **ValidateAssessmentGrade** method, add code to:
   - Use the following regular expression to check that the string passed to the method is in the range of **A+** to **E-**.
        ```cs
        Match matchGrade = Regex.Match(assessment, @"^[A-E][+-]?$");
        ```
   - If the string passed is not in the valid range, throw a new **ArgumentOutOfRangeException** exception. Otherwise, return **true**.
8. In the **Controls** folder, in the **GradeDialog.xaml.cs** class, locate the **ok_Click** method.
9. In this method, add code to:
   - Create a new **Grade** object.
   - Call the **ValidateAssessmentDate** method, passing the selected date in the **assessmentDate** date picker control.
   - Call the **ValidateAssessmentGrade** method, passing the text in the **assessmentGrade** text box control.

#### Task 3: Run the application and test the validation logic

1. Build the solution, and then resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with **password99** as the password.
4. Attempt to enroll a new student into the class, and then verify that an error message is displayed explaining that the class is already full.
5. Click **Kevin Liu**, and then add a new grade for him by using the following information:
   - Date: **tomorrow’s date**
   - Subject: **Math**
   - Assessment: **F+**
   - Comments: **Well done!**
6. Verify that an error message is displayed explaining that the assessment date must be on or before the current date.
7. Modify the new grade date by using the following information:
   - Date: **8/19/2012**
   - Subject: **Math**
   - Assessment: **F+**
   - Comments: **Well done!**
8. Verify that an error message is displayed explaining that the assessment grade must be in the range **A+** to **E-**.
9. Modify the new grade date by using the following information:
   - Date: **8/19/2012**
   - Subject: **Math**
   - Assessment: **A+**
   - Comments: **Well done!**
10. Verify that the new grade is added to the list, and then close the application.
11. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the application will raise and handle exceptions when invalid data is entered.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
