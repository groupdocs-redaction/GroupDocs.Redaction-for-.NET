// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to save a document to any location.
    /// </summary>
    class SaveToStream
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Here we can use document instance to perform redactions
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));
                if (result.Status != RedactionStatus.Failed)
                {
                    // Save the document to a custom location and convert its pages to images
                    using (Stream fileStream = File.Open(@"C:\\Temp\\sample_output_file.pdf", FileMode.Open, FileAccess.ReadWrite))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = true });
                    }
                }
            }
        }
    }
}
