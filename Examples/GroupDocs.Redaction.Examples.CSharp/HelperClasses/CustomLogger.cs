using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// This is an example of ILogger implementation, tracking count of error messages.
    /// </summary>
    public class CustomLogger : ILogger
    {
        public List<string> Errors { get; private set; }
        public List<string> Traces { get; private set; }
        public List<string> Warnings { get; private set; }

        public bool HasErrors { get { return Errors.Count > 0; } }

        public CustomLogger()
        {
            Errors = new List<string>();
            Traces = new List<string>();
            Warnings = new List<string>();
        }

        public void Error(string message)
        {
            Errors.Add(message);
        }

        public void Trace(string message)
        {
            Traces.Add(message);
        }

        public void Warning(string message)
        {
            Warnings.Add(message);
        }
    }
}
