---
id: image-redactions
url: redaction/net/image-redactions
title: Image redactions
weight: 9
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
GroupDocs.Redactions prodives a set of features to remove sensitive data from images of various formats like JPG, PNG, TIFF and others. See full list at [supported document formats]({{< ref "redaction/net/getting-started/supported-document-formats.md" >}}) article.

GroupDocs.Redaction since version 21.3 supports two ways of redacting images, both in separate image files and embedded images:
*   You can put a colored box over a given area, such as header, footer, or an area, where customer's data are expected to appear.
*   You can use any 3-rd party OCR engine to process the image, search it for text and redact sensitive data within the image.   

GroupDocs.Redaction for .NET also allows you to change image metadata (e.g. edit EXIF data of an image or act as an "EXIF eraser").

## Redact image area

In order to redact image area, you have to use [ImageAreaRedaction](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/imagearearedaction) class:

**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\test.jpg"))
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

If the redaction cannot be applied to this type of files, e.g. MS Word document without embedded images, [RedactorChangeLog.Status](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactorchangelog/properties/status) will be [RedactionStatus.Skipped](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactionstatus).

## Redact recognized text from an image

To enable OCR-processing and search for a text using regular expressions, you have to implement [IOcrConnector](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration.ocr/iocrconnector) interface and pass the instance to [RedactorSettings](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/redactorsettings) constructor. For more details, see [OCR Usage Basics]({{< ref "redaction/net/developer-guide/advanced-usage/using-ocr/ocr-usage-basics" >}}) article.

**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\test.jpg", new LoadOptions(), new RedactorSettings(new MyCustomOcrConnector())))
{
   RedactorChangeLog result = redactor.Apply(new RegexRedaction("\\d{4}", new ReplacementOptions(System.Drawing.Color.Blue)));
   if (result.Status != RedactionStatus.Failed)
   {
      redactor.Save();
   };
}
```

In the example above **MyCustomOcrConnector** class implements [IOcrConnector](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration.ocr/iocrconnector) interface.

## Clean image metadata

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

If the redaction cannot be applied to this type of files, e.g. BMP image, [RedactorChangeLog.Status](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactorchangelog/properties/status) will be [RedactionStatus.Skipped](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactionstatus).

## Redact embedded images

You can redact image area within all kinds of embedded images inside a document. You can both use [ImageAreaRedaction](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/imagearearedaction) class and any type of [TextRedaction](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/textredaction) (regular expression, exact phrase), if the OCR is enabled in **RedactorSettings** (see [OCR Usage Basics]({{< ref "redaction/net/developer-guide/advanced-usage/using-ocr/ocr-usage-basics" >}}) article). 

The following example demonstrates how to redact all embedded images within a Microsoft Word document:

**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\sample.docx"))
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

If the redaction cannot be applied to this type of files, e.g. a spreadsheet document, [RedactorChangeLog.Status](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactorchangelog/properties/status) will be [RedactionStatus.Skipped](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactionstatus).

## More resources

### Advanced usage topics

To learn more about document redaction features, please refer to the [advanced usage section]({{< ref "redaction/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
