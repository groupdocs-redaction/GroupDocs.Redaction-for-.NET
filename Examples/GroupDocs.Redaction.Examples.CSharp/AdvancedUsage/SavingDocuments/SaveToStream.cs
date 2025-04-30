using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to save a document to stream.
    /// </summary>
    class SaveToStream
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveToStream.cs : Save redacted document to stream");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string outputFile = Utils.GetOutputFile(sourceFile);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                if (result.Status != RedactionStatus.Failed)
                {
                    // Save the document to a custom location and convert its pages to images
                    using (Stream fileStream = File.Open(outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = true });
                    }
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
