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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerPanel = new System.Windows.Forms.Panel();
            this.mainGridView = new GDombo_CustomControl.DoubleBufferedDataGridView();
            this.viewerLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.viewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.helpMenuItem,
            this.optionsMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1984, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // viewerPanel
            // 
            this.viewerPanel.Controls.Add(this.mainGridView);
            this.viewerPanel.Controls.Add(this.viewerLabel);
            this.viewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerPanel.Location = new System.Drawing.Point(0, 24);
            this.viewerPanel.Name = "viewerPanel";
            this.viewerPanel.Size = new System.Drawing.Size(1984, 1173);
            this.viewerPanel.TabIndex = 8;
            // 
            // mainGridView
            // 
            this.mainGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridView.Location = new System.Drawing.Point(0, 20);
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowTemplate.Height = 23;
            this.mainGridView.Size = new System.Drawing.Size(1984, 1153);
            this.mainGridView.TabIndex = 7;
            this.mainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainGridView_DataBindingComplete);
            this.mainGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.mainGridView_RowPostPaint);
            // 
            // viewerLabel
            // 
            this.viewerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(72)))));
            this.viewerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewerLabel.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.viewerLabel.ForeColor = System.Drawing.Color.White;
            this.viewerLabel.Location = new System.Drawing.Point(0, 0);
            this.viewerLabel.Name = "viewerLabel";
            this.viewerLabel.Size = new System.Drawing.Size(1984, 20);
            this.viewerLabel.TabIndex = 6;
            this.viewerLabel.Text = " ▶ Viewer";
            this.viewerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exportButton
            // 
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exportButton.Location = new System.Drawing.Point(0, 1197);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(1984, 64);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 1261);
            this.Controls.Add(this.viewerPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.exportButton);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "FormMain";
            this.Text = "Condition Excel Painter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.viewerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.Panel viewerPanel;
        private GDombo_CustomControl.DoubleBufferedDataGridView mainGridView;
        private System.Windows.Forms.Label viewerLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
    }
}

