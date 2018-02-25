
# Module 6: Reading and Writing Local Data

# Lab: Generating the Grades Report

#### Scenario

You have been asked to upgrade the Grades Prototype application to enable users to save a student’s grades as an XML file on the local disk. The user should be able to click a new button on the StudentProfile view that asks the user where they would like to save the file, displays a preview of the data to the user, and asks the user to confirm that they wish to save the file to disk. If they do, the application should save the grade data in XML format in the location that the user specified.

#### Objectives

After completing this lab, you will be able to:
   -	Serialize data to a memory stream.
   -	Deserialize data from a memory stream.
   -	Save serialized data to a file.


### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Serializing Data for the Grades Report as XML

#### Scenario

In this exercise, you will write code that runs when the user clicks the **Save
Report** button on the **Student Profile** view. You will enable a user to
specify where to save the Grade Report, and to serialize the grades data so it
is ready to save to a file.

You will use the **SaveFileDialog** object to ask the user for the file name and
location where they want to save the file. You will extract the grade data from
the application data source and store it in a list of Grade objects.

You will then write the **FormatAsXMLStream** method. This method will use an
**XmlWriter** object to create an XML document and populate it with grade
information from the list of Grade objects. Finally, you will debug the
application and view the data held in the memory stream.



#### Task 1: Prompt the user for a filename and retrieve the grade data.

1.  Start Visual Studio and from the **E:\\Mod06\\Labfiles\\Starter\\Exercise
    1** folder, open the **GradesPrototype.sln** solution.
2. In the **Views** folder, open the **StudentProfile.xaml** user interface, and
note that it has been updated to include a **Save Report** button that users
will click to generate and save the Grades Report.
3. In **StudentProfile.xaml.cs**, in the **SaveReport_Click** method, add code to
store the return value from the dialog box in a nullable Boolean variable.
4.  Check if the return value from the **SaveFileDialog** contains data. If it
    does, do the following:

    -  Get the grades for the currently selected student and store them in a
        generic list.

    -  Call the **FormatAsXMLStream** method, passing the list of grades to it,
        and store the returned data in a **MemoryStream** object.



#### Task 2: Serialize the grade data to a memory stream.

1.  In **StudentProfile.xaml.cs** code file, locate the **FormatAsXMLStream**
    method.
2.  Add code to save the XML document to a **MemoryStream** object by using an
    **XmlWriter** object.
3.	Add code to create the root node of the XML document in the following format:
    ```xml
    <Grades Student="Eric Gruber">
    ```
4.	Add code to enumerate the grades for the student and add them as child elements of the root node, using the following format:
    ```xml
    <Grade Date="01/01/2012" Subject="Math" Assessment="A-" Comments="Good" />
    ```
5.	Add code to finish the XML document with the appropriate end elements.
6. Add code to flush the **XmlWriter** object and then close it to ensure that all
the data is written to the **MemoryStream** object.
7.  Add code to reset the **MemoryStream** object so that it can be read from
    the start, and then return it to the calling method.
8.  Delete the line of code that throws a **NotImplementedException** exception.


#### Task 3: Debug the application.

1.  Build the solution and resolve any compilation errors.

2.  In the **SaveReport_Click** method, add a breakpoint to the closing brace of
    the **if** block.
3.  Debug the application.
4.  Log in as **vallee** with a password of **password99**.
5.  View **Kevin Liu’s** report, and then click **Save Report** to generate the
    XML document.
6.  In the **Save As** dialog box, click **Save**.
>**Note :** You will write the code to actually save the report to disk in Exercise 3 of this lab.
7.	When you enter Break Mode, use the Immediate Window to view the contents of the **MemoryStream** object by using the following code:
    ```cs
    ?(new StreamReader(ms)).ReadToEnd()
    ```
8.	Review the grade data that is returned.
9.	Stop debugging, delete the breakpoint, and then close the solution.


>**Result :** After completing this exercise, users will be able to specify the location for the Grades Report file.


### Exercise 2: Previewing the Grades Report

#### Scenario

