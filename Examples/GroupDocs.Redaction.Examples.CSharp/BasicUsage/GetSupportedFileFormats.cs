using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    using GroupDocs.Redaction;

    /// <summary>
    /// The following example demonstrates how to get supported file formats list.
    /// </summary>
    class GetSupportedFileFormats
    {
        public static void Run()
        {
            Console.WriteLine("[Example Basic Usage] # GetSupportedFileFormats.cs : Getting GroupDocs.Redaction supported file formats");

            IEnumerable<FileType> supportedFileTypes = FileType
                .GetSupportedFileTypes()
                .OrderBy(f => f.Extension);

            foreach (FileType fileType in supportedFileTypes)
                Console.WriteLine(fileType);
            Console.WriteLine("======================================");
        }
    }
}
