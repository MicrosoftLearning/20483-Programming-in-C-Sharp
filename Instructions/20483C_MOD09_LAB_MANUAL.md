
# Module 9: Designing the User Interface for a Graphical Application

## Lab: Customizing Student Photographs and Styling the Application

### Scenario

Now that you and The School of Fine Arts are happy with the basic functionality of the application, you need to improve the appearance of the interface to give the user a nicer experience through the use of animations and a consistent look and feel.

You decide to create a **StudentPhoto** control that will enable you to display photographs of students in the student list and other views.  
You also decide to create a fluid method for a teacher to remove a student from their class.  
Finally, you want to update the look of the various views, keeping their look consistent across the application.

#### Objectives

After completing this lab, you will be able to:

- Create and use user controls.
- Use styles and animations.

### Lab Setup

Estimated Time: **90 minutes**

### Exercise 1: Customizing the Appearance of Student Photographs

#### Scenario

In this exercise, you will customize the appearance of student photographs in the production application.

You will begin by creating a **StudentPhoto** user control that will host the photographs on the various pages in the UI.  
Then you will lay out the user controls and write code to raise the **Student_Click** method when a user clicks a student photograph.  
Next, you will add a remove button with a red X to the user control that users can click to remove a student from a class. When a user places their mouse over the button, the opacity of the button and the photograph will change.  
Finally, you will run the application to verify that the student’s image is displayed correctly on the **StudentsPage** view.

#### Task 1: Create the StudentPhoto user control

1. Start **File Explorer**, navigate to the **[Repository Root]\\Allfiles\\Mod09\\Labfiles\\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close **File Explorer**.
3. Start **Microsoft Visual Studio**, and then open the **Grades.sln** solution from the **[Repository Root]\\Allfiles\\Mod09\\Labfiles\\Starter\\Exercise 1** folder.
4. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
5. Add a new WPF user control named **StudentPhoto.xaml** to the **Controls** folder in the **Grades.WPF** project.
6. Modify the XAML markup for the user control as follows:
   - Add an **Image** control to the **Grid**. This **Image** control will use data binding to display the photograph, and the source of the **Image** should be the **File** property of the data source. The **Image** should fill the user control except for a margin of **8** points all the way around to allow for a frame.
   - Add a second **Image** control to the **Grid**. This **Image** control will display the frame around the student photograph, and it should completely fill the **Grid**. Therefore, specify a margin of **0** points. Use the **Image_Frame.png** file in the **Images** folder as the source for the image. This image has a transparent center that enables the student photograph to show through.
   - Add a **TextBlock** control to display the name of the student underneath the photo frame. This control will also use data binding, and the name will be provided by the **Name** property of the data source. Use the static resource **LabelCenter** to style the text and set the **FontSize** to **16**. Set the **VerticalAlignment** to **Bottom** to ensure that the name appears underneath the photograph, and specify a margin of **8, 0, 14.583, 8** to add a bit of space around the name.
   - Change the **Class** name of the control to **Grades.WPF.StudentPhoto**. The completed markup should look like the following:
        ```xml
        <UserControl x:Class="Grades.WPF.StudentPhoto"
                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                     xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                     mc:Ignorable="d"
                     d:DesignHeight="300" d:DesignWidth="300">
            <Grid>
                <Image Stretch="UniformToFill" Source="{Binding File}" Margin="8"  />
                <Image Margin="0" Source="../Images/Image_Frame.png" Stretch="Fill" />
                <TextBlock Text="{Binding Name}"
                           Style="{StaticResource LabelCenter}"
                           FontSize="16"
                           VerticalAlignment="Bottom"
                           Margin="8, 0,14.583,8" />
            </Grid>
        </UserControl>
        ```
7. In **StudentPhoto.xaml.cs**, remove the existing **using** directives and add **using** directives to bring the following namespaces into scope:
   - **System.Windows.Controls**
   - **System.Windows.Media.Animation**
8. Change the namespace of the control to **Grades.WPF**.

#### Task 2: Display the students’ photographs in the StudentsPage view

1. In the **Views** folder, in **StudentsPage.xaml**, in the **ScrollViewer** element, locate the **ItemsControl** control named **list**. You will use this control to display the list of photographs for students in a class. In a later step, you will use data binding to associate the list of students with this control.
2. Add an **ItemTemplate** element to the **ItemsControl** below the **ItemsControl.ItemsPanel** control. This element will specify how each photograph is displayed and formatted.
3. In the **ItemTemplate** element, define a **DataTemplate** that displays the **StudentPhoto** control in a grid with a **Margin** property of **8** points.  
4. Remember that the **StudentPhoto** control is defined in the **Grades.WPF** namespace. The XAML markup for the **StudentsPage** control contains the following namespace definition to bring the types in the **Grades.WPF** namespace into scope with the alias **local**; so, you should refer to the **StudentPhoto** control as **local:StudentPhoto**.
    ```cs
    xmlns:local="clr-namespace:Grades.WPF"
    ```
