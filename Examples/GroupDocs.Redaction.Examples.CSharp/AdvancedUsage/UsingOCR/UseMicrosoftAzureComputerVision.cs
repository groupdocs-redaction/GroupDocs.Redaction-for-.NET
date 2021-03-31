
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.UsingOCR
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to use Microsoft Azure Cognitive Services Computer Vision to OCR images.
    /// </summary>
    /// <remarks>
    /// To access the service you need a valid subscription in Microsoft Azure Cognitive Services. You can always try it for free.
    /// </remarks>
    class UseMicrosoftAzureComputerVision
    {
        public static void Run()
        {
            var settings = new RedactorSettings(new ComputerVisionOcrConnector());
            using (var redactor = new Redactor(Constants.SAMPLE_PDF_4OCR, new LoadOptions(), settings))
            {
                var marker = new ReplacementOptions(Color.Black);
                var result = redactor.Apply(new Redaction[] {
                    new RegexRedaction(@"(?<=Dear\s+)([^,]+)", marker), // cardholder name
                    new RegexRedaction(@"\d{2}/\d{2}", marker), // valid thru
                    new RegexRedaction(@"\d{4}", marker)  // card number parts
                });
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save(new SaveOptions(false, "Microsoft"));
                }
            }
        }
    }
}
