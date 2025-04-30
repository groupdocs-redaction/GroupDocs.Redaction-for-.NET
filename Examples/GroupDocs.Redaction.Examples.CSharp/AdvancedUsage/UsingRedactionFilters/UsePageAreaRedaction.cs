using System;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.UsingRedactionFilters
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply PageAreaRedaction to the right half of the last page in a PDF document.
    /// </summary>
    class UsePageAreaRedaction
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UsePageAreaRedaction.cs : Redact pages ares");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.LOREMIPSUM_PDF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                Regex rx = new Regex("urna");
                ReplacementOptions optionsText = new ReplacementOptions("[redarea]");
                optionsText.Filters = new RedactionFilter[] {
                    new PageRangeFilter(PageSeekOrigin.End, 0, 1), // last page
                    new PageAreaFilter(new System.Drawing.Point(300, 0), new System.Drawing.Size(300, 840)) // right half of the page 300x840
                };
                RegionReplacementOptions optionsImg = new RegionReplacementOptions(System.Drawing.Color.Chocolate, new System.Drawing.Size(100, 100));
                RedactorChangeLog result = redactor.Apply(new PageAreaRedaction(rx, optionsText, optionsImg));
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                ;
            }
            Console.WriteLine("======================================");
        }
    }
}
