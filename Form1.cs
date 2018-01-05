using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication9
{
 xcv
  




    public partial class Form1 : Form
    {







        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);





        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            linkLabel1.Links.Add(0, 10, "www");

            this.KeyPreview = true;
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);



        }





        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                button1.PerformClick();

            }
            if (keyData == (Keys.Control | Keys.A))
            {
                button2.PerformClick();

            }
            if (keyData == (Keys.Enter))
            {
                button2.PerformClick();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }




        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }













        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Enabled = true;
            this.BackColor = System.Drawing.Color.DarkRed;
































        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Enabled = true;
            this.BackColor = System.Drawing.Color.Black;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 5);


            if (checkBox2.Checked)
            {
                if (num == 1)
                {
                       
                    label9.Visible = true;

                    label10.Visible = false;
                    label11.Visible = false; 
                    label12.Visible = false;


                    SendKeys.Send(textBox1.Text);
                    if (checkBox1.Checked == true)
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 10, 20, 0, 0);
                    }
                    SendKeys.Send("{ENTER}");



                }

            }else
            {
               
            }









            if (checkBox3.Checked)
            {
                if (num == 2)
                {
                label10.Visible = true;

                label9.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                SendKeys.Send(textBox2.Text);
                if (checkBox1.Checked == true) {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 10, 20, 0, 0);
                }
                SendKeys.Send("{ENTER}");



            }


            }
            else
            {

            }










            if (checkBox4.Checked)
            {


                if (num == 3)
            {

                label11.Visible = true;

                label12.Visible = false;
                label10.Visible = false;
                label9.Visible = false;
                SendKeys.Send(textBox3.Text);
                if (checkBox1.Checked == true)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 10, 20, 0, 0);
                }
                SendKeys.Send("{ENTER}");

            }



            }
            else
            {

            }








            if (checkBox5.Checked)
            {



                if (num == 4)
            {
                label12.Visible = true;

                label10.Visible = false;
                label11.Visible = false;
                label9.Visible = false;
                SendKeys.Send(textBox4.Text);
                if (checkBox1.Checked == true)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 10, 20, 0, 0);
                }
                SendKeys.Send("{ENTER}");


            }




            }
            else
            {

            }









    }

    

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(numericUpDown1.Value * 1000);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { textBox1.Enabled = true; textBox1.BackColor = System.Drawing.Color.YellowGreen; }
            if (checkBox3.Checked) { textBox2.Enabled = true; textBox2.BackColor = System.Drawing.Color.YellowGreen; }
            if (checkBox4.Checked) { textBox3.Enabled = true; textBox3.BackColor = System.Drawing.Color.YellowGreen; }
            if (checkBox5.Checked) { textBox4.Enabled = true; textBox4.BackColor = System.Drawing.Color.YellowGreen; }
            //////////////
            if (!checkBox2.Checked) { textBox1.Enabled = false; textBox1.BackColor = System.Drawing.Color.Black; }
            if (!checkBox3.Checked) { textBox2.Enabled = false; textBox2.BackColor = System.Drawing.Color.Black; }
            if (!checkBox4.Checked) { textBox3.Enabled = false; textBox3.BackColor = System.Drawing.Color.Black; }
            if (!checkBox5.Checked) { textBox4.Enabled = false; textBox4.BackColor = System.Drawing.Color.Black; }

        }

        private void button3_Click(object sender, EventArgs e)
        {
   

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
         
         
            button1.Enabled = true;
        





































        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    }

