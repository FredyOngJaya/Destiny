namespace Destiny.Main.Data
{
    partial class FormNPC
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
            this.buttonCheck = new System.Windows.Forms.Button();
            this.richTextBoxScript = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(12, 12);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 0;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            // 
            // richTextBoxScript
            // 
            this.richTextBoxScript.AcceptsTab = true;
            this.richTextBoxScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxScript.Location = new System.Drawing.Point(12, 41);
            this.richTextBoxScript.Name = "richTextBoxScript";
            this.richTextBoxScript.Size = new System.Drawing.Size(688, 368);
            this.richTextBoxScript.TabIndex = 1;
            this.richTextBoxScript.Text = "ASDFI";
            // 
            // FormNPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 421);
            this.Controls.Add(this.richTextBoxScript);
            this.Controls.Add(this.buttonCheck);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNPC";
            this.Text = "FormNPC";
            this.Load += new System.EventHandler(this.FormNPC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.RichTextBox richTextBoxScript;
    }
}