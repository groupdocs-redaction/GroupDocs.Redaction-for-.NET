﻿using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to set license from a stream.
    /// </summary>
    class SetLicenseFromStream
    {
        public static void Run()
        {
            Console.WriteLine("[Quick Start] # SetLicenseFromStream.cs : Set license from stream");
            if (File.Exists(Constants.LicensePath))
            {
                using (FileStream stream = File.OpenRead(Constants.LicensePath))
                {
                    License license = new License();
                    license.SetLicense(stream);
                }

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
