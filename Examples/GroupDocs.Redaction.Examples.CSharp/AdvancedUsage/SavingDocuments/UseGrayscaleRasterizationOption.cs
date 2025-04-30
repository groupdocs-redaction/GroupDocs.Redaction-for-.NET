using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the grayscale advanced rasterization option.
    /// </summary>
    class UseGrayscaleRasterizationOption
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseGrayscaleRasterizationOption.cs : Save document using grayscale rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Save the document with the custom grayscale effect
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Grayscale);
                var outputFile = redactor.Save(so);
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
