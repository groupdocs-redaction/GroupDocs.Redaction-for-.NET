---
id: extend-supported-extensions-list
url: redaction/net/extend-supported-extensions-list
title: Extend supported extensions list
weight: 6
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
This method can be used when for some reason files have non-standard extensions or if its format is supported, but not pre-configured. For instance, all kinds of plain text files (logs, dumps etc) could be opened with text processors like MS Word/Open Office. In this case you do not need to create your own format handler. As it is shown below, you can add file extension (e.g. ".log") as being handled by the same *[DocumentFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance)* as MS Word files:

**C#**

```csharp
var config = RedactorConfiguration.GetInstance();
var docxSettings = config.FindFormat(".docx");
docxSettings.ExtensionFilter = docxSettings.ExtensionFilter + ",.log";
using (Redactor redactor = new Redactor(@"C:\sample.log"))
{
   // Here we can use document instance to perform redactions
}
```

In detail, creating your own document format instances is covered in another article.

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document parser App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
