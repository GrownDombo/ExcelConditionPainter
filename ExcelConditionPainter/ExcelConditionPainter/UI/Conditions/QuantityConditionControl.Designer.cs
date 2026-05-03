namespace ExcelConditionPainter
{
    partial class QuantityConditionControl
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
            this.selectableColumnsComboBox = new GDombo_CustomControl.CheckBoxComboBox();
            this.selectedColumnsLabel = new System.Windows.Forms.Label();
            this.goodsCountInput = new System.Windows.Forms.NumericUpDown();
            this.goodsCountLabel = new System.Windows.Forms.Label();
            this.peopleLimitInput = new System.Windows.Forms.NumericUpDown();
            this.conditionCommonControl = new ExcelConditionPainter.ConditionCommonControl();
            this.peopleLimitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.goodsCountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).BeginInit();
            this.SuspendLayout();
            // 
            // selectableColumnsComboBox
            // 
            this.selectableColumnsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectableColumnsComboBox.DropDownHeight = 1;
            this.selectableColumnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectableColumnsComboBox.FormattingEnabled = true;
            this.selectableColumnsComboBox.IntegralHeight = false;
            this.selectableColumnsComboBox.Location = new System.Drawing.Point(3, 5);
            this.selectableColumnsComboBox.Name = "selectableColumnsComboBox";
            this.selectableColumnsComboBox.Size = new System.Drawing.Size(90, 22);
            this.selectableColumnsComboBox.TabIndex = 5;
            // 
            // selectedColumnsLabel
            // 
            this.selectedColumnsLabel.AutoSize = true;
            this.selectedColumnsLabel.Location = new System.Drawing.Point(96, 10);
            this.selectedColumnsLabel.Name = "selectedColumnsLabel";
            this.selectedColumnsLabel.Size = new System.Drawing.Size(101, 12);
            this.selectedColumnsLabel.TabIndex = 6;
            this.selectedColumnsLabel.Text = "이 같은 사람들 중";
            // 
            // goodsCountInput
            // 
            this.goodsCountInput.Location = new System.Drawing.Point(201, 6);
            this.goodsCountInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.goodsCountInput.Name = "goodsCountInput";
            this.goodsCountInput.Size = new System.Drawing.Size(55, 21);
            this.goodsCountInput.TabIndex = 7;
            // 
            // goodsCountLabel
            // 
            this.goodsCountLabel.AutoSize = true;
            this.goodsCountLabel.Location = new System.Drawing.Point(257, 10);
            this.goodsCountLabel.Name = "goodsCountLabel";
            this.goodsCountLabel.Size = new System.Drawing.Size(125, 12);
            this.goodsCountLabel.TabIndex = 8;
            this.goodsCountLabel.Text = "개 이상 구매자 선착순";
            // 
            // peopleLimitInput
            // 
            this.peopleLimitInput.Location = new System.Drawing.Point(383, 6);
            this.peopleLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.peopleLimitInput.Name = "peopleLimitInput";
            this.peopleLimitInput.Size = new System.Drawing.Size(55, 21);
            this.peopleLimitInput.TabIndex = 9;
            this.peopleLimitInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ConditionCommon
            // 
            this.conditionCommonControl.PaintTarget = ExcelConditionPainter.PaintTarget.Font;
            this.conditionCommonControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.conditionCommonControl.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.conditionCommonControl.PriorityLevel = 0;
            this.conditionCommonControl.Location = new System.Drawing.Point(485, 0);
            this.conditionCommonControl.Name = "ConditionCommon";
            this.conditionCommonControl.SelectedColor = System.Drawing.Color.Red;
            this.conditionCommonControl.Size = new System.Drawing.Size(215, 30);
            this.conditionCommonControl.TabIndex = 4;
            this.conditionCommonControl.DeleteButtonClick += new System.EventHandler(this.conditionCommonControl_DeleteButtonClick);
            // 
            // peopleLimitLabel
            // 
            this.peopleLimitLabel.AutoSize = true;
            this.peopleLimitLabel.Location = new System.Drawing.Point(441, 10);
            this.peopleLimitLabel.Name = "peopleLimitLabel";
            this.peopleLimitLabel.Size = new System.Drawing.Size(17, 12);
            this.peopleLimitLabel.TabIndex = 10;
            this.peopleLimitLabel.Text = "명";
            // 
            // uConditionCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peopleLimitLabel);
            this.Controls.Add(this.peopleLimitInput);
            this.Controls.Add(this.goodsCountLabel);
            this.Controls.Add(this.goodsCountInput);
            this.Controls.Add(this.selectedColumnsLabel);
            this.Controls.Add(this.selectableColumnsComboBox);
            this.Controls.Add(this.conditionCommonControl);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "uConditionCount";
            this.Size = new System.Drawing.Size(700, 30);
            ((System.ComponentModel.ISupportInitialize)(this.goodsCountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleLimitInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ConditionCommonControl conditionCommonControl;
        private GDombo_CustomControl.CheckBoxComboBox selectableColumnsComboBox;
        private System.Windows.Forms.Label selectedColumnsLabel;
        private System.Windows.Forms.NumericUpDown goodsCountInput;
        private System.Windows.Forms.Label goodsCountLabel;
        private System.Windows.Forms.NumericUpDown peopleLimitInput;
        private System.Windows.Forms.Label peopleLimitLabel;
    }
}
