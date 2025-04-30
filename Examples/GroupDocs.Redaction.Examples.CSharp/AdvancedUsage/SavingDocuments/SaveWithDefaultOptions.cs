using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates usage of Save() method with default options.
    /// </summary>
    class SaveWithDefaultOptions
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveWithDefaultOptions.cs : Save redacted document with default options");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Save the document with default options (convert pages into images, save as PDF)
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
