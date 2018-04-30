
# Module 7: Accessing a Database

# Lesson 1:  Creating and Using Entity Data Models
###this document is missing the first demo of the module: "Creating an Entity Data Model". we need to port it from the docx file (older version of it)###
### Demonstration: Reading and Modifying Data in an EDM

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod07\Democode\Demo2\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.


#### Demonstration Steps

1.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
2.  Review the definition of the **DBContext** variable.
3.  Review the code in the **PrintEmployeesList** method that uses the
    **DBContext** variable to access the data in the EDM.
4.  Review the code in the **Main** method that uses the **First** extension
    method to retrieve an employee and then modifies that employee’s
    **LastName** property.
5.  On the **Debug** menu, click **Start Without Debugging**.
6.  Verify that the employees list is displayed, and then press Enter.
7. Verify that the employee named “Diane Prescott” is now named “Diane
    Forsyth,” and then press Enter.
8. Press Enter to close the application.


# Lesson 2:  Querying Data by Using LINQ

### Demonstration: Querying Data

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles
2. Navigate to **Allfiles\Mod07\Democode\Demo3\FourthCoffee.Employees**, and then open the **FourthCoffee.Employees.sln** file.



#### Demonstration Steps

1.  In Solution Explorer, expand **FourthCoffee.Employees**, and then
    double-click **Program.cs**.
2.  Review the LINQ code in each of the methods.
3.  On the **Build** menu, click **Build Solution**.
4.  On the **Debug** menu, click **Start Without Debugging**.
5.  In the console window, review the output of the **QueryingData** method, and
    then press Enter.
6.  Repeat step 12 for each of the following methods:
    -  **FilteringDataByRow**
    -  **FilteringDataByColumn**
7. Press Enter to close the application.
8. In Visual Studio, on the **File** menu, click **Close Solution**.


### Demonstration: Retrieving and Modifying Grade Data Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles






©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
