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

namespace UnicodeViewer
{
    public partial class Search : Form
    {
        private enum SearchType { Name = 0, Character = 1, UnicodeCodePoint = 2 };

        /// <summary>
        /// Tooltip for the search button.
        /// </summary>
        ToolTip ToolTip1 = new ToolTip();

        /// <summary>
        /// Instance of the main form.
        /// </summary>
        private Form1 FormPrincipal = null;

        public Search(Form1 f)
        {
            InitializeComponent();

            FormPrincipal = f;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.CancelButton = btClose;

            // Suspend the layout logic for the form, while the application is initialing
            this.SuspendLayout();

            cboSearchOptions.AutoCompleteMode = AutoCompleteMode.None;
            cboSearchOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchOptions.Items.Add("Name");
            cboSearchOptions.Items.Add("Unicode Character");
            cboSearchOptions.Items.Add("Unicode Code Point");
            cboSearchOptions.SelectedIndex = 0;

            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            txtSearch.Left = lblSearch.Left + lblSearch.Width;
            txtSearch.MaxLength = 255;

            btSearch.FlatAppearance.BorderSize = 0;
            btSearch.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#C9DEF5");

            // Initialize the tooltip
            ToolTip1.ShowAlways = true;
            ToolTip1.SetToolTip(btSearch, "Search");

            lvwSearchResults.View = View.Details;
            lvwSearchResults.HideSelection = false;
            lvwSearchResults.MultiSelect = false;
            lvwSearchResults.FullRowSelect = true;
            lvwSearchResults.Columns.Add("", 10, HorizontalAlignment.Left);
            lvwSearchResults.Columns.Add("Code", 20, HorizontalAlignment.Left);
            lvwSearchResults.Columns.Add("Name", 20, HorizontalAlignment.Left);
            lvwSearchResults.Columns.Add("Unicode Code Block", 20, HorizontalAlignment.Left);
            lvwSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            btGoToCharacter.Enabled = false;

            // Accessibility
            cboSearchOptions.AccessibleName = "Search options";
            txtSearch.AccessibleDescription = "Insert the name, Unicode character or Unicode code point to search for";
            btSearch.AccessibleName = "Search";
            lvwSearchResults.AccessibleName = "Search results";

            // Resume the layout logic
            this.ResumeLayout();
        }

        /// <summary>
        /// Close the form.
        /// </summary>
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Change the search type.
        /// </summary>
        private void cboSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;

            switch ((SearchType) cboSearchOptions.SelectedIndex)
            {
                case SearchType.Name:
                    lblSearch.Text = "&Name:";
                    txtSearch.MaxLength = 255;
                    break;

                case SearchType.Character:
                    lblSearch.Text = "C&haracter:";                    
                    txtSearch.MaxLength = 1;
                    break;

                case SearchType.UnicodeCodePoint:
                    lblSearch.Text = "&U+";
                    txtSearch.MaxLength = 4;
                    break;
            }

            lblSearch.UseMnemonic = true;

            // Position the label
            lblSearch.Left = txtSearch.Left - lblSearch.Width;
        }

        /// <summary>
        /// Initiate the search.
        /// </summary>
        private void btSearch_Click(object sender, EventArgs e)
        {
            lvwSearchResults.Items.Clear();
            
            // Test if the search term is empty
            if (txtSearch.Text == string.Empty) return;

            int CodePoint = 0;

            // Test if the Unicode code point is a valid number
            if ((SearchType)cboSearchOptions.SelectedIndex == SearchType.UnicodeCodePoint)
            {
                if (!Int32.TryParse(txtSearch.Text, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out CodePoint))
                    return;
                else if (CodePoint > UnicodeViewer.Settings.CODE_POINT_UPPER_LIMIT)
                    return;                
            }

            bool Hit = false;
            ListViewItem ItemLista = null;
            
            lvwSearchResults.BeginUpdate();

            foreach (KeyValuePair<char, string> item in ApplicationData.UnicodeCodePoints)
            {
                if ((SearchType)cboSearchOptions.SelectedIndex == SearchType.Name)
                {
                    string TermoPesquisa = txtSearch.Text.ToUpper();

                    if (item.Value.Contains(TermoPesquisa)) Hit = true;
                }
                else if ((SearchType)cboSearchOptions.SelectedIndex == SearchType.Character)
                {
                    if (item.Key == (char)txtSearch.Text[0]) Hit = true;
                }
                else if ((SearchType)cboSearchOptions.SelectedIndex == SearchType.UnicodeCodePoint)
                {
                    if ((int)item.Key == CodePoint) Hit = true;
                }

                if (Hit)
                {
                    // Add the Unicode character to the results list
                    ItemLista = new ListViewItem(item.Key.ToString());
                    
                    // Add the Unicode code point to the results list
                    ItemLista.SubItems.Add("U+" + ((int)item.Key).ToString("X4"));

                    // Add the character name to the results list
                    ItemLista.SubItems.Add(item.Value);

                    int ItemKey = (int)item.Key;
                    string BlockName = string.Empty;

                    // Determine the Unicode code block of this character
                    foreach (UnicodeViewer.UnicodeCodeBlock Block in UnicodeViewer.ApplicationData.UnicodeCodeBlocks)
                    {
                        if ((ItemKey >= Block.Start) && (ItemKey <= Block.End))
                        {
                            BlockName = Block.Name;
                            break;
                        }
                    }

                    // Add the Unicode code block to the results list
                    ItemLista.SubItems.Add(BlockName);

                    lvwSearchResults.Items.Add(ItemLista);

                    Hit = false;
                }
            }

            lvwSearchResults.EndUpdate();

            // Set the column widths according to their content
            if (lvwSearchResults.Items.Count > 0)
            {
                lvwSearchResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwSearchResults.Columns[0].Width = -2;
                lvwSearchResults.Columns[1].Width = -2;
                lvwSearchResults.Columns[3].Width = -2;
                lvwSearchResults.Columns[2].Width = lvwSearchResults.ClientSize.Width - (lvwSearchResults.Columns[0].Width + lvwSearchResults.Columns[1].Width + lvwSearchResults.Columns[3].Width);
                btGoToCharacter.Enabled = true;
            }
            else
            {
                btGoToCharacter.Enabled = false;
            }            

            lblResultsNumber.Text = "Search &results (" + lvwSearchResults.Items.Count + "):";
        }

        /// <summary>
        /// Display details about the selected character, when the user clicks on the "Go To Character" button.
        /// </summary>
        private void btGoToCharacter_Click(object sender, EventArgs e)
        {
            GoToCharacter();
        }

        /// <summary>
        /// Display details about the selected character, when the user double-clicks on the search results.
        /// </summary>
        private void lvwSearchResults_DoubleClick(object sender, EventArgs e)
        {
            GoToCharacter();
        }

        /// <summary>
        /// Handle keyboard keypresses in the search results.
        /// </summary>
        private void lvwSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                GoToCharacter();
            }
        }

        /// <summary>
        /// Display details about the selected character.
        /// </summary>
        private void GoToCharacter()
        {
            if (lvwSearchResults.SelectedItems.Count > 0)
            {
                string CodeBlock = lvwSearchResults.SelectedItems[0].SubItems[3].Text;
                int CodePoint = Int32.Parse(lvwSearchResults.SelectedItems[0].SubItems[1].Text.Substring(2, 4), NumberStyles.HexNumber);
                FormPrincipal.SelectCharacterGrid(CodeBlock, CodePoint);
            }
        }
    }
}
