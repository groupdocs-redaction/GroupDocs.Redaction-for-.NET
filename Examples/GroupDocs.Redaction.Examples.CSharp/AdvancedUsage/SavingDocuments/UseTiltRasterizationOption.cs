using System;
using System.Collections.Generic;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the tilt advanced rasterization option with custom settings.
    /// </summary>
    class UseTiltRasterizationOption
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseTiltRasterizationOption.cs : Save document using Tilt rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Save the document with the custom tilt effect
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Tilt,
                    new Dictionary<string, string>() { { "minAngle", "85" }, { "randomAngleMax", "5" } });
                var outputFile = redactor.Save(so);
            }
            Console.WriteLine("======================================");
        }
    }
}
