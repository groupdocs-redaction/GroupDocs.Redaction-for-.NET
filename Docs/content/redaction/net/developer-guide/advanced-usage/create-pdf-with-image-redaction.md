---
id: create-pdf-with-image-redaction
url: redaction/net/create-pdf-with-image-redaction
title: Create PDF with Image Redaction
weight: 8
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---

In some cases you might need to redact the pages of a document as images, redacting entire areas of the page instead or in addition to a specific text. With GroupDocs.Redaction you can use the following approach:  

*   open the document and apply all required redactions to the document's body (text, annotations, etc.);
    
*   save it as a rasterized PDF file (containing images of the original document's pages);
    
*   apply ImageAreaRedaction to remove specific areas on the pages within the PDF document.  
    
The following example demonstrates how to create a rasterized PDF from a Microsoft Word document and apply image redactions to its pages:

**C#**

```csharp
var stream = new MemoryStream();
// Rasterize the document before applying redactions
using (var redactor = new Redactor("C:\\Temp\\sample.docx"))
{
    // Perform annotation and textual redactions, if needed
    redactor.Save(stream, new RasterizationOptions() { Enabled = true });
    stream.Seek(0, SeekOrigin.Begin);
}
// Re-open the rasterized PDF document to redact its pages as images
using (var redactor = new Redactor(stream))
{
    RedactorChangeLog result = redactor.Apply(new Redactions.ImageAreaRedaction(new System.Drawing.Point(1160, 2375),
        new RegionReplacementOptions(System.Drawing.Color.Aqua, new System.Drawing.Size(1050, 720))));
    if (result.Status != RedactionStatus.Failed)
    {
        using (var fileStream = File.OpenWrite("C:\\Temp\\sample_docx_Raster.pdf"))
        {
            redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
        }
    }
}
```

Please, note that you don't have to use GroupDocs.Redaction to create a rasterized PDF from an office document. You will be able to use it, if you don't have any other tool for that.

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
