namespace UnicodeViewer
{
    partial class Search
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
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSearchOptions = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.lvwSearchResults = new System.Windows.Forms.ListView();
            this.lblResultsNumber = new System.Windows.Forms.Label();
            this.btGoToCharacter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(475, 311);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Search for:";
            // 
            // cboSearchOptions
            // 
            this.cboSearchOptions.FormattingEnabled = true;
            this.cboSearchOptions.Location = new System.Drawing.Point(80, 11);
            this.cboSearchOptions.Name = "cboSearchOptions";
            this.cboSearchOptions.Size = new System.Drawing.Size(140, 21);
            this.cboSearchOptions.TabIndex = 1;
            this.cboSearchOptions.SelectedIndexChanged += new System.EventHandler(this.cboSearchOptions_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(267, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(23, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "U+";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(296, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Image = global::UnicodeViewer.Properties.Resources.Search;
            this.btSearch.Location = new System.Drawing.Point(451, 10);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(32, 23);
            this.btSearch.TabIndex = 4;
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lvwSearchResults
            // 
            this.lvwSearchResults.Location = new System.Drawing.Point(15, 62);
            this.lvwSearchResults.Name = "lvwSearchResults";
            this.lvwSearchResults.Size = new System.Drawing.Size(535, 242);
            this.lvwSearchResults.TabIndex = 6;
            this.lvwSearchResults.UseCompatibleStateImageBehavior = false;
            this.lvwSearchResults.DoubleClick += new System.EventHandler(this.lvwSearchResults_DoubleClick);
            this.lvwSearchResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwSearchResults_KeyDown);
            // 
            // lblResultsNumber
            // 
            this.lblResultsNumber.AutoSize = true;
            this.lblResultsNumber.Location = new System.Drawing.Point(12, 47);
            this.lblResultsNumber.Name = "lblResultsNumber";
            this.lblResultsNumber.Size = new System.Drawing.Size(81, 13);
            this.lblResultsNumber.TabIndex = 5;
            this.lblResultsNumber.Text = "Search &results:";
            // 
            // btGoToCharacter
            // 
            this.btGoToCharacter.Location = new System.Drawing.Point(15, 311);
            this.btGoToCharacter.Name = "btGoToCharacter";
            this.btGoToCharacter.Size = new System.Drawing.Size(111, 23);
            this.btGoToCharacter.TabIndex = 7;
            this.btGoToCharacter.Text = "&Go To Character";
            this.btGoToCharacter.UseVisualStyleBackColor = true;
            this.btGoToCharacter.Click += new System.EventHandler(this.btGoToCharacter_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 346);
            this.Controls.Add(this.btGoToCharacter);
            this.Controls.Add(this.lblResultsNumber);
            this.Controls.Add(this.lvwSearchResults);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cboSearchOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSearchOptions;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ListView lvwSearchResults;
        private System.Windows.Forms.Label lblResultsNumber;
        private System.Windows.Forms.Button btGoToCharacter;
    }
}