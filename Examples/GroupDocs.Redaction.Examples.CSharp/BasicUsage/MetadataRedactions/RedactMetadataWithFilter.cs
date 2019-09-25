using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.MetadataRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact a text in metadata with a specific filter (Company only).
    /// </summary>
    class RedactMetadataWithFilter
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                MetadataSearchRedaction redaction = new MetadataSearchRedaction("Company Ltd.", "--company--")
                {
                    Filter = MetadataFilters.Company
                };
                redactor.Apply(redaction);
                // Save the document to "*_Redacted.*" file in original format
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
