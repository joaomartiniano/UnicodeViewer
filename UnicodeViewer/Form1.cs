/* Copyright (c) João Martiniano. All rights reserved.
 * Licensed under the MIT License.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Text;

namespace UnicodeViewer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// If true, signals that the application is initializing
        /// </summary>
        bool ApplicationInitializing = true;

        /// <summary>
        /// If true, the application will display, in the grid, the character code below the actual character.
        /// </summary>
        bool ShowCharacterCode = true;

        enum CharacterCodesViews { None = 0, Hexadecimal, Decimal };

        CharacterCodesViews GridCharacterCodes = CharacterCodesViews.None;

        /// <summary>
        /// When true signals that an operation of updating the character codes of the character grid, is in progress.
        /// </summary>
        bool GridUpdateCharacterCode = false;

        /// <summary>
        /// Tooltip for the decrease font size button.
        /// </summary>
        ToolTip ToolTip1 = new ToolTip();

        /// <summary>
        /// Tooltip for the increase font size button.
        /// </summary>
        ToolTip ToolTip2 = new ToolTip();

        /// <summary>
        /// Tooltip for the increase search button.
        /// </summary>
        ToolTip ToolTip3 = new ToolTip();

        /// <summary>
        /// Tooltip for the copy Unicode character button.
        /// </summary>
        ToolTip ToolTip4 = new ToolTip();

        /// <summary>
        /// Tooltip for the copy hexadecimal code button.
        /// </summary>
        ToolTip ToolTip5 = new ToolTip();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form initialization.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = UnicodeViewer.Properties.Resources.Icons;

            // Suspend the layout logic for the form, while the application is initializing
            this.SuspendLayout();

            this.MinimumSize = UnicodeViewer.Settings.FORM_MIN_SIZE;
            lblCopyright.Text = "\u00a9 Copyright 2019 - João Martiniano";

            InitializeUI_Fonts();
            ApplicationData.InitializeUnicodeCodeBlocks();
            ApplicationData.InitializeUnicodeCodePoints();
            InitializeUI_UnicodeCodeBlocks();

            // Initialize the label responsible for the character preview
            lblCharacter.BorderStyle = BorderStyle.None;
            lblCharacter.Font = new Font(UnicodeViewer.Settings.DEFAULT_FONT_NAME, 42f);
            lblCharacter.BackColor = Color.White;
            lblCharacterCodeHex.Top = lblCharacter.Top + lblCharacter.Height;
            lblCharacterCodeHex.Left = lblCharacter.Left;
            lblCharacterCodeHex.Width = lblCharacter.Width;
            
            lblCharacterName.Text = string.Empty;
            lblCharacterName.Padding = new Padding(6, 0, 6, 0);
            lblCharacterCodeHex.Text = string.Empty;

            // Configure the font size up/down numeric input
            txtFontSize.Minimum = UnicodeViewer.Settings.CHARACTER_PREVIEW_MIN_FONT_SIZE;
            txtFontSize.Maximum = UnicodeViewer.Settings.CHARACTER_PREVIEW_MAX_FONT_SIZE;
            txtFontSize.Value = UnicodeViewer.Settings.CHARACTER_PREVIEW_DEFAULT_FONT_SIZE;

            chkCharacterCodes.Checked = ShowCharacterCode;
            chkHexCharacterCodes.Checked = true;
            GridCharacterCodes = CharacterCodesViews.Hexadecimal;

            // Initialize the DataGridView
            InitializeUI_DataGridView();

            // Initialize the tooltips
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(DecreaseFontSize, "Decrease the font size for the character grid");
            ToolTip2.ShowAlways = true;
            ToolTip2.SetToolTip(IncreaseFontSize, "Increase the font size for the character grid");
            ToolTip3.ShowAlways = true;
            ToolTip3.SetToolTip(btSearch, "Search for Unicode characters");
            ToolTip4.ShowAlways = true;
            ToolTip4.SetToolTip(btCopyCharacter, "Copy the selected Unicode character to the clipboard");
            ToolTip5.ShowAlways = true;
            ToolTip5.SetToolTip(btCopyHex, "Copy the selected Unicode character's hexadecimal code to the clipboard");

            // Accessibility
            InitializeUI_Accessibility();

            // Resume the layout logic
            this.ResumeLayout();

            // The initialization process has ended
            ApplicationInitializing = false;
       }

        #region "Initialization"

        /// <summary>
        /// Initialize accessibility descriptions for various controls in the form.
        /// </summary>
        private void InitializeUI_Accessibility()
        {
            lstBlocks.AccessibleName = "Code blocks";
            lstBlocks.AccessibleDescription = "List of Unicode code blocks";
            chkHexCharacterCodes.AccessibleDescription = "Show character codes in hexadecimal format";
            chkDecimalCharacterCodes.AccessibleDescription = "Show character codes in decimal format";
            cboFonts.AccessibleName = "Fonts";
            gvwCharacters.AccessibleName = "Unicode character grid";
            DecreaseFontSize.AccessibleName = "Decrease font size";
            DecreaseFontSize.AccessibleDescription = "Decrease the font size of the Unicode character grid";
            IncreaseFontSize.AccessibleName = "Increase font size";
            IncreaseFontSize.AccessibleDescription = "Increase the font size of the Unicode character grid";
            lblCharacter.AccessibleName = "Unicode character preview";
            lblCharacter.AccessibleDescription= "Renders in a bigger size, the Unicode character selected in the character grid";
            lblCharacterCodeHex.AccessibleName = "Unicode character codepoint";
            lblCharacterName.AccessibleName = "Unicode character name";
            btCopyCharacter.AccessibleDescription = "Copy the selected Unicode character to the clipboard";
            btCopyHex.AccessibleDescription = "Copy the selected Unicode character's hexadecimal code to the clipboard";
        }

        /// <summary>
        /// Initialize the combo box containing the fonts installed in the system.
        /// </summary>
        private void InitializeUI_Fonts()
        {
            InstalledFontCollection Fonts = new InstalledFontCollection();

            FontFamily[] FontFamilies = Fonts.Families;

            foreach (FontFamily Font in FontFamilies)
            {
                cboFonts.Items.Add(Font.Name);
            }

            // Set the default font
            cboFonts.SelectedItem = UnicodeViewer.Settings.DEFAULT_FONT_NAME;
        }

        /// <summary>
        /// Initialize the drop down list containing the unicode code blocks.
        /// </summary>
        private void InitializeUI_UnicodeCodeBlocks()
        {
            foreach(UnicodeCodeBlock block in ApplicationData.UnicodeCodeBlocks)
            {
                lstBlocks.Items.Add(block.Name);
            }
        }

        /// <summary>
        /// Initialization of the user interface: initialize the character grid.
        /// </summary>
        private void InitializeUI_DataGridView()
        {
            gvwCharacters.StandardTab = true;
            gvwCharacters.AllowUserToAddRows = false;
            gvwCharacters.AllowUserToDeleteRows = false;
            gvwCharacters.AllowUserToOrderColumns = false;
            gvwCharacters.AllowUserToResizeColumns = false;
            gvwCharacters.AllowUserToResizeRows = false;
            gvwCharacters.ColumnHeadersVisible = false;
            gvwCharacters.RowHeadersVisible = false;
            gvwCharacters.ColumnCount = UnicodeViewer.Settings.GRID_NUMBER_COLUMNS;
            gvwCharacters.GridColor = UnicodeViewer.Settings.GRID_BORDER_COLOR;
            gvwCharacters.ReadOnly = true;
            gvwCharacters.MultiSelect = false;
            gvwCharacters.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gvwCharacters.Font = new Font(cboFonts.SelectedItem.ToString(), UnicodeViewer.Settings.GRID_DEFAULT_FONT_SIZE);
        }

        /// <summary>
        /// Initialization of the user interface: populate the character grid with characters from a Unicode code block.
        /// </summary>
        /// <param name="Block">The Unicode code block to populate the grid.</param>
        private void InitializeUI_PopulateDataGridView(UnicodeViewer.UnicodeCodeBlock Block)
        {
            if (Block.GetNumberOfCharacters() < 1) return;

            int num_rows = 0;
            int column_width = 0;

            // Suspend the grid layout logic (if the application is not initializing)
            if (!ApplicationInitializing) gvwCharacters.SuspendLayout();

            gvwCharacters.Rows.Clear();

            // Calculate the number of characters in the block
            num_rows = Block.GetNumberOfCharacters() / UnicodeViewer.Settings.GRID_NUMBER_COLUMNS;

            // Add the required number of rows
            gvwCharacters.Rows.Add(num_rows);

            // Set the rows height
            foreach (DataGridViewRow row in gvwCharacters.Rows)
            {
                row.Height = UnicodeViewer.Settings.GRID_ROW_SIZE;
            }

            // Set the column widths
            column_width = gvwCharacters.ClientSize.Width / UnicodeViewer.Settings.GRID_NUMBER_COLUMNS;
            foreach (DataGridViewColumn column in gvwCharacters.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Populate the DataGridView
            bool break_flag = false;
            int c = Block.Start;
            char ch = (char)Block.Start;

            for (int j = 0; j < num_rows; ++j)
            {
                for (int i = 0; i < UnicodeViewer.Settings.GRID_NUMBER_COLUMNS; ++i, ++ch, ++c)
                {
                    // If not a valid Unicode code point, simply paint a gray background on the cell
                    if (!ApplicationData.UnicodeCodePoints.ContainsKey(ch))
                    {
                        gvwCharacters.Rows[j].Cells[i].Value = string.Empty;
                        gvwCharacters.Rows[j].Cells[i].Style.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        gvwCharacters.Rows[j].Cells[i].Value = ch;
                    }

                    gvwCharacters.Rows[j].Cells[i].Tag = c;

                    // Test if the end of the Unicode code block was reached
                    if (c == Block.End)
                    {
                        break_flag = true;
                        break;
                    }
                }

                if (break_flag) break;
            }

            // Resume the grid layout logic (if the application is not initializing)
            if (!ApplicationInitializing) gvwCharacters.ResumeLayout();
        }

        #endregion

        #region "Grid"

        /// <summary>
        /// Owner draw of the character grid.
        /// </summary>
        private void gvwCharacters_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex < 0) || (!ShowCharacterCode))
            {
                return;
            }

            DataGridViewCell cell = gvwCharacters[e.ColumnIndex, e.RowIndex];
            int DecimalValue = 0;
            string footnote = "";
            int y = e.CellBounds.Bottom - 15;
            Font f = new Font(UnicodeViewer.Settings.GRID_CELL_FOOTER_FONT_NAME, UnicodeViewer.Settings.GRID_CELL_FOOTER_FONT_SIZE);

            if (cell.Tag != null)
            {
                DecimalValue = Int32.Parse(cell.Tag.ToString());
                if (GridCharacterCodes == CharacterCodesViews.Hexadecimal)
                    footnote = DecimalValue.ToString("X4");
                else if (GridCharacterCodes == CharacterCodesViews.Decimal)
                    footnote = cell.Tag.ToString();
            }

            Size fontWidth = TextRenderer.MeasureText(footnote, f);

            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.ClipBounds);
            using (Font smallFont = f)
                e.Graphics.DrawString(footnote, smallFont, cell.Selected ? UnicodeViewer.Settings.GRID_CELL_FOOTER_COLOR_SELECTED : UnicodeViewer.Settings.GRID_CELL_FOOTER_COLOR, (e.CellBounds.Left + (e.CellBounds.Width / 2) - (fontWidth.Width / 2)), y);

            e.Handled = true;
        }

        /// <summary>
        /// Handle a click on a character in the grid.
        /// </summary>
        private void gvwCharacters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Show details about the character
            DisplayCharacterDetails((char)gvwCharacters[e.ColumnIndex, e.RowIndex].Value, Int32.Parse(gvwCharacters[e.ColumnIndex, e.RowIndex].Tag.ToString()));
        }

        /// <summary>
        /// Handle keypresses on the grid.
        /// </summary>
        private void gvwCharacters_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user pressed the Enter key, display details about the character
            if (e.KeyData == Keys.Enter)
            {
                int col = gvwCharacters.SelectedCells[0].ColumnIndex;
                int row = gvwCharacters.SelectedCells[0].RowIndex;

                DisplayCharacterDetails((char)gvwCharacters[col, row].Value, Int32.Parse(gvwCharacters[col, row].Tag.ToString()));

                // Supress the default behavior
                e.Handled = true;
            }
        }

        #endregion

        #region "Unicode Code Blocks"

        /// <summary>
        /// Handle a change of the selected item for the list of unicode code blocks.
        /// </summary>
        private void lstBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBlocks.SelectedIndex > -1)
            {
                InitializeUI_PopulateDataGridView(ApplicationData.UnicodeCodeBlocks[lstBlocks.SelectedIndex]);

                // When the user selects a Unicode code block, do not select a cell in the grid
                gvwCharacters.SelectedCells[0].Selected = false;
            }
        }

        #endregion

        #region "Character Codes"

        /// <summary>
        /// Show/hide the character codes in the grid.
        /// </summary>
        private void chkCharacterCodes_CheckedChanged(object sender, EventArgs e)
        {
            if (!ApplicationInitializing)
            {
                int SelectedRow = -1;
                int SelectedCol = -1;

                ShowCharacterCode = !ShowCharacterCode;

                // Enable/disable the radio buttons, depending on the value of ShowCharacterCode
                chkHexCharacterCodes.Enabled = chkDecimalCharacterCodes.Enabled = ShowCharacterCode;

                if (lstBlocks.SelectedIndex >= 0)
                {
                    // Retrieve the currently selected cell in order to preserve it
                    if (gvwCharacters.SelectedCells.Count == 1)
                    {
                        SelectedRow = gvwCharacters.CurrentCell.RowIndex;
                        SelectedCol = gvwCharacters.CurrentCell.ColumnIndex;
                    }

                    InitializeUI_PopulateDataGridView(ApplicationData.UnicodeCodeBlocks[lstBlocks.SelectedIndex]);

                    // Select the previously selected cell
                    if (SelectedRow != -1) gvwCharacters.CurrentCell = gvwCharacters.Rows[SelectedRow].Cells[SelectedCol];
                }
            }
        }

        /// <summary>
        /// Show the character codes in hexadecimal format.
        /// </summary>
        private void chkHexCharacterCodes_CheckedChanged(object sender, EventArgs e)
        {
            if ((!ApplicationInitializing) && (lstBlocks.SelectedIndex >= 0))
            {
                if ((ShowCharacterCode) && (chkHexCharacterCodes.Checked))
                {
                    int SelectedRow = -1;
                    int SelectedCol = -1;

                    GridCharacterCodes = CharacterCodesViews.Hexadecimal;

                    // Retrieve the currently selected cell in order to preserve it
                    if (gvwCharacters.SelectedCells.Count == 1)
                    {
                        SelectedRow = gvwCharacters.CurrentCell.RowIndex;
                        SelectedCol = gvwCharacters.CurrentCell.ColumnIndex;
                    }

                    GridUpdateCharacterCode = true;
                    InitializeUI_PopulateDataGridView(ApplicationData.UnicodeCodeBlocks[lstBlocks.SelectedIndex]);
                    GridUpdateCharacterCode = false;

                    // Select the previously selected cell
                    if (SelectedRow != -1) gvwCharacters.CurrentCell = gvwCharacters.Rows[SelectedRow].Cells[SelectedCol];
                }
            }
        }

        /// <summary>
        /// Show the character codes in decimal format.
        /// </summary>
        private void chkDecimalCharacterCodes_CheckedChanged(object sender, EventArgs e)
        {
            if ((!ApplicationInitializing) && (lstBlocks.SelectedIndex >= 0))
            {
                if ((ShowCharacterCode) && (chkDecimalCharacterCodes.Checked))
                {
                    int SelectedRow = -1;
                    int SelectedCol = -1;

                    GridCharacterCodes = CharacterCodesViews.Decimal;

                    // Retrieve the currently selected cell in order to preserve it
                    if (gvwCharacters.SelectedCells.Count == 1)
                    {
                        SelectedRow = gvwCharacters.CurrentCell.RowIndex;
                        SelectedCol = gvwCharacters.CurrentCell.ColumnIndex;
                    }

                    GridUpdateCharacterCode = true;
                    InitializeUI_PopulateDataGridView(ApplicationData.UnicodeCodeBlocks[lstBlocks.SelectedIndex]);
                    GridUpdateCharacterCode = false;

                    // Select the previously selected cell
                    if (SelectedRow != -1) gvwCharacters.CurrentCell = gvwCharacters.Rows[SelectedRow].Cells[SelectedCol];
                }
            }
        }

        #endregion

        #region "Font/Font Size"

        /// <summary>
        /// Change the selected font.
        /// </summary>
        private void cboFonts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboFonts.SelectedItem != null)
            {
                gvwCharacters.Font = new Font(cboFonts.SelectedItem.ToString(), 14f);
                lblCharacter.Font = new Font(cboFonts.SelectedItem.ToString(), 42f);
            }
        }

        /// <summary>
        /// Decrease the font size of the character grid.
        /// </summary>
        private void btDecreaseFontSize_Click(object sender, EventArgs e)
        {
            float FontSize = gvwCharacters.Font.Size;

            // Decrease the font size only if the minimum font size hasn't been reached
            if (FontSize > UnicodeViewer.Settings.GRID_MIN_FONT_SIZE)
            {
                --FontSize;

                gvwCharacters.Font = new Font(cboFonts.SelectedItem.ToString(), FontSize);

                // Enable the 'Increase font size' control if it was disabled
                if (!IncreaseFontSize.Enabled) IncreaseFontSize.Enabled = true;

                // Disable this control if the minimum size has been reached
                if (FontSize == UnicodeViewer.Settings.GRID_MIN_FONT_SIZE) DecreaseFontSize.Enabled = false;
            }
        }

        /// <summary>
        /// Increase the font size of the character grid.
        /// </summary>
        private void btIncreaseFontSize_Click(object sender, EventArgs e)
        {
            float FontSize = gvwCharacters.Font.Size;

            // Increase the font size only if the maximum font size hasn't been reached
            if (FontSize < UnicodeViewer.Settings.GRID_MAX_FONT_SIZE)
            {
                ++FontSize;

                gvwCharacters.Font = new Font(cboFonts.SelectedItem.ToString(), FontSize);

                // Enable the 'Decrease font size' control if it was disabled
                if (!DecreaseFontSize.Enabled) DecreaseFontSize.Enabled = true;

                // Disable this control if the maximum size has been reached
                if (FontSize == UnicodeViewer.Settings.GRID_MAX_FONT_SIZE) IncreaseFontSize.Enabled = false;
            }
        }

        /// <summary>
        /// Change the character preview font size.
        /// </summary>
        private void txtFontSize_ValueChanged(object sender, EventArgs e)
        {
            int FontSize = 0;

            if (Int32.TryParse(txtFontSize.Value.ToString(), out FontSize))
            {
                lblCharacter.Font = new Font(cboFonts.SelectedItem.ToString(), FontSize);
            }            
        }

        #endregion

        #region "Search"

        /// <summary>
        /// Open the search form.
        /// </summary>
        private void btSearch_Click(object sender, EventArgs e)
        {
            Search frmSearch = new Search(this);
            frmSearch.ShowDialog();

            frmSearch.Dispose();
        }

        /// <summary>
        /// This method (called from the search form) selects a Unicode character in the grid and the corresponding code block in the code blocks list.
        /// </summary>
        /// <param name="CodeBlock">The Unicode code block to select.</param>
        /// <param name="CodePoint">The Unicode code point of the character to select.</param>
        public void SelectCharacterGrid(string CodeBlock, int CodePoint)
        {
            // Find and select the code block in code blocks list
            if (CodeBlock != string.Empty)
            {
                // Select the apropriate Unicode code block
                if (lstBlocks.Items.Contains(CodeBlock))
                {
                    lstBlocks.SelectedIndex = lstBlocks.Items.IndexOf(CodeBlock);
                }
                else
                    return;

                // Find and select the cell of the Unicode character in the grid
                int cols = gvwCharacters.ColumnCount;
                int rows = gvwCharacters.RowCount;

                for (int row = 0; row < rows; ++row)
                {
                    for (int col = 0; col < cols; ++col)
                    {
                        if (Int32.Parse(gvwCharacters[col, row].Tag.ToString()) == CodePoint)
                        {
                            // Select the character in the grid
                            gvwCharacters[col, row].Selected = true;

                            // Display the character details
                            DisplayCharacterDetails((char)gvwCharacters[col, row].Value, CodePoint);

                            return;
                        }
                    }
                }
            }
        }

        #endregion

        #region "Character Details"

        /// <summary>
        /// Display details about a Unicode character.
        /// </summary>
        /// <param name="Character">The character to display details</param>
        /// <param name="CodePoint">The Unicode character code point</param>
        private void DisplayCharacterDetails(char? Character, int CodePoint)
        {
            if (Character.HasValue)
            {
                if (ApplicationData.UnicodeCodePoints.ContainsKey(Character.Value))
                {
                    lblCharacter.Text = Character.ToString();
                    lblCharacterName.Text = ApplicationData.UnicodeCodePoints[Character.Value];
                    lblCharacterCodeHex.Text = String.Format("U+{0}\n({1})", CodePoint.ToString("X4"), CodePoint);

                    return;
                }
            }

            // There is no information about the character: empty the controls that display details
            lblCharacter.Text = string.Empty;
            lblCharacterName.Text = string.Empty;
            lblCharacterCodeHex.Text = string.Empty;
        }

        #endregion

        #region "Copy To Clipboard"

        /// <summary>
        /// Copy the selected Unicode character to the operating system clipboard.
        /// </summary>
        private void btCopyCharacter_Click(object sender, EventArgs e)
        {
            if (lblCharacter.Text != string.Empty)
            {
                Clipboard.SetText(lblCharacter.Text);
            }
        }

        /// <summary>
        /// Copy the selected Unicode character's hexadecimal code to the operating system clipboard.
        /// </summary>
        private void btCopyHex_Click(object sender, EventArgs e)
        {
            if (lblCharacter.Text != string.Empty)
            {
                Clipboard.SetText(lblCharacterCodeHex.Text.Substring(0, 6));
            }
        }

        #endregion
    }
}
