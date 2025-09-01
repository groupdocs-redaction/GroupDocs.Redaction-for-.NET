# GroupDocs.Redaction-for-.NET

[GroupDocs.Redaction for .NET](https://products.groupdocs.com/redaction/net) is a reliable tool for protecting sensitive information in business documents of many formats. With this API, you can redact text, images, metadata, annotations, and other hidden content to ensure your files remain secure before sharing or archiving. 

<p align="center">
  <a title="Download complete GroupDocs.Redaction for .NET source code" href="https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Examples)  | Contains С№ code samples and example files to help you quickly learn and test API features. 
[Plugins](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Plugins/GroupDocsRedactionVSPlugin) | Contains Visual Studio Add-in to explore GroupDocs.Redaction for .NET examples.

## Document Redaction Features

- Remove private or confidential content from [30+ different file formats](https://docs.groupdocs.com/redaction/net/supported-document-formats).
- Clear document metadata, comments, and annotations.
- Create a rasterized PDF version of redacted files for stronger protection.
- Preserve the original file format after redaction.
- Apply redaction to a specific worksheet or column in spreadsheets.
- Change PDF compliance from PDF/A-1b to PDF/A-1a when saving as rasterized PDF.

## Supported Redaction Types

**Text:** Replace or hide sensitive text in the document body with a colored overlay.\
**Image:** Cover selected image areas with a solid color.\
**Metadata:** Remove or replace metadata fields.\
**Annotation:** Delete or redact document annotations.

## Develop & Deploy Anywhere

**Operation Systems:** Windows, Linux, Mac OS\
**Supported IDE:** Microsoft Visual Studio, JetBrains Rider, Microsoft Visual Code\
**Environment:** .NET Framework 4.6.2 or higher, .NET Core 3.1 or higher

## How to Run Examples

Install the package with: `Install-Package GroupDocs.Redaction` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Redaction assembly in your project. 
Upgrade to the latest version with: `Update-Package GroupDocs.Redaction` to get the latest version.
Run the examples using: `RunExamples.cs` in appropriate project.
Redacted files are saved in the  `\bin\Output` folder.

## Example: Case-Sensitive Phrase Redaction in DOCX

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
  redactor.Apply(new ExactPhraseRedaction("John Doe", true /*isCaseSensitive*/, new ReplacementOptions("[personal]")));
  redactor.Save();
}
```

## Example: Redact Strings in PDF Annotations

```csharp
using (Redactor redactor = new Redactor(@"C:\test.pdf"))
{
   redactor.Apply(new AnnotationRedaction("(?im:john)", "[redacted]"));

   redactor.Save()
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/redaction/net) | [Documentation](https://docs.groupdocs.com/redaction/net) | [Demo](https://products.groupdocs.app/redaction/family) | [API Reference](https://apireference.groupdocs.com/redaction/net) | [Examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET) | [Blog](https://blog.groupdocs.com/category/redaction/) | [Search](https://search.groupdocs.com/) | [Free Support](https://forum.groupdocs.com/c/redaction) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
