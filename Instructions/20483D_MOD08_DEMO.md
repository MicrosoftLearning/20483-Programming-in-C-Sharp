
# Module 8: Accessing Remote Data

# Lesson 1:  Accessing Data Across the Web

### Demonstration: Consuming a Web Service

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps

1.  Click **Visual Studio 2017**.
2.  In Visual Studio, on the **File** menu, point to **Open**, and then click
    **Project/Solution**.
3.  In the **Open Project** dialog box, browse to
    **E:\\Mod08\\Democode\\Starter\\Fourth Coffee Contact Finder** folder, click
    **Fourth Coffee Contact Finder.sln**, and then click **Open**.
4.  In the **Solution Explorer** window, expand the **FourthCoffee.DataService**
    project, and then double-click **ISalesService.cs**.
5.  In the code editor, review the signature of the **GetSalesPerson**
    operation, which accepts an email address in the form of a JSON string and
    returns a **SalesPerson** object.
6.  In the **Solution Explorer** window, expand the
    **FourthCoffee.Infrastructure** project, expand the **Models** folder, and
    then double-click **SalesPerson.cs**.
7.  In the code editor, review the **DataContract** and **DataMember**
    attributes that decorate the type and type members.
8.  In Microsoft Visual Studio®, on the **View** menu, click **Task List**.
9.  In the **Task List** window, in the **Categories** list, click **Comments**.
10. Double-click the **TODO: 01: Bring the System.Net namespace into scope.**
    task.
11. In the code editor, click in the blank line below the comment, and then type
    the following code:
    ```cs
    using System.Net;
    ```
15.	In the **Task List** window, double-click the **TODO: 02: Declare a global object to encapsulate an HTTP request**. task.
16.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    HttpWebRequest _request;
    ```
17.	In the **Task List** window, double-click the **TODO: 03: Instantiate the _request object.** task.
18.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._request = WebRequest.Create(
       this._serviceUri.AbsoluteUri) as 
       HttpWebRequest;
    ```
19.	In the **Task List** window, double-click the **TODO: 04: Configure the request to send JSON data.** task.
20.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    this._request.Method = "POST";
    this._request.ContentType = "application/json";
    this._request.ContentLength = rawData.Length;
    ```
21.	In the **Task List** window, double-click the **TODO: 05: Write data to the request stream.** task.
22.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var dataStream = this._request.GetRequestStream();
    dataStream.Write(data, 0, data.Length);
    dataStream.Close();
    ```
23.	In the **Task List** window, double-click the **TODO: 06: Create an HttpWebResponse object.** task.
24.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var response = this._request.GetResponse() 
       as HttpWebResponse;
    ```
25.	In the **Task List** window, double-click the **TODO: 07: Check to see if the response contains any data.** task.
26.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    if (response.ContentLength == 0)
       return null;
    ```
27.	In the **Task List** window, double-click the **TODO: 08: Read and process the response data.** task.
28.	In the code editor, click in the blank line below the comment, and then type the following code:
    ```cs
    var stream = new StreamReader(response.GetResponseStream());
    var result = SalesPerson.FromJson(stream.BaseStream);
    stream.Close();
    ```
29.	On the **Build** menu, click **Build Solution**.
30.	In Solution Explorer, right-click **Fourth Coffee Contact Finder**, and then click **Set as StartUp Project**.
31.	On the **Debug** menu, click **Start Debugging**.
32.	In the Fourth Coffee Contract Finder application, in the **Search** box, type **jesper@fourthcoffee.com**, and then click **GO**.
33.	In the **Search Successful** dialog box, click **OK**.
34.	Verify that the details for Jesper Herp are displayed.
35.	On the **Debug** menu, click **Stop Debugging**.
36.	Close Visual Studio.


# Lesson 2:  Accessing Data in the Cloud

### Demonstration: Retrieving and Modifying Grade Data in the Cloud Lab

#### Preparation Steps

1. Ensure that you have cloned the 20483D directory from GitHub. It contains the code segments for this course's labs and demos. https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp/tree/master/Allfiles

#### Demonstration Steps





©2017 Microsoft Corporation. All rights reserved.

The text in this document is available under the  [Creative Commons Attribution 3.0 License](https://creativecommons.org/licenses/by/3.0/legalcode), additional terms may apply. All other content contained in this document (including, without limitation, trademarks, logos, images, etc.) are  **not**  included within the Creative Commons license grant. This document does not provide you with any legal rights to any intellectual property in any Microsoft product. You may copy and use this document for your internal, reference purposes.

This document is provided &quot;as-is.&quot; Information and views expressed in this document, including URL and other Internet Web site references, may change without notice. You bear the risk of using it. Some examples are for illustration only and are fictitious. No real association is intended or inferred. Microsoft makes no warranties, express or implied, with respect to the information provided here.