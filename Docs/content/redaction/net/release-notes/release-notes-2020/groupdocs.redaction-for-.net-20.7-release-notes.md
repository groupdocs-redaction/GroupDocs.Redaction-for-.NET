---
id: groupdocs-redaction-for-net-20-7-release-notes
url: redaction/net/groupdocs-redaction-for-net-20-7-release-notes
title: GroupDocs.Redaction for .NET 20.7 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 20.7{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Ability to redact embedded images in PDF, textual and presentation documents  
    

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-279 | Allow ImageAreaRedaction to be applied to rasterized PDF | Improvement |
| REDACTIONNET-285 | Add support for embedded image redaction with Aspose.Words | Improvement |
| REDACTIONNET-286 | Add support for embedded image redaction with Aspose.Slides | Improvement |


## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 20.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Allow ImageAreaRedaction to be applied to rasterized PDF

This feature provides functionality to apply ImageAreaRedaction to any embedded image inside PDF document, including resterized PDF files.

### Add support for embedded image redaction with Aspose.Words

This feature provides functionality to apply ImageAreaRedaction to any embedded image inside Microsoft Office Word or Open Office document.

### Add support for embedded image redaction with Aspose.Slides

This feature provides functionality to apply ImageAreaRedaction to any embedded image inside Microsoft Office PowerPoint or Open Office presentation.

##### Public API changes

Obsolete property **Redactor.RedactionCallback** has been **removed**.  

##### Usage

The following example demonstrates how to apply an [ImageAreaRedaction](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/imagearearedaction) to all embedded images within a PDF document.
 
**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\test_with_embedded_images.pdf"))
{
   System.Drawing.Point samplePoint = new System.Drawing.Point(516, 311);
   System.Drawing.Size sampleSize = new System.Drawing.Size(170, 35);
   RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
   if (result.Status != RedactionStatus.Failed)
   {
      redactor.Save();
   };
}
```

The following example demonstrates how to create a rasterized PDF from a Microsoft Word document and apply image redactions to its pages

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
