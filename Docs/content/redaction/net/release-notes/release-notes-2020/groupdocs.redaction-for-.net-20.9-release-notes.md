---
id: groupdocs-redaction-for-net-20-9-release-notes
url: redaction/net/groupdocs-redaction-for-net-20-9-release-notes
title: GroupDocs.Redaction for .NET 20.9 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Redaction for .NET 20.9{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Ability to save Redaction Policy to an XML file  
*   Built-in support for plain text format (previously was an example)  
*   Support for HTML documents and Markdown files  
    

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| REDACTIONNET-305 | Saving RedactionPolicy.xml file in .NET | Improvement |
| REDACTIONNET-314 | Add built-in support for plain text format | Improvement |
| REDACTIONNET-315 | Add support for HTML documents and Markdown files | Improvement |


## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Redaction for .NET 20.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Redaction which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Saving RedactionPolicy.xml file in .NET

This feature provides functionality to save a redaction policy created in code as an XML file for further use.

### Add built-in support for plain text format

This feature provides built-in support for plain text format. Previously, user had to take the class from public examples and configure it as a custom format handler.

### Add support for HTML documents and Markdown files

This feature provides support for HTML documents and Markdown files.

##### Public API changes
                                                                                            
Constructor **RedactionPolicy(Redaction[])** taking an array of redactions has been **added**.  
Methods **RedactionPolicy.Save(String)** and **RedactionPolicy.Save(Stream)** have been **added**.  


##### Usage

The following example demonstrates how to save a [RedactionPolicy](https://apireference.groupdocs.com/redaction/net/groupdocs.redaction/redactionpolicy) to an XML file.
 
**C#**

```csharp
RedactionPolicy policy = new RedactionPolicy(new Redaction[] {
    new ExactPhraseRedaction("Redaction", new ReplacementOptions("[Product]")),
    new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)),
    new DeleteAnnotationRedaction(),
    new EraseMetadataRedaction(MetadataFilters.All)
});
policy.Save(".\\MyPolicyFile.xml");
```


