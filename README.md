# Redaction API to Secure Classified Data

[GroupDocs.Redaction for .NET](https://products.groupdocs.com/redaction/net) is an on-premise API for removing sensitive and classified information from the documents of different file formats. The API provides a single format-independent interface supports text redaction, metadata redaction, annotation redaction, and tabular document redaction. 

<p align="center">

  <a title="Download complete GroupDocs.Redaction for .NET source code" href="https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Examples)  | Contains the package of all .NET examples (C#) and sample files that will help you learn how to use API features. 
[Plugins](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET/tree/master/Plugins/GroupDocsRedactionVSPlugin) | Contains Visual Studio Add-in to explore GroupDocs.Redaction for .NET examples.

## Document Redaction Processing Features

- Remove classified or sensitive information from [25+ different file formats](https://docs.groupdocs.com/redaction/net/supported-document-formats).
- Remove document metadata, comments and annotations.
- Make a rasterized PDF version of the redacted document for better security.
- Keep the document in its original format after the redaction process.
- Set the redaction scope to a specific worksheet or column.
- Modify compliance level from PDF/A-1b to PDF/A-1a during rasterizing PDF.

## Supported Redaction Types

**Text:** Replace or hide a textual area within the document body with a colored block.\
**Metadata:** Replace metadata values with empty ones or redact metadata values.\
**Annotation:** Remove annotations from the document or redact their content.\
**Image:** Replace specific area of an image with a colored box.

## Document Body & Metadata Redaction Formats

**Microsoft Word:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, RTF\
**Microsoft Excel:** XLSX, XLSM, XLTX, XLTM, XLS, XLT, CSV\
**Microsoft PowerPoint:** PPT, PPTX, PPSX, POT, PPS, PPTM, PPSM, POTM\
**Image:** JPEG, TIF, TIFF, PNG, BMP, GIF\
**Fixed Layout:** PDF

## Annotations & Comments Redaction Formats

**Microsoft Word:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, RTF\
**Microsoft Excel:** XLSX, XLSM, XLTX, XLTM, XLS, XLT, CSV\
**Microsoft PowerPoint:** PPT, PPTX, PPSX, POT, PPS, PPTM, PPSM, POTM\
**Fixed Layout:** PDF

## Develop & Deploy GroupDocs.Redaction Anywhere

**Microsoft Windows:** Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop 2.4 and later\
**Supported Frameworks:** .NET Framework 2.0 or higher, .NET Standard 2.0, .NET Core 2.0 or higher

## Get Started with GroupDocs.Redaction for .NET

Are you ready to give GroupDocs.Redaction for .NET a try? Simply execute `Install-Package GroupDocs.Redaction` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Redaction assembly in your project. If you already have GroupDocs.Redaction for .NET and want to upgrade it, please execute `Update-Package GroupDocs.Redaction` to get the latest version.

## Perform Exact Phrase, Case Sensitive Redaction on DOCX

```csharp
using (Redactor redactor = new Redactor(@"sample.docx"))
{
  redactor.Apply(new ExactPhraseRedaction("John Doe", true /*isCaseSensitive*/, new ReplacementOptions("[personal]")));
  redactor.Save();
}
```

## Redact Specific String from Annotations

```csharp
using (Redactor redactor = new Redactor(@"C:\test.pdf"))
{
   redactor.Apply(new AnnotationRedaction("(?im:john)", "[redacted]"));

   redactor.Save()
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/redaction/net) | [Documentation](https://docs.groupdocs.com/redaction/net) | [Demo](https://products.groupdocs.app/redaction/family) | [API Reference](https://apireference.groupdocs.com/redaction/net) | [Examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET) | [Blog](https://blog.groupdocs.com/category/redaction/) | [Free Support](https://forum.groupdocs.com/c/redaction) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
