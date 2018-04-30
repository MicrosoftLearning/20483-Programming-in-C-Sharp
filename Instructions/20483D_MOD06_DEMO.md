# Module 6: Reading and Writing Local Data

# Lesson 1:  Reading and Writing Files

### Demonstration: Manipulating Files, Directories, and Paths
### Lesson 3 demo steps were not imported from docx ###
#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod06\Democode\Starter\FourthCoffee.LogProcessor**, and then open the **FourthCoffee.LogProcessor.sln** file.

#### Demonstration Steps

1.  In Visual Studio, on the **View** menu, click **Task List**.
2.  In the **Task List** window, in the **Categories** list, click **Comments**.
3.  Double-click the **TODO: 01: Ensure log file directory exists.** task.
4.  In the code editor, click in the blank line below the comment, and then type
    the following code:
    ```cs
    if (!Directory.Exists(logDirectoryRoot))
       throw new DirectoryNotFoundException();
    ```
5.	In the **Task List** window, double-click the **TODO: 02: Get all log file paths.** task.
6.	In the code editor, click in the blank line below the comment, and then type the following code:
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
    var logName = 
       Path.GetFileNameWithoutExtension(logPath);
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
17.	On the **Build** menu, click **Build Solution**.
18.	On the **Debug** menu, click **Start Without Debugging**.
19.	In the **Command Prompt** window, when prompted to press any key to continue, press Enter.
20.	Open File Explorer and browse to the **Allfiles\Mod06\Democode\Data\Logs** folder.
21.	Double-click **CombinedLog.txt**, verify that the file contains a heading, and then verify the contents of each log file.
22.	Close Notepad, close File Explorer, and then close Visual Studio.


# Lesson 2:  Serializing and Deserializing Data

### Demonstration: Serializing to XML

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod06\Democode\Starter\FourthCoffee.ExceptionLogger**, and then open the **FourthCoffee.ExceptionLogger.sln** file.
#### Demonstration Steps

1.	In Visual Studio, on the **View** menu, click **Task List**.
2.	In the **Task List** window, in the **Categories** list, click **Comments**.
3.	Double-click the **TODO: 01: Decorate the type with the Serializable attribute.** task.
4.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    [Serializable]
    ```
5.	In the **Task List** window, double-click the **TODO: 02: Implement the ISerializable interface.** task.
6.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    : ISerializable
    ```
7.	Right-click the text **ISerializable**, point to **Implement Interface**, and then click **Implement Interface**.
8.	In the **GetObjectData** method, replace the existing code to throw a new **NotImplementedException** object with the following code:
    ```cs
    info.AddValue("Title", this.Title);
    info.AddValue("Details", this.Details);
    ```
9.	In the **Task List** window, double-click the **TODO: 03: Add a deserialization constructor.** task.
10.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    public ExceptionEntry(
       SerializationInfo info, 
       StreamingContext context)
       {
          this.Title = info.GetString("Title");
          this.Details = info.GetString("Details");
       }
    ```
11.	In the **Task List** window, double-click the **TODO: 04: Create a SoapFormatter object and serialize the entry object.** task.
12.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var formatter = new SoapFormatter();
    formatter.Serialize(stream, entry);
    ```
13.	In the **Task List** window, double-click the **TODO: 05: Create a SoapFormatter object and deserialize the stream to the entry object.** task.
14.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var formatter = new SoapFormatter();
    entry = formatter.Deserialize(stream) as ExceptionEntry;
    ```
15.	On the **Build** menu, click **Build Solution**.
16.	On the **Debug** menu, click **Start Without Debugging**.
17.	In the **Exception Logger** window, create a new exception entry by using the following information, and then click **Save**:
    -	Title: Critical database error
    -	Details: Could not find database server
18.	In the **Save Successful** message box, click **OK**. The exception entry has now been serialized.
19.	Close the Exception Logger application.
20.	Open File Explorer and browse to the **Allfiles\Mod06\Democode\Data\Exceptions** folder.
21.	In the **Allfiles\Mod06\Democode\Data\Exceptions** folder, double-click the Exception_\<date and time\>.txt file.  
22.	In Notepad, find the **Title** and **Details** XML elements.
23.	Switch to Visual Studio, and on the **Debug** menu, click **Start Without Debugging**.
24.	In the **Exception Logger** window, in the File list, click **Allfiles\Mod06\Democode\Data\Exceptions\Exception_\<date and time\>.txt**, and then click Load. The ExceptionEntry object has now been deserialized.
25.	Close the application, close Visual Studio, and then close File Explorer.


# Lesson 3:  Performing I/O by Using Streams

### Demonstration: Generating the Grades Report Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
