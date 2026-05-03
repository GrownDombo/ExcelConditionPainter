namespace ExcelConditionPainter
{
    partial class DuplicateConditionControl
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
            this.selectableColumnsComboBox = new WinFormsCustomControls.CheckBoxComboBox();
            this.conditionDescriptionLabel = new System.Windows.Forms.Label();
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
            this.selectableColumnsComboBox.Location = new System.Drawing.Point(3, 5);
            this.selectableColumnsComboBox.Name = "selectableColumnsComboBox";
            this.selectableColumnsComboBox.Size = new System.Drawing.Size(90, 24);
            this.selectableColumnsComboBox.TabIndex = 6;
            // 
            // conditionDescriptionLabel
            // 
            this.conditionDescriptionLabel.AutoSize = true;
            this.conditionDescriptionLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.conditionDescriptionLabel.Location = new System.Drawing.Point(96, 8);
            this.conditionDescriptionLabel.Name = "conditionDescriptionLabel";
            this.conditionDescriptionLabel.Size = new System.Drawing.Size(218, 15);
            this.conditionDescriptionLabel.TabIndex = 7;
            this.conditionDescriptionLabel.Text = "이 같은 사람들 중 중복되는 데이터";
            // 
            // ConditionCommonControl
            // 
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Font;
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.PriorityLevel = 0;
            this.conditionCommonControl.Location = new System.Drawing.Point(545, 0);
            this.conditionCommonControl.Name = "ConditionCommonControl";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Coral;
            this.conditionCommonControl.Size = new System.Drawing.Size(215, 30);
            this.conditionCommonControl.TabIndex = 0;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            // 
            // DuplicateConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.conditionDescriptionLabel);
            this.Controls.Add(this.selectableColumnsComboBox);
            this.Controls.Add(this.conditionCommonControl);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DuplicateConditionControl";
            this.Size = new System.Drawing.Size(760, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private WinFormsCustomControls.CheckBoxComboBox selectableColumnsComboBox;
        private System.Windows.Forms.Label conditionDescriptionLabel;
    }
}
