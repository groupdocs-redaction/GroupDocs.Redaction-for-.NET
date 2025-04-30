using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to save file in its original format
    /// </summary>
    class SaveInOriginalFormat
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveInOriginalFormat.cs : Save redacted document to original format");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Saving in original format with date as a suffix
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false, RedactedFileSuffix = DateTime.Now.ToShortDateString() });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
