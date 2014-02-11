using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Destiny.Main
{
    public partial class MDIDestiny : Form
    {
        public MDIDestiny()
        {
            InitializeComponent();
        }

        private void _newChildForm(Form _form)
        {
            _form.MdiParent = this;
            _form.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newChildForm(new Config.FormConfiguration());
        }

        private void nPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newChildForm(new Data.FormNPC());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enkripsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newChildForm(new Data.FormEnkripsi());
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newChildForm(new Data.FormItem());
        }

        private void itemGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _newChildForm(new Data.FormItemPatchGenerator());
        }
    }
}
