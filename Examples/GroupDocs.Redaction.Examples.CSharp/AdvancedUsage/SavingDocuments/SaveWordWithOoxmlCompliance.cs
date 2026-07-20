using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to save a word processing document with a specific OOXML compliance level.
    /// </summary>
    class SaveWordWithOoxmlCompliance
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # SaveWordWithOoxmlCompliance.cs : Save Word document with OOXML compliance");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));

                // Save in original format with a specific OOXML compliance level
                var options = new SaveOptions()
                {
                    AddSuffix = true,
                    RasterizeToPDF = false,
                    RedactedFileSuffix = "Strict"
                };
                // If not specified, the compliance level of the original document is preserved.
                // Strict can only be downgraded to Transitional, not to Ecma.
                options.WordprocessingSaveOptions.OoxmlCompliance = WordProcessingComplianceLevel.Strict;

                var outputFile = redactor.Save(options);
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
