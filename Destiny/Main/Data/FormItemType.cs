using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Destiny.Main.Data
{
    public partial class FormItemType : Form
    {
        public int result { get; set; }

        public FormItemType()
        {
            InitializeComponent();
            this.result = -1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            foreach (var _var in this.Controls)
            {
                if (_var is RadioButton)
                {
                    if (((RadioButton)_var).Checked)
                    {
                        this.result = int.Parse(((RadioButton)_var).Tag.ToString());
                        break;
                    }
                }
            }
            this.Close();
        }
    }
}
