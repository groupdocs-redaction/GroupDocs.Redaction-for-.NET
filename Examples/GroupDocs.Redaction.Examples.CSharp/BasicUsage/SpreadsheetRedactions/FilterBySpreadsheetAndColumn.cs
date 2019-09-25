using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.SpreadsheetRedactions
{
    using GroupDocs.Redaction.Options;
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// The following example demonstrates how to redact text only on a specific spreadsheet and even in a specific column, leaving text outside untouched.
    /// </summary>
    class FilterBySpreadsheetAndColumn
    {
        public static void Run()
        {
            using (Redactor redactor  = new Redactor(Constants.SAMPLE_XLSX))
            {
                var filter = new CellFilter()
                {
                    ColumnIndex = 1, // zero-based 2nd column
                    WorkSheetName = "Customers"
                };
                var expression = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
                RedactorChangeLog result = redactor.Apply(new CellColumnRedaction(filter, expression, new ReplacementOptions("[customer email]")));
                if (result.Status != RedactionStatus.Failed)
                {
                    redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                };
            }
        }
    }
}
