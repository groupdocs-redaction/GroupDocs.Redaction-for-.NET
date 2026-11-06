using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to remove 3 frames from an animated GIF image.
    /// </summary>
    class RemoveFrameFromImage
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemoveFrameFromImage.cs : Remove multi-page image frames");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_GIF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Removes all frames starting from the third frame to the end of the document.
                if (redactor.GetDocumentInfo().PageCount >= 4)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.Begin, 2, redactor.GetDocumentInfo().PageCount - 2));
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