5. Use the following information to set the properties of the **StudentPhoto** control.
   - Height: **150**
   - Width: **127.5**
   - Cursor: **Hand**  
    The completed markup should look like the following:
        ```xml
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid Margin="8">
                    <local:StudentPhoto Height="150" Width="127.5" Cursor="Hand" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        ```

#### Task 3: Enable the user to display the details for a student

1. In **StudentPage.xaml**, modify the instance of the **StudentPhoto** control in the **DataTemplate** element to invoke the **Student_Click** event handler when a user clicks a photo.  
    The XAML markup for the **StudentPhoto** control should look like this:
    ```xml
    <local:StudentPhoto Height="150" Width="127.5" Cursor="Hand"    MouseLeftButtonUp="Student_Click"/>
    ```
2. In **StudentsPage.xaml.cs**, in the **Events** region, locate the **Student_Click** method.
3. Review the **Student_Click** method, which raises the **StudentSelected** event to display the details of the student when a user clicks their photo.

#### Task 4: Add a Remove button to the StudentsPage view

1. In **StudentsPage.xaml**, add another grid control to the existing grid control in the **DataTemplate** element. You will add controls to this grid to display a customized "remove" icon in the upper-right corner of each photograph. If the user clicks this icon, the student will be removed from the class.
2. Use the following information to set the properties of the grid control.
   - VerticalAlignment: **Top**
   - HorizontalAlignment: **Right**
   - Background: **\#00000000**
   - Opacity: **0.3**
   - Width: **20**
   - Height: **20**
   - ToolTipService.Tooltip: **Remove from class**
   - Tag: **{Binding}**
   > **Note:** The **Tag** property will contain a reference to the student, so that the "remove" functionality knows which student to remove.
   > This property will use the data binding of **ItemsControl** that contains the **DataTemplate** to reference the student.
3. Add an image control as a child of the grid control and use it to display the **delete.png** picture in the **Images** folder. Set the **Stretch** property to **Uniform**. This image contains a cross symbol that will be displayed by the remove icon.  
    The XAML markup for the grid control should look like this:
    ```xml
    <Grid VerticalAlignment="Top"
          HorizontalAlignment="Right"
          Background="#00000000"
          Opacity="0.3"
          Width="20"
          Height="20"
          ToolTipService.ToolTip="Remove from class"
          Tag="{Binding}">
        <Image Source="../Images/delete.png" Stretch="Uniform" />
    </Grid>
    ```
4. In **StudentsPage.xaml.cs**, locate the **RemoveStudent_MouseEnter** method. This code increases the opacity of the grid that contains the remove icon and reduces the opacity of the grid that contains the photo when the user moves the mouse over the deleted image.
5. In **StudentsPage.xaml.cs**, locate the **RemoveStudent_MouseLeave** method. This code reduces the opacity of the grid that contains the remove icon and increases the opacity of the grid that contains the photo when the user moves the mouse away from the deleted image.
6. In **StudentsPage.xaml.cs**, locate the **RemoveStudent_Click** method. This code removes a student from the current teacher’s class when a user clicks the remove icon.
7. In **StudentsPage.xaml**, in the grid control for the remove icon, specify the event handlers to use when the mouse traverses the control: when the mouse enters the control, raise the **RemoveStudent_MouseEnter** event, and when the mouse leaves the control, raise the **RemoveStudent_MouseLeave** event.
8. In **StudentsPage.xaml**, in the grid control for the remove icon, specify to raise the **RemoveStudent_Click** event handler when the user clicks **Remove**. The completed XAML markup for **ItemsControl.ItemTemplate** element in **StudentsPage.xaml**, including the student photograph and the remove icon, should look like this:
    ```xml
    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <Grid Margin="8">
                <local:StudentPhoto Height="150"
                                    Width="127.5"
                                    Cursor="Hand"
                                    MouseLeftButtonUp="Student_Click" />
                <Grid VerticalAlignment="Top"
                      HorizontalAlignment="Right"
                      Background="#00000000"
                      Opacity="0.3"
                      Width="20"
                      Height="20"
                      ToolTipService.ToolTip="Remove from class"
                      Tag="{Binding}"
                      MouseEnter="RemoveStudent_MouseEnter"
                      MouseLeave="RemoveStudent_MouseLeave"
                      MouseLeftButtonUp="RemoveStudent_Click">
                    <Image Source="../Images/delete.png" Stretch="Uniform" />
                </Grid>
            </Grid>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
    ```

