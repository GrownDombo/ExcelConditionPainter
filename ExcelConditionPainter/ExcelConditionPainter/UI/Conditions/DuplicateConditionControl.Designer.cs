namespace ExcelConditionPainter
{
    partial class DuplicateConditionControl
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
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
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
            this.conditionNameLabel.Size = new System.Drawing.Size(111, 15);
            this.conditionNameLabel.TabIndex = 7;
            this.conditionNameLabel.Text = "중복값 Cell 검색";
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
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Coral;
            this.conditionCommonControl.Size = new System.Drawing.Size(305, 30);
            this.conditionCommonControl.TabIndex = 0;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            //
            // DuplicateConditionControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.conditionNameLabel);
            this.Controls.Add(this.selectableColumnsComboBox);
            this.Controls.Add(this.conditionCommonControl);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DuplicateConditionControl";
            this.Size = new System.Drawing.Size(827, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private WinFormsCustomControls.CheckBoxComboBox selectableColumnsComboBox;
        private System.Windows.Forms.Label conditionNameLabel;
    }
}
