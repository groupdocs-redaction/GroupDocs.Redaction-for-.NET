using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to use a regular expressions to redact textual documents
    /// </summary>
    class UseRegularExpression
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                redactor.Apply(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)));
                // Save the document to "*_Redacted.*" file in original format
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
