
using System;
using System.IO;
using System.Collections.Generic;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using GroupDocs.Redaction.Integration.Ocr;

    public class AsposeOCRStandaloneConnector : IOcrConnector
    {
        public AsposeOCRStandaloneConnector(string licenseFile)
        {
            var lic = new Aspose.OCR.License();
            lic.SetLicense(licenseFile);
        }

        public RecognizedImage Recognize(Stream imageStream)
        {
            bool newStreamCreated = false;
            MemoryStream memStream = imageStream as MemoryStream;
            try
            {               
                if (memStream == null)
                {
                    newStreamCreated = true;
                    memStream = new MemoryStream();
                    imageStream.CopyTo(memStream);
                }
                var api = new Aspose.OCR.AsposeOcr();
                var rectangles = api.GetRectangles(memStream, Aspose.OCR.AreasType.LINES, false);
                var result = api.RecognizeImage(memStream, new Aspose.OCR.RecognitionSettings()
                {
                    Language = Aspose.OCR.Language.Eng,
                    RecognitionAreas = rectangles
                });
                return CreateDtoFromResponse(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aspose.OCR for .NET Recognition failed: {0}", ex.ToString());
            }
            finally
            {
                if (newStreamCreated)
                {
                    memStream.Dispose();
                }
            }
            return new RecognizedImage(new List<TextLine>());
        }

        protected virtual RecognizedImage CreateDtoFromResponse(Aspose.OCR.RecognitionResult result)
        {
            List<TextLine> lines = new List<TextLine>();
            for (int i = 0; i < result.RecognitionAreasText.Count; i++)
            {
                var fragments = RegularTextLine.SplitToFragments(result.RecognitionAreasText[i].Trim('\r', '\n'), result.RecognitionAreasRectangles[i]);
                lines.Add(new TextLine(fragments));
            }
            return new RecognizedImage(lines);
        }
    }
}
