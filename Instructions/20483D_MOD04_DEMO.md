# Module 4: Creating Classes and Implementing Type-Safe Collections

# Lesson 1: Creating Classes

### Demonstration: Comparing Reference Types and Value Types

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Open **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **New**, and then click
    **Project**.
3.  In the **New Project** dialog box, in the **Templates** list, click **Visual
    C\#**, and then in the **Project Type** list, click **Console Application**.
4.  In the **Name** text box, type **ValuesAndReferences**
5.  In the **Location** text box, set the location to **Allfiles\\Mod04\\Democode**,
    and then click **OK**.
6. Within the **ValuesAndReferences** namespace, add the following code:
    ```cs
    struct MyStruct
    {
       public int Contents;
    }
    ```
7.	Immediately below the code you just added, add the following code:
    ```cs
    class MyClass
    {
       public int Contents = 0;
    }
    ```
8.	Within the **Program** class, within the **Main** method, add the following code:
    ```cs
    MyStruct struct1 = new MyStruct();
    MyStruct struct2 = struct1;
    struct2.Contents = 100;

    MyClass class1 = new MyClass();
    MyClass class2 = class1;
    class2.Contents = 100;

    Console.WriteLine("Value types: {0}, {1}", struct1.Contents, struct2.Contents);
    Console.WriteLine("Reference types: {0}, {1}", class1.Contents, class2.Contents);
    ```
9.  On the **Debug** menu, click **Start without Debugging**. The console window
    shows the following output:
    ```cs
    Value types: 0, 100
    Reference types: 100, 100
    ```
10.	Press Enter to close the console window.
11.	Close Visual Studio 2017.



# Lesson 3: Implementing Type-Safe Collections

### Demonstration: Adding Data Validation and Type-Safety to the Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
