namespace ExcelConditionPainter
{
    partial class DistinctOrderConditionControl
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
            this.peopleLimitLabel = new System.Windows.Forms.Label();
            this.peopleLimitInput = new System.Windows.Forms.NumericUpDown();
            this.selectedColumnsLabel = new System.Windows.Forms.Label();
            this.selectableColumnsComboBox = new GDombo_CustomControl.CheckBoxComboBox();
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).BeginInit();
            this.SuspendLayout();
            // 
            // peopleLimitLabel
            // 
            this.peopleLimitLabel.AutoSize = true;
            this.peopleLimitLabel.Location = new System.Drawing.Point(334, 10);
            this.peopleLimitLabel.Name = "peopleLimitLabel";
            this.peopleLimitLabel.Size = new System.Drawing.Size(17, 12);
            this.peopleLimitLabel.TabIndex = 1;
            this.peopleLimitLabel.Text = "명";
            this.peopleLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // peopleLimitInput
            // 
            this.peopleLimitInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.peopleLimitInput.Location = new System.Drawing.Point(287, 5);
            this.peopleLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.peopleLimitInput.Name = "peopleLimitInput";
            this.peopleLimitInput.Size = new System.Drawing.Size(44, 21);
            this.peopleLimitInput.TabIndex = 2;
            this.peopleLimitInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.peopleLimitInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // selectedColumnsLabel
            // 
            this.selectedColumnsLabel.AutoSize = true;
            this.selectedColumnsLabel.Location = new System.Drawing.Point(95, 10);
            this.selectedColumnsLabel.Name = "selectedColumnsLabel";
            this.selectedColumnsLabel.Size = new System.Drawing.Size(189, 12);
            this.selectedColumnsLabel.TabIndex = 3;
            this.selectedColumnsLabel.Text = "을 기준으로 중복을 제외한 선착순";
            this.selectedColumnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectableColumnsComboBox
            // 
            this.selectableColumnsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectableColumnsComboBox.DropDownHeight = 1;
            this.selectableColumnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectableColumnsComboBox.FormattingEnabled = true;
            this.selectableColumnsComboBox.IntegralHeight = false;
            this.selectableColumnsComboBox.Location = new System.Drawing.Point(3, 4);
            this.selectableColumnsComboBox.Name = "selectableColumnsComboBox";
            this.selectableColumnsComboBox.Size = new System.Drawing.Size(90, 22);
            this.selectableColumnsComboBox.TabIndex = 6;
            // 
            // conditionCommonControl
            // 
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Font;
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.PriorityLevel = 0;
            this.conditionCommonControl.Location = new System.Drawing.Point(385, 0);
            this.conditionCommonControl.Name = "conditionCommonControl";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Red;
            this.conditionCommonControl.Size = new System.Drawing.Size(215, 30);
            this.conditionCommonControl.TabIndex = 0;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            // 
            // DistinctOrderConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectableColumnsComboBox);
            this.Controls.Add(this.peopleLimitInput);
            this.Controls.Add(this.peopleLimitLabel);
            this.Controls.Add(this.conditionCommonControl);
            this.Controls.Add(this.selectedColumnsLabel);
            this.Name = "DistinctOrderConditionControl";
            this.Size = new System.Drawing.Size(600, 30);
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConditionCommonControl conditionCommonControl;
        private System.Windows.Forms.Label peopleLimitLabel;
        private System.Windows.Forms.NumericUpDown peopleLimitInput;
        private System.Windows.Forms.Label selectedColumnsLabel;
        private GDombo_CustomControl.CheckBoxComboBox selectableColumnsComboBox;
    }
}
