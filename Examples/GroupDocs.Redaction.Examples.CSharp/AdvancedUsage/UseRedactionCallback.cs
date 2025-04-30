using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to attach and use an IRedactionCallback implementation
    /// </summary>
    class UseRedactionCallback
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseRedactionCallback.cs : Using callbacks");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile, new LoadOptions(), new RedactorSettings(new RedactionDump())))
            {
                // Assign an instance before using Redactor
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                var outputFile = redactor.Save();
                Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
            }
            Console.WriteLine("======================================");
        }
    }
 }

