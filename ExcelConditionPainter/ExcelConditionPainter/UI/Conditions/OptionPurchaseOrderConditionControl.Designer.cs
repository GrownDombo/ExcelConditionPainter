namespace ExcelConditionPainter
{
    partial class OptionPurchaseOrderConditionControl
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
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
            this.selectableOptionsComboBox = new GDombo_CustomControl.CheckBoxComboBox();
            this.conditionDescriptionLabel = new System.Windows.Forms.Label();
            this.peopleLimitLabel = new System.Windows.Forms.Label();
            this.peopleLimitInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).BeginInit();
            this.SuspendLayout();
            // 
            // ConditionCommon
            // 
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Fill;
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.PriorityLevel = 1;
            this.conditionCommonControl.Location = new System.Drawing.Point(485, 0);
            this.conditionCommonControl.Name = "ConditionCommon";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Yellow;
            this.conditionCommonControl.Size = new System.Drawing.Size(215, 30);
            this.conditionCommonControl.TabIndex = 1;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            // 
            // selectableOptionsComboBox
            // 
            this.selectableOptionsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectableOptionsComboBox.DropDownHeight = 1;
            this.selectableOptionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectableOptionsComboBox.FormattingEnabled = true;
            this.selectableOptionsComboBox.IntegralHeight = false;
            this.selectableOptionsComboBox.Location = new System.Drawing.Point(4, 4);
            this.selectableOptionsComboBox.Name = "selectableOptionsComboBox";
            this.selectableOptionsComboBox.Size = new System.Drawing.Size(90, 22);
            this.selectableOptionsComboBox.TabIndex = 2;
            // 
            // conditionDescriptionLabel
            // 
            this.conditionDescriptionLabel.AutoSize = true;
            this.conditionDescriptionLabel.Location = new System.Drawing.Point(97, 10);
            this.conditionDescriptionLabel.Name = "conditionDescriptionLabel";
            this.conditionDescriptionLabel.Size = new System.Drawing.Size(165, 12);
            this.conditionDescriptionLabel.TabIndex = 8;
            this.conditionDescriptionLabel.Text = "옵션을 구입한 사람 중 선착순";
            // 
            // peopleLimitLabel
            // 
            this.peopleLimitLabel.AutoSize = true;
            this.peopleLimitLabel.Location = new System.Drawing.Point(324, 9);
            this.peopleLimitLabel.Name = "peopleLimitLabel";
            this.peopleLimitLabel.Size = new System.Drawing.Size(17, 12);
            this.peopleLimitLabel.TabIndex = 12;
            this.peopleLimitLabel.Text = "명";
            // 
            // peopleLimitInput
            // 
            this.peopleLimitInput.Location = new System.Drawing.Point(266, 5);
            this.peopleLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.peopleLimitInput.Name = "peopleLimitInput";
            this.peopleLimitInput.Size = new System.Drawing.Size(55, 21);
            this.peopleLimitInput.TabIndex = 11;
            this.peopleLimitInput.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // uConditionOptionBuyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peopleLimitLabel);
            this.Controls.Add(this.peopleLimitInput);
            this.Controls.Add(this.conditionDescriptionLabel);
            this.Controls.Add(this.selectableOptionsComboBox);
            this.Controls.Add(this.conditionCommonControl);
            this.Name = "uConditionOptionBuyOrder";
            this.Size = new System.Drawing.Size(700, 30);
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private GDombo_CustomControl.CheckBoxComboBox selectableOptionsComboBox;
        private System.Windows.Forms.Label conditionDescriptionLabel;
        private System.Windows.Forms.Label peopleLimitLabel;
        private System.Windows.Forms.NumericUpDown peopleLimitInput;
    }
}
