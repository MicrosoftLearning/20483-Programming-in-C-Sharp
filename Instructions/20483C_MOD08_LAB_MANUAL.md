# Module 8: Accessing Remote Data

## Lab: Retrieving and Modifying Grade Data Remotely

### Scenario

Currently, the application retrieves data from a local database. However, you have decided to store the data in the cloud and must configure the application so that it can retrieve data from the web.
You must create a WCF Data Service for the **SchoolGrades** database that will be integrated into the application to enable access to the data.
Finally, you have been asked to write code that displays student images by retrieving them from across the web.

#### Objectives

After completing this lab, you will be able to:

- Create a WCF Data Service.
- Use an OData Connected Service.
- Retrieve data over the web.

### Lab Setup

Estimated Time: **60 minutes**

### Exercise 1: Creating a WCF Data Service for the SchoolGrades Database

#### Scenario

In this exercise, you will create a WCF Data Service for the **SchoolGrades** database so that the client application can connect to the database over the web.

First, you will add a new ASP.NET Web Application project to the solution and configure it for the client application.  
You will then expose the entities in the Entity Data Model (EDM) from a data service in the new project.  
Next, you will specify the data context for the data service and configure access rights to the entities that it exposes.  
Finally, you will add an operation to the data service that returns a list of all the students in a specified class.

#### Task 1: Configure data service in the Grades.Web project

1. Start File Explorer, navigate to the **[Repository Root]\Allfiles\Mod08\Labfiles\Databases** folder, and then run **SetupSchoolGradesDB.cmd**.
2. Close File Explorer.
3. Start Microsoft Visual Studio, and from the **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 1** folder, open the **GradesPrototype.sln** solution.
4. Add a new folder named **Services** to the **Grades.Web** project.
5. Add a new WCF Data Service named **GradesWebDataService** to the **Services** folder.
6. Add a reference to the **Grades.DataModel** project in the **Grades.Web** project.
7. Add a reference to the **EntityFramework** assembly. This assembly is located in the **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 1\packages\EntityFramework.5.0.0\lib\net45** folder.
8. Copy the **\<connectionStrings\>** element from the **App.config** file in the **GradesPrototype** project and paste it into the **Web.config** file in the **Grades.Web** project.
    >**Note:** The data service in the **Grades.Web** project needs to connect to the same data source used by the data model.

#### Task 2: Specify the GradesDBEntities data context for the data service

1. In the code in the **Grades.WebDataService.svc** file, add a **using** directive to bring the **Grades.DataModel** namespace into scope.
2. Modify the class declaration of the **GradesWebDataService** to use the **SchoolGradesDBEntities** class as the data source.
    >**Note:** The **GradesDBEntities** class provides the object context for the EDM. The **GradesWebDataService** data service will retrieve data by using this object context and expose the various entities by using REST URIs.
3. In the **InitializeService** method, set the access rules for each of the following entities to **EntitySetRights.All**:
   - **Grades**
   - **Teachers**
   - **Students**
   - **Subjects**
   - **Users**

#### Task 3: Add an operation to retrieve all of the students in a specified class

1. In the **GradesWebDataService** class, add an operation named **StudentsInClass** that takes a class name as a string and returns an **IEnumerable\<Student\>** collection. This operation should be annotated with the **WebGet** attribute.
2. In this operation, use a LINQ query against the **CurrentDataSource** object to retrieve and return all of the students in the class.
3. In the **InitializeService** method, set the access rule for the **StudentsInClass** operation to **ServiceOperationRights.AllRead**.

#### Task 4: Build and test the data service

1. Build the solution, and then resolve any compilation errors.
2. In **Solution Explorer**, in the **Grades.Web** project, in the **Services** folder, right-click **GradesWebDataService.svc**, and then click **View in Browser (Microsoft Edge)**.
3. Verify that **Microsoft Edge** displays an XML description of the entities that the data service exposes.
4. Close Browser.
5. In Visual Studio, close the solution.

>**Result:** After completing this exercise, you should have added a WCF Data Service to the application to provide remote access to the **SchoolGrades** database.

### Exercise 2: Integrating the Data Service into the Application

#### Scenario

In this exercise, you will integrate OData Connected Service into the **Grades Prototype** application.

First, you will add a connected service in the **GradesPrototype** project that references the running WCF Data Service.  
You will then modify the code that accesses the local EDM to use the WCF Data Service instead.  
Next, you will modify the code that saves changes back to the database to do so through the data service.  
Finally, you will test the application to verify that it runs the same as if the data was being called locally.

#### Task 1: Add an OData Connected Service for the WCF Data Service to the GradesPrototype application

