using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace DongHoBamGio
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Timers.Timer timer;
        int h, m, s, ms;

        PrivateFontCollection modernFont = new PrivateFontCollection();

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            timer.Stop();
            
            label1.Font = new Font(modernFont.Families[0], 60);
            label1.Text = "00:00:00:00";
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modernFont.AddFontFile(@"C:\Users\Admin\Documents\WebAPS\LCDM2B__.ttf");

            label1.Font = new Font(modernFont.Families[0], 60);
            btnstart.Font = new Font(modernFont.Families[0], 20);
            simpleButton1.Font = new Font(modernFont.Families[0], 20);
            simpleButton2.Font = new Font(modernFont.Families[0], 20);

            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ms += 1;
                if(ms == 100)
                {
                    ms = 0;
                    s += 1;
                }
                if(s == 60)
                {
                    ms = 0;
                    s += 1;
                }
                if(m == 60)
                {
                    m = 0;
                    h += 1;
                }

                label1.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().ToString().PadLeft(2, '0'), m.ToString().ToString().PadLeft(2, '0'), s.ToString().ToString().PadLeft(2, '0'), ms.ToString().ToString().PadLeft(2, '0'));

            }));
        }
    }
}
