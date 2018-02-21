# Module 2: Creating Methods, Handling Exceptions, and Monitoring Applications

# Lesson 1: Creating and Invoking Methods

### Demonstration: Creating, Invoking, and Debugging Methods

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles


#### Demonstration Steps

1.	Start the MSL-TMG1 virtual machine if it is not already running.
2.	Start the 20483B-SEA-DEV11 virtual machine.
3.	Log on to Windows 10 as **Student** with the password **Pa$$w0rd**. If necessary, click **Switch User** to display the list of users.
4.	Switch to the Windows 10 **Start** window.
5.	Click **Visual Studio 2017**.
6.	In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
7.	In the **Open Project** dialog box, browse to the **E:\Mod02\Democode\Starter\FourthCoffee.MethodTestHarness** folder, click **FourthCoffee.MethodTestHarness.sln**, and then click Open.
8.	In Visual Studio, on the **View** menu, click **Task List**.
9.	In the **Task List** window, in the **Categories** list, click **Comments**.
10.	Double-click the **TODO: 01: Define the Initialize method.** task.
11.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    bool Initialize()
    {
    var path = GetApplicationPath();

    return
        !string.IsNullOrEmpty(path);
    } 
    ```
12.	In the **Task List** window, double-click the **TODO: 02: Invoke the Initialize method.** task.
13.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var isInitialized= Initialize();
    ```
14.	Right-click the call to the **Initialize** method, point to **Breakpoint**, and then click **Insert Breakpoint**.
15.	On the **Build** menu, click **Build Solution**.
16.	On the **Debug** menu, click Start **Debugging**.
17.	Press F11 to step into the **Initialize** method.
18.	Press F10 to step to the **GetApplicationPath** method call.
19.	Press F10 to step over the **GetApplicationPath** method call.
20.	Press Shift+F11 to step out of the **Initialize** method.
21.	Press F10 to step over the **Initialize** method call.
22.	Hover over the **isInitialized** variable, 
and verify that the value returned is **true**.
23.	On the **Debug** menu, click **Stop Debugging**.
24.	On the **File** menu, click **Close Solution**.


# Lesson 4: Monitoring Applications

### Demonstration: Extending the Class Enrollment Application Functionlity Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles


©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
