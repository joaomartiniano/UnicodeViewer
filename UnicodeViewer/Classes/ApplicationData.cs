/*
 * Copyright (c) João Martiniano
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UnicodeViewer
{
    /// <summary>
    /// Stores the application data.
    /// </summary>
    public static class ApplicationData
    {
        /// <summary>
        /// Holds all the Unicode code blocks.
        /// </summary>
        public static List<UnicodeViewer.UnicodeCodeBlock> UnicodeCodeBlocks { get; set; } = new List<UnicodeViewer.UnicodeCodeBlock>();

        /// <summary>
        /// Holds all the Unicode codepoints.
        /// </summary>
        public static Dictionary<char, string> UnicodeCodePoints { get; set; } = new Dictionary<char, string>(UnicodeViewer.Settings.CODE_POINT_UPPER_LIMIT + 1);

        /// <summary>
        /// Initialize the list of Unicode code blocks: reads the information from the file UnicodeBlocks.txt
        /// </summary>
        public static void InitializeUnicodeCodeBlocks()
        {
            int start = -1;
            int end = -1;
            string[] s = Properties.Resources.UnicodeBlocks.Split('\n');
            int count = s.Count();

            for (int i = 0; i < count; ++i)
            {
                string[] items = s[i].Split(new string[] { "..", ";" }, StringSplitOptions.None);

                start = int.Parse(items[0], NumberStyles.HexNumber);
                end = int.Parse(items[1], NumberStyles.HexNumber);

                UnicodeCodeBlocks.Add(new UnicodeCodeBlock(items[2], start, end));

                // Stop adding Unicode code blocks after the 'Specials' block
                if (end == UnicodeViewer.Settings.CODE_POINT_UPPER_LIMIT) break;
            }

            s = null;
        }

        /// <summary>
        /// Initialize the list of Unicode code points: reads the information from the file UnicodeData.txt
        /// </summary>
        public static void InitializeUnicodeCodePoints()
        {
            string[] s = Properties.Resources.UnicodeData.Split('\n');
            int count = s.Count();
            int char_code = '\0';

            for (int j = 0, i = 1; j < count; ++j, ++i)
            {
                string[] items = s[j].Split(';');
                char_code = int.Parse(items[0], NumberStyles.HexNumber);

                UnicodeCodePoints.Add((char)char_code, items[1]);

                // Stop adding if the last character of the last Unicode block is reached
                if (i == 0x4137) break;
            }

            s = null;
        }
    }
}
