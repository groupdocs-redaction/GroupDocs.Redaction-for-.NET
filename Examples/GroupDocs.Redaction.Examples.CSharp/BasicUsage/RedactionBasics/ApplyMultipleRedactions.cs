using System;
using System.IO;
using System.Text.RegularExpressions;

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
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
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
                    redactor.Save();
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
        }
    }
}
