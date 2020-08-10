---
id: load-from-local-disc
url: redaction/net/load-from-local-disc
title: Load from local disc
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
[GroupDocs.Redaction.Redactor](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor) class is a main class in Redaction API, providing functionality to open a document. When document is located on the local disk, you can pass its path to [Redactor](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor)  class constructor.

The following example demonstrates how to open a document from local disc:

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
   // Here we can use document instance to perform redactions   
   redactor.Apply(new DeleteAnnotationRedaction());
   redactor.Save();
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
