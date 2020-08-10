---
id: select-specific-pages-for-rasterized-pdf
url: redaction/net/select-specific-pages-for-rasterized-pdf
title: Select specific pages for rasterized PDF
weight: 5
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
Saving document as a rasterized PDF, you can specify starting page index (zero based) and the number of pages from this index to save. Also, you can change the Compliance level from PDF/A-1b, which is used by default, to PDF/A-1a:

**C#**

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
    RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
    if (result.Status != RedactionStatus.Failed)
    {
        var options = new SaveOptions();
        options.Rasterization.Enabled = true;                           // the same as options.RasterizeToPDF = true;
        options.Rasterization.PageIndex = 5;                            // start from 6th page (index is 0-based)
        options.Rasterization.PageCount = 1;                            // save only one page
        options.Rasterization.Compliance = PdfComplianceLevel.PdfA1a;   // by default PdfComplianceLevel.Auto or PDF/A-1b
        options.AddSuffix = true;
        redactor.Save(options);
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
