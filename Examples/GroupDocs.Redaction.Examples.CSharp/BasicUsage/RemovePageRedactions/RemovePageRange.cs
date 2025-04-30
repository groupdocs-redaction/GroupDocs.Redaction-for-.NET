using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to remove a specific page range from a document.
    /// </summary>
    class RemovePageRange
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemovePageRange.cs : Remove document pages");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.MULTIPAGE_PDF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                var info = redactor.GetDocumentInfo();
                int startIndex = 1, pagesToDelete = 1;
                // Removes 1 page starting from 2nd one, requires at least 2 pages
                if (info.PageCount >= 2)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.Begin, startIndex, pagesToDelete));
                    var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
