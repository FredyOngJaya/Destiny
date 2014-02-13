using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Destiny.Main;

namespace Destiny.Main.Data
{
    public partial class FormItemPatchGenerator : Form
    {
        public FormItemPatchGenerator()
        {
            InitializeComponent();
        }

        private string toUnderScore(string var)
        {
            string result = var.Replace(' ', '_');
            return result;
        }

        private string toProperCase(string var)
        {
            string result = "";
            bool nextUpper = true;
            foreach (char c in var)
            {
                if (nextUpper)
                {
                    result += c.ToString().ToUpper();
                }
                else
                {
                    result += c.ToString();
                }
                if (c == ' ')
                    nextUpper = true;
            }
            return result;
        }

        private string CheckFile(string fileName, string fullPath, string baseName)
        {
            string newName = fileName;
            string _underscore = toUnderScore(baseName);
            if ((fileName.Contains("²") || fileName.Contains("³")) && !fileName.Contains("³²"))
            {
                newName = "³²" + fileName.Substring(2);
            }
            if ((fileName.Contains("¿") || fileName.Contains("©")) && !fileName.Contains("¿©"))
            {
                newName = "¿©" + fileName.Substring(2);
            }
            if (fullPath.Contains("Drop") || fullPath.Contains("Collection") || fullPath.Contains("Item"))
                newName = _underscore + newName.Substring(newName.LastIndexOf('.'));
            else
                newName = newName.Substring(0, 3) + _underscore + newName.Substring(newName.LastIndexOf('.'));
            if (fileName != newName)
                File.Move(fullPath + "\\" + fileName, fullPath + "\\" + newName);
            return newName;
        }

        private void AddChildNode(TreeNode parent, String lastPath, String baseName, bool check)
        {
            DirectoryInfo dir = new DirectoryInfo(lastPath);
            var _folder = dir.GetDirectories();
            var _file = dir.GetFiles();
            foreach (DirectoryInfo folder in _folder)
            {
                TreeNode now = new TreeNode(folder.Name.ToString());
                parent.Nodes.Add(now);
                AddChildNode(now, folder.FullName, baseName, check);
            }
            foreach (FileInfo file in _file)
            {
                TreeNode now = new TreeNode();
                if (check)
                    now.Text = CheckFile(file.Name.ToString(), lastPath, baseName);
                else
                    now.Text = file.Name.ToString();
                parent.Nodes.Add(now);
            }
        }

