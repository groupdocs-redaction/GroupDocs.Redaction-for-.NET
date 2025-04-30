using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.AnnotationRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to remove only specific annotations using regular expression
    /// </summary>
    class RemoveAnnotations
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # RemoveAnnotations.cs : Remove suitable document annotations");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.ANNOTATED_XLSX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                // Delete all annotations, matching these criteria
                redactor.Apply(new DeleteAnnotationRedaction("(?im:John Doe)"));
                // Save the document to "*_Redacted.*" file in original format
                var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
}
