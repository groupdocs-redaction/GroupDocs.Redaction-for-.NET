---
id: save-in-original-format
url: redaction/net/save-in-original-format
title: Save in original format
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
The following example demonstrates how to save file in its original format with current date as a suffix:

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    // Here we can use document instance to perform redactions
    redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
    // Saving in original format with date as a suffix
    redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false, RedactedFileSuffix = DateTime.Now.ToShortDateString() });
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
