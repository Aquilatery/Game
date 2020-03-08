using System;
using System.Windows.Forms;

namespace Game
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.continue_down;
        }

        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.continue_idle;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void PictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.quit_down;
        }

        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.quit_idle;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.settings_down;
        }

        private void PictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.settings_idle;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            using (Form2 Form2 = new Form2())
            {
                if (Form2.ShowDialog() == DialogResult.OK)
                {
                    Form2.Focus();
                    Form2.BringToFront();
                }
            }
        }
    }
}