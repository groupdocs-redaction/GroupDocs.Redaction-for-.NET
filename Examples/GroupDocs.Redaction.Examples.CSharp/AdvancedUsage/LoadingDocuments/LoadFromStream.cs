using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
 
    /// <summary>
    /// The following example demonstrates how to load and redact a document using Stream.
    /// </summary>
    public class LoadFromStream
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # LoadFromStream.cs : Redact a document stored in a stream\"n");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string outputFile = Utils.GetOutputFile(sourceFile);

            using (Stream stream = File.Open(sourceFile, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Redactor redactor = new Redactor(stream))
                {
                    // Here we can use document instance to make redactions
                    redactor.Apply(new DeleteAnnotationRedaction());
                    using (Stream streamOut = File.Open(outputFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)) 
                    {
                        redactor.Save(streamOut, new Options.RasterizationOptions { Enabled = false });
                    }
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
