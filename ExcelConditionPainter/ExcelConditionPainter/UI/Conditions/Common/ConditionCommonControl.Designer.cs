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
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.paintTargetButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.priorityLevelInput = new System.Windows.Forms.NumericUpDown();
            this.colorComboBox = new GDombo_CustomControl.ColorComboBox();
            this.conditionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.levelLabel = new System.Windows.Forms.Label();
            this.mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityLevelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // paintTargetButton
            // 
            this.paintTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.paintTargetButton.Location = new System.Drawing.Point(77, 3);
            this.paintTargetButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.paintTargetButton.Name = "paintTargetButton";
            this.paintTargetButton.Size = new System.Drawing.Size(47, 24);
            this.paintTargetButton.TabIndex = 3;
            this.paintTargetButton.Text = "Font";
            this.paintTargetButton.UseVisualStyleBackColor = true;
            this.paintTargetButton.Click += new System.EventHandler(this.paintTargetButton_Click);
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 5;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.Controls.Add(this.paintTargetButton, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.deleteButton, 4, 0);
            this.mainLayoutPanel.Controls.Add(this.priorityLevelInput, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.colorComboBox, 3, 0);
            this.mainLayoutPanel.Controls.Add(this.levelLabel, 0, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 1;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(221, 30);
            this.mainLayoutPanel.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Image = global::ExcelConditionPainter.Properties.Resources.Delete;
            this.deleteButton.Location = new System.Drawing.Point(191, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // priorityLevelInput
            // 
            this.priorityLevelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityLevelInput.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.priorityLevelInput.Location = new System.Drawing.Point(35, 4);
            this.priorityLevelInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.priorityLevelInput.Name = "priorityLevelInput";
            this.priorityLevelInput.Size = new System.Drawing.Size(39, 22);
            this.priorityLevelInput.TabIndex = 5;
            this.priorityLevelInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colorComboBox
            // 
            this.colorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox.DropDownHeight = 1;
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.IntegralHeight = false;
            this.colorComboBox.Location = new System.Drawing.Point(130, 4);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.SelectedColor = System.Drawing.Color.Red;
            this.colorComboBox.Size = new System.Drawing.Size(58, 22);
            this.colorComboBox.TabIndex = 6;
            // 
            // levelLabel
            // 
            this.levelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(3, 9);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(26, 12);
            this.levelLabel.TabIndex = 7;
            this.levelLabel.Text = "Lv :";
            // 
            // ConditionCommonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "ConditionCommonControl";
            this.Size = new System.Drawing.Size(221, 30);
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityLevelInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button paintTargetButton;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ToolTip conditionToolTip;
        private System.Windows.Forms.NumericUpDown priorityLevelInput;
        private GDombo_CustomControl.ColorComboBox colorComboBox;
        private System.Windows.Forms.Label levelLabel;
    }
}