1. In Visual Studio, open the **GradesPrototype.sln** solution from the **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 2** folder.
2. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
3. Rebuild the solution.
4. In the **GradesPrototype** project, remove the reference to the **Grades.DataModel** project.
5. Add a service reference to **http://localhost:1655/Services/GradesWebDataService.svc/$metadata** by using the **Grades.DataModel** namespace.
6. Update the namespace declaration in the **Reference.cs** file for OData Connected Service to **Grades.DataModel**. The **Reference.cs** file is generated in the **ConnectedServices\Grades.DataModel** folder in **Solution Explorer**.
    > **Note:** Add Connected Service Wizard prepends the namespace that you specify with the namespace of the project, so the result, in this case, is **GradesPrototype.Grades.DataModel**. The existing code in the **GradesPrototype** project expects the various entity classes to be located in the **Grades.DataModel** namespace. You can either update every reference throughout the project, or you can change the namespace of the data service; this lab opts for the latter approach.  
    > There is one drawback with this approach; if you regenerate the data service reference (this will be necessary if, for example, you modify WCF Data Service and add a new entity class), you will have to edit the **Reference.cs** file and update the namespace again because any manual changes you make to this file will be lost.
7. Add a new folder named **DataModel** to the **GradesPrototype** project.
8. Copy the following code files from the **Grades.DataModel** project to the **GradesPrototype\DataModel** folder:
   - **Classes.cs**
   - **customGrade.cs**
   - **customTeacher.cs**
    > **Note:** The **Classes.cs**, **Grade.cs**, and **Teacher.cs** files contain custom functionality for the **Grade** and **Teacher** classes that you implemented in an earlier lab.
    > Data Services does not propagate any custom functionality that is defined for a data model, so you must manually copy these files to the **Grades.DataModel** project.  
    > You will also have to make some small changes to this code to access data through OData Connected Service rather than by referencing the entities themselves.  
    > You will do this in the next task.

#### Task 2: Modify the code that accesses the EDM to use the WCF Data Service

1. In the **Grades.Web** project, in the **Services** folder, in **SessionContext.cs**, modify the **DBContext** declaration to pass a new **Uri** object pointing to **http://localhost:1655/Services/GradesWebDataService.svc** to the **SchoolGradesDBEntities** constructor.
    > **Note:** The **DBContext** object provides the object context for accessing the data source. Previously this object context retrieved data directly from a local EDM. Now the data service provides this object context, and the constructor requires the URL of the data service.
2. Add the following static constructor to the **SessionContext** class.
    ```cs
    static SessionContext()
    {
        DBContext.MergeOption = System.Data.Services.Client.MergeOption.PreserveChanges;
    }
    ```
    This constructor ensures that any changes made by the user are not lost if multiple users try and make simultaneous changes.
3. In the **Views** folder, in **StudentsPage.xaml.cs**, locate the **Refresh** method.
4. Modify the code in the **foreach** loop that populates the **list ItemsControl** with the details of the students for the current teacher. The user and grades data for a student are held in separate entities and they are not fetched automatically by the data service (this is to save network resources by not retrieving data unnecessarily). Your code should retrieve the related data in the **User** and **Grades** properties for each student by using the **LoadProperty** method of the data context (available in **SessionContext.DBContext** object).
5. In **LogonPage.xaml.cs**, in the **Logon_Click** method, modify the statement that loads teacher data to also load the user and student data for that teacher. As an alternative to using the **LoadProperty** method of the data context, use the **Expand** method when the data is fetched by using the LINQ query.
6. In **LogonPage.xaml.cs**, in the **Logon_Click** method, modify the statement that loads student data to also load the user and grades data.
7. In the **GradesPrototype** solution, in the **customTeacher.cs** file, add a **using** directive to bring the **GradesPrototype.Services** namespace into scope.
8. In the **EnrollInClass** method, modify the **from** statement to reference the **Students** collection in the **SessionContext.DBContext** object.
9. In the **AssignStudentDialog** dialog, in the **Refresh** method, modify the code that finds unassigned students to reference the **SessionContext.DBContext.Students** collection rather than **SessionContext.DBContext.Students.Local**. This change is necessary because the data model implemented by the data service does not provide the **Local** property. You should also use the **Expand** method to retrieve the **User** and **Grades** information for the students.
10. In the **StudentProfile** view, in the **AddGrade_Click** method, find the code that uses the **Add** method of the **Grades** collection to add a grade to a student. Modify this code to use the **AddToGrades** method of the **DBContext** class. This change is necessary because the **Grades** collection implemented by Data Services does not provide the **Add** method.
11. In the **SaveReport_Click** method, modify the LINQ query that retrieves the grades for the report to also fetch the **Subject** details by using the **Expand** method.
12. In the **StudentsPage** view, in the **NewStudent_Click** method, find the code that uses the **Add** method of the **Students** collection to add a new student. Modify this code to use the **AddToStudents** method of the **DBContext** class.

#### Task 3: Modify the code that saves changes back to the database to use the Data Service

1. In the code for the **AssignStudentDialog** view, in the **Student_Click** method, add code to specify that the selected student has been changed by using the **UpdateObject** method before the call to the **SessionContext.Save** method.
   >**Note:** The data service requires that you explicitly mark an entity as updated, otherwise any changes will not be saved.
2. In the **StudentProfile** view, in the **Remove_Click** method, add code to specify that the current student has been changed before the call to the **SessionContext.Save** method.
3. In the **Controls** folder, in **ChangePasswordDialog.xaml.cs**, in the **ok_Click** method, add code to specify that the current user has been changed before the call to the **SessionContext.Save** method.