#### Task 5: Display all students for the current teacher

1. In the **StudentsPage.xaml.cs** file, locate the **Refresh** method. This method runs each time the **StudentsPage** view is displayed. The purpose of this method is to ensure that the view displays a correct and up-to-date list of students for the teacher.
2. In this method, review the code which finds all students for the current teacher and constructs a list of students.
3. Add code after the **foreach** loop to bind the list of students to the **list ItemsControl** control by using the **ItemsSource** property of the **list** object.

#### Task 6: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with **password99** as the password.
4. Verify that the student list appears with photographs.
5. In the student list, place your mouse over the red **x** for the student **Weber**.
6. Verify that the student photograph for **Weber** becomes transparent and that the red **x** becomes opaque.
7. Move the cursor away from the red **x** and verify that the student photograph becomes opaque and that the red **x** becomes transparent.
8. Click the red **x** for **Weber**, verify that the **Student** message box appears, and then click **Yes**.
9. Verify that **Weber** is removed from the student list.
10. Close the application, and then in **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the application will display the photographs of each student on the **Student List** page.

### Exercise 2: Styling the Logon View

#### Scenario

In this exercise, you will update the **LogonPage** control to have the same look and feel as the rest of the application.

First, you will define styles for the username and password text boxes on the **LogonPage** of the application. You will use the **Style** property of each control to apply the styles that you have defined.  
Then you will define some global styles for use across the entire application.  
You will define a style for labels and a style for text.  
Finally, you will run the application to verify that the styling of the text elements has changed throughout the application.

#### Task 1: Define and apply styles for the LogonPage view

1. In **Visual Studio**, open the **Grades.sln** solution from the **[Repository Root]\Allfiles\Mod09\Labfiles\Starter\Exercise 2** folder.
2. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
3. In the **Grades.WPF** project, in the **Views** folder, open **LogonPage.xaml**.
4. In the **LogonPage** user control, create a **Resources** section.
5. In the **Resources** section, define a style named **LoginTextBoxStyle**, which targets text boxes, and is based on the **TextBoxStyle** style.
6. Use the following information to set properties of the style:
   - Margin: **5**
   - FontSize: **24**
   - MaxLength: **16**  
     The XAML markup for the style should look like this:
        ```xml
        <UserControl.Resources>
            <Style x:Key="LoginTextBoxStyle" BasedOn="{StaticResource TextBoxStyle}" TargetType="{x:Type TextBox}">
                <Setter Property="Margin" Value="5" />
                <Setter Property="FontSize" Value="24"/>
                <Setter Property="MaxLength" Value="16" />
            </Style>
        </UserControl.Resources>
        ```
7. Locate the definition of the **username** text box, delete the **FontSize** property of the control, and then apply the **LoginTextBoxStyle** to the control.
8. In the **Resources** section, define another style named **PasswordBoxStyle** that targets password boxes.
9. Use the following information to set properties of the style:
   - Margin: **5**
   - FontSize: **24**
   - MaxLength: **16**
10. Locate the definition of the **password** text box, delete the **FontSize** property of the control, and then apply the **PasswordBoxStyle** to the control.

#### Task 2: Define global styles for the application

1. In the **Themes** folder, open the **Generic.xaml** file.
2. Locate the **\<!-- TODO: Exercise 2: Task 2a: Define the label styling used throughout the application --\>** comment near the end of the file.
3. Below this comment, set the properties of the **LabelStyle** style by using the following information:
   - TextWrapping: **NoWrap**
   - FontFamily: **Buxton Sketch**
   - FontSize: **19**
   - Foreground: **#FF303030**
4. Locate the **\<!-- TODO: Exercise 2: Task 2b: Define the text styling used throughout the application --\>** comment.
5. Below this comment, set the properties of the **TextBoxStyle** style by using the following information:
   - TextWrapping: **NoWrap**
   - FontFamily: **Buxton Sketch**
   - FontSize: **12**
   - TextAlignment: **Left**
   - Foreground: **#FF303030**

#### Task 3: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with **password99** as the password.
4. In the **The School of Fine Arts** window, verify that the styling of the text elements of the application has changed.  
    ![alt text](./Images/20483C_09_LogonView.png "Upper: Old style Logon view. Lower: New style Logon view")
5. Close the application, and then in **Visual Studio**, close the solution.

