using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RedactionBasics
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply a single redaction
    /// </summary>
    class ApplyRedaction
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # ApplyRedaction.cs : Redact file content");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
