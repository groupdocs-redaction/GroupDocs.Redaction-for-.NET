---
id: save-overwriting-original-file
url: redaction/net/save-overwriting-original-file
title: Save overwriting original file
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
The following example demonstrates how to save the redacted document, replacing an original file:

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    // Here we can use document instance to perform redactions
    RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
    if (result.Status != RedactionStatus.Failed)
    {
        // Save the document in original format overwriting original file
        redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = false });
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
