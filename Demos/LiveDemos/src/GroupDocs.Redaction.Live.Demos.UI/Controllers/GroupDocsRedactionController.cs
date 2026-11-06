using System.Web.Http;
using System.Threading.Tasks;
using GroupDocs.Redaction.Live.Demos.UI.Models;
using System;
using System.IO;
using GroupDocs.Redaction.Options;
using GroupDocs.Redaction.Redactions;

namespace GroupDocs.Redaction.Live.Demos.UI.Controllers
{
	public class GroupDocsRedactionController : ApiControllerBase
	{       
        [HttpGet]
		[ActionName("RedactFile")]
		public async Task<Response> RedactFile(string fileName, string folderName, string redactType, string searchText, string replaceText)
		{            
            string logMsg = "ControllerName: GroupDocsRedactionController FileName: " + fileName + " FolderName: " + folderName;            
            bool metadataActionFlag = redactType.ToLower().StartsWith("metadata") ? true : false;

			try
			{
                string fileExt = Path.GetExtension(fileName).Substring(1).ToLower();

                return await ProcessTask(fileName, folderName, "." + fileExt, false, "", delegate (string inFilePath, string outPath, string zipOutFolder)
				{
                    string outputDir = AppSettings.DemosOutputDirectory;
                    Directory.CreateDirectory(outputDir);
                    string copiedPath = Path.Combine(outputDir, Path.GetFileName(inFilePath));
                    File.Copy(inFilePath, copiedPath, true);

                    using (Redactor redactor = new Redactor(copiedPath))
                    {
                        if (metadataActionFlag)
                        {
                            redactor.Apply(new MetadataSearchRedaction(searchText, replaceText));
                        }
                        else
                        {
                            redactor.Apply(new ExactPhraseRedaction(searchText, new ReplacementOptions(replaceText)));
                        }

                        string redactedPath = redactor.Save(new SaveOptions() { AddSuffix = true, RasterizeToPDF = false });
                        File.Copy(redactedPath, outPath, true);
                    }
                });
			}
			catch (Exception exc)
			{				
                return new Response { FileName = fileName, FolderName = folderName, OutputType = redactType, Status = exc.Message, StatusCode = 500, Text = exc.ToString() };
			}
		}

        private async Task<Response> ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, string userEmail, ActionDelegate action)
		{
			try
			{
                //GroupDocs.Redaction.Live.Demos.UI.Models.License.SetGroupDocsRedactionLicense();
                return await Process2("GroupDocsRedactionController", fileName, folderName, outFileExtension, createZip, action);
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}
    }
}