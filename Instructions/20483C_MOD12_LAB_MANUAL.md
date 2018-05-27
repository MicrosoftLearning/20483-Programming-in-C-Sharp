


# Module 12: Creating Reusable Types and Assemblies

# Lab: Specifying the Data to Include in the Grades Report


#### Scenario

You decide to update the Grades application to use custom attributes to define the fields and properties that should be included in a grade report and to format them appropriately. This will enable further reusability of the Microsoft Word reporting functionality.
You will host this code in the GAC to ensure that it is available to other applications that require its services. 


#### Objectives

After completing this lab, you will be able to:
-	Define custom attributes.
-	Use reflection to examine metadata at run time.
-	Sign an assembly and deploy it to the GAC.


### Lab Setup

Estimated Time: **75 minutes**


### Exercise 1: Creating and Applying the IncludeInReport attribute


#### Scenario

In this exercise, you will create the **IncludeInReport** attribute to specify
the fields and the format of each field that is included in the grades report.

First, you will write code for the **IncludeInReportAttribute** class and define
the members that are contained in it. Next, you will apply the attribute to the
appropriate properties in the **LocalGrade** class in the Data.cs file. Finally,
you will build the application and then use the MSIL Disassembler utility (IL
DASM) to examine the metadata that the attribute generates.


#### Task 1: Write the code for the IncludeInReportAttribute class.

1.  In the **Apps** list, click **File Explorer**.
2.  Navigate to the **[Repository Root]\\Mod12\\Labfiles\\Databases** folder, and then
    double-click **SetupSchoolGradesDB.cmd**.
3.  Close File Explorer.
4.  Click **Visual Studio 2017**.
5.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
6. In the **Open Project** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 1**, click **Grades.sln**, and then
    click **Open**.
7. In Solution Explorer, right-click **Solutions ‘Grades’**, and then click
    **Properties**.
8. On the **Startup Project** page, click **Multiple startup projects**. Set
    **Grades.Web** and **Grades.WPF** to **Start without debugging**, and then
    click **OK**.
9.	In Solution Explorer, expand **Grades.Utilities**, and then double-click **IncludeInReport.cs**.
10.	On the **View** menu, click **Task List**.
11.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1a: Specify that IncludeInReportAttribute is an attribute class** task.
12.	In the code editor, below the comment, click at the end of the public **public class IncludeInReportAttribute** code, and then type the following code:
    ```cs
    : Attribute
    ```
13.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1b: Specify the possible targets to which the IncludeInReport attribute can be applied** task.
14.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple   = false)]
    ```
15.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1c: Define a private field to hold the value of the attribute** task.
16.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    private bool _include;
    ```
17.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1d: Add public properties that specify how an included item should be formatted** task.
18.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    public bool Underline { get; set; }
    public bool Bold { get; set; }
    ```
19.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1e: Add a public property that specifies a label (if any) for the item** task.
20.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    public string Label { get; set; }
    ```
21.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 1f: Define constructors** task.
22.	In the code editor, click at the end of the comment, press Enter, and then type the following code:
    ```cs
    public IncludeInReportAttribute()
    {
        this._include = true;
        this.Underline = false;
        this.Bold = false;
        this.Label = string.Empty;
    }

    public IncludeInReportAttribute(bool includeInReport)
    {
        this._include = includeInReport;
        this.Underline = false;
        this.Bold = false;
        this.Label = string.Empty;
    }
    ```

#### Task 2: Apply the IncludeInReportAttribute attribute to the appropriate properties.

1.	In Solution Explorer, expand **Grades.WPF**, and then double-click **Data.cs**.
2.	In the **Task List** window, double-click the **TODO: Exercise 1: Task 2: Add the IncludeInReport attribute to the appropriate properties in the LocalGrade class** task.
3.	In the **LocalGrade** class, expand the Properties region, and then expand the **Readonly Properties** region.
4.	Above the **public string SubjectName** code, click in the blank line, and then type the following code:
    ```cs
    [IncludeInReport(Label="Subject Name", Bold=true, Underline=true)]
    ```
