using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to remove only specific annotations using regular expression
    /// </summary>
    class RemoveAnnotations
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.ANNOTATED_XLSX))
            {
                // Delete all annotations, matching these criteria
                redactor.Apply(new DeleteAnnotationRedaction("(?im:(use|show|describe))"));
                // Save the document to "*_Redacted.*" file in original format
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
