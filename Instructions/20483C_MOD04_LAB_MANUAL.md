# Module 4: Creating Classes and Implementing Type-Safe Collections

## Lab: Adding Data Validation and Type-Safety to the Application

### Scenario

Now that the user interface navigation features are working, you decide to replace the simple structs with classes to make your application more efficient and straightforward.
You have also been asked to include validation logic in the application to ensure that when a user adds grades to a student, that the data is valid before it is written to the database. You decide to create a unit test project that will perform tests against the required validation for different grade scenarios.
Teachers who have seen the application have expressed a concern that the students in their classes are displayed in a random order. You decide to use the **IComparable** interface to enable them to be displayed in alphabetical order.
Finally, you have been asked to add functionality to the application to enable teachers to add students to and remove students from a class, and to add student grades to the database.

#### Objectives

After completing this lab, you will be able to:

- Create classes.
- Write data validation code and unit tests.
- Implement the **IComparable** interface.
- Use generic collections.

#### Lab Setup

Estimated Time: **75 minutes**

### Exercise 1: Implementing the Teacher, Student, and Grade Structs as Classes

#### Scenario

In this exercise, you will convert the existing **Teacher**, **Student**, and **Grade** structs into classes.
This will enable you to implement the additional functionality required for each class, such as adding constructors, properties, and methods.  
In the **Teacher** and **Student** classes, add a write-only property for the password, add the **VerifyPassword** method, and then define their respective constructors.  
You will also modify the **Logon_Click** method to use the **VerifyPassword** method to verify passwords when a user logs on.  
Finally, you will run the application and verify that it still functions correctly, allowing a student or a teacher to log on.

#### Task 1: Convert the Grades struct into a class

1. Start **Microsoft Visual Studio** and open the **GradesPrototype.sln** solution from the **[Repository Root]\AllFiles\Mod04\Labfiles\Starter\Exercise 1** folder.
2. In the **Data** folder, in **Grade.cs**, convert the **Grade** struct into a class.
3. Define a class constructor that takes the following parameters and uses them to populate the public properties of the class:
   - **studentID**
   - **assessmentDate**
   - **subject**
   - **assessment**
   - **comments**
4. Define a default class constructor that takes no parameters and assigns the following default values to the public properties:
   - **Student ID: 0**
   - **AssessmentDate: the current date**
   - **SubjectName: Math**
   - **Assessment: A**
   - **Comments: an empty string**

#### Task 2: Convert the Students and Teachers structs into classes

1. Convert the **Students** struct into a class.
2. Create a write-only password property that generates a new GUID for the default value.
3. Create a **VerifyPassword** method that uses the **String.Compare** method to check that the password passed to it as a parameter matches the stored password.
   >**Note:** An application should not be able to read passwords; only set them and verify that a password is correct.
4. Define a class constructor that takes the following parameters and uses them to populate the public properties of the class:
   - **studentID**
   - **userName**
   - **password**
   - **firstName**
   - **lastName**
   - **teacherID**
5. Define a default class constructor that takes no parameters and assigns the following default values to the public properties:
   - **Student ID: 0**
   - **UserName: an empty string**
   - **Password: an empty string**
   - **FirstName: an empty string**
   - **LastName: an empty string**
   - **TeacherID: 0**
6. Convert the **Teachers** struct into a class.
7. Create a write-only password property that generates a new GUID for a default value and a **VerifyPassword** method that uses the **String.Compare** method to check that the password passed to it as a parameter matches the stored password.
8. Define a class constructor that takes the following parameters and uses them to populate the public properties of the class:
   - **teacherID**
   - **userName**
   - **password**
   - **firstName**
   - **lastName**
   - **className**
9. Define a default class constructor that takes no parameters and assigns the following default values to the public properties:
   - **TeacherID: 0**
   - **UserName: an empty string**
   - **Password: an empty string**
   - **FirstName: an empty string**
   - **LastName: an empty string**
   - **Class: an empty string**

#### Task 3: Use the VerifyPassword method to verify the password when a user logs in

