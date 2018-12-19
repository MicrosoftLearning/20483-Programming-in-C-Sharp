# Module 12: Creating Reusable Types and Assemblies

## Lab: Specifying the Data to Include in the Grades Report

### Scenario

You decide to update the **Grades** application to use custom attributes to define the fields and properties that should be included in a grade report and to format them appropriately. This will enable further reusability of the Microsoft Word reporting functionality.
You will host this code in the GAC to ensure that it is available to other applications that require its services.

#### Objectives

After completing this lab, you will be able to:

- Define custom attributes.
- Use reflection to examine metadata at run time.
- Sign an assembly and deploy it to the GAC.

### Lab Setup

Estimated Time: **75 minutes**

### Exercise 1: Creating and Applying the IncludeInReport attribute

#### Scenario

In this exercise, you will create the **IncludeInReport** attribute to specify the fields and the format of each field that is included in the grades report.

First, you will write code for the **IncludeInReportAttribute** class and define the members that are contained in it.  
Next, you will apply the attribute to the appropriate properties in the **LocalGrade** class in the **Data.cs** file.  
Finally, you will build the application and then use the MSIL Disassembler utility (ILDASM) to examine the metadata that the attribute generates.

#### Task 1: Write the code for the IncludeInReportAttribute class

1. Start File Explorer, navigate to the **[Repository Root]\\Allfiles\\Mod12\\Labfiles\\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close File Explorer.
3. Start Visual Studio, from the **[Repository Root]\\Allfiles\\Mod12\\Labfiles\\Starter\\Exercise 1** folder, open the **Grades.sln** solution.
4. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
5. In the **Grades.Utilities** project, in the **IncludeInReport.cs** class, add code to specify that the **IncludeInReportAttribute** class is an attribute class.
6. Add code to specify that the possible targets to which the **IncludeInReport** attribute can be applied are fields and properties and that the attribute can be applied only once to each entity.
7. In the **IncludeInReportAttribute** class, define a private Boolean variable named **\_include** to hold the value of the attribute.
8. In the **IncludeInReportAttribute** class, define two public read/write Boolean properties named **Underline** and **Bold**.
9. In the **IncludeInReportAttribute** class, define a public read/write string property named **Label**.
10. In the **IncludeInReportAttribute** class, create a default constructor that sets the properties as follows:
    - \_include: **true**
    - Underline: **false**
    - Bold: **false**
    - Label: **string.Empty**
11. Create another constructor that takes a Boolean parameter named **includeInReport** and sets the properties as follows:
    - \_include: **\_includeInReport**
    - Underline: **false**
    - Bold: **false**
    - Label: **string.Empty**

#### Task 2: Apply the IncludeInReportAttribute attribute to the appropriate properties

In the **Grades.WPF** project, in the **Data.cs** file, in the **LocalGrade** class, add the **IncludeInReport** attribute to the appropriate properties of the **LocalGrade** class as follows:

- **SubjectName** property:
  - Label: **Subject Name**
  - Bold: **true**
  - Underline: **true**
- **AssessmentDate** property:
  - Label: **Date**
- **Assessment** property:
  - Label: **Grade**
- **Comments** property:
  - Label: **Comments**

#### Task 3: Build the application and review the metadata for the LocalGrades class

1. Build the solution, and then resolve any compilation errors.
2. Use the IL DASM utility to examine the metadata of the **LocalGrades** class in the **Grades.WPF.exe** assembly. The IL DASM utility is located in the **C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools** folder, and the **Grades.WPF.exe** assembly is located in the **[Repository Root]\Allfiles\Mod12\Labfiles\Starter\Exercise 1\Grades.WPF\bin\Debug** folder.
3. Verify that the **IncludeInReport** attribute has been applied to the specified properties in the class.

> **Result :** After completing this exercise, the **Grades.Utilities** assembly will contain an **IncludeInReport** custom attribute and the **Grades** class will contain fields and properties that are tagged with that attribute.

### Exercise 2: Updating the Report

#### Scenario

In this exercise, you will update the grades report to include fields and properties only if they are tagged with the **IncludeInReport** attribute.

First, you will implement a method named **GetItemsToInclude** in a static helper class called **IncludeProcessor** that implements the logic that is necessary to discover the fields and properties that are tagged with the **IncludeInReport** attribute.  
You will then update the code for the **StudentProfile** view to include fields and properties in the report only if they are tagged with the **IncludeInReport** attribute and to format them appropriately.

