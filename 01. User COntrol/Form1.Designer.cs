namespace _01.User_COntrol
{
    partial class Form1
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
            this.ctrlCalc1 = new _01.User_COntrol.ctrlCalc();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlCalc1
            // 
            this.ctrlCalc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCalc1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCalc1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlCalc1.Name = "ctrlCalc1";
            this.ctrlCalc1.Size = new System.Drawing.Size(910, 93);
            this.ctrlCalc1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(183, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Result";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlCalc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlCalc ctrlCalc1;
        private System.Windows.Forms.Button button1;
    }
}

