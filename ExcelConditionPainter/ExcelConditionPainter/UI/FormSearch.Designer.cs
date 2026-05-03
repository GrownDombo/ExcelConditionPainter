namespace ExcelConditionPainter
{
    partial class FormSearch
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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchAllButton = new System.Windows.Forms.Button();
            this.allSearchResultsGridView = new System.Windows.Forms.DataGridView();
            this.columnNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allSearchResultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainLayoutPanel.Controls.Add(this.searchTextBox, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.searchLabel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.searchAllButton, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.allSearchResultsGridView, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(684, 161);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(153, 4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(428, 21);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLabel.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLabel.Location = new System.Drawing.Point(3, 0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(144, 29);
            this.searchLabel.TabIndex = 1;
            this.searchLabel.Text = "찾을 내용 :";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchAllButton
            // 
            this.searchAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchAllButton.Location = new System.Drawing.Point(587, 3);
            this.searchAllButton.Name = "searchAllButton";
            this.searchAllButton.Size = new System.Drawing.Size(94, 23);
            this.searchAllButton.TabIndex = 3;
            this.searchAllButton.Text = "모두 찾기";
            this.searchAllButton.UseVisualStyleBackColor = true;
            this.searchAllButton.Click += new System.EventHandler(this.searchAllButton_Click);
            // 
            // allSearchResultsGridView
            // 
            this.allSearchResultsGridView.AllowUserToAddRows = false;
            this.allSearchResultsGridView.AllowUserToDeleteRows = false;
            this.allSearchResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSearchResultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNameColumn,
            this.rowIndexColumn,
            this.valueColumn});
            this.mainLayoutPanel.SetColumnSpan(this.allSearchResultsGridView, 3);
            this.allSearchResultsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allSearchResultsGridView.Location = new System.Drawing.Point(3, 32);
            this.allSearchResultsGridView.MultiSelect = false;
            this.allSearchResultsGridView.Name = "allSearchResultsGridView";
            this.allSearchResultsGridView.ReadOnly = true;
            this.allSearchResultsGridView.RowHeadersVisible = false;
            this.allSearchResultsGridView.RowTemplate.Height = 23;
            this.allSearchResultsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allSearchResultsGridView.Size = new System.Drawing.Size(678, 126);
            this.allSearchResultsGridView.TabIndex = 4;
            this.allSearchResultsGridView.SelectionChanged += new System.EventHandler(this.allSearchResultsGridView_SelectionChanged);
            // 
            // columnNameColumn
            // 
            this.columnNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnNameColumn.HeaderText = "행 이름";
            this.columnNameColumn.Name = "columnNameColumn";
            this.columnNameColumn.ReadOnly = true;
            this.columnNameColumn.Width = 70;
            // 
            // rowIndexColumn
            // 
            this.rowIndexColumn.HeaderText = "열 인덱스";
            this.rowIndexColumn.Name = "rowIndexColumn";
            this.rowIndexColumn.ReadOnly = true;
            // 
            // valueColumn
            // 
            this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueColumn.HeaderText = "값";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 161);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSearch_FormClosing);
            this.Shown += new System.EventHandler(this.FormSearch_Shown);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allSearchResultsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button searchAllButton;
        private System.Windows.Forms.DataGridView allSearchResultsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowIndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
    }
}