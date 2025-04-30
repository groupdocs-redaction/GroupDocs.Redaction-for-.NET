using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to save the document as a rasterized PDF file
    /// </summary>
    class SaveInRasterizedPDF
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveInRasterizedPDF.cs : Save redacted document as a rasterized PDF");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Saving as rasterized PDF with no suffix in file name
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = true });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