        private void loadData(bool check)
        {
            try
            {
                treeViewListData.Nodes.Clear();
                string path = textBoxPath.Text;
                DirectoryInfo dir = new DirectoryInfo(path);
                var _folder = dir.GetDirectories();
                var _file = dir.GetFiles();
                foreach (DirectoryInfo folder in _folder)
                {
                    TreeNode now = new TreeNode(folder.Name.ToString());
                    treeViewListData.Nodes.Add(now);
                    AddChildNode(now, folder.FullName, folder.Name, check);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadData(true);
        }

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            treeViewListData.ExpandAll();
        }

        private void buttonLoadDataNoCheck_Click(object sender, EventArgs e)
        {
            loadData(false);
        }

        private void moveDrop(string lastPath)
        {
            DirectoryInfo dir = new DirectoryInfo(lastPath);
            var _file = dir.GetFiles();
            foreach (FileInfo file in _file)
            {
                file.MoveTo(textBoxPathSPRDrop.Text + "\\" + file.Name);
            }
        }

        private void moveCollection(string lastPath)
        {
            DirectoryInfo dir = new DirectoryInfo(lastPath);
            var _file = dir.GetFiles();
            foreach (FileInfo file in _file)
            {
                file.MoveTo(textBoxPathItemCollection.Text + "\\" + file.Name);
            }
        }

        private void moveItems(string lastPath)
        {
            DirectoryInfo dir = new DirectoryInfo(lastPath);
            var _file = dir.GetFiles();
            foreach (FileInfo file in _file)
            {
                file.MoveTo(textBoxPathItemIcon.Text + "\\" + file.Name);
            }
        }

        private void moveSpr(string lastPath)
        {
            DirectoryInfo dir = new DirectoryInfo(lastPath);
            var _file = dir.GetFiles();
            foreach (FileInfo file in _file)
            {
                if (file.Name.Contains("¿©"))
                    file.MoveTo(textBoxPathSPRMan.Text + "\\" + file.Name);
                else
                    file.MoveTo(textBoxPathSPRWoman.Text + "\\" + file.Name);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBoxPath.Text;
                DirectoryInfo dir = new DirectoryInfo(path);
                var _folder = dir.GetDirectories();
                var _file = dir.GetFiles();
                foreach (DirectoryInfo folder in _folder)
                {
                    DirectoryInfo dir2 = new DirectoryInfo(folder.FullName);
                    var _folder2 = dir2.GetDirectories();
                    foreach (DirectoryInfo f in _folder2)
                    {
                        if (f.Name == "Collection")
                        {
                            moveCollection(f.FullName);
                        }
                        else if (f.Name == "Item")
                        {
                            moveItems(f.FullName);
                        }
                        else if (f.Name == "Drop")
                        {
                            moveDrop(f.FullName);
                        }
                    }
                    moveSpr(folder.FullName);
                }
                MessageBox.Show("Finish");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void buttonPrepareGrid_Click(object sender, EventArgs e)
        {
            int nextID, nextView;
            if (int.TryParse(textBoxLastID.Text, out nextID) && int.TryParse(textBoxLastView.Text, out nextView))
            {
                DirectoryInfo dir = new DirectoryInfo(textBoxPathSPRMan.Text);
                var _file = dir.GetFiles("*.spr");
                string spr_, spr;
                dataGridViewSPR.Rows.Clear();
                foreach (FileInfo file in _file)
                {
                    nextID++;
                    nextView++;

                    spr_ = file.Name.Substring(3, file.Name.LastIndexOf('.') - 3);
                    spr = spr_.Replace('_', ' ');

                    dataGridViewSPR.Rows.Add(new String[] { nextID.ToString(), spr, nextView.ToString() });
                }
            }
            else
            {
                MessageBox.Show("Input next Item ID Number");
            }
        }

        private void buttonGenerateScript_Click(object sender, EventArgs e)
        {
            if (dataGridViewSPR.Rows.Count > 0)
            {
                if (File.Exists(textBoxPathDataGRF.Text + "itemdb.txt"))
                    File.Delete(textBoxPathDataGRF.Text + "itemdb.txt");
                if (File.Exists(textBoxPathDataGRF.Text + "idnum2itemdesctable.txt"))
                    File.Delete(textBoxPathDataGRF.Text + "idnum2itemdesctable.txt");
                if (File.Exists(textBoxPathDataGRF.Text + "idnum2itemdisplaynametable.txt"))
                    File.Delete(textBoxPathDataGRF.Text + "idnum2itemdisplaynametable.txt");
                if (File.Exists(textBoxPathDataGRF.Text + "idnum2itemresnametable.txt"))
                    File.Delete(textBoxPathDataGRF.Text + "idnum2itemresnametable.txt");
                if (File.Exists(textBoxPathDataGRF.Text + "itemslotcounttable.txt"))
                    File.Delete(textBoxPathDataGRF.Text + "itemslotcounttable.txt");
                if (File.Exists(textBoxPathLUA.Text + "accessoryid.lua"))
                    File.Delete(textBoxPathLUA.Text + "accessoryid.lua");
                if (File.Exists(textBoxPathLUA.Text + "accname.lua"))
                    File.Delete(textBoxPathLUA.Text + "accname.lua");
                StreamWriter itemdb = new StreamWriter(textBoxPathDataGRF.Text + "itemdb.txt", true);
                StreamWriter itemdesctable = new StreamWriter(textBoxPathDataGRF.Text + "idnum2itemdesctable.txt", true);
                StreamWriter itemdisplaynametable = new StreamWriter(textBoxPathDataGRF.Text + "idnum2itemdisplaynametable.txt", true);
                StreamWriter itemrestable = new StreamWriter(textBoxPathDataGRF.Text + "idnum2itemresnametable.txt", true);
                StreamWriter itemslotcounttable = new StreamWriter(textBoxPathDataGRF.Text + "itemslotcounttable.txt", true);
                StreamWriter accname = new StreamWriter(textBoxPathLUA.Text + "accname.lua", true);
                StreamWriter accessoryid = new StreamWriter(textBoxPathLUA.Text + "accessoryid.lua", true);
                int nextID, nextView, slot;
                string spr_, spr, position, script;
                foreach (DataGridViewRow _row in dataGridViewSPR.Rows)
                {
                    nextID = int.Parse(_row.Cells["ID"].Value.ToString());
                    spr = _row.Cells["SPR"].Value.ToString();
                    spr_ = spr.Replace(' ', '_');
                    nextView = int.Parse(_row.Cells["View"].Value.ToString());
                    position = _row.Cells["Location"].Value.ToString();
                    slot = int.Parse(_row.Cells["Slot"].Value.ToString());
                    script = _row.Cells["Script"].Value.ToString();

                    itemdesctable.WriteLine(nextID.ToString() + "#");
                    itemdesctable.WriteLine(spr);
                    itemdesctable.WriteLine("Class :^777777 Headgear^000000");
                    itemdesctable.WriteLine("Defense :^777777 0^000000");
                    itemdesctable.WriteLine("Equipped on :^777777 " + position + "^000000");
                    itemdesctable.WriteLine("Weight :^777777 50^000000");
                    itemdesctable.WriteLine("Applicable Job :^777777 Every Job^000000");
                    itemdesctable.WriteLine("#");

                    itemdisplaynametable.WriteLine(nextID.ToString() + "#" + spr + "#");

                    itemrestable.WriteLine(nextID.ToString() + "#" + spr_ + "#");

                    itemslotcounttable.WriteLine(nextID.ToString() + "#" + slot + "#");

                    accname.WriteLine(",");
                    accname.Write("\t[ACCESSORY_IDs.ACCESSORY_" + spr_ + "] = \"_" + spr_ + "\"");

                    accessoryid.WriteLine(",");
                    accessoryid.Write("\tACCESSORY_" + spr_ + " = " + nextView);

                    itemdb.WriteLine(script);
                }
                itemdesctable.Close();
                itemdisplaynametable.Close();
                itemrestable.Close();
                itemslotcounttable.Close();
                accessoryid.Close();
                accname.Close();
                itemdb.Close();
                MessageBox.Show("Finish");
            }
            else
            {
                MessageBox.Show("No Row Data");
            }
        }

        private void dataGridViewSPR_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dataGridViewSPR.SelectedRows[0];
            int id = int.Parse(_row.Cells["ID"].Value.ToString());
            int view = int.Parse(_row.Cells["View"].Value.ToString());
            FormItem _form = new FormItem(id, toUnderScore(_row.Cells["SPR"].Value.ToString()), view);
            _form.ShowDialog();
            if (_form.result != "")
            {
                _row.Cells["Location"].Value = _form.position;
                _row.Cells["Slot"].Value = _form.slot;
                _row.Cells["Script"].Value = _form.result;
            }
            _form.Dispose();
        }

        private void FormItemPatchGenerator_Load(object sender, EventArgs e)
        {
            ClassGlobal.LoadData();
            textBoxLastID.Text = ClassGlobal._lastItemID.ToString();
            textBoxLastView.Text = ClassGlobal._lastViewID.ToString();
            textBoxPathDataGRF.Text = ClassGlobal._pathDataGRF;
            textBoxPathLUA.Text = ClassGlobal._pathLUA;
            textBoxPathSPRDrop.Text = ClassGlobal._pathSPRDrop;
            textBoxPathSPRMan.Text = ClassGlobal._pathSPRMan;
            textBoxPathSPRWoman.Text = ClassGlobal._pathSPRWoman;
            textBoxPathItemCollection.Text = ClassGlobal._pathItemCollection;
            textBoxPathItemIcon.Text = ClassGlobal._pathItemIcon;
        }

        private void buttonDeleteLastData_Click(object sender, EventArgs e)
        {
            deleteFileInFolder(textBoxPathSPRDrop.Text);
            deleteFileInFolder(textBoxPathSPRMan.Text);
            deleteFileInFolder(textBoxPathSPRWoman.Text);
            deleteFileInFolder(textBoxPathItemCollection.Text);
            deleteFileInFolder(textBoxPathItemIcon.Text);
            MessageBox.Show("Selesai");
        }

        private void deleteFileInFolder(string path)
        {
            DirectoryInfo _folder = new DirectoryInfo(path);
            foreach (FileInfo _file in _folder.GetFiles())
            {
                _file.Delete();
            }
        }
    }
}