>**Result:** After completing this exercise, the **Logon** view will be styled with a consistent look and feel.

### Exercise 3: Animating the StudentPhoto Control (If Time Permits)

#### Scenario

In this exercise, you will update the **StudentPhoto** control to animate when the user places the mouse over it.

First, you will define an animation for the **StudentPhoto** control, which will cause a student’s photograph to pulse when a user places their mouse over it.  
You will then add event handlers for this animation and apply the animation to the control.  
Finally, you will run the application to verify that the animation executes correctly.

#### Task 1: Define animations for the StudentPhoto control

1. In **Visual Studio**, open the **Grades.sln** solution from the **[Repository Root]\\Allfiles\\Mod09\\Labfiles\\Starter\\Exercise 3** folder.
2. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
3. In the **Grades.WPF** project, in the **Controls** folder, open the **StudentPhoto.xaml** file.
4. Create a **RenderTransform** element in **UserControl**.
5. Inside the **RenderTransform** element, add a **ScaleTransform** named **scale**. You will use this transform to change the size of the **StudentPhoto** user control when the mouse moves over it.
6. Create a **Resources** element in **UserControl**.
7. Inside the **Resources** element, add a **Storyboard** element that will contain animations that are performed when the mouse enters the control; set the **x:Key** property to **sbMouseEnter**.
8. Inside the **Storyboard** element, add a **DoubleAnimation** element. Use the following information to define the properties of the animation:
   - To: **1.1**
   - BeginTime: **00:00:00**
   - Duration: **00:00:00.05**
   - Storyboard.TargetName: **scale**
   - Storyboard.TargetProperty: **ScaleX**
9. Inside the **Storyboard** element, add another **DoubleAnimation** element. Use the following information to define the properties of the animation:
   - To: **1.1**
   - BeginTime: **00:00:00**
   - Duration: **00:00:00.15**
   - Storyboard.TargetName: **scale**
   - Storyboard.TargetProperty: **ScaleY**
10. After the existing **Storyboard** element, add another **Storyboard** element that will contain animations that are performed when the mouse leaves the control; set the **x:Key** property to **sbMouseLeave**.
11. Inside the **Storyboard** element, add a **DoubleAnimation** element. Use the following information to define the properties of the animation:
    - To: **1**
    - BeginTime: **00:00:00**
    - Duration: **00:00:00.05**
    - Storyboard.TargetName: **scale**
    - Storyboard.TargetProperty: **ScaleX**
12. Inside the **Storyboard** element, add another **DoubleAnimation** element. Use the following information to define the properties of the animation:
    - To: **1**
    - BeginTime: **00:00:00**
    - Duration: **00:00:00.15**
    - Storyboard.TargetName: **scale**
    - Storyboard.TargetProperty: **ScaleY**

#### Task 2: Add event handlers to trigger the animations

1. In the **StudentPhoto.xaml.cs** file, locate the **Storyboard** region.
2. Add code to define the **OnMouseEnter** event handler that triggers the mouse enter animation (**sbMouseEnter**), as follows:
    ```cs
    public void OnMouseEnter()
    {
       // Trigger the mouse enter animation to grow the size of the photograph currently under the mouse pointer
        (this.Resources["sbMouseEnter"] as Storyboard).Begin();
    }
    ```
3. Add code to define the **OnMouseLeave** event handler that triggers the mouse leave animation (**sbMouseLeave**).
4. In the **Views** folder, open the **StudentsPage.xaml.cs** file.
5. In the **Events** region, add an event handler called **Student_MouseEnter** to forward the **MouseEnter** event to the **StudentPhoto** control, as follows:
    ```cs
    private void Student_MouseEnter(object sender, MouseEventArgs e)
    {
        // Call the OnMouseEnter event handler on the specific photograph currently under the mouse pointer
        ((StudentPhoto)sender).OnMouseEnter();
    }
    ```
6. Add another event handler called **Student_MouseLeave** that forwards the **MouseLeave** event to the **StudentPhoto** control.
7. In the XAML markup for the **StudentsPage** view, specify that the **MouseEnter** event for the **StudentPhoto** control in the **DataTemplate** should trigger the **Student_MouseEnter** event handler method, and the **MouseLeave** event should trigger the **Student_MouseLeave** event handler.

#### Task 3: Build and test the application

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** with **password99** as the password.
4. Place your mouse over one of the students in the student list and verify that the photograph animates—it should expand and contract as the mouse passes over it.
5. Close the application, and then in **Visual Studio**, close the solution

>**Result:** After completing this exercise, the **Photograph** control will be animated.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
