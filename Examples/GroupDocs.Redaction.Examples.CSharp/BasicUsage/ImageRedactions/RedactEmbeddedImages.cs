using System;

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
            Console.WriteLine("[Example Basic Usage] # RedactEmbeddedImages.cs : Redact DOCX embedded images");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.LOREMIPSUM_PDF);

            //ExStart:ImageAreaRedaction_20.7
            using (Redactor redactor = new Redactor(sourceFile))
            {
                System.Drawing.Point samplePoint = new System.Drawing.Point(516, 311);
                System.Drawing.Size sampleSize = new System.Drawing.Size(170, 35);
                RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                              new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                ;
            }
            //ExEnd:ImageAreaRedaction_20.7
            Console.WriteLine("======================================");
        }
    }
}