5.	Above the **public string AssessmentDateString** code, click in the blank line, press Enter, and then type the following code:
    ```cs
    [IncludeInReport (Label="Date")]
    ```
6.	Expand the **Form Properties** region.
7.	Above the **public string Assessment** code, click in the blank line, press Enter, and then type the following code:
    ```cs
    [IncludeInReport(Label = "Grade")]
    ```
8.	Above the **public string Comments** code, click in the blank space, press Enter, and then type the following code:
    ```cs
    [IncludeInReport(Label = "Comments")]
    ```


#### Task 3: Build the application and review the metadata for the LocalGrades class.

1.  On the **Build** menu, click **Build Solution**.
2.  Open File Explorer and browse to the **C:\\Program Files (x86)\\Microsoft
    SDKs\\Windows\\v8.0A\\bin\\NETFX 4.0 Tools** folder.
3.  Right-click **ildasm.exe,** and then click **Open**.
4.  In the **IL DASM** window, on the **File** menu, click **Open**.
5.  In the **Open** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 1\\Grades.WPF\\bin\\Debug**, click
    **Grades.WPF.exe**, and then click **Open**.
6.  In the **IL DASM** application window, expand **Grades.WPF,** expand
    **Grades.WPF.LocalGrade**, and then double-click **Assessment : instance
    string();**.
