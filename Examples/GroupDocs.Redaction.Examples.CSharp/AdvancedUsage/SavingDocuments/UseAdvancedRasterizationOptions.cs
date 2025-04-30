using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the advanced rasterization options.
    /// </summary>
    class UseAdvancedRasterizationOptions
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseAdvancedRasterizationOptions.cs : Save redacted document using advanced rasterization options");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Save the document with advanced options (convert pages into images, and save PDF with scan-like pages)
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Border);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Noise);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Grayscale);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Tilt);
                var outputFile = redactor.Save(so);
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
