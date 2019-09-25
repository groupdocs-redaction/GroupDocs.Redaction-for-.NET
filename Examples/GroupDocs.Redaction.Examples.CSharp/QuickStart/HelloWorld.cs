using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.QuickStart
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// Basic example of GroupDocs.Redaction usage
    /// </summary>
    class HelloWorld
    {
        public static void Run()
        {            
            // The path to the documents directory.
            string outputFolder = Path.Combine(Constants.OutputPath, "HelloWorld");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(Constants.SAMPLE_DOCX));

            // Apply a single redaction to a document
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Do some redaction
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                // Save document in original format with a given file name
                using (var stream = File.OpenWrite(outputFilePath))
                {
                    redactor.Save(stream, new RasterizationOptions() { Enabled = false });
                }
            }

            Console.WriteLine("\nSource document was redacted successfully.\nFile saved at " + outputFilePath);
        }
    }
}
