using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact the whole paragraph in a PDF document
    /// </summary>
    class UseRegexForParagraph
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # UseRegexForParagraph.cs : Redact paragraphs content");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.LOREMIPSUM_PDF);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                redactor.Apply(new RegexRedaction("(Lorem(\n|.)+?urna)", new ReplacementOptions(System.Drawing.Color.Red)));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
