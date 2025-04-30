using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to make exact phrase redaction case sensitive
    /// </summary>
    class UseExactPhraseCaseSensitive
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # UseExactPhraseCaseSensitive.cs : Redact case sensitive exact phrase");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", true /*isCaseSensitive*/, new ReplacementOptions("[personal]")));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
