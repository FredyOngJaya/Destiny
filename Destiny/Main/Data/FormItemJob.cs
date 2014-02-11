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
    public partial class FormItemJob : Form
    {
        public string result { get; set; }

        public FormItemJob()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint _value = 0;
            if (checkBoxAllJob.Checked)
            {
                _value = uint.Parse(checkBoxAllJob.Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            else if (checkBoxAllJobExceptNovice.Checked)
            {
                _value = uint.Parse(checkBoxAllJobExceptNovice.Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                foreach (var _var in this.Controls)
                {
                    if (_var is CheckBox)
                    {
                        if (((CheckBox)_var).Checked)
                            _value += uint.Parse(((CheckBox)_var).Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            string _hex = _value.ToString("X");
            ((Button)sender).Text = "0x" + ("00000000" + _hex).Substring(_hex.Length);
            this.result = "0x" + ("00000000" + _hex).Substring(_hex.Length);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            uint _value = 0;
            if (checkBoxAllJob.Checked)
            {
                _value = uint.Parse(checkBoxAllJob.Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            else if (checkBoxAllJobExceptNovice.Checked)
            {
                _value = uint.Parse(checkBoxAllJobExceptNovice.Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                foreach (var _var in this.Controls)
                {
                    if (_var is CheckBox)
                    {
                        if (((CheckBox)_var).Checked)
                            _value += uint.Parse(((CheckBox)_var).Tag.ToString().Substring(2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            string _hex = _value.ToString("X");
            this.result = "0x" + ("00000000" + _hex).Substring(_hex.Length);
            this.Close();
        }
    }
}
