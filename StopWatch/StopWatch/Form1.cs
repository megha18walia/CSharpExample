using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        int hh;
        int mm;
        int ss;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            ss = ss + 1;
            if(ss > 59)
            {
                ss = 0;
                mm = mm + 1;
            }
            if(mm > 59)
            {
                mm = 0;
                hh = hh + 1;
            }
            label1.Text = $"{hh} : {mm} : {ss}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hh = 0;
            mm = 0;
            ss = 0;
            label1.Text = $"{hh} : {mm} : {ss}";
        }
    }
}
