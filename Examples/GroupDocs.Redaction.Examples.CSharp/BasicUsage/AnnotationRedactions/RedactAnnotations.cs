using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to redact texts within annotations (comments, etc.)
    /// </summary>
    class RedactAnnotations
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RedactAnnotations.cs : Redact annotation in a document");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_XLSX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                redactor.Apply(new AnnotationRedaction("(?im:annotations)", "[redacted]"));
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
