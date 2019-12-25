// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to specify a custom ILogger implementation.
    /// </summary>
    public class UseAdvancedLogging
    {
        public static void Run()
        {
            using (Stream stream = File.Open(Constants.SAMPLE_DOCX, FileMode.Open, FileAccess.ReadWrite))
            {
                var logger = new CustomLogger();
                using (Redactor redactor = new Redactor(stream, new LoadOptions(), new RedactorSettings(logger)))
                {
                    // Here we can use document instance to make redactions
                    redactor.Apply(new DeleteAnnotationRedaction());
                    if (!logger.HasErrors)
                    {   
                        redactor.Save();
                    }
                }
            }
        }
    }
}
