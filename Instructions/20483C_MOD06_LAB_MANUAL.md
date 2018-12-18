
# Module 6: Reading and Writing Local Data

## Lab: Generating and loading the Grades Report

### Scenario

You have been asked to upgrade the **Grades Prototype** application to enable users to save a student’s grades as a JSON file on the local disk.
The user should be able to click a new button on the **StudentProfile** view that asks the user where they would like to save the file, displays a preview of the data to the user, and asks the user to confirm that they wish to save the file to disk. If they do, the application should save the grade data in the JSON format at the location that the user specified.
Then, you should be able to change the report that you just saved and load it into the user interface.
After doing it, you should be able to see the changes reflected in the user interface.

#### Objectives

After completing this lab, you will be able to:

- Use the **Newsoft.Json** NuGet package to work with JSON documents.
- Serialize data to a JSON.
- Save serialized data to a file using **FileStream**.
- Load serialized data from a file.
- Deserialize data from a JSON file.

### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Serializing Data for the Grades Report as JSON

#### Scenario

In this exercise, you will write code that runs when the user clicks the **Save Report** button on the **Student Profile** view. You will enable a user to specify where to save the grade report, and to serialize the grades data so it is ready to save to a file.  
You will use the **SaveFileDialog** object to ask the user for the file name and location where they want to save the file. You will extract the grade data from the application data source and store it in a list of grade objects.  
You will then write the code in **SaveReport_Click**. This code will use a **StreamWriter** object to create a JSON document and populate it with grade information from the list of grade objects.  
Finally, you will save the student report in the disk and view the data held in the disk.

#### Task 1: Prompt the user for a filename and retrieve the grade data

1. Open **Visual Studio 2017**.
2. From the **[Repository Root]\AllFiles\Mod06\Labfiles\Starter\Exercise 1** folder, open the **GradesPrototype.sln** solution.
3. In the **Views** folder, open the **StudentProfile.xaml** user interface, and
    > note that it has been updated to include a **Save Report** button that users will click to generate and save the grades report.
4. In **StudentProfile.xaml.cs**, in the **SaveReport_Click** method, add code to store the return value from the dialog box in a nullable Boolean variable.
5. Check if the return value from the **SaveFileDialog** contains data. If it does, do the following:
   - Get the grades for the currently selected student and store them in a generic list.

#### Task 2: Serialize the grade data to a file stream

1. Add code to serialize the grades data to a JSON format.

#### Task 3: Save the JSON document to disk by using FileStream

1. Add code to store the serialized data in a **FileStream** object by using **StreamWriter**.
2. Add code to reset the **FileStream** object so that it can be read from the start, and then close all the stream resources by using **Close** and **Dispose** methods.

#### Task 4: Run the application and check the save functionality

1. Build the solution and resolve any compilation errors.
2. Run the application.
3. Log in as **vallee** with **password99** as the password.
4. View **Kevin Liu’s** report, and then click **Save Report** to generate the JSON document.
5. Specify to save the file in the default location.
6. Review the JSON data displayed in the message box and close the application.
7. In **Visual Studio**, close the solution.
8. Open the specified file, change some assessment data and save the file.

>**Result:** After completing this exercise, users will be able to save student reports to the local hard disk in the JSON format.

### Exercise 2: Deserialize Data from the JSON report to Grades object

#### Scenario

In this exercise, you will write code to define load settings and load the student report from the disk. At the end of this exercise, you will be able to display the loaded student report from the disk to the user.  
You will add code to the **LoadReport_Click** method to define the settings to load the report as a JSON file and display a dialog box to the user to get a filename. To the **LoadReport_Click** method, you will also add code that loads the report from the disk as a JSON, deserializes it to the grades model, and displays it to the user.

#### Task 1: Define the File Dialog settings to load the report file

1. In **Visual Studio**, from the **[Repository Root]\AllFiles\Mod06\Labfiles\Starter\Exercise 2** folder, open the **GradesPrototype.sln** solution.
2. In **StudentProfile.xaml.cs**, in the **LoadReport_Click** method, add code to the beginning of the method block that defines the load dialog settings.
3. Show a dialog box to the user and save the dialog result into a Boolean variable.

#### Task 2: Load the report and display it to the user

1. Add an **If** statement that checks the user's file selection.
2. Read the report data from the disk.
3. Deserialize the JSON data to grades list by using **Newsoft.JSON** NuGet package.
4. Display the saved report to the user.

#### Task 3: Run the application and check the load functionality

1. Build the solution for resolving any compilation errors.
2. Run the application and log in by using **vallee** as the username and **password99** as the password.
3. Select **Kevin Liu** and load his report from the disk.
4. Review the data displayed in the **Report Card** view and verify that the changes that were made in the report file are reflected now.
5. Close the application.
6. In **Visual Studio**, on the **File** menu, click **Close Solution**.
7. Close **Visual Studio**.

>**Result:** After completing this exercise, users will be able to load student reports from the local disk.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
