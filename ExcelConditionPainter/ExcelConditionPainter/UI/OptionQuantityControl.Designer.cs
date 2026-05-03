namespace ExcelConditionPainter
{
    partial class OptionQuantityControl
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
            this.optionNameLabel = new System.Windows.Forms.Label();
            this.optionCountInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.optionCountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // optionNameLabel
            // 
            this.optionNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.optionNameLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.optionNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.optionNameLabel.Location = new System.Drawing.Point(0, 1);
            this.optionNameLabel.Name = "optionNameLabel";
            this.optionNameLabel.Size = new System.Drawing.Size(249, 22);
            this.optionNameLabel.TabIndex = 0;
            this.optionNameLabel.Text = "OptionName";
            this.optionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optionCountInput
            // 
            this.optionCountInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionCountInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionCountInput.Font = new System.Drawing.Font("Malgun Gothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.optionCountInput.Location = new System.Drawing.Point(249, 0);
            this.optionCountInput.Margin = new System.Windows.Forms.Padding(3);
            this.optionCountInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.optionCountInput.Name = "optionCountInput";
            this.optionCountInput.Size = new System.Drawing.Size(51, 26);
            this.optionCountInput.TabIndex = 1;
            this.optionCountInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.optionCountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OptionQuantityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.optionNameLabel);
            this.Controls.Add(this.optionCountInput);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OptionQuantityControl";
            this.Size = new System.Drawing.Size(300, 25);
            ((System.ComponentModel.ISupportInitialize)(this.optionCountInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label optionNameLabel;
        private System.Windows.Forms.NumericUpDown optionCountInput;
    }
}
