namespace ExcelConditionPainter
{
    partial class ConditionCommonControl
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.matchModeButton = new System.Windows.Forms.Button();
            this.paintTargetButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.priorityLevelInput = new System.Windows.Forms.NumericUpDown();
            this.colorComboBox = new WinFormsCustomControls.ColorComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.conditionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityLevelInput)).BeginInit();
            this.SuspendLayout();
            //
            // matchModeButton
            //
            this.matchModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.matchModeButton.BackColor = System.Drawing.Color.White;
            this.matchModeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.matchModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.matchModeButton.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.matchModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.matchModeButton.Location = new System.Drawing.Point(3, 3);
            this.matchModeButton.Margin = new System.Windows.Forms.Padding(3);
            this.matchModeButton.Name = "matchModeButton";
            this.matchModeButton.Size = new System.Drawing.Size(49, 24);
            this.matchModeButton.TabIndex = 8;
            this.matchModeButton.Text = "AND";
            this.matchModeButton.UseVisualStyleBackColor = false;
            this.matchModeButton.Click += new System.EventHandler(this.matchModeButton_Click);
            //
            // paintTargetButton
            //
            this.paintTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.paintTargetButton.BackColor = System.Drawing.Color.White;
            this.paintTargetButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.paintTargetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintTargetButton.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.paintTargetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.paintTargetButton.Location = new System.Drawing.Point(132, 3);
            this.paintTargetButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.paintTargetButton.Name = "paintTargetButton";
            this.paintTargetButton.Size = new System.Drawing.Size(50, 24);
            this.paintTargetButton.TabIndex = 3;
            this.paintTargetButton.Text = "Font";
            this.paintTargetButton.UseVisualStyleBackColor = false;
            this.paintTargetButton.Click += new System.EventHandler(this.paintTargetButton_Click);
            //
            // mainLayoutPanel
            //
            this.mainLayoutPanel.BackColor = System.Drawing.Color.White;
            this.mainLayoutPanel.ColumnCount = 6;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.Controls.Add(this.matchModeButton, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.levelLabel, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.priorityLevelInput, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.paintTargetButton, 3, 0);
            this.mainLayoutPanel.Controls.Add(this.colorComboBox, 4, 0);
            this.mainLayoutPanel.Controls.Add(this.deleteButton, 5, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 1;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(305, 30);
            this.mainLayoutPanel.TabIndex = 4;
            //
            // deleteButton
            //
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.Color.White;
            this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Image = global::ExcelConditionPainter.Properties.Resources.Delete;
            this.deleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteButton.Location = new System.Drawing.Point(275, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(0);
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            //
            // priorityLevelInput
            //
            this.priorityLevelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priorityLevelInput.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.priorityLevelInput.Location = new System.Drawing.Point(90, 4);
            this.priorityLevelInput.Margin = new System.Windows.Forms.Padding(3);
            this.priorityLevelInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.priorityLevelInput.Name = "priorityLevelInput";
            this.priorityLevelInput.Size = new System.Drawing.Size(39, 23);
            this.priorityLevelInput.TabIndex = 5;
            this.priorityLevelInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // colorComboBox
            //
            this.colorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox.DropDownHeight = 1;
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.IntegralHeight = false;
            this.colorComboBox.Location = new System.Drawing.Point(188, 4);
            this.colorComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.SelectedColor = System.Drawing.Color.Red;
            this.colorComboBox.Size = new System.Drawing.Size(84, 24);
            this.colorComboBox.TabIndex = 6;
            //
            // levelLabel
            //
            this.levelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.levelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.levelLabel.Location = new System.Drawing.Point(58, 7);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(26, 15);
            this.levelLabel.TabIndex = 7;
            this.levelLabel.Text = "Lv :";
            //
            // ConditionCommonControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "ConditionCommonControl";
            this.Size = new System.Drawing.Size(305, 30);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityLevelInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button matchModeButton;
        private System.Windows.Forms.Button paintTargetButton;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ToolTip conditionToolTip;
        private System.Windows.Forms.NumericUpDown priorityLevelInput;
        private WinFormsCustomControls.ColorComboBox colorComboBox;
        private System.Windows.Forms.Label levelLabel;
    }
}
