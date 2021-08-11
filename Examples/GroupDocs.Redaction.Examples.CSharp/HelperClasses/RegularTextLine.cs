using System;
using System.Collections.Generic;
using System.Drawing;

namespace GroupDocs.Redaction.Examples.CSharp.HelperClasses
{
    using GroupDocs.Redaction.Integration.Ocr;

    class RegularTextLine
    {
        public static List<TextFragment> SplitToFragments(string lineText, Rectangle boundingRect)
        {
            List<TextFragment> fragments = new List<TextFragment>();
            if (!string.IsNullOrEmpty(lineText))
            {
                int index = 0, fragIndex = 0;
                bool isWhitespace = false;
                List<char> frag = new List<char>();
                int previousWidth = 0;
                float fixWidthChar = boundingRect.Width / GetEquivalentLength(lineText);
                while (index < lineText.Length)
                {
                    if (frag.Count == 0)
                    {
                        isWhitespace = (lineText[index] == ' ');
                    }
                    else
                    {
                        bool altIsWhitespace = (lineText[index] == ' ');
                        if (index == lineText.Length - 1) frag.Add(lineText[index]);
                        if (altIsWhitespace != isWhitespace || (index == lineText.Length - 1))
                        {
                            string fragment = new string(frag.ToArray());
                            int fragWidth = (int)Math.Round(GetEquivalentLength(fragment) * fixWidthChar);
                            int actualLength = (index == lineText.Length - 1) ? lineText.Length : index;
                            previousWidth = (int)Math.Round(GetEquivalentLength(lineText.Substring(0, actualLength - frag.Count)) * fixWidthChar);
                            fragments.Add(new TextFragment(fragment, new Rectangle(boundingRect.X + previousWidth,
                                boundingRect.Y, fragWidth, boundingRect.Height)));
                            fragIndex += fragment.Length;
                            frag.Clear();
                            isWhitespace = altIsWhitespace;
                        }
                    }
                    frag.Add(lineText[index]);
                    index++;
                }
            }
            return fragments;
        }

        private static readonly List<char> _narrowChars = new List<char>(new char[] { ',', '.', ':', ';', '!', '|', '(', ')', '{', '}',
            'l', 'i', 'I', '-', '+', 'f', 't', 'r'});
        private static readonly List<char> _wideChars = new List<char>(new char[] { '\t', 'm', 'w', 'M', 'W' });

        public static float GetEquivalentLength(string lineText)
        {
            float length = 0F;
            foreach (var c in lineText)
            {
                if (c == ' ')
                    length += 0.6F;
                else if (_narrowChars.Contains(c))
                    length += 0.5F;
                else if (_wideChars.Contains(c) || char.IsUpper(c))
                    length += 1.5F;
                else
                    length += 1F;
            }
            return length;
        }
    }
}
