using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to set license from file.
    /// </summary>
    /// <remarks>
    /// The SetLicense method attempts to set a license from several locations relative to the executable and GroupDocs.Redaction.dll.
    /// You can also use the additional overload to load a license from a stream, this is useful for instance when the 
    /// License is stored as an embedded resource. 
    /// </remarks>
    class SetLicenseFromFile
    {
        public static void Run()
        {
            Console.WriteLine("[Quick Start] # SetLicenseFromFile.cs : Set license from file");
            if (File.Exists(Constants.LicensePath))
            {
                License license = new License();
                license.SetLicense(Constants.LicensePath);

                Console.WriteLine("License is set successfully.");
            }
            else
            {
                Console.WriteLine("\nWe do not ship any license with this example. " +
                                  "\nVisit the GroupDocs site to obtain either a temporary or permanent license. " +
                                  "\nLearn more about licensing at https://purchase.groupdocs.com/faqs/licensing. " +
                                  "\nLearn how to request a temporary license at https://purchase.groupdocs.com/temporary-license.");
            }
            Console.WriteLine("======================================");
        }
    }
}
