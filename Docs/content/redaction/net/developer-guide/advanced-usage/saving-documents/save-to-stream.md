---
id: save-to-stream
url: redaction/net/save-to-stream
title: Save to Stream
weight: 6
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
You might need to save a document to any custom file at any location on the local disc or a even a Stream.

The following example demonstrates how to save a document to any location.

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    // Here we can use document instance to perform redactions
    RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
    if (result.Status != RedactionStatus.Failed)
    {
        // Save the document to a custom location and convert its pages to images
        using (Stream fileStream = File.Open(@"C:\\Temp\\sample_output_file.pdf", FileMode.Open, FileAccess.ReadWrite))
        {
            redactor.Save(fileStream, new RasterizationOptions() { Enabled = true });
        }
    }
}

```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