#### Task 1: Implement a static helper class called IncludeProcessor

1. In Visual Studio, from the **[Repository Root]\Allfiles\Mod12\Labfiles\Starter\Exercise 2** folder, open the **Grades.sln** solution.
2. Set the following projects to start at startup:
    - **Grades.Web**
    - **Grades.WPF**
3. In the **Grades.Utilities** project, open **IncludeInReport.cs**.
4. Locate the **FormatField** struct declaration, and then add two string members named **Value** and **Label** and two Boolean members named **IsBold** and **IsUnderlined**.
5. In the **GetItemsToInclude** method of the **IncludeProcessor** class, after the variable declarations, add code to find all of the public fields and properties in the **dataForReport** object and use the **AddRange** method to add them to the **fieldsAndProperties** list.
6. Add code to iterate through all of the public fields and properties.
7. In the loop, add code to retrieve all the custom attributes applied to an item.
8. Then use the **Array.Find** method to test whether any of the custom attributes applied to the item are the **IncludeInReport** attribute.
9. At the end of the loop, add code to find the value of the item that is tagged with the **IncludeInReport** attribute.
10. At the end of the loop, add code to construct a **FormatField** item containing the value of the item and the label, boldface and underline values from the attribute.
11. At the end of the loop, add code to add the **FormatField** item to the collection to be returned.

#### Task 2: Update the report functionality for the StudentProfile view

1. In the **Grades.WPF** project, in the **StudentProfile.xaml.cs** class, in the **GenerateStudentReport** method, at the start of the **foreach** loop, add code to use the **IncludeProcessor** class to determine which fields in the **Grade** object are tagged with the **IncludeInReport** attribute.
2. Add code to include each tagged item in the output by using the format that is specified by the properties of the **IncludeInReport** attribute for each item.

#### Task 3: Build and test the application

1. Build the solution, and then resolve any compilation errors.
2. Run the application.
3. Log on as **vallee** and use the password **password99**.
4. Create and save a grades report for **Kevin Liu**.
5. Close the application, and then close the solution.
6. Open the grades report that you just created in Word and verify that the document contains a correctly formatted report.
7. Close Word.

> **Result :** After completing this exercise, the application will be updated to use reflection to include only the tagged fields and properties in the grades report.

### Exercise 3: Storing the Grades.Utilities Assembly Centrally (If Time Permits)

#### Scenario

In this exercise, you will store the **Grades.Utilities** assembly in the GAC.

First, you will use **Sn.exe** to generate a key pair and then use the key pair to sign the **Grades.Utilities** assembly.  
Next, you will use **Gacutil.exe** to add the assembly to the GAC.  
You will then update the reference for the **Grades.Utilities** assembly in the **Grades.WPF** project to use the new signed assembly that is hosted in the GAC,  
and finally you will test the application to ensure that the reports are generated correctly.

#### Task 1: Sign the Grades.Utilities assembly and deploy it to the GAC

1. In Visual Studio, from the **[Repository Root]\Allfiles\Mod12\Labfiles\Starter\Exercise 3** folder, open the **Grades.sln** solution.
2. Set the following projects to start at startup:
    - **Grades.Web**
    - **Grades.WPF**
3. Run the **Developer Command Prompt for VS 2017** window as Administrator.
4. Run the **Sn.exe** utility to create a key pair file named **GradesKey.snk** in the **[Repository Root]\Allfiles\Mod12\Labfiles\Starter** folder.
5. In Visual Studio, set the properties of the **Grades.Utilities** project to use the key pair that you have just created to sign the assembly.
6. Build the solution, and then resolve any compilation errors.
7. At the command prompt, use the **Gacutil** utility to add the **Grades.Utilities** assembly to the GAC.
8. Close command prompt.

#### Task 2: Reference the Grades.Utilities assembly in the GAC from the application

1. In Visual Studio, from the **Grades.WPF** project, remove the current reference to the **Grades.Utilities** project.
2. Add a new reference to the signed **Grades.Utilities.dll** assembly.
3. Build the solution, and then resolve any compilation errors.
4. Run the application.
5. Log on as **vallee** and the password **password99**.
6. Create and save a grades report for **Kevin Liu**.
7. Close the application, and then close the solution.
8. Open the grades report that you just created in Word and verify that the document contains a correctly formatted report.
9. Close Word.

> **Result :** After completing this exercise, you will have a signed version of the **Grades.Utilities** assembly deployed to the GAC.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
