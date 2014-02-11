using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Destiny.Main
{
    public class ClassDataGridViewVisibleScroll : DataGridView
    {
        public event EventHandler ScrollbarVisibleChanged;
        public ClassDataGridViewVisibleScroll()
        {
            this.VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
        }

        public bool VerticalScrollbarVisible
        {
            get { return VerticalScrollBar.Visible; }
        }

        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            EventHandler handler = ScrollbarVisibleChanged;
            if (handler != null) handler(this, e);
        }
    }
}
