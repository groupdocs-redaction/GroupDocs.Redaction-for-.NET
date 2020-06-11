---
id: groupdocs-redaction-for-net-19-9-release-notes
url: redaction/net/groupdocs-redaction-for-net-19-9-release-notes
title: GroupDocs.Redaction for .NET 19.9 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 19.9{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version we're introducing new public API which was designed to be simple and easy to use. For more details about new API please check Public Docs section. The legacy API has been completely removed and is no longer available.{{< /alert >}}

## Public API and Backward Incompatible Changes

Here are the key reasons to use the new updated API provided by GroupDocs.Redaction for .NET since version 19.9:

*   **Redactor** class was introduced as a **single entry point** to manage the document redaction process (instead of **Document**class from previous versions).
    
*   Methods **RedactWith()** of the **Document** class were replaced with similar **Apply()** methods in **Redactor** class. 
    
*   Method **Document.Save(Stream, SaveOptions)** was replaced with **Redactor.Save(Stream, RasterizationOptions)**.
*   Constructor **LoadOptions(DocumentFormatConfiguration)** was removed.  
    
*   Exception and option classes were put in separate namespaces.   
    
*   **RedactionSummary** was renamed into **RedactorChangeLog**, **RedactionLogRecord** into **RedactorLogRecord**, **MetadataFilter** into **MetadataFilters**.  
    
*   Obsolete members were removed from public API.
    
*   Added a number of new exception classes and a base exception class for GroupDocs.Redaction exceptions.

##### Public API changes

Class **DocumentFormatException** has been moved to **GroupDocs.Redaction.Exceptions**namespace.  
Class **IncorrectPasswordException** has been added to **GroupDocs.Redaction.Exceptions**namespace.   
Class **PasswordRequiredException** has been added to **GroupDocs.Redaction.Exceptions**namespace.   
Class **TrialLimitationsException** has been moved to **GroupDocs.Redaction.Exceptions**namespace.  
Class **GroupDocsRedactionException** has been added to **GroupDocs.Redaction.Exceptions**namespace.  
Class **LoadOptions** has been moved to **GroupDocs.Redaction.Options**namespace.  
Class **RasterizationOptions** has been moved to **GroupDocs.Redaction.Options**namespace.  
Class **Save****Options** has been moved to **GroupDocs.Redaction.Options**namespace.  
Class **PreviewOptions** has been added to **GroupDocs.Redaction.Options**namespace.  
Delegate **CreatePageStream** has been added to **GroupDocs.Redaction.Options**namespace.  
Delegate **ReleasePageStream** has been added to **GroupDocs.Redaction.Options**namespace.  
EnumerationEnumeration **PdfComplianceLevel**has been moved to **GroupDocs.Redaction.Options** namespace.  
Overloaded methods **Load(...)** have been replaced with constructors of **GroupDocs.Redaction.Redactor** class.  
Class **Document** has been removed from public API.  
Property **FormatConfiguration** has been removed from **LoadOptions** class.  
Overloaded methods **RedactWith(...)** of the **Document** class has been replaced with **Apply(...)** methods of the**GroupDocs.Redaction.Redactor** class.  
Overloaded methods **DetermineFormat(...)**  have been removed from public API.  
Obsolete property **IsValidLicense** has been removed from**GroupDocs.Redaction.License**class.  
Method **GetDocumentInfo()**  has been added to **GroupDocs.Redaction.Redactor**class.  
Method **GeneratePreview(GroupDocs.Redaction.Options.PreviewOptions)** has been added to **GroupDocs.Redaction.Redactor**class.  
Method **SetAccessGranted(System.Boolean)** has been added to **GroupDocs.Redaction.Integration.DocumentFormatInstance**class.  
Class **RedactionSummary**has been renamed into **RedactorChangeLog**.  
Class **RedactionLogEntry**has been renamed into **RedactorLogEntry**.  
Obsolete property **Success** has been removed from**GroupDocs.Redaction.RedactionResult**class.  
Obsolete property**Success** has been removed from**GroupDocs.Redaction.RedactorChangeLog**class.  
Flagged enumeration **MetadataFilter**has been renamed into **MetadataFilters**.  
Class **RedactionPolicy** has been moved to **GroupDocs.Redaction**namespace.  
Interface **IDocumentInfo**has been added to **GroupDocs.Redaction** namespace.  
Class **DocumentInfo** has been added to **GroupDocs.Redaction**namespace.  
Class **FileType**has been added to **GroupDocs.Redaction** namespace.  
Class **PageInfo**has been added to **GroupDocs.Redaction** namespace.  
Method **Rasterize(System.IO.Stream, RasterizationOptions)**  has been added to **GroupDocs.Redaction.Integration.IRasterizableDocument**interface.

##### Usecases

The following example demonstrates how to redact Microsoft Office Word document and dumping statuses of applied redactions using the old and new API:

**Old coding style**

```csharp
using (Document doc = Redactor.Load(@"Documents/Doc/sample.docx"))
{
    // Here we can use document instance to perform redactions
	RedactionSummary summary = doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
	foreach (RedactionLogEntry entry in summary.RedactionLog)
	{
		Console.WriteLine(entry.Status.ToString());
	}
    doc.Save();
}
```

**New coding style**

```csharp
using (Redactor redactor = new Redactor(@"Documents/Doc/sample.docx"))
{
    // Here we can use Redactor instance to perform redactions
    RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
	foreach (RedactorLogEntry entry in result.RedactionLog)
	{
		Console.WriteLine(entry.Status.ToString());
	}
	redactor.Save();
}
```
