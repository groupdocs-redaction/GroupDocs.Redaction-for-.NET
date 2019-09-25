// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// The following example demonstrates how to get document information for a file from stream.
    /// </summary>
    class GetFileInfoForAFileFromStream
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(File.OpenRead(Constants.SAMPLE_DOCX)))
            {
                IDocumentInfo info = redactor.GetDocumentInfo();
                Console.WriteLine("\nFile type: {0}\nNumber of pages: {1}\nDocument size: {2} bytes", info.FileType, info.PageCount, info.Size);
            }
        }
    }
}
