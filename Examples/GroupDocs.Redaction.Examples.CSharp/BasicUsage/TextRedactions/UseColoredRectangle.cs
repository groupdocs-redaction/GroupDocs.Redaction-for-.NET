using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to replace matched text with a solid color rectangle
    /// </summary>
    class UseColoredRectangle
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_DOCX))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                redactor.Save();
            }
        }
    }
}
