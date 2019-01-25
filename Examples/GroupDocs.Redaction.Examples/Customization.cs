using GroupDocs.Redaction.Configuration;
using GroupDocs.Redaction.Integration;
using GroupDocs.Redaction.Redactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples
{
    public static class Customization
    {
        //Sample filepath
        private const string FilePath = "Documents/Doc/sample.docx";
        //Sample text filpath
        private const string TextFilePath = "Documents/Doc/sample.txt";
        /// <summary>
        /// This method is used when for some reason files have non-standard extensions or if its format is supported, but not pre-configured. 
        /// For instance, all kinds of plain text files (logs, dumps etc) could be opened with text processors like MS Word/Open Office.
        /// </summary>
        public static void WorkWithFileExtensions()
        {
            RedactorConfiguration config = RedactorConfiguration.GetInstance();
            DocumentFormatConfiguration docxSettings = config.FindFormat(".docx");
            docxSettings.ExtensionFilter = docxSettings.ExtensionFilter + ",.txt";
            using (Document doc = Redactor.Load(Common.MapSourceFilePath(TextFilePath)))
            {
                // Here we can use document instance to perform redactions
                doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                doc.Save();
            }
        }
        /// <summary>
        /// This method rejects or accepts specific changes during redaction process or keeps a full log of changes in the document
        /// </summary>
        public static void UseRedactionCallback()
        {
            using (Document doc = Redactor.Load(Common.MapSourceFilePath(FilePath)))
            {
                // Assign an instance before using Redactor
                Redactor.RedactionCallback = new RedactionDump();
                doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                doc.Save();
            }
        }
        /// <summary>
        /// This method supports a new document format(txt), it implements a handler for it by inheriting from DocumentFormatInstance class
        /// </summary>
        public static void CreateCustomFileFormat()
        {
            var config = new DocumentFormatConfiguration()
            {
                ExtensionFilter = ".txt",
                DocumentType = typeof(PlainTextDocument)
            };
            using (Document doc = Redactor.Load(Common.MapSourceFilePath(TextFilePath), new LoadOptions(config)))
            {
                // Here we can use document instance to perform redactions
                doc.RedactWith(new ExactPhraseRedaction("John Doe", new ReplacementOptions("[personal]")));
                // Save the document to "*_AnyText.*" (e.g. timestamp instead of "AnyText") in its file name without rasterization
                doc.Save(new SaveOptions(false, "AnyText"));
            }
        }
    }
    /// <summary>
    /// RedactionDump callback class to dump changes to system console
    /// </summary>
    public class RedactionDump : IRedactionCallback
    {
        public RedactionDump()
        {
        }

        public bool AcceptRedaction(RedactionDescription description)
        {
            Console.Write("{0} redaction, {1} action, item {2}. ", description.RedactionType, description.ActionType, description.OriginalText);
            if (description.Replacement != null)
            {
                Console.Write("Text {0} is replaced with {1}. ", description.Replacement.OriginalText, description.Replacement.Replacement);
            }
            Console.WriteLine();
            return true;
        }
    }
    /// <summary>
    /// DocumentFormatInstance class for plain text document
    /// </summary>
    public class PlainTextDocument : DocumentFormatInstance, ITextualFormatInstance
    {
        private List<string> FileContent { get; set; }

        public PlainTextDocument()
        {
            FileContent = new List<string>();
        }

        public override void Initialize(DocumentFormatConfiguration config)
        {
        }

        public override void Load(System.IO.Stream input)
        {
            FileContent.Clear();
            using (var reader = new StreamReader(input))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        FileContent.Add(line);
                    }
                }
                while (!string.IsNullOrEmpty(line));
                reader.Close();
            }
        }

        public override void Save(System.IO.Stream output)
        {
            using (var writer = new StreamWriter(output))
            {
                foreach (var line in FileContent)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            }
        }

        public RedactionResult ReplaceText(Regex regex, Redactions.ReplacementOptions options)
        {
            try
            {
                if (options.ActionType != Redactions.ReplacementType.ReplaceString)
                {
                    return new RedactionResult(false, "This format allows only ReplaceString redactions!");
                }
                for (int i = 0; i < FileContent.Count; i++)
                {
                    FileContent[i] = regex.Replace(FileContent[i], options.Replacement);
                }
                return new RedactionResult(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new RedactionResult(false, ex.ToString());
            }
        }
    }
}
