
# Module 8: Accessing Remote Data

## Lesson 1: Accessing Data Across the Web

### Demonstration: Consuming a Web Service

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Navigate to **[Repository Root]\Allfiles\Mod08\Democode\Starter\Fourth Coffee Contact Finder**, and then open the **Fourth Coffee Contact Finder.sln** file.
  >**Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.

#### Demonstration Steps

1. In the **Solution Explorer** window, expand the **FourthCoffee.DataService** project, and then double-click **ISalesService.cs**.
2. In the code editor, review the signature of the **GetSalesPerson** operation, which accepts an email address in the form of a JSON string and returns a **SalesPerson** object.
3. In the **Solution Explorer** window, expand the **FourthCoffee.Infrastructure** project, expand the **Models** folder, and then double-click **SalesPerson.cs**.
4. In the code editor, review the **DataContract** and **DataMember** attributes that decorate the type and type members.
5. In Microsoft Visual Studio, on the **View** menu, click **Task List**.
6. In the **Task List** window, double-click the **TODO: 01: Bring the System.Net namespace into scope.** task.
7. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    using System.Net;
    ```
8. In the **Task List** window, double-click the **TODO: 02: Declare a global object to encapsulate an HTTP request** task.
9. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    HttpWebRequest _request;
    ```
10. In the **Task List** window, double-click the **TODO: 03: Instantiate the _request object** task.
11. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._request = WebRequest.Create(this._serviceUri.AbsoluteUri) as HttpWebRequest;
    ```
12. In the **Task List** window, double-click the **TODO: 04: Configure the request to send JSON data** task.
13. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._request.Method = "POST";
    this._request.ContentType = "application/json";
    this._request.ContentLength = rawData.Length;
    ```
14. In the **Task List** window, double-click the **TODO: 05: Write data to the request stream** task.
15. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var dataStream = this._request.GetRequestStream();
    dataStream.Write(data, 0, data.Length);
    dataStream.Close();
    ```
16. In the **Task List** window, double-click the **TODO: 06: Create an HttpWebResponse object** task.
17. In the code editor, click in the blank line below the comment, and then type the following code:
     ```cs
    var response = this._request.GetResponse() as HttpWebResponse;
    ```
18. In the **Task List** window, double-click the **TODO: 07: Check to see if the response contains any data.** task.
19. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    if (response.ContentLength == 0)
        return null;
    ```
20. In the **Task List** window, double-click the **TODO: 08: Read and process the response data** task.
21. In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var stream = new StreamReader(response.GetResponseStream());
    var result = SalesPerson.FromJson(stream.BaseStream);
    stream.Close();
    ```
22. On the **Build** menu, click **Build Solution**.
23. Right-click the **FourthCoffee.DataService** project, point to **Debug** and then click **Start new instance**.
24. Locate the address bar in the browser, add **\SalesService.svc** to the end of the address and then press Enter.
25. In Solution Explorer, right-click **Fourth Coffee Contact Finder**, point to **Debug** and then click **Start new instance**.
26. In the **Fourth Coffee Contract Finder** application, in the **Search** box, type **jesper@fourthcoffee.com**, and then click **GO**.
27. In the **Search Successful** dialog box, click **OK**.
28. Verify that the details for Jesper Herp are displayed.
29. On the **Debug** menu, click **Stop Debugging**.
30. Close Visual Studio.

## Lesson 2: Accessing Data by Using OData Connected Services

### Demonstration: Retrieving and Modifying Grade Data Remotely

#### Preparation Steps

1. Ensure that you have cloned the 20483C directory from GitHub. It contains the code segments for this course's labs and demos. (**https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles**)
2. Initialize the database:
   - In the **Apps list**, click **File Explorer**.
   - In **File Explorer**, navigate to the **[Repository Root]\Allfiles\Mod08\Labfiles\Databases** folder, and then double-click **SetupSchoolGradesDB.cmd**.
    >**Note:** If a Windows protected your PC dialog appears, click **More info** and then click **Run Anyway**.
   - Close **File Explorer**.
3. Ensure that you have completed the following steps before starting working on this module:
   - Install **Microsoft.OData.ConnectedService.vsix** from **[Repository Root]\AllFiles\Assets**.  
     Alternatively download the latest version from the Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=laylaliu.ODataConnectedService
   - Install **WcfDataServices.exe** from **[Repository Root]\AllFiles\Assets**.
   - Run **WCF.reg** file from **[Repository Root]\AllFiles\Assets**.

#### Demonstration Steps

1. Open the **GradesPrototype.sln** solution from the **[Repository Root]\\Allfiles\\Mod08\\Labfiles\\Solution\\Exercise 3** folder.
    >**Note:** If any Security warning dialog box appears, clear **Ask me for every project in this solution** check box and then click **OK**.
2. In **Solution Explorer**, right-click **Solution ‘GradesPrototype’**, and then click **Properties**.
3. On the **Startup Project** page, click **Multiple startup projects**. Set **Grades.Web** and **GradesPrototype** to **Start**, and then click **OK**.
4. Rebuild the solution.
5. View the properties of the **Grades.Web** project and show the **Web** tab. Explain to the students that during Exercise 1, they will add this project to the solution and configure it as a data service.
6. In the **Grades.Web** project, in the **Services** folder, open **GradesWebDataService.svc**, and then explain to the students that during Exercise 1, they will set rules to indicate which entity sets and service operations are visible and add a new service operation to the class.
7. In **Solution Explorer**, in the **Grades.Web** project, view the **Connected Services** folder.
8. Explain to the students that in Exercise 2, they will add a **OData Connected Service** to the data service so that the data is retrieved from the data service, not directly from the data source.
9. In **Solution Explorer**, in the **GradesPrototype** project, view the **DataModel** folder.
10. Explain to the students that in Exercise 2, they will copy the partial classes from the original Entity Data Manager (EDM) into the client application because the partial types that are contained in them are not propagated by **OData Connected Service**.
11. In the **GradesPrototype** project, in the **Services** folder, in **SessionContext.cs**, locate the **DBContext** declaration.
12. Explain to the students that in Exercise 2, they will specify the URL of the **GradesWebDataService** data service here.
13. In the **Views** folder, expand **StudentsPage.xaml** and then open **StudentsPage.xaml.cs**, locate the **Refresh** method, and then explain to the students that in **Exercise 2**, they will use eager loading to load related data.
14. In the **Controls** folder, expand **AssignStudentDialog.xaml** and then open **AssignStudentDialog.xaml.cs**, locate the **Student_Click** method, and then explain to the students that in **Exercise 2**, they will add code to the application to detect when student data has been changed.
15. In **StudentsPage.xaml.cs**, locate the **ImageNameConverter** class, and then explain to the students that in Exercise 3, they will create this class and implement the **IValueConverter** interface.
16. In **StudentsPage.xaml**, point out the **UserControl.Resources** element and the **Image** element, and then explain to the students that in Exercise 3, they will bind **Image** controls to the images of students to display them in the UI.
17. Run the application, log on as **vallee** with a password of **password99**, and then point out to students that the students list now includes images.
18. View a student’s profile and point out that this also includes an image.
19. Remove a student from the class and then enroll that student again to show images in the **Assign Student** dialog box and for new students who are added to a class.
20. Click **Log off**, and then close the application.
21. On **Debug menu**, click **Stop Debugging** and then close Visual Studio.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
