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
using System.Resources;
using System.Diagnostics;

namespace Image_Secrets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.img32;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg; *.png; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = ofd.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ZIP Archive|*.zip|RAR Archive|*.rar";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                textBox2.Text = ofd.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image Files|*.jpg; *.png; *.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                textBox3.Text = sfd.FileName;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Random randnum = new Random();

            string image_path = textBox1.Text;
            string archive_path = textBox2.Text;

            if ((image_path != string.Empty) || (archive_path != string.Empty) || (textBox3.Text != string.Empty))
            {
                System.Diagnostics.Process.Start("cmd", "/c copy /b " + image_path + " + " + archive_path + " " + textBox3.Text);

                Process.Start(Application.StartupPath);
                System.Threading.Thread.Sleep(1000);
                if (checkBox1.Checked == true)
                {

                    Process.Start(Application.StartupPath + "\\" + textBox3.Text + "_" + randnum);
                }
                else
                {
                    Process.Start(Application.StartupPath + "\\" + textBox3.Text);
                }
            }
            else
            {
                MessageBox.Show("No path!\nPlease enter path and file name!", "Image Secrets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Image Secrets", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                checkBox1.Checked = false;

            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