In this exercise, you will write code to display a preview of the report to the
user before saving it.

First, you will add code to the **SaveReport_Click** method to display the XML
document to the user in a message box. To display the document, you need to
build a string representation of the XML document that is stored in the
**MemoryStream** object. Finally, you will verify that your code functions as
expected by running the application and previewing the contents of a report.



#### Task 1: Display the string to the user in a message box.

1.	In Visual Studio, from the **E:\Mod06\Labfiles\Starter\Exercise 2** folder, open the **GradesPrototype.sln** solution.
2. In **StudentProfile.xaml.cs**, in the **SaveReport_Click** method, add code to
the end of the **if** block that calls the **FormatXMLData** method, passing the
**MemoryStream** object that you created in the previous task, and storing the
return value in a string variable.
3. Add code to preview the string version of the report data in a message box with
a caption of **Preview Report**, an **OK** button, and an information image.




#### Task 2: Build a string representation of the XML document.

1. In **StudentProfile.xaml.cs**, in the **FormatXMLData** method, add code to
create a new **StringBuilder** object used to construct the string.
2.	Add code to create a new **XmlTextReader** object used to read the XML data from the stream.
3.  Add code to read the XML data one node at a time, construct a string
    representation of the node, and append it to the **StringBuilder**. The
    possible nodes that can be encountered are **XmlDeclaration**, **Element**,
    and **EndElement**. Each element may have one or more attributes.
4.  Add code to reset the **MemoryStream** object and return the string
    containing the formatted data to the calling method.
5.  Delete the line of code that throws a **NotImplementedException** exception.



#### Task 3: Run the application and preview the data.

1.  Build the solution and resolve any compilation errors.
2.  Run the application.
3.  Log in as **vallee** with a password of **password99**.
4.  View **Kevin Liu’s** report, and then click **Save Report** to generate the
    XML document.
5.  Specify to save the file in the default location.
    >**Note :** You will write the code to actually save the report to disk in the next exercise of this lab.
6.	Review the XML data displayed in the message box and close the application.
7.	In Visual Studio, close the solution.


>**Result :** After completing this exercise, users will be able to preview a report before saving it.

### Exercise 3: Persisting the Serialized Grade Data to a File

#### Scenario

In this exercise, you will write the grade data to a file on the local disk.

You will begin by modifying the existing preview dialog box to ask the user if
they wish to save the file. If they wish to save the file, you will use a
**FileStream** object to copy the data from the **MemoryStream** to a physical
file. Then you will run the application, generate and save a report, and then
verify that the report has been saved in the correct location in the correct
format.


#### Task 1: Save the XML document to disk.

1.	In Visual Studio, from the **E:\Mod06\Labfiles\Starter\Exercise 3** folder, open the **GradesPrototype.sln** solution.
2.  In **StudentProfile.xaml.cs**, in the **SaveReport_Click** method, locate
    the line of code that displays the report data to the user in a message box.
3.  Modify this line of code as follows:
    -  Save the return value of the **MessageBox.Show** method in a
        **MessageBoxResult** variable
    -  Set the caption of the message box to **Save Report?**
    -  Include **Yes** and **No** buttons in the message box.
    -  Display a question mark image.
4.  If the user clicks **Yes** to save the report, open the file that the user
    specified and create a **FileStream** object to write data to this file.
5.  Write the data from the **MemoryStream** object to the file by using the
    **MemoryStream.CopyTo** method.


#### Task 2: Run the application and verify that the XML document is saved correctly.

1.  Build the solution and resolve any compilation errors.
2.  Run the application.
3.  Log on as **vallee** with a password of **password99**.
4.  View **Kevin Liu’s** report card and then click **Save Report** to generate
    the XML document.
5.  Specify to save the file in the Documents folder by using the default name.
6.  Review the XML data displayed in the message box, and then confirm that you
    want to save the file.
7.  Close the application.
8.	Open the saved report in Internet Explorer and verify that it contains the expected grade data.
9.	In Visual Studio, close the solution.


>**Result :** After completing this exercise, users will be able to save student reports to the local hard disk in XML format.




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.