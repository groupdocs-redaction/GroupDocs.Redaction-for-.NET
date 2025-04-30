using System;
using System.Drawing;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.UsingOCR
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to use Aspose.OCR for .NET on-premise API to OCR images.
    /// </summary>
    /// <remarks>
    /// To use this API you will need a valid license file. You can always request a temporal license for evaluation.
    /// </remarks>
    class UseAsposeOCROnPremise
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseAsposeOCROnPremise.cs : Using Aspose.OCR");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_PDF_4OCR);

            var settings = new RedactorSettings(new AsposeOCRStandaloneConnector(Constants.LicensePath));
            using (var redactor = new Redactor(sourceFile, new LoadOptions(), settings))
            {
                var marker = new ReplacementOptions(Color.Black);
                var result = redactor.Apply(new Redaction[] {
                    new RegexRedaction(@"(?<=Dear\s+)([^,]+)", marker), // cardholder name
                    new RegexRedaction(@"\d{2}/\d{2}", marker), // valid thru
                    new RegexRedaction(@"\d{4}", marker)  // card number parts
                });
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save(new SaveOptions(false, "OnPremise"));
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
