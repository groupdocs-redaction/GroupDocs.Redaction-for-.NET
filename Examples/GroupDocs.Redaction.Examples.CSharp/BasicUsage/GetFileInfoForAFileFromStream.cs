using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// The following example demonstrates how to get document information for a file from stream.
    /// </summary>
    class GetFileInfoForAFileFromStream
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # GetFileInfoForAFileFromStream.cs : Getting file info from stream");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(File.OpenRead(sourceFile)))
            {
                IDocumentInfo info = redactor.GetDocumentInfo();
                Console.WriteLine("\nFile type: {0}\nNumber of pages: {1}\nDocument size: {2} bytes", info.FileType, info.PageCount, info.Size);
            }
            Console.WriteLine("======================================");
        }
    }
}
