---
id: save-in-rasterized-pdf
url: redaction/net/save-in-rasterized-pdf
title: Save in rasterized PDF
weight: 2
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
The following example demonstrates how to save the document as a rasterized PDF file:

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    // Here we can use document instance to perform redactions
    redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
    // Saving ias rasterized PDF with no suffix in file name
    redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = true });
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
