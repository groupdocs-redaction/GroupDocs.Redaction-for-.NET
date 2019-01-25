using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Redaction.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Working with License
            //Apply License
            //Common.SetLicense();

            //Apply Dynabic Metered License
            //Common.UseDynabicMeteredAccount();
            #endregion

            #region Common Operations
            //Load Document
            //Common.LoadDocument();

            //Load Document Using Stream
            //Common.LoadDocumentUsingStream();

            //Save Document
            //Common.SaveDocument();

            #endregion

            #region Working with Text Redaction 
            //Perform a exact phrase redaction
            //Redaction.Text.ExactPhraseRedaction();
            
            //Perform a case sensitive exact phrase redaction 
            //Redaction.Text.CaseSensitiveExactPhraseRedaction();
            
            //Color Redacted Text 
            //Redaction.Text.ColorRedactedText();
            
            //Peform a regular expression redaction
            //Redaction.Text.RegularExpressionRedaction();

            //Work with password protected document 
            //Redaction.Text.PasswordProtectedDocument();
            #endregion

            #region Working with Metadata Redaction
            //Filter document metadata 
            //Redaction.Metadata.FilterMetadata();

            //Clean document metadata
            //Redaction.Metadata.CleanDocumentMetadata();

            //Search and replace metadata 
            //Redaction.Metadata.MetadataSearchRedaction();

            //Search and replace metadata using filters
            //Redaction.Metadata.MetadataSearchRedactionUsingFilters();

            #endregion

            #region Working with Annotation Redaction
            //Remove Annotations 
            //Redaction.Annotation.AnnotationRedaction();

            //Remove sensitive information from annotations 
            //Redaction.Annotation.RemoveSensitiveInformationFromAnnotation();

            #endregion

            #region Working with Tabular Redaction
            //Work with tabular document redaction
            //Redaction.Tabular.TabularDocumentRedaction();
            #endregion

            #region Working with customizations
            //Work with file extensions
            //Customization.WorkWithFileExtensions();

            //Work with redaction callback 
            //Customization.UseRedactionCallback();

            //Create a custom file foramt 
            //Customization.CreateCustomFileFormat();
            #endregion

            Console.WriteLine("Operation completed...");

            Console.ReadKey();
        }
    }
}
