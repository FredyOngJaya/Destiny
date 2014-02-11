using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Destiny.Main;

namespace Destiny.Main.Data
{
    public partial class FormEnkripsi : Form
    {
        public FormEnkripsi()
        {
            InitializeComponent();
        }

        private void duplicateToLower()
        {
            textBoxOutputLower.Text = textBoxOutputUpper.Text.ToLower();
            labelLength.Text = "Panjang : " + textBoxOutputUpper.Text.Length;
        }

        private void buttonMD5_Click(object sender, EventArgs e)
        {
            textBoxOutputUpper.Text = ClassGlobal.GetMD5(textBoxInput.Text);
            duplicateToLower();
        }

        private void buttonSHA1_Click(object sender, EventArgs e)
        {
            textBoxOutputUpper.Text = ClassGlobal.GetSHA1(textBoxInput.Text);
            duplicateToLower();
        }

        private void buttonSHA256_Click(object sender, EventArgs e)
        {
            textBoxOutputUpper.Text = ClassGlobal.GetSHA256(textBoxInput.Text);
            duplicateToLower();
        }

        private void buttonSHA384_Click(object sender, EventArgs e)
        {
            textBoxOutputUpper.Text = ClassGlobal.GetSHA384(textBoxInput.Text);
            duplicateToLower();
        }

        private void buttonSHA512_Click(object sender, EventArgs e)
        {
            textBoxOutputUpper.Text = ClassGlobal.GetSHA512(textBoxInput.Text);
            duplicateToLower();
        }
    }
}
