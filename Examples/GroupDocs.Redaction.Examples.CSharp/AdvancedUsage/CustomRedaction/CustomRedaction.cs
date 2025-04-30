using System;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to use custom redaction.
    /// </summary>
    class CustomRedaction
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # CustomRedaction.cs : Using custom redactions");
            // Regular expressions may not always be flexible enough for document content processing.  
            // Use custom redaction to gain full control over the redaction process.

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.LOREMIPSUM_PDF);

            // Use a regular expression to process the entire text within a custom handler.
            Regex regex = new Regex(".*");

            // Define replacement options.
            ReplacementOptions optionsText = new ReplacementOptions("[replaced]");
            // Set up the custom redaction handler.
            optionsText.CustomRedaction = new TextRedactor();

            var textRedaction = new PageAreaRedaction(regex, optionsText);
            var redactions = new Redaction[] { textRedaction };

            // Currently, custom redaction is supported only for PDFs
            using (Redactor redactor = new Redactor(sourceFile))
            {
                RedactorChangeLog result = redactor.Apply(redactions);
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save(new Options.SaveOptions(false, "Custom_Redaction_Result"));
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                else
                {
                    Console.WriteLine("Custom redaction failed");
                }
            }
            Console.WriteLine("======================================");
        }

        // Implement a custom redaction handler.
        public class TextRedactor : ICustomRedactionHandler
        {
            public CustomRedactionResult Redact(CustomRedactionContext context)
            {
                CustomRedactionResult result = new CustomRedactionResult();

                try
                {
                    Regex regex = new Regex(@"Lorem ipsum");
                    if (regex.IsMatch(context.Text))
                    {
                        string redactedText = regex.Replace(context.Text, "[redacted-custom]");
                        result.Apply = true;
                        result.Text = redactedText;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Apply = false;
                }

                return result;
            }
        }
    }
}
