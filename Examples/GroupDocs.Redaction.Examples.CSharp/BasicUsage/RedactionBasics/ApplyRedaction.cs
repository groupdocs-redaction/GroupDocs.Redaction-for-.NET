// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RedactionBasics
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to apply a single redaction
    /// </summary>
    class ApplyRedaction
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }
}
