using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Destiny.Main;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

namespace Destiny.Main.Data
{
    public partial class FormItem : Form
    {
        NumberFormatInfo _numberInfo = NumberFormatInfo.CurrentInfo;
        NumberStyles _NumberStyle = NumberStyles.AllowDecimalPoint;
        CultureInfo _Culture = CultureInfo.CreateSpecificCulture("en-US");

        public string result { get; set; }

        public FormItem()
        {
            InitializeComponent();
            this.result = "";
        }

        public FormItem(int ItemID, string ItemName, int Slot, int ViewID)
        {
            InitializeComponent();
            this.result = "";
            numericUpDownID.Value = ItemID;
            textBoxNameEnglish.Text = ItemName;
            textBoxType.Text = "5";
            textBoxPriceBuy.Text = "20";
            textBoxWeightReal.Text = "50";
            numericUpDownRange.Value = -1;
            numericUpDownSlot.Value = Slot;
            textBoxJob.Text = "0xFFFFFFFF";
            numericUpDownWeaponLevel.Value = -1;
            numericUpDownView.Value = ViewID;
        }

        private void FormItem_Load(object sender, EventArgs e)
        {
            UncheckAllCheckBox();
            comboBoxGender.SelectedIndex = 2;
            numericUpDownRange.Value = -1;
        }

        private void classDataGridViewVisibleScroll_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                if (int.Parse(e.CellValue1.ToString()) > int.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = 1;
                }
                else if (int.Parse(e.CellValue1.ToString()) < int.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
                e.Handled = true;
            }
        }

        #region "event"

        private void UncheckAllCheckBox()
        {
            foreach (TabPage _tabPage in this.Controls["tabControlScript"].Controls)
            {
                foreach (var _var in _tabPage.Controls)
                {
                    if (_var is CheckBox)
                        ((CheckBox)_var).Checked = false;
                }
            }
        }

        private void checkedListBoxUpper_Enter(object sender, EventArgs e)
        {
            checkedListBoxUpper.Size = new Size(275, 76);
        }

        private void checkedListBoxUpper_Leave(object sender, EventArgs e)
        {
            checkedListBoxUpper.Size = new Size(150, 22);
        }

        private void textBoxWeightReal_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^1?[0-9]{0,3}(";
            pattern += Regex.Escape(_numberInfo.CurrencyDecimalSeparator);
            pattern += @"[0-9]?)?$";
            Regex _regex = new Regex(pattern);
            if (_regex.IsMatch(textBoxWeightReal.Text) || textBoxWeightReal.Text.Equals(""))
            {
                double weight;
                double.TryParse(textBoxWeightReal.Text, _NumberStyle, _Culture, out weight);
                textBoxWeightData.Text = (weight * 10).ToString();
            }
            else
            {
                textBoxWeightData.Clear();
            }
        }

        private void textBoxNameEnglish_TextChanged(object sender, EventArgs e)
        {
            textBoxNameJapanese.Text = textBoxNameEnglish.Text.Replace('_', ' ');
        }

        private void buttonIncrease_Click(object sender, EventArgs e)
        {
            ((NumericUpDown)this.Controls["numericUpDown" + ((Button)sender).Name.Replace("buttonIncrease", "")]).UpButton();
        }

        #endregion

        #region "Pop-Up"

        private void textBoxType_Click(object sender, EventArgs e)
        {
            FormItemType _form = new FormItemType();
            _form.ShowDialog();
            if (_form.result != -1)
                textBoxType.Text = _form.result.ToString();
            _form.Dispose();
        }

        private void textBoxJob_Click(object sender, EventArgs e)
        {
            FormItemJob _form = new FormItemJob();
            _form.ShowDialog();
            if (_form.result != null)
                textBoxJob.Text = _form.result;
            _form.Dispose();
        }

        private void textBoxLocation_Click(object sender, EventArgs e)
        {
            FormItemLocation _form = new FormItemLocation();
            _form.ShowDialog();
            if (_form.result != -1)
                textBoxLocation.Text = _form.result.ToString();
            _form.Dispose();
        }

        #endregion

        #region "Message Box"

        private void ErrorMessage(Exception _exception)
        {
            MessageBox.Show(_exception.Message.ToString(), "Error Detected");
        }

        private void InformationMessage(string message)
        {
            MessageBox.Show(message, "Information");
        }

        #endregion

