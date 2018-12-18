
# Module 5: Creating a Class Hierarchy by Using Inheritance

## Lab: Refactoring Common Functionality into the User Class

### Scenario

You have noticed that the **Student** and **Teacher** classes in the **Grades** application contain some duplicated functionality. To make the application more maintainable, you decide to refactor this common functionality to remove the duplication.
You are also concerned about security. All teachers and students require a password, but it is important to maintain confidentiality and at the same time ensure that students (who are children) do not have to remember long and complex passwords. You decide to implement different password policies for teachers and students; teachers' passwords must be stronger and more difficult to guess than student passwords.
Also, you have been asked to update the application to limit the number of students that can be added to a class. You decide to add code that throws a custom exception if a user tries to enroll a student in a class that is already at capacity.

### Objectives

After completing this lab, you will be able to:

- Use inheritance to factor common functionality into a base class.
- Implement polymorphism by using an abstract method.
- Create a custom exception class.

### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Creating and Inheriting from the User Base Class

#### Scenario

In this exercise, you will create an abstract base class called **User** that contains the **UserName** and **Password** properties and the **VerifyPassword** method that is common to the **Student** and **Teacher** classes.  
You will modify the definitions of the **Student** and **Teacher** classes to inherit from the **User** class and remove the **UserName** and **Password** properties and the **VerifyPassword** method from these classes.  
Finally, you will build and run the application without making any other changes to the application, and then verify that it still works correctly.

#### Task 1: Create the User abstract base class

1. Start **Microsoft Visual Studio** and open the **GradesPrototype.sln** solution from the **[Repository Root]\Allfiles\Mod05\Labfiles\Starter\Exercise 1** folder.
2. In the **Grade.cs** file, in the **Data** folder, create a new abstract class called **User**.
3. Add the **UserName** and **Password** properties to the **User** class. You can copy the code for the **UserName** and **Password** properties and the private **\_password** field from either the **Student** class or the **Teacher** class.
4. Add the **VerifyPassword** method to the **User** class. You can copy the code for the **VerifyPassword** method from either the **Student** class or the **Teacher** class.

#### Task 2: Modify the Student and Teacher classes to inherit from the User class

1. In the **Grade.cs** file, modify the **Student** class to inherit from the **User** class. Remove the **UserName** and **Password** properties, and the private **\_password** field. Also remove the **VerifyPassword** method from the **Student** class.
2. Modify the **Teacher** class to inherit from the **User** class. Remove the **UserName** and **Password** properties, and the private **\_password** field. Also remove the **VerifyPassword** method from the **Teacher** class.

#### Task 3: Run the application and test the log on functionality

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** (a teacher) with **password** as the password.
4. Verify that a list of students for this teacher appears in **The School of Fine Arts** window.
5. Select the student **Kevin Liu** and verify that the report card listing the grades for this student appears.
6. Log off and then log on as **liuk** (a student) with **password** as the password.
7. Verify that the report card for **Kevin Liu** is displayed again.
8. Log off and then close the application.
9. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, you should have removed the duplicated code from the **Student** and **Teacher** classes and moved the code to an abstract base class called **User**.

### Exercise 2: Implementing Password Complexity by Using an Abstract Method

#### Scenario

In this exercise, you will add an abstract method called **SetPassword** to the **User** class.  
In the **Teacher** and **Student** classes, you will implement the **SetPassword** method. This method will set the password for the user (either a teacher or a student).  
The **SetPassword** method for a teacher will check that the password is at least eight characters long and contains at least two numeric characters.  
The **SetPassword** method for a student will check that the password is at least six characters long. If the password meets these requirements, it is set and the method will return true; otherwise, it will return false.  
You will then modify the set accessor of the **Password** property in the **User** class to call the **SetPassword** method to change the user's password.  
Next, you will integrate this feature into the user interface of the application to enable a user to change their password.  
Finally, you will build and run the application to test the password functionality.

#### Task 1: Define the SetPassword abstract method

1. In **Visual Studio**, open the **GradesPrototype.sln** solution from the **[Repository Root]\Allfiles\Mod05\Labfiles\Starter\Exercise 2** folder.
2. In the **Data** folder, in the **Grade.cs** file, in the **User** class, define a public abstract method called **SetPassword**. This method should take a string parameter containing the password and return a Boolean value indicating whether the password has been set successfully.
3. In the **User** class, modify the set accessor of the **Password** property to call the **SetPassword** method rather than directly writing to the **\_password** field. Throw an **ArgumentException** exception if the **SetPassword** method returns false.

#### Task 2: Implement the SetPassword method in the Student and Teacher classes

1. In the **User** class, make the **\_password** field protected rather than private; it needs to be accessible in the **Student** and **Teacher** classes.
2. In the **Student** class, implement the **SetPassword** method. The method should verify that the password specified as the parameter is at least six characters long. If the password is of sufficient length, then populate the **\_password** field and return true; otherwise, return false.
3. In the **Teacher** class, implement the **SetPassword** method. The method should verify that the password specified as the parameter is at least eight characters long and contains at least two numeric characters by using the following regular expression.
    ```cs
    Match numericMatch = Regex.Match(pwd, @".*[0-9]+.*[0-9]+.*");
    ```
4. If the password is of sufficient complexity, then populate the **\_password** field and return true; otherwise, return false.

#### Task 3: Set the password for a new student

1. In the code for the **StudentsPage** view, locate the **NewStudent_Click** method. This method runs when a teacher creates a new student.
2. In this method, modify the statement that sets the password for the new student to call the **SetPassword** method. If the password is not sufficiently complex and the method returns **false**, throw an **Exception** with a suitable error message.

