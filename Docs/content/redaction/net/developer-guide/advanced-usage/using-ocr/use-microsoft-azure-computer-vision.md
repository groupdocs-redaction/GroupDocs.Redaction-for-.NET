---
id: use-microsoft-azure-computer-vision
url: redaction/net/use-microsoft-azure-computer-vision
title: Use Microsoft Azure Computer Vision API 
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---

This implementation is based on [Microsoft Azure Computer Vision API](https://docs.microsoft.com/en-US/azure/cognitive-services/computer-vision/). The service is paid, but you can [create a free subscription](https://azure.microsoft.com/free/cognitive-services/). Once you've done with subscription, you will have to [create Computer Vision resource](https://portal.azure.com/#create/Microsoft.CognitiveServicesComputerVision) using the free pricing tier (F0) to try the service, and upgrade later to a paid tier for production. As a result, you will get Computer Vision Endpoint and Subscription Key (let's suppose they are stored in the environment variables COMPUTER_VISION_ENDPOINT and COMPUTER_VISION_SUBSCRIPTION_KEY respectively). 

**C#**

```csharp
using Newtonsoft.Json.Linq;

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

    protected virtual RecognizedImage CreateDtoFromResponse(JToken jToken)
    {
        // Parse json response to extract lines and words with the bounding rectangles.
    }

    ...
}

```
The service returns a JSON-serialized with text regions and recognized words, each word with its bounding rectangle.

You can find full implementation and an example of its usage here [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET).

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
