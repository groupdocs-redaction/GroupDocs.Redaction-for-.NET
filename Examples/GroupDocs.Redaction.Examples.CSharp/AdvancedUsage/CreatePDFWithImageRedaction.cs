using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to create a rasterized PDF from a Microsoft Word document and apply image redactions to its pages.
    /// </summary>
    class CreatePDFWithImageRedaction
    {
        public static void Run()
        {
            var stream = new MemoryStream();
            // Rasterize the document before applying redactions
            using (var redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Perform annotation and textual redactions, if needed
                redactor.Save(stream, new RasterizationOptions() { Enabled = true });
                stream.Seek(0, SeekOrigin.Begin);
            }
            // Re-open the rasterized PDF document to redact its pages as images
            using (var redactor = new Redactor(stream))
            {
                RedactorChangeLog result = redactor.Apply(new Redactions.ImageAreaRedaction(new System.Drawing.Point(1160, 2375),
                    new RegionReplacementOptions(System.Drawing.Color.Aqua, new System.Drawing.Size(1050, 720))));
                if (result.Status != RedactionStatus.Failed)
                {
                    string newFileName = Path.Combine(@"C:\\Temp\\", Path.GetFileNameWithoutExtension(Constants.SAMPLE_DOCX) + "_Raster.pdf");
                    using (var fileStream = File.OpenWrite(newFileName))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
                    }
                }
            }
        }
    }
 }

