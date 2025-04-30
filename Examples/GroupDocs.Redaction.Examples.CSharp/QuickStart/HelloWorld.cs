using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.QuickStart
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// Basic example of GroupDocs.Redaction usage
    /// </summary>
    class HelloWorld
    {
        public static void Run()
        {
            Console.WriteLine("[Quick Start] # HelloWorld.cs : Redact text in a document");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string outputFile = Utils.GetOutputFile(sourceFile);

            // Apply a single redaction to a document
            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Do some redaction
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                // Save document in original format with a given file name
                using (var stream = File.OpenWrite(outputFile))
                {
                    redactor.Save(stream, new RasterizationOptions() { Enabled = false });
                }
            }

            Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            Console.WriteLine("======================================");
        }
    }
}
