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
    /// The following example demonstrates how to save the redacted document, replacing an original file
    /// </summary>
    class SaveOverwritingOriginalFile
    {
        public static void Run()
        {
            // Make a copy of source file
            File.Copy(Constants.SAMPLE_DOCX, Constants.OVERWRITTEN_SAMPLE_DOCX, true);
            // Apply redaction
            using (Redactor redactor = new Redactor(Constants.OVERWRITTEN_SAMPLE_DOCX))
            {
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                if (result.Status != RedactionStatus.Failed)
                {
                    // Save the document in original format overwriting original file
                    redactor.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = false });
                }
            }
        }
    }
}
