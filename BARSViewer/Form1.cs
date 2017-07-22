using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BARSViewer
{
    public partial class Form1 : Form
    {
        public BMETA bmta = new BMETA();
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmta = new BMETA();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "") return;
            else bmta.load(openFileDialog1.FileName);

            listBox1.Items.Clear();
            button1.Enabled = true;

            for (int i = 0; i < bmta.strgList.Count; i++)
            {
                listBox1.Items.Add(new string(bmta.strgList[i].fwavName));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bmta.unpack(openFileDialog1.FileName.Replace(".bars", ""));
            MessageBox.Show("Done.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BARS Viewer 0.1 by MasterF0x", "About");
        }
    }
}
