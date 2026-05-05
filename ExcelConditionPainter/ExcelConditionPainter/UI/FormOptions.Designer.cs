namespace ExcelConditionPainter
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.exportSplitByConditionsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.matchModeDefaultTitleLabel = new System.Windows.Forms.Label();
            this.orderDefaultMatchModeLabel = new System.Windows.Forms.Label();
            this.orderDefaultMatchModeComboBox = new System.Windows.Forms.ComboBox();
            this.duplicateDefaultMatchModeLabel = new System.Windows.Forms.Label();
            this.duplicateDefaultMatchModeComboBox = new System.Windows.Forms.ComboBox();
            this.quantityDefaultMatchModeLabel = new System.Windows.Forms.Label();
            this.quantityDefaultMatchModeComboBox = new System.Windows.Forms.ComboBox();
            this.optionBuyOrderDefaultMatchModeLabel = new System.Windows.Forms.Label();
            this.optionBuyOrderDefaultMatchModeComboBox = new System.Windows.Forms.ComboBox();
            this.conditionDefaultToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            //
            // exportSplitByConditionsCheckBox
            //
            this.exportSplitByConditionsCheckBox.AutoSize = true;
            this.exportSplitByConditionsCheckBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exportSplitByConditionsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.exportSplitByConditionsCheckBox.Location = new System.Drawing.Point(20, 22);
            this.exportSplitByConditionsCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.exportSplitByConditionsCheckBox.Name = "exportSplitByConditionsCheckBox";
            this.exportSplitByConditionsCheckBox.Size = new System.Drawing.Size(192, 21);
            this.exportSplitByConditionsCheckBox.TabIndex = 0;
            this.exportSplitByConditionsCheckBox.Text = "Export Split By Conditions";
            this.exportSplitByConditionsCheckBox.UseVisualStyleBackColor = true;
            //
            // matchModeDefaultTitleLabel
            //
            this.matchModeDefaultTitleLabel.AutoSize = true;
            this.matchModeDefaultTitleLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.matchModeDefaultTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.matchModeDefaultTitleLabel.Location = new System.Drawing.Point(20, 62);
            this.matchModeDefaultTitleLabel.Name = "matchModeDefaultTitleLabel";
            this.matchModeDefaultTitleLabel.Size = new System.Drawing.Size(140, 17);
            this.matchModeDefaultTitleLabel.TabIndex = 2;
            this.matchModeDefaultTitleLabel.Text = "조건별 기본 검색 방식";
            //
            // orderDefaultMatchModeLabel
            //
            this.orderDefaultMatchModeLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.orderDefaultMatchModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.orderDefaultMatchModeLabel.Location = new System.Drawing.Point(22, 94);
            this.orderDefaultMatchModeLabel.Name = "orderDefaultMatchModeLabel";
            this.orderDefaultMatchModeLabel.Size = new System.Drawing.Size(190, 23);
            this.orderDefaultMatchModeLabel.TabIndex = 3;
            this.orderDefaultMatchModeLabel.Text = "중복 제외 순차 검색";
            this.orderDefaultMatchModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // orderDefaultMatchModeComboBox
            //
            this.orderDefaultMatchModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderDefaultMatchModeComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.orderDefaultMatchModeComboBox.FormattingEnabled = true;
            this.orderDefaultMatchModeComboBox.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.orderDefaultMatchModeComboBox.Location = new System.Drawing.Point(250, 94);
            this.orderDefaultMatchModeComboBox.Name = "orderDefaultMatchModeComboBox";
            this.orderDefaultMatchModeComboBox.Size = new System.Drawing.Size(120, 23);
            this.orderDefaultMatchModeComboBox.TabIndex = 4;
            //
            // duplicateDefaultMatchModeLabel
            //
            this.duplicateDefaultMatchModeLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.duplicateDefaultMatchModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.duplicateDefaultMatchModeLabel.Location = new System.Drawing.Point(22, 126);
            this.duplicateDefaultMatchModeLabel.Name = "duplicateDefaultMatchModeLabel";
            this.duplicateDefaultMatchModeLabel.Size = new System.Drawing.Size(190, 23);
            this.duplicateDefaultMatchModeLabel.TabIndex = 5;
            this.duplicateDefaultMatchModeLabel.Text = "중복값 Cell 검색";
            this.duplicateDefaultMatchModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // duplicateDefaultMatchModeComboBox
            //
            this.duplicateDefaultMatchModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.duplicateDefaultMatchModeComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.duplicateDefaultMatchModeComboBox.FormattingEnabled = true;
            this.duplicateDefaultMatchModeComboBox.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.duplicateDefaultMatchModeComboBox.Location = new System.Drawing.Point(250, 126);
            this.duplicateDefaultMatchModeComboBox.Name = "duplicateDefaultMatchModeComboBox";
            this.duplicateDefaultMatchModeComboBox.Size = new System.Drawing.Size(120, 23);
            this.duplicateDefaultMatchModeComboBox.TabIndex = 6;
            //
            // quantityDefaultMatchModeLabel
            //
            this.quantityDefaultMatchModeLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.quantityDefaultMatchModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.quantityDefaultMatchModeLabel.Location = new System.Drawing.Point(22, 158);
            this.quantityDefaultMatchModeLabel.Name = "quantityDefaultMatchModeLabel";
            this.quantityDefaultMatchModeLabel.Size = new System.Drawing.Size(190, 23);
            this.quantityDefaultMatchModeLabel.TabIndex = 7;
            this.quantityDefaultMatchModeLabel.Text = "총 구매 수량 검색";
            this.quantityDefaultMatchModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // quantityDefaultMatchModeComboBox
            //
            this.quantityDefaultMatchModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quantityDefaultMatchModeComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.quantityDefaultMatchModeComboBox.FormattingEnabled = true;
            this.quantityDefaultMatchModeComboBox.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.quantityDefaultMatchModeComboBox.Location = new System.Drawing.Point(250, 158);
            this.quantityDefaultMatchModeComboBox.Name = "quantityDefaultMatchModeComboBox";
            this.quantityDefaultMatchModeComboBox.Size = new System.Drawing.Size(120, 23);
            this.quantityDefaultMatchModeComboBox.TabIndex = 8;
            //
            // optionBuyOrderDefaultMatchModeLabel
            //
            this.optionBuyOrderDefaultMatchModeLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.optionBuyOrderDefaultMatchModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.optionBuyOrderDefaultMatchModeLabel.Location = new System.Drawing.Point(22, 190);
            this.optionBuyOrderDefaultMatchModeLabel.Name = "optionBuyOrderDefaultMatchModeLabel";
            this.optionBuyOrderDefaultMatchModeLabel.Size = new System.Drawing.Size(190, 23);
            this.optionBuyOrderDefaultMatchModeLabel.TabIndex = 9;
            this.optionBuyOrderDefaultMatchModeLabel.Text = "특정 옵션 구매 검색";
            this.optionBuyOrderDefaultMatchModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // optionBuyOrderDefaultMatchModeComboBox
            //
            this.optionBuyOrderDefaultMatchModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionBuyOrderDefaultMatchModeComboBox.Enabled = false;
            this.optionBuyOrderDefaultMatchModeComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.optionBuyOrderDefaultMatchModeComboBox.FormattingEnabled = true;
            this.optionBuyOrderDefaultMatchModeComboBox.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.optionBuyOrderDefaultMatchModeComboBox.Location = new System.Drawing.Point(250, 190);
            this.optionBuyOrderDefaultMatchModeComboBox.Name = "optionBuyOrderDefaultMatchModeComboBox";
            this.optionBuyOrderDefaultMatchModeComboBox.Size = new System.Drawing.Size(120, 23);
            this.optionBuyOrderDefaultMatchModeComboBox.TabIndex = 10;
            //
            // saveButton
            //
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(94)))), ((int)(((byte)(89)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(0, 236);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(400, 44);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            //
            // FormOptions
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.optionBuyOrderDefaultMatchModeComboBox);
            this.Controls.Add(this.optionBuyOrderDefaultMatchModeLabel);
            this.Controls.Add(this.quantityDefaultMatchModeComboBox);
            this.Controls.Add(this.quantityDefaultMatchModeLabel);
            this.Controls.Add(this.duplicateDefaultMatchModeComboBox);
            this.Controls.Add(this.duplicateDefaultMatchModeLabel);
            this.Controls.Add(this.orderDefaultMatchModeComboBox);
            this.Controls.Add(this.orderDefaultMatchModeLabel);
            this.Controls.Add(this.matchModeDefaultTitleLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exportSplitByConditionsCheckBox);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = global::ExcelConditionPainter.Properties.Resources.AppIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 319);
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox exportSplitByConditionsCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label matchModeDefaultTitleLabel;
        private System.Windows.Forms.Label orderDefaultMatchModeLabel;
        private System.Windows.Forms.ComboBox orderDefaultMatchModeComboBox;
        private System.Windows.Forms.Label duplicateDefaultMatchModeLabel;
        private System.Windows.Forms.ComboBox duplicateDefaultMatchModeComboBox;
        private System.Windows.Forms.Label quantityDefaultMatchModeLabel;
        private System.Windows.Forms.ComboBox quantityDefaultMatchModeComboBox;
        private System.Windows.Forms.Label optionBuyOrderDefaultMatchModeLabel;
        private System.Windows.Forms.ComboBox optionBuyOrderDefaultMatchModeComboBox;
        private System.Windows.Forms.ToolTip conditionDefaultToolTip;
    }
}
