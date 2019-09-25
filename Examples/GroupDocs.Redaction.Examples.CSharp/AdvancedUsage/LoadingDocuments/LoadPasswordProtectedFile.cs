using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to open a password-protected document
    /// </summary>
    class OpenPasswordProtectedFile
    {
        public static void Run()
        {
            LoadOptions loadOptions = new LoadOptions("mypassword");
            using (Redactor redactor = new Redactor(Constants.PROTECTED_SAMPLE_DOCX, loadOptions))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }
}
