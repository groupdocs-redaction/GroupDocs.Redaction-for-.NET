using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to replace matched text with a solid color rectangle
    /// </summary>
    class UseColoredRectangle
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # UseColoredRectangle.cs : Hide text using color rectangle");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
