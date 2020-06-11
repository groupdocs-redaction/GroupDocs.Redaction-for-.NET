---
id: groupdocs-redaction-for-net-19-3-release-notes
url: redaction/net/groupdocs-redaction-for-net-19-3-release-notes
title: GroupDocs.Redaction for .NET 19.3 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 19.3.{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Support for raster image formats and image region redactions 
*   Ability to specify a set of redaction rules (policy) in XML file
*   Improved information concerning redaction application status

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-115 | Add support for image formats and region redactions | Feature |
| REDACTIONNET-6 | Implement Configurable Redaction | Feature |
| REDACTIONNET-144 | Redesign redaction reporting | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 19.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement Configurable Redaction

Implement mechanism to configure redactions in XML and apply them to any document as a single redaction profile.

##### Public API changes

Class **RedactionPolicy** has been added to **GroupDocs.Redaction.Configuration**namespace.  
Method **Load(System.String)** has been added to **GroupDocs.Redaction.Configuration.RedactionPolicy** class.  
Method **Load(System.IO.Stream)**  has been added to **GroupDocs.Redaction.Configuration.RedactionPolicy**class.  
Property **Redaction\[\] Redactions**has been added to **GroupDocs.Redaction.Configuration.RedactionPolicy** class.

##### Usecase

This example shows how to use **RedactionPolicy** class:

**C#**

```csharp
RedactionPolicy policy = RedactionPolicy.Load("RedactionPolicy.xml");
foreach (var fileEntry in Directory.GetFileNames("C:\\Inbound")) 
{
    using (Document doc = Redactor.Load(Path.Combine("C:\\Inbound\\", fileEntry)))
	{
    	RedactionSummary result = doc.RedactWith(policy.Redactions);
        String resultFolder = result.Status != RedactionStatus.Failed ? "C:\\Outbound\\Done\\" : "C:\\Outbound\\Failed\\";
		using (Stream fileStream = File.Open(Path.Combine(resultFolder, fileEntry), FileMode.Open, FileAccess.ReadWrite))
   		{
      		doc.Save(fileStream, new SaveOptions() { RasterizeToPDF = false, RedactedFileSuffix = DateTime.Now.ToString() });
      		fileStream.Close();
   		}        
	}
}   
```

### Support for image formats and region redactions

Added support for image formats and region redactions.

##### Public API changes

Value **ImageArea** has been added to **GroupDocs.Redaction.Redactions.RedactionType** enum.

Class **RegionReplacementOptions** has been added to **GroupDocs.Redaction.Redactions**namespace.  
Property **System.Drawing.Color FillColor** has been added to **GroupDocs.Redaction.Redactions.RegionReplacementOptions** class.  
Property **System.Drawing.Size Size** has been added to **GroupDocs.Redaction.Redactions.RegionReplacementOptions** class.

Interface **IImageFormatInstance** has been added to **GroupDocs.Redaction.Integration** namespace.  
Method **EditArea(System.Drawing.Point, RegionReplacementOptions)** has been added to **GroupDocs.Redaction.Integration**.**IImageFormatInstance** interface.

Class **ImageAreaRedaction** inheriting from **Redaction** class has been added to **GroupDocs.Redaction.Redactions** namespace.  
Method **EditArea** has been added to **GroupDocs.Redaction.Redactions.ImageAreaRedaction** class as an implementation of **GroupDocs.Redaction.Integration**.**IImageFormatInstance** interface.  
Property **RegionReplacementOptions Options**  has been added to **GroupDocs.Redaction.Redactions.ImageAreaRedaction** class.  
Property **System.Drawing.Point TopLeft** has been added  to **GroupDocs.Redaction.Redactions.ImageAreaRedaction** class.

##### Usecase

This example shows how to use **ImageAreaRedaction** class:

**C#**

```csharp
using (Document doc = Redactor.Load("D:\\test.jpg"))
{
   System.Drawing.Point samplePoint = new System.Drawing.Point(516, 311);
   System.Drawing.Size sampleSize = new System.Drawing.Size(170, 35);
   RedactionSummary result = doc.RedactWith(new ImageAreaRedaction(samplePoint,
                new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
   if (result.Status != RedactionStatus.Failed)
   {
      doc.Save();
   };
}
```

### Redesign redaction reporting

Refactor/redesign **RedactionResult** to reflect at least following options:

*   Redaction ran without errors, but was rejected by user.
*   Redaction could not run because it is not applicable to this type of files.

##### Public API changes

Constant **String RejectionMessage** has been added to **GroupDocs.Redaction.Integration.DocumentFormatInstance** class.

Enum **RedactionStatus** has been added to **GroupDocs.Redaction**namespace.  
Value **Applied** has been added to **GroupDocs.Redaction.RedactionStatus** enum.  
Value **PartiallyApplied** has been added to **GroupDocs.Redaction.RedactionStatus** enum.  
Value **Skipped** has been added to **GroupDocs.Redaction.RedactionStatus** enum.  
Value **Failed** has been added to **GroupDocs.Redaction.RedactionStatus** enum.

Class **RedactionLogEntry** has been added to **GroupDocs.Redaction**namespace.  
Property **RedactionResult Result**  has been added to **GroupDocs.Redaction.RedactionLogEntry**class.  
Property **Redaction Redaction** has been added to **GroupDocs.Redaction.RedactionLogEntry**class.

Property **RedactionStatus Status** has been added to **GroupDocs.Redaction.RedactionSummary** class.  
Property **Systrem.Boolean Success** has been declared warning-level OBSOLETE in **GroupDocs.Redaction.RedactionSummary** class.

Property **RedactionStatus Status** has been added to **GroupDocs.Redaction.RedactionResult** class.  
Property **Systrem.Boolean Success** has been declared warning-level OBSOLETE in **GroupDocs.Redaction.RedactionResult** class.  
Public constructor of **GroupDocs.Redaction.RedactionResult** class has been declared private and is no longer available to users.  
Static factory method **Successful()**  has been added to **GroupDocs.Redaction.RedactionResult** class.  
Static factory method **Skipped(System.String)**  has been added to **GroupDocs.Redaction.RedactionResult** class.  
Static factory method **Partial(System.String)**  has been added to **GroupDocs.Redaction.RedactionResult** class..  
Static factory method **Failed(System.String)**  has been added to **GroupDocs.Redaction.RedactionResult** class.

##### Usecase

Instead of *RedactionSummary.Success* or *RedactionResult.Success*, declared as obsolete, users have to use corresponding Status property. This example shows how to use Status property:

**C#**

```csharp
RedactionSummary summary = doc.redactWith(...);
if (summary.Status != RedactionStatus.Applied)
{
	for (int i = 0; i < summary.RedactionLog.Count; i++)
	{
		RedactionLogEngtry logEntry = summary.RedactionLog[i];
    	if (logEntry.Result.Status != RedactionStatus.Applied)
        {
			Console.WriteLine("{0} status is {1}, details: {2}", 
				logEntry.Redaction.GetType().Name, // Dump/analyze redaction settings here, if needed
				logEntry.Result.Status, 
				logEntry.Result.ErrorMessage);
		}
	}
}
```
