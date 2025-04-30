using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to require pre-rasterization for a Microsoft Word document.
    /// </summary>
    public class PreRasterize
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # CustomRedactionAI.cs : Use document rasterization");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            bool preRasterize = true;
            using (Redactor redactor = new Redactor(sourceFile, new LoadOptions(preRasterize)))
            {
                // Make changes to the file as a rasterized PDF, e.g. using ExactPhraseRedaction:
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", 
                    new ReplacementOptions("[personal]")));
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
