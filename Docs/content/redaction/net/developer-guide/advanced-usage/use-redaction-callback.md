---
id: use-redaction-callback
url: redaction/net/use-redaction-callback
title: Use redaction callback
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
In order to reject or approve specific changes during redaction process or to keep a full log of changes in the document, you need to provide an instance of [IRedactionCallback](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/iredactioncallback) to a constructor of [RedactorSettings](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/redactorsettings) class. The interface contains only one method, [AcceptRedaction()](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/iredactioncallback/methods/acceptredaction), which receives detailed information about proposed redaction and returns *Boolean* value, accepted or not.

Below, we create a callback class, dumping changes to system console:

**C#**

```csharp
public class RedactionDump : IRedactionCallback
{
    public RedactionDump()
    {
    }

    public bool AcceptRedaction(RedactionDescription description)
    {
        Console.Write("{0} redaction, {1} action, item {2}. ", description.RedactionType, description.ActionType, description.OriginalText);
        if (description.Replacement != null)
        {
            Console.Write("Text {0} is replaced with {1}. ", description.Replacement.OriginalText, description.Replacement.Replacement);
        }
        Console.WriteLine();
        // you can return "false" here to prevent particular change during redaction process
        return true;
    }
}

```

The instance of this class is to be passed to a constructor of the [Redactor](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction/redactor) class:

**C#**

```csharp
using (Redactor redactor = new Redactor("\\Sample.docx", new LoadOptions(), new RedactorSettings(new RedactionDump())))
{
    // Assign an instance before using Redactor
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
