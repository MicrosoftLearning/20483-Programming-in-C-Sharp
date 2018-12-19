# Module 10: Improving Application Performance and Responsiveness

## Lab: Improving the Responsiveness and Performance of the Application

### Scenario

You have been asked to update the **Grades** application to ensure that the UI remains responsive while the user is waiting for operations to complete. To achieve this improvement in responsiveness, you decide to convert the logic that retrieves the list of students for a teacher to use asynchronous methods. You also decide to provide visual feedback to the user to indicate when an operation is taking place.

### Objectives

After completing this lab, you will be able to:

- Use the **async** and **await** keywords to implement asynchronous methods.
- Use events and user controls to provide visual feedback during long-running operations.

### Lab Setup

Estimated Time: **75 minutes**

### Exercise 1: Ensuring That the UI Remains Responsive When Retrieving Teacher Data

#### Scenario

In this exercise, you will modify the functionality that retrieves data for teachers to make use of asynchronous programming techniques.

First, you will modify the code that gets the details of the current user (when the user is a teacher) to run asynchronously.  
You will use an asynchronous task to run the LINQ query and use the **await** operator to return the results of the query.  
Next, you will modify the code that retrieves the list of students for a teacher. In this case, you will configure the code that retrieves the list of students to run asynchronously.  
When the operation is complete, your code will invoke a callback method to update the UI with the list of students.  
Finally, you will build and test the application and verify that the UI remains responsive while the application is retrieving data.

#### Task 1: Build and run the application

1. Start File Explorer, navigate to the **[Repository Root]\Allfiles\Mod10\Labfiles\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close File Explorer.
3. Start Visual Studio, from the **[Repository Root]\Allfiles\Mod10\Labfiles\Starter\Exercise 1** folder, open the **Grades.sln** solution.
4. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
5. Build the solution, and then resolve any compilation errors.
6. Run the application.
7. Sign in as **vallee** and the password **password99**.
8. Notice that the UI briefly freezes while fetching the list of students for Esther Valle (try moving the application window after logging on but before the list of students appears).
9. Close the application.

#### Task 2: Modify the code that retrieves teacher data to run asynchronously

1. In the **Grades.WPF** project, in the **Services** folder, open **ServiceUtils.cs**.
2. Modify the **GetTeacher** method declaration so that it:
    - Runs asynchronously.
    - Returns a **Task\<Teacher>** object.
3. In the **GetTeacher** method, modify the LINQ query to use the **await** operator to run the query asynchronously and to return a **Task\<Teacher\>** object.
4. In the **MainWindow** class, modify the **Refresh** method declaration so that the method runs asynchronously.
5. In the **Refresh** method, in the **case "Teacher"** block, modify the call to the **GetTeacher** method to run asynchronously.

#### Task 3: Modify the code that retrieves and displays the list of students for a teacher to run asynchronously

1. In the **StudentsPage** class, modify the **Refresh** method declaration so that the method runs asynchronously.
2. In the **Refresh** method, in the **Callbacks** region, locate the code that iterates through the returned set of students and updates the UI.
3. Factor out this code into a new method named **OnGetStudentsByTeacherComplete**. This method should:
    - Accept a single argument of type **IEnumerable\<Student>**.
    - Return **void**.
    - Use a **Dispatcher** object to update the UI.
4. In the **ServiceUtils** class, modify the **GetStudentsByTeacher** method declaration so that it:
    - Runs asynchronously.
    - Returns a **Task** object.
    - Accepts a delegate argument that can represent the **OnGetStudentsByTeacherComplete** callback method.
5. Modify the **GetStudentsByTeacher** method so that it returns without passing a value if the call to **IsConnected** returns **false**.
6. In the **GetStudentsByTeacher** method, use the **await** operator to run the LINQ query asynchronously and return a **Task<Student\>** object.
7. Modify the **GetStudentsByTeacher** method so that it invokes the callback method delegate asynchronously rather than returning the results.
8. In the **StudentsPage** class, modify the **Refresh** method so that it:
    - Calls the **GetStudentsByTeacher** method asynchronously.
    - Passes the **OnGetStudentsByTeacherComplete** method as the second argument.

#### Task 4: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Sign in as **vallee** and the password **password99**.
4. Verify that the application is more responsive than before while fetching the list of students for Esther Valle.
5. Close the application, and then close the solution.

> **Result :** After completing this exercise, you should have updated the **Grades** application to retrieve data asynchronously.

### Exercise 2: Providing Visual Feedback During Long-Running Operations

#### Scenario

In this exercise, you will create a user control that displays a progress indicator while the **Grades** application is retrieving data.

You will add this user control to the main page but will initially hide it from view.  
Next, you will modify the code that retrieves data so that it raises one event when the data retrieval starts and another event when the data retrieval is complete.  
You will create handler methods for these events that toggle the visibility of the progress indicator control, so that the application displays the progress indicator when data retrieval starts and hides it when data retrieval is complete.  
Finally, you will build and test the application and verify that the UI displays the progress indicator while the application is retrieving data.

#### Task 1: Create the BusyIndicator user control

