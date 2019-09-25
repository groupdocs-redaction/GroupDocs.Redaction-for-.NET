using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.ImageRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact a rectangular area of an image
    /// </summary>
    class RedactImageArea
    {
        public static void Run()
        {
            //ExStart:ImageAreaRedaction_19.3
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_JPG))
            {
                //Define the position on image
                System.Drawing.Point samplePoint = new System.Drawing.Point(385, 485);

                //Define the size of the area which need to be redacted
                System.Drawing.Size sampleSize = new System.Drawing.Size(1793, 2069);

                //Perform redaction
                RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                                new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
                if (result.Status != RedactionStatus.Failed)
                {
                    //The redacted output will save as PDF 
                    redactor.Save();
                };
            }
            //ExEnd:ImageAreaRedaction_19.3
        }
    }
}
