using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options.Drawing;

    /// <summary>
    /// The following example demonstrates how to use a regular expressions to redact textual documents
    /// </summary>
    class UseRegularExpression
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemoveFrameFromImage.cs : Redact content using regular expressions");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                // Use GroupDocs.Redaction.Options.Drawing types instead of System.Drawing, which is scheduled for removal in future versions.
                //redactor.Apply(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)));
                redactor.Apply(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(Color.Blue)));
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
