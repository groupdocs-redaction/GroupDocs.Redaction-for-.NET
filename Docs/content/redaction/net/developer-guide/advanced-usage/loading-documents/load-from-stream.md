---
id: load-from-stream
url: redaction/net/load-from-stream
title: Load from Stream
weight: 2
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
As an alternative to a local file, [Redac](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor)[t](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor)[or](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor) can open a document from stream.

The following example demonstrates how to load and redact a document using Stream:

**C#**

```csharp
using (Stream stream = File.Open(@"sample.docx", FileMode.Open, FileAccess.ReadWrite))
{
   using (Redactor redactor = new Redactor(stream))
   {
      // Here we can use document instance to make redactions
      redactor.Apply(new DeleteAnnotationRedaction());
      redactor.Save();
   }
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
