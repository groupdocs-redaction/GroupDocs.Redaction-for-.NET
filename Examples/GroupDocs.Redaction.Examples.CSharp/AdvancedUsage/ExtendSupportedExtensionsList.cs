using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Configuration;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to add a custom file extension to the list of supported extensions. 
    /// </summary>
    class ExtendSupportedExtensionsList
    {        
        public static void Run()
        {
            RedactorConfiguration config = RedactorConfiguration.GetInstance();
            DocumentFormatConfiguration settings = config.FindFormat(".txt");
            settings.ExtensionFilter = settings.ExtensionFilter + ",.dump";
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DUMP))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("dolor", false, new ReplacementOptions("[redacted]")));
                redactor.Save();
            }
        }
    }

 }

