using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private static bool DEVAM = false;
        private static int SAYIM = 3;
        private int Oyuncu1X;
        private int Oyuncu1Y;
        private int Oyuncu2X;
        private int Oyuncu2Y;

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Oyuncu1X = pictureBox1.Location.X;
            Oyuncu1Y = pictureBox1.Location.Y;
            Oyuncu2X = pictureBox2.Location.X;
            Oyuncu2Y = pictureBox2.Location.Y;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (SAYIM == 0)
            {
                SAYIM = 3;
                label1.Text = "0";
                timer1.Enabled = false;
                timer3.Enabled = true;
                pictureBox4.Cursor = Cursors.Hand;
            }
            else
            {
                label1.Text = SAYIM.ToString();
                SAYIM--;
            }
        }

        private void PictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (DEVAM == true)
            {
                pictureBox4.Image = Properties.Resources.pause_down;
            }
        }

        private void PictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (DEVAM == true)
            {
                pictureBox4.Image = Properties.Resources.pause_idle;
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (DEVAM == true)
            {
                DEVAM = false;
                pictureBox4.Cursor = Cursors.No;
                label1.Text = "3";
                label1.Visible = true;
                using (Form4 Form4 = new Form4())
                {
                    if (Form4.ShowDialog() == DialogResult.OK)
                    {
                        Form4.Focus();
                        Form4.BringToFront();
                    }
                    else
                    {
                        pictureBox4.Image = Properties.Resources.pause_idle;
                        timer1.Enabled = true;
                    }
                }
            }
        }

        private readonly int ABIG = 40;
        private readonly bool P1Null = false;
        private bool P1Null2 = false;
        private bool P1WalkR = true;
        private bool P1WalkR2 = true;
        private bool P1WalkL = false;
        private bool P1WalkL2 = false;
        private bool P1AttackR = false;
        private bool P1AttackL = false;

        //int P1Can = 100;

        private readonly bool P2Null = false;
        private bool P2Null2 = false;
        private bool P2WalkR = false;
        private bool P2WalkR2 = false;
        private bool P2WalkL = true;
        private bool P2WalkL2 = true;
        private bool P2AttackR = false;
        private bool P2AttackL = false;
        //int P2Can = 100;

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (DEVAM == true)
            {
                if (P1AttackR == false && P1AttackL == false)
                {
                    if (P1Null == false && P1Null2 == false)
                    {
                        P1Null2 = true;
                        pictureBox1.Image = Properties.Resources.IdleR;
                    }

                    if (P1WalkR == true && P1WalkR2 == false)
                    {
                        P1WalkR2 = true;
                        pictureBox1.Image = Properties.Resources.WalkR;
                    }

                    if (P1WalkL == true && P1WalkL2 == false)
                    {
                        P1WalkL2 = true;
                        pictureBox1.Image = Properties.Resources.WalkL;
                    }
                }
                else
                {
                    pictureBox2.BringToFront();
                    pictureBox1.Size = new Size(pictureBox1.Size.Width + (ABIG * 2), pictureBox1.Size.Height + ABIG);
                    if (P1AttackR == true)
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - ABIG);
                        pictureBox1.Image = Properties.Resources.AtackR;
                    }
                    else
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X - (ABIG * 2), pictureBox1.Location.Y - ABIG);
                        pictureBox1.Image = Properties.Resources.AtackL;
                    }
                    P1AttackR = false;
                    P1AttackL = false;
                    timer4.Enabled = true;
                }

                if (P2AttackR == false && P2AttackL == false)
                {
                    if (P2Null == false && P2Null2 == false)
                    {
                        P2Null2 = true;
                        pictureBox2.Image = Properties.Resources.IdleL;
                    }

                    if (P2WalkR == true && P2WalkR2 == false)
                    {
                        P2WalkR2 = true;
                        pictureBox2.Image = Properties.Resources.WalkR;
                    }

                    if (P2WalkL == true && P2WalkL2 == false)
                    {
                        P2WalkL2 = true;
                        pictureBox2.Image = Properties.Resources.WalkL;
                    }
                }
                else
                {
                    pictureBox1.BringToFront();
                    pictureBox2.Size = new Size(pictureBox2.Size.Width + (ABIG * 2), pictureBox2.Size.Height + ABIG);
                    if (P2AttackR == true)
                    {
                        pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - ABIG);
                        pictureBox2.Image = Properties.Resources.AtackR;
                    }
                    else
                    {
                        pictureBox2.Location = new Point(pictureBox2.Location.X - (ABIG * 2), pictureBox2.Location.Y - ABIG);
                        pictureBox2.Image = Properties.Resources.AtackL;
                    }
                    P2AttackR = false;
                    P2AttackL = false;
                    timer5.Enabled = true;
                }
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Visible == false)
            {
                timer3.Interval = 1000;
                pictureBox3.Visible = true;
            }
            else
            {
                DEVAM = true;
                pictureBox3.Visible = false;
                label1.Visible = false;
                timer3.Enabled = false;
                timer3.Interval = 1;
                timer2.Enabled = true;
            }
        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (DEVAM == true)
            {
                Klavye(e.KeyChar.ToString());
            }*/
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (DEVAM == true)
            {
                Klavye(e.KeyCode.ToString());
            }
        }

        private void Form3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            //MessageBox.Show(e.KeyData.ToString());
            //MessageBox.Show(e.KeyValue.ToString()); //ASCII
            if (DEVAM == true)
            {
                Klavye(e.KeyCode.ToString());
            }
        }

        private void Klavye(string Tus)
        {
            if (Tus == "D" || Tus == "d")
            {
                Oyuncu1(1);
            }
            else if (Tus == "A" || Tus == "a")
            {
                Oyuncu1(2);
            }
            else if (Tus == "B" || Tus == "b")
            {
                Oyuncu1(3);
            }

            if (Tus == "Left" || Tus == "NumPad4")
            {
                Oyuncu2(1);
            }
            else if (Tus == "Right" || Tus == "NumPad6")
            {
                Oyuncu2(2);
            }
            else if (Tus == "NumPad0")
            {
                Oyuncu2(3);
            }
        }

        private void Oyuncu1(int Job)
        {
            if (DEVAM == true)
            {
                if (Job == 1)
                {
                    //D
                    if (timer4.Enabled == false)
                    {
                        if (pictureBox1.Location.X != Oyuncu2X && (pictureBox1.Location.X + pictureBox1.Width) < pictureBox2.Location.X)
                        {
                            P1WalkR = true;
                            P1WalkL = false;
                            P1WalkL2 = false;
                            pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y);
                        }
                        else
                        {
                            if (P1WalkR == true)
                            {
                                P1WalkR = false;
                                pictureBox1.Image = Properties.Resources.IdleR;
                            }
                        }
                    }
                }
                else if (Job == 2)
                {
                    //A
                    if (timer4.Enabled == false)
                    {
                        if (pictureBox1.Location.X != Oyuncu1X)
                        {
                            P1WalkR = false;
                            P1WalkL = true;
                            P1WalkR2 = false;
                            pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y);
                        }
                        else
                        {
                            if (P1WalkL == true)
                            {
                                P1WalkL = false;
                                pictureBox1.Image = Properties.Resources.IdleL;
                            }
                        }
                    }
                }
                else if (Job == 3)
                {
                    //B
                    if (timer4.Enabled == false)
                    {
                        if (P1WalkL == true)
                        {
                            P1AttackL = true;
                        }
                        else
                        {
                            P1AttackR = true;
                        }
                    }
                }
            }
        }

        private void Oyuncu2(int Job)
        {
            if (DEVAM == true)
            {
                if (Job == 1)
                {
                    //Left
                    if (timer5.Enabled == false)
                    {
                        if (pictureBox2.Location.X != Oyuncu1X && pictureBox2.Location.X > (pictureBox1.Location.X + pictureBox1.Width))
                        {
                            P2WalkR = false;
                            P2WalkL = true;
                            P2WalkR2 = false;
                            pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
                        }
                        else
                        {
                            if (P2WalkL == true)
                            {
                                P2WalkL = false;
                                pictureBox2.Image = Properties.Resources.IdleL;
                            }
                        }
                    }
                }
                else if (Job == 2)
                {
                    //Right
                    if (timer5.Enabled == false)
                    {
                        if (pictureBox2.Location.X != Oyuncu2X)
                        {
                            P2WalkR = true;
                            P2WalkL = false;
                            P2WalkL2 = false;
                            pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
                        }
                        else
                        {
                            if (P2WalkR == true)
                            {
                                P2WalkR = false;
                                pictureBox2.Image = Properties.Resources.IdleR;
                            }
                        }
                    }
                }
                else if (Job == 3)
                {
                    //NumPad0
                    if (timer5.Enabled == false)
                    {
                        if (P2WalkR == true)
                        {
                            P2AttackR = true;
                        }
                        else
                        {
                            P2AttackL = true;
                        }
                    }
                }
            }
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            if (P1WalkR == false && P1WalkL == false)
            {
                pictureBox1.Image = Properties.Resources.IdleR;
            }
            else
            {
                if (P1WalkR == true)
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
                    pictureBox1.Image = Properties.Resources.IdleR;
                }
                else
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X + (ABIG * 2), pictureBox1.Location.Y);
                    pictureBox1.Image = Properties.Resources.IdleL;
                }
            }
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + ABIG);
            pictureBox1.Size = new Size(pictureBox1.Size.Width - (ABIG * 2), pictureBox1.Size.Height - ABIG);
            timer4.Enabled = false;
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            if (P2WalkR == false && P2WalkL == false)
            {
                pictureBox2.Image = Properties.Resources.IdleL;
            }
            else
            {
                if (P2WalkR == true)
                {
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y);
                    pictureBox2.Image = Properties.Resources.IdleR;
                }
                else
                {
                    pictureBox2.Location = new Point(pictureBox2.Location.X + (ABIG * 2), pictureBox2.Location.Y);
                    pictureBox2.Image = Properties.Resources.IdleL;
                }
            }
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + ABIG);
            pictureBox2.Size = new Size(pictureBox2.Size.Width - (ABIG * 2), pictureBox2.Size.Height - ABIG);
            timer5.Enabled = false;
        }
    }
}
