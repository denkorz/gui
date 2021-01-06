using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool blink = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void DoSomething_Click(object sender, EventArgs e)
        {
            blink = !blink;
            if (blink)
            {
                RunBlinking();
            }
        }

        private void RunBlinking()
        {
            new Thread(blinkingLogic).Start();

            async void blinkingLogic()
            {
                while (blink)
                {
                    ChangeTextSafe("Nice", TextField);
                    await Task.Delay(500);
                    ChangeTextSafe("Dick", TextField);
                    await Task.Delay(500);
                }
                ChangeTextSafe("Thread finished", TextField);
            }
        }

        private void ChangeTextSafe(string text, TextBox box)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new Action(() => ChangeTextSafe(text, box)));
            }
            else
            {
                box.Text = text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
