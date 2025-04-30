using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to get a single page preview of the document. 
    /// </summary>
    class GetDocumentPagePreview
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # GetDocumentPagePreview.cs : Getting document page preview");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            // Take preview of the first page
            int testPageNumber = 1;
            // Preview file name
            string previewFileName = Utils.GetOutputFileByName(sourceFile, $"preview_page{testPageNumber}");
            // Load the document to generate preview
            using (Redactor redactor = new Redactor(sourceFile))
            {
                PreviewOptions options = new PreviewOptions(delegate(int pageNumber) 
                { 
                    return File.OpenWrite(previewFileName); 
                });
                options.Width = 480;
                options.Height = 640;
                options.PageNumbers = new int[] { testPageNumber };
                options.PreviewFormat = PreviewOptions.PreviewFormats.PNG;
                redactor.GeneratePreview(options);
                Console.WriteLine("\nPreview for page: {0} was saved to \"{1}\"", testPageNumber, previewFileName);
            }
            Console.WriteLine("======================================");
        }
    }
}
