using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp
{
    internal static class Constants
    {
        /// <summary>
        /// License file path
        /// </summary>
        public const string LicensePath = @"c:\Worx\Aspose\Data\License\Conholdate.Total.Product.Family.lic";

        /// <summary>
        /// Public key for dynabic account
        /// </summary>
        public const string PublicKey = "Public key for your Metered account";

        /// <summary>
        /// Private key for dynabic account
        /// </summary>
        public const string PrivateKey = "Private key for your Metered account";

        public const string SamplesPath = "../../../../GroupDocs.Redaction.Examples.CSharp/Resources/SampleFiles";
        public const string ImagesPath = "../../../../GroupDocs.Redaction.Examples.CSharp/Resources/SampleFiles/Images";
        public const string CertificatesPath = "../../../../GroupDocs.Redaction.Examples.CSharp/Resources/SampleFiles/Certificates";
        public const string OutputPath = "../../Output/";        

        private static string GetSampleFilePath(string filePath) 
	    {
           return Path.Combine(SamplesPath, filePath);
	    }
        
        // WordProcessing documents
        public static string SAMPLE_DOCX = GetSampleFilePath("Doc/sample.docx");
        public static string CONVERSION_CONTROL_DOCX = GetSampleFilePath("Doc/demo.docx");
        public static string PROTECTED_SAMPLE_DOCX = GetSampleFilePath("Doc/protected_sample.docx");
        public static string OVERWRITTEN_SAMPLE_DOCX = GetSampleFilePath("Doc/overwritten_sample.docx");
        public static string MULTIPAGE_SAMPLE_DOCX = GetSampleFilePath("Doc/multipage_sample.docx");

        // PDF
        public static string SAMPLE_PDF_4OCR = GetSampleFilePath("Pdf/OCR sample.pdf");
        public static string MULTIPAGE_PDF = GetSampleFilePath("Pdf/Multipage.pdf");
        public static string LOREMIPSUM_PDF = GetSampleFilePath("Pdf/LoremIpsum.pdf");
        public static string ARABIC_PDF = GetSampleFilePath("Pdf/Arabic.pdf");

        // Presentations

        // Spreadsheets
        public static string ANNOTATED_XLSX = GetSampleFilePath("Xls/sample1.xlsx");
        public static string SAMPLE_XLSX = GetSampleFilePath("Xls/sample.xlsx");

        // Images
        public static string SAMPLE_JPG = GetSampleFilePath("Image/sample.jpg");
        public static string SAMPLE_EXIF_JPG = GetSampleFilePath("Image/exif.jpg");
        public static string ANIMATED_GIF = GetSampleFilePath("Image/sample.gif");

        // Text files
        public static string SAMPLE_DUMP = GetSampleFilePath("Doc/sample.dump");

        // Policy test files
        public static string POLICY_FILE = GetSampleFilePath("Bulk/RedactionPolicy.xml");
        public static string POLICY_INBOUND = GetSampleFilePath("Bulk/Inbound");
        public static string POLICY_OUTBOUND_DONE = GetSampleFilePath("Bulk/Outbound/Done");
        public static string POLICY_OUTBOUND_FAILED = GetSampleFilePath("Bulk/Outbound/Failed");
        public static string POLICY_SAVE = GetSampleFilePath("SamplePolicy.xml");
    }
}
