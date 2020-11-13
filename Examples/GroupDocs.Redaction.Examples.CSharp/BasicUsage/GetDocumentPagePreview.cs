// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to get a single page preview of the document. 
    /// </summary>
    class GetDocumentPagePreview
    {
        public static void Run()
        {
            // Take preview of the first page
            int testPageNumber = 1;
            // Preview file name
            string previewFileName = string.Format("{0}_page{1}.png", Constants.SAMPLE_DOCX, testPageNumber);
            // Load the document to generate preview
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
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
        }
    }
}
