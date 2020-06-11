---
id: groupdocs-redaction-for-net-19-12-release-notes
url: redaction/net/groupdocs-redaction-for-net-19-12-release-notes
title: GroupDocs.Redaction for .NET 19.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 19.12{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Support for .NET Standard 2.0 
*   Redactor settings including logging interface

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-234 | Provide implementation for .NET Standard 2.0 | Improvement |
| REDACTIONNET-235 | Implement standard logging interface | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 19.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement standard logging interface

Implement standard logging interface for GroupDocs projects.

##### Public API changes   

Class **RedactorSettings** has been added to **GroupDocs.Redaction.Options**namespace.  
Interface **ILogger** has been added to **GroupDocs.Redaction.Options**namespace.  
Property **Redactor.RedactionCallback** has been declared **obsolete**.  
Method **IsRedactionAccepted(RedactionDescription)**  has been added to **GroupDocs.Redaction.Integration.DocumentFormatInstance**class.  
Method **AddRange(MetadataCollection)**  has been added to **GroupDocs.Redaction.Integration.MetadataCollection**class.  
Constructors, accepting **RedactionSettings** have been added to **GroupDocs.Redaction.Redactor** class.  
Method **DocumentFormatInstance.Initialize()**  now requires an instance of**RedactorSetting**as a second parameter.  
Property **String Description** has been added to **GroupDocs.Redaction.Redaction** class.  
  

##### Usecases

The following example demonstrates how to set instances of **MyCustomLogger** and **MyRedactionCallback** classes:

**C#**

```csharp
using (Redactor redactor = new Redactor("\\SampleFile.doc", new LoadOptions(), 
	new RedactorSettings(new MyCustomLogger(), new MyRedactionCallback())))
{
    redactor.Apply(new ExactPhraseRedaction("John Doe"), new ReplacementOptions(Color.Red));
    redactor.Save();
}
```
