using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to remove all annotations from a document
    /// </summary>
    class RemoveAllAnnotations
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Delete all annotations
                redactor.Apply(new DeleteAnnotationRedaction());
                // Save the document to "*_Redacted.*" file in original format
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
