using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples
{
    public class Common
    {
        //Source folder file path
        private const string SourceFolderPath = "../../../Data/";
        //Sample text file path
        private const string TextFilePath = "Documents/Doc/sample.txt";
        //Sample file path  
        private const string FilePath = "Documents/Doc/sample.docx";
        //Public key for dynabic account
        private const string PublicKey = "Public key for your account";
        //Private key for dynabic account
        private const string PrivateKey = "Private key for your account";
        //License file path
        private const string LicenseFilePath = @"D:\GroupDocs.Total.NET.lic";
       
        /// <summary>
        /// Applies License
        /// </summary>
        /// <returns> Ture if license is succefully applied applied</returns>
        public static bool SetLicense()
        {
            License license = new License();
            // as an alternative you can use a stream:
            license.SetLicense(LicenseFilePath);
            return license.IsValidLicense;
        }
        /// <summary>
        /// Shows how to use library in licensed mode using Dynabic.Metered account
        /// </summary>
        public static void UseDynabicMeteredAccount()
        {
            // initialize Metered API
            Metered metered = new Metered();
            // set-up credentials
            metered.SetMeteredKey(PublicKey, PrivateKey);
        }
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="sourceFileName">Source File Name</param>
        /// <returns>Returns complete path of source file</returns>
        public static string MapSourceFilePath(string sourceFileName)
        {
            try
            {
                return SourceFolderPath + sourceFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        /// <summary>
        /// Loads document
        /// </summary>
        public static void LoadDocument()
        {
            using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
            {
                // Here we can use document instance to perform redactions
            }
        }
        /// <summary>
        /// Loads document using stream
        /// </summary>
        public static void LoadDocumentUsingStream()
        {
            using (Stream stream = File.Open(Common.MapSourceFilePath(FilePath), FileMode.Open, FileAccess.ReadWrite))
            {
                using (Document doc = Redactor.Load(stream))
                {
                    // Here we can use document instance to make redactions
                }
            }
        }
        /// <summary>
        /// Saves document using diffrent appraches
        /// </summary>
        public static void SaveDocument()
        {
            using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
            {
                // Document redaction goes here
                // ...

                // Save the document with default options (convert pages into images, save as PDF)
                doc.Save();

                // Save the document in original format overwriting original file
                doc.Save(new SaveOptions() { AddSuffix = false, RasterizeToPDF = false });

                // Save the document to "*_Redacted.*" file in original format
                doc.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });

                // Save the document to "*_AnyText.*" (e.g. timestamp instead of "AnyText") in its file name without rasterization
                doc.Save(new SaveOptions(false, "AnyText"));

                // Save the document to the specified stream in original format
                using (Stream memStream = new MemoryStream())
                {
                    doc.Save(memStream, new SaveOptions() { RasterizeToPDF = false });
                    memStream.Close();
                }

                // Save the document to a custom location and convert its pages to images
                using (Stream fileStream = File.Open(Common.MapSourceFilePath(FilePath), FileMode.Open, FileAccess.ReadWrite))
                {
                    doc.Save(fileStream, new SaveOptions() { RasterizeToPDF = true });
                    fileStream.Close();
                }
            }

        }
    }
}