1. In Visual Studio, from the **[Repository Root]\Allfiles\Mod10\Allfiles\Labfiles\Starter\Exercise 2** folder, open the **Grades.sln** solution.
2. Set the following projects to start at startup:
    - **Grades.Web**
    - **Grades.WPF**
3. Build the solution.
4. In the **Grades.WPF** project, create a new user control named **BusyIndicator.xaml**.
5. Move the **BusyIndicator.xaml** file into the **Controls** folder.
    > **Note :** It is better to create the user control at the project level and then move it into the **Controls** folder when it is created. This ensures that the user control is created in the same namespace as other project resources.
6. Ensure that the user control does not specify dimensions by deleting the **DesignWidth** and **DesignHeight** properties.
7. In the **BusyIndicator.xaml** file, modify the existing **Grid** element to have a background color of **#99000000**.
8. In the **Grid** element, add a **Border** element with the following characteristics:
    - Set the corner radius to **6** units.
    - Set the horizontal and vertical alignments to **Center**.
    - Set the background to a horizontal linear gradient from light gray to dark gray.
    - Add a drop shadow effect with opacity of 0.75.
9. In the **Border** element, add a **Grid** element with the following characteristics:
    - Set the margin to **10** units.
    - Define two rows with automatically determined heights.
10. In the first row of the **Grid** element, add a **ProgressBar** element with the following characteristics:
    - Set the width to **200** units.
    - Set the height to **25** units.
    - Set the margin to **20** units.
    - Set the name of the control to **progress**.
    - Set the progress bar to provide generic, continuous feedback rather than actual values (Hint: use the **IsIndeterminate** attribute).
11. In the second row of the **Grid** element, add a **TextBlock** element with the following characteristics:
    - Set the font size to **14** points.
    - Apply the **Verdana** font.
    - Set the text alignment to **Center**.
    - Display the message **Please Wait…**
    - Set the name of the control to **txtMessage**.
12. Your completed XAML markup should look like the following code:
    ```xml
    <UserControl x:Class="Grades.WPF.BusyIndicator"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Grid Background="#99000000">
            <Border CornerRadius="6"
                    VerticalAlignment="Center"
                    HorizontalAlignment="Center">
                <Border.Background>
                    <LinearGradientBrush>
                        <GradientStop Color="LightGray" Offset="0" />
                        <GradientStop Color="DarkGray" Offset="1" />
                    </LinearGradientBrush>
                </Border.Background>
                <Border.Effect>
                    <DropShadowEffect Opacity="0.75" />
                </Border.Effect>
                <Grid Margin="10">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <ProgressBar x:Name="progress"
                                 IsIndeterminate="True"
                                 Width="200"
                                 Height="25"
                                 Margin="20" />
                    <TextBlock x:Name="txtMessage"
                               Grid.Row="1"
                               FontSize="14"
                               FontFamily="Verdana"
                               Text="Please Wait..."
                               TextAlignment="Center"/>
                </Grid>
            </Border>
        </Grid>
    </UserControl>
    ```
13. Save all files.
14. In the **Grades.WPF** project, in the **MainWindow.xaml** file, add a **BusyIndicator** element with the following characteristics:
    - Set the margin to **0**.
    - Set the visibility to **Collapsed**.
    - Set the name of the control to **busyIndicator**.
    - Build the solution.

#### Task 2: Add StartBusy and EndBusy event handler methods

1. In the **MainWindow** class, add a private method named **StartBusy**. The method should:
    - Return **void**.
    - Accept two arguments, of type **object** and **EventArgs**.
2. In the **StartBusy** method, make the **busyIndicator** control visible.
3. In the **MainWindow** class, add a private method named **EndBusy**. The method should:
    - Return **void**.
    - Accept two arguments, of type **object** and **EventArgs**.
4. In the **EndBusy** method, make the **busyIndicator** control hidden.

#### Task 3: Raise the StartBusy and EndBusy events

1. In the **StudentsPage** class, add a public event named **StartBusy**.
2. Add a public event named **EndBusy**.
3. Add a method named **StartBusyEvent** that takes no arguments and returns **void**.
4. In the **StartBusyEvent** method, raise the **StartBusy** event.
5. Add a method named **EndBusyEvent** that takes no arguments and returns **void**.
6. In the **EndBusyEvent** method, raise the **EndBusy** event.
7. In the **MainWindow.xaml** file, in the **StudentsPage** element, associate the **StartBusy** event handler method with the **StartBusy** event.
8. In the **StudentsPage** element, associate the **EndBusy** event handler method with the **EndBusy** event.
9. In the **StudentsPage** class, at the start of the **Refresh** method, raise the **StartBusy** event by calling the **StartBusyEvent** method.
10. At the end of the **Refresh** method, raise the **EndBusy** event by calling the **EndBusyEvent** method.

#### Task 4: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Sign in as **vallee** and the password **password99**.
4. Verify that the application displays the busy indicator while waiting for the list of students to load.
5. Close the application, and then close the solution.

>**Result :** After completing this exercise, you should have updated the Grades application to display a progress indicator while the application is retrieving data.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
