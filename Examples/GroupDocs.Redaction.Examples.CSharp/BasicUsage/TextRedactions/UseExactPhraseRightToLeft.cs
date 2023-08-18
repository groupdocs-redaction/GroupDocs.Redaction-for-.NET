using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.TextRedactions
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply ExactPhraseRedaction to an Arabic PDF document
    /// </summary>
    class UseExactPhraseRightToLeft
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.ARABIC_PDF))
            {
                ExactPhraseRedaction red = new ExactPhraseRedaction("أﺑﺠﺪ", new ReplacementOptions("[test]"));
                red.IsRightToLeft = true;

                redactor.Apply(red);
                redactor.Save();
            }
        }
    }
}
