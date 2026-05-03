namespace ExcelConditionPainter
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerPanel = new System.Windows.Forms.Panel();
            this.mainGridView = new WinFormsCustomControls.DoubleBufferedDataGridView();
            this.viewerHeaderPanel = new System.Windows.Forms.Panel();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.viewerLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.viewerPanel.SuspendLayout();
            this.viewerHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.White;
            this.mainMenuStrip.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mainMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.helpMenuItem,
            this.optionsMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.mainMenuStrip.Size = new System.Drawing.Size(1984, 31);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // openMenuItem
            // 
            this.openMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.openMenuItem.Size = new System.Drawing.Size(59, 23);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.helpMenuItem.Size = new System.Drawing.Size(55, 23);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // viewerPanel
            // 
            this.viewerPanel.BackColor = System.Drawing.Color.White;
            this.viewerPanel.Controls.Add(this.mainGridView);
            this.viewerPanel.Controls.Add(this.viewerHeaderPanel);
            this.viewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerPanel.Location = new System.Drawing.Point(0, 31);
            this.viewerPanel.Name = "viewerPanel";
            this.viewerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.viewerPanel.Size = new System.Drawing.Size(1984, 1230);
            this.viewerPanel.TabIndex = 8;
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mainGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mainGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mainGridView.BackgroundColor = System.Drawing.Color.White;
            this.mainGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.mainGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(246)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridView.EnableHeadersVisualStyles = false;
            this.mainGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.mainGridView.Location = new System.Drawing.Point(12, 44);
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowHeadersWidth = 56;
            this.mainGridView.RowTemplate.Height = 28;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGridView.Size = new System.Drawing.Size(1960, 1174);
            this.mainGridView.TabIndex = 7;
            this.mainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainGridView_DataBindingComplete);
            this.mainGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.mainGridView_RowPostPaint);
            //
            // viewerHeaderPanel
            //
            this.viewerHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(50)))), ((int)(((byte)(79)))));
            this.viewerHeaderPanel.Controls.Add(this.currentFileLabel);
            this.viewerHeaderPanel.Controls.Add(this.exportButton);
            this.viewerHeaderPanel.Controls.Add(this.viewerLabel);
            this.viewerHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewerHeaderPanel.Location = new System.Drawing.Point(12, 0);
            this.viewerHeaderPanel.Name = "viewerHeaderPanel";
            this.viewerHeaderPanel.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.viewerHeaderPanel.Size = new System.Drawing.Size(1960, 44);
            this.viewerHeaderPanel.TabIndex = 8;
            //
            // currentFileLabel
            //
            this.currentFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentFileLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.currentFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            this.currentFileLabel.Location = new System.Drawing.Point(144, 6);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.currentFileLabel.Size = new System.Drawing.Size(1698, 32);
            this.currentFileLabel.TabIndex = 10;
            this.currentFileLabel.Text = "No file opened";
            this.currentFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // viewerLabel
            // 
            this.viewerLabel.BackColor = System.Drawing.Color.Transparent;
            this.viewerLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewerLabel.Font = new System.Drawing.Font("Malgun Gothic", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.viewerLabel.ForeColor = System.Drawing.Color.White;
            this.viewerLabel.Location = new System.Drawing.Point(10, 6);
            this.viewerLabel.Name = "viewerLabel";
            this.viewerLabel.Size = new System.Drawing.Size(134, 32);
            this.viewerLabel.TabIndex = 6;
            this.viewerLabel.Text = "Excel Viewer";
            this.viewerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(94)))), ((int)(((byte)(89)))));
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Location = new System.Drawing.Point(1842, 6);
            this.exportButton.Margin = new System.Windows.Forms.Padding(0);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(108, 32);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.optionsMenuItem.Size = new System.Drawing.Size(75, 23);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1984, 1261);
            this.Controls.Add(this.viewerPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "FormMain";
            this.Text = "Condition Excel Painter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.viewerPanel.ResumeLayout(false);
            this.viewerHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.Panel viewerPanel;
        private WinFormsCustomControls.DoubleBufferedDataGridView mainGridView;
        private System.Windows.Forms.Panel viewerHeaderPanel;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Label viewerLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
    }
}

