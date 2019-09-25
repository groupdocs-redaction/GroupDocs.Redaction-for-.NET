using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to make exact phrase redaction case sensitive
    /// </summary>
    class UseExactPhraseCaseSensitive
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", true /*isCaseSensitive*/, new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }
}
