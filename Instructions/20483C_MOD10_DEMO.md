
# Module 10:   Improving Application Performance and Responsiveness

## Lesson 2:  Performing Operations Asynchronously

### Demonstration: Using the Tak Parallel Library to Invoke APM Operations

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]\Allfiles\Mod10\Democode\Starter**, and then open the **APMTasks.sln** file.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.

#### Demonstration Steps

1. On the **Build** menu, click **Build Solution**.
2. On the **Debug** menu, click **Start Without Debugging**.
3. In the text box, type **http://www.fourthcoffee.com**, and then click **Check URL**.  
   Notice that the label displays the message **The URL returned the following status code: OK**.
4. Close the **MainWindow** window.
5. In **Solution Explorer**, expand **MainWindow.xaml**, and then double-click **MainWindow.xaml.cs**.
6. Review the code in the **MainWindow** class:
    - Notice that the **btnCheckUrl_Click** method creates an **HttpWebRequest** object and then calls the **BeginGetResponse** method.
    - Notice that the **BeginGetResponse** method specifies the **ResponseCallback** method as an asynchronous callback method.
    - Notice that the **ResponseCallback** method calls the **HttpWebResponse.EndGetResponse** method to get the result of the web request and then updates the UI.
7. Delete the **ResponseCallback** method.
8. Modify the **btnCheckUrl_Click** method declaration to include the **async** modifier as follows:
    ```cs
    private async void btnCheckUrl_Click(object sender, RoutedEventArgs e)
    ```
9. In the **btnCheckUrl_Click** method, delete the following line of code:
    ```cs
    request.BeginGetResponse(new AsyncCallback(ResponseCallback), request);
    ```
10. Add the following code in place of the line you just deleted:
    ```cs
    HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
    lblResult.Content = String.Format("The URL returned the following status code: {0}", response.StatusCode);
    ```
11. Notice that the **MainWindow** class is now far more simple and concise.
12. On the **Debug** menu, click **Start Without Debugging**.
13. In the text box, type **http://www.fourthcoffee.com**, and then click **Check URL**.
14. Notice that the label displays the message **The URL returned the following status code: OK**.
15. Notice that the application works in exactly the same way as before.
16. Close the **MainWindow** window, and then close Visual Studio.

## Lesson 3:  Synchronizing Concurrent Access to Data

### Demonstration:  Using Lock Statements

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos.(**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]\Allfiles\Mod10\Democode\Starter**, and then open the **Locking.sln** file.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.

#### Demonstration Steps

1. In **Solution Explorer**, double-click **Coffee.cs**.
2. Review the **Coffee** class, paying particular attention to the **MakeCoffees** method.
3. Notice how the **MakeCoffees** method uses a **lock** statement to prevent concurrent access to the critical code.
4. In **Solution Explorer**, double-click **Program.cs**.
5. In the **Program** class, review the **Main** method.
6. Notice how the **Main** method uses a **Parallel.For** loop to simultaneously place 100 orders for between one and 100 coffees.
7. On the **Build** menu, click **Build Solution**.
8. On the **Debug** menu, click **Start Debugging**.
9. Review the console window output and notice that the application keeps track of stock levels effectively.
10. To close the console window, press Enter.
11. In the **Coffee** class, comment out the following line of code:
    ```cs
    lock (coffeeLock)
    ```
12. On the **Debug** menu, click **Start Debugging**.
13. Notice that the application throws an exception with the message **Stock cannot be negative!**
14. Explain that this is due to concurrent access to the critical code section in the **MakeCoffees** method.
15. On the **Debug** menu, click **Stop Debugging**.
16. Close Visual Studio.

### Demonstration:  Improving the Responsiveness and Performance of the Application Lab

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open the **Grades.sln** solution from the **[Repository Root]\Allfiles\Mod10\Labfiles\Solution\Exercise 2** folder.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In Solution Explorer, right-click **Solution ‘Grades’**, and then click **Properties**.
3. On the **Startup Project** page, click **Multiple startup projects**. Set **Grades.Web** and **Grades.WPF** to **Start**, and then click **OK**.
4. Build the solution.
5. In the **Grades.WPF** project, Expand **MainWindow.xaml** and then open **MainWindow.xaml.cs** and then locate the **Refresh** method.
6. Explain to the students that during Exercise 1, they will convert the **Refresh** method to an **async** method.
7. In the **Refresh** method, in the **case "Teacher"** block, locate the call to **utils.GetTeacher**.
8. Explain to the students that they will convert the **GetTeacher** method into an awaitable method, so that it waits for the method to return without blocking the UI thread.
9. On the statement that calls **utils.GetTeacher**, right-click **GetTeacher**, and then click **Go To Definition**.
10. Explain that to make the **GetTeacher** method awaitable, the students must:
    - Make **GetTeacher** an **async** method.
    - Change the return type of the method from **Teacher** to **Task\<Teacher\>**.
    - Use a task to run the LINQ query.
    - Use an **await** operator to get the query result.
11. In the **Views** folder, Expand **StudentsPage.xaml** and then open **StudentsPage.xaml.cs**, and then locate the **Refresh** method.
12. In the **Refresh** method, locate the call to **utils.GetStudentsByTeacher**.
13. Explain to the students that they will convert the **GetStudentsByTeacher** method into an asynchronous method that uses a callback method to update the UI.
14. On the statement that calls **utils.GetStudentsByTeacher**, right-click **GetStudentsByTeacher**, and then click **Go To Definition**.
15. Explain to the students that they will use a task to run the LINQ query, use an **await** operator to get the query result, and then pass the results as an argument to the callback method.
16. In **StudentsPage.xaml.cs**, locate the **OnGetStudentsByTeacherComplete** method.
17. Explain to the students that this is the callback method, and show how it uses a **Dispatcher** object to update the UI.
18. In the **Controls** folder, open the **BusyIndicator.xaml** file.
19. Explain to the students that during Exercise 2, they will create this user control.
20. Draw attention to the **ProgressBar** control, which displays a simple animation whenever the control is visible, and to the XAML code that creates the control.
21. Open the **MainWindow.xaml** file, locate the **BusyIndicator** element, and then point out that the visibility of the control is initially set to **Collapsed**.
22. In **MainWindow.xaml.cs**, locate the **StartBusy** and **EndBusy** event handler methods. Point out that the **StartBusy** method makes the **BusyIndicator** control visible and the **EndBusy** method hides the **BusyIndicator** control.
23. Open the **StudentsPage.xaml.cs** file, and then point out the following:
    - The **StartBusy** and **EndBusy** events.
    - The **StartBusyEvent** method that raises the **StartBusy** event.
    - The **EndBusyEvent** method that raises the **EndBusy** event.
24. Locate the **Refresh** method.
25. Point out that the method raises the **StartBusy** event before the call to **GetStudentsByTeacher**.
26. Point out that the method raises the **EndBusy** event after the call to **GetStudentsByTeacher**.
27. In the **MainWindow.xaml** file, locate the **StudentsPage** element.
28. Explain that the **StartBusy** and **EndBusy** events are wired up to the **StartBusy** and **EndBusy** event handler methods respectively.
29. Run the application, and then log on as **vallee** with the password **password99**.
30. Point out that the application displays the **BusyIndicator** control while waiting for the list of students to load.
31. Click **Log off**, and then close the application.
32. Close **Visual Studio** and in Microsoft Visual Studio dialog box, click **Yes**.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
