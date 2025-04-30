using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to create a rasterized PDF from a Microsoft Word document and apply image redactions to its pages.
    /// </summary>
    class CreatePDFWithImageRedaction
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # CreatePDFWithImageRedaction.cs : Word to PDF rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string outputFile = Utils.GetOutputFileByExtension(sourceFile, ".pdf");

            var stream = new MemoryStream();
            // Rasterize the document before applying redactions
            using (var redactor = new Redactor(sourceFile))
            {
                // Perform annotation and textual redactions, if needed
                redactor.Save(stream, new RasterizationOptions() { Enabled = true });
                stream.Seek(0, SeekOrigin.Begin);
            }
            // Re-open the rasterized PDF document to redact its pages as images
            using (var redactor = new Redactor(stream))
            {
                RedactorChangeLog result = redactor.Apply(new Redactions.ImageAreaRedaction(new System.Drawing.Point(40, 160),
                    new RegionReplacementOptions(System.Drawing.Color.Aqua, new System.Drawing.Size(350, 75))));
                if (result.Status != RedactionStatus.Failed)
                {
                    using (var fileStream = File.OpenWrite(outputFile))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
                    }
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
 }

