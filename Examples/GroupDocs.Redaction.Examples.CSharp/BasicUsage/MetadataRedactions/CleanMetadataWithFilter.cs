using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.MetadataRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to clean only specific metadata items (Author and Manager).
    /// </summary>
    class CleanMetadataWithFilter
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # CleanMetadataWithFilter.cs : Clean filtered file metadata");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                redactor.Apply(new EraseMetadataRedaction(MetadataFilters.Author | MetadataFilters.Manager));
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
