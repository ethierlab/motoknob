Imports System.IO.Ports
Imports System.Threading

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        ' Parameters of the chart
        Chart1.ChartAreas("ChartArea1").AxisX.Minimum = 1
        Chart1.ChartAreas("ChartArea1").AxisX.Maximum = 3
        Chart1.ChartAreas("ChartArea1").AxisY.Minimum = 0
        Chart1.ChartAreas("ChartArea1").AxisY.Maximum = 5
        Chart1.ChartAreas("ChartArea1").AxisX.Interval = 0.5
        Chart1.ChartAreas("ChartArea1").AxisY.Interval = 0.5
        Chart1.ChartAreas("ChartArea1").AxisY.MinorGrid.Enabled = True
        Chart1.ChartAreas("ChartArea1").AxisY.MinorGrid.LineColor = Color.LightBlue
        Chart1.Series("Trial").BorderWidth = 3

    End Sub

    'Open the serial port for the connect button click
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        SerialPort1.Open()
    End Sub

    'Close the serial port for the disconnect button click
    Private Sub DisconnectButton_Click(sender As Object, e As EventArgs) Handles DisconnectButton.Click
        SerialPort1.Close()
    End Sub

    ' Begin the timer to record the values of the Arduino serial port for the click of the start button
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        StartButton.Enabled = False
        StartButton.SendToBack()

        StopButton.Enabled = True
        StopButton.BringToFront()
        Timer1.Start()
        Timer2.Start()
    End Sub

    ' Stop the timer and the recording of the Arduino serial port for the click of the stop button
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopButton.Enabled = False
        StopButton.SendToBack()

        StartButton.Enabled = True
        StartButton.BringToFront()

        Timer1.Stop()
        Timer2.Stop()
    End Sub

    ' Timer for 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            ' Display of the knob value
            Dim num_trials As Integer = 0
            Dim i As Single = SerialPort1.ReadExisting
            KnobValue.Text = "Knob Value : " & i.ToString

            'Display of the number of trial
            If i >= 0.8 Then
                num_trials = num_trials + 1
                NumTrial.Text = "Num Trials : " & num_trials
            End If

            'Display of the number of reward
            If i >= 1.5 Then
                Dim num_rewards As Integer = 0

                NumRewards.Text = "Num Rewards : " & num_rewards

            End If


            ' Display of the knob value on chart
            Chart1.Series("Trial").Points.AddY(i.ToString)
            If Chart1.Series(0).Points.Count = 20 Then
                Chart1.Series(0).Points.RemoveAt(0)
            End If

            Chart1.ChartAreas(0).AxisY.Maximum = 5

        Catch ex As Exception

        End Try
    End Sub


    Private Sub RetractButton_Click(sender As Object, e As EventArgs) Handles RetractButton.Click

    End Sub

    ' Timer for elapsed time
    Private Sub Timer2_Click(sender As Object, e As EventArgs) Handles Timer2.Tick
        TimeElapsedBox.Text = TimeElapsedBox.Text + 1
    End Sub
End Class
