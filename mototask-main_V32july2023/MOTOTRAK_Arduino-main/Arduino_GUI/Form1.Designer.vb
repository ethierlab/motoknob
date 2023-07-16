<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.KnobValue = New System.Windows.Forms.Label()
        Me.LocationBox = New System.Windows.Forms.TextBox()
        Me.IDBox = New System.Windows.Forms.TextBox()
        Me.TimeElapsed = New System.Windows.Forms.Label()
        Me.PelletsDelivered = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.Label()
        Me.DisconnectButton = New System.Windows.Forms.Button()
        Me.SaveLocation = New System.Windows.Forms.Label()
        Me.RatID = New System.Windows.Forms.Label()
        Me.NumRewards = New System.Windows.Forms.Label()
        Me.NumTrial = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Parameters = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.MaxHoldTimeBox = New System.Windows.Forms.TextBox()
        Me.MaxHitCellingBox = New System.Windows.Forms.TextBox()
        Me.MaxHitThreshBox = New System.Windows.Forms.TextBox()
        Me.MinHoldTimeBox = New System.Windows.Forms.TextBox()
        Me.MinHitCellingBox = New System.Windows.Forms.TextBox()
        Me.MinHitThreshBox = New System.Windows.Forms.TextBox()
        Me.Max = New System.Windows.Forms.Label()
        Me.Min = New System.Windows.Forms.Label()
        Me.Adaptive = New System.Windows.Forms.Label()
        Me.AdaptHoldTimeCheckBox = New System.Windows.Forms.CheckBox()
        Me.AdaptHitCellingCheckBox = New System.Windows.Forms.CheckBox()
        Me.AdaptHitThreshCheckBox = New System.Windows.Forms.CheckBox()
        Me.HoldTimeBox = New System.Windows.Forms.TextBox()
        Me.HitCellingBox = New System.Windows.Forms.TextBox()
        Me.HitThreshBox = New System.Windows.Forms.TextBox()
        Me.HoldTime = New System.Windows.Forms.Label()
        Me.HitCelling = New System.Windows.Forms.Label()
        Me.HitThresh = New System.Windows.Forms.Label()
        Me.textBox6 = New System.Windows.Forms.TextBox()
        Me.InitThresh = New System.Windows.Forms.Label()
        Me.textBox5 = New System.Windows.Forms.TextBox()
        Me.HitWindow = New System.Windows.Forms.Label()
        Me.textBox4 = New System.Windows.Forms.TextBox()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.KnobPos = New System.Windows.Forms.Label()
        Me.Duration = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.FeedButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.RetractButton = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.TimeElapsedBox = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KnobValue
        '
        Me.KnobValue.AutoSize = True
        Me.KnobValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.KnobValue.ForeColor = System.Drawing.Color.Coral
        Me.KnobValue.Location = New System.Drawing.Point(1206, 103)
        Me.KnobValue.Name = "KnobValue"
        Me.KnobValue.Size = New System.Drawing.Size(131, 25)
        Me.KnobValue.TabIndex = 60
        Me.KnobValue.Text = "Knob Value : "
        '
        'LocationBox
        '
        Me.LocationBox.Location = New System.Drawing.Point(236, 135)
        Me.LocationBox.Name = "LocationBox"
        Me.LocationBox.Size = New System.Drawing.Size(269, 22)
        Me.LocationBox.TabIndex = 58
        '
        'IDBox
        '
        Me.IDBox.Location = New System.Drawing.Point(85, 95)
        Me.IDBox.Name = "IDBox"
        Me.IDBox.Size = New System.Drawing.Size(100, 22)
        Me.IDBox.TabIndex = 57
        '
        'TimeElapsed
        '
        Me.TimeElapsed.AutoSize = True
        Me.TimeElapsed.Location = New System.Drawing.Point(969, 59)
        Me.TimeElapsed.Name = "TimeElapsed"
        Me.TimeElapsed.Size = New System.Drawing.Size(149, 20)
        Me.TimeElapsed.TabIndex = 56
        Me.TimeElapsed.Text = "Time Elapsed (s)  :"
        '
        'PelletsDelivered
        '
        Me.PelletsDelivered.AutoSize = True
        Me.PelletsDelivered.Location = New System.Drawing.Point(969, 17)
        Me.PelletsDelivered.Name = "PelletsDelivered"
        Me.PelletsDelivered.Size = New System.Drawing.Size(116, 16)
        Me.PelletsDelivered.TabIndex = 55
        Me.PelletsDelivered.Text = "Pellets Delivered :"
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.BackColor = System.Drawing.SystemColors.Control
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Title.ForeColor = System.Drawing.Color.MediumBlue
        Me.Title.Location = New System.Drawing.Point(354, 4)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(244, 29)
        Me.Title.TabIndex = 54
        Me.Title.Text = "Moto Trak Knob Task"
        '
        'DisconnectButton
        '
        Me.DisconnectButton.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DisconnectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DisconnectButton.Location = New System.Drawing.Point(471, 36)
        Me.DisconnectButton.Name = "DisconnectButton"
        Me.DisconnectButton.Size = New System.Drawing.Size(127, 85)
        Me.DisconnectButton.TabIndex = 53
        Me.DisconnectButton.Text = "Disconnect Moto Trak"
        Me.DisconnectButton.UseVisualStyleBackColor = False
        '
        'SaveLocation
        '
        Me.SaveLocation.AutoSize = True
        Me.SaveLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.SaveLocation.Location = New System.Drawing.Point(22, 138)
        Me.SaveLocation.Name = "SaveLocation"
        Me.SaveLocation.Size = New System.Drawing.Size(201, 18)
        Me.SaveLocation.TabIndex = 52
        Me.SaveLocation.Text = "Save location (parent folder) :"
        '
        'RatID
        '
        Me.RatID.AutoSize = True
        Me.RatID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.RatID.Location = New System.Drawing.Point(22, 96)
        Me.RatID.Name = "RatID"
        Me.RatID.Size = New System.Drawing.Size(57, 18)
        Me.RatID.TabIndex = 51
        Me.RatID.Text = "Rat ID :"
        '
        'NumRewards
        '
        Me.NumRewards.AutoSize = True
        Me.NumRewards.Location = New System.Drawing.Point(689, 59)
        Me.NumRewards.Name = "NumRewards"
        Me.NumRewards.Size = New System.Drawing.Size(98, 16)
        Me.NumRewards.TabIndex = 50
        Me.NumRewards.Text = "Num Rewards :"
        '
        'NumTrial
        '
        Me.NumTrial.AutoSize = True
        Me.NumTrial.Location = New System.Drawing.Point(689, 14)
        Me.NumTrial.Name = "NumTrial"
        Me.NumTrial.Size = New System.Drawing.Size(78, 16)
        Me.NumTrial.TabIndex = 49
        Me.NumTrial.Text = "Num Trials :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.SystemColors.Control
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.label2.Location = New System.Drawing.Point(894, 96)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(191, 25)
        Me.label2.TabIndex = 48
        Me.label2.Text = "Knob Rotation Angle"
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(511, 131)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(87, 30)
        Me.BrowseButton.TabIndex = 47
        Me.BrowseButton.Text = "Browse..."
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'ConnectButton
        '
        Me.ConnectButton.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ConnectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ConnectButton.Location = New System.Drawing.Point(338, 36)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(127, 85)
        Me.ConnectButton.TabIndex = 46
        Me.ConnectButton.Text = "Connect Moto Trak"
        Me.ConnectButton.UseVisualStyleBackColor = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.panel1.Controls.Add(Me.Parameters)
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Location = New System.Drawing.Point(25, 167)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(572, 521)
        Me.panel1.TabIndex = 45
        '
        'Parameters
        '
        Me.Parameters.AutoSize = True
        Me.Parameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Parameters.Location = New System.Drawing.Point(3, 36)
        Me.Parameters.Name = "Parameters"
        Me.Parameters.Size = New System.Drawing.Size(85, 18)
        Me.Parameters.TabIndex = 1
        Me.Parameters.Text = "Parameters"
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.panel2.Controls.Add(Me.MaxHoldTimeBox)
        Me.panel2.Controls.Add(Me.MaxHitCellingBox)
        Me.panel2.Controls.Add(Me.MaxHitThreshBox)
        Me.panel2.Controls.Add(Me.MinHoldTimeBox)
        Me.panel2.Controls.Add(Me.MinHitCellingBox)
        Me.panel2.Controls.Add(Me.MinHitThreshBox)
        Me.panel2.Controls.Add(Me.Max)
        Me.panel2.Controls.Add(Me.Min)
        Me.panel2.Controls.Add(Me.Adaptive)
        Me.panel2.Controls.Add(Me.AdaptHoldTimeCheckBox)
        Me.panel2.Controls.Add(Me.AdaptHitCellingCheckBox)
        Me.panel2.Controls.Add(Me.AdaptHitThreshCheckBox)
        Me.panel2.Controls.Add(Me.HoldTimeBox)
        Me.panel2.Controls.Add(Me.HitCellingBox)
        Me.panel2.Controls.Add(Me.HitThreshBox)
        Me.panel2.Controls.Add(Me.HoldTime)
        Me.panel2.Controls.Add(Me.HitCelling)
        Me.panel2.Controls.Add(Me.HitThresh)
        Me.panel2.Controls.Add(Me.textBox6)
        Me.panel2.Controls.Add(Me.InitThresh)
        Me.panel2.Controls.Add(Me.textBox5)
        Me.panel2.Controls.Add(Me.HitWindow)
        Me.panel2.Controls.Add(Me.textBox4)
        Me.panel2.Controls.Add(Me.textBox3)
        Me.panel2.Controls.Add(Me.KnobPos)
        Me.panel2.Controls.Add(Me.Duration)
        Me.panel2.Location = New System.Drawing.Point(5, 59)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(561, 459)
        Me.panel2.TabIndex = 0
        '
        'MaxHoldTimeBox
        '
        Me.MaxHoldTimeBox.Location = New System.Drawing.Point(481, 396)
        Me.MaxHoldTimeBox.Name = "MaxHoldTimeBox"
        Me.MaxHoldTimeBox.Size = New System.Drawing.Size(61, 22)
        Me.MaxHoldTimeBox.TabIndex = 61
        '
        'MaxHitCellingBox
        '
        Me.MaxHitCellingBox.Location = New System.Drawing.Point(481, 294)
        Me.MaxHitCellingBox.Name = "MaxHitCellingBox"
        Me.MaxHitCellingBox.Size = New System.Drawing.Size(61, 22)
        Me.MaxHitCellingBox.TabIndex = 60
        '
        'MaxHitThreshBox
        '
        Me.MaxHitThreshBox.Location = New System.Drawing.Point(481, 193)
        Me.MaxHitThreshBox.Name = "MaxHitThreshBox"
        Me.MaxHitThreshBox.Size = New System.Drawing.Size(61, 22)
        Me.MaxHitThreshBox.TabIndex = 59
        '
        'MinHoldTimeBox
        '
        Me.MinHoldTimeBox.Location = New System.Drawing.Point(365, 396)
        Me.MinHoldTimeBox.Name = "MinHoldTimeBox"
        Me.MinHoldTimeBox.Size = New System.Drawing.Size(61, 22)
        Me.MinHoldTimeBox.TabIndex = 58
        '
        'MinHitCellingBox
        '
        Me.MinHitCellingBox.Location = New System.Drawing.Point(365, 294)
        Me.MinHitCellingBox.Name = "MinHitCellingBox"
        Me.MinHitCellingBox.Size = New System.Drawing.Size(61, 22)
        Me.MinHitCellingBox.TabIndex = 57
        '
        'MinHitThreshBox
        '
        Me.MinHitThreshBox.Location = New System.Drawing.Point(365, 193)
        Me.MinHitThreshBox.Name = "MinHitThreshBox"
        Me.MinHitThreshBox.Size = New System.Drawing.Size(61, 22)
        Me.MinHitThreshBox.TabIndex = 56
        '
        'Max
        '
        Me.Max.AutoSize = True
        Me.Max.Location = New System.Drawing.Point(491, 162)
        Me.Max.Name = "Max"
        Me.Max.Size = New System.Drawing.Size(32, 16)
        Me.Max.TabIndex = 55
        Me.Max.Text = "Max"
        '
        'Min
        '
        Me.Min.AutoSize = True
        Me.Min.Location = New System.Drawing.Point(383, 162)
        Me.Min.Name = "Min"
        Me.Min.Size = New System.Drawing.Size(28, 16)
        Me.Min.TabIndex = 54
        Me.Min.Text = "Min"
        '
        'Adaptive
        '
        Me.Adaptive.AutoSize = True
        Me.Adaptive.Location = New System.Drawing.Point(247, 162)
        Me.Adaptive.Name = "Adaptive"
        Me.Adaptive.Size = New System.Drawing.Size(61, 16)
        Me.Adaptive.TabIndex = 53
        Me.Adaptive.Text = "Adaptive"
        '
        'AdaptHoldTimeCheckBox
        '
        Me.AdaptHoldTimeCheckBox.AutoSize = True
        Me.AdaptHoldTimeCheckBox.Location = New System.Drawing.Point(270, 400)
        Me.AdaptHoldTimeCheckBox.Name = "AdaptHoldTimeCheckBox"
        Me.AdaptHoldTimeCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AdaptHoldTimeCheckBox.TabIndex = 52
        Me.AdaptHoldTimeCheckBox.UseVisualStyleBackColor = True
        '
        'AdaptHitCellingCheckBox
        '
        Me.AdaptHitCellingCheckBox.AutoSize = True
        Me.AdaptHitCellingCheckBox.Location = New System.Drawing.Point(270, 299)
        Me.AdaptHitCellingCheckBox.Name = "AdaptHitCellingCheckBox"
        Me.AdaptHitCellingCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AdaptHitCellingCheckBox.TabIndex = 51
        Me.AdaptHitCellingCheckBox.UseVisualStyleBackColor = True
        '
        'AdaptHitThreshCheckBox
        '
        Me.AdaptHitThreshCheckBox.AutoSize = True
        Me.AdaptHitThreshCheckBox.Location = New System.Drawing.Point(270, 198)
        Me.AdaptHitThreshCheckBox.Name = "AdaptHitThreshCheckBox"
        Me.AdaptHitThreshCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AdaptHitThreshCheckBox.TabIndex = 50
        Me.AdaptHitThreshCheckBox.UseVisualStyleBackColor = True
        '
        'HoldTimeBox
        '
        Me.HoldTimeBox.Location = New System.Drawing.Point(132, 398)
        Me.HoldTimeBox.Name = "HoldTimeBox"
        Me.HoldTimeBox.Size = New System.Drawing.Size(61, 22)
        Me.HoldTimeBox.TabIndex = 49
        '
        'HitCellingBox
        '
        Me.HitCellingBox.Location = New System.Drawing.Point(132, 297)
        Me.HitCellingBox.Name = "HitCellingBox"
        Me.HitCellingBox.Size = New System.Drawing.Size(61, 22)
        Me.HitCellingBox.TabIndex = 48
        '
        'HitThreshBox
        '
        Me.HitThreshBox.Location = New System.Drawing.Point(132, 196)
        Me.HitThreshBox.Name = "HitThreshBox"
        Me.HitThreshBox.Size = New System.Drawing.Size(61, 22)
        Me.HitThreshBox.TabIndex = 47
        '
        'HoldTime
        '
        Me.HoldTime.AutoSize = True
        Me.HoldTime.Location = New System.Drawing.Point(21, 401)
        Me.HoldTime.Name = "HoldTime"
        Me.HoldTime.Size = New System.Drawing.Size(88, 16)
        Me.HoldTime.TabIndex = 46
        Me.HoldTime.Text = "Hold time (s) :"
        '
        'HitCelling
        '
        Me.HitCelling.AutoSize = True
        Me.HitCelling.Location = New System.Drawing.Point(21, 303)
        Me.HitCelling.Name = "HitCelling"
        Me.HitCelling.Size = New System.Drawing.Size(106, 16)
        Me.HitCelling.TabIndex = 45
        Me.HitCelling.Text = "Hit celling (deg) :"
        '
        'HitThresh
        '
        Me.HitThresh.AutoSize = True
        Me.HitThresh.Location = New System.Drawing.Point(21, 202)
        Me.HitThresh.Name = "HitThresh"
        Me.HitThresh.Size = New System.Drawing.Size(103, 16)
        Me.HitThresh.TabIndex = 44
        Me.HitThresh.Text = "Hit thresh (deg) :"
        '
        'textBox6
        '
        Me.textBox6.Location = New System.Drawing.Point(441, 55)
        Me.textBox6.Name = "textBox6"
        Me.textBox6.Size = New System.Drawing.Size(61, 22)
        Me.textBox6.TabIndex = 43
        '
        'InitThresh
        '
        Me.InitThresh.AutoSize = True
        Me.InitThresh.Location = New System.Drawing.Point(332, 61)
        Me.InitThresh.Name = "InitThresh"
        Me.InitThresh.Size = New System.Drawing.Size(103, 16)
        Me.InitThresh.TabIndex = 42
        Me.InitThresh.Text = "Init thresh (deg) :"
        '
        'textBox5
        '
        Me.textBox5.Location = New System.Drawing.Point(441, 9)
        Me.textBox5.Name = "textBox5"
        Me.textBox5.Size = New System.Drawing.Size(61, 22)
        Me.textBox5.TabIndex = 41
        '
        'HitWindow
        '
        Me.HitWindow.AutoSize = True
        Me.HitWindow.Location = New System.Drawing.Point(332, 15)
        Me.HitWindow.Name = "HitWindow"
        Me.HitWindow.Size = New System.Drawing.Size(94, 16)
        Me.HitWindow.TabIndex = 40
        Me.HitWindow.Text = "Hit window (s) :"
        '
        'textBox4
        '
        Me.textBox4.Location = New System.Drawing.Point(132, 59)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New System.Drawing.Size(61, 22)
        Me.textBox4.TabIndex = 39
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(132, 15)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(61, 22)
        Me.textBox3.TabIndex = 38
        '
        'KnobPos
        '
        Me.KnobPos.AutoSize = True
        Me.KnobPos.Location = New System.Drawing.Point(21, 65)
        Me.KnobPos.Name = "KnobPos"
        Me.KnobPos.Size = New System.Drawing.Size(99, 16)
        Me.KnobPos.TabIndex = 1
        Me.KnobPos.Text = "Knob pos (cm) :"
        '
        'Duration
        '
        Me.Duration.AutoSize = True
        Me.Duration.Location = New System.Drawing.Point(21, 18)
        Me.Duration.Name = "Duration"
        Me.Duration.Size = New System.Drawing.Size(95, 16)
        Me.Duration.TabIndex = 0
        Me.Duration.Text = "Duration (min) :"
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.StartButton.Location = New System.Drawing.Point(22, 709)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(148, 53)
        Me.StartButton.TabIndex = 44
        Me.StartButton.Text = "START"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'FeedButton
        '
        Me.FeedButton.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FeedButton.Location = New System.Drawing.Point(243, 709)
        Me.FeedButton.Name = "FeedButton"
        Me.FeedButton.Size = New System.Drawing.Size(151, 53)
        Me.FeedButton.TabIndex = 43
        Me.FeedButton.Text = "FEED"
        Me.FeedButton.UseVisualStyleBackColor = False
        '
        'StopButton
        '
        Me.StopButton.BackColor = System.Drawing.Color.Tomato
        Me.StopButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.StopButton.Location = New System.Drawing.Point(471, 709)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(150, 53)
        Me.StopButton.TabIndex = 42
        Me.StopButton.Text = "STOP"
        Me.StopButton.UseVisualStyleBackColor = False
        '
        'RetractButton
        '
        Me.RetractButton.BackColor = System.Drawing.Color.Sienna
        Me.RetractButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.RetractButton.Location = New System.Drawing.Point(12, 4)
        Me.RetractButton.Name = "RetractButton"
        Me.RetractButton.Size = New System.Drawing.Size(127, 85)
        Me.RetractButton.TabIndex = 61
        Me.RetractButton.Text = "Retract Knob"
        Me.RetractButton.UseVisualStyleBackColor = False
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'Timer1
        '
        '
        'Chart1
        '
        ChartArea6.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend6)
        Me.Chart1.Location = New System.Drawing.Point(637, 131)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series6.Legend = "Legend1"
        Series6.Name = "Trial"
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(741, 578)
        Me.Chart1.TabIndex = 62
        Me.Chart1.Text = "Chart1"
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.BackColor = System.Drawing.SystemColors.Window
        Me.TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TimeLabel.Location = New System.Drawing.Point(934, 679)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(79, 24)
        Me.TimeLabel.TabIndex = 63
        Me.TimeLabel.Text = "Time (s)"
        '
        'TimeElapsedBox
        '
        Me.TimeElapsedBox.Location = New System.Drawing.Point(1097, 53)
        Me.TimeElapsedBox.Name = "TimeElapsedBox"
        Me.TimeElapsedBox.Size = New System.Drawing.Size(55, 22)
        Me.TimeElapsedBox.TabIndex = 64
        Me.TimeElapsedBox.Text = "0"
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1407, 772)
        Me.Controls.Add(Me.TimeElapsedBox)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.RetractButton)
        Me.Controls.Add(Me.KnobValue)
        Me.Controls.Add(Me.LocationBox)
        Me.Controls.Add(Me.IDBox)
        Me.Controls.Add(Me.TimeElapsed)
        Me.Controls.Add(Me.PelletsDelivered)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.DisconnectButton)
        Me.Controls.Add(Me.SaveLocation)
        Me.Controls.Add(Me.RatID)
        Me.Controls.Add(Me.NumRewards)
        Me.Controls.Add(Me.NumTrial)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.FeedButton)
        Me.Controls.Add(Me.StopButton)
        Me.Name = "Form1"
        Me.Text = "MotoTrak Knob Controller"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents KnobValue As Label
    Private WithEvents LocationBox As TextBox
    Private WithEvents IDBox As TextBox
    Private WithEvents TimeElapsed As Label
    Private WithEvents PelletsDelivered As Label
    Private WithEvents Title As Label
    Private WithEvents DisconnectButton As Button
    Private WithEvents SaveLocation As Label
    Private WithEvents RatID As Label
    Private WithEvents NumRewards As Label
    Private WithEvents NumTrial As Label
    Private WithEvents label2 As Label
    Private WithEvents BrowseButton As Button
    Private WithEvents ConnectButton As Button
    Private WithEvents panel1 As Panel
    Private WithEvents Parameters As Label
    Private WithEvents panel2 As Panel
    Private WithEvents MaxHoldTimeBox As TextBox
    Private WithEvents MaxHitCellingBox As TextBox
    Private WithEvents MaxHitThreshBox As TextBox
    Private WithEvents MinHoldTimeBox As TextBox
    Private WithEvents MinHitCellingBox As TextBox
    Private WithEvents MinHitThreshBox As TextBox
    Private WithEvents Max As Label
    Private WithEvents Min As Label
    Private WithEvents Adaptive As Label
    Private WithEvents AdaptHoldTimeCheckBox As CheckBox
    Private WithEvents AdaptHitCellingCheckBox As CheckBox
    Private WithEvents AdaptHitThreshCheckBox As CheckBox
    Private WithEvents HoldTimeBox As TextBox
    Private WithEvents HitCellingBox As TextBox
    Private WithEvents HitThreshBox As TextBox
    Private WithEvents HoldTime As Label
    Private WithEvents HitCelling As Label
    Private WithEvents HitThresh As Label
    Private WithEvents textBox6 As TextBox
    Private WithEvents InitThresh As Label
    Private WithEvents textBox5 As TextBox
    Private WithEvents HitWindow As Label
    Private WithEvents textBox4 As TextBox
    Private WithEvents textBox3 As TextBox
    Private WithEvents KnobPos As Label
    Private WithEvents Duration As Label
    Private WithEvents StartButton As Button
    Private WithEvents FeedButton As Button
    Private WithEvents StopButton As Button
    Private WithEvents RetractButton As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents TimeLabel As Label
    Friend WithEvents TimeElapsedBox As TextBox
    Friend WithEvents Timer2 As Timer
End Class
