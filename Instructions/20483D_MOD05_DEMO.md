
# Module 5: Creating a Class Hierarchy by Using Inheritance

# Lesson 1: Creating Class Hierarchies

### Demonstration: Calling Base Class Constructors

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps


1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
3.  In the **Open Project** dialog box, browse to **E:\\Mod05\\Democode**, click
    **BaseConstructors.sln**, and then click **Open**.
4.  In Solution Explorer, double-click **Beverage.cs** and review the contents
    of the class.
5.  Note that the **Beverage** class contains a default constructor and an
    alternative constructor.
6.  In Solution Explorer, double-click **Coffee.cs** and review the contents of
    the class.
7.  Note that the **Coffee** class inherits from the **Beverage** class.
8.  Note that the **Coffee** class contains a default constructor and an
    alternative constructor.
9. Note that the alternative constructor explicitly calls the alternative
constructor in the base class.
10.  In Solution Explorer, double-click **Program.cs** and review the contents of
    the class.
11.  Note that the **Program** class creates two instances of the **Coffee**
    type: one by using the default constructor, and one by using the alternative
    constructor.
12.  On the **Build** menu, click **Rebuild Solution**.
13.  Press F11 twice so that the first line of executable code in the **Program**
    class is highlighted.
14.  Press F11. Note that the debugger steps into the default constructor for the
    **Coffee** class.
15.  Press F11. Note that the debugger steps into the default constructor for the
    **Beverage** class.
16.  Point out that derived class constructors implicitly call the default base
    class constructor unless you specify an alternative base class constructor.
17.  Press F11 six times, until the debugger returns to the default constructor
    for the **Coffee** class.
18.  Point out that the base class constructor logic is executed before the
    derived class constructor logic.
19.  Press F11 six times, until the debugger returns to the **Program** class.
20.  Press F11. The second executable line of code in the **Program** class
    should be highlighted.
21.  Press F11. Note that the debugger steps into the alternative constructor for
    the **Coffee** class.
22.  Press F11. Note that the debugger steps into the alternative constructor for
    the **Beverage** class.
23.  Hover over the **Beverage** constructor parameters, and point out that the
    **Coffee** constructor has passed argument values to this constructor.
24.  Press F11 six times, until the debugger returns to the alternative
    constructor for the **Coffee** class.
25.  Press F11 six times, until the debugger returns to the **Program** class.
26.	Press F5 to run the remainder of the application. 
27.	When the console window appears, point out that it makes no difference to consumers of the class whether variables were set by the derived class constructor or the base class constructor. 
28.	Press Enter to close the console window. 
29.	Close Visual Studio. 


# Lesson 2: Extending .NET Framework Classes

### Demonstration: Refactoring Common Functionality into the User Class Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles





©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.