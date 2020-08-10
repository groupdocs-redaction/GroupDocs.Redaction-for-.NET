---
id: save-with-default-options
url: redaction/net/save-with-default-options
title: Save with default options
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
The simplest way to save the document is it provide no parameters to [Save](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor/methods/save) method. In this case the document will be rasterized to PDF and will have the same name as the original one except its extension (.PDF). The PDF file will be overwritten.

The following example demonstrates usage of [Save()](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor/methods/save) method with default options.

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    // Here we can use document instance to perform redactions
    redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
    // Save the document with default options (convert pages into images, save as PDF)
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
