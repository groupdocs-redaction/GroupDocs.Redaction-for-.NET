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
This method can be used when for some reason files have non-standard extensions or if its format is supported, but not pre-configured. For instance, all kinds of plain text files (batch, command files, etc.) could be opened. In this case you do not need to create your own format handler. As it is shown below, you can add file extension (e.g. ".dump") as being handled by the same *[DocumentFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance)* as all plain text files:

**C#**

```csharp
var config = RedactorConfiguration.GetInstance();
var settings = config.FindFormat(".txt");
settings.ExtensionFilter = settings.ExtensionFilter + ",.dump";
using (Redactor redactor = new Redactor(@"C:\sample.dump"))
{
   // Here we can use the document instance to perform redactions
}
```

In detail, creating your own document format instances is covered in another article.

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
