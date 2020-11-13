---
id: groupdocs-redaction-for-net-20-2-release-notes
url: redaction/net/groupdocs-redaction-for-net-20-2-release-notes
title: GroupDocs.Redaction for .NET 20.2 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 20.2{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Ability to edit or erase image metadata  
    

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-236 | Implement metadata redaction for raster images | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 20.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement metadata redaction for raster images

This feature provides functionality to erase or redact the raster image metadata.

##### Public API changes

There are no changes in public API

##### Usage

The following example demonstrates how to edit exif data (erase them) from a photo or any other image:

**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\photo.jpg"))
{
    redactor.Apply(new EraseMetadataRedaction(MetadataFilters.All));
    // Save the document to "*_Redacted.*" file in original format
    redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
}
```
