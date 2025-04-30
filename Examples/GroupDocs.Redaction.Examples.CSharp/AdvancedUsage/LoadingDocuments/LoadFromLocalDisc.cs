using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to open a document from local disc
    /// </summary>
    public class LoadFromLocalDisc
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # LoadFromLocalDisc.cs : Redact a document from local disk");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                // Here we can use document instance to perform redactions   
                redactor.Apply(new DeleteAnnotationRedaction());
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
