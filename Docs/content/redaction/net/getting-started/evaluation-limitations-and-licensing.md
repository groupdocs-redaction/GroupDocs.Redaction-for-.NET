---
id: evaluation-limitations-and-licensing
url: redaction/net/evaluation-limitations-and-licensing
title: Evaluation Limitations and Licensing
weight: 5
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}You can use GroupDocs.Redaction without the license. The usage and functionalities are pretty much same as the licensed one but you will face few limitations while using the non-licensed API.{{< /alert >}}

## Evaluation Limitations

You can easily download GroupDocs.Redaction for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. You will face following limitations while using the API without the license:  

*   Only 1 document can be opened in one process.
*   Only 1 redaction can be applied to the document.
*   Any redaction is limited to 4 replacements/deletions, even if there are more matches.
*   Trial badges are placed in the document on the top of each page.

## Licensing

The license file contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. It contains the digital signature, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing GroupDocs.Redaction API if you want to avoid its evaluation limitations.   
The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the GroupDocs.Redaction.dll file and specify the file name, without a path, as shown in the examples below.

#### Applying License from File

The code below will explain how to apply product license.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET
// Setup the license.
License lic = new License();
lic.SetLicense(licensePath);
```

#### Applying License from Stream

The following example shows how to load a license from a stream.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET
using (FileStream fileStream = new FileStream("GroupDocs.Redaction.lic", FileMode.Open, FileAccess.Read))
{
    License lic = new License();
    lic.SetLicense(fileStream);
}
```

{{< alert style="info" >}}Calling License.SetLicense multiple times is not harmful but simply wastes processor time. If you are developing a Windows Forms or console application, call License.SetLicense in your startup code, before using GroupDocs.Redaction classes. When developing an ASP.NET application, you can call License.SetLicense from the Global.asax.cs (Global.asax.vb) file in the Application_Start protected method. It is called once when the application starts.Do not call License.SetLicense from within Page_Load methods since it means the license will be loaded every time a web page is loaded.{{< /alert >}}

#### Applying Metered License

{{< alert style="info" >}}You can also set Metered license as an alternative to license file. It is a new licensing mechanism that will be used along with existing licensing method. It is useful for the customers who want to be billed based on the usage of the API features. For more details, please refer to Metered Licensing FAQ section.{{< /alert >}}

Here are the simple steps to use the `Metered` class.

1.  Create an instance of `Metered` class.
2.  Pass public & private keys to S`etMeteredKey` method.
3.  Do processing (perform task).
4.  call method G`etConsumptionQuantity` of the `Metered` class.
5.  It will return the amount/quantity of API requests that you have consumed so far.
6.  call method G`etConsumptionCredit` of the `Metered` class (Since version 19.5).
7.  It will return the credit that you have consumed so far.

Following is the sample code demonstrating how to use `Metered` class.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET
string publicKey = ""; // Your public license key
string privateKey = ""; // Your private license key

Metered metered = new Metered();
metered.SetMeteredKey(publicKey, privateKey);

// Apply redaction to a document
using (Redactor redactor = new Redactor("D:\\test.docx"))
{
   RedactorChangeLog result = redactor.Apply(new RegexRedaction(LookupStrings.SSNRegexPattern, new ReplacementOptions("[ssn]")));
   if (result.Status != RedactionStatus.Failed)
   {
      redactor.Save();
   };
}

// Get metered consumption quantity after usage of the comparison
decimal amountAfter = GroupDocs.Redaction.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount (MB) consumed: " + amountAfter);

// Get metered consumption credit
decimal creditAfter = GroupDocs.Redaction.Metered.GetConsumptionCredit();
Console.WriteLine("Credits consumed: " + creditAfter);
```
