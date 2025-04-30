using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to open a password-protected document
    /// </summary>
    class OpenPasswordProtectedFile
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # LoadPasswordProtectedFile.cs : Redact a password-protected document");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.PROTECTED_SAMPLE_DOCX);

            LoadOptions loadOptions = new LoadOptions("mypassword");
            using (Redactor redactor = new Redactor(sourceFile, loadOptions))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