1. In the **Views** folder, in the **LogonPage.xaml.cs** code, modify the code in the **Logon_Click** method to call the **VerifyPassword** method to verify the teacher’s password.
2. Modify the code to check whether **teacher** is null before examining the **UserName** property.
3. In the **Student** class, modify the code in the **Logon_Click** method to use the **VerifyPassword** method to verify the student’s password.
4. Modify the code to check whether **student** is null before examining the **UserName** property.

#### Task 4: Build and run the application, and verify that a teacher or student can still log on

1. Build the solution and resolve any compilation errors.
2. Log on as **vallee** with **password** as the password.
3. Verify that you can log on as a teacher.
4. Log off from the application.
5. Log on as **grubere** with **password** as the password.
6. Verify that you can log on as a student.
7. Close the application.
8. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the **Teacher**, **Student**, and **Grade** structs will be implemented as classes and the **VerifyPassword** method will be called when a user logs on.

### Exercise 2: Adding Data Validation to the Grade Class

#### Scenario

In this exercise, you will define a public list of strings called **Subjects** to hold the names of each subject that can be assessed and then populate it with valid subject names.  
You will then add validation logic to the **Grade** class to ensure that the subject name appears on the list you created and that the assessment date and assessment grade contain allowed values.  
Finally, you will create a unit test project to verify that your validation code functions as expected.

#### Task 1: Create a list of valid subject names

1. In **Visual Studio**, from the **[Repository Root]\AllFiles\Mod04\Labfiles\Starter\Exercise 2** folder, open the **GradesPrototype.sln** solution.
2. In the **Data** folder, in the **DataSource** class, define a generic **List** collection to hold the names of valid subjects.
3. In the **CreateData** method in that class, populate the list with the following subject names:
   - **Math**
   - **English**
   - **History**
   - **Geography**
   - **Science**

#### **Task 2: Add validation logic to the** Grade class to check the data entered by the user

1. In the **Data** folder, in the **Grade.cs** code, add validation code to the **AssessmentDate** property to ensure that the following requirements have been met:
   - Verify that the user has provided a valid date.
   - Check that the date is no later than the current date. If it is, throw an **ArgumentOutOfRangeException** exception.
   - If the date is valid, then save it in the appropriate format.
   - If the date is not in a valid format, throw an **ArgumentException** exception.
2. Add validation code to the **Subject** property to ensure that the following requirements are met:
   - Check that the specified subject is on the list that you have defined.
   - If the subject is valid, store the subject name.
   - If the subject is not valid, then throw an **ArgumentException** exception.
3. Add validation to the Assessment property to ensure that the following requirements are met:
   - Verify that the grade is in the range A+ to E- by using the following regular expression.
      ```cs
      Match matchGrade = Regex.Match(value, @"[A-E][+-]?$");
      ```
   - If the grade is not valid, then throw an **ArgumentOutOfRangeException** exception.

#### Task 3: Add a unit test to verify that the validations defined for the Grade class functions as expected

1. Add a **Unit Test Project** called **GradesTest** to the solution and reference the **GradesPrototype** project from it.
2. In the **UnitTest1** class, define the following tests and support methods:
   - **Init**: to call the **CreateData** method to initialize the **DataSource**.
   - **TestValidGrade**: to check that valid data passes the validation logic successfully. If the grade is not valid, then throw an **ArgumentOutOfRangeException** exception.
   - **TestBadDate**: to check that dates in the future are not valid.
   - **TestDateNotRecognized**: to check that non-dates are not valid.
   - **TestBadAssessment**: to check that assessment values outside the permitted range are not valid.
   - **TestBadSubject**: to check that subject names not on the list are not valid.
3. Build the solution and resolve any compilation errors.
4. Run all tests and verify that they all pass.
5. Close **Test Explorer** and then close the solution.
    ```cs
    Match matchGrade = Regex.Match(value, @"[A-E][+-]?$");
    ```

**Result:** After completing this exercise, the **Grade** class will contain validation logic.

### Exercise 3: Displaying Students in Name Order

