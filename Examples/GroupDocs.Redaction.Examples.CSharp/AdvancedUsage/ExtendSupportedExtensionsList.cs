using System;

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
            Console.WriteLine("[Example Advanced Usage] # ExtendSupportedExtensionsList.cs : Extend supported formats list");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DUMP);

            RedactorConfiguration config = RedactorConfiguration.GetInstance();
            DocumentFormatConfiguration settings = config.FindFormat(".txt");
            settings.ExtensionFilter = settings.ExtensionFilter + ",.dump";
            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("dolor", false, new ReplacementOptions("[redacted]")));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }

 }

