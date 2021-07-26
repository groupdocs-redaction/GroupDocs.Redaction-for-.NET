using GroupDocs.Redaction.Live.Demos.UI.Models;
using System.Net.Http;
using System.Net.Http.Headers;


namespace GroupDocs.Redaction.Live.Demos.UI.Helpers
{
	public class GroupDocsRedactionApiHelper
	{
		public static Response RedactFile(string fileName, string folderName, string redactType, string searchText, string replaceText)
        {
			Response convertResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                System.Threading.Tasks.Task taskUpload = client.GetAsync(GroupDocs.Redaction.Live.Demos.UI.Config.Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsRedaction/RedactFile?fileName=" + fileName 
                    + "&folderName=" + folderName + "&redactType=" + redactType + "&searchText=" + searchText + "&replaceText=" + replaceText).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							convertResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});

				taskUpload.Wait();
			}

			return convertResponse;
		}
		
	}
}