#### Scenario

In this exercise, you will write code to display the students in alphabetical order of the last name and then the first name.

The application currently displays students in no specific order when logged on as a teacher, but you now want them to be displayed in alphabetical order of the last name and then the first name.  
To achieve this, you decide that the **Student** class should implement the **IComparable\<\>** interface to enable comparison of student data.  
You can then add code to the **CompareTo** method in the **Student** class, enabling students to be sorted based on their last name and first name.  
Currently, students are stored in a non-type-safe **ArrayList** collection. You decide to modify this so they are stored in a type-safe **List** collection.  
Finally, you will sort the student data and then run the application to verify that the students are retrieved and displayed in alphabetical order of their last name and first name.

#### Task 1: Run the application and verify that the students are not displayed in any specific order when logged on as a teacher

1. In **Visual Studio**, from the **[Repository Root]\AllFiles\Mod04\Labfiles\Starter\Exercise 3** folder, open the **GradesPrototype.sln** solution.
2. Build the solution and resolve any compilation errors.
3. Log in as **vallee** with **password** as the password. Verify that the students are not displayed in any specific order.
4. Close the application.

#### Task 2: Implement the IComparable\<Student\> interface to enable comparison of students

1. In the **Grade.cs** code window, locate the **Student** class definition, and modify it to implement the **IComparable\<Student\>** interface.

#### Task 3: Change the Students ArrayList collection into a List\<Student\> collection

1. In the **Data** folder, in the **DataSource.cs** code, in the **DataSource** class, modify the **Students ArrayList** collection to create a generic **List** collection.
2. In the **CreateData** method, modify the creation of the **Students** collection to create a new generic **List** collection.

#### Task 4: Sort the data in the Students collection

In **MainWindow.xaml.cs**, in the **MainWindow** constructor, after calling the **DataSource.CreateData** method, add a method call to sort the data in the **Students** collection.

#### Task 5: Verify that Students are retrieved and displayed in the order of their first name and last name

1. Build the solution and resolve any compilation errors.
2. Run the application without debugging.
3. Log in as **vallee** with **password** as the password.
4. Verify that the students are displayed in order of ascending last name.
5. Close the application.
6. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the application will display the students in alphabetical order of the last name and then the first name.

### Exercise 4: Enabling Teachers to Modify Class and Grade Data

#### Scenario

In this exercise, you will write code that enables a teacher to add a student and then enroll them in a class.  
This will be implemented as two separate steps, because a teacher may want to add a student before knowing which class they will be enrolled in.  
You will also enable a teacher to remove a student from a class. When adding or removing a student, you will display a prompt to confirm that the teacher wants to perform the action.

To enroll a student in a class or remove them from a class, you modify the **TeacherID** property of that student.  
The application now includes the **AssignStudentDialog** window, which displays a list of students who are not assigned to a class.  
You need to add code to this window to assign a student to the teacher’s class and to update the list of students as appropriate.  
You also need to add code to remove a student from a class and to enable teachers to add grades to their students.  
After a student has been added to the database, that student will be able to log on to view their grades.

#### Task 1: Change the Teachers and Grades collections to be generic List collections

1. In **Visual Studio**, from the **[Repository Root]\AllFiles\Mod04\Labfiles\Starter\Exercise 4** folder, open the **GradesPrototype.sln** solution.

2. In the **Data** folder, in the **DataSource.cs** code, change the **Teachers** collection to be a generic **List** collection.
3. Change the **Grades** collection to be a generic **List** collection.
4. In the **CreateData** method, modify the creation of the **Teachers** collection to create a new generic **List** collection.
5. In the **CreateData** method, modify the creation of the **Grades** collection to create a new generic **List** collection.

#### Task 2: Add the EnrollInClass and RemoveFromClass methods for the Teacher class

1. In the **Data** folder, in the **Grade.cs** code, in the **Teacher** class, implement the **EnrollInClass** method as follows:
   - Verify that the student is not already enrolled in another class.
   - If the student is not in another class, set the **TeacherID** property of the student to the current **TeacherID**.
   - If the student is in another class, throw an **ArgumentException** exception to show that the student is already assigned to a class.
