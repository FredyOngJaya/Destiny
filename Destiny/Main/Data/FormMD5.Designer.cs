namespace Destiny.Main.Data
{
    partial class FormEnkripsi
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
            this.buttonMD5 = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutputUpper = new System.Windows.Forms.TextBox();
            this.textBoxOutputLower = new System.Windows.Forms.TextBox();
            this.buttonSHA1 = new System.Windows.Forms.Button();
            this.buttonSHA256 = new System.Windows.Forms.Button();
            this.buttonSHA384 = new System.Windows.Forms.Button();
            this.buttonSHA512 = new System.Windows.Forms.Button();
            this.labelLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonMD5
            // 
            this.buttonMD5.Location = new System.Drawing.Point(13, 44);
            this.buttonMD5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMD5.Name = "buttonMD5";
            this.buttonMD5.Size = new System.Drawing.Size(74, 28);
            this.buttonMD5.TabIndex = 1;
            this.buttonMD5.Text = "MD5";
            this.buttonMD5.UseVisualStyleBackColor = true;
            this.buttonMD5.Click += new System.EventHandler(this.buttonMD5_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(13, 13);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(1066, 23);
            this.textBoxInput.TabIndex = 0;
            // 
            // textBoxOutputUpper
            // 
            this.textBoxOutputUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputUpper.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutputUpper.Location = new System.Drawing.Point(13, 80);
            this.textBoxOutputUpper.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOutputUpper.Name = "textBoxOutputUpper";
            this.textBoxOutputUpper.Size = new System.Drawing.Size(1066, 22);
            this.textBoxOutputUpper.TabIndex = 2;
            // 
            // textBoxOutputLower
            // 
            this.textBoxOutputLower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputLower.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutputLower.Location = new System.Drawing.Point(13, 111);
            this.textBoxOutputLower.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOutputLower.Name = "textBoxOutputLower";
            this.textBoxOutputLower.Size = new System.Drawing.Size(1066, 22);
            this.textBoxOutputLower.TabIndex = 3;
            // 
            // buttonSHA1
            // 
            this.buttonSHA1.Location = new System.Drawing.Point(95, 44);
            this.buttonSHA1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSHA1.Name = "buttonSHA1";
            this.buttonSHA1.Size = new System.Drawing.Size(74, 28);
            this.buttonSHA1.TabIndex = 4;
            this.buttonSHA1.Text = "SHA1";
            this.buttonSHA1.UseVisualStyleBackColor = true;
            this.buttonSHA1.Click += new System.EventHandler(this.buttonSHA1_Click);
            // 
            // buttonSHA256
            // 
            this.buttonSHA256.Location = new System.Drawing.Point(177, 44);
            this.buttonSHA256.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSHA256.Name = "buttonSHA256";
            this.buttonSHA256.Size = new System.Drawing.Size(74, 28);
            this.buttonSHA256.TabIndex = 5;
            this.buttonSHA256.Text = "SHA256";
            this.buttonSHA256.UseVisualStyleBackColor = true;
            this.buttonSHA256.Click += new System.EventHandler(this.buttonSHA256_Click);
            // 
            // buttonSHA384
            // 
            this.buttonSHA384.Location = new System.Drawing.Point(259, 44);
            this.buttonSHA384.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSHA384.Name = "buttonSHA384";
            this.buttonSHA384.Size = new System.Drawing.Size(74, 28);
            this.buttonSHA384.TabIndex = 6;
            this.buttonSHA384.Text = "SHA384";
            this.buttonSHA384.UseVisualStyleBackColor = true;
            this.buttonSHA384.Click += new System.EventHandler(this.buttonSHA384_Click);
            // 
            // buttonSHA512
            // 
            this.buttonSHA512.Location = new System.Drawing.Point(341, 44);
            this.buttonSHA512.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSHA512.Name = "buttonSHA512";
            this.buttonSHA512.Size = new System.Drawing.Size(74, 28);
            this.buttonSHA512.TabIndex = 7;
            this.buttonSHA512.Text = "SHA512";
            this.buttonSHA512.UseVisualStyleBackColor = true;
            this.buttonSHA512.Click += new System.EventHandler(this.buttonSHA512_Click);
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(10, 147);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(71, 16);
            this.labelLength.TabIndex = 8;
            this.labelLength.Text = "Panjang :";
            // 
            // FormEnkripsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 209);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.buttonSHA512);
            this.Controls.Add(this.buttonSHA384);
            this.Controls.Add(this.buttonSHA256);
            this.Controls.Add(this.buttonSHA1);
            this.Controls.Add(this.textBoxOutputLower);
            this.Controls.Add(this.textBoxOutputUpper);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonMD5);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEnkripsi";
            this.Text = "Cryptography";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMD5;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutputUpper;
        private System.Windows.Forms.TextBox textBoxOutputLower;
        private System.Windows.Forms.Button buttonSHA1;
        private System.Windows.Forms.Button buttonSHA256;
        private System.Windows.Forms.Button buttonSHA384;
        private System.Windows.Forms.Button buttonSHA512;
        private System.Windows.Forms.Label labelLength;
    }
}