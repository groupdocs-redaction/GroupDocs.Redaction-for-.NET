---
id: get-supported-file-formats
url: redaction/net/get-supported-file-formats
title: Get supported file formats
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
GroupDocs.Redaction allows to get the list of all supported file formats by these steps:

*   Call [GetSupportedFileTypes](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/filetype/methods/getsupportedfiletypes)of [FileType](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/filetype) class;
*   Enumerate through the collection of [FileType](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/filetype)objects*.*

The following example demonstrates how to get supported file formats list.

```csharp
IEnumerable<FileType> supportedFileTypes = FileType
	.GetSupportedFileTypes()
	.OrderBy(f => f.Extension);

foreach (FileType fileType in supportedFileTypes)
	Console.WriteLine(fileType);
```

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
