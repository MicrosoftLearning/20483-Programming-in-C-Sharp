# Module 2: Creating Methods, Handling Exceptions, and Monitoring Applications

## Lab: Extending the Class Enrollment Application Functionality

### Scenario

You have been asked to refactor the code that you wrote in the lab exercises for module 1 into separate methods to avoid the duplication of code in the Class Enrollment application.

Also, you have been asked to write code that validates the student information that the user enters and to enable the updated student information to be written back to the database, handling any errors that may occur.

### Objectives

After completing this lab, you will be able to:

- Refactor code to facilitate reusability.
- Write Visual C# code that validates data entered by a user.
- Write Visual C# code that saves changes back to a database.

### Lab Setup

Estimated Time: **90 minutes**

### Exercise 1: Refactoring the Enrollment Code

#### Scenario

In this exercise, you will refactor the existing code to avoid writing duplicate code.

The application currently allows a user to edit a student’s details by pressing Enter. Now, you want users to be able to initiate the edit process by double-clicking a student in the list. You will begin by creating a new method that contains the code for editing a student’s details. This will avoid duplicating and maintaining the code in both event handlers. You will then call the new method from both the **studentsList_MouseDoubleClick** and **StudentsList_Keydown** events. While doing this, you also decide to refactor the code for adding and deleting students into separate methods, so that it can be called from other parts of the application if the need arises. You will then run the application and verify that users can press Enter or double-click a student to edit the student’s details, can press Insert to add a new student, and can press Delete to remove a student.

#### Task 1: Copy the code for editing a student into the studentsList_MouseDoubleClick event handler

1. Start **File Explorer**, navigate to the **[Repository Root]\Allfiles\Mod02\Labfiles\Databases** folder, and then run **SetupSchoolDB.cmd**.
2. Close **File Explorer**.
3. Start **Microsoft Visual Studio** and from the **[Repository Root]\Allfiles\Mod02\Labfiles\Starter\Exercise 1** folder, open the **School.sln** solution.
4. In the code for the **MainWindow.xaml.cs** window, in the **studentsList_KeyDown** event, locate the code for editing student details which is in the **case Key.Enter** block.
5. Copy the code in this block to the clipboard and then paste it into the **StudentsList_MouseDoubleClick** method.

#### Task 2: Run the application and verify that the user can now double-click a student to edit their details

1. Build the solution and resolve any compilation errors.
2. Change **Kevin Liu’s** last name to **Cook** by pressing Enter in the main application window.
3. Verify that the updated data is copied back to the student list and that the **Save Changes** button is now enabled.
4. Change **George Li’s** name to **Darren Parker** by double-clicking his row in the main application window.
5. Verify that the updated data is copied back to the student list.
6. Close the application.

#### Task 3: Refactor the logic that adds and deletes a student into the addNewStudent and deleteStudent methods

1. Refactor the code in the **case Key.Insert** code block in the **studentsList_KeyDown** method into a method called **addNewStudent** that takes no parameters.
2. Call this method from the **case Key.Insert** code block in the **studentsList_KeyDown** method.
3. Refactor the code in the **case Key.Delete** code block in the **studentsList_KeyDown** method into a method called **removeStudent** that takes a student as a parameter.
4. Call this method from the **case Key.Delete** code block in the **studentsList_KeyDown** method.

#### Task 4: Verify that students can still be added and removed from the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Add a new student by pressing Insert to display the new student in the **Class 3C** window, and verify that it contains no data.
4. Enter details for **Dominik Dubicki**, whose date of birth is **02/03/2006**, and verify that the new student is added to the student list.
5. Delete the student **Run Liu** and verify that the prompt window appears and the student is removed from the student list.
6. Close the application.

#### Task 5: Debug the application and step into the new method calls

1. Add a breakpoint at the start of the **switch** statement in the **studentsList_KeyDown** method.
2. Debug the application.
3. Edit the row for **Kevin Liu** by pressing Enter.
4. Step over the code, watching the **Call Stack** window and the **Locals** window, until you reach the **editStudent** method call, and then step into that method.
5. Step out of the **editStudent** method.
6. Cancel editing the student’s details, and then continue debugging.
7. Add a new student by pressing Insert.
8. Step over the code until you reach the **addNewStudent** method call, and then step into that method.
9. Step out of the **addNewStudent** method.
10. Cancel adding a new student, and then continue debugging.
11. Delete the row for **George Li** by pressing Delete.
12. Step over the code until you reach the **removeStudent** method call, and then step into that method.
13. Step out of the **removeStudent** method.
14. Cancel deleting the student.
15. Stop debugging the application.
16. In **Visual Studio**, delete all breakpoints and then close the solution.

>**Results** : After completing this exercise, you should have updated the application to refactor duplicate code into reusable methods.

### Exercise 2: Validating Student Information

#### Scenario

In this exercise, you will write code that validates the information that a user enters for a student.
Up until this point, almost anything can be entered as student data, and fields can be left blank. This means, for example, that a student could be added to the student list with no last name or with an invalid date of birth.
You will write code to check that when adding or editing a student, the first name and last name fields for the student contain data.
You will also write code to check that the date of birth entered is a valid date and that the student is at least five years old.
Finally, you will run the application and test your validation code.

#### Task 1: Run the application and observe that student details that are not valid can be entered

1. In **Visual Studio**, from the **[Repository Root]\Allfiles\Mod02\Labfiles\Starter\Exercise 2** folder, open the **School.sln** solution.
2. Build the solution and resolve any compilation errors.
3. Run the application.
4. Press Insert to display the **new student** window.
5. Leave the **First Name** and **Last Name** boxes empty, and type **10/06/3012** in the **Date of Birth** text box.
6. Click **OK** and verify that a new row has been added to the student list, containing a blank first name, blank last name, and a negative age.
7. Close the application.

