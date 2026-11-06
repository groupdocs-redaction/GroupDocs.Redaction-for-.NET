using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.UsingRedactionFilters
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options.Drawing;

    /// <summary>
    /// The following example demonstrates how to apply redaction to the top half of the last page in a PDF document.
    /// </summary>
    class UsePdfRedactionFilters
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UsePdfRedactionFilters.cs : Using redaction filters");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_PDF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Get the actual size information for the last page:
                IDocumentInfo info = redactor.GetDocumentInfo();
                PageInfo lastPage = info.Pages[info.PageCount - 1];
                ReplacementOptions options = new Redactions.ReplacementOptions("[secret]");
                options.Filters = new RedactionFilter[] { //top half of the page
                    new PageRangeFilter(PageSeekOrigin.End, 0, 1),
                    new PageAreaFilter(new Point(0, 0),
                        new Size(lastPage.Width, lastPage.Height/2))
                };
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("sensitive data", false, options));
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
