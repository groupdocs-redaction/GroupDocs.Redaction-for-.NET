---
id: use-advanced-logging
url: redaction/net/use-advanced-logging
title: Use advanced logging
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---

You can implement [ILogger](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/ilogger) interface from GroupDocs.Redaction.Options namespace. This interface requires to implement three methods:

**C#**

```csharp
    using GroupDocs.Redaction.Options;
    /// <summary>
    /// This is an example of ILogger implementation, tracking count of error messages.
    /// </summary>
    public class CustomLogger : ILogger
    {
        public List<string> Errors { get; private set; }
        public List<string> Traces { get; private set; }
        public List<string> Warnings { get; private set; }

        public bool HasErrors { get { return Errors.Count > 0; } }

        public CustomLogger()
        {
            Errors = new List<string>();
            Traces = new List<string>();
            Warnings = new List<string>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Trace(string message)
        {
            Traces.Add(message);
        }

        public void Warning(string message)
        {
            Warnings.Add(message);
        }
    }
```

Once implemented, you can use it to track error log records:

**C#**

```csharp
using (Stream stream = File.Open(@"sample.docx", FileMode.Open, FileAccess.ReadWrite))
{
   var logger = new CustomLogger();
   using (Redactor redactor = new Redactor(stream, new LoadOptions(), new RedactorSettings(logger)))
   {
      // Here we can use document instance to make redactions
      redactor.Apply(new DeleteAnnotationRedaction());
      if (!logger.HasErrors)
      {   
         redactor.Save();
      }
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
