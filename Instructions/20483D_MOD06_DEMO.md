# Module 6: Reading and Writing Local Data

# Lesson 1:  Reading and Writing Files

### Demonstration: Manipulating Files, Directories, and Paths

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
3.  In the **Open Project** dialog box, browse to
    **E:\\Mod06\\Democode\\Starter\\FourthCoffee.LogProcessor** folder, click
    **FourthCoffee.LogProcessor.sln**, and then click **Open**.
4.  In Visual Studio, on the **View** menu, click **Task List**.
5.  In the **Task List** window, in the **Categories** list, click **Comments**.
6.  Double-click the **TODO: 01: Ensure log file directory exists.** task.
7.  In the code editor, click in the blank line below the comment, and then type
    the following code:
    ```cs
    if (!Directory.Exists(logDirectoryRoot))
       throw new DirectoryNotFoundException();
    ```
16.	In the **Task List** window, double-click the **TODO: 02: Get all log file paths.** task.
17.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    return Directory.GetFiles(this._logDirectoryPath,   "*.txt");       
    ```
18.	In the **Task List** window, double-click the **TODO: 03: Check for existing combined log file and delete if it already exists.** task.
19.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    if (File.Exists(combinedLogPath))
       File.Delete(combinedLogPath);
    ```
20.	In the **Task List** window, double-click the **TODO: 04: Write the heading to the combined log file.** task.
21.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    File.AppendAllLines(combinedLogPath, heading);
    ```
22.	In the **Task List** window, double-click the **TODO: 05: Get the log file name without the file extension.** task.
23.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var logName = 
       Path.GetFileNameWithoutExtension(logPath);
    ```
24.	In the **Task List** window, double-click the **TODO: Task 06: Read the contents of the existing log file.** task.
25.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var logText = File.ReadAllText(logPath);
    ```
26.	In the **Task List** window, double-click the **TODO: Task 07: Write the log file contents to the combined log file.** task.
27.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    File.AppendAllLines(combinedLogPath, logContent);
    ```
28.	On the **Build** menu, click **Build Solution**.
29.	On the **Debug** menu, click **Start Without Debugging**.
30.	In the **Command Prompt** window, when prompted to press any key to continue, press Enter.
31.	Open File Explorer and browse to the **E:\Mod06\Democode\Data\Logs** folder.
32.	Double-click **CombinedLog.txt**, verify that the file contains a heading, and then verify the contents of each log file.
33.	Close Notepad, close File Explorer, and then close Visual Studio.


# Lesson 2:  Serializing and Deserializing Data

### Demonstration: Serializing to XML

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.	Click **Visual Studio 2017**.
2.	In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3.	In the **Open Project** dialog box, browse to **E:\Mod06\Democode\Starter\FourthCoffee.ExceptionLogger**, click **FourthCoffee.ExceptionLogger.sln**, and then click **Open**.
4.	In Visual Studio, on the **View** menu, click **Task List**.
5.	In the **Task List** window, in the **Categories** list, click **Comments**.
6.	Double-click the **TODO: 01: Decorate the type with the Serializable attribute.** task.
7.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    [Serializable]
    ```
8.	In the **Task List** window, double-click the **TODO: 02: Implement the ISerializable interface.** task.
9.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    : ISerializable
    ```
10.	Right-click the text **ISerializable**, point to **Implement Interface**, and then click **Implement Interface**.
11.	In the **GetObjectData** method, replace the existing code to throw a new **NotImplementedException** object with the following code:
    ```cs
    info.AddValue("Title", this.Title);
    info.AddValue("Details", this.Details);
    ```
12.	In the **Task List** window, double-click the **TODO: 03: Add a deserialization constructor.** task.
13.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    public ExceptionEntry(
       SerializationInfo info, 
       StreamingContext context)
       {
          this.Title = info.GetString("Title");
          this.Details = info.GetString("Details");
       }
    ```
14.	In the **Task List** window, double-click the **TODO: 04: Create a SoapFormatter object and serialize the entry object.** task.
15.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var formatter = new SoapFormatter();
    formatter.Serialize(stream, entry);
    ```
16.	In the **Task List** window, double-click the **TODO: 05: Create a SoapFormatter object and deserialize the stream to the entry object.** task.
17.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var formatter = new SoapFormatter();
    entry = formatter.Deserialize(stream) as ExceptionEntry;
    ```
18.	On the **Build** menu, click **Build Solution**.
19.	On the **Debug** menu, click **Start Without Debugging**.
20.	In the **Exception Logger** window, create a new exception entry by using the following information, and then click **Save**:
    -	Title: Critical database error
    -	Details: Could not find database server
21.	In the **Save Successful** message box, click **OK**. The exception entry has now been serialized.
22.	Close the Exception Logger application.
23.	Open File Explorer and browse to the **E:\Mod06\Democode\Data\Exceptions** folder.
24.	In the **E:\Mod06\Democode\Data\Exceptions** folder, double-click the Exception_\<date and time\>.txt file.  
25.	In Notepad, find the **Title** and **Details** XML elements.
26.	Switch to Visual Studio, and on the **Debug** menu, click **Start Without Debugging**.
27.	In the **Exception Logger** window, in the File list, click **E:\Mod06\Democode\Data\Exceptions\Exception_\<date and time\>.txt**, and then click Load. The ExceptionEntry object has now been deserialized.
28.	Close the application, close Visual Studio, and then close File Explorer.


# Lesson 3:  Performing I/O by Using Streams

### Demonstration: Generating the Grades Report Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.