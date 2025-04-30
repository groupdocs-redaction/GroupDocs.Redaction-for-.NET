using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to remove all annotations from a document
    /// </summary>
    class RemoveAllAnnotations
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemoveAllAnnotations.cs : Remove all document annotations");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                // Delete all annotations
                redactor.Apply(new DeleteAnnotationRedaction());
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
