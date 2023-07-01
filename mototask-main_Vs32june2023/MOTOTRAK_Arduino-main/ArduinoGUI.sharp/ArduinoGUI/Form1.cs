using System;
using System.Activities;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ArduinoGUI
{
    public partial class MotoTrakController : Form
    {
        public object CmbBaud { get; private set; }
        public Func<string> Single { get; private set; }

        public MotoTrakController()
        {
            InitializeComponent();
            serialPort1.Open();

            // Chart parameters
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = -1;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 3;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 80;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 0.5;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 20;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightBlue;
            

            chart1.Series["Trial"].BorderWidth = 3;
            chart1.Series["Trial"].Points.AddXY(0, 80);
            chart1.Series["Trial"].Points.AddXY(0, 25);
            chart1.Series["Trial"].ChartType = SeriesChartType.Line;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void buttonFeed_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop(); 
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void IDBox_Changed(object sender, EventArgs e)
        {

        }

        private void LocationBox_Changed(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("browse");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            ConnectButton.SendToBack();

            serialPort1.Open();

        }

        private void RetractButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("retract");
        }

        private void DurationBox_Changed(object sender, EventArgs e)
        {

        }

        private void KnobPosBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitWindowBox_Changed(object sender, EventArgs e)
        {

        }

        private void InitThreshBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitThreshBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitCellingBox_Changed(object sender, EventArgs e)
        {

        }

        private void HoldTimeBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitThreshMinBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitThreshMaxBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitCellingMinBox_Changed(object sender, EventArgs e)
        {

        }

        private void HitCellingMaxBox_Changed(object sender, EventArgs e)
        {

        }

        private void HoldTimeMinBox_Changed(object sender, EventArgs e)
        {

        }

        private void HoldTimeMaxBox_Changed(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
           
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e) 
        {




        }
    }
}
    }