        #region "Add Edit Delete"

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Button _button = (Button)sender;
                string _currentBonus = _button.Name.Replace("buttonAdd", "");
                TabControl _tabControl = (TabControl)this.Controls["tabControlScript"];
                foreach (TabPage _tabPage in _tabControl.Controls)
                {
                    if (_tabPage.Controls[_button.Name] != null)
                    {
                        ComboBox _comboBox = (ComboBox)_tabPage.Controls["comboBox" + _currentBonus.Substring(8) + _currentBonus];
                        TextBox _textBox = (TextBox)_tabPage.Controls["textBoxPercent" + _currentBonus];
                        string _pattern = @"^1?[0-9]{0,2}$";
                        Regex _regex = new Regex(_pattern);
                        if (_comboBox.SelectedIndex == -1)
                        {
                            InformationMessage("Choose " + _currentBonus.Substring(8));
                        }
                        else if (!_regex.IsMatch(_textBox.Text) || _textBox.Text.Equals("") || _textBox.Text.Equals("0") || _textBox.Text.Equals("00"))
                        {
                            InformationMessage("Percent value not valid");
                        }
                        else
                        {
                            DataGridView _dataGridView = (DataGridView)_tabPage.Controls["classDataGridViewVisibleScroll" + _currentBonus];
                            for (int i = 0; i < _dataGridView.Rows.Count; i++)
                                if (_dataGridView.Rows[i].Cells[1].Value.ToString() == _comboBox.SelectedItem.ToString())
                                {
                                    _dataGridView.Rows[i].Cells[2].Value = _textBox.Text;
                                    return;
                                }
                            _dataGridView.Rows.Add(new string[] { _comboBox.SelectedIndex.ToString(), _comboBox.SelectedItem.ToString(), _textBox.Text });
                            _dataGridView.Sort(_dataGridView.Columns[0], ListSortDirection.Ascending);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button _button = (Button)sender;
                string _currentBonus = _button.Name.Replace("buttonEdit", "");
                TabControl _tabControl = (TabControl)this.Controls["tabControlScript"];
                foreach (TabPage _tabPage in _tabControl.Controls)
                {
                    if (_tabPage.Controls[_button.Name] != null)
                    {
                        DataGridView _dataGridView = (DataGridView)_tabPage.Controls["classDataGridViewVisibleScroll" + _currentBonus];
                        if (_dataGridView.SelectedRows.Count > 0)
                        {
                            DataGridViewRow _selectedRow = _dataGridView.SelectedRows[0];
                            ((ComboBox)_tabPage.Controls["comboBox" + _currentBonus.Substring(8) + _currentBonus]).Text = _selectedRow.Cells[0].Value.ToString();
                            ((TextBox)_tabPage.Controls["textBoxPercent" + _currentBonus]).Text = _selectedRow.Cells[1].Value.ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button _button = (Button)sender;
                string _currentBonus = _button.Name.Replace("buttonDelete", "");
                TabControl _tabControl = (TabControl)this.Controls["tabControlScript"];
                foreach (TabPage _tabPage in _tabControl.Controls)
                {
                    if (_tabPage.Controls[_button.Name] != null)
                    {
                        DataGridView _dataGridView = (DataGridView)_tabPage.Controls["classDataGridViewVisibleScroll" + _currentBonus];
                        if (_dataGridView.SelectedRows.Count > 0)
                            _dataGridView.Rows.Remove(_dataGridView.SelectedRows[0]);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        #endregion

        #region "checkBox CheckedChanged"

        private void checkBoxType1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox _checkBox = (CheckBox)sender;
                string _currentBonus = _checkBox.Name.Replace("checkBox", "");
                TabControl _tabControl = (TabControl)this.Controls["tabControlScript"];
                TabPage _tabPage = (TabPage)_tabControl.Controls["tabPageBasic"];
                ((TextBox)_tabPage.Controls["textBox" + _currentBonus]).Enabled = _checkBox.Checked;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        private void checkBoxType2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox _checkBox = (CheckBox)sender;
                string _currentBonus = _checkBox.Name.Replace("checkBox", "");
                TabControl _tabControl = (TabControl)this.Controls["tabControlScript"];
                foreach (TabPage _tabPage in _tabControl.Controls)
                {
                    if (_tabPage.Controls[_checkBox.Name] != null)
                    {
                        bool value = _checkBox.Checked;
                        ((ComboBox)_tabPage.Controls["comboBox" + _currentBonus.Substring(8) + _currentBonus]).Enabled = value;
                        ((TextBox)_tabPage.Controls["textBoxPercent" + _currentBonus]).Enabled = value;
                        ((Button)_tabPage.Controls["buttonAdd" + _currentBonus]).Enabled = value;
                        ((Button)_tabPage.Controls["buttonEdit" + _currentBonus]).Enabled = value;
                        ((Button)_tabPage.Controls["buttonDelete" + _currentBonus]).Enabled = value;
                        ((ClassDataGridViewVisibleScroll)_tabPage.Controls["classDataGridViewVisibleScroll" + _currentBonus]).Enabled = value;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        #endregion

        #region "script"

        private void buttonGenerateScript_Click(object sender, EventArgs e)
        {
            try
            {
                string _script = "";
                int _upper = 0;
                foreach (int _list in checkedListBoxUpper.CheckedIndices)
                {
                    if (_list == 4)
                        _upper = (1 << _list);
                    else
                        _upper += (1 << _list);
                }
                _script = _script + numericUpDownID.Value.ToString() + ",";
                _script = _script + textBoxNameEnglish.Text + ",";
                _script = _script + textBoxNameJapanese.Text + ",";
                _script = _script + textBoxType.Text + ",";
                _script = _script + textBoxPriceBuy.Text + ",";
                _script = _script + textBoxPriceSell.Text + ",";
                _script = _script + textBoxWeightData.Text + ",";
                _script = _script + textBoxAttack.Text + ",";
                _script = _script + textBoxDefence.Text + ",";
                if (numericUpDownRange.Value > -1) _script = _script + numericUpDownRange.Value.ToString();
                _script = _script + ",";
                _script = _script + numericUpDownSlot.Value.ToString() + ",";
                _script = _script + textBoxJob.Text + ",";
                _script = _script + _upper.ToString() + ",";
                _script = _script + comboBoxGender.SelectedIndex.ToString() + ",";
                _script = _script + textBoxLocation.Text + ",";
                if (numericUpDownWeaponLevel.Value > -1) _script = _script + numericUpDownWeaponLevel.Value.ToString();
                _script = _script + ",";
                _script = _script + textBoxEquipLevel.Text + ",";
                if (checkBoxRefineable.Checked) _script = _script + "1";
                _script = _script + ",";
                if (numericUpDownView.Value > -1) _script = _script + numericUpDownView.Value.ToString();
                _script = _script + ",{";

                //on equip script
                TabPage _tabPageBasic = (TabPage)this.Controls["tabControlScript"].Controls["tabPageBasic"];
                TabPage _tabPageAddReduceDamage = (TabPage)this.Controls["tabControlScript"].Controls["tabPageAddReduceDamage"];
                TabPage _tabPageEffect = (TabPage)this.Controls["tabControlScript"].Controls["tabPageEffect"];

                _script += GetScriptType1FromTab(_tabPageBasic);
                _script += GetScriptType2FromTab(_tabPageAddReduceDamage);
                _script += GetScriptType2FromTab(_tabPageEffect);

                //end script
                if (!_script.EndsWith("{"))
                    _script += " ";
                _script += "},{},{}";

                textBoxScript.Text = _script;
                result = _script;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        private string GetScriptType1FromTab(TabPage _tabPage)
        {
            string _result = "";
            string _currentBonus;
            Stack _stack = new Stack();
            foreach (var _var in _tabPage.Controls)
            {
                if (_var is CheckBox)
                {
                    CheckBox _checkBox = (CheckBox)_var;
                    if (_checkBox.Checked)
                    {
                        _currentBonus = _checkBox.Name.Replace("checkBox", "");
                        _stack.Push(" " + _checkBox.Tag.ToString() + "," + ((TextBox)_tabPage.Controls["textBox" + _currentBonus]).Text + ";");
                    }
                }
            }
            while (_stack.Count > 0)
            {
                _result += _stack.Pop();
            }
            return _result;
        }

        private string GetScriptType2FromTab(TabPage _tabPage)
        {
            string _result = "";
            string _currentBonus;
            string _scriptBonus;
            Stack _stack = new Stack();
            foreach (var _var in _tabPage.Controls)
            {
                if (_var is CheckBox)
                {
                    CheckBox _checkBox = (CheckBox)_var;
                    if (_checkBox.Checked)
                    {
                        _currentBonus = _checkBox.Name.Replace("checkBox", "");
                        DataGridView _dataGridView = (DataGridView)
                            _tabPage.Controls["classDataGridViewVisibleScroll" + _currentBonus];
                        _scriptBonus = _checkBox.Tag.ToString();
                        _result = "";
                        foreach (DataGridViewRow _row in _dataGridView.Rows)
                        {
                            _result += " " + _scriptBonus + "," + _row.Cells[1].Value.ToString() + "," + _row.Cells[2].Value.ToString() + ";";
                        }
                        _stack.Push(_result);
                    }
                }
            }
            _result = "";
            while (_stack.Count > 0)
            {
                _result += _stack.Pop();
            }
            return _result;
        }

        #endregion
    }
}
