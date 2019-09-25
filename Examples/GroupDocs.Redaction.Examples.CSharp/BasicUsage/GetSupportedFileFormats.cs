// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2018 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IEnumerable<FileType> supportedFileTypes = FileType
                .GetSupportedFileTypes()
                .OrderBy(f => f.Extension);

            foreach (FileType fileType in supportedFileTypes)
                Console.WriteLine(fileType);
        }
    }
}
