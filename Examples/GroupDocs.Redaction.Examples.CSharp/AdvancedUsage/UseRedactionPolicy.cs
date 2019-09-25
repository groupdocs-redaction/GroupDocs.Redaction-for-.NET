
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Options;
    
    /// <summary>
    /// The following example demonstrates how to load and apply a redaction policy
    /// </summary>
    /// <remarks>
    /// The policy is loaded from a file and applied to all files in given folder. The redacted files are saved in different folders, depending on their processinhg status (success/failure).
    /// </remarks>
    class UseRedactionPolicy
    {
        public static void Run()
        {
            //ExStart:ConfigurableRedaction_19.3

            //Initialize RedactionPolicy
            RedactionPolicy policy = RedactionPolicy.Load(Constants.POLICY_FILE);

            foreach (var fileEntry in Directory.GetFiles(Constants.POLICY_INBOUND))
            {
                using (Redactor redactor  = new Redactor( fileEntry))
                {
                    //Apply redaction 
                    RedactorChangeLog result = redactor.Apply(policy);
                        
                    // Set the output directory path, it is supposed that all folders exist
                    String resultFolder = result.Status != RedactionStatus.Failed ?Constants.POLICY_OUTBOUND_DONE : Constants.POLICY_OUTBOUND_FAILED;
                        
                    // Save the ouput files after applying redactions
                    using (Stream fileStream = File.Create(Path.Combine(resultFolder, Path.GetFileName(fileEntry))))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
                    }
                }
            }
            //ExEnd:ConfigurableRedaction_19.3
        }
    }
}
