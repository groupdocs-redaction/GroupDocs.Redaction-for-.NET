using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using GroupDocs.Redaction.Configuration;
    using GroupDocs.Redaction.Integration;
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// This is an example of DocumentFormatInstance-derived format handler class with custom logic for textual documents processing.
    /// </summary>
    public class CustomTextualDocument : DocumentFormatInstance, ITextualFormatInstance
    {
        private RedactorSettings Settings { get; set; }
        private List<string> FileContent { get; set; }

        public CustomTextualDocument()
        {
            FileContent = new List<string>();
        }

        public override void Initialize(DocumentFormatConfiguration config, RedactorSettings settings)
        {
            Settings = settings;
        }

        public override void Load(System.IO.Stream input)
        {
            FileContent.Clear();
            using (var reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {
                    FileContent.Add(reader.ReadLine());
                }
            }
        }

        public override void Save(System.IO.Stream output)
        {
            var writer = new StreamWriter(output);
            foreach (var line in FileContent)
            {
                writer.WriteLine(line);
            }
            writer.Flush();
        }

        public RedactionResult ReplaceText(Regex regularExpression, ReplacementOptions options)
        {
            try
            {
                if (options.ActionType != Redactions.ReplacementType.ReplaceString)
                {
                    return  RedactionResult.Failed("This format allows only ReplaceString redactions!");
                }
                for (int i = 0; i < FileContent.Count; i++)
                {
                    FileContent[i] = regularExpression.Replace(FileContent[i], options.Replacement);
                }
                return RedactionResult.Successful();
            }
            catch (Exception ex)
            {
                return RedactionResult.Failed(ex.ToString());
            }
        }
    }
}
