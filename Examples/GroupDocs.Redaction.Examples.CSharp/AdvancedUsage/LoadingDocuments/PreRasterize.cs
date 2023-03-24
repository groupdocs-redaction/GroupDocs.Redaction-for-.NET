// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to require pre-rasterization for a Microsoft Word document.
    /// </summary>
    public class PreRasterize
    {
        public static void Run()
        {
            bool preRasterize = true;
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX, new LoadOptions(preRasterize)))
            {
                // Make changes to the file as a rasterized PDF, e.g. uisng ImageAreaRedaction:
                System.Drawing.Point samplePoint = new System.Drawing.Point(516, 311);
                System.Drawing.Size sampleSize = new System.Drawing.Size(170, 35);
                RedactorChangeLog result = redactor.Apply(new ImageAreaRedaction(samplePoint,
                                new RegionReplacementOptions(System.Drawing.Color.Blue, sampleSize)));
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save();
                };
            }
        }
    }
}
