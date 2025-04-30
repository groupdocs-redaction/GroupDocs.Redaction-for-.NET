using System;

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
            Console.WriteLine("[Example Basic Usage] # RedactMetadataWithFilter.cs : Redact filtered file metadata");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                MetadataSearchRedaction redaction = new MetadataSearchRedaction("Company Ltd.", "--company--")
                {
                    Filter = MetadataFilters.Company
                };
                redactor.Apply(redaction);
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
