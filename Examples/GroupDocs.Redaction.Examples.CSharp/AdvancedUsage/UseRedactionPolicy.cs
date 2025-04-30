using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Redaction.Options;
    
    /// <summary>
    /// The following example demonstrates how to load and apply a redaction policy
    /// </summary>
    /// <remarks>
    /// The policy is loaded from a file and applied to all files in given folder. The redacted files are saved in different folders, depending on their processing status (success/failure).
    /// </remarks>
    class UseRedactionPolicy
    {
        public static void Run()
        {
            Console.WriteLine("[Example Advanced Usage] # UseRedactionPolicy.cs : Using redaction policies");

            // Prepare output directory and source file.
            string sourceFile = Utils.PrepareOutputDirectory(Constants.POLICY_FILE);
            var path = Path.GetDirectoryName(sourceFile);
            string success_path = Path.Combine(path, "Success");
            if (!Directory.Exists(success_path)){Directory.CreateDirectory(success_path);}
            string fail_path = Path.Combine(path, "Fail");
            if (!Directory.Exists(fail_path)) { Directory.CreateDirectory(fail_path); }

            //ExStart:ConfigurableRedaction_19.3

            //Initialize RedactionPolicy
            RedactionPolicy policy = RedactionPolicy.Load(sourceFile);

            foreach (var fileEntry in Directory.GetFiles(Constants.POLICY_INBOUND))
            {
                using (Redactor redactor  = new Redactor( fileEntry))
                {
                    //Apply redaction 
                    RedactorChangeLog result = redactor.Apply(policy);
                        
                    // Set the output directory path, it is supposed that all folders exist
                    String resultFolder = result.Status != RedactionStatus.Failed ? success_path : fail_path;
                    var outputFile = Path.Combine(resultFolder, Path.GetFileName(fileEntry));
                    // Save the output files after applying redactions
                    using (Stream fileStream = File.Create(outputFile))
                    {
                        redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
                    }
                    Console.WriteLine($"\nRedacted file saved to {outputFile}.");
                }
            }
            //ExEnd:ConfigurableRedaction_19.3
            Console.WriteLine("======================================");
        }
    }
}
