namespace ExcelConditionPainter
{
    partial class OptionPurchaseOrderConditionControl
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
            this.selectableOptionsComboBox = new WinFormsCustomControls.CheckBoxComboBox();
            this.conditionNameLabel = new System.Windows.Forms.Label();
            this.peopleLimitInput = new System.Windows.Forms.NumericUpDown();
            this.peopleLimitLabel = new System.Windows.Forms.Label();
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).BeginInit();
            this.SuspendLayout();
            //
            // selectableOptionsComboBox
            //
            this.selectableOptionsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectableOptionsComboBox.DropDownHeight = 1;
            this.selectableOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectableOptionsComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectableOptionsComboBox.FormattingEnabled = true;
            this.selectableOptionsComboBox.IntegralHeight = false;
            this.selectableOptionsComboBox.Location = new System.Drawing.Point(3, 4);
            this.selectableOptionsComboBox.Name = "selectableOptionsComboBox";
            this.selectableOptionsComboBox.Size = new System.Drawing.Size(120, 24);
            this.selectableOptionsComboBox.TabIndex = 2;
            //
            // conditionNameLabel
            //
            this.conditionNameLabel.AutoSize = true;
            this.conditionNameLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.conditionNameLabel.Location = new System.Drawing.Point(132, 8);
            this.conditionNameLabel.Name = "conditionNameLabel";
            this.conditionNameLabel.Size = new System.Drawing.Size(127, 15);
            this.conditionNameLabel.TabIndex = 8;
            this.conditionNameLabel.Text = "특정 옵션 구매 검색";
            //
            // peopleLimitInput
            //
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
            this.peopleLimitInput.TabIndex = 11;
            this.peopleLimitInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.peopleLimitInput.Value = new decimal(new int[] {
            50,
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
            this.peopleLimitLabel.TabIndex = 12;
            this.peopleLimitLabel.Text = "명";
            //
            // conditionCommonControl
            //
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.MatchMode = ExcelConditionPainter.MultiSelectMatchMode.Or;
            this.conditionCommonControl.MatchModeEnabled = false;
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Fill;
            this.conditionCommonControl.PriorityLevel = 1;
            this.conditionCommonControl.Location = new System.Drawing.Point(522, 0);
            this.conditionCommonControl.Name = "conditionCommonControl";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Yellow;
            this.conditionCommonControl.Size = new System.Drawing.Size(305, 30);
            this.conditionCommonControl.TabIndex = 1;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            //
            // OptionPurchaseOrderConditionControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.peopleLimitLabel);
            this.Controls.Add(this.peopleLimitInput);
            this.Controls.Add(this.conditionNameLabel);
            this.Controls.Add(this.selectableOptionsComboBox);
            this.Controls.Add(this.conditionCommonControl);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "OptionPurchaseOrderConditionControl";
            this.Size = new System.Drawing.Size(827, 30);
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private WinFormsCustomControls.CheckBoxComboBox selectableOptionsComboBox;
        private System.Windows.Forms.Label conditionNameLabel;
        private System.Windows.Forms.Label peopleLimitLabel;
        private System.Windows.Forms.NumericUpDown peopleLimitInput;
    }
}
