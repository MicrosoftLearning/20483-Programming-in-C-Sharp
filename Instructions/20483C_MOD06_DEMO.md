# Module 6: Reading and Writing Local Data

# Lesson 1:  Reading and Writing Files

### Demonstration: Manipulating Files, Directories, and Paths
### !!!__Lesson 3 demo steps were not imported from docx__!!! ###
#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. Navigate to **Allfiles\Mod06\Democode\Starter\FourthCoffee.LogProcessor**, and then open the **FourthCoffee.LogProcessor.sln** file.
3. In Visual Studio, on the **View** menu, click **Task List**.
4. In the **Task List** window, double-click the **TODO: 01: Ensure log file directory exists.** task.
5. In the code editor, click in the blank line below the comment, and then type
    the following code:
    ```cs
    if (!Directory.Exists(logDirectoryRoot))
       throw new DirectoryNotFoundException();
    ```
6. In the **Task List** window, double-click the **TODO: 02: Get all log file paths.** task.
7. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    return Directory.GetFiles(this._logDirectoryPath,   "*.txt");       
    ```
7.	In the **Task List** window, double-click the **TODO: 03: Check for existing combined log file and delete if it already exists.** task.
8.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    if (File.Exists(combinedLogPath))
       File.Delete(combinedLogPath);
    ```
9.	In the **Task List** window, double-click the **TODO: 04: Write the heading to the combined log file.** task.
10.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    File.AppendAllLines(combinedLogPath, heading);
    ```
11.	In the **Task List** window, double-click the **TODO: 05: Get the log file name without the file extension.** task.
12.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var logName = Path.GetFileNameWithoutExtension(logPath);
    ```
13.	In the **Task List** window, double-click the **TODO: Task 06: Read the contents of the existing log file.** task.
14.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var logText = File.ReadAllText(logPath);
    ```
15.	In the **Task List** window, double-click the **TODO: Task 07: Write the log file contents to the combined log file.** task.
16.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    File.AppendAllLines(combinedLogPath, logContent);
    ```
17. In the **Task List** window, double-click the **//TODO 09: Replace [Repository Root] with your folder path.** task.
18. Replace **[Repository Root]** with your folder path. 
19.	On the **Build** menu, click **Build Solution**.
20.	On the **Debug** menu, click **Start Without Debugging**.
21.	In the **Command Prompt** window, when prompted to press any key to continue, press Enter.
22.	Open File Explorer and browse to the **Allfiles\Mod06\Democode\Data\Logs** folder.
23.	Double-click **CombinedLog.txt**, verify that the file contains a heading, and then verify the contents of each log file.
24.	Close Notepad, close File Explorer, and then close Visual Studio.


# Lesson 2:  Serializing and Deserializing Data

### Demonstration: Serializing Objects as JSON using JSON.Net

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1. Navigate to **Allfiles\Mod06\Democode\Starter\FourthCoffee.ExceptionLogger**, and then open the **FourthCoffee.ExceptionLogger.sln** file.
2.  Right click on **FourthCoffee.ExceptionLogger** project, and select **Manage NuGet Packages**.
    - In **NeGet: FourthCoffee.ExceptionLogger**, click on **Browse**.
    - Click on Search box and type **Newtonsoft.Json**
    - Select the result for **Newtonsoft.Json** and click on left side of the window **Install**.
    -  Close the window.
3.	In Visual Studio, on the **View** menu, click **Task List**.
4.	In the **Task List** window, double-click the **TODO: 01:  Add Using for Newtonsoft.Json.** task.
5.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    using Newtonsoft.Json;
    ```
6.	In the **Task List** window, double-click the **TODO: 02: Convert object to JSON string.** task.
7.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var jsonAsString = JsonConvert.SerializeObject(entry);
    File.WriteAllText(path,jsonAsString);
    ```
8.	In the **Task List** window, double-click the **TODO: 03: Convert JSON string to an object.** task.
9.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    entry = JsonConvert.DeserializeObject<ExceptionEntry>(jsonAsStriong);
    ```
10. Expand  **FourthCoffee.ExceptionLogger** project and double-click on **App.config** file.
11. Replace **[Repository Root]** with your folder path.
12.	On the **Build** menu, click **Build Solution**.
13.	On the **Debug** menu, click **Start Without Debugging**.
14.	In the **Exception Logger** window, create a new exception entry by using the following information, and then click **Save**:
    -	Title: Critical database error
    -	Details: Could not find database server
15.	In the **Save Successful** message box, click **OK**. The exception entry has now been serialized.
16.	Close the Exception Logger application.
17.	Open File Explorer and browse to the **[Repository Root]\Allfiles\Mod06\Democode\Data\Exceptions** folder.
18.	In the **[Repository Root]\Allfiles\Mod06\Democode\Data\Exceptions** folder, double-click the Exception_\<date and time\>.json file.  
19.	In Notepad, find the **Title** and **Details** JSON elements.
20.	Switch to Visual Studio, and on the **Debug** menu, click **Start Without Debugging**.
21.	In the **Exception Logger** window, in the File list, click **[Repository Root]\Allfiles\Mod06\Democode\Data\Exceptions\Exception_\<date and time\>.json**, and then click Load. The ExceptionEntry object has now been deserialized.
22.	Close the application, close Visual Studio, and then close File Explorer.


# Lesson 3:  Performing I/O by Using Streams

### Demonstration: Generating the Grades Report Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1. Open the **GradesPrototype.sln** solution from the
    **[Repository Root]\\Mod06\\Labfiles\\Solution\\Exercise 2** folder.
2. In the **Views** folder, open **StudentProfile.xaml** and point out that the
    user interface has been updated to include a **Save Report** and **Load Report** buttons.
3. In the **Views** folder, open **StudentProfile.xaml.cs**, and locate the
    **SaveReport_Click** method.
4. Explain to students that during the lab they will add the code in this
    method to prompt the user for a filename to save the report as, and to call
    methods to generate, preview, and save the report.
5. In the **Views** folder, open **StudentProfile.xaml.cs**, and locate the
    **LoadReport_Click** method.
6. Explain to students that during the lab they will add the code in this
    method to prompt the user for a filename to load the report, and to call
    methods to display the report to the user.
7. Explain to students that during the lab they will add the code that generates a JSON document and load it from the Disk.
8. Run the application, and log on as **vallee** with a password of
    **password99**.
9. View **Kevin Liu’s** report card and then click **Save Report** to generate
    the JSON document.
10. Specify to save the file in the Documents folder by using the default name.
11. Review the JSON data displayed in the message box, and then confirm that you
    want to save the file.
12. Go to the file and change some properties inside the report.
13. View **Kevin Liu’s** report card and then click **Load Report** to load the JSON document and display it in the **Report Card** view.
14. Close the application, and then close Visual Studio.


©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
