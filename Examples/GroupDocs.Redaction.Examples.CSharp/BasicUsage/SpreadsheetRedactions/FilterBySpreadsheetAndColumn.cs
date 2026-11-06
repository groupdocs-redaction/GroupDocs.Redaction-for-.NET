using System;
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
            Console.WriteLine("[Example Basic Usage] # FilterBySpreadsheetAndColumn.cs : Redact content in specific column");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_XLSX);

            using (Redactor redactor  = new Redactor(sourceFile))
            {
                var filter = new CellFilter()
                {
                    ColumnIndex = 0, // zero-based 1st column
                    WorkSheetName = "Other"
                };
                var expression = new Regex("R[a-zA-Z ]{0,15}n");
                RedactorChangeLog result = redactor.Apply(new CellColumnRedaction(filter, expression, new ReplacementOptions("[classified]")));
                if (result.Status != RedactionStatus.Failed)
                {
                    var outputFile = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                    Console.WriteLine($"\nSource document was redacted successfully.\nFile saved to {outputFile}.");
                }
                ;
            }
            Console.WriteLine("======================================");
        }
    }
}
