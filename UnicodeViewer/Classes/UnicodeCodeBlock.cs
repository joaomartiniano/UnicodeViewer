using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeViewer
{
    /// <summary>
    /// Represents a Unicode code block.
    /// </summary>
    public class UnicodeCodeBlock
    {
        /// <summary>
        /// The name of the Unicode code block.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The start of the Unicode code block.
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// The end of the Unicode code block.
        /// </summary>
        public int End { get; set; } = 0;

        public UnicodeCodeBlock(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Returns the number of characters in this block.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCharacters()
        {
            return End - Start + 1;
        }
    }
}
