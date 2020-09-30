using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Configuration;
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to register and use custom format handler for plain text documents
    /// </summary>    
    class CreateCustomFormatHandler
    {
        public static void Run()
        {
            var config = new DocumentFormatConfiguration()
            {
                ExtensionFilter = ".dump",
                DocumentType = typeof(CustomTextualDocument)
            };
            RedactorConfiguration.GetInstance().AvailableFormats.Add(config);
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DUMP))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("dolor", false, new ReplacementOptions("[redacted]")));
                // Save the document to "*_AnyText.*" (e.g. timestamp instead of "AnyText") in its file name without rasterization
                redactor.Save(new SaveOptions(false, "AnyText"));
            }
        }
    }
 }

