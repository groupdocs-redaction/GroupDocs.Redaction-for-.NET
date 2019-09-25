// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to open a document from local disc
    /// </summary>
    public class LoadFromLocalDisc
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Here we can use document instance to perform redactions   
                redactor.Apply(new DeleteAnnotationRedaction());
                redactor.Save();
            }
        }
    }
}
