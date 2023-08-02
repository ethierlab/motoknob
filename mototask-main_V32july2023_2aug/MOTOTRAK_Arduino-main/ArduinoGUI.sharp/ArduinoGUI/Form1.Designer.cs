namespace ArduinoGUI
{
    partial class MotoTrakController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SaveLocation = new System.Windows.Forms.Label();
            this.RatID = new System.Windows.Forms.Label();
            this.NumRewards = new System.Windows.Forms.Label();
            this.NumTrials = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Parameters = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MaxHoldTimeBox = new System.Windows.Forms.TextBox();
            this.MaxHitCellingBox = new System.Windows.Forms.TextBox();
            this.MaxHitThreshBox = new System.Windows.Forms.TextBox();
            this.MinHoldTimeBox = new System.Windows.Forms.TextBox();
            this.MinHitCellingBox = new System.Windows.Forms.TextBox();
            this.MinHitThreshBox = new System.Windows.Forms.TextBox();
            this.Max = new System.Windows.Forms.Label();
            this.Min = new System.Windows.Forms.Label();
            this.Adaptive = new System.Windows.Forms.Label();
            this.AdaptHoldTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.AdaptHitCellingCheckBox = new System.Windows.Forms.CheckBox();
            this.AdaptHitThreshCheckBox = new System.Windows.Forms.CheckBox();
            this.HoldTimeBox = new System.Windows.Forms.TextBox();
            this.HitCellingBox = new System.Windows.Forms.TextBox();
            this.HitThreshBox = new System.Windows.Forms.TextBox();
            this.HoldTime = new System.Windows.Forms.Label();
            this.HitCelling = new System.Windows.Forms.Label();
            this.HitThresh = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.InitThresh = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.HitWindow = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.KnobPos = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.FeedButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.RetractButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.PelletsDelivered = new System.Windows.Forms.Label();
            this.TimeElapsed = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.LocationBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.KnobValue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveLocation
            // 
            this.SaveLocation.AutoSize = true;
            this.SaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SaveLocation.Location = new System.Drawing.Point(12, 133);
            this.SaveLocation.Name = "SaveLocation";
            this.SaveLocation.Size = new System.Drawing.Size(201, 18);
            this.SaveLocation.TabIndex = 31;
            this.SaveLocation.Text = "Save location (parent folder) :";
            // 
            // RatID
            // 
            this.RatID.AutoSize = true;
            this.RatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.RatID.Location = new System.Drawing.Point(12, 83);
            this.RatID.Name = "RatID";
            this.RatID.Size = new System.Drawing.Size(57, 18);
            this.RatID.TabIndex = 30;
            this.RatID.Text = "Rat ID :";
            // 
            // NumRewards
            // 
            this.NumRewards.AutoSize = true;
            this.NumRewards.Location = new System.Drawing.Point(679, 54);
            this.NumRewards.Name = "NumRewards";
            this.NumRewards.Size = new System.Drawing.Size(98, 16);
            this.NumRewards.TabIndex = 29;
            this.NumRewards.Text = "Num Rewards :";
            // 
            // NumTrials
            // 
            this.NumTrials.AutoSize = true;
            this.NumTrials.Location = new System.Drawing.Point(679, 9);
            this.NumTrials.Name = "NumTrials";
            this.NumTrials.Size = new System.Drawing.Size(78, 16);
            this.NumTrials.TabIndex = 28;
            this.NumTrials.Text = "Num Trials :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(884, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Knob Rotation Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(464, -23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "MotoTrak Knob Task";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(501, 126);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(87, 30);
            this.BrowseButton.TabIndex = 25;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ConnectButton.Location = new System.Drawing.Point(328, 31);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(127, 85);
            this.ConnectButton.TabIndex = 24;
            this.ConnectButton.Text = "Connect Moto Trak";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.Parameters);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(15, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 521);
            this.panel1.TabIndex = 23;
            // 
            // Parameters
            // 
            this.Parameters.AutoSize = true;
            this.Parameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Parameters.Location = new System.Drawing.Point(3, 36);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(85, 18);
            this.Parameters.TabIndex = 1;
            this.Parameters.Text = "Parameters";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.MaxHoldTimeBox);
            this.panel2.Controls.Add(this.MaxHitCellingBox);
            this.panel2.Controls.Add(this.MaxHitThreshBox);
            this.panel2.Controls.Add(this.MinHoldTimeBox);
            this.panel2.Controls.Add(this.MinHitCellingBox);
            this.panel2.Controls.Add(this.MinHitThreshBox);
            this.panel2.Controls.Add(this.Max);
            this.panel2.Controls.Add(this.Min);
            this.panel2.Controls.Add(this.Adaptive);
            this.panel2.Controls.Add(this.AdaptHoldTimeCheckBox);
            this.panel2.Controls.Add(this.AdaptHitCellingCheckBox);
            this.panel2.Controls.Add(this.AdaptHitThreshCheckBox);
            this.panel2.Controls.Add(this.HoldTimeBox);
            this.panel2.Controls.Add(this.HitCellingBox);
            this.panel2.Controls.Add(this.HitThreshBox);
            this.panel2.Controls.Add(this.HoldTime);
            this.panel2.Controls.Add(this.HitCelling);
            this.panel2.Controls.Add(this.HitThresh);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.InitThresh);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.HitWindow);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.KnobPos);
            this.panel2.Controls.Add(this.Duration);
            this.panel2.Location = new System.Drawing.Point(5, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 459);
            this.panel2.TabIndex = 0;
            // 
            // MaxHoldTimeBox
            // 
            this.MaxHoldTimeBox.Location = new System.Drawing.Point(481, 396);
            this.MaxHoldTimeBox.Name = "MaxHoldTimeBox";
            this.MaxHoldTimeBox.Size = new System.Drawing.Size(61, 22);
            this.MaxHoldTimeBox.TabIndex = 61;
            this.MaxHoldTimeBox.TextChanged += new System.EventHandler(this.HoldTimeMaxBox_Changed);
            // 
            // MaxHitCellingBox
            // 
            this.MaxHitCellingBox.Location = new System.Drawing.Point(481, 294);
            this.MaxHitCellingBox.Name = "MaxHitCellingBox";
            this.MaxHitCellingBox.Size = new System.Drawing.Size(61, 22);
            this.MaxHitCellingBox.TabIndex = 60;
            this.MaxHitCellingBox.TextChanged += new System.EventHandler(this.HitCellingMaxBox_Changed);
            // 
            // MaxHitThreshBox
            // 
            this.MaxHitThreshBox.Location = new System.Drawing.Point(481, 193);
            this.MaxHitThreshBox.Name = "MaxHitThreshBox";
            this.MaxHitThreshBox.Size = new System.Drawing.Size(61, 22);
            this.MaxHitThreshBox.TabIndex = 59;
            this.MaxHitThreshBox.TextChanged += new System.EventHandler(this.HitThreshMaxBox_Changed);
            // 
            // MinHoldTimeBox
            // 
            this.MinHoldTimeBox.Location = new System.Drawing.Point(365, 396);
            this.MinHoldTimeBox.Name = "MinHoldTimeBox";
            this.MinHoldTimeBox.Size = new System.Drawing.Size(61, 22);
            this.MinHoldTimeBox.TabIndex = 58;
            this.MinHoldTimeBox.TextChanged += new System.EventHandler(this.HoldTimeMinBox_Changed);
            // 
            // MinHitCellingBox
            // 
            this.MinHitCellingBox.Location = new System.Drawing.Point(365, 294);
            this.MinHitCellingBox.Name = "MinHitCellingBox";
            this.MinHitCellingBox.Size = new System.Drawing.Size(61, 22);
            this.MinHitCellingBox.TabIndex = 57;
            this.MinHitCellingBox.TextChanged += new System.EventHandler(this.HitCellingMinBox_Changed);
            // 
            // MinHitThreshBox
            // 
            this.MinHitThreshBox.Location = new System.Drawing.Point(365, 193);
            this.MinHitThreshBox.Name = "MinHitThreshBox";
            this.MinHitThreshBox.Size = new System.Drawing.Size(61, 22);
            this.MinHitThreshBox.TabIndex = 56;
            this.MinHitThreshBox.TextChanged += new System.EventHandler(this.HitThreshMinBox_Changed);
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Location = new System.Drawing.Point(491, 162);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(32, 16);
            this.Max.TabIndex = 55;
            this.Max.Text = "Max";
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Location = new System.Drawing.Point(383, 162);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(28, 16);
            this.Min.TabIndex = 54;
            this.Min.Text = "Min";
            // 
            // Adaptive
            // 
            this.Adaptive.AutoSize = true;
            this.Adaptive.Location = new System.Drawing.Point(247, 162);
            this.Adaptive.Name = "Adaptive";
            this.Adaptive.Size = new System.Drawing.Size(61, 16);
            this.Adaptive.TabIndex = 53;
            this.Adaptive.Text = "Adaptive";
            // 
            // AdaptHoldTimeCheckBox
            // 
            this.AdaptHoldTimeCheckBox.AutoSize = true;
            this.AdaptHoldTimeCheckBox.Location = new System.Drawing.Point(270, 400);
            this.AdaptHoldTimeCheckBox.Name = "AdaptHoldTimeCheckBox";
            this.AdaptHoldTimeCheckBox.Size = new System.Drawing.Size(18, 17);
            this.AdaptHoldTimeCheckBox.TabIndex = 52;
            this.AdaptHoldTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdaptHitCellingCheckBox
            // 
            this.AdaptHitCellingCheckBox.AutoSize = true;
            this.AdaptHitCellingCheckBox.Location = new System.Drawing.Point(270, 299);
            this.AdaptHitCellingCheckBox.Name = "AdaptHitCellingCheckBox";
            this.AdaptHitCellingCheckBox.Size = new System.Drawing.Size(18, 17);
            this.AdaptHitCellingCheckBox.TabIndex = 51;
            this.AdaptHitCellingCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdaptHitThreshCheckBox
            // 
            this.AdaptHitThreshCheckBox.AutoSize = true;
            this.AdaptHitThreshCheckBox.Location = new System.Drawing.Point(270, 198);
            this.AdaptHitThreshCheckBox.Name = "AdaptHitThreshCheckBox";
            this.AdaptHitThreshCheckBox.Size = new System.Drawing.Size(18, 17);
            this.AdaptHitThreshCheckBox.TabIndex = 50;
            this.AdaptHitThreshCheckBox.UseVisualStyleBackColor = true;
            // 
            // HoldTimeBox
            // 
            this.HoldTimeBox.Location = new System.Drawing.Point(132, 398);
            this.HoldTimeBox.Name = "HoldTimeBox";
            this.HoldTimeBox.Size = new System.Drawing.Size(61, 22);
            this.HoldTimeBox.TabIndex = 49;
            this.HoldTimeBox.TextChanged += new System.EventHandler(this.HoldTimeBox_Changed);
            // 
            // HitCellingBox
            // 
            this.HitCellingBox.Location = new System.Drawing.Point(132, 297);
            this.HitCellingBox.Name = "HitCellingBox";
            this.HitCellingBox.Size = new System.Drawing.Size(61, 22);
            this.HitCellingBox.TabIndex = 48;
            this.HitCellingBox.TextChanged += new System.EventHandler(this.HitCellingBox_Changed);
            // 
            // HitThreshBox
            // 
            this.HitThreshBox.Location = new System.Drawing.Point(132, 196);
            this.HitThreshBox.Name = "HitThreshBox";
            this.HitThreshBox.Size = new System.Drawing.Size(61, 22);
            this.HitThreshBox.TabIndex = 47;
            this.HitThreshBox.TextChanged += new System.EventHandler(this.HitThreshBox_Changed);
            // 
            // HoldTime
            // 
            this.HoldTime.AutoSize = true;
            this.HoldTime.Location = new System.Drawing.Point(21, 401);
            this.HoldTime.Name = "HoldTime";
            this.HoldTime.Size = new System.Drawing.Size(88, 16);
            this.HoldTime.TabIndex = 46;
            this.HoldTime.Text = "Hold time (s) :";
            // 
            // HitCelling
            // 
            this.HitCelling.AutoSize = true;
            this.HitCelling.Location = new System.Drawing.Point(21, 303);
            this.HitCelling.Name = "HitCelling";
            this.HitCelling.Size = new System.Drawing.Size(106, 16);
            this.HitCelling.TabIndex = 45;
            this.HitCelling.Text = "Hit celling (deg) :";
            // 
            // HitThresh
            // 
            this.HitThresh.AutoSize = true;
            this.HitThresh.Location = new System.Drawing.Point(21, 202);
            this.HitThresh.Name = "HitThresh";
            this.HitThresh.Size = new System.Drawing.Size(103, 16);
            this.HitThresh.TabIndex = 44;
            this.HitThresh.Text = "Hit thresh (deg) :";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(441, 55);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(61, 22);
            this.textBox6.TabIndex = 43;
            this.textBox6.TextChanged += new System.EventHandler(this.InitThreshBox_Changed);
            // 
            // InitThresh
            // 
            this.InitThresh.AutoSize = true;
            this.InitThresh.Location = new System.Drawing.Point(332, 61);
            this.InitThresh.Name = "InitThresh";
            this.InitThresh.Size = new System.Drawing.Size(103, 16);
            this.InitThresh.TabIndex = 42;
            this.InitThresh.Text = "Init thresh (deg) :";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(441, 9);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(61, 22);
            this.textBox5.TabIndex = 41;
            this.textBox5.TextChanged += new System.EventHandler(this.HitWindowBox_Changed);
            // 
            // HitWindow
            // 
            this.HitWindow.AutoSize = true;
            this.HitWindow.Location = new System.Drawing.Point(332, 15);
            this.HitWindow.Name = "HitWindow";
            this.HitWindow.Size = new System.Drawing.Size(94, 16);
            this.HitWindow.TabIndex = 40;
            this.HitWindow.Text = "Hit window (s) :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(132, 59);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(61, 22);
            this.textBox4.TabIndex = 39;
            this.textBox4.TextChanged += new System.EventHandler(this.KnobPosBox_Changed);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(132, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(61, 22);
            this.textBox3.TabIndex = 38;
            this.textBox3.TextChanged += new System.EventHandler(this.DurationBox_Changed);
            // 
            // KnobPos
            // 
            this.KnobPos.AutoSize = true;
            this.KnobPos.Location = new System.Drawing.Point(21, 65);
            this.KnobPos.Name = "KnobPos";
            this.KnobPos.Size = new System.Drawing.Size(99, 16);
            this.KnobPos.TabIndex = 1;
            this.KnobPos.Text = "Knob pos (cm) :";
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Location = new System.Drawing.Point(21, 18);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(95, 16);
            this.Duration.TabIndex = 0;
            this.Duration.Text = "Duration (min) :";
            this.Duration.Click += new System.EventHandler(this.label11_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.StartButton.Location = new System.Drawing.Point(12, 704);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(148, 53);
            this.StartButton.TabIndex = 22;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FeedButton
            // 
            this.FeedButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FeedButton.Location = new System.Drawing.Point(233, 704);
            this.FeedButton.Name = "FeedButton";
            this.FeedButton.Size = new System.Drawing.Size(151, 53);
            this.FeedButton.TabIndex = 21;
            this.FeedButton.Text = "FEED";
            this.FeedButton.UseVisualStyleBackColor = false;
            this.FeedButton.Click += new System.EventHandler(this.buttonFeed_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Tomato;
            this.StopButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StopButton.Location = new System.Drawing.Point(461, 704);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(150, 53);
            this.StopButton.TabIndex = 20;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // RetractButton
            // 
            this.RetractButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RetractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RetractButton.Location = new System.Drawing.Point(461, 31);
            this.RetractButton.Name = "RetractButton";
            this.RetractButton.Size = new System.Drawing.Size(127, 85);
            this.RetractButton.TabIndex = 32;
            this.RetractButton.Text = "Retract Knob";
            this.RetractButton.UseVisualStyleBackColor = false;
            this.RetractButton.Click += new System.EventHandler(this.RetractButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.Control;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Title.ForeColor = System.Drawing.Color.MediumBlue;
            this.Title.Location = new System.Drawing.Point(344, -1);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(244, 29);
            this.Title.TabIndex = 33;
            this.Title.Text = "Moto Trak Knob Task";
            // 
            // PelletsDelivered
            // 
            this.PelletsDelivered.AutoSize = true;
            this.PelletsDelivered.Location = new System.Drawing.Point(959, 12);
            this.PelletsDelivered.Name = "PelletsDelivered";
            this.PelletsDelivered.Size = new System.Drawing.Size(116, 16);
            this.PelletsDelivered.TabIndex = 34;
            this.PelletsDelivered.Text = "Pellets Delivered :";
            // 
            // TimeElapsed
            // 
            this.TimeElapsed.AutoSize = true;
            this.TimeElapsed.Location = new System.Drawing.Point(959, 54);
            this.TimeElapsed.Name = "TimeElapsed";
            this.TimeElapsed.Size = new System.Drawing.Size(101, 16);
            this.TimeElapsed.TabIndex = 36;
            this.TimeElapsed.Text = "Time Elapsed  :";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(79, 82);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(100, 22);
            this.IDBox.TabIndex = 37;
            this.IDBox.TextChanged += new System.EventHandler(this.IDBox_Changed);
            // 
            // LocationBox
            // 
            this.LocationBox.Location = new System.Drawing.Point(226, 130);
            this.LocationBox.Name = "LocationBox";
            this.LocationBox.Size = new System.Drawing.Size(269, 22);
            this.LocationBox.TabIndex = 38;
            this.LocationBox.TextChanged += new System.EventHandler(this.LocationBox_Changed);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // chart1
            // 
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(617, 126);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Trial";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 593);
            this.chart1.TabIndex = 39;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "label3";
            // 
            // KnobValue
            // 
            this.KnobValue.AutoSize = true;
            this.KnobValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.KnobValue.ForeColor = System.Drawing.Color.Coral;
            this.KnobValue.Location = new System.Drawing.Point(1196, 98);
            this.KnobValue.Name = "KnobValue";
            this.KnobValue.Size = new System.Drawing.Size(131, 25);
            this.KnobValue.TabIndex = 41;
            this.KnobValue.Text = "Knob Value : ";
            this.KnobValue.Click += new System.EventHandler(this.label4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MotoTrakController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 773);
            this.Controls.Add(this.KnobValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.LocationBox);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.TimeElapsed);
            this.Controls.Add(this.PelletsDelivered);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.RetractButton);
            this.Controls.Add(this.SaveLocation);
            this.Controls.Add(this.RatID);
            this.Controls.Add(this.NumRewards);
            this.Controls.Add(this.NumTrials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FeedButton);
            this.Controls.Add(this.StopButton);
            this.Name = "MotoTrakController";
            this.Text = "MotoTrak Knob Controller";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaveLocation;
        private System.Windows.Forms.Label RatID;
        private System.Windows.Forms.Label NumRewards;
        private System.Windows.Forms.Label NumTrials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button FeedButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label Parameters;
        private System.Windows.Forms.Button RetractButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label PelletsDelivered;
        private System.Windows.Forms.Label TimeElapsed;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox LocationBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.TextBox HoldTimeBox;
        private System.Windows.Forms.TextBox HitCellingBox;
        private System.Windows.Forms.TextBox HitThreshBox;
        private System.Windows.Forms.Label HoldTime;
        private System.Windows.Forms.Label HitCelling;
        private System.Windows.Forms.Label HitThresh;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label InitThresh;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label HitWindow;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label KnobPos;
        private System.Windows.Forms.TextBox MaxHoldTimeBox;
        private System.Windows.Forms.TextBox MaxHitCellingBox;
        private System.Windows.Forms.TextBox MaxHitThreshBox;
        private System.Windows.Forms.TextBox MinHoldTimeBox;
        private System.Windows.Forms.TextBox MinHitCellingBox;
        private System.Windows.Forms.TextBox MinHitThreshBox;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.Label Adaptive;
        private System.Windows.Forms.CheckBox AdaptHoldTimeCheckBox;
        private System.Windows.Forms.CheckBox AdaptHitCellingCheckBox;
        private System.Windows.Forms.CheckBox AdaptHitThreshCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label KnobValue;
        private System.Windows.Forms.Timer timer1;
    }
}

