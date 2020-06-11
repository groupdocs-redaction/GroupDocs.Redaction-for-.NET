---
id: how-to-run-examples
url: redaction/net/how-to-run-examples
title: How to Run Examples
weight: 6
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="warning" >}}Before running an example make sure that GroupDocs.Redaction has been installed successfully.{{< /alert >}}

We offer multiple solutions on how you can run GroupDocs.Redaction examples, by building your own or using our back-end or front-end examples out-of-the-box.

Please choose one from the following list:


## Build project from scratch

*   Open Visual Studio and go to **File** -> **New **\->** Project**.
*   Select appropriate project type - Console App, ASP.NET Web Application etc.
*   Install **GroupDocs.Redaction for .NET **from Nuget or official GroupDocs website following this [guide]({{< ref "redaction/net/getting-started/how-to-run-examples.md" >}}).
*   Code your first application with **GroupDocs.Redaction for .NET **like this
    
    ```csharp
    string documentPath = @"C:\sample.docx"; // NOTE: Put here actual path for your document
    using (Redactor redactor = new Redactor(documentPath))
    {
          // replace with text
          redactor.Apply(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions("[removed]")));
          // replace with blue solid rectangle
          redactor.Apply(new RegexRedaction(@"^\d+[,\.]{1}\d+$", new ReplacementOptions(System.Drawing.Color.Blue)));
          redactor.Save();
    }
    ```
    
*   Build and Run your project. 
*   Redacted document will appear in workingdirectory as *"sample\_Redacted.pdf".*

## Run back-end examples

The complete examples package of **GroupDocs.Redaction** is hosted on [Github](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET). You can either download the ZIP file from [here](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/archive/master.zip) or clone the repository of Github using your favorite git client.  
In case you download the ZIP file, extract the folders on your local disk. The extracted files and folders will look like following image:

![](redaction/net/images/how-to-run-examples.png)

In the extracted Examples folder you can find GroupDocs.Redaction.Examples C# solution file. The project is created in **Microsoft Visual Studio 2017**. The **Resources **folder contains all the sample document and image files used in the examples.  
To run the examples, open the solution file in Visual Studio and build the project. To add missing references of **GroupDocs.Redaction** see [Development Environment, Installation and Configuration](https://docs.groupdocs.com/display/redactionnet/Development+Environment%2C+Installation+and+Configuration). All the functions are called from **RunExamples.cs**.   
Un-comment the function you want to run and comment the rest.

![](redaction/net/images/how-to-run-examples_1.png)

## Contribute

If you like to add or improve an example, we encourage you to contribute to the project. All examples in this repository are open source and can be freely used in your own applications.  
To contribute, you can fork the repository, edit the code and create a pull request. We will review the changes and include it in the repository if found helpful.
