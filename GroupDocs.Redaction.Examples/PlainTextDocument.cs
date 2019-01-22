using GroupDocs.Redaction.Configuration;
using GroupDocs.Redaction.Integration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples
{
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
