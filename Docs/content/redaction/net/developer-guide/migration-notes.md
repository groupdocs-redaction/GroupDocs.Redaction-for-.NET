---
id: migration-notes
url: redaction/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
### Why To Migrate?

  
Here are the key reasons to use the new updated API provided by GroupDocs.Redaction for .NET since version 19.9:

*   **Redactor** class introduced as a **single entry point** to manage the document redaction process (instead of **Document**class from previous versions).
    
*   Methods **RedactWith()** of the **Document** class were replaced with similar **Apply()** methods in **Redactor** class.
    
*   Method **Document.Save(Stream, SaveOptions)** was replaced with **Redactor.Save(Stream, RasterizationOptions)**.
*   Constructor **LoadOptions(DocumentFormatConfiguration)** was removed.  
    
*   Exception and option classes were put in separate namespaces.   
    
*   **RedactionSummary** was renamed into **RedactorChangeLog**, **RedactionLogEntry** into **RedactorLogEntry**, **MetadataFilter** into **MetadataFilters**.  
    
*   Obsolete members were removed from Public API.
    
*   Added a number of new exception classes and base exception class for GroupDocs.Redaction exceptions.  
    

### How To Migrate?

The following example demonstrates how to redact Microsoft Office Word document and dumping statuses of applied redactions using old and new API:  

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
    // Here we can use document instance to perform redactions
    RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
	foreach (RedactorLogEntry entry in result.RedactionLog)
	{
		Console.WriteLine(entry.Status.ToString());
	}
	redactor.Save();
}
```

For more code examples and specific use cases please refer to our [Developer Guide]({{< ref "redaction/net/developer-guide/_index.md" >}}) documentation or [GitHub](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET) samples and showcases.
