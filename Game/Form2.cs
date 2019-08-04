using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static readonly string SGFOLDER = Application.StartupPath + "\\Settings";
        static readonly string SETTING1 = SGFOLDER + "\\Setting1.dll";
        static readonly string SETTING2 = SGFOLDER + "\\Setting2.dll";

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            AyarDosya();
        }

        private void PictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.back_down;
        }

        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.back_idle;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void PictureBox4_Click(object sender, EventArgs e)
        {
            StreamReader Oku = new StreamReader(SETTING1);
            string Durum = Oku.ReadLine();
            Oku.Close();
            if (Durum == "Y" || Durum == "N")
            {
                if (Durum == "Y")
                {
                    pictureBox4.Image = Properties.Resources.music_off;
                    StreamWriter Yaz = new StreamWriter(SETTING1);
                    Yaz.Write("N");
                    Yaz.Close();
                }
                else
                {
                    pictureBox4.Image = Properties.Resources.music_on;
                    StreamWriter Yaz = new StreamWriter(SETTING1);
                    Yaz.Write("Y");
                    Yaz.Close();
                }
            }
            else
            {
                File.Delete(SETTING1);
                pictureBox4.Image = Properties.Resources.music_on;
                StreamWriter Yaz = new StreamWriter(SETTING1);
                Yaz.Write("Y");
                Yaz.Close();
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            StreamReader Oku = new StreamReader(SETTING2);
            string Durum = Oku.ReadLine();
            Oku.Close();
            if (Durum == "Y" || Durum == "N")
            {
                if (Durum == "Y")
                {
                    pictureBox5.Image = Properties.Resources.sfx_off;
                    StreamWriter Yaz = new StreamWriter(SETTING2);
                    Yaz.Write("N");
                    Yaz.Close();
                }
                else
                {
                    pictureBox5.Image = Properties.Resources.sfx_on;
                    StreamWriter Yaz = new StreamWriter(SETTING2);
                    Yaz.Write("Y");
                    Yaz.Close();
                }
            }
            else
            {
                File.Delete(SETTING2);
                pictureBox5.Image = Properties.Resources.sfx_on;
                StreamWriter Yaz = new StreamWriter(SETTING2);
                Yaz.Write("Y");
                Yaz.Close();
            }
        }

        private void AyarDosya()
        {
            if (!Directory.Exists(SGFOLDER))
                Directory.CreateDirectory(SGFOLDER);
            if (!File.Exists(SETTING1))
            {
                StreamWriter Yaz = new StreamWriter(SETTING1);
                Yaz.Write("Y");
                Yaz.Close();
                pictureBox4.Image = Properties.Resources.music_on;
            }
            else
            {
                StreamReader Oku = new StreamReader(SETTING1);
                string Durum = Oku.ReadLine();
                Oku.Close();
                if (Durum == "Y" || Durum == "N")
                {
                    if (Durum == "Y")
                        pictureBox4.Image = Properties.Resources.music_on;
                    else
                        pictureBox4.Image = Properties.Resources.music_off;
                }
                else
                {
                    File.Delete(SETTING1);
                    pictureBox4.Image = Properties.Resources.music_on;
                    StreamWriter Yaz = new StreamWriter(SETTING1);
                    Yaz.Write("Y");
                    Yaz.Close();
                }
            }
            if (!File.Exists(SETTING2))
            {
                StreamWriter Yaz = new StreamWriter(SETTING2);
                Yaz.Write("Y");
                Yaz.Close();
                pictureBox5.Image = Properties.Resources.sfx_on;
            }
            else
            {
                StreamReader Oku = new StreamReader(SETTING2);
                string Durum = Oku.ReadLine();
                Oku.Close();
                if (Durum == "Y" || Durum == "N")
                {
                    if (Durum == "Y")
                        pictureBox5.Image = Properties.Resources.sfx_on;
                    else
                        pictureBox5.Image = Properties.Resources.sfx_off;
                }
                else
                {
                    File.Delete(SETTING2);
                    pictureBox5.Image = Properties.Resources.sfx_on;
                    StreamWriter Yaz = new StreamWriter(SETTING2);
                    Yaz.Write("Y");
                    Yaz.Close();
                }
            }
        }
    }
}
