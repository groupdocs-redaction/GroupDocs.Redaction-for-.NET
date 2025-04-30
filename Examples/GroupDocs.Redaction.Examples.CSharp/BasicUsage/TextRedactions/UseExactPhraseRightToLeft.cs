using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply ExactPhraseRedaction to an Arabic PDF document
    /// </summary>
    class UseExactPhraseRightToLeft
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # UseExactPhraseRightToLeft.cs : Redact phrases in right-to-left languages like Arabic or Hebrew");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.ARABIC_PDF);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                ExactPhraseRedaction red = new ExactPhraseRedaction("أﺑﺠﺪ", new ReplacementOptions("[test]"));
                red.IsRightToLeft = true;

                redactor.Apply(red);
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
