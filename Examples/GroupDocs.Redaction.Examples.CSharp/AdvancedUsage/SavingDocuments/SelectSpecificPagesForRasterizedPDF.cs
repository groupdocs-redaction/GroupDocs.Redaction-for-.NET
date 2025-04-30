using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to select page range and PDF compliance level for rasterization.
    /// </summary>
    class SelectSpecificPagesForRasterizedPDF
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SelectSpecificPagesForRasterizedPDF.cs : Save redacted document to PDF with specific page rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.MULTIPAGE_SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                if (result.Status != RedactionStatus.Failed)
                {

                    var options = new SaveOptions();
                    options.Rasterization.Enabled = true;                           // the same as options.RasterizeToPDF = true;
                    options.Rasterization.PageIndex = 5;                            // start from 6th page (index is 0-based)
                    options.Rasterization.PageCount = 1;                            // save only one page
                    options.Rasterization.Compliance = PdfComplianceLevel.PdfA1a;   // by default PdfComplianceLevel.Auto or PDF/A-1b
                    options.AddSuffix = true;
                    var outputFile = redactor.Save(options);
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
