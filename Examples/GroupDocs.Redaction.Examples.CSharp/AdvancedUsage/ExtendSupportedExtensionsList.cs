using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Configuration;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates 
    /// </summary>
    class ExtendSupportedExtensionsList
    {        
        public static void Run()
        {
            RedactorConfiguration config = RedactorConfiguration.GetInstance();
            DocumentFormatConfiguration docxSettings = config.FindFormat(".docx");
            docxSettings.ExtensionFilter = docxSettings.ExtensionFilter + ",.txt";
            using (Redactor redactor = new Redactor(Constants.SAMPLE_TXT))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }

 }

