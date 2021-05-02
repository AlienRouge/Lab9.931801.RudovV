using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        readonly double[] Einstein = new double[5];
        public Form1()
        {
            InitializeComponent();
            chart1.Legends.Clear();
            numericUpDown5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Einstein[0] = (double)numericUpDown1.Value;
            Einstein[1] = (double)numericUpDown2.Value;
            Einstein[2] = (double)numericUpDown3.Value;
            Einstein[3] = (double)numericUpDown4.Value;
            Einstein[4] = 1 - (Einstein[0] + Einstein[1] + Einstein[2] + Einstein[3]);
            
            if (Einstein[4] <= 0 || Einstein[4] > 1)
            {
                return;
            }

            numericUpDown5.Value = (decimal)Einstein[4];
            chart1.Series[0].Points.Clear();
            Random rand = new Random();

            int[] stats = new int[5];
            var n = (int)numericTimes.Value;

            for (var i = 0; i < n; i++)
            {
                var q = (double)rand.NextDouble();
                for (var j = 0; j < 5; j++)
                {
                    q -= Einstein[j];
                    if (!(q <= 0)) continue;
                    stats[j]++;
                    break;
                }
            }
            for (var i = 0; i < 5; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, (float)stats[i] / n);
            }

        }
    }
}
