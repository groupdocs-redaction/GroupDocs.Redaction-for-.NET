using System;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp.BasicUsage.RemovePageRedactions
{
    using GroupDocs.Redaction.Redactions;
    using GroupDocs.Redaction.Options;

    /// <summary>
    /// The following example demonstrates how to remove 3 frames from an animated GIF image.
    /// </summary>
    class RemoveFrameFromImage
    {
        public static void Run()
        {
            using (Redactor redactor = new Redactor(Constants.ANIMATED_GIF))
            {
                // Removes 5 frames starting from 3nd one, requires at least 7 frames
                if (redactor.GetDocumentInfo().PageCount >= 7)
                {
                    redactor.Apply(new RemovePageRedaction(PageSeekOrigin.Begin, 2, 5));
                    redactor.Save();
                }
            }
        }
    }
}
