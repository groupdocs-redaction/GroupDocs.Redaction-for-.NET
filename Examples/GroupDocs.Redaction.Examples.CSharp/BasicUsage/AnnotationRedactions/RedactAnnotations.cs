using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to redact texts within annotations (comments, etc.)
    /// </summary>
    class RedactAnnotations
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.ANNOTATED_XLSX))
            {
                redactor.Apply(new AnnotationRedaction("(?im:john)", "[redacted]"));
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
