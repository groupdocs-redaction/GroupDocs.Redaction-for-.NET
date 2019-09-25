using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using GroupDocs.Redaction.Redactions;

    /// <summary>
    /// This is an example of IRedactionCallback implementation, dumping all changes to system console
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
}
