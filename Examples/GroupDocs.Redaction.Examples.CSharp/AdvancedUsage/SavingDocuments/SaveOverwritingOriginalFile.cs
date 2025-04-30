using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to save the redacted document, replacing an original file
    /// </summary>
    class SaveOverwritingOriginalFile
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveOverwritingOriginalFile.cs : Redact and overwrite document");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            // Apply redaction
            using (Redactor redactor = new Redactor(sourceFile))
            {
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                if (result.Status != RedactionStatus.Failed)
                {
                    // Save the document in original format overwriting original file
                    var outputFile = redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = false });
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                Console.WriteLine("======================================");
            }
        }
    }
}
