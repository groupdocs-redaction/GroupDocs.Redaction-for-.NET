// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage.UsingRedactionFilters
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The following example demonstrates how to apply PageAreaRedaction to the right half of the last page in a PDF document.
    /// </summary>
    class UsePageAreaRedaction
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.LOREMIPSUM_PDF))
            {
                Regex rx = new Regex("urna");
                ReplacementOptions optionsText = new ReplacementOptions("[redarea]");
                optionsText.Filters = new RedactionFilter[] {
                    new PageRangeFilter(PageSeekOrigin.End, 0, 1), // last page
                    new PageAreaFilter(new System.Drawing.Point(300, 0), new System.Drawing.Size(300, 840)) // right half of the page 300x840
                };
                RegionReplacementOptions optionsImg = new RegionReplacementOptions(System.Drawing.Color.Chocolate, new System.Drawing.Size(100, 100));
                RedactorChangeLog result = redactor.Apply(new PageAreaRedaction(rx, optionsText, optionsImg));
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save();
                };
            }
        }
    }
}
