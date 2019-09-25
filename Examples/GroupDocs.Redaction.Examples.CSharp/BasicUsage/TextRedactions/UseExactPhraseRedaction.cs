using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to use exact phrase redaction
    /// </summary>
    class UseExactPhraseRedaction
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }
}
