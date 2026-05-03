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
            this.exportSplitByConditionsCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exportSplitByConditionsCheckBox
            // 
            this.exportSplitByConditionsCheckBox.AutoSize = true;
            this.exportSplitByConditionsCheckBox.Location = new System.Drawing.Point(5, 5);
            this.exportSplitByConditionsCheckBox.Name = "exportSplitByConditionsCheckBox";
            this.exportSplitByConditionsCheckBox.Size = new System.Drawing.Size(171, 16);
            this.exportSplitByConditionsCheckBox.TabIndex = 0;
            this.exportSplitByConditionsCheckBox.Text = "Export Split By Conditions";
            this.exportSplitByConditionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveButton.Location = new System.Drawing.Point(0, 54);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(202, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 77);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exportSplitByConditionsCheckBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox exportSplitByConditionsCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}