namespace ExcelConditionPainter
{
    partial class FormSetConditions
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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.secondarySortColumnComboBox = new System.Windows.Forms.ComboBox();
            this.secondarySortColumnLabel = new System.Windows.Forms.Label();
            this.conditionFlowPanel = new WinFormsCustomControls.VerticalFlowLayoutPanel();
            this.duplicateConditionControl = new ExcelConditionPainter.DuplicateConditionControl();
            this.distinctOrderConditionControl = new ExcelConditionPainter.DistinctOrderConditionControl();
            this.primaryQuantityConditionControl = new ExcelConditionPainter.QuantityConditionControl();
            this.secondaryQuantityConditionControl = new ExcelConditionPainter.QuantityConditionControl();
            this.buyCountColumnComboBox = new System.Windows.Forms.ComboBox();
            this.buyCountColumnLabel = new System.Windows.Forms.Label();
            this.goodsOptionColumnComboBox = new System.Windows.Forms.ComboBox();
            this.goodsOptionColumnLabel = new System.Windows.Forms.Label();
            this.addConditionComboBox = new System.Windows.Forms.ComboBox();
            this.addConditionLabel = new System.Windows.Forms.Label();
            this.primarySortColumnComboBox = new System.Windows.Forms.ComboBox();
            this.primarySortColumnLabel = new System.Windows.Forms.Label();
            this.primaryKeyLabel = new System.Windows.Forms.Label();
            this.primaryKeyComboBox = new System.Windows.Forms.ComboBox();
            this.addConditionButton = new System.Windows.Forms.Button();
            this.optionQuantityFlowPanel = new WinFormsCustomControls.VerticalFlowLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.setButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.conditionFlowPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoSize = false;
            this.mainLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.Controls.Add(this.secondarySortColumnComboBox, 1, 2);
            this.mainLayoutPanel.Controls.Add(this.secondarySortColumnLabel, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.conditionFlowPanel, 0, 7);
            this.mainLayoutPanel.Controls.Add(this.buyCountColumnComboBox, 1, 3);
            this.mainLayoutPanel.Controls.Add(this.buyCountColumnLabel, 0, 3);
            this.mainLayoutPanel.Controls.Add(this.goodsOptionColumnComboBox, 1, 4);
            this.mainLayoutPanel.Controls.Add(this.goodsOptionColumnLabel, 0, 4);
            this.mainLayoutPanel.Controls.Add(this.addConditionComboBox, 1, 6);
            this.mainLayoutPanel.Controls.Add(this.addConditionLabel, 0, 6);
            this.mainLayoutPanel.Controls.Add(this.primarySortColumnComboBox, 1, 1);
            this.mainLayoutPanel.Controls.Add(this.primarySortColumnLabel, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.primaryKeyLabel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.primaryKeyComboBox, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.addConditionButton, 2, 6);
            this.mainLayoutPanel.Controls.Add(this.optionQuantityFlowPanel, 0, 5);
            this.mainLayoutPanel.Controls.Add(this.bottomPanel, 0, 8);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 9;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(860, 520);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // secondarySortColumnComboBox
            // 
            this.secondarySortColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.secondarySortColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondarySortColumnComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.secondarySortColumnComboBox.FormattingEnabled = true;
            this.secondarySortColumnComboBox.Location = new System.Drawing.Point(143, 65);
            this.secondarySortColumnComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.secondarySortColumnComboBox.Name = "secondarySortColumnComboBox";
            this.secondarySortColumnComboBox.Size = new System.Drawing.Size(684, 23);
            this.secondarySortColumnComboBox.TabIndex = 16;
            // 
            // secondarySortColumnLabel
            // 
            this.secondarySortColumnLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondarySortColumnLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.secondarySortColumnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.secondarySortColumnLabel.Location = new System.Drawing.Point(3, 60);
            this.secondarySortColumnLabel.Name = "secondarySortColumnLabel";
            this.secondarySortColumnLabel.Size = new System.Drawing.Size(134, 30);
            this.secondarySortColumnLabel.TabIndex = 15;
            this.secondarySortColumnLabel.Text = "졍렬 기준 선택2 :";
            this.secondarySortColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // conditionFlowPanel
            // 
            this.conditionFlowPanel.AutoScroll = true;
            this.conditionFlowPanel.AutoSize = false;
            this.conditionFlowPanel.BackColor = System.Drawing.Color.White;
            this.mainLayoutPanel.SetColumnSpan(this.conditionFlowPanel, 3);
            this.conditionFlowPanel.Controls.Add(this.duplicateConditionControl);
            this.conditionFlowPanel.Controls.Add(this.distinctOrderConditionControl);
            this.conditionFlowPanel.Controls.Add(this.primaryQuantityConditionControl);
            this.conditionFlowPanel.Controls.Add(this.secondaryQuantityConditionControl);
            this.conditionFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.conditionFlowPanel.Location = new System.Drawing.Point(3, 189);
            this.conditionFlowPanel.Margin = new System.Windows.Forms.Padding(3);
            this.conditionFlowPanel.Name = "conditionFlowPanel";
            this.conditionFlowPanel.Size = new System.Drawing.Size(854, 152);
            this.conditionFlowPanel.TabIndex = 1;
            this.conditionFlowPanel.WrapContents = false;
            // 
            // duplicateConditionControl
            // 
            this.duplicateConditionControl.PaintTarget = ExcelConditionPainter.PaintTarget.Fill;
            this.duplicateConditionControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.duplicateConditionControl.PriorityLevel = 0;
            this.duplicateConditionControl.Location = new System.Drawing.Point(3, 3);
            this.duplicateConditionControl.Margin = new System.Windows.Forms.Padding(3);
            this.duplicateConditionControl.Name = "duplicateConditionControl";
            this.duplicateConditionControl.SelectedColor = System.Drawing.Color.Coral;
            this.duplicateConditionControl.Size = new System.Drawing.Size(827, 30);
            this.duplicateConditionControl.TabIndex = 4;
            // 
            // distinctOrderConditionControl
            // 
            this.distinctOrderConditionControl.PaintTarget = ExcelConditionPainter.PaintTarget.Font;
            this.distinctOrderConditionControl.PriorityLevel = 0;
            this.distinctOrderConditionControl.Location = new System.Drawing.Point(3, 39);
            this.distinctOrderConditionControl.Margin = new System.Windows.Forms.Padding(3);
            this.distinctOrderConditionControl.Name = "distinctOrderConditionControl";
            this.distinctOrderConditionControl.PeopleLimit = 10;
            this.distinctOrderConditionControl.SelectedColor = System.Drawing.Color.Red;
            this.distinctOrderConditionControl.Size = new System.Drawing.Size(827, 30);
            this.distinctOrderConditionControl.TabIndex = 1;
            // 
            // primaryQuantityConditionControl
            // 
            this.primaryQuantityConditionControl.PaintTarget = ExcelConditionPainter.PaintTarget.Fill;
            this.primaryQuantityConditionControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.primaryQuantityConditionControl.PriorityLevel = 1;
            this.primaryQuantityConditionControl.Location = new System.Drawing.Point(3, 75);
            this.primaryQuantityConditionControl.Margin = new System.Windows.Forms.Padding(3);
            this.primaryQuantityConditionControl.Name = "primaryQuantityConditionControl";
            this.primaryQuantityConditionControl.GoodsCount = 120;
            this.primaryQuantityConditionControl.PeopleLimit = 50;
            this.primaryQuantityConditionControl.SelectedColor = System.Drawing.Color.Green;
            this.primaryQuantityConditionControl.Size = new System.Drawing.Size(827, 30);
            this.primaryQuantityConditionControl.TabIndex = 2;
            // 
            // secondaryQuantityConditionControl
            // 
            this.secondaryQuantityConditionControl.PaintTarget = ExcelConditionPainter.PaintTarget.Fill;
            this.secondaryQuantityConditionControl.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.secondaryQuantityConditionControl.PriorityLevel = 2;
            this.secondaryQuantityConditionControl.Location = new System.Drawing.Point(3, 111);
            this.secondaryQuantityConditionControl.Margin = new System.Windows.Forms.Padding(3);
            this.secondaryQuantityConditionControl.Name = "secondaryQuantityConditionControl";
            this.secondaryQuantityConditionControl.GoodsCount = 60;
            this.secondaryQuantityConditionControl.PeopleLimit = 50;
            this.secondaryQuantityConditionControl.SelectedColor = System.Drawing.Color.Yellow;
            this.secondaryQuantityConditionControl.Size = new System.Drawing.Size(827, 30);
            this.secondaryQuantityConditionControl.TabIndex = 3;
            // 
            // buyCountColumnComboBox
            // 
            this.buyCountColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buyCountColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buyCountColumnComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buyCountColumnComboBox.FormattingEnabled = true;
            this.buyCountColumnComboBox.Location = new System.Drawing.Point(143, 95);
            this.buyCountColumnComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.buyCountColumnComboBox.Name = "buyCountColumnComboBox";
            this.buyCountColumnComboBox.Size = new System.Drawing.Size(684, 23);
            this.buyCountColumnComboBox.TabIndex = 13;
            // 
            // buyCountColumnLabel
            // 
            this.buyCountColumnLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buyCountColumnLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buyCountColumnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.buyCountColumnLabel.Location = new System.Drawing.Point(3, 90);
            this.buyCountColumnLabel.Name = "buyCountColumnLabel";
            this.buyCountColumnLabel.Size = new System.Drawing.Size(134, 30);
            this.buyCountColumnLabel.TabIndex = 12;
            this.buyCountColumnLabel.Text = "수량 컬럼 선택 :";
            this.buyCountColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // goodsOptionColumnComboBox
            // 
            this.goodsOptionColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.goodsOptionColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goodsOptionColumnComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goodsOptionColumnComboBox.FormattingEnabled = true;
            this.goodsOptionColumnComboBox.Location = new System.Drawing.Point(143, 125);
            this.goodsOptionColumnComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.goodsOptionColumnComboBox.Name = "goodsOptionColumnComboBox";
            this.goodsOptionColumnComboBox.Size = new System.Drawing.Size(684, 23);
            this.goodsOptionColumnComboBox.TabIndex = 10;
            this.goodsOptionColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.goodsOptionColumnComboBox_SelectedIndexChanged);
            // 
            // goodsOptionColumnLabel
            // 
            this.goodsOptionColumnLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goodsOptionColumnLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goodsOptionColumnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.goodsOptionColumnLabel.Location = new System.Drawing.Point(3, 120);
            this.goodsOptionColumnLabel.Name = "goodsOptionColumnLabel";
            this.goodsOptionColumnLabel.Size = new System.Drawing.Size(134, 30);
            this.goodsOptionColumnLabel.TabIndex = 9;
            this.goodsOptionColumnLabel.Text = "옵션 컬럼 선택 :";
            this.goodsOptionColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addConditionComboBox
            // 
            this.addConditionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addConditionComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addConditionComboBox.FormattingEnabled = true;
            this.addConditionComboBox.Location = new System.Drawing.Point(143, 161);
            this.addConditionComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.addConditionComboBox.Name = "addConditionComboBox";
            this.addConditionComboBox.Size = new System.Drawing.Size(684, 23);
            this.addConditionComboBox.TabIndex = 7;
            // 
            // addConditionLabel
            // 
            this.addConditionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addConditionLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addConditionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.addConditionLabel.Location = new System.Drawing.Point(3, 156);
            this.addConditionLabel.Name = "addConditionLabel";
            this.addConditionLabel.Size = new System.Drawing.Size(134, 30);
            this.addConditionLabel.TabIndex = 6;
            this.addConditionLabel.Text = "조건 추가 :";
            this.addConditionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // primarySortColumnComboBox
            // 
            this.primarySortColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.primarySortColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.primarySortColumnComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.primarySortColumnComboBox.FormattingEnabled = true;
            this.primarySortColumnComboBox.Location = new System.Drawing.Point(143, 35);
            this.primarySortColumnComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.primarySortColumnComboBox.Name = "primarySortColumnComboBox";
            this.primarySortColumnComboBox.Size = new System.Drawing.Size(684, 23);
            this.primarySortColumnComboBox.TabIndex = 5;
            // 
            // primarySortColumnLabel
            // 
            this.primarySortColumnLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primarySortColumnLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.primarySortColumnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.primarySortColumnLabel.Location = new System.Drawing.Point(3, 30);
            this.primarySortColumnLabel.Name = "primarySortColumnLabel";
            this.primarySortColumnLabel.Size = new System.Drawing.Size(134, 30);
            this.primarySortColumnLabel.TabIndex = 4;
            this.primarySortColumnLabel.Text = "졍렬 기준 선택 :";
            this.primarySortColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // primaryKeyLabel
            // 
            this.primaryKeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primaryKeyLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.primaryKeyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.primaryKeyLabel.Location = new System.Drawing.Point(3, 0);
            this.primaryKeyLabel.Name = "primaryKeyLabel";
            this.primaryKeyLabel.Size = new System.Drawing.Size(134, 30);
            this.primaryKeyLabel.TabIndex = 0;
            this.primaryKeyLabel.Text = "기본키 선택 :";
            this.primaryKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // primaryKeyComboBox
            // 
            this.primaryKeyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.primaryKeyComboBox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.primaryKeyComboBox.FormattingEnabled = true;
            this.primaryKeyComboBox.Location = new System.Drawing.Point(143, 5);
            this.primaryKeyComboBox.Margin = new System.Windows.Forms.Padding(3);
            this.primaryKeyComboBox.Name = "primaryKeyComboBox";
            this.primaryKeyComboBox.Size = new System.Drawing.Size(684, 23);
            this.primaryKeyComboBox.TabIndex = 1;
            // 
            // addConditionButton
            // 
            this.addConditionButton.BackColor = System.Drawing.Color.White;
            this.addConditionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addConditionButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.addConditionButton.FlatAppearance.BorderSize = 0;
            this.addConditionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addConditionButton.Image = global::ExcelConditionPainter.Properties.Resources.Add;
            this.addConditionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addConditionButton.Location = new System.Drawing.Point(830, 156);
            this.addConditionButton.Margin = new System.Windows.Forms.Padding(0);
            this.addConditionButton.Name = "addConditionButton";
            this.addConditionButton.Padding = new System.Windows.Forms.Padding(0);
            this.addConditionButton.Size = new System.Drawing.Size(30, 30);
            this.addConditionButton.TabIndex = 8;
            this.addConditionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.addConditionButton.UseVisualStyleBackColor = false;
            this.addConditionButton.Click += new System.EventHandler(this.addConditionButton_Click);
            // 
            // optionQuantityFlowPanel
            // 
            this.optionQuantityFlowPanel.AutoScroll = true;
            this.optionQuantityFlowPanel.AutoSize = false;
            this.optionQuantityFlowPanel.BackColor = System.Drawing.Color.White;
            this.mainLayoutPanel.SetColumnSpan(this.optionQuantityFlowPanel, 3);
            this.optionQuantityFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionQuantityFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionQuantityFlowPanel.Location = new System.Drawing.Point(3, 153);
            this.optionQuantityFlowPanel.Margin = new System.Windows.Forms.Padding(3);
            this.optionQuantityFlowPanel.Name = "optionQuantityFlowPanel";
            this.optionQuantityFlowPanel.Size = new System.Drawing.Size(854, 120);
            this.optionQuantityFlowPanel.TabIndex = 11;
            this.optionQuantityFlowPanel.WrapContents = false;
            // 
            // bottomPanel
            // 
            this.mainLayoutPanel.SetColumnSpan(this.bottomPanel, 3);
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.bottomPanel.Controls.Add(this.setButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 473);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(3);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(854, 44);
            this.bottomPanel.TabIndex = 14;
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.setButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(94)))), ((int)(((byte)(89)))));
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("Malgun Gothic", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.setButton.ForeColor = System.Drawing.Color.White;
            this.setButton.Location = new System.Drawing.Point(0, 0);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(854, 44);
            this.setButton.TabIndex = 0;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // FormSetConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = global::ExcelConditionPainter.Properties.Resources.AppIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetConditions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Conditions";
            this.TopMost = true;
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.conditionFlowPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Label primaryKeyLabel;
        private System.Windows.Forms.Label primarySortColumnLabel;
        private System.Windows.Forms.ComboBox primarySortColumnComboBox;
        private System.Windows.Forms.ComboBox primaryKeyComboBox;
        private System.Windows.Forms.ComboBox addConditionComboBox;
        private System.Windows.Forms.Label addConditionLabel;
        private System.Windows.Forms.Button addConditionButton;
        private System.Windows.Forms.ComboBox goodsOptionColumnComboBox;
        private System.Windows.Forms.Label goodsOptionColumnLabel;
        private WinFormsCustomControls.VerticalFlowLayoutPanel optionQuantityFlowPanel;
        private System.Windows.Forms.Label buyCountColumnLabel;
        private System.Windows.Forms.ComboBox buyCountColumnComboBox;
        private WinFormsCustomControls.VerticalFlowLayoutPanel conditionFlowPanel;
        private DistinctOrderConditionControl distinctOrderConditionControl;
        private QuantityConditionControl primaryQuantityConditionControl;
        private QuantityConditionControl secondaryQuantityConditionControl;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button setButton;
        private DuplicateConditionControl duplicateConditionControl;
        private System.Windows.Forms.ComboBox secondarySortColumnComboBox;
        private System.Windows.Forms.Label secondarySortColumnLabel;
    }
}