2. In the **Teacher** class, add code to the **RemoveFromClass** method as follows:
   - Verify that the **Student** is actually assigned to the class for the given teacher.
   - If the student is part of the class, reset the **TeacherID** property of the student to zero.
   - If the student is not part of the class, throw an **ArgumentException** exception to show that the student is not assigned to this class.
3. In the **Student** class, implement the **AddGrade** method as follows:
    - Verify that the **Grade** object passed to the method does not belong to another student.
    - If it does not belong to another student, add the grade to the student’s record by setting the **StudentID** property of the **Grade** object.
    - If it does belong to another student, throw an **ArgumentException** exception to show that the grade belongs to a different student.

#### Task 3: Add code to enroll a student in a teacher’s class

1. In the **Controls** folder, in the **AssignStudentDialog.xaml.cs** code, in the **Student_Click** method, write code as follows:
   - Add a **try** block.
   - Inside the **try** block, determine which student the user clicked by using the **Tag** property of the **studentClicked** button.
   - Find this student in the **Students** collection and prompt the user to confirm that they wish to add the student to their class.
   - If the user confirms this, add the student to the class by calling the **EnrollInClass** method, and then refresh the display.
   - Add a **catch** block to display a message to the user if an exception occurs.
2. In the **Refresh** method, write code as follows:
   - Find all unassigned students with a **TeacherID** of zero.
   - If there are no unassigned students, show the **txtMessage** box and hide the **list** control.
   - If there are unassigned students, hide the **txtMessage** box and show the **list** control bound to the list of unassigned students.
3. In the **StudentsPage.xaml.cs** code, in the **EnrollStudent_Click** method, add code to use the **AssignStudentDialog** to display the unassigned students. Then refresh the display to show any newly enrolled students.

#### Task 4: Add code to enable a teacher to remove the student from the assigned class

1. In the **StudentProfile.xaml.cs** code, in the **Remove_Click** method, write code as follows:
   - Detect if the user is a teacher. If they are not, exit the method.
   - Add a **try** block.
   - Inside the **try** block, display a message box to prompt the user to confirm that the current student should be removed from their class.
   - If the user confirms, call the **RemoveFromClass** method of the current teacher to remove this student from their class, and then return to the previous page.
   - Add a **catch** block to display a message to the user if an exception occurs.

#### Task 5: Add code to enable a teacher to add a grade to a student

1. In the **StudentProfile.xaml.cs** code, in the **AddGrade_Click** method, write code to add a grade to a student as follows:
   - Detect if the user is a teacher. If they are not, exit the method.
   - Add a **try** block.
   - Inside the **try** block, use the **GradeDialog** to get the details of the assessment grade and use them to create a new **Grade** object.
   - Save the grade to the list of grades.
   - Add the grade to the current student.
   - Refresh the display so that the new grade appears.
   - Add a **catch** block to display a message to the user if an exception occurs.

#### Task 6: Run the application and verify that students can be added to and removed from classes, and that grades can be added to students

1. Build the solution and resolve any compilation errors.
2. Log on as **vallee** with **password** as the password.
3. Add a student with the following details:
   - First name: **Darren**
   - Last name: **Parker**
   - Password: **password**
4. Verify that **Darren Parke**r is added to the student list.
5. Remove the student **Kevin Liu** from the student list.
6. For the student **Darren Parker**, add a new grade by using the following information:
   - Date: **current date**
   - Subject: **English**
   - Assessment: **B**
   - Comments: **Good**
7. Verify that the grade information is added to the **Report Card**.
8. Log on as the student **Darren Parker** and verify that the grade information from the previous steps is displayed in the **Report Card**.
   >**Note:** A username is generated by taking a user’s last name and the first initial of their first name.
   >
   > The username for Darren Parker is **parkerd**.
9. Close the application.
10. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the application will enable teachers to add and remove students from their classes, and to add grades to students.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
