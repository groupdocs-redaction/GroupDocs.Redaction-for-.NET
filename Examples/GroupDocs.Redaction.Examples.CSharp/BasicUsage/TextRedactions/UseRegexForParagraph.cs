using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact the whole paragraph in a PDF document
    /// </summary>
    class UseRegexForParagraph
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.LOREMIPSUM_PDF))
            {
                redactor.Apply(new RegexRedaction("(Lorem(\n|.)+?urna)", new ReplacementOptions(System.Drawing.Color.Red)));
                redactor.Save();
            }
        }
    }
}
