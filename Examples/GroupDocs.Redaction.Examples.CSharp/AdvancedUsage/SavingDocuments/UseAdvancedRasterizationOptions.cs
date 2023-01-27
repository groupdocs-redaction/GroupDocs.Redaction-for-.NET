// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to apply the advanced rasterization options with default settings.
    /// </summary>
    class UseAdvancedRasterizationOptions
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Here we can use document instance to perform redactions
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Save the document with advanced options (convert pages into images, and save PDF with scan-like pages)
                var so = new SaveOptions();
                so.Rasterization.Enabled = true;
                so.RedactedFileSuffix = "_scan";
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Border);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Noise);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Grayscale);
                so.Rasterization.AddAdvancedOption(AdvancedRasterizationOptions.Tilt);
                redactor.Save(so);
            }
        }
    }
}
