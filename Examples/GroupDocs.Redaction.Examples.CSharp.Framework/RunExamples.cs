using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples.CSharp
{
    class RunExamples
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            // Please uncomment the example you want to try out

            #region Quick Start
            QuickStart.SetLicenseFromFile.Run();
            //QuickStart.SetLicenseFromStream.Run();
            //QuickStart.SetMeteredLicense.Run();
            QuickStart.HelloWorld.Run();
            #endregion // Quick Start

            #region Basic Usage

            #region Redaction Basics
            // Apply single redaction
            //BasicUsage.RedactionBasics.ApplyRedaction.Run();

            // Apply multiple redactions and analyse redaction result
            //BasicUsage.RedactionBasics.ApplyMultipleRedactions.Run();
            #endregion

            #region Text Redactions 
            //Perform an exact phrase redaction
            //BasicUsage.TextRedactions.UseExactPhraseRedaction.Run();

            //Perform a case sensitive exact phrase redaction 
            //BasicUsage.TextRedactions.UseExactPhraseCaseSensitive.Run();

            //Replace text with colored rectangle 
            //BasicUsage.TextRedactions.UseColoredRectangle.Run();

            //Peform a regular expression redaction
            //BasicUsage.TextRedactions.UseRegularExpression.Run();
            #endregion

            #region Metadata Redactions
            //Clean document metadata
            //BasicUsage.MetadataRedactions.CleanMetadata.Run();

            //Clean document metadata matching filter 
            //BasicUsage.MetadataRedactions.CleanMetadataWithFilter.Run();

            //Search and replace metadata 
            //BasicUsage.MetadataRedactions.RedactMetadata.Run();

            //Search and replace metadata using filters
            //BasicUsage.MetadataRedactions.RedactMetadataWithFilter.Run();
            #endregion

            #region Annotation Redactions
            //Remove Specific Annotations 
            //BasicUsage.AnnotationRedactions.RemoveAllAnnotations.Run();

            //Remove Specific Annotations 
            //BasicUsage.AnnotationRedactions.RemoveAnnotations.Run();

            //Remove sensitive information from annotations 
            //BasicUsage.AnnotationRedactions.RedactAnnotations.Run();
            #endregion

            #region Spreadsheet Redaction
            //Work with spreadsheet document redaction
            //BasicUsage.SpreadsheetRedactions.FilterBySpreadsheetAndColumn.Run();
            #endregion

            #region Image Redactions
            //Perform image formats redactions.
            //BasicUsage.ImageRedactions.RedactImageArea.Run();

            //Remove Image metadata.
            //BasicUsage.ImageRedactions.CleanImageMetadada.Run();
            #endregion

            #endregion // Basic Usage

            #region Advanced Usage

            #region Loading Documents
            // Open file from local disc
            //AdvancedUsage.LoadingDocuments.LoadFromLocalDisc.Run();

            // Open file from stream
            //AdvancedUsage.LoadingDocuments.LoadFromStream.Run();

            //Redact a Password-Protected Document
            //AdvancedUsage.LoadingDocuments.OpenPasswordProtectedFile.Run();

            //Use custom ILogger implementation 
            //AdvancedUsage.LoadingDocuments.UseAdvancedLogging.Run();
            #endregion

            #region Saving Documents
            //Save the Redacted Document In Its Original Format With Timestamp
            //AdvancedUsage.SavingDocuments.SaveInOriginalFormat.Run();

            //Save the Document as PDF 
            //AdvancedUsage.SavingDocuments.SaveInRasterizedPDF.Run();

            //Redact and save the document overwriting its original
            //AdvancedUsage.SavingDocuments.SaveOverwritingOriginalFile.Run();

            //Save the document to a custom location using stream
            //AdvancedUsage.SavingDocuments.SaveToStream.Run();

            // Save with default options
            //AdvancedUsage.SavingDocuments.SaveWithDefaultOptions.Run();

            //Save only specific pages of thge Document as PDF 
            //AdvancedUsage.SavingDocuments.SelectSpecificPagesForRasterizedPDF.Run();
            #endregion // Loading and Saving

            //Adding custom file extensions
            //AdvancedUsage.ExtendSupportedExtensionsList.Run();

            //Work with redaction callback 
            //AdvancedUsage.UseRedactionCallback.Run();

            //Create a custom file foramt 
            //AdvancedUsage.CreateCustomFormatHandler.Run();

            //configure redactions in XML and apply them to any document as a single redaction profile.
            //AdvancedUsage.UseRedactionPolicy.Run();
            #endregion

            Console.WriteLine("Operation completed...");

            Console.ReadKey();
        }
    }
}
