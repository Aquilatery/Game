using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static readonly string SGFOLDER = Application.StartupPath + "\\Settings";
        static readonly string SETTING1 = SGFOLDER + "\\Setting1.dll";

        static Random Rastgele = new Random();
        static readonly string Music = Rastgele.Next(1, 3) + ".mp3";

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strKomut, StringBuilder sb, int rl, IntPtr iptr);

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.start_down;
        }

        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.start_idle;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            using (Form3 Form3 = new Form3())
            {
                if (Form3.ShowDialog() == DialogResult.OK)
                {
                    Form3.Focus();
                    Form3.BringToFront();
                }
            }
        }

        private void PictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.settings_down;
        }

        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.settings_idle;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
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

        private void PictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.quit_down;
        }

        private void PictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.quit_idle;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayMusic()
        {
            mciSendString("open \"" + Music + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
        }

        private void StopMusic()
        {
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);
        }

        private void AyarDosya()
        {
            if (!Directory.Exists(SGFOLDER))
                Directory.CreateDirectory(SGFOLDER);
            if (File.Exists(SETTING1))
            {

                StreamReader Oku = new StreamReader(SETTING1);
                string Durum = Oku.ReadLine();
                Oku.Close();
                if (Durum == "Y" || Durum == "N")
                {
                    if (Durum == "Y")
                        PlayMusic();
                    else
                        StopMusic();
                }
                else
                {
                    File.Delete(@SETTING1);
                    PlayMusic();
                    StreamWriter Yaz = new StreamWriter(SETTING1);
                    Yaz.Write("Y");
                    Yaz.Close();
                }
            }
            else
            {
                StreamWriter Yaz = new StreamWriter(SETTING1);
                Yaz.Write("Y");
                Yaz.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            AyarDosya();
        }
    }
}