7.  In the **Grades.WPF.LocalGrade::Assessment : instance string()** window, in
    the **Assessment** method, verify that the **.custom instance void
    [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** code
    is present, and then close the window.
8.  In the **IL DASM** application window, double-click **AssessmentDateString :
    instance string();**.
9.  In the **Grades.WPF.LocalGrade::AssessmentDateString : instance string()**
    window, in the **AssessmentDateString** method, verify that the **.custom
    instance void
    [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** code
    is present, and then close the window.
10. In the **IL DASM** application window, double-click **Comments : instance
    string();**.
11. In the **Grades.WPF.LocalGrade::Comments : instance string()** window, in
    the **Comments** method, verify that the **.custom instance void
    [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** code
    is present, and then close the window.
12. In the **IL DASM** application window, double-click **SubjectName : instance
    string();**.
13. In the **Grades.WPF.LocalGrade::SubjectName : instance string()** window, in
    the **SubjectName** method, verify that the **.custom instance void
    [Grades.Utilities]Grades.Utilities.IncludeInReportAttribute::.ctor()** code
    is present, and then close the window.
14. Close the IL DASM application.
15. Close File Explorer.
16. In Visual Studio, on the **File** menu, click **Close Solution**.


>**Result :** After completing this exercise, the **Grades.Utilities** assembly will contain an **IncludeInReport** custom attribute and the **Grades** class will contain fields and properties that are tagged with that attribute.



### Exercise 2: Updating the Report

#### Scenario

In this exercise, you will update the grades report to include fields and
properties only if they are tagged with the **IncludeInReport** attribute.

First, you will implement a method named **GetItemsToInclude** in a static
helper class called **IncludeProcessor** that implements the logic that is
necessary to discover the fields and properties that are tagged with the
**IncludeInReport** attribute. You will then update the code for the
**StudentProfile** view to include fields and properties in the report only if
they are tagged with the **IncludeInReport** attribute and to format them
appropriately.


#### Task 1: Implement a static helper class called IncludeProcessor.

1.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
2.  In the **Open Project** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 2**, click **Grades.sln**, and then
    click **Open**.
3.  In Solution Explorer, right-click **Solutions ‘Grades’**, and then click
    **Properties**.
4.  On the **Startup Project** page, click **Multiple startup projects**. Set
    **Grades.Web** and **Grades.WPF** to **Start without debugging**, and then
    click **OK**.
5.  In Solution Explorer, expand **Grades.Utilities**, and then double-click
    **IncludeInReport.cs**.
6.  Below the **Output** window, click **Task List**.
7.  In the **Task List** window, double-click the **TODO: Exercise 2: Task 1a:
    Define a struct that specifies the formatting to apply to an item** task.
8.  In the code editor, click in the blank line in the **FormatField** struct,
    and then type the following code:
    ```cs
    public string Value;
    public string Label;
    public bool IsBold;
    public bool IsUnderlined;
    ```
9.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1b: Find all the public fields and properties in the dataForReport object** task.
10.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    Type dataForReportType = dataForReport.GetType();
    fieldsAndProperties.AddRange(dataForReportType.GetFields());
    fieldsAndProperties.AddRange(dataForReportType.GetProperties());
    ```
11.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1c: Iterate through all public fields and properties, and process each item that is tagged with the IncludeInReport attribute** task.
12.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    foreach (MemberInfo member in fieldsAndProperties)
    {
    ```
13.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1d: Determine whether the current member is tagged with the IncludeInReport attribute** task.
14.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    object[] attributes = member.GetCustomAttributes(false);
    IncludeInReportAttribute attributeFound = Array.Find(attributes, a => a.GetType()   == typeof(IncludeInReportAttribute)) as IncludeInReportAttribute;
    ```
15.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1e: If the member is tagged with the IncludeInReport attribute, construct a FormatField item** task.
16.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    if (attributeFound != null)
    {
        // Find the value of the item tagged with the IncludeInReport attribute
        string itemValue;
        if (member is FieldInfo)
        {
            itemValue = (member as FieldInfo).GetValue(dataForReport).ToString();
        }
        else
        {
            itemValue = (member as PropertyInfo).GetValue(dataForReport).ToString();
        }
    ```
17.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1f: Construct a FormatField item with this data** task.
18.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    FormatField item = new FormatField() 
    { 
        Value = itemValue, 
        Label = attributeFound.Label, 
        IsBold = attributeFound.Bold, 
        IsUnderlined = attributeFound.Underline
    };
    ```
19.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 1g: Add the FormatField item to the collection to be returned** task.
20.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
           items.Add(item);
       }
    }
    ```

#### Task 2: Update the report functionality for the StudentProfile view.

1.	In Solution Explorer, expand **Grades.WPF**, expand **Views**, expand **StudentProfile.xaml**, and then double-click **StudentProfile.xaml.cs**.
2.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 2a: Use the IncludeProcessor to determine which fields in the Grade object are tagged** task.
3.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    List<FormatField> itemsToReport = IncludeProcessor.GetItemsToInclude(grade);
    ```
4.	In the **Task List** window, double-click the **TODO: Exercise 2: Task 2b: Output each tagged item, using the format specified by the properties of the IncludeInReport attribute for each item** task.
5.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    foreach (FormatField item in itemsToReport)
    {

    wrapper.AppendText(item.Label == string.Empty ? item.Value : item.Label + ": " +    item.Value, item.IsBold, item.IsUnderlined);

    wrapper.InsertCarriageReturn();

    }
    ```

#### Task 3: Build and test the application.

1.  On the **Build** menu, click **Build Solution**.
2.  On the **Debug** menu, click **Start Without Debugging**.
3.  In the **Username** box, type **vallee**, and in the **Password** box, type
    **password99**, and then click **Log on**.
4.  In the **Class 3C** view, click **Kevin Liu**.
5.  Verify that the student report for Kevin Liu appears, and then click **save
    report**.
6.  In the **Save As** dialog box, browse to the
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 2** folder.
7.  In the **File name** box, type **KevinLiuGradesReport**, and then click
    **Save**.
8.  Close the application.
9.  In Visual Studio, on the **File** menu, click **Close Solution**.
10. Open File Explorer, browse to **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 2**,
    and then verify that KevinLiuGradesReport.docx has been generated.
11. Right-click **KevinLiuGradesReport.docx**, and then click **Open**.
12. Verify that the document contains the grade report for Kevin Liu and that it
    is correctly formatted, and then close Word.




>**Result :** After completing this exercise, the application will be updated to use reflection to include only the tagged fields and properties in the grades report.


### Exercise 3: Storing the Grades.Utilities Assembly Centrally (If Time Permits)

#### Scenario

In this exercise, you will store the **Grades.Utilities** assembly in the GAC.
First, you will use Sn.exe to generate a key pair and then use the key pair to
sign the **Grades.Utilities** assembly. Next, you will use Gacutil.exe to add
the assembly to the GAC. You will then update the reference for the
**Grades.Utilities** assembly in the Grades.WPF project to use the new signed
assembly that is hosted in the GAC, and finally you will test the application to
ensure that the reports are correctly generated.


#### Task 1: Sign the Grades.Utilities assembly and deploy it to the GAC.

1.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
2.  In the **Open Project** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 3**, click **Grades.sln**, and then
    click **Open**.
3.  In Solution Explorer, right-click **Solutions ‘Grades’**, and then click
    **Properties**.
4.  On the **Startup Project** page, click **Multiple startup projects**. Set
    **Grades.Web** and **Grades.WPF** to **Start without debugging**, and then
    click **OK**.
5.  Switch to the Windows 8 **Start** window.
6.  In the **Start** window, right-click the background to display the taskbar.
7.  On the taskbar, click **All apps**.
8.  In the **Start** window, right-click the **VS2012 x86 Native Tools Command**
    icon.
9.  On the taskbar, click **Run as administrator**.
10. In the **User Account Control** dialog box, in the **Password** box, type
    **Pa\$\$w0rd**, and then click **Yes**.
11. At the command prompt, type the following code, and then press Enter:
    ```cs
    E:
    ```
12.	At the command prompt, type the following code, and then press Enter:
    ```cs
    cd [Repository Root]\Mod12\Labfiles\Starter
    ```
13.	At the command prompt, type the following code, and then press Enter:
    ```cs
    sn -k GradesKey.snk
    ```
14.	Verify that the text **Key pair written to GradesKey.snk** is displayed.
15.  In Visual Studio, in Solution Explorer, right-click **Grades.Utilities**,
    and then click **Properties**.
16.  On the **Signing** tab, select **Sign the assembly**.
17.  In the **Choose a strong name key file** list, click **Browse**.
18.  In the **Select File** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter**, click **GradesKey.snk**, and then click
    **Open**.
19.  On the **Build** menu, click **Build Solution**.
20.	Switch to the command prompt, type the following code, and then press Enter:
    ```cs
    cd [Repository Root]\Mod12\Labfiles\Starter\Exercise 3\Grades.Utilities\bin\Debug
    ```
21.	At the command prompt, type the following code, and then press Enter:
    ```cs
    gacutil -i Grades.Utilities.dll
    ```
22.	Verify that the text **Assembly successfully added to the cache** is displayed, and then close the Command Prompt window.


#### Task 2: Reference the Grades.Utilities assembly in the GAC from the application.

1.  In Visual Studio, in Solution Explorer, expand **Grades.WPF**, expand
    **References**, right-click **Grades.Utilities**, and then click **Remove**.
2.  Right-click **References**, and then click **Add Reference**.
3.  In the **Reference Manager – Grades.WPF** dialog box, click the **Browse**
    button.
4.  In the **Select the files to reference** dialog box, browse to
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 3\\Grades.Utilities\\bin\\Debug**,
    click **Grades.Utilities.dll**, and then click **Add**.
5.  In the **Reference Manager – Grades.WPF** dialog box, click **OK**.
6.  On the **Build** menu, click **Build Solution**.
7.  On the **Debug** menu, click **Start Without Debugging**.
8.  In the **Username** box, type **vallee**, and in the **Password** box, type
    **password99**, and then click **Log on**.
9.  In the **Class 3C** view, click **Kevin Liu**.
10.  Verify that the student report for Kevin Liu appears, and then click **save
    report**.
11.  In the **Save As** dialog box, browse to the
    **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 3** folder.
12.  In the **File name** box, type **KevinLiuGradesReport**, and then click
    **Save**.
13.  Close the application.
14.  In Visual Studio, on the **File** menu, click **Close Solution**.
15. Open File Explorer, browse to **[Repository Root]\\Mod12\\Labfiles\\Starter\\Exercise 3**,
    and then verify that KevinLiuGradesReport.docx has been generated.
16. Right-click **KevinLiuGradesReport.docx**, and then click **Open**.
17. Verify that the document contains the grade report for Kevin Liu and that it
    is correctly formatted, and then close Word.



>**Result :** After completing this exercise, you will have a signed version of the
**Grades.Utilities** assembly deployed to the GAC.




©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.