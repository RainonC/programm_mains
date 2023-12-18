using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Windows.Forms.VisualStyles;
using System.Data;

namespace labarator
{
    public partial class esimeneForm : Form
    {
        TreeView tree;
        Button btn, btn2;

        public object treeNode { get; }

        public esimeneForm(object treeNode)
        {
            this.Height = 600;
            this.Width = 1200;
            this.Text = "Vorm põhielementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            btn.MouseHover += button2_MouseHover;
            btn.Visible = false;
            this.treeNode = treeNode;
        }

        private void button2_MouseHover(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
