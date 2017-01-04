
Imports System.IO
Imports System.IO.Ports
Imports System.Environment

Public Class MainForm
    ''*************************************************************
    '   Project     Shuttlebox Behavior System
    '               The Tanguay Lab, Oregon State University
    '   Programmer  Rick Mandrell
    '   Date        4/2/2013
    '   Version     3.0
    '   
    '   Summary:    The Shuttlebox Behavior system automates the behavior testing of zebra fish using a microcontroller based shuttlebox device.
    '               This VB.Net application interfaces with the Arduino microcontroller via a Serial over USB link to receive test results and download
    '               test configuration parameters and control commands.  The application also implements the user interface, and outputs test results 
    '               to a .txt file for later analysis.
    '
    '               The user interface consists of two Windows forms:
    '               MainForm:   displays test results and status in a scrolling textbox.  Also provides for selecting or creating the output results file.
    '
    '               ConfigForm: used to manage the test configuration parameters.  The form uses two parameter list columns to display and manage the configuration
    '                           parameters used by the shuttle box for testing.  Pre-defined configuration text files can be selected and their 
    '                           parameters downloaded and used for testing.  A System default configuration file can also be designated, and its parameters 
    '                           used as default parameters for all shuttle boxes attached to the Host PC.  A hardcoded set of default parameters are also 
    '                           available when no System default file is designated.
    '                           Default parametes are initially loaded into the Default Params column displayed on the form.  A second parameter list column is used 
    '                           to display the current parameter set on the Arduino controller.  Parameters in this column may be edited and
    '                           downloaded to the Arduino.  The Arduino maintains configuration parameters in non-volatile memory after power-down, and will
    '                           restart with the last parameter set intact.
    '
    '   Components: MainForm - Shuttlebox control panel for results and output file specification.  Used to Start and Abort tests.  Also launches the ConfigForm.
    '               ConfigForm - used to manage the test configuration parameters and download to the Arduino microcontroller.
    '               DownloadStatusForm - used to show the config parameter download status during the download; displays each parameter & value
    '               ShuttleboxIOClass - an asynchronous thread running a server loop that handles all serial I/O with the Arduino.
    '               StatusClass - a Singleton class providing communication between the Main and Config Forms and the ShuttleboxIOClass Server for passing 
    '               parameters and control commands.
    '               
    '
    '************************  Class Level Declarations  *************************************
    '   Suttlebox Box number and ComPort are read in from the Behavior_Serial_VB_Source.exe.config file
    '   ComPort must be determined from the Device Manager for the specific shuttlebox unit to be controlled
    '
    Public intBoxNum As Integer = My.Settings.ShuttleBox_Num
    Dim strComPort As String = My.Settings.COM_Port

    '****************  Default Config Parameters  **************
    Public intNumberOfTrials As Integer = 20
    Public strSelectionMode As String = "Opposite"
    Public intSettleTime As Integer = 600
    Public intTrialDuration As Integer = 24
    Public intSeekTime As Integer = 12
    Public intInterTrialSettleTime As Integer = 12
    Public strSettleLight As String = "OFF"
    Public strAcceptLight As String = "OFF"
    Public strRejectLight As String = "GREEN"
    Public strWaitForStartLight As String = "OFF"
    Public intFaultOutTrials_Percent As Integer = 8
    Public intFaultOutTrials_SideSwaps As Integer = 4
    Public intFaultOutPercent As Integer = 95
    Public decShockVoltage As Decimal = 45D
    Public intShockInterval As Integer = 1500
    Public intShockDuration As Integer = 100
    Public intSuccessTrials As Integer = 5
    '**************  End Default Config Parameters  ************
    '
    '   Declare the ConfigForm and DownloadStatusForm - makes them single instance forms
    '
    Public frmConfigForm As New ConfigForm
    Dim frmDownloadStatusForm As New DownloadStatusForm
    Dim frmConfigFormLoading As New ConfigForm_Loading
    Dim blnConfigFormButton As Boolean = False
    '
    '*************************  MainForm Load Handler **********************************
    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '
        '   Set up the StatusClass
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   Load the ComPort into StatusClass for the ShuttleboxIOClass server
        '
        status.COMPort = strComPort
        '
        '   Display the COMPort and BoxNum for in the MainForm labels
        '
        lblComPort.Text = status.COMPort
        lblBoxNum.Text = intBoxNum.ToString
        '
        '   Check for the logfile folder - if present then set the logging flag True
        '
        Dim strLogFileDirectory As String = "c:\sboxlogfiles"

        If Directory.Exists(strLogFileDirectory) Then
            status.LogFileWrite = True
            status.LogFilename = strLogFileDirectory & "\" & Format(Now, "MM_dd_yyyy_HH_mm_ss" & vbCrLf & vbCrLf) & "\" & "Shuttlebox_" & intBoxNum & "_LogFile.txt"
        End If
        '
        '   Write out program start time to log file
        '
        If status.LogFileWrite Then
            Try
                File.AppendAllText(status.LogFilename, vbCrLf & vbCrLf & "*****  Program Start at: " & Format(Now, "MM/dd/yyyy HH:mm:ss" & vbCrLf & vbCrLf))

            Catch ex As Exception
                MessageBox.Show("Shuttlebox_" & intBoxNum & " Logfile write failed: " & ex.Message)
            End Try
        End If

        '
        '   Set up defaults for the Results file directory and filename
        '   Using 'Desktop\Shuttle Box Results' folder as the default
        '
        Dim strResultsDefaultFolder As String = "Shuttle Box Results"
        Dim strResultsFullPathname = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), strResultsDefaultFolder)
        If Not System.IO.Directory.Exists(strResultsFullPathname) Then
            System.IO.Directory.CreateDirectory(strResultsFullPathname)
        End If
        '
        '   Display the folder path and the file name in separate text boxes on the MainForm
        '
        txtResultFolderPath.Text = strResultsFullPathname
        txtResultFilename.Text = "Shuttlebox_" & intBoxNum & "_Results.txt"
        '
        '   Disable the Abort button until a test is started
        '
        btnAbort.Enabled = False
        Me.Show()
        '
        '   Set up ShuttleboxIOClass Class to interface with the Arduino microcontroller and receive test results
        '   
        Dim Server As New ShuttleboxIOClass
        '
        ' Start the asynchronous Shuttlebox IO Server.
        '
        BackgroundWorker1.RunWorkerAsync(Server)
        
    End Sub

    '************************************** BackgroundWorker DoWork - starts COMPortIO server in ShuttleboxIOClass  ************************************************
    Private Sub BackgroundWorker1_DoWork(
    ByVal sender As Object,
    ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ' This starts the Shuttlebox Server thread.
        ' This method runs on the background thread.

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Get the Server object and call the main method.
        Dim Server As ShuttleboxIOClass = CType(e.Argument, ShuttleboxIOClass)
        ShuttleboxIOClass.COMPortIO(worker, e)
    End Sub

    '************************************** Event Handler - BackgroundWorker1 Status Changed (ComPortIO server event)  ************************************************

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object,
                                                  ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '
        '   The ProgressChanged event is initiated by the ComPortIO server to send results and/or error messages back to this MainForm
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   e.UserState contains the text message from the server
        '
        Dim strResults As String = (CType(e.UserState, String))

        Dim strTestResultsTextbox As String = ""
        Dim strTestResultsFile As String = ""
        Dim strTime As String = Format(Now, "MM/dd/yyyy HH:mm:ss")

        '
        '   First check for a fatal error denoted by ProgressPercentage = 2
        '   These errors are due to failure to open the serial port to the Shuttlebox
        '
        If e.ProgressPercentage = 2 Then
            '
            '   Write the error to the logfile
            '
            If status.LogFileWrite Then
                Try
                    File.AppendAllText(status.LogFilename, "Program Start Failed at: " & Format(Now, "MM/dd/yyyy HH:mm:ss") & vbCrLf)
                Catch ex As Exception
                    MessageBox.Show("Shuttlebox_" & intBoxNum & " Logfile write failed in ProgressChanged: " & ex.Message)
                End Try
            End If
            '
            '   Notify the operator and exit the application
            MessageBox.Show(strResults & vbCrLf & "Please reconnect or power up the Shuttlebox then restart the application.")
            Application.Exit()
        End If
        '
        '   Check for a configuration parameter download update messages
        '   Configuration download status is displayed on the DownloadStatusForm
        '
        '   ProgressPercentage = 3 is the start download message
        '
        If e.ProgressPercentage = 3 Then
            Dim Point As New Point
            Point.X = Me.Location.X - 20
            Point.Y = Me.Location.Y - 20

            frmDownloadStatusForm.Show()
            frmDownloadStatusForm.Text = "Download Status - ShuttleBox #" & intBoxNum
            frmDownloadStatusForm.lblStatus.Text = strResults
            frmDownloadStatusForm.Update()
            frmDownloadStatusForm.Activate()
            frmDownloadStatusForm.Location = Point

        End If
        '
        '   ProgressPercentage = 4 is a download parameter update message
        '
        If e.ProgressPercentage = 4 Then
            frmDownloadStatusForm.lblStatus.Text = strResults
            frmDownloadStatusForm.Update()
            'frmDownloadStatusForm.Activate()

        End If
        '
        '   Check for configuration parameter read complete message
        '   Completes the parameter read process for the ConfigForm
        '
        If e.ProgressPercentage = 10 Then
            ConfigParamReadComplete()

        End If

        '
        '   The ProgressChanged event is not reporting a fatal error or config download parameter update, so process the Results string:
        '
        '   Since Shuttlebox tests can be started or aborted with buttons on the Shuttlebox device - button states (Enabled/Disabled) must 
        '       be set based on status messages received from the Shuttlebox Arduino
        '   This code disables buttons during testing: they are disabled upon receipt of messages starting with 'New' (Test) & 
        '   re-enable upon receipt of messages starting with 'Test' (Complete or Abort)
        '   Add Time stamps to the messages indicating start and end of test
        '
        '   Check that this message is a non-fatal error (= 0) or a status/results update (= 100) or Trial Results (= 50)
        '
        If e.ProgressPercentage = 0 Or e.ProgressPercentage = 100 Or e.ProgressPercentage = 50 Then
            '
            '   Messages starting with 'New' indicate a new test was started
            '
            If strResults.StartsWith("New") Then
                '
                '   Add time stamps to New Test lines & format separately for the textbox and file output
                '   Add a line with the Result file path/filename
                '   Add a line showing the Config parameters for this test
                '   Add a header indicating the Trial result items in the comma delimited result lines
                '
                strTestResultsFile = strResults.Trim & ": " & strTime & vbCrLf & "Results File = " & txtResultFolderPath.Text & "\" & txtResultFilename.Text & vbCrLf &
                    "Config Params: " & vbCrLf &
                    status.NumberOfTrials & " | " & status.SelectionMode & " | " & status.SettleTime &
                    " | " & status.TrialDuration & " | " & status.SeekTime & " | " & status.InterTrialSettleTime & " | " & status.SettleLight &
                    " | " & status.AcceptLight & " | " & status.RejectLight & " | " & status.WaitForStartLight &
                    " | " & status.FaultOutTrials_Percent & " | " & status.FaultOutTrials_SideSwaps & " | " & status.FaultOutPercent & " | " & status.ShockVoltage &
                    " | " & status.ShockInterval & " | " & status.ShockDuration & " | " & status.SuccessTrials & vbCrLf & vbCrLf &
                    "Trial: ASide, SeekSwaps, ShockSwaps, TimeToASide, Reject, Accept, Shock, Shocked" & vbCrLf

                strTestResultsTextbox = strResults.Trim & ": " & strTime & vbCrLf & "Results File = " & txtResultFolderPath.Text & "\" & txtResultFilename.Text & vbCrLf &
                    status.NumberOfTrials & " | " & status.SelectionMode & " | " & status.SettleTime &
                    " | " & status.TrialDuration & " | " & status.SeekTime & " | " & status.InterTrialSettleTime & " | " & status.SettleLight &
                    " | " & status.AcceptLight & " | " & status.RejectLight & " | " & status.WaitForStartLight &
                    " | " & status.FaultOutTrials_Percent & " | " & status.FaultOutTrials_SideSwaps & " | " & status.FaultOutPercent & " | " & status.ShockVoltage &
                    " | " & status.ShockInterval & " | " & status.ShockDuration & " | " & status.SuccessTrials & vbCrLf & vbCrLf &
                    "Trial: ASide,SeekSwaps,ShockSwaps,TimeToASide,Reject,Accept,Shock,Shocked"

                '
                '   Since a new test is starting, set the Test start time & SBox number as the index for the raw Trial results file
                '
                status.TestIndex = Format(Now, "yyyyMMdd_HHmmss_" & intBoxNum)

                '
                '   Disable the buttons since "New" indicates starting a test
                btnStart.Enabled = False
                btnOpenFileBrowse.Enabled = False
                btnResultsFolderBrowse.Enabled = False
                btnConfigParams.Enabled = False
                btnAbort.Enabled = True
                txtResultFilename.ReadOnly = True
                '   Disable the Download button on the Configform
                frmConfigForm.btnDownloadConfigParams.Enabled = False
                frmConfigForm.btnReadConfigParams.Enabled = False
                '
                '   Messages starting with "Test" indicate at test was either completed or aborted.
                '
            ElseIf strResults.StartsWith("Test") Then
                '   Add time stamps to Test Complete/Abort lines & format separately for the textbox and file output
                strTestResultsFile = strResults.Trim & ": " & strTime & vbCrLf & vbCrLf
                strTestResultsTextbox = strResults.Trim & ": " & strTime & vbCrLf
                '   Re-enable the buttons since "Test" indicates either Complete or Abort
                btnStart.Enabled = True
                btnOpenFileBrowse.Enabled = True
                btnResultsFolderBrowse.Enabled = True
                btnConfigParams.Enabled = True
                btnAbort.Enabled = False
                txtResultFilename.ReadOnly = False
                '   Also enable the Download button on the ConfigForm
                frmConfigForm.btnDownloadConfigParams.Enabled = True
                frmConfigForm.btnReadConfigParams.Enabled = True
                '
                '   Messages starting with 'Config' indicate a configuration parameter download has completed
                '
            ElseIf strResults.StartsWith("Config") Then
                strTestResultsFile = strResults
                strTestResultsTextbox = strResults.TrimEnd & vbCrLf
                btnStart.Enabled = True
                '
                '   Config Download is complete - hide DownloadStatusForm and re-enable ConfigForm
                '
                frmDownloadStatusForm.Hide()
                '
                '   Enable the Config Form buttons
                '
                frmConfigForm.btnClose.Enabled = True
                frmConfigForm.btnReadConfigParams.Enabled = True
                frmConfigForm.btnResetDefaults.Enabled = True
                frmConfigForm.btnDownloadConfigParams.Enabled = True
                frmConfigForm.btnConfigBrowse.Enabled = True
                frmConfigForm.btnTransferValues.Enabled = True
                '
                '   If the download was successful (e.ProgressPercentage = 100)
                '   Reset the column name to Arduino Params
                '
                If e.ProgressPercentage = 100 Then
                    frmConfigForm.lblParamsTitle.Text = "Arduino Params"
                End If
                '
                '   Bring the Main form back to the front & hide the ConfigForm
                '
                frmConfigForm.Hide()
                Me.Activate()

                '
                '   Messages starting with 'Error' are error messages
                '   The Start button needs to be re-enabled after an error
                '
            ElseIf strResults.StartsWith("Error") Then
                strTestResultsFile = strResults
                strTestResultsTextbox = strResults
                btnStart.Enabled = True
                '
                '   Enable the Config Form buttons in case this is a download or read timeout error
                '
                frmConfigForm.btnClose.Enabled = True
                frmConfigForm.btnReadConfigParams.Enabled = True
                frmConfigForm.btnResetDefaults.Enabled = True
                frmConfigForm.btnDownloadConfigParams.Enabled = True
                frmConfigForm.btnConfigBrowse.Enabled = True
                frmConfigForm.btnTransferValues.Enabled = True
                frmConfigFormLoading.Hide()
                '
                '
                '   All other messages are Trial results or Fault Out info - no reformatting or enabling required
            Else
                strTestResultsFile = strResults
                strTestResultsTextbox = strResults
            End If
            '
            '   Write trial results and config download messages to the Results file
            '   No Error messages are sent to the results file output
            '
            If e.ProgressPercentage = 100 Or e.ProgressPercentage = 50 Then
                WriteToFileForTest(strTestResultsFile, intBoxNum)
            End If
            '
            '   Write trial results and error messages to the text box and the logfile
            '
            txtResults.AppendText(strTestResultsTextbox & vbCrLf)

            If status.LogFileWrite Then
                Try
                    File.AppendAllText(status.LogFilename, strTestResultsFile)

                Catch ex As Exception
                    MessageBox.Show("Shuttlebox_" & intBoxNum & " Logfile write failed: " & ex.Message)
                End Try
            End If
            '
            '   Write only Trial results to the raw Trial results file
            '
            If e.ProgressPercentage = 50 Then
                WriteTrialResultsToFile(strTestResultsFile)
            End If
        End If

    End Sub

    '************************************** Write Results to Results file ************************************************
    '
    '   Write test results to the results text file specified in the MainForm text boxes
    '
    Sub WriteToFileForTest(ByVal strResultString As String, ByVal intBoxNum As Integer)

        Dim status As StatusClass
        status = StatusClass.GetInstance

        '
        '   Append the test results line to the output folder\file for this Station
        '
        Try
            File.AppendAllText(txtResultFolderPath.Text & "\" & txtResultFilename.Text, strResultString)

        Catch ex As Exception
            MessageBox.Show("WriteToFile failed on results file output: " & ex.Message)
            Application.Exit()
        End Try
    End Sub

    '************************************** Write raw Trial Results to file ************************************************
    '
    '   Write test results to the results text file specified in the MainForm text boxes
    '
    Sub WriteTrialResultsToFile(ByVal strResultString As String)

        Dim status As StatusClass
        status = StatusClass.GetInstance
        Dim strModifiedResultString = strResultString.Replace(":", ",")
        Dim strTrialResultString As String = status.TestIndex & ", " & strModifiedResultString
        '
        '   Append the test results line to the output folder\file for this Station
        '
        Try
            File.AppendAllText(txtResultFolderPath.Text & "\" & "TrialResults_SBox" & intBoxNum & ".txt", strTrialResultString)
        Catch ex As Exception
            MessageBox.Show("WriteTrialResultsToFile failed on results file output: " & ex.Message)
            Application.Exit()
        End Try
    End Sub


    '************************************** Start Test Button Event Handler  ************************************************
    '
    '   The Start test button has been pressed
    '
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        '
        '   Set the StatusClass.StartTest property to True to signal a start test request to the ShuttleboxIOClass
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance

        status.StartTest = True

    End Sub

    '************************************** Abort Button Event Handler  ************************************************
    '
    '   The Abort test button has been pressed
    '
    Private Sub btnAbort_Click(sender As System.Object, e As System.EventArgs) Handles btnAbort.Click
        '
        '   Set the StatusClass.AbortTest property to True to signal a Abort test to the ShuttleboxIOClass
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance

        status.AbortTest = True

    End Sub


    '************************************** Results File Folder Browse Button Event Handler  ************************************************
    '
    '   
    Private Sub btnResultsFolderBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnResultsFolderBrowse.Click
        '
        '   Bring up the Folder Browser dialog to choose a folder path for the output results file. 
        ' 
        Dim resultsFolderDialog As New FolderBrowserDialog
        resultsFolderDialog.SelectedPath = txtResultFolderPath.Text

        Dim result As DialogResult = resultsFolderDialog.ShowDialog()

        If (result = DialogResult.OK) Then
            txtResultFolderPath.Text = resultsFolderDialog.SelectedPath

        End If
    End Sub


    '************************************** Results File Name Select Button Event Handler  ************************************************
    '
    '   Bring up the File selection dialog to select or create a results output filename
    '   The path and filename are split for display in separate textboxes on the MainForm
    '
    Private Sub btnOpenFileBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenFileBrowse.Click

        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim openFileDialog As New OpenFileDialog()
        Dim strFilePathandName As String = ""
        Dim strFileName As String = ""
        Dim strFilePath As String = ""

        openFileDialog.InitialDirectory = txtResultFolderPath.Text
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = False
        openFileDialog.AddExtension = True
        openFileDialog.DefaultExt = ".txt"
        openFileDialog.CheckFileExists = False

        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            strFilePathandName = openFileDialog.FileName
            '
            '   Find the last "\" in the string
            '
            Dim position As Integer = strFilePathandName.LastIndexOf("\"c)
            '
            '   The filename starts after the position of the last "\", put it in the ResultFilename textbox
            '
            txtResultFilename.Text = strFilePathandName.Substring(position + 1)
            '
            '   The file path ends with the \, put it in the ResultFolderPath textbox
            '
            txtResultFolderPath.Text = strFilePathandName.Substring(0, position)

        End If

    End Sub

    '************************************** Configuration Param Button Event Handler  ************************************************
    '
    Private Sub btnConfigParams_Click(sender As System.Object, e As System.EventArgs) Handles btnConfigParams.Click
        '
        '   The Configurations Parameters button was clicked - Show the ConfigForm
        '   The ConfigForm takes seconds to load, because it reads in config parameters from the default file and the Arduino,
        
        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   Show a loading notice while waiting for the Arduino parameter read to complete
        '
        Dim Point As New Point
        Point.X = Me.Location.X + 50
        Point.Y = Me.Location.Y + 50
        frmConfigFormLoading.Show()
        frmConfigFormLoading.Location = Point
        '
        '   Set the flag to indicate this parameter read is due to the Config form loading
        '   Used in the ConfigParamReadComplete method to differentiate between the Arduino Read
        '   and the Config Load operations
        '
        blnConfigFormButton = True
        '
        '   Initiate the Arduino Parameter Read process
        status.ReadArduinoConfigParams = True
        '
        '   The Arduino config parameter read is implemented by the ShuttleboxIOClass and
        '   then completed in the MainForm BackgroundWorker ProgressChanged Event Handler
        '


    End Sub

    '************************************** Arduino Configuration Param Read Complete  ************************************************
    '
    Private Sub ConfigParamReadComplete()
        '
        '   Complete the config parameter read process for the ConfigForm.
        '   This Sub is called after the IOClass completes the parameter read from the Arduino (ProgressPercentage = 10)
        '   
        Dim status As StatusClass
        status = StatusClass.GetInstance

        '
        '   Parameter Read completed - load parameters in ConfigForm text boxes
        '
        frmConfigForm.txtNumberOfTrials.Text = status.NumberOfTrials.ToString
        frmConfigForm.txtSelectionMode.Text = status.SelectionMode
        frmConfigForm.txtSettleTime.Text = status.SettleTime.ToString
        frmConfigForm.txtTrialDuration.Text = status.TrialDuration.ToString
        frmConfigForm.txtSeekTime.Text = status.SeekTime.ToString
        frmConfigForm.txtInterTrialSettleTime.Text = status.InterTrialSettleTime.ToString
        frmConfigForm.txtSettleLight.Text = status.SettleLight
        frmConfigForm.txtAcceptLight.Text = status.AcceptLight
        frmConfigForm.txtRejectLight.Text = status.RejectLight
        frmConfigForm.txtWaitForStartLight.Text = status.WaitForStartLight
        frmConfigForm.txtFaultOutTrials_Percent.Text = status.FaultOutTrials_Percent.ToString
        frmConfigForm.txtFaultOutTrials_SideSwaps.Text = status.FaultOutTrials_SideSwaps.ToString
        frmConfigForm.txtFaultOutPercent.Text = status.FaultOutPercent.ToString
        frmConfigForm.txtShockVoltage.Text = status.ShockVoltage.ToString
        frmConfigForm.txtShockInterval.Text = status.ShockInterval.ToString
        frmConfigForm.txtShockDuration.Text = status.ShockDuration.ToString
        frmConfigForm.txtSuccessTrials.Text = status.SuccessTrials.ToString
        '
        '   Write parameters to Logfile
        '
        If status.LogFileWrite Then
            Try
                File.AppendAllText(status.LogFilename, "Arduino Config Params Read at: " & Format(Now, "MM/dd/yyyy HH:mm:ss" & vbCrLf))

                Dim strParamsString As String = status.NumberOfTrials & " | " & status.SelectionMode & " | " & status.SettleTime &
                " | " & status.TrialDuration & " | " & status.SeekTime & " | " & status.InterTrialSettleTime & " | " & status.SettleLight &
                " | " & status.AcceptLight & " | " & status.RejectLight & " | " & status.WaitForStartLight &
                " | " & status.FaultOutTrials_Percent & " | " & status.FaultOutTrials_SideSwaps & " | " & status.FaultOutPercent & " | " & status.ShockVoltage &
                " | " & status.ShockInterval & " | " & status.ShockDuration & " | " & status.SuccessTrials & vbCrLf & vbCrLf

                File.AppendAllText(status.LogFilename, strParamsString)
            Catch ex As Exception
                MessageBox.Show("Logfile write failed for Arduino config params read: " & ex.Message)
            End Try
        End If
        '
        '   Re-enable the button to show complete
        '
        frmConfigForm.btnReadConfigParams.Enabled = True
        '
        '   Set title to Arduino
        '
        frmConfigForm.lblParamsTitle.Text = "Arduino Params"
        '
        '   If this Arduino Read was part of the Config Form loading
        '   Hide the loading notice & reload the default params
        '
        If blnConfigFormButton Then
            '
            '   Hide the loading notice
            '
            frmConfigFormLoading.Hide()
            '
            '   Load the Default Parameter column and show the ConfigForm
            '
            frmConfigForm.LoadDefaultParams()

            blnConfigFormButton = False
        End If
        
        '   Show the form
        frmConfigForm.Show()
        frmConfigForm.Focus()


    End Sub
End Class