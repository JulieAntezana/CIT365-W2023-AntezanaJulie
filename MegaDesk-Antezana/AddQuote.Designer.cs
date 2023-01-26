namespace MegaDesk_Antezana
{
    partial class AddQuote
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.depth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drawers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.material = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rushDaysOptions = new System.Windows.Forms.TextBox();
            this.TodayDate = new System.Windows.Forms.Label();
            this.SaveQuote = new System.Windows.Forms.Button();
            this.ShowQuoteButton = new System.Windows.Forms.Button();
            this.currentDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rushDays = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(178, 48);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(155, 20);
            this.customerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width in inches";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(178, 74);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(155, 20);
            this.width.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Depth in inches";
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(178, 100);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(155, 20);
            this.depth.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number of Drawers (0 - 7)";
            // 
            // drawers
            // 
            this.drawers.Location = new System.Drawing.Point(178, 126);
            this.drawers.Name = "drawers";
            this.drawers.Size = new System.Drawing.Size(155, 20);
            this.drawers.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Surface Material";
            // 
            // material
            // 
            this.material.Location = new System.Drawing.Point(178, 152);
            this.material.Name = "material";
            this.material.Size = new System.Drawing.Size(155, 20);
            this.material.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rush Days (3, 5, or 7)";
            // 
            // rushDaysOptions
            // 
            this.rushDaysOptions.Location = new System.Drawing.Point(178, 181);
            this.rushDaysOptions.Name = "rushDaysOptions";
            this.rushDaysOptions.Size = new System.Drawing.Size(155, 20);
            this.rushDaysOptions.TabIndex = 6;
            // 
            // TodayDate
            // 
            this.TodayDate.AutoSize = true;
            this.TodayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodayDate.Location = new System.Drawing.Point(125, 154);
            this.TodayDate.Name = "TodayDate";
            this.TodayDate.Size = new System.Drawing.Size(0, 20);
            this.TodayDate.TabIndex = 15;
            // 
            // SaveQuote
            // 
            this.SaveQuote.Location = new System.Drawing.Point(231, 222);
            this.SaveQuote.Name = "SaveQuote";
            this.SaveQuote.Size = new System.Drawing.Size(95, 23);
            this.SaveQuote.TabIndex = 8;
            this.SaveQuote.Text = "Save Quote";
            this.SaveQuote.UseVisualStyleBackColor = true;
            this.SaveQuote.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowQuoteButton
            // 
            this.ShowQuoteButton.Location = new System.Drawing.Point(47, 222);
            this.ShowQuoteButton.Name = "ShowQuoteButton";
            this.ShowQuoteButton.Size = new System.Drawing.Size(107, 23);
            this.ShowQuoteButton.TabIndex = 7;
            this.ShowQuoteButton.Text = "Show Quote";
            this.ShowQuoteButton.UseVisualStyleBackColor = true;
            this.ShowQuoteButton.Click += new System.EventHandler(this.ShowQuoteButton_Click);
            // 
            // currentDate
            // 
            this.currentDate.AutoSize = true;
            this.currentDate.Location = new System.Drawing.Point(44, 19);
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(28, 13);
            this.currentDate.TabIndex = 0;
            this.currentDate.Text = "date";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rushDays
            // 
            this.rushDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rushDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rushDays.FormattingEnabled = true;
            this.rushDays.Items.AddRange(new object[] {
            "3",
            "5",
            "7"});
            this.rushDays.Location = new System.Drawing.Point(423, 32);
            this.rushDays.Name = "rushDays";
            this.rushDays.Size = new System.Drawing.Size(137, 28);
            this.rushDays.TabIndex = 0;
            this.rushDays.SelectedIndexChanged += new System.EventHandler(this.rushDays_SelectedIndexChanged);
            // 
            // AddQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 264);
            this.Controls.Add(this.rushDays);
            this.Controls.Add(this.currentDate);
            this.Controls.Add(this.SaveQuote);
            this.Controls.Add(this.TodayDate);
            this.Controls.Add(this.ShowQuoteButton);
            this.Controls.Add(this.rushDaysOptions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.material);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.drawers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.label1);
            this.Name = "AddQuote";
            this.Text = "AddQuote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TodayDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox drawers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox material;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rushDaysOptions;
        private System.Windows.Forms.Button ShowQuoteButton;
        private System.Windows.Forms.Button SaveQuote;
        private System.Windows.Forms.Label currentDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox rushDays;
    }
}