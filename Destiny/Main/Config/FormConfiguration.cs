using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Destiny.Main;
using System.IO;
using System.Collections;

namespace Destiny.Config
{
    public partial class FormConfiguration : Form
    {
        public FormConfiguration()
        {
            InitializeComponent();
        }

        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            if (File.Exists(ClassGlobal._confFile))
            {
                StreamReader _conf = new StreamReader(ClassGlobal._confFile);
                string _line;
                while (!_conf.EndOfStream)
                {
                    _line = _conf.ReadLine();
                    string[] _split = _line.Split(';');
                    this.Controls[_split[0]].Text = _split[1];
                }
                _conf.Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int itemID, viewID;
                if (int.TryParse(textBoxLastItemID.Text, out itemID) && int.TryParse(textBoxLastViewID.Text, out viewID))
                {
                    StreamWriter _file = new StreamWriter(ClassGlobal._confFile);
                    Stack _stack = new Stack();
                    foreach (Control _control in this.Controls)
                    {
                        if (_control is TextBox)
                        {
                            _stack.Push(((TextBox)_control).Name + ";" + ((TextBox)_control).Text);
                        }
                    }
                    while (_stack.Count > 0)
                        _file.WriteLine(_stack.Pop().ToString());
                    _file.Close();
                    MessageBox.Show("Saved.");
                }
                else
                {
                    MessageBox.Show("Item ID and View ID should be numbers.");
                }
                ClassGlobal.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
