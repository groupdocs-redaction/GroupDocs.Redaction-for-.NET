using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to remove the last page from a document.
    /// </summary>
    class RemoveLastPage
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemoveLastPage.cs : Remove the last page from a document");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.MULTIPAGE_PDF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Requires at least 1 page
                if (redactor.GetDocumentInfo().PageCount >= 1)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.End, 0, 1));
                    var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
