---
id: groupdocs-redaction-for-net-20-11-release-notes
url: redaction/net/groupdocs-redaction-for-net-20-11-release-notes
title: GroupDocs.Redaction for .NET 20.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 20.11{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Improve PDF preview generation  
    
## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-331 | Improve PDF preview generation | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 20.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Improve PDF preview generation

This feature contains improvements for PDF preview rendering and embedded images redactions.

##### Public API changes
                                                                                            
Interface **IPreviewable** providing methods for getting a general document information and previews has been **added**.  
Class **Redactor** now **implements** interface **IPreviewable**.  


##### Usage

The following example demonstrates how to get a single page preview of the document.
 
**C#**

```csharp
// Take preview of the first page
int testPageNumber = 1;
// Preview file name
string previewFileName = string.Format("{0}_page{1}.png", "D:\\sample.pdf", testPageNumber);
// Load the document to generate preview
using (Redactor redactor = new Redactor("D:\\sample.pdf"))
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
    Console.WriteLine("\nPreview for page: {0} was saved to \"{1}\"", testPageNumber, previewFileName);
}
```


