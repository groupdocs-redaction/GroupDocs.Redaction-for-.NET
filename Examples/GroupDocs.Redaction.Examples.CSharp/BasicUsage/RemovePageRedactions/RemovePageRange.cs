using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to remove a specific page range from a document.
    /// </summary>
    class RemovePageRange
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.MULTIPAGE_PDF))
            {
                var info = redactor.GetDocumentInfo();
                int startIndex = 1, pagesToDelete = 1;
                // Removes 1 page starting from 2nd one, requires at least 2 pages
                if (info.PageCount >= 2)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.Begin, startIndex, pagesToDelete));
                    redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
        }
    }
}
