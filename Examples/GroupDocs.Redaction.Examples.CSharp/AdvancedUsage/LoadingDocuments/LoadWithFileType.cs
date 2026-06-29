using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Options.Drawing;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to load a document by specifying its file type and then apply redactions.
    /// </summary>
    public class LoadWithFileType
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # LoadWithFileType.cs : Load a document by specifying its file type\n");

            // Prepare output directory and source files.
            string sourceFileStream = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);
            string sourceFilePath = Utils.PrepareOutputDirectory(Constants.LOREMIPSUM_PDF);

            // Redact a stream while explicitly specifying its file type.
            string outputFileStream = Utils.GetOutputFileByName(sourceFileStream, $"Redacted_Stream.docx");
            using (Stream stream = File.Open(sourceFileStream, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Redactor redactor = new Redactor(stream, new LoadOptions(FileType.DOCX)))
                {
                    redactor.Apply(new DeleteAnnotationRedaction());
                    using (Stream streamOut = File.Open(outputFileStream, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        redactor.Save(streamOut, new RasterizationOptions { Enabled = false });
                    }
                    Console.WriteLine($"\nSource stream was redacted successfully.\nFile saved to {outputFileStream}.");
                }
            }

            // Redact a file by explicitly specifying its file type.
            using (Redactor redactor = new Redactor(sourceFilePath, new LoadOptions(FileType.PDF)))
            {
                redactor.Apply(new ExactPhraseRedaction("Lorem", new ReplacementOptions(Color.Chocolate)));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }

            Console.WriteLine("======================================");
        }
    }
}
