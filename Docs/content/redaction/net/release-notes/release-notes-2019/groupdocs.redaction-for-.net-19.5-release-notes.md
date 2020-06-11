---
id: groupdocs-redaction-for-net-19-5-release-notes
url: redaction/net/groupdocs-redaction-for-net-19-5-release-notes
title: GroupDocs.Redaction for .NET 19.5 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 19.5{{< /alert >}}

## Major Features

There are the following improvements in this release:Extend SaveOptions to control conversion to PDF

*   Extended SaveOptions to control conversion to PDF
*   Implemented method to retrieve credit consumption info

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-166 | Extend SaveOptions to control conversion to PDF | Improvement |
| REDACTIONNET-175 | Implement method to retrieve credit consumption info | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Extend SaveOptions to control conversion to PDF

Add ability to specify page range and PDF compliance level.

##### Public API changes

Class **RasterizationOptions** has been added to **GroupDocs.Redaction**namespace.  
Property **RasterizationOptions Rasterization** has been added to **GroupDocs.Redaction.SaveOptions** class.  
Method **Rasterize(System.IO.Stream, RasterizationOptions)**  has been added to **GroupDocs.Redaction.Integration.IRasterizableDocument**interface.  
Enumeration **PdfComplianceLevel**has been added to **GroupDocs.Redaction** namespace.

##### Usecases

This example shows how to use RasterizationOptions class:

**C#**

```csharp
using (Document doc = Redactor.Load("D:\\Temp\\SampleFile.doc")))
{
    RedactionSummary result = doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
    if (result.Status != RedactionStatus.Failed)
    {
   	  	using (Stream fileStream = File.Open("D:\\Temp\\Output.pdf", FileMode.Open, FileAccess.ReadWrite))
   	  	{
            var options = new SaveOptions();
            options.Rasterization.Enabled = true; 							// the same as options.RasterizeToPDF = true;
            options.Rasterization.PageIndex = 5;  							// start from 5th page
            options.Rasterization.PageCount = 1;  							// save only one page
            options.Rasterization.Compliance = PdfComplianceLevel.PdfA1a;   // by default PdfComplianceLevel.Auto or PDF/A-1b
            doc.Save(fileStream, options);
   	  	}
    }
}
```

### Implement method to retrieve credit consumption info

Add method to retrieve credit consumption info.

##### Public API changes

Method **GetConsumptionCredit()**  has been added to **GroupDocs.Redaction.Metered** class.

##### Usecases

This example shows how to use **GetConsumptionCredit()** method:

**C#**

```csharp
GroupDocs.Redaction.Metered metered = new GroupDocs.Redaction.Metered();
metered.SetMeteredKey(publicKey, privateKey);
// get credit consumption
decimal creditsConsumed = metered.GetConsumptionCredit();
```
