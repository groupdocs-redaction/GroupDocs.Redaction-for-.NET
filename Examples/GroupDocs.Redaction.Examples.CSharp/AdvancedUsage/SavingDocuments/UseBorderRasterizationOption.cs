using System;
using System.Collections.Generic;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the border advanced rasterization option with custom settings.
    /// </summary>
    class UseBorderRasterizationOption
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseBorderRasterizationOption.cs : Save redacted document using rasterization border");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Save the document with a custom border
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Border, new Dictionary<string, string>() { { "border", "10" } });
                var outputFile = redactor.Save(so);
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
