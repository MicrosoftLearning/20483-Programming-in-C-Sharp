
# Module 7: Accessing a Database

# Lesson 1:  Creating and Using Entity Data Models

### Demonstration: Reading and Modifying Data in an EDM

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
3.  In the **Open Project** dialog box, browse to the
    **E:\\Mod07\\Democode\\Demo2\\FourthCoffee.Employees** folder, click
    **FourthCoffee.Employees.sln**, and then click **Open**.
4.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
5.  Review the definition of the **DBContext** variable.
6.  Review the code in the **PrintEmployeesList** method that uses the
    **DBContext** variable to access the data in the EDM.
7.  Review the code in the **Main** method that uses the **First** extension
    method to retrieve an employee and then modifies that employee’s
    **LastName** property.
8.  On the **Debug** menu, click **Start Without Debugging**.
9.  Verify that the employees list is displayed, and then press Enter.
10. Verify that the employee named “Diane Prescott” is now named “Diane
    Forsyth,” and then press Enter.
11. Press Enter to close the application.


# Lesson 2:  Querying Data by Using LINQ

### Demonstration: Querying Data

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
3.  In the **Open Project** dialog box, browse to the
    **E:\\Mod07\\Democode\\Demo3\\FourthCoffee.Employees** folder, click
    **FourthCoffee.Employees.sln**, and then click **Open**.
4.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
5.  Review the LINQ code in each of the methods.
6.  On the **Build** menu, click **Build Solution**.
7.  On the **Debug** menu, click **Start Without Debugging**.
8.  In the console window, review the output of the **QueryingData** method, and
    then press Enter.
9.  Repeat step 12 for each of the following methods:
    -  **FilteringDataByRow**
    -  **FilteringDataByColumn**
10. Press Enter to close the application.
11. In Visual Studio, on the **File** menu, click **Close Solution**.


### Demonstration: Retrieving and Modifying Grade Data Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles






©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.