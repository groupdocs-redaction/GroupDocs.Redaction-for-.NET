using System;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    using GroupDocs.Redaction;

    /// <summary>
    /// The following example demonstrates how to get document information for a file on a local disc.
    /// </summary>
    class GetFileInfoForAFileFromLocalDisk
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # GetFileInfoForAFileFromLocalDisk.cs : Getting local file info");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.SAMPLE_DOCX);

            using (Redactor redactor = new Redactor(sourceFile))
            {
                IDocumentInfo info = redactor.GetDocumentInfo();
                Console.WriteLine("\nFile type: {0}\nNumber of pages: {1}\nDocument size: {2} bytes", info.FileType, info.PageCount, info.Size);
            }
            Console.WriteLine("======================================");
        }
    }
}
