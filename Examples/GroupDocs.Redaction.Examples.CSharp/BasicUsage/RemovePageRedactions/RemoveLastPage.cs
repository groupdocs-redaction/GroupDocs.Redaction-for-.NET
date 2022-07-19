using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to remove the last page from a document.
    /// </summary>
    class RemoveLastPage
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.MULTIPAGE_PDF))
            {
                // Requires at least 1 page
                if (redactor.GetDocumentInfo().PageCount >= 1)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.End, 0, 1));
                    redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
        }
    }
}
