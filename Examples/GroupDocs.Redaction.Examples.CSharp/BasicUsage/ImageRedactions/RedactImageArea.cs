using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.ImageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options.Drawing;

    /// <summary>
    /// The following example demonstrates how to redact a rectangular area of an image
    /// </summary>
    class RedactImageArea
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RedactImageArea.cs : Redact image area");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_JPG);

            //ExStart:ImageAreaRedaction_19.3
            using (Redactor redactor  = new Redactor(sourceFile))
            {
                //Define the position on image
                // Use GroupDocs.Redaction.Options.Drawing types instead of System.Drawing, which is scheduled for removal in future versions.
                //System.Drawing.Point samplePoint = new System.Drawing.Point(385, 485);
                Point samplePoint = new Point(385, 485);

                //Define the size of the area which need to be redacted
                // Use GroupDocs.Redaction.Options.Drawing types instead of System.Drawing, which is scheduled for removal in future versions.
                //System.Drawing.Size sampleSize = new System.Drawing.Size(1793, 2069);
                Size sampleSize = new Size(1793, 2069);

                //Perform redaction
                // Use GroupDocs.Redaction.Options.Drawing types instead of System.Drawing, which is scheduled for removal in future versions.
                //RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                //                new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
                RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                                new RegionReplacementOptions(Color.Blue, sampleSize)));
                if (result.Status != RedactionStatus.Failed)
                {
                    //The redacted output will save as PDF 
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                ;
            }
            //ExEnd:ImageAreaRedaction_19.3
            Console.WriteLine("======================================");
        }
    }
}
