using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to specify a custom ILogger implementation.
    /// </summary>
    public class UseAdvancedLogging
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # CustomRedactionAI.cs : Use advanced logging");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string outputFile = Utils.GetOutputFile(sourceFile);

            using (Stream stream = File.Open(sourceFile, FileMode.Open, FileAccess.ReadWrite))
            {
                var logger = new CustomLogger();
                using (Redactor redactor = new Redactor(stream, new LoadOptions(), new RedactorSettings(logger)))
                {
                    // Here we can use document instance to make redactions
                    redactor.Apply(new DeleteAnnotationRedaction());
                    if (!logger.HasErrors)
                    {
                        using (Stream streamOut = File.Open(outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            redactor.Save(streamOut, new Options.RasterizationOptions { Enabled = false });
                        }
                        Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                    }
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
