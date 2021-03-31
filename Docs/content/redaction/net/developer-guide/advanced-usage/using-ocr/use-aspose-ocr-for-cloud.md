---
id: use-aspose-ocr-for-cloud
url: redaction/net/use-aspose-ocr-for-cloud
title: Use Aspose.OCR for Cloud SDK
weight: 3
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
This implementation is based on [Aspose.OCR for Cloud SDK](https://products.aspose.cloud/ocr/net). Although it requires a valid Aspose.Cloud subscription, you can always [request a trial](https://dashboard.aspose.cloud/).

Let's suppose that the Aspose.Cloud AppSid and AppKey are stored in system environment variables ASPOSE_CLOUD_APPSID and ASPOSE_CLOUD_APPKEY. 

**C#**

```csharp
using Aspose.Ocr.Cloud.Sdk;
using Aspose.Ocr.Cloud.Sdk.Model;
using Aspose.Ocr.Cloud.Sdk.Model.Requests;
using Newtonsoft.Json.Linq;

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
        // Recursively parse json tree with regions and text lines.
    }

    ...
}

```

The PostOcrFromUrlOrContent() method with ResultType.Internal returns a JSON-serialized tree of text regions and recognized lines, with bounding rectangles. The text line is represented by a single object.

You can find full implementation and an example of its usage here [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET).

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