#### Task 4: Build and test the application to verify that the application still functions correctly

1. Build the solution, and then resolve any compilation errors.
2. Sign in as **vallee** with the password **password99**.
3. Perform the following tasks to verify that the application still updates the data correctly:
   - Remove **Eric Gruber** from the class.
   - Enroll **Jon Orton** into the class.
   - Change the password to **password88**, and then verify that you can sign in with the new password.
   - Sign in as **grubere** with the password **password**.
   - Verify that his student profile appears, and then sign out.
4. Close the application.
5. In Visual Studio, close the solution.

>**Result:** After completing this exercise, you should have updated the **Grades Prototype** application to use Data Service.

### Exercise 3: Retrieving Student Photographs Over the Web (If Time Permits)

#### Scenario

In this exercise, you will write code that displays student images by retrieving the image from across the web.

You will modify the **StudentsPage** window (that displays the list of students in a class), the **StudentProfile** window (that displays the details for an individual student), and the **AssignStudentDialog** window (that displays a list of unassigned students) to include the student photographs.  
The data for each student contains an **ImageName** property that specifies the filename of the photograph for the student on the web server.  
These files are located in the **Images\Portraits** folder on the same web server that hosts the data service (in the **Web.Grades** project).  
You will build a value converter class that generates the URL of an image from the **ImageName** property and then use an **Image** control to use the URL to fetch and render the image in each of the specified windows.  
Finally, you will run the application to verify that the images appear.

#### Task 1: Create the ImageNameConverter value converter class

1. In Visual Studio, open the **GradesPrototype.sln** solution from the **[Repository Root]\Allfiles\Mod08\Labfiles\Starter\Exercise 3** folder.
2. Set the following projects to start at startup:
   - **Grades.Web**
   - **Grades.WPF**
3. Rebuild the solution.
4. In the **GradesPrototype** project, in **StudentsPage.xaml.cs**, create a new public class named **ImageNameConverter** that implements the **IValueConverter** interface.
5. In the **ImageNameConverter** class, define a string constant named **webFolder** that contains the string **http://localhost:1650/Images/Portraits/**.
6. Implement the **IValueConverter** interface.
7. In the **Convert** method, add code to check whether the value that is passed to the method contains a string, and if so, append it to the **webFolder** string and return the result. If the value passed to the method is **null**, return **string.Empty**. There is no need to add any code to the **ConvertBack** method.
8. Build the solution and resolve any compilation errors.

#### Task 2: Add an Image control to the StudentsPage view and bind it to the ImageName property

1. In the XAML markup for the **StudentsPage** view, add a reference to the **clr-namespace:GradesPrototype.Views** namespace. Assign this to **xmlns:local**. This is the namespace that contains the **ImageNameConverter** class.
2. Add an instance of the **ImageNameConverter** class as a resource to the view as shown in the following code
    ```xml
    <UserControl.Resources>
        <local:ImageNameConverter x:Key="ImageNameConverter"/>
    </UserControl.Resources>
    ```
3. At the top of the **StackPanel** control, add an **Image** control. The contents of the image should use a data binding that references the **ImageNameConverter** class to convert the value in the **ImageName** property into a URL, and then display the data retrieved from this URL. Set the height of the control to **100**. The markup for the control should look like this:
    ```xml
    <Image Height="100" Source="{Binding ImageName, Converter={StaticResource ImageNameConverter}}" />
    ```

#### Task 3: Add an Image control to the StudentProfile view and bind it to the ImageName property

1. In the XAML markup for the **StudentProfile** view, add an instance of the **ImageNameConverter** class as a resource to the view. Use the **app** namespace (this namespace has already been defined at the top of the XAML markup).
2. At the top of the **StackPanel** control, add an **Image** control. Use the **ImageNameConverter** to convert the value in the **ImageName** property into a URL and display the image retrieved from this URL. Set the height of the **Image** control to **150**.

#### Task 4: Add an Image control to the AssignStudentDialog control and bind it to the ImageName property

1. In the XAML markup for the **AssignStudentDialog** control, add a reference to the **clr-namespace:GradesPrototype.Views** namespace. Assign this to **xmlns:local**.
2. Add an instance of the **ImageNameConverter** class as a resource to the view.
3. At the top of the **StackPanel** control. As before, use the **ImageNameConverter** to convert the value in the **ImageName** property into a URL and display the image retrieved from this URL. Set the height of the **Image** control to **100**.

#### Task 5: Build and test the application, verifying that student’s photographs appear in the list of students for the teacher

1. Build the solution, and then resolve any compilation errors.
2. Log on as **vallee** with the password **password88**.
3. Verify that the student list now includes images.
4. View George Li’s profile and verify that his image appears.
5. Remove George Li from the class.
6. Enroll George Li in the class, and then verify that the **Assign Student** dialog box now includes images, and new student icons in the main application window include images.
7. Close the application.
8. In Visual Studio, close the solution.

>**Result:** After completing this exercise, the student list, student profile, and unassigned student dialog box will display the images of students that were retrieved across the web.

©2018 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.
