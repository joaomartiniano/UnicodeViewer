using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UnicodeViewer
{
    /// <summary>
    /// Static class that holds the application settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Upper limit of the Unicode code points displayed in this application.
        /// </summary>
        public const int CODE_POINT_UPPER_LIMIT = 0xFFFF;

        /// <summary>
        /// Minimum width of the application form.
        /// </summary>
        public static System.Drawing.Size FORM_MIN_SIZE = new Size(992, 589);

        /// <summary>
        /// Default font used in the character grid and in the character preview.
        /// </summary>
        public const string DEFAULT_FONT_NAME = "Arial";

        /// <summary>
        /// Default font size for the character grid.
        /// </summary>
        public const int GRID_DEFAULT_FONT_SIZE = 13;

        /// <summary>
        /// Minimum font size for the character grid.
        /// </summary>
        public const int GRID_MIN_FONT_SIZE = 10;

        /// <summary>
        /// Maximum font size for the character grid.
        /// </summary>
        public const int GRID_MAX_FONT_SIZE = 18;

        /// <summary>
        /// Number of columns in the character grid.
        /// </summary>
        public const int GRID_NUMBER_COLUMNS = 16;

        /// <summary>
        /// Row size of the character grid.
        /// </summary>
        public const int GRID_ROW_SIZE = 60;

        /// <summary>
        /// Border color for the character grid.
        /// </summary>
        public static System.Drawing.Color GRID_BORDER_COLOR = ColorTranslator.FromHtml("#ececec");

        /// <summary>
        /// Font used in the footer section of each cell of the character grid.
        /// </summary>
        public static string GRID_CELL_FOOTER_FONT_NAME = "Segoe UI";

        /// <summary>
        /// Font sized used in the footer section of each cell of the character grid.
        /// </summary>
        public static int GRID_CELL_FOOTER_FONT_SIZE = 7;

        /// <summary>
        /// Text color of each cell footer (of the character grid).
        /// </summary>
        public static System.Drawing.Brush GRID_CELL_FOOTER_COLOR = Brushes.DimGray;

        /// <summary>
        /// Text color of each cell footer (of the character grid) when the cell is selected.
        /// </summary>
        public static System.Drawing.Brush GRID_CELL_FOOTER_COLOR_SELECTED = Brushes.White;

        /// <summary>
        /// Default font size for the character preview.
        /// </summary>
        public static int CHARACTER_PREVIEW_DEFAULT_FONT_SIZE = 42;

        /// <summary>
        /// Minimum font size for the character preview.
        /// </summary>
        public static int CHARACTER_PREVIEW_MIN_FONT_SIZE = 8;

        /// <summary>
        /// Maximum font size for the character preview.
        /// </summary>
        public static int CHARACTER_PREVIEW_MAX_FONT_SIZE = 80;
    }
}
