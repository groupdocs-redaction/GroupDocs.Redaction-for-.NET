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

    /// <summary>
    /// The following example demonstrates how to apply redaction to the bottom half of the last page in a PDF document.
    /// </summary>
    class UsePdfRedactionFilters
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.MULTIPAGE_PDF))
            {
                // Get the actual size information for the last page:
                IDocumentInfo info = redactor.GetDocumentInfo();
                PageInfo lastPage = info.Pages[info.PageCount - 1];
                ReplacementOptions options = new Redactions.ReplacementOptions("[secret]");
                options.Filters = new RedactionFilter[] {
                    new PageRangeFilter(PageSeekOrigin.End, 0, 1),
                    new PageAreaFilter(new System.Drawing.Point(0, lastPage.Height/2),
                        new System.Drawing.Size(lastPage.Width, lastPage.Height/2))
                };
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("bibliography", false, options));
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save();
                };
            }
        }
    }
}
