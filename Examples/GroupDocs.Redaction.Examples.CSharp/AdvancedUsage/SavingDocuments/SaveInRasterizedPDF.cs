using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to save the document as a rasterized PDF file
    /// </summary>
    class SaveInRasterizedPDF
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Saving as rasterized PDF with no suffix in file name
                redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = true });
            }
        }
    }
}
