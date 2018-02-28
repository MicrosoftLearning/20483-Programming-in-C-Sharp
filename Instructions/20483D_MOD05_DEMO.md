
# Module 5: Creating a Class Hierarchy by Using Inheritance

# Lesson 1: Creating Class Hierarchies

### Demonstration: Calling Base Class Constructors

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod05\Democode**, and then open the **BaseConstructors.sln** file.

#### Demonstration Steps


1.  In Solution Explorer, double-click **Beverage.cs** and review the contents
    of the class.
2.  Note that the **Beverage** class contains a default constructor and an
    alternative constructor.
3.  In Solution Explorer, double-click **Coffee.cs** and review the contents of
    the class.
4.  Note that the **Coffee** class inherits from the **Beverage** class.
5.  Note that the **Coffee** class contains a default constructor and an
    alternative constructor.
6. Note that the alternative constructor explicitly calls the alternative
constructor in the base class.
7.  In Solution Explorer, double-click **Program.cs** and review the contents of
    the class.
8.  Note that the **Program** class creates two instances of the **Coffee**
    type: one by using the default constructor, and one by using the alternative
    constructor.
9.  On the **Build** menu, click **Rebuild Solution**.
10.  Press F11 twice so that the first line of executable code in the **Program**
    class is highlighted.
11.  Press F11. Note that the debugger steps into the default constructor for the
    **Coffee** class.
12.  Press F11. Note that the debugger steps into the default constructor for the
    **Beverage** class.
13.  Point out that derived class constructors implicitly call the default base
    class constructor unless you specify an alternative base class constructor.
14.  Press F11 six times, until the debugger returns to the default constructor
    for the **Coffee** class.
15.  Point out that the base class constructor logic is executed before the
    derived class constructor logic.
16.  Press F11 six times, until the debugger returns to the **Program** class.
17.  Press F11. The second executable line of code in the **Program** class
    should be highlighted.
18.  Press F11. Note that the debugger steps into the alternative constructor for
    the **Coffee** class.
19.  Press F11. Note that the debugger steps into the alternative constructor for
    the **Beverage** class.
20.  Hover over the **Beverage** constructor parameters, and point out that the
    **Coffee** constructor has passed argument values to this constructor.
21.  Press F11 six times, until the debugger returns to the alternative
    constructor for the **Coffee** class.
22.  Press F11 six times, until the debugger returns to the **Program** class.
23.	Press F5 to run the remainder of the application. 
24.	When the console window appears, point out that it makes no difference to consumers of the class whether variables were set by the derived class constructor or the base class constructor. 
25.	Press Enter to close the console window. 
26.	Close Visual Studio. 


# Lesson 2: Extending .NET Framework Classes

### Demonstration: Refactoring Common Functionality into the User Class Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles





©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.