#### Task 2: Add code to validate the first name and last name fields

1. In the **ok_Click** method, in the **StudentForm.xaml.cs** code, add a statement to check if the **First Name** text box is empty.
2. If it is empty, display a message box with the caption  **Error** and the text **The student must have a first name**, and then exit the method.
3. In the **ok_Click** method in the **StudentForm.xaml.cs** code, add a statement to check if the **Last Name** text box is empty.
4. If it is empty, display a message box with the caption **Error** and the text **The student must have a last name**, and then exit the method.

#### Task 3: Add code to validate the date of birth

1. In the **ok_Click** method, in the **StudentForm.xaml.cs** code, add a statement to check if the **Date of Birth** text box is empty.
2. If the entered date is invalid, display a message box with the caption **Error** and the text **The date of birth must be a valid date**, and then exit the method.
3. In the **ok_Click** method in **StudentForm.xaml.cs** code, add a statement to calculate the student’s age in years, and check if the age is less than five years.
4. If the age is less than five years, display a message box with the caption **Error** and the text **The student must at least 5 years old**, and then exit the method.  
    Use the following formula to calculate the age in years.  
    *Age in years = age in days/365.25*

#### Task 4: Run the application and verify that student information is now validated correctly

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Press Insert to display the **new student** window.
4. Leave the **First Name**, **Last Name**, and **Date of Birth** text boxes empty.
5. Click **OK**, verify that an error message appears containing the text **The student must have a first name**, and then close the error message.
6. Type **Darren** in the **First Name** text box, and then click **OK**.
7. Verify that an error message appears containing the text **The student must have a last name**, and then close the error message.
8. Type **Parker** in the **Last Name** text box, and then click **OK**.
9. Verify that an error message appears containing the text **The date of birth must be a valid date**, and then close the error message.
10. Type **10/06/3012** in the **Date of Birth** text box, and then click **OK**.
11. Verify that an error message appears containing the text **The student must be at least 5 years old**, and then close the error message.
12. Amend the date to **10/06/2006**, click **OK**, and then verify that Darren Parker is added to the student list with an age appropriate to the current date.
13. Close the application.
14. In **Visual Studio**, close the solution.

>**Results** : After completing this exercise, student data will be validated before it is saved.

### Exercise 3: Saving Changes to the Class List

#### Scenario

In this exercise, you will write code that saves changes in the student list to the database.

Every time the user closes and opens the application, they are presented with the original student list as it existed when they first ran the application, regardless of any changes they may have made.  
You will write code to save changes back to the database when the user clicks the **Save Changes** button.  
You will then add exception handling code to catch concurrency, update, and general exceptions, and handle the exceptions gracefully.  
Finally, you will run your application and verify that the changes you make to student data are persisted between application sessions.

#### Task 1: Verify that data changes are not persisted to the database

1. In **Visual Studio**, from the **[Repository Root]\Allfiles\Mod02\Labfiles\Starter\Exercise 3** folder, open the **School.sln** solution.
2. Build the solution and resolve any compilation errors.
3. Run the application.
4. Change **Kevin Liu’s** last name to **Cook** by pressing Enter in the main application window
5. Verify that the updated data is copied to the student list and that the **Save Changes** button is enabled.
6. Click **Save Changes**.
7. Delete the student **George Li**, and then click **Save Changes**.
8. Close the application.
9. Run the application again and verify that it displays the original list of students, without the changes that you just made.
10. Close the application.

#### Task 2: Add code to save changes back to the database

1. In the **MainWindow.xaml.cs** code bring the **System.Data** and **System.Data.Objects** namespaces into scope.
2. Add code to perform the following tasks when a user clicks **Save Changes**:
    - Call the **SaveChanges** method of the **schoolContext** object.
    - Disable the **Save Changes** button.

#### Task 3: Add exception handling to the code to catch concurrency, update, and general exceptions

1. Enclose the lines of code that call the **SaveChanges** method of the **schoolContext** object and disable the **Save Changes** button in a **try** block.
2. Below the **try** block, add a **catch** block to catch any  **OptimisticConcurrencyException** exceptions that may occur.
3. In the **catch** block, add the following code:

    ```cs
    // If the user has changed the same students earlier, then overwrite their changes with the new data
    this.schoolContext.Refresh(RefreshMode.ClientWins, schoolContext.Students);
    this.schoolContext.SaveChanges();
    ```

4. Add another **catch** block to catch any **UpdateException** exceptions that may occur, storing the exception in a variable named **uEx**.
5. In the **catch** block, add the following code:

    ```cs
    // If some sort of database exception has occurred, then display the reason for the exception and rollback
    MessageBox.Show(uEx.InnerException.Message, "Error saving changes");
    this.schoolContext.Refresh(RefreshMode.StoreWins, schoolContext.Students);
    ```

6. Add another **catch** block to catch any other type of exception that might occur, storing the exception in a variable named **ex**.
7. In the **catch** block, add the following code:

    ```cs
    // If some other exception occurs, report it to the user
    MessageBox.Show(ex.Message, "Error saving changes");
    this.schoolContext.Refresh(RefreshMode.ClientWins, schoolContext.Students);
    ```

#### Task 4: Run the application and verify that data changes are persisted to the database

1. Run the application.
2. Change the last name of **Kevin Liu** to **Cook**.
3. Verify that **Save Changes** button working as expected.
4. Remove the student **George Li**.
5. Close the application.

>**Results** : After completing this exercise, modified student data will be saved to the database.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, m ay change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
