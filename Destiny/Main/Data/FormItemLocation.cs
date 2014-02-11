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
    public partial class FormItemLocation : Form
    {
        public int result { get; set; }

        public FormItemLocation()
        {
            InitializeComponent();
            this.result = -1;
            radioButtonHeadgear_CheckedChanged(null, null);
            radioButtonWeapon_CheckedChanged(null, null);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.result = 0;
            if (radioButtonHeadgear.Checked)
            {
                foreach (var _var in panelHeadgear.Controls)
                {
                    if (((CheckBox)_var).Checked)
                    {
                        this.result = this.result | int.Parse(((CheckBox)_var).Tag.ToString());
                    }
                }
            }
            else if (radioButtonWeapon.Checked)
            {
                foreach (var _var in panelWeapon.Controls)
                {
                    if (((RadioButton)_var).Checked)
                    {
                        this.result = this.result | int.Parse(((RadioButton)_var).Tag.ToString());
                    }
                }
            }
            else
            {
                foreach (var _var in this.Controls)
                {
                    if (_var is RadioButton)
                    {
                        if (((RadioButton)_var).Checked)
                        {
                            this.result = this.result | int.Parse(((RadioButton)_var).Tag.ToString());
                        }
                    }
                }
            }
            this.Close();
        }

        private void radioButtonHeadgear_CheckedChanged(object sender, EventArgs e)
        {
            panelHeadgear.Enabled = radioButtonHeadgear.Checked;
            if (!panelHeadgear.Enabled)
            {
                checkBoxUpper.Checked = false;
                checkBoxMiddle.Checked = false;
                checkBoxLower.Checked = false;
            }
        }

        private void radioButtonWeapon_CheckedChanged(object sender, EventArgs e)
        {
            panelWeapon.Enabled = radioButtonWeapon.Checked;
            if (!panelWeapon.Enabled)
            {
                radioButtonOneHand.Checked = false;
                radioButtonTwoHand.Checked = false;
            }
        }
    }
}
