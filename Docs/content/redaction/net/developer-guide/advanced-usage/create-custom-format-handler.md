---
id: create-custom-format-handler
url: redaction/net/create-custom-format-handler
title: Create custom format handler
weight: 7
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
If format is not supported, you will need to implement a handler for it by inheriting from [DocumentFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance) class. Depending on the document's features and required redactions, you will also need to implement one or several interfaces, allowing GroupDocs.Redaction to work with this document format.

| Interface | Description |
| --- | --- |
| [ITextualFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/itextualformatinstance) | Required for document text redactions to work, replaces occurrences of given regular expression with text or a color block |
| [IMetadataAccess](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/imetadataaccess) | Required for metadata redactions, reads metadata and changes specific metadata item |
| [IAnnotatedDocument](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/iannotateddocument) | Required for annotation redactions, changes or deletes annotations, matching given regular expression |
| [IRasterizableDocument](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/irasterizabledocument) | Required to rasterize (save document as a PDF with page images) |
| [IImageFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/iimageformatinstance) | Required for raster image format redactions, based on area top-left corner coordinates and area size |
| [IPreviewable](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/ipreviewable) | Required to provide document general information and preview functionality |

Each of these interfaces is optional, i.e. you don't have to implement all of them, e.g. [IImageFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/iimageformatinstance) - if you don't need its functionality or [IMetadataAccess](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/imetadataaccess), if your format does not support metadata.

Below, we create a [DocumentFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance) class with custom logic for textual documents processing, supporting only textual redactions:

**C#**

```csharp
public class CustomTextualDocument : DocumentFormatInstance, ITextualFormatInstance
{
    private RedactorSettings Settings { get; set; }
    private List<string> FileContent { get; set; }

    public CustomTextualDocument()
    {
        FileContent = new List<string>();
    }

    public override void Initialize(DocumentFormatConfiguration config, RedactorSettings settings)
    {
        Settings = settings;
    }

    public override void Load(System.IO.Stream input)
    {
        FileContent.Clear();
        using (var reader = new StreamReader(input))
        {
            while (!reader.EndOfStream)
            {
                FileContent.Add(reader.ReadLine());
            }
        }
    }

    public override void Save(System.IO.Stream output)
    {
        var writer = new StreamWriter(output);
        foreach (var line in FileContent)
        {
            writer.WriteLine(line);
        }
        writer.Flush();
    }

    public RedactionResult ReplaceText(Regex regex, Redactions.ReplacementOptions options)
    {
        try
        {
            if (options.ActionType != Redactions.ReplacementType.ReplaceString)
            {
                return new RedactionResult.Failed("This format allows only ReplaceString redactions!");
            }
            for (int i = 0; i < FileContent.Count; i++)
            {
                FileContent[i] = regex.Replace(FileContent[i], options.Replacement);
            }
            return RedactionResult.Successful();
        }
        catch (Exception ex)
        {
            return RedactionResult.Failed(ex.ToString());
        }
    }
}

```

In order to use this class, we will need to add it to pre-configured formats, e.g. as a handler for dump files ("\*.dump"):

**C#**

```csharp
var config = RedactorConfiguration.GetInstance();
config.AvailableFormats.Add(new DocumentFormatConfiguration()
{
    ExtensionFilter = ".dump",
    DocumentType = typeof(CustomTextualDocument)
});
```

## Security and password protection

If your format supports security options like password protection, you'll have to pass true or false to [SetAccessGranted](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance/methods/setaccessgranted) method of [DocumentFormatInstance](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance) class in your override of [Load](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration/documentformatinstance/methods/load) method and throw [IncorrectPasswordException](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.exceptions/incorrectpasswordexception) or [PasswordRequiredException](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.exceptions/passwordrequiredexception), if applicable. For instance:

**C#**

```csharp
public override void Load(System.IO.Stream input)
{
    try
    {
		// check security and load document 

        SetAccessGranted(true);
    }
    catch (SomeSecurityException)
    {
        SetAccessGranted(false);
		// Password, provided with LoadOptions
        if (string.IsNullOrEmpty(Password))
            throw new Exceptions.PasswordRequiredException();
        else
            throw new Exceptions.IncorrectPasswordException();
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
