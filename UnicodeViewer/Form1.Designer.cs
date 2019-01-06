namespace UnicodeViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstBlocks = new System.Windows.Forms.ListBox();
            this.chkCharacterCodes = new System.Windows.Forms.CheckBox();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.lblCharacterCodeHex = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFonts = new System.Windows.Forms.ComboBox();
            this.txtFontSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.chkHexCharacterCodes = new System.Windows.Forms.RadioButton();
            this.chkDecimalCharacterCodes = new System.Windows.Forms.RadioButton();
            this.IncreaseFontSize = new System.Windows.Forms.Button();
            this.DecreaseFontSize = new System.Windows.Forms.Button();
            this.gvwCharacters = new System.Windows.Forms.DataGridView();
            this.btSearch = new System.Windows.Forms.Button();
            this.btCopyHex = new System.Windows.Forms.Button();
            this.btCopyCharacter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBlocks
            // 
            this.lstBlocks.FormattingEnabled = true;
            this.lstBlocks.Location = new System.Drawing.Point(12, 40);
            this.lstBlocks.Name = "lstBlocks";
            this.lstBlocks.Size = new System.Drawing.Size(218, 394);
            this.lstBlocks.TabIndex = 1;
            this.lstBlocks.SelectedIndexChanged += new System.EventHandler(this.lstBlocks_SelectedIndexChanged);
            // 
            // chkCharacterCodes
            // 
            this.chkCharacterCodes.AutoSize = true;
            this.chkCharacterCodes.Location = new System.Drawing.Point(12, 444);
            this.chkCharacterCodes.Name = "chkCharacterCodes";
            this.chkCharacterCodes.Size = new System.Drawing.Size(138, 17);
            this.chkCharacterCodes.TabIndex = 2;
            this.chkCharacterCodes.Text = "Sh&ow character codes";
            this.chkCharacterCodes.UseVisualStyleBackColor = true;
            this.chkCharacterCodes.CheckedChanged += new System.EventHandler(this.chkCharacterCodes_CheckedChanged);
            // 
            // lblCharacter
            // 
            this.lblCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacter.BackColor = System.Drawing.Color.White;
            this.lblCharacter.Location = new System.Drawing.Point(791, 40);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(169, 169);
            this.lblCharacter.TabIndex = 13;
            this.lblCharacter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCharacterCodeHex
            // 
            this.lblCharacterCodeHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacterCodeHex.BackColor = System.Drawing.Color.White;
            this.lblCharacterCodeHex.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterCodeHex.Location = new System.Drawing.Point(792, 209);
            this.lblCharacterCodeHex.Name = "lblCharacterCodeHex";
            this.lblCharacterCodeHex.Size = new System.Drawing.Size(168, 37);
            this.lblCharacterCodeHex.TabIndex = 14;
            this.lblCharacterCodeHex.Text = "CharacterHex";
            this.lblCharacterCodeHex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacterName.BackColor = System.Drawing.Color.White;
            this.lblCharacterName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterName.Location = new System.Drawing.Point(792, 246);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(169, 50);
            this.lblCharacterName.TabIndex = 15;
            this.lblCharacterName.Text = "CharacterName";
            this.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Code Blocks:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "&Font:";
            // 
            // cboFonts
            // 
            this.cboFonts.FormattingEnabled = true;
            this.cboFonts.Location = new System.Drawing.Point(287, 13);
            this.cboFonts.Name = "cboFonts";
            this.cboFonts.Size = new System.Drawing.Size(329, 21);
            this.cboFonts.TabIndex = 6;
            this.cboFonts.SelectedValueChanged += new System.EventHandler(this.cboFonts_SelectedValueChanged);
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(896, 13);
            this.txtFontSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(43, 22);
            this.txtFontSize.TabIndex = 12;
            this.txtFontSize.ValueChanged += new System.EventHandler(this.txtFontSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(789, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "&Preview Font Size:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.ForeColor = System.Drawing.Color.Navy;
            this.lblCopyright.Location = new System.Drawing.Point(9, 525);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(64, 13);
            this.lblCopyright.TabIndex = 17;
            this.lblCopyright.Text = "(Copyright)";
            // 
            // chkHexCharacterCodes
            // 
            this.chkHexCharacterCodes.AutoSize = true;
            this.chkHexCharacterCodes.Checked = true;
            this.chkHexCharacterCodes.Location = new System.Drawing.Point(41, 466);
            this.chkHexCharacterCodes.Name = "chkHexCharacterCodes";
            this.chkHexCharacterCodes.Size = new System.Drawing.Size(89, 17);
            this.chkHexCharacterCodes.TabIndex = 3;
            this.chkHexCharacterCodes.TabStop = true;
            this.chkHexCharacterCodes.Text = "H&exadecimal";
            this.chkHexCharacterCodes.UseVisualStyleBackColor = true;
            this.chkHexCharacterCodes.CheckedChanged += new System.EventHandler(this.chkHexCharacterCodes_CheckedChanged);
            // 
            // chkDecimalCharacterCodes
            // 
            this.chkDecimalCharacterCodes.AutoSize = true;
            this.chkDecimalCharacterCodes.Location = new System.Drawing.Point(41, 486);
            this.chkDecimalCharacterCodes.Name = "chkDecimalCharacterCodes";
            this.chkDecimalCharacterCodes.Size = new System.Drawing.Size(65, 17);
            this.chkDecimalCharacterCodes.TabIndex = 4;
            this.chkDecimalCharacterCodes.TabStop = true;
            this.chkDecimalCharacterCodes.Text = "&Decimal";
            this.chkDecimalCharacterCodes.UseVisualStyleBackColor = true;
            this.chkDecimalCharacterCodes.CheckedChanged += new System.EventHandler(this.chkDecimalCharacterCodes_CheckedChanged);
            // 
            // IncreaseFontSize
            // 
            this.IncreaseFontSize.Image = global::UnicodeViewer.Properties.Resources.IncreaseFontSize;
            this.IncreaseFontSize.Location = new System.Drawing.Point(658, 12);
            this.IncreaseFontSize.Name = "IncreaseFontSize";
            this.IncreaseFontSize.Size = new System.Drawing.Size(30, 23);
            this.IncreaseFontSize.TabIndex = 8;
            this.IncreaseFontSize.UseVisualStyleBackColor = true;
            this.IncreaseFontSize.Click += new System.EventHandler(this.btIncreaseFontSize_Click);
            // 
            // DecreaseFontSize
            // 
            this.DecreaseFontSize.Image = global::UnicodeViewer.Properties.Resources.DecreaseFontSize;
            this.DecreaseFontSize.Location = new System.Drawing.Point(622, 12);
            this.DecreaseFontSize.Name = "DecreaseFontSize";
            this.DecreaseFontSize.Size = new System.Drawing.Size(30, 23);
            this.DecreaseFontSize.TabIndex = 7;
            this.DecreaseFontSize.UseVisualStyleBackColor = true;
            this.DecreaseFontSize.Click += new System.EventHandler(this.btDecreaseFontSize_Click);
            // 
            // gvwCharacters
            // 
            this.gvwCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvwCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwCharacters.Location = new System.Drawing.Point(247, 40);
            this.gvwCharacters.Name = "gvwCharacters";
            this.gvwCharacters.Size = new System.Drawing.Size(528, 498);
            this.gvwCharacters.TabIndex = 10;
            this.gvwCharacters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvwCharacters_CellClick);
            this.gvwCharacters.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvwCharacters_CellPainting);
            this.gvwCharacters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvwCharacters_KeyDown);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(700, 12);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 9;
            this.btSearch.Text = "&Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btCopyHex
            // 
            this.btCopyHex.Location = new System.Drawing.Point(791, 337);
            this.btCopyHex.Name = "btCopyHex";
            this.btCopyHex.Size = new System.Drawing.Size(169, 23);
            this.btCopyHex.TabIndex = 17;
            this.btCopyHex.Text = "Copy &Hexadecimal";
            this.btCopyHex.UseVisualStyleBackColor = true;
            this.btCopyHex.Click += new System.EventHandler(this.btCopyHex_Click);
            // 
            // btCopyCharacter
            // 
            this.btCopyCharacter.Location = new System.Drawing.Point(792, 308);
            this.btCopyCharacter.Name = "btCopyCharacter";
            this.btCopyCharacter.Size = new System.Drawing.Size(169, 23);
            this.btCopyCharacter.TabIndex = 16;
            this.btCopyCharacter.Text = "Copy &Unicode Character";
            this.btCopyCharacter.UseVisualStyleBackColor = true;
            this.btCopyCharacter.Click += new System.EventHandler(this.btCopyCharacter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 550);
            this.Controls.Add(this.btCopyCharacter);
            this.Controls.Add(this.btCopyHex);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.IncreaseFontSize);
            this.Controls.Add(this.DecreaseFontSize);
            this.Controls.Add(this.chkDecimalCharacterCodes);
            this.Controls.Add(this.chkHexCharacterCodes);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.cboFonts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCharacterName);
            this.Controls.Add(this.lblCharacterCodeHex);
            this.Controls.Add(this.lblCharacter);
            this.Controls.Add(this.chkCharacterCodes);
            this.Controls.Add(this.gvwCharacters);
            this.Controls.Add(this.lstBlocks);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Unicode Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBlocks;
        private System.Windows.Forms.CheckBox chkCharacterCodes;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Label lblCharacterCodeHex;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFonts;
        private System.Windows.Forms.NumericUpDown txtFontSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.RadioButton chkHexCharacterCodes;
        private System.Windows.Forms.RadioButton chkDecimalCharacterCodes;
        private System.Windows.Forms.Button DecreaseFontSize;
        private System.Windows.Forms.Button IncreaseFontSize;
        private System.Windows.Forms.DataGridView gvwCharacters;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btCopyHex;
        private System.Windows.Forms.Button btCopyCharacter;
    }
}

