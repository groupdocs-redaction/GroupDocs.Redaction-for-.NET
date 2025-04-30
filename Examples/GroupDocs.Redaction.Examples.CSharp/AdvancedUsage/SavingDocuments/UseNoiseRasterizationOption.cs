using System;
using System.Collections.Generic;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the noise advanced rasterization option with custom settings.
    /// </summary>
    class UseNoiseRasterizationOption
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseNoiseRasterizationOption.cs : Save document using noise rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Save the document with the custom number and size of noise effects
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Noise, 
                    new Dictionary<string, string>() { { "maxSpots", "150" }, { "spotMaxSize", "15" } });
                var outputFile = redactor.Save(so);
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
