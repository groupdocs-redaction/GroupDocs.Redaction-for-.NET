using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.ImageRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact all embedded images within a Microsoft Word document.
    /// </summary>
    class RedactEmbeddedImages
    {
        public static void Run()
        {
            //ExStart:ImageAreaRedaction_20.7
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                System.Drawing.Point samplePoint = new System.Drawing.Point(516, 311);
                System.Drawing.Size sampleSize = new System.Drawing.Size(170, 35);
                RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                              new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save();
                };
            }
            //ExEnd:ImageAreaRedaction_20.7
        }
    }
}