#### Task 4: Change the password for an existing user

1. Build the solution.
2. In the **XAML** definition of the **MainWindow** window, find the definition of the **Change Password** button. When the application runs, this button appears at the top of the page. If the user clicks this button, the **ChangePassword_Click** method runs.
3. In the **MainWindow.xaml.cs** file, review the **ChangePassword_Click** method. This method displays a dialog called **ChangePasswordDialog** that enables a user to change their password.
4. In the **Controls** folder, review both the UI and the XAML code for the **ChangePasswordDialog.xaml** window. This window contains three text boxes that prompt the user to provide their old password, enter a new password, and confirm the new password. When the user clicks **OK**, the new password is set.  
    ![alt text](./Images/20483C_05_ChangePasswordDialog.png "The ChangePasswordDialog window")
5. Examine the code in the **ok_Click** method in the **ChangePassword.xaml.cs** file. This method runs when the user clicks **OK** in the **Change Password** dialog box. Currently, this method does nothing.
6. Implement the logic for the **ok_Click** method:
   - Get the details for the current user. You can use the **SessionContext.UserRole** property to determine if the current user is a teacher or a student and then use either the **CurrentTeacher** property or the **CurrentStudent** property of the **SessionContext** object to access the user details.
   - Verify that the old password specified in the dialog is correct by using the **VerifyPassword** method of the **User** class. If the password is incorrect, display a message and return from the method without changing the password.
   - Verify that the **new password** and **confirm password** text boxes in the dialog contain the same value. If they are different, display a message and return from the method without changing the password.
   - Set the password by using the **SetPassword** method of the current user. If this method returns false, display a message and return without changing the password.

#### Task 5: Run the application and test the change password functionality

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** (a teacher) with **password99** as the password.
    >**Note:** The passwords for all teachers have been changed to **password99** to ensure that they meet the complexity requirements. The password for all students is still **password**.
4. Change the password for the current user. First, try setting it to a password that is insufficiently complex, and then change it to **password101**.
5. Log out and then log back in again as **vallee** and verify that the password has been changed to **password101**.
6. Create a new student and verify that the student password must be at least six characters long. Use the **Enroll Student** feature to verify that the student is successfully created.
7. Log off and then close the application.
8. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, you should have implemented a polymorphic method named **SetPassword** that exhibits different behavior for students and teachers. You will also have modified the application to enable users to change their passwords.

### Exercise 3: Creating the ClassFullException Custom Exception

#### Scenario

In this exercise, you will create a new custom exception class called **ClassFullException**.  
You will modify the **EnrollInClass** method of the **Teacher** class to raise this exception if too many students are added to a teacher's class.  
You will update the application to catch this exception, and then you will build and run the application to test this feature.

#### Task 1: Implement the ClassFullException class

1. In **Visual Studio**, open the **GradesPrototype.sln** solution from the **[Repository Root]\Allfiles\Mod05\Labfiles\Starter\Exercise 3** folder.
2. Review the **ClassFullException** class in the **Services** folder. Notice that the class inherits from the **Exception** class, but most of the functionality is yet to be defined.
3. Add a private string field called **\_className** and a public virtual read-only string property called **ClassName** to the **ClassFullException** class. This property should return the value in the **\_className** field. The **\_className** field will hold the name of the class that is full when the exception is raised.
4. Add a default public constructor to the **ClassFullException** class. This constructor should simply delegate its responsibilities to the equivalent constructor in the **Exception** class.
5. Add a public constructor to the **ClassFullException** class that takes a string parameter containing the exception message. This constructor should also delegate its functionality to the equivalent constructor in the **Exception** class.
6. Add a public constructor to the **ClassFullException** that takes a string parameter holding the exception message and an **Exception** object containing an inner exception. Like the previous constructors, this constructor should delegate its functionality to the equivalent constructor in the **Exception** class.
7. Add a public custom constructor that takes the exception message and the name of the class that is full as parameters. Invoke the **Exception** constructor with the exception message but store the name of the class in the **\_className** field.
8. Add a public custom constructor that takes the exception message, the name of the class that is full, and an **Exception** object containing an inner exception as parameters. Invoke the **Exception** constructor with the exception message and the inner exception but store the name of the class in the **\_className** field.

#### Task 2: Throw and catch the ClassFullException

1. In the **Teacher** class, add a private constant integer field called **MAX_CLASS_SIZE** and initialize it with the value **8**. This field specifies the maximum class size for a teacher.
2. In the **EnrollInClass** method of the **Teacher** class, if the current number of students is already equal to the value in **MAX_CLASS_SIZE**, then throw a **ClassFullException** with a suitable message and the name of the class that is full (the name of the class is available in the **Class** property of **Teacher**).
3. Students are enrolled in a class by using the **AssignStudentDialog** window. Open the **AssignStudentDialog.xaml.cs** file and review the code in the **Student_Click** method. This method runs when the user selects a student to add to a class. Notice that the **try** block in this method includes the following statement:
    ```cs
    SessionContext.CurrentTeacher.EnrollInClass(student);
    ```
4. Add a **catch** handler after the **try** block that catches the **ClassFullException**. In this **catch** handler, display a suitable message that includes the exception message and class name from the exception.

#### Task 3: Build and test the solution

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** (a teacher) with **password99** as the password.
4. Create four new students.
5. Try to enroll all four students in the class for Esther Valle; this teacher currently has five students, so attempting to add the final student should fail with a **ClassFullException** exception.
6. Log off and then close the application.
7. In **Visual Studio**, close the solution.

>**Result:** After completing this exercise, you should have created a new custom exception class and used it to report when too many students are enrolled in a class.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
