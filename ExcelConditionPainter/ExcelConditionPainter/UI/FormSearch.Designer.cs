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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.mainLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.mainLayoutPanel.Controls.Add(this.searchTextBox, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.searchLabel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.searchAllButton, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.allSearchResultsGridView, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Padding = new System.Windows.Forms.Padding(16);
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(760, 260);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchTextBox.Location = new System.Drawing.Point(144, 25);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(480, 25);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.searchLabel.Location = new System.Drawing.Point(19, 16);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(114, 44);
            this.searchLabel.TabIndex = 1;
            this.searchLabel.Text = "찾을 내용 :";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchAllButton
            // 
            this.searchAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.searchAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(94)))), ((int)(((byte)(89)))));
            this.searchAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchAllButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchAllButton.ForeColor = System.Drawing.Color.White;
            this.searchAllButton.Location = new System.Drawing.Point(635, 19);
            this.searchAllButton.Name = "searchAllButton";
            this.searchAllButton.Size = new System.Drawing.Size(106, 38);
            this.searchAllButton.TabIndex = 3;
            this.searchAllButton.Text = "모두 찾기";
            this.searchAllButton.UseVisualStyleBackColor = false;
            this.searchAllButton.Click += new System.EventHandler(this.searchAllButton_Click);
            // 
            // allSearchResultsGridView
            // 
            this.allSearchResultsGridView.AllowUserToAddRows = false;
            this.allSearchResultsGridView.AllowUserToDeleteRows = false;
            this.allSearchResultsGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.allSearchResultsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.allSearchResultsGridView.BackgroundColor = System.Drawing.Color.White;
            this.allSearchResultsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.allSearchResultsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allSearchResultsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.allSearchResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSearchResultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNameColumn,
            this.rowIndexColumn,
            this.valueColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(246)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.allSearchResultsGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainLayoutPanel.SetColumnSpan(this.allSearchResultsGridView, 3);
            this.allSearchResultsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allSearchResultsGridView.EnableHeadersVisualStyles = false;
            this.allSearchResultsGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.allSearchResultsGridView.Location = new System.Drawing.Point(19, 63);
            this.allSearchResultsGridView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.allSearchResultsGridView.MultiSelect = false;
            this.allSearchResultsGridView.Name = "allSearchResultsGridView";
            this.allSearchResultsGridView.ReadOnly = true;
            this.allSearchResultsGridView.RowHeadersVisible = false;
            this.allSearchResultsGridView.RowTemplate.Height = 28;
            this.allSearchResultsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allSearchResultsGridView.Size = new System.Drawing.Size(722, 181);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(760, 260);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = global::ExcelConditionPainter.Properties.Resources.AppIcon;
            this.MinimumSize = new System.Drawing.Size(640, 240);
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
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
