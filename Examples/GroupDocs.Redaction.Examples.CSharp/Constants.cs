using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp
{
    internal static class Constants
    {
        /// <summary>
        /// License file path
        /// </summary>
        public const string LicensePath = @"your license file path";

        /// <summary>
        /// Public key for dynabic account
        /// </summary>
        public const string PublicKey = "Public key for your Metered account";

        /// <summary>
        /// Private key for dynabic account
        /// </summary>
        public const string PrivateKey = "Private key for your Metered account";

        public const string SamplesPath = "../../../../GroupDocs.Redaction.Examples.CSharp/Resources/SampleFiles";
        public const string OutputPath = "../../Output/";        

        private static string GetSampleFilePath(string filePath) 
	    {
           return Path.Combine(SamplesPath, filePath);
	    }
        
        // WordProcessing documents
        public static string SAMPLE_DOCX = GetSampleFilePath("Wordprocessing/04_pages_docx.docx");
        public static string PROTECTED_SAMPLE_DOCX = GetSampleFilePath("Wordprocessing/protected_sample.docx");

        // PDF
        public static string SAMPLE_PDF = GetSampleFilePath("Pdf/04_pages_pdf.pdf");
        public static string SAMPLE_PDF_4OCR = GetSampleFilePath("Pdf/OCR sample.pdf");
        public static string LOREMIPSUM_PDF = GetSampleFilePath("Pdf/LoremIpsum.pdf");
        public static string ARABIC_PDF = GetSampleFilePath("Pdf/Arabic.pdf");

        // Presentations
        public static string SAMPLE_PPTX = GetSampleFilePath("Presentations/04_pages_pptx.pptx");

        // Spreadsheets
        public static string SAMPLE_XLSX = GetSampleFilePath("Spreadsheets/04_pages_xlsx.xlsx");

        // Images
        public static string SAMPLE_JPG = GetSampleFilePath("Images/01_pages_jpg.jpg");
        public static string SAMPLE_GIF = GetSampleFilePath("Images/04_pages_gif.gif");

        // Text files
        public static string SAMPLE_DUMP = GetSampleFilePath("Wordprocessing/sample.dump");

        // Policy test files
        public static string POLICY_FILE = GetSampleFilePath("Bulk/RedactionPolicy.xml");
        public static string POLICY_INBOUND = GetSampleFilePath("Bulk/Inbound");
        public static string POLICY_OUTBOUND_DONE = GetSampleFilePath("Bulk/Outbound/Done");
        public static string POLICY_OUTBOUND_FAILED = GetSampleFilePath("Bulk/Outbound/Failed");
        public static string POLICY_SAVE = GetSampleFilePath("SamplePolicy.xml");
    }
}
