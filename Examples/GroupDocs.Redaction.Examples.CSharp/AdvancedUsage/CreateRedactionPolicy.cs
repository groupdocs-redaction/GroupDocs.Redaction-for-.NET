using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to create and save redaction policy for future use.
    /// </summary>
    /// <remarks>
    /// A set of redactions, configured in code, can be saved for future use as an XML file with redaction policy.
    /// </remarks>
    class CreateRedactionPolicy
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # CreateRedactionPolicy.cs : Using redaction policies");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.POLICY_SAVE, false);

            //ExStart:ConfigurableRedaction_20.9

            //Configure Redactions
            RedactionPolicy policy = new RedactionPolicy(new Redaction[] {
                new ExactPhraseRedaction("Redaction", new ReplacementOptions("[Product]")),
                new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)),
                new DeleteAnnotationRedaction(),
                new EraseMetadataRedaction(MetadataFilters.All)
            });
            //Save RedactionPolicy
            policy.Save(sourceFile);

            //ExEnd:ConfigurableRedaction_20.9
            Console.WriteLine("======================================");
        }
    }
}
