---
id: get-document-page-preview
url: redaction/net/get-document-page-preview
title: Get document page preview
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---

In GroupDocs.Redaction, [Redactor](https://apireference.groupdocs.com/redaction/net/groupdocs.redaction/redactor) class supports rendering of the document preview in on of these image formats:

*   JPEG Image
*   Portable Network Graphics
*   Bitmap Image File

The following example demonstrates how to get a single page preview of the document.

```csharp
// Take preview of the first page
int testPageNumber = 1;
// Preview file name
string previewFileName = string.Format("{0}_page{1}.png", "D:\\sample.docx", testPageNumber);
// Load the document to generate preview
using (Redactor redactor = new Redactor("D:\\sample.docx"))
{
    PreviewOptions options = new PreviewOptions(delegate(int pageNumber) 
    { 
        return File.OpenWrite(previewFileName); 
    });
    options.Width = 480;
    options.Height = 640;
    options.PageNumbers = new int[] { testPageNumber };
    options.PreviewFormat = PreviewOptions.PreviewFormats.PNG;
    redactor.GeneratePreview(options);
    Console.WriteLine("\nPreview for page {0} was saved to \"{1}\"", testPageNumber, previewFileName);
}
```
