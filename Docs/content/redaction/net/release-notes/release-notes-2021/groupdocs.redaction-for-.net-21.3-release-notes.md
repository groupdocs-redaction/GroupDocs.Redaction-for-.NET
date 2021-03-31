---
id: groupdocs-redaction-for-net-21-3-release-notes
url: redaction/net/groupdocs-redaction-for-net-21-3-release-notes
title: GroupDocs.Redaction for .NET 21.3 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 21.3{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Redaction of text in images  
    
## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-226 | Redaction of text in images | Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 21.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Redaction of text in images

This feature makes possible redaction of text in image documents and embedded images, using Optical Character Recognition (OCR) tools.

##### Public API changes
                                                                                            
Interface **IOcrConnector** providing methods that are required to apply textual redactions to image documents and embedded images has been **added**.  
Class **RecognizedImage** representing text, extracted from an image has been **added**.  
Class **TextLine** representing a line of text, extracted by OCR engine has been **added**.  
Class **TextFragment** representing a part of recognized text (word, symbol, etc) has been **added**.  

##### Usage

The following example demonstrates how to use an implementation of **IOcrConnector** (e.g. **AsposeOCRForCloudConnector** or any other OCR toolkit connector) to redact embedded images.
 
**C#**

```csharp
            var settings = new RedactorSettings(new MyOwnOcrConnector());
            using (var redactor = new Redactor("FileWithEmbeddedImages.pdf", new LoadOptions(), settings))
            {
                var marker = new ReplacementOptions(Color.Black);
                var result = redactor.Apply(new Redaction[] {
                    new RegexRedaction(@"(?<=Dear\s+)([^,]+)", marker) // person name
                    new RegexRedaction(@"\d{4}", marker)  // card number parts, etc
                });
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save(new SaveOptions(false, "Redacted"));
                }
            }
```



