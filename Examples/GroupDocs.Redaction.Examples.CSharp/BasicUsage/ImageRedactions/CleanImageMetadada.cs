using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.ImageRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to edit exif data (erase them) from a photo or any other image.
    /// </summary>
    class CleanImageMetadada
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # CleanImageMetadada.cs : Clean all image metadata");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_JPG);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                redactor.Apply(new EraseMetadataRedaction(MetadataFilters.All));
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
