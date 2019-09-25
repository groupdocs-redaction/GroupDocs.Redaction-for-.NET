// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates usage of Save() method with default options.
    /// </summary>
    class SaveWithDefaultOptions
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Save the document with default options (convert pages into images, save as PDF)
                redactor.Save();
            }
        }
    }
}
