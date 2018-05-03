# Module 9:  Designing the User Interface for a Graphical Application

# Lesson 1:  Using XAML to Design a User Interface

### Demonstration: Using Design View to Create a XAML UI

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **New**, and then click
    **Project**.
3.  In the **New Project** dialog box, in the **Templates** list, click **Visual
    C\#**, and then in the **Project Type** list, click **WPF Application**.
4.  In the **Name** box, type **DesignView**.
5.  In the **Location** text box, set the location to **Allfiles\\Mod09\\Democode**,
    and then click **OK**.
6.  In the XAML pane, in the **Window** element, change the value of the
    **Title** attribute to **Order Your Coffee Here**.
7.  Add the following markup between the opening and closing **Grid** tags:
    ```xml
    <Grid.RowDefinitions>
       <RowDefinition Height="Auto" />
       <RowDefinition Height="*" />
    </Grid.RowDefinitions>
    ```
8.  Open the **Toolbox** pane, expand **Common WPF Controls**, and then
    double-click **Button**.
9.  On the design surface, drag the button towards the top of the screen until a
    message displays **Press Tab to place inside row 0**. Press **Tab**, and
    then release the button.
10.  In the XAML pane, in the **Button** element, change the value of the
    **Content** attribute to **Make Me a Coffee!**.
11.  Change the value of the **HorizontalAlignment** attribute to **Center**.
12.  Change the value of the **Width** attribute to **Auto**.
13.  In the **Properties** window, ensure the button is selected, and then in the
    **Name** box, type **btnGetCoffee**.
14.  In the **Toolbox** pane, double-click **Label**.
15.  On the design surface, drag the label to anywhere in the lower row of the
    **Grid**.
16.  In the XAML pane, in the **Label** element, change the value of the
    **Content** attribute to an empty string.
17. Change the value of the **HorizontalAlignment** attribute to **Center**.
18. In the **Properties** window, ensure the label is selected, and then in the
    **Name** text box, type **lblResult**.
19. On the design surface, double-click **Make Me a Coffee!**.
20. Notice that Visual Studio automatically creates an event handler method and
    switches to the code-behind page.
21. In the **btnGetCoffee_Click** method, add the following code:
    ```cs
    lblResult.Content = "Your coffee is on its way.";
    ```
22.  On the **Debug** menu, click **Start Without Debugging**.
23.  In the **Order Your Coffee Here** window, click **Make Me a Coffee!**.
24.  Notice that the label displays a message.
25.  Close the **Order Your Coffee Here** window, and then close Visual Studio.




# Lesson 3:  Styling a UI

### Demonstration: Customizing Student Photographs and Styling the Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Open the **Grades.sln** solution from the
    **E:\\Mod09\\Labfiles\\Solution\\Exercise 3** folder.
2.  In Solution Explorer, right-click **Solutions ‘Grades’**, and then click
    **Properties**.
3.  On the **Startup Project** page, click **Multiple startup projects**. Set
    **Grades.Web** and **Grades.WPF** to **Start without debugging**, and then
    click **OK**. Explain to students that they will have to perform this step
    whenever they open lab starter files because the startup project information
    is stored in the .suo user options file for a solution which is not included
    in the Allfiles for this course.
4.  Build the solution.
5.  In the **Grades.WPF** project, in the **Controls** folder, open
    **StudentPhoto.xaml**.
6.  Review the XAML markup and explain to students that in Exercise 1 of the
    lab, they will create a **StudentPhoto** user control and add code to use it
    in the application.
7.  In the **Views** folder, open **StudentsPage.xaml** and explain to students
    that they will create the **ItemsControl** and **DataTemplate** elements in
    this file to host the **StudentPhoto** control and the remove button.
8.  Open **StudentsPage.xaml.cs** and locate the **Student_Click** event.
9.  Explain to students that they will add this code to raise the
    **StudentSelected** event when a user clicks a photograph.
10. In the **Views** folder, open **StudentProfile.xaml**.
11. Locate the **StudentPhoto** element and explain to students that they will
    add the user control to this view.
12. Open **LogonPage.xaml** and explain to students that in Exercise 2 they will
    define two styles: one for the username box and one for the password box.
    Also show students the markup where the style is applied to a control.
13. In the **Themes** folder, open **Generic.xaml**. Explain to students that
    here they will define properties for labels and text throughout the
    application.
14. Run the application and point out the styling of the labels and text boxes
    on the Log on page.
15. Log on as **vallee** with a password of **password99**.
16. Hover over one of the students in the student list and point out that the
    photograph animates.
17. Hover over a remove button and point out that the photograph dims.
18. Log off, and then log on as **liyale** with a password of **password**.
19. Explain that parents can now use the application and review the grades of
    all of their children.
20. Click each child’s name in turn and then log off.
21. Close the application, and then close Visual Studio.





©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.