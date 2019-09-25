// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to load and redact a document using Stream.
    /// </summary>
    public class LoadFromStream
    {
        public static void Run()
        {
            using (Stream stream = File.Open(Constants.SAMPLE_DOCX, FileMode.Open, FileAccess.ReadWrite))
            {
                using (Redactor redactor = new Redactor(stream))
                {
                    // Here we can use document instance to make redactions
                    redactor.Apply(new DeleteAnnotationRedaction());
                    redactor.Save();
                }
            }
        }
    }
}
