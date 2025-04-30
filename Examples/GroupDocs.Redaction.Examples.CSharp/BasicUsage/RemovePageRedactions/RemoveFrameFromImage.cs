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
            string sourceFile = Utils.PrepareOutputDirectory(Constants.ANIMATED_GIF);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Removes 3 frames starting from 3nd one, requires at least 7 frames
                if (redactor.GetDocumentInfo().PageCount >= 7)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.Begin, 2, 5));
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
