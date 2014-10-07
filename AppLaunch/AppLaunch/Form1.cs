using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppLaunch
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        const int MAXIMIZE = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                    new System.Drawing.Drawing2D.GraphicsPath();
            path.AddRectangle(new Rectangle(0, 23, 155, 135));
            this.Region = new Region(path);
            this.Location = new Point(0, 50);
            this.TopMost = true;
            this.timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string prog = "MBScheduler";
            RunOrShow(prog);
            this.Close();
        }

        private void RunOrShow(string prog)
        {
            Process[] p = Process.GetProcessesByName(prog);
            if (p != null && p.Length > 0)
            {
                ShowWindow(p[0].MainWindowHandle, 3);
            }
            else
            {
                Process.Start(prog);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string prog = "ProgOpe";
            RunOrShow(prog);
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 操作時間切れでクローズ
            this.Close();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const string prog = "PlotCharts";
            RunOrShow(prog);
            this.Close();
        }
    }
}
