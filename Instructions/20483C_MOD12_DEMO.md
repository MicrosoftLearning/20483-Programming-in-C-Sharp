# Module 12: Creating Reusable Types and Assemblies

## Lesson 1: Examining Object Metadata

### Demonstration: Inspection Assemblies

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\AllFiles\Mod12\Democode\Starter\FourthCoffee.TypeInspector** folder, click **FourthCoffee.TypeInspector.sln**, and then click **Open**.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In Visual Studio, on the **View** menu, click **Task List**.
5. In the **Task List** window, double-click the **TODO: 01: Bring the System.Reflection namespace into scope** task.
6. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    using System.Reflection;
    ```
7. In the **Task List** window, double-click the **TODO: 02: Create an Assembly object** task.
8. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    return Assembly.ReflectionOnlyLoadFrom(path);
    ```
9. In the **Task List** window, double-click the **TODO: 03: Get all the types from the current assembly** task.
10. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    return assembly.GetTypes();
    ```
11. In the **Task List** window, double-click the **TODO: 04: Get a specific type from the current assembly** task.
12. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    return assembly.GetType(typeName);
    ```
13. In the code editor, locate the **RenderMethods** method, and then review the use of the **IsPublic**, **IsStatic**, **ReturnType**, and **Name** properties of the **MethodInfo** class.
14. Locate the **RenderProperties** method, and then review the use of the **DeclaringType** and **Name** properties of the **PropertyInfo** class.
15. On the **Build** menu, click **Build Solution**.
16. On the **Debug** menu, click **Start Without Debugging**.
17. In the **Fourth Coffee Type Inspector** application, click **Load Assembly**.
18. In the **Open** dialog box, browse to the **[Repository Root]\AllFiles\Mod12\Democode\Starter\FourthCoffee.TypeInspector\FourthCoffee.Core\bin\Debug** folder, click **FourthCoffee.Core.dll**, and then click **Open**. The **Types** list now contains a list of all of the types that the assembly exposes.
19. In the **Types** list, click **FourthCoffee.Core.Encryptor**, and then click **Inspect Type**. The **Members** list now shows all of the methods that the type exposes.
20. Close **Fourth Coffee Type Inspector**.
21. In Visual Studio, close the solution.

## Lesson 2: Creating and Using Custom Attributes

### Demonstration: Consuming Custom Attributes by Using Reflection

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\AllFiles\Mod12\Democode\Starter\FourthCoffee.MetadataExtractor** folder, click **FourthCoffee.MetadataExtractor.sln**, and then click **Open**.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. In Visual Studio, on the **View** menu, click **Task List**.
5. In the **Task List** window, double-click the **TODO: 01: Invoke the Type.GetCustomAttribute method** task.
6. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var typeAttribute = type.GetCustomAttribute<DeveloperInfo>(false);
    ```
7. In the **Task List** window, double-click the **TODO: 02: Invoke the MemberInfo.GetCustomAttribute method** task.
8. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var memberAttribute = member.GetCustomAttribute<DeveloperInfo>(false);
    ```
9. On the **Build** menu, click **Build Solution**.
10. On the **Debug** menu, click **Start Without Debugging**.
11. In the **Fourth Coffee Metadata Extractor** application, click **Load**. The list box now contains a list of all of the members in the **Encryptor** type and the details from any **DeveloperInfo** attributes that were found.
12. Close **Fourth Coffee Metadata Extractor**.
13. In Visual Studio, close the solution.

## Lesson 4: Versioning, Signing, and Deploying Assemblies

### Demonstration: Signing and Installing an Assembly into the GAC

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open **Visual Studio 2017**.
2. In Visual Studio, on the **File** menu, point to **Open**, and then click **Project/Solution**.
3. In the **Open Project** dialog box, browse to the **[Repository Root]\AllFiles\\Mod12\Democode\Starter\FourthCoffee.Core** folder, click **FourthCoffee.Core.sln**, and then click **Open**.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
4. Open **Windows Menu** and type **Developer Command Prompt for VS 2017**, right click on the app
    then select **Run as adiministrator**.
5. Paste the following command and then press **Enter**:
    ```cs
    cd [Repository Root]\AllFiles\Mod12\Democode\Starter\FourthCoffee.Core\FourthCoffee.Core
    ```
6. Paste the following command and then press **Enter**:
    ```cs
    generateKeyFile.cmd
    ```
7. Switch to Visual Studio 2017.
8. In **Solution Explorer**, right-click **FourthCoffee.Core**, and then click **Properties**.
9. On the **Signing** tab, select **Sign the assembly**.
10. In the **Choose a strong name key file** list, click **Browse**.
11. In the **Select File** dialog box, click **FourthCoffeeKeyFile.snk**, and then click **Open**.
12. On the **Build** menu, click **Build Solution**.
13. Switch to File Explorer.
14. In the **[Repository Root]\AllFiles\Mod12\Democode\Starter\FourthCoffee.Core\FourthCoffee.Core** folder, right-click the **installAssemblyInGac.cmd** file, and then click **Edit**.
    > **Note :** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
15. In Notepad, view the **Gacutil** command.
16. Close Notepad, and then close File Explorer.
17. Switch back to **Developer Command Prompt for VS 2017** and then run the **installAssemblyInGac** command. Verify that the command completes successfully.
18. Run the **verifyGacInstall** command, and then ensure that the number of items found equals one.
19. Close the **Administrator: Developer Command Prompt for VS 2017** window.
20. In Visual Studio, close the solution.

### Demonstration: Specifying the Data to Include in the Grades Report Lab

#### Preparation Steps

Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)

#### Demonstration Steps

1. Open the **Grades.sln** solution from the **[Repository Root]\AllFiles\Mod12\Labfiles\Solution\Exercise 2** folder.
    > **Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In the **Grades.Utilities** project, open **IncludeInReport.cs**.
3. Locate the **IncludeInReportAttribute** class definition, and then explain to the students that in Exercise 1, they will make this class an attribute class and define its members.
4. In the **Grades.WPF** project, open **Data.cs**.
5. Locate the **LocalGrade** class, and then point out to the students the **IncludeInReport** attributes on the **SubjectName**, **AssessmentDate**, **Assessment**, and **Comments** properties.
6. In the **Grades.Utilities** project, open **IncludeInReport.cs**.
7. Locate the **FormatField** struct, and then explain to the students that in Exercise 2, they will define this struct to specify the formatting to apply to an item.
8. In the **IncludeProcessor** class, locate the **GetItemsToInclude** method.
9. Explain to the students that they will add code to this method to find all of the public fields and properties in the **dataForReport** object and process each item that is tagged with the **IncludeInReport** attribute to format it correctly and include it in the report.
10. In the **Grades.WPF** project, in the **Views** folder, Expand **StudentProfile.xaml** and then open **StudentProfile.xaml.cs**.
11. Locate the **GenerateStudentReport** method, and then explain to the students that they add code to this method to use the **IncludeProcessor** class to determine which fields in the **Grade** object are tagged with the **IncludeInReport** attribute, format them appropriately, and include them in the report.
12. Explain to the students that they will use the **Strong Name** tool to generate a key pair and sign the **Grades.Utilities** assembly with the key pair and then host the assembly in the GAC.
13. Finally, they will generate a report and check that the correct properties are included in the report and the formatting is correctly applied.
14. Close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
