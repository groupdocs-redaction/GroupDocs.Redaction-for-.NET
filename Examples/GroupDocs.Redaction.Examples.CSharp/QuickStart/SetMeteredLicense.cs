using GroupDocs.Redaction.Redactions;
using System;

namespace GroupDocs.Redaction.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to set Metered license.
    /// Learn more about Metered license at https://purchase.groupdocs.com/faqs/licensing/metered.
    /// </summary>
    class SetMeteredLicense
    {
        public static void Run()
        {
            // initialize Metered API
            Metered metered = new Metered();
            // set-up credentials
            metered.SetMeteredKey(Constants.PublicKey, Constants.PrivateKey);

            // do some work:

            // Load Word document
            using (Redactor redactor = new Redactor(Constants.CONVERSION_CONTROL_DOCX))
            {
                // Do some redaction
                RedactorChangeLog result = redactor.Apply(new ExactPhraseRedaction("John Doe", new ReplacementOptions(System.Drawing.Color.Red)));

                // and get consumption quantity
                decimal consumptionQuantitiy = Metered.GetConsumptionQuantity();

                // get consumption credit (Supported since version 19.5)
                decimal consumptionCredit = Metered.GetConsumptionCredit();
            }
        }
    }
}
