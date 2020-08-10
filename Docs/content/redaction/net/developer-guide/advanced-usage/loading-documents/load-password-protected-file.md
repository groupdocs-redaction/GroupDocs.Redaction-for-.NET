---
id: load-password-protected-file
url: redaction/net/load-password-protected-file
title: Load password-protected file
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
In order to open password-protected documents, you have to pass your password to [LoadOptions](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/loadoptions) class constructor or assign it to its [Password](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/loadoptions/properties/password) property of an instance of [LoadOptions](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/loadoptions) class:

**C#**

```csharp
LoadOptions loadOptions = new LoadOptions("mypassword");
using (Redactor redactor = new Redactor(@"protected_sample.docx", loadOptions))
{
   // Here we can use document instance to perform redactions
   redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
   redactor.Save();
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
