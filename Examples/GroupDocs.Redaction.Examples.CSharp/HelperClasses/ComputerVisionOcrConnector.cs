
using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using Newtonsoft.Json.Linq;
    using GroupDocs.Redaction.Integration.Ocr;

    /// <summary>
    /// This is an example of IOcrConnector implementation, using Microsoft Azure Cognitive Services Computer Vision.
    /// </summary>
    public class ComputerVisionOcrConnector : IOcrConnector
    {
        private const string OcrUri = "vision/v2.1/ocr";
        private readonly string SubscriptionKey;
        private readonly string Endpoint;

        public ComputerVisionOcrConnector()
        {
            Endpoint = Environment.GetEnvironmentVariable("COMPUTER_VISION_ENDPOINT");
            SubscriptionKey = Environment.GetEnvironmentVariable("COMPUTER_VISION_SUBSCRIPTION_KEY");
        }

        public string GetServiceUri(bool detectOrientation, string language)
        {
            // Request parameters. 
            // The language parameter doesn't specify a language, so the 
            // method detects it automatically.
            // The detectOrientation parameter is set to true, so the method detects and
            // and corrects text orientation before detecting text.

            // Assemble the URI for the REST API method.
            return string.Format("{0}{1}?language={2}&detectOrientation={3}", Endpoint, OcrUri,
                string.IsNullOrEmpty(language) ? "unk" : language, detectOrientation).ToLower();
        }

        public RecognizedImage Recognize(Stream imageStream)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    // authentication
                    client.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
                    // payload
                    BinaryReader binaryReader = new BinaryReader(imageStream);
                    var data = binaryReader.ReadBytes((int)imageStream.Length);
                    client.Headers[HttpRequestHeader.ContentType] = "application/octet-stream";
                    string stringResponse = string.Empty;
                    try
                    {
                        byte[] result = client.UploadData(GetServiceUri(true, null), data);
                        stringResponse = Encoding.UTF8.GetString(result);
                    }
                    catch (Exception ex)
                    {
                        // MS Azure Cognintive services reports 400 Bad requests and other exceptions on small pictures and pictures with no text
                        Console.WriteLine("Microsoft Azure Cognitive Services consider this image as wrong ({0})", ex.ToString());
                    }
                    if (!string.IsNullOrEmpty(stringResponse))
                    {
                        return CreateDtoFromResponse(JToken.Parse(stringResponse));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Microsoft Azure Cognitive Services Text Recognition failed: {0}", ex.ToString());
            }
            return new RecognizedImage(new List<TextLine>());
        }

        private RecognizedImage CreateDtoFromResponse(JToken jToken)
        {
            List<TextLine> lines = new List<TextLine>();
            if (jToken["regions"].Count() > 0)
            {
                foreach (var line in jToken["regions"][0]["lines"])
                {
                    List<TextFragment> fragments = new List<TextFragment>();
                    var words = line["words"];
                    for (int i = 0; i < words.Count(); i++)
                    {
                        fragments.Add(new TextFragment(words[i]["text"].ToString(), ParseRect(words[i]["boundingBox"].ToString())));
                        if (i != words.Count() - 1)
                        {
                            fragments.Add(new TextFragment(" ", Rectangle.Empty));
                        }
                    }
                    lines.Add(new TextLine(fragments));
                }
            }
            return new RecognizedImage(lines);
        }

        private Rectangle ParseRect(string boundingBox)
        {
            if (!string.IsNullOrEmpty(boundingBox))
            {
                var items = boundingBox.Split(',');
                if (items.Length == 4)
                {
                    return new Rectangle(int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), int.Parse(items[3]));
                }
            }
            return Rectangle.Empty;
        }
    }
}
