using GroupDocs.Redaction.Redactions;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples
{
    public static class Redaction
    {
        public static class Text
        {
            //Sample file path
            private const string FilePath = "Documents/Doc/sample.docx";
            //Protected sample file path
            private const string ProtectedFilePath = "Documents/Doc/protected_sample.docx";
            /// <summary>
            /// Performs exact phrase redaction 
            /// </summary>
            public static void ExactPhraseRedaction()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                    doc.Save();
                }
            }
            /// <summary>
            /// Performs a case sensitive exact phrase redaction
            /// </summary>
            public static void CaseSensitiveExactPhraseRedaction()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new ExactPhraseRedaction("John Doe", true /*isCaseSensitive*/, new ReplacementOptions("[personal]")));
                    doc.Save();
                }
            }
            /// <summary>
            /// Colors redacted text 
            /// </summary>
            public static void ColorRedactedText()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Black)));
                    doc.Save();
                }
            }
            /// <summary>
            /// Performs a regular expression redaction
            /// </summary>
            public static void RegularExpressionRedaction()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)));
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
            /// <summary>
            /// Opens and performs redaction in password proteced document
            /// </summary>
            public static void PasswordProtectedDocument()
            {
                LoadOptions loadOptions = new LoadOptions("mypassword");
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(ProtectedFilePath), loadOptions))
                {
                    // Here we can use document instance to perform redactions
                    doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                    doc.Save();
                }
            }

        }

        public static class Tabular
        {
            //Sample file path
            private const string FilePath = "Documents/Doc/sample.xlsx";
            /// <summary>
            /// Performs cell column redaction in excel file format
            /// </summary>
            public static void TabularDocumentRedaction()
            {

                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    var filter = new CellFilter()
                    {
                        ColumnIndex = 1, // zero-based 2nd column
                        WorkSheetName = "Customers"
                    };
                    var expression = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
                    RedactionSummary result = doc.RedactWith(new CellColumnRedaction(filter, expression, new ReplacementOptions("[customer email]")));
                    if (result.Success)
                    {
                        doc.Save(new SaveOptions() { AddSuffix = true });
                    };
                }
            }
        }

        public static class Metadata
        {
            //Sample file path
            private const string FilePath = "Documents/Doc/sample.docx";
            /// <summary>
            /// Filters document metadata 
            /// </summary>
            public static void FilterMetadata()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new EraseMetadataRedaction(MetadataFilter.Author | MetadataFilter.Manager | MetadataFilter.NameOfApplication));
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
            /// <summary>
            /// Cleans document metadata
            /// </summary>
            public static void CleanDocumentMetadata()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new EraseMetadataRedaction(MetadataFilter.All));
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
            /// <summary>
            /// Performs a metadata search redaction
            /// </summary>
            public static void MetadataSearchRedaction()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new MetadataSearchRedaction("Company Ltd.", "--company--"));
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
            /// <summary>
            /// Performs search and replace metadata redaction using filters
            /// </summary>
            public static void MetadataSearchRedactionUsingFilters()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    MetadataSearchRedaction redaction = new MetadataSearchRedaction("Company Ltd.", "--company--")
                    {
                        Filter = MetadataFilter.Company
                    };
                    doc.RedactWith(redaction);
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
        }

        public static class Annotation
        {
            //Sample file path
            private const string FilePath = "Documents/Doc/sample.docx";
            /// <summary>
            /// Performs Annotation Redaction
            /// </summary>
            public static void AnnotationRedaction()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new DeleteAnnotationRedaction("(?im:(use|show|describe))"));
                    // Save the document to "*_Redacted.*" file in original format
                    doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                }
            }
            /// <summary>
            /// Removes sensitive information from specific annotations
            /// </summary>
            public static void RemoveSensitiveInformationFromAnnotation()
            {
                using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
                {
                    doc.RedactWith(new AnnotationRedaction("(?im:john)", "[redacted]"));
                    doc.Save();
                }

            }
        }  
    }
}
