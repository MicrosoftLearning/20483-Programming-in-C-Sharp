
# Module 10:   Improving Application Performance and Responsiveness

# Lesson 2:  Performing Operations Asynchronously

### Demonstration: Using the Tak Parallel Library to Invoke APM Operations

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod10\Democode\Starter**, and then open the **APMTasks.sln** file.

#### Demonstration Steps

1.  On the **Build** menu, click **Build Solution**.
2.  On the **Debug** menu, click **Start Without Debugging**.
3.  In the text box, type **http://www.fourthcoffee.com**, and then click
    **Check URL**.
4.  Notice that the label displays the message **The URL returned the following
    status code: OK**.
5.  Close the **MainWindow** window.
6.  In Solution Explorer, expand **MainWindow.xaml**, and then double-click
    **MainWindow.xaml.cs**.
7. Review the code in the **MainWindow** class:
    -  Notice that the **btnCheckUrl_Click** method creates an
        **HttpWebRequest** object and then calls the **BeginGetResponse**
        method.
    -  Notice that the **BeginGetResponse** method specifies the
        **ResponseCallback** method as an asynchronous callback method.
    -  Notice that the **ResponseCallback** method calls the
        **HttpWebResponse.EndGetResponse** method to get the result of the web
        request and then updates the UI.
8. Delete the **ResponseCallback** method.
9. Modify the **btnCheckUrl_Click** method declaration to include the **async**
    modifier as follows:
    ```cs
    private async void btnCheckUrl_Click(object sender, RoutedEventArgs e)
    ```
10.	In the **btnCheckUrl_Click** method, delete the following line of code: 
    ```cs
    request.BeginGetResponse(new AsyncCallback(ResponseCallback), request);
    ```
11.	Add the following code in place of the line you just deleted:
    ```cs
    HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync    (request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
    lblResult.Content = String.Format("The URL returned the following status code: {0}  ", response.StatusCode);
    ```
12.  Notice that the **MainWindow** class is now far more simple and concise.
13.  On the **Debug** menu, click **Start Without Debugging**.
14.  In the text box, type **http://www.fourthcoffee.com**, and then click
    **Check URL**.
15.  Notice that the label displays the message **The URL returned the following
    status code: OK**.
16.  Notice that the application works in exactly the same way as before.
17.  Close the **MainWindow** window, and then close Visual Studio.


# Lesson 3:  Synchronizing Concurrent Access to Data

### Demonstration:  Using Lock Statements

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod10\Democode\Starter**, and then open the **Locking.sln** file.


#### Demonstration Steps

1.  In Solution Explorer, double-click **Coffee.cs**.
2.  Review the **Coffee** class, paying particular attention to the
    **MakeCoffees** method.
3.  Notice how the **MakeCoffees** method uses a **lock** statement to prevent
    concurrent access to the critical code.
4.  In Solution Explorer, double-click **Program.cs**.
5.  In the **Program** class, review the **Main** method.
6.  Notice how the **Main** method uses a **Parallel.For** loop to
    simultaneously place 100 orders for between one and 100 coffees.
7. On the **Build** menu, click **Build Solution**.
8. On the **Debug** menu, click **Start Debugging**.
9. Review the console window output, and notice that the application keeps
    track of stock levels effectively.
10. Press Enter to close the console window.
11. In the **Coffee** class, comment out the following line of code:
    ```cs
    lock (coffeeLock)
    ```
12.  On the **Debug** menu, click **Start Debugging**.
13.  Notice that the application throws an exception with the message **Stock
    cannot be negative!**
14.  Explain that this is due to concurrent access to the critical code section
    in the **MakeCoffees** method.
15.  On the **Debug** menu, click **Stop Debugging**.
16.  Close Visual Studio.




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.