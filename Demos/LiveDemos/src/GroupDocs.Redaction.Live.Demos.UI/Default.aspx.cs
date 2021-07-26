using System;
using GroupDocs.Redaction.Live.Demos.UI.Config;
using System.Web;
using GroupDocs.Redaction.Live.Demos.UI.Models;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GroupDocs.Redaction.Live.Demos.UI.Helpers;

namespace GroupDocs.Redaction.Live.Demos.UI
{
	public partial class Default : BasePage
	{
        public string fileFormat = "";
        string logMsg = "";

        private string GetValidFileExtensions(string validationExpression)
        {
            string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

            int index = validFileExtensions.LastIndexOf(",");
            if (index != -1)
            {
                string substr = validFileExtensions.Substring(index);
                string str = substr.Replace(",", " or");
                validFileExtensions = validFileExtensions.Replace(substr, str);
            }

            return validFileExtensions;
        }

        protected void Page_Load(object sender, EventArgs e)
		{            
            if (!IsPostBack)
			{
                dvAllFormats.Visible = true;

                aPoweredBy.InnerText = "GroupDocs.Redaction. "; ;
				aPoweredBy.HRef = "https://products.groupdocs.com/redaction";

                string validationExpression = Resources["RedactionValidationExpression"];
                if (Page.RouteData.Values["fileformat"] != null)
                {
                    validationExpression = "." + Page.RouteData.Values["fileformat"].ToString().ToLower();
                }
                string validFileExtensions = GetValidFileExtensions(validationExpression);
                ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";                
                ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + validFileExtensions;
                
                ddlTo.Items.Clear();
                string[] lstFormats = new string[] { "Text", "Metadata"};                
                foreach (string str in lstFormats)
                {
                    ddlTo.Items.Add(new ListItem(str, str.ToLower()));
                }               

                Page.Title = "Free online document redaction for DOC, DOCX, PDF, XLSX, PPTX and other formats";
                Page.MetaDescription = "Free online document redaction. Hide or remove sensitive content and metadata from files.";
                hdescription.InnerHtml = "Hide or remove sensitive content and metadata from document";
                if (Page.RouteData.Values["fileformat"] != null)
                {
                    hheading.InnerHtml = "Free Online  " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Document Redaction";
                    hdescription.InnerHtml = string.Format("Hide or remove sensitive content and metadata from {0} document", Page.RouteData.Values["fileformat"].ToString().ToUpper());
                    hfToFormat.Value = Page.RouteData.Values["fileformat"].ToString();

                    Page.Title = "Free Online  " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Document Redaction - GroupDocs.App";
                    Page.MetaDescription = string.Format("Free online {0} document redaction. Hide or remove sensitive content and metadata from {0} files.", Page.RouteData.Values["fileformat"].ToString().ToUpper());
                }
            }
		}      

		protected void btnRedact_Click(object sender, EventArgs e)
		{
            Config.Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            Config.Configuration.FileDownloadLink = Config.Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

            if (IsValid)
            {
                bool errFlag = true;                                

                if (txtSearchValue.Value.Trim().Length == 0)
                {
                    pMessage.InnerHtml = txtSearchValue.Attributes["placeholder"].ToString();
                }
                else if (txtRedactValue.Value.Trim().Length == 0)
                {
                    pMessage.InnerHtml = txtRedactValue.Attributes["placeholder"].ToString();
                }
                else if ((UploadFile.PostedFile == null) || (UploadFile.PostedFile.ContentLength == 0))
                {
                    pMessage.InnerHtml = Resources["FileSelectMessage"];
                }
                else
                {
                    errFlag = false;
                }                                

                if (!errFlag)
                {                    
                    try
                    {
                        string fn = Regex.Replace(System.IO.Path.GetFileName(UploadFile.PostedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
                        string SaveLocation = GroupDocs.Redaction.Live.Demos.UI.Config.Configuration.AssetPath + fn;
                        UploadFile.PostedFile.SaveAs(SaveLocation);                        
                        var isFileUploaded = FileManager.UploadFile(SaveLocation, "");

                        if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
                        {
                            Response response = GroupDocsRedactionApiHelper.RedactFile(isFileUploaded.FileName, isFileUploaded.FolderId, ddlTo.SelectedItem.Text.ToLower(), txtSearchValue.Value.Trim(), txtRedactValue.Value.Trim());

                            if (response == null)
                            {
                                throw new Exception(Resources["APIResponseTime"]);
                            }
                            else if (response.StatusCode == 200)
                            {
                                string url = GroupDocs.Redaction.Live.Demos.UI.Config.Configuration.FileDownloadLink + "?FileName=" + response.FileName + "&Time=" + DateTime.Now.ToString();
                                litDownloadNow.Text = "<a target=\"_blank\" href=\"" + url + "\" class=\"btn btn-success btn-lg\">" + Resources["DownLoadNow"] + " <i class=\"fa fa-download\"></i></a>";
                                downloadUrl.Value = HttpUtility.UrlEncode(url);

                                ConvertPlaceHolder.Visible = false;
                                DownloadPlaceHolder.Visible = true;

                                logMsg = "ControllerName: GroupDocsRedactionController FileName: " + response.FileName + " FolderName: " + isFileUploaded.FolderId + " OutFileExtension: " + "txt";
                            }
                            else
                            {
                                string msg = response.Status;

                                if (msg.ToLower().Contains("password"))
                                {
                                    string asposeProduct = GetAsposeUnlockProduct(isFileUploaded.FileName);
                                    if (asposeProduct != null)
                                    {
                                        string asposeUrl = GroupDocs.Redaction.Live.Demos.UI.Config.Configuration.ProductsGroupDocsAppsURL.ToLower().Replace("groupdocs", "aspose") + "/" + asposeProduct.ToLower() + "/unlock";
                                        msg = "Your file seems to be encrypted. Please use our <a href=\"" + asposeUrl + "\">\"Unlock " + asposeProduct + "\"</a> app to remove the password.";
                                    }
                                }

                                throw new Exception(msg);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        pMessage.InnerHtml = "Error: " + ex.Message;
                        pMessage.Attributes.Add("class", "alert alert-danger");
                    }
                } 
                else
                {
                    pMessage.Attributes.Add("class", "alert alert-danger");
                }
			}
		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
                if (emailTo.Value.Trim() == "")
                {
                    pMessage2.InnerHtml = Resources["MissingEmailMsg"];
                    pMessage2.Attributes.Add("class", "alert alert-danger");
                }
                else
                {
                    string url = HttpUtility.UrlDecode(downloadUrl.Value);
                    string emailBody = EmailManager.PopulateEmailBody(Resources["RedactionEmailHeading"], url, Resources["FileRedactSuccessMessage1"]);
                    EmailManager.SendEmail(emailTo.Value, GroupDocs.Redaction.Live.Demos.UI.Config.Configuration.FromEmailAddress, Resources["RedactionEmailTitle"], emailBody, "");

                    pMessage2.Attributes.Add("class", "alert alert-success");
                    pMessage2.InnerHtml = Resources["FileRedactionSuccessMessage"];
                }
			}
			catch (Exception ex)
			{				
				pMessage2.InnerHtml = "Error: " + ex.Message;
				pMessage2.Attributes.Add("class", "alert alert-danger");
			}
		} 
    }
}