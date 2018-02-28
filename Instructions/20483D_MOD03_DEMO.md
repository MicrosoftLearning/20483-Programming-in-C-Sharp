# Module 3:  Developing the Code for a Graphical Application

# Lesson 1:  Implementing Structs and Enums

### Demonstration: Creating and Using a Struct

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles


#### Demonstration Steps

1.  Open **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **New**, and then click
    **Project**.
3.  In the **New Project** dialog box, in the **Templates** list, click **Visual
    C\#**, and then in the **Project Type** list, click **Console Application**.
4.  In the **Name** box, type **UsingStructs**
5.  In the **Location** box, set the location to **Allfiles\\Mod03\\Democode**, and
    then click **OK**.
6.  In the **UsingStructs** namespace, add the following code:
    ```cs
    struct Coffee
    {
       public string Name { get; set; }
       public string Bean { get; set; }
       public string CountryOfOrigin { get; set; }
       public int Strength { get; set; } 
    }
    ```
7.	In the **Program** class, in the **Main** method, add the following code:
    ```cs
    Coffee coffee1 = new Coffee();
    coffee1.Name = "Fourth Coffee Quencher";
    coffee1.CountryOfOrigin = "Indonesia";
    coffee1.Strength = 3;

    Console.WriteLine("Name: {0}", coffee1.Name);
    Console.WriteLine("Country of Origin: {0}",coffee1.CountryOfOrigin);
    Console.WriteLine("Strength: {0}", coffee1.Strength);
    ```
8.  Notice that you are able to use the **Coffee** struct in the same way that
    you would use a standard .NET Framework type.
9.  On the **Build** menu, click **Build Solution**.
10.  On the **Debug** menu, click **Start Without Debugging**.
11.  Notice that the **Coffee** struct works just like a standard .NET Framework
    type at runtime.
12.  Press Enter to close the console window.
13.  Close Visual Studio.



# Lesson 3:  Handling Events

### Demonstration: Writing Code for the Grades Prototype Application Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles





©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
