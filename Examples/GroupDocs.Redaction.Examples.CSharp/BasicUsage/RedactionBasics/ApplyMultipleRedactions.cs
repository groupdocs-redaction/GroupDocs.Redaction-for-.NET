using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RedactionBasics
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply a list of redactions
    /// </summary>
    class ApplyMultipleRedactions
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # ApplyMultipleRedactions.cs : Redact file with multiple redactions");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                var redactionList = new Redaction[]
                {
                      new ExactPhraseRedaction("John Doe", new ReplacementOptions("[Client]")),
                      new RegexRedaction("Redaction", new ReplacementOptions("[Product]")),
                      new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)),
                      new DeleteAnnotationRedaction(),
                      new EraseMetadataRedaction(MetadataFilters.All)
                };
                RedactorChangeLog result = redactor.Apply(redactionList);
                // false, if at least one redaction failed
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save();
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                else
                {
                    // Dump all failed or skipped redactions
                    foreach (RedactorLogEntry logEntry in result.RedactionLog)
                    {
                        if (logEntry.Result.Status != RedactionStatus.Applied)
                        {
                            Console.WriteLine("{0} status is {1}, details: {2}",
                                logEntry.Redaction.GetType().Name,
                                logEntry.Result.Status,
                                logEntry.Result.ErrorMessage);
                        }
                    }
                }
            }
            Console.WriteLine("======================================");
        }
    }
}
