﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Redactions;

    using GroupDocs.Redaction.Examples.CSharp.HelperClasses;

    /// <summary>
    /// The following example demonstrates how to attach and use an IRedactionCallback implementation
    /// </summary>
    class UseRedactionCallback
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.SAMPLE_DOCX))
            {
                // Assign an instance before using Redactor
                Redactor.RedactionCallback = new RedactionDump();
                redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                redactor.Save();
            }
        }
    }
 }

