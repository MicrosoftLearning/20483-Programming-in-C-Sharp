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




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.