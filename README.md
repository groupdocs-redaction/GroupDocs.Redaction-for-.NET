[Product Page](https://products.groupdocs.com/redaction/net) | [Docs](https://docs.groupdocs.com/redaction/net) | [Free Web Demo](https://products.groupdocs.app/redaction/family) | [API Reference](https://apireference.groupdocs.com/redaction/net) | [Blog](https://blog.groupdocs.com/category/redaction/) | [Search](https://search.groupdocs.com/) | [Free Support](https://forum.groupdocs.com/c/redaction) | [Temporary License](https://purchase.groupdocs.com/temporary-license)

# GroupDocs.Redaction-for-.NET

[![banner](https://raw.githubusercontent.com/groupdocs/groupdocs.github.io/master/img/banners/groupdocs-redaction-net-banner.png)](https://releases.groupdocs.com/conversion/python-net/)

[GroupDocs.Redaction for .NET](https://products.groupdocs.com/redaction/net) is a reliable tool for protecting sensitive information in business documents of many formats. With this API, you can redact text, images, metadata, annotations, and other hidden content to ensure your files remain secure before sharing or archiving. 

<br>
<p align="center">
  <a title="Download complete GroupDocs.Redaction for .NET source code" href="https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>
<br>

Directory | Description
--------- | -----------
[Demos](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Demos)  | Contains demo projects that demonstrate product features.
[Examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Examples)  | Contains С# code samples and example files to help you quickly learn and test API features. 
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
**Environment:** .NET Framework 4.6.2+, .NET Core 3.1+, NET6.0+

## Get Started

1. **Set Up Environment**: Ensure that .NET Framework 4.6.2+, .NET Core 3.1+, or NET6.0+ are installed on your system.

2. **Get the solution**: Clone or download this repository.

   ```bash
   git clone git@github.com:groupdocs-redaction/GroupDocs.Redaction-for-.NET.git
   ```

3. **Install Package**: To install the package, use NuGet packages manager or call package install command in console. Alternatively, you can download packages from the official [GroupDocs Releases](https://releases.groupdocs.com/redaction/net/#direct-download) website.
   
   ```bash
   dotnet add package GroupDocs.Redaction
   ```

4. **Open examples solution in Visual Studio**

   ```bash
   GroupDocs.Redaction-for-Python-via-.NET/Examples/GroupDocs.Redaction.Examples.CSharp.sln
   ```

5. **Configure License (Optional)**: If you have a license file, you can set the license path in the `Constants.cs` file. You can also [get a temporary license](https://purchase.groupdocs.com/temporary-license) to test all the features.

6. **Run the Examples**: It is much easier to run examples using Visual Studio.  You can also build solution and run examples using command prompt or other tools.

7. **Check results**: Redacted files are saved in the folder like this `Examples\GroupDocs.Redaction.Examples.CSharp.Core\bin\Output` accordingly to used framework.

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

[Product Page](https://products.groupdocs.com/redaction/net) | [Docs](https://docs.groupdocs.com/redaction/net) | [Free Web Demo](https://products.groupdocs.app/redaction/family) | [API Reference](https://apireference.groupdocs.com/redaction/net) | [Blog](https://blog.groupdocs.com/category/redaction/) | [Search](https://search.groupdocs.com/) | [Free Support](https://forum.groupdocs.com/c/redaction) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
