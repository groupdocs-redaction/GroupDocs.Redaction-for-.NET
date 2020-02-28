using System;
using System.Collections.Generic;
using System.Text;

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
            using (Redactor redactor = new Redactor(Constants.SAMPLE_EXIF_JPG))
            {
                redactor.Apply(new EraseMetadataRedaction(MetadataFilters.All));
                // Save the document to "*_Redacted.*" file in original format
                redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
            }
        }
    }
}
