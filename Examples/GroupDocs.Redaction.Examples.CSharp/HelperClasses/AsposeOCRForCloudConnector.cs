using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using Newtonsoft.Json.Linq;

    using Aspose.Ocr.Cloud.Sdk;
    using Aspose.Ocr.Cloud.Sdk.Model;
    using Aspose.Ocr.Cloud.Sdk.Model.Requests;

    using GroupDocs.Redaction.Integration.Ocr;

    /// <summary>
    /// This is an example of IOcrConnector implementation, using Aspose.OCR for Cloud SDK.
    /// </summary>
    public class AsposeOCRForCloudConnector : IOcrConnector
    {
        private readonly Configuration configuration;

        public AsposeOCRForCloudConnector()
        {
            configuration = new Configuration();
            configuration.AppSid = Environment.GetEnvironmentVariable("ASPOSE_CLOUD_APPSID");
            configuration.AppKey = Environment.GetEnvironmentVariable("ASPOSE_CLOUD_APPKEY");
            configuration.ApiBaseUrl = "https://api.aspose.cloud";
            configuration.IdentityServerBaseUrl = "https://api.aspose.cloud";
        }

        public RecognizedImage Recognize(Stream imageStream)
        {
            try
            {
                OcrApi api = new OcrApi(configuration);
                var request = new PostOcrFromUrlOrContentRequest(imageStream, resultType: ResultType.Internal, dsrMode: DsrMode.DsrAndFilter);
                OCRResponse response = api.PostOcrFromUrlOrContent(request);
                return CreateDtoFromResponse(JToken.Parse(response.Text));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aspose.OCR for Cloud Recognition failed: {0}", ex.ToString());
            }
            return new RecognizedImage(new List<TextLine>());
        }

        protected virtual RecognizedImage CreateDtoFromResponse(JToken jToken)
        {
            return new RecognizedImage(LeafRecursion(jToken));
        }

        private TextLine[] LeafRecursion(JToken jToken)
        {
            List<TextLine> lines = new List<TextLine>();
            if (jToken["leaves"].Count() > 0)
            {
                foreach (var node in jToken["leaves"])
                {
                    if (node["leaves"].Count() > 0)
                    {
                        lines.AddRange(LeafRecursion(node));
                    }
                    else
                    {
                        TextLine textLine = CreateTextLine(node);
                        if (textLine != null)
                        {
                            lines.Add(textLine);
                        }
                    }
                }
            }
            return lines.ToArray();
        }

        private TextLine CreateTextLine(JToken line)
        {
            string lineText = line["values"].ToString();
            Rectangle lineRectangle = GetLineRectangle(line);
            if (!string.IsNullOrEmpty(lineText) && !lineRectangle.IsEmpty)
            {
                return new TextLine(RegularTextLine.SplitToFragments(lineText, lineRectangle));
            }
            else
            {
                return null;
            }
        }

        private Rectangle GetLineRectangle(JToken line)
        {
            var rect = line["rect"];
            return new Rectangle(rect[0].Value<int>(), rect[1].Value<int>(), rect[2].Value<int>() - rect[0].Value<int>(),
                rect[3].Value<int>() - rect[1].Value<int>());
        }
    }
}
