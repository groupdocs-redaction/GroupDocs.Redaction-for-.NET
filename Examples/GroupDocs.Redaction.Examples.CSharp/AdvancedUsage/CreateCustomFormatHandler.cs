using System;

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
            Console.WriteLine("[Example Advanced Usage] # CreateCustomFormatHandler.cs : Using custom format handlers");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DUMP);

            var config = new DocumentFormatConfiguration()
            {
                ExtensionFilter = ".dump",
                DocumentType = typeof(CustomTextualDocument)
            };
            RedactorConfiguration.GetInstance().AvailableFormats.Add(config);
            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("dolor", false, new ReplacementOptions("[redacted]")));
                // Save the document to "*_AnyText.*" (e.g. timestamp instead of "AnyText") in its file name without rasterization
                var outputFile = redactor.Save(new SaveOptions(false, "AnyText"));
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
 }

