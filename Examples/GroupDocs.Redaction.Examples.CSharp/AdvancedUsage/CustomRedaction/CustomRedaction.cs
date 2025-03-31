using System;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Redactions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The following example demonstrates how to use custom redaction.
    /// </summary>
    class CustomRedaction
    {
        public static void Run()
        {
            // Regular expressions may not always be flexible enough for document content processing.  
            // Use custom redaction to gain full control over the redaction process.

            // Use a regular expression to process the entire text within a custom handler.
            Regex regex = new Regex(".*");

            // Define replacement options.
            ReplacementOptions optionsText = new ReplacementOptions("[replaced]");
            // Set up the custom redaction handler.
            optionsText.CustomRedaction = new TextRedactor();

            var textRedaction = new PageAreaRedaction(regex, optionsText);
            var redactions = new Redaction[] { textRedaction };

            // Currently, custom redaction is supported only for PDFs
            using (Redactor redactor = new Redactor(Constants.LOREMIPSUM_PDF))
            {
                RedactorChangeLog result = redactor.Apply(redactions);
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save(new Options.SaveOptions(false, "Custom_Redaction_Result"));
                    Console.WriteLine("Custom redaction performed");
                }
                else
                {
                    Console.WriteLine("Custom redaction failed");
                }
            }
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
