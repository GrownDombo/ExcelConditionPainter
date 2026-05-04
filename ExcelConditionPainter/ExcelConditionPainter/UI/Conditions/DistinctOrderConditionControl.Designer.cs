namespace ExcelConditionPainter
{
    partial class DistinctOrderConditionControl
    {
        private System.ComponentModel.IContainer components = null;

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
            this.selectableColumnsComboBox = new WinFormsCustomControls.CheckBoxComboBox();
            this.conditionNameLabel = new System.Windows.Forms.Label();
            this.peopleLimitInput = new System.Windows.Forms.NumericUpDown();
            this.peopleLimitLabel = new System.Windows.Forms.Label();
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).BeginInit();
            this.SuspendLayout();
            //
            // selectableColumnsComboBox
            //
            this.selectableColumnsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectableColumnsComboBox.DropDownHeight = 1;
            this.selectableColumnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectableColumnsComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectableColumnsComboBox.FormattingEnabled = true;
            this.selectableColumnsComboBox.IntegralHeight = false;
            this.selectableColumnsComboBox.Location = new System.Drawing.Point(3, 4);
            this.selectableColumnsComboBox.Name = "selectableColumnsComboBox";
            this.selectableColumnsComboBox.Size = new System.Drawing.Size(120, 24);
            this.selectableColumnsComboBox.TabIndex = 6;
            //
            // conditionNameLabel
            //
            this.conditionNameLabel.AutoSize = true;
            this.conditionNameLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.conditionNameLabel.Location = new System.Drawing.Point(132, 8);
            this.conditionNameLabel.Name = "conditionNameLabel";
            this.conditionNameLabel.Size = new System.Drawing.Size(127, 15);
            this.conditionNameLabel.TabIndex = 3;
            this.conditionNameLabel.Text = "중복 제외 순차 검색";
            this.conditionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // peopleLimitInput
            //
            this.peopleLimitInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.peopleLimitInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peopleLimitInput.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.peopleLimitInput.Location = new System.Drawing.Point(300, 4);
            this.peopleLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.peopleLimitInput.Name = "peopleLimitInput";
            this.peopleLimitInput.Size = new System.Drawing.Size(55, 23);
            this.peopleLimitInput.TabIndex = 2;
            this.peopleLimitInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.peopleLimitInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            //
            // peopleLimitLabel
            //
            this.peopleLimitLabel.AutoSize = true;
            this.peopleLimitLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.peopleLimitLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.peopleLimitLabel.Location = new System.Drawing.Point(360, 8);
            this.peopleLimitLabel.Name = "peopleLimitLabel";
            this.peopleLimitLabel.Size = new System.Drawing.Size(19, 15);
            this.peopleLimitLabel.TabIndex = 1;
            this.peopleLimitLabel.Text = "명";
            this.peopleLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // conditionCommonControl
            //
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.MatchMode = ExcelConditionPainter.MultiSelectMatchMode.And;
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Font;
            this.conditionCommonControl.PriorityLevel = 0;
            this.conditionCommonControl.Location = new System.Drawing.Point(522, 0);
            this.conditionCommonControl.Name = "conditionCommonControl";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Red;
            this.conditionCommonControl.Size = new System.Drawing.Size(305, 30);
            this.conditionCommonControl.TabIndex = 0;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            //
            // DistinctOrderConditionControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.selectableColumnsComboBox);
            this.Controls.Add(this.conditionNameLabel);
            this.Controls.Add(this.peopleLimitInput);
            this.Controls.Add(this.peopleLimitLabel);
            this.Controls.Add(this.conditionCommonControl);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DistinctOrderConditionControl";
            this.Size = new System.Drawing.Size(827, 30);
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private System.Windows.Forms.Label peopleLimitLabel;
        private System.Windows.Forms.NumericUpDown peopleLimitInput;
        private System.Windows.Forms.Label conditionNameLabel;
        private WinFormsCustomControls.CheckBoxComboBox selectableColumnsComboBox;
    }
}
