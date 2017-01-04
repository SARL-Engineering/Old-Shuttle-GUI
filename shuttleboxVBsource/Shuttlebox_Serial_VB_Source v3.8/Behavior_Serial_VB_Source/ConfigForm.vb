Imports System.Environment
Imports System.Threading
Imports System.IO

Public Class ConfigForm
    '
    '   This form supports management of the test configuration parameters for the Shuttlebox Behavior System.
    '   Components:
    '           1. System Default Config File: displays the path & filename of the system default config file - if one has been designated. 
    '           2. Configuration File textbox: displays the filename of a configuration file selected for loading into the parameter list.
    '           2. Test Parameters: list of the test parameter names used to configure Shuttlebox tests
    '           3. Default/Config Parameters: column of parameter values representing either the current (hardcoded or System) default parameter set
    '               or the parameter set read in from the configuration file specified in #2.
    '           4. Arduino Parameters: at form-load, the right-hand column of parameter values displays the current set of parameters in
    '               the Arduino.  This column of parameters can be modified, and then represents a parameter set that 
    '               can be downloaded to the Arduino when the "Download" button is clicked.  The parameter values can be modified by:
    '                   a. Transferring the Default/Config column of parameters into the Arduino column.
    '                   b. Typing directly into the parameter value textbox in the Arduino column.
    '           5. The "Read from Arduino" button will re-read the Arduino parameters into the Arduino column.
    '               Note: the "Arduino" column title changes to reflect what is in the parameter values at the time:
    '                   (i)     Arduino Params: the parameter values read from the Arduino - represents currently used test values in the Arduino
    '                   (ii)    Default Params: the default parameter set has been moved from the Default column into this column
    '                   (iii)   Config Params: The parameter set read in from the Configuration file have been moved into this column
    '                   (iv)    Custom Params: A parameter value has been modified by typing directly into the textbox
    '
    '           5. "Browse" button: click to open the Windows File Selection dialog to select a configuration file to read in.  The config file parameters
    '                               are read into the Default parameter column and the column title is changed to Config Params.
    '           6. "Reset to Defaults" button: click to reload the hardcoded default parameter set into the Default column.  The column name is changed back to
    '                                           Default Params.
    '           7. "Download" button: click to download the parameters is the righthand column to the Arduino.  The column title will represent the source of
    '                               of the parameter set as presented above for the "Arduino" column titles.
    '           8. "Read from Arduino" button: click to read the current Arduino config parameter set and load into the righthand column.  The column title is changed
    '                                   to Arduino Params.
    '           9. "Set To Defaults" or "Set to Config" button: click to transfer the middle column (either Defaults or Config file params) into the righthand
    '                                                           column.
    '           10. "Close" button: This button replaces the Windows "x" close button in the upper right corner of the form.  It hides the ConfigForm instead of 
    '               closing it.  The form is a single instance form so it cannot be closed.  It is hidden, then re-shown to retain it's state and entries in tact.
    '
    '
    '**************  Class Variables  ******************
    '   Declare an ErrorProvider to be used as a warning
    '
    Public warningProvider As ErrorProvider = New ErrorProvider()

    '************************  Disable Windows Close Button  *****************************
    '
    '   Disable the Windows Close button ("x") on the form
    '   Only one instance of this form is declared, so it must be Hidden instead of Closed.
    '
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property

    '************************  ConfigForm Load Handler  *****************************
    '
    Private Sub ConfigForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '
        '   Set up the Warning icon for warningProvider to use for the Configuration parameters
        '
        Dim icon1 As New Icon("Deleket-Soft-Scraps-Button-Warning.ico")
        warningProvider.Icon = icon1
        warningProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink
        '
        '   Set the Config Form title to reflect the current Shuttlebox number
        '
        lblBoxNum.Text = "Shuttlebox " & MainForm.intBoxNum

    End Sub


    '************************  Sub to Read Arduino Config Parameters  *****************************
    '
    '   Initiates the Arduino parameter set read (handled by the ShuttleboxIOClass thread).
    '   The read process is completed in the MainForm backgroundworker event handler after the IOClass completes the read
    '
    Private Sub ReadArduinoConfigParams()
        '
        '   Disable the button to show Read underway
        '
        btnReadConfigParams.Enabled = False
        '
        '   Set status flag to prompt read from Arduino by ShuttleboxIOClass
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance

        status.ReadArduinoConfigParams = True

        '   The Arduino config parameter read is implemented by the ShuttleboxIOClass and
        '   then completed in the MainForm BackgroundWorker ProgressChanged Event Handler
        '

    End Sub




    '************************  Download Button Handler  *****************************
    '
    Private Sub btnDownloadConfigParams_Click(sender As System.Object, e As System.EventArgs) Handles btnDownloadConfigParams.Click
        '
        '   Starts the process to download the config parameters to the Arduino.
        '   Set Download Request in StatusClass to trigger download in ShuttleboxIOClass
        '   Uses the StatusClass properties to pass the parameters to the ShuttleBoxIOClass server.
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   First, verify that the config parameters are all valid
        '
        ErrorProvider1.Clear()
        warningProvider.Clear()
        VerifyDefaultParameters()
        If VerifyTextboxParameters() = False Then
            '
            '   There was an invalid parameter - do not download; Exit Sub
            '   The errors are flagged on the form using ErrorProvider
            '
            MessageBox.Show("Invalid parameter value(s); correct errors and click Download again", "Invalid Parameter Values")
            Exit Sub
        End If
        '
        '   Disable the buttons while download is underway
        '
        btnDownloadConfigParams.Enabled = False
        btnClose.Enabled = False
        btnReadConfigParams.Enabled = False
        btnResetDefaults.Enabled = False
        btnConfigBrowse.Enabled = False
        btnTransferValues.Enabled = False
        '
        '   Transfer new Config Parameters to StatusClass
        '
        status.NumberOfTrials = Integer.Parse(txtNumberOfTrials.Text)
        status.SelectionMode = txtSelectionMode.Text
        status.SettleTime = Integer.Parse(txtSettleTime.Text)
        status.TrialDuration = Integer.Parse(txtTrialDuration.Text)
        status.SeekTime = Integer.Parse(txtSeekTime.Text)
        status.InterTrialSettleTime = Integer.Parse(txtInterTrialSettleTime.Text)
        status.SettleLight = txtSettleLight.Text
        status.AcceptLight = txtAcceptLight.Text
        status.RejectLight = txtRejectLight.Text
        status.WaitForStartLight = txtWaitForStartLight.Text
        status.FaultOutTrials_Percent = Integer.Parse(txtFaultOutTrials_Percent.Text)
        status.FaultOutTrials_SideSwaps = Integer.Parse(txtFaultOutTrials_SideSwaps.Text)
        status.FaultOutPercent = Integer.Parse(txtFaultOutPercent.Text)
        status.ShockVoltage = Decimal.Parse(txtShockVoltage.Text)
        status.ShockInterval = Integer.Parse(txtShockInterval.Text)
        status.ShockDuration = Integer.Parse(txtShockDuration.Text)
        status.SuccessTrials = Integer.Parse(txtSuccessTrials.Text)
        '
        '   Set Download Request in StatusClass to trigger download in ShuttleboxIOClass
        '
        status.DownloadConfigParams = True

    End Sub

    '************************  'Read from Arduino' Button Handler  *****************************
    '
    Private Sub btnReadConfigParams_Click(sender As System.Object, e As System.EventArgs) Handles btnReadConfigParams.Click
        '
        '   Read the Arduino Config Parameters
        '
        ReadArduinoConfigParams()


    End Sub

    '************************  Reset to Defaults Button Handler  *****************************
    '
    Private Sub btnResetDefaults_Click(sender As System.Object, e As System.EventArgs) Handles btnResetDefaults.Click

        '
        '   Reset the Default column to the selected Default Config file, or
        '   if no default config file is selected, the hardcoded program default params
        '
        If ResetSystemConfigFileParams() Then
            '   Success - do nothing
        Else
            '   Either no Default Config file is selected, or the read failed
            '   Load the Program Defaults

            ResetProgramDefaultParams()

        End If


    End Sub

    '************************  Close Button Handler  *****************************
    '
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        '
        '   Close the Config parameters
        '
        Me.Hide()

    End Sub

    '************************  Transfer Values Button Handler  *****************************
    '
    Private Sub btnTransferValues_Click(sender As System.Object, e As System.EventArgs) Handles btnTransferValues.Click
        '
        '   Move the Default (or Config) column parameters into the Current Configs Column
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance

        '
        '   Move Default/Config values into the parameter text boxes
        '
        txtNumberOfTrials.Text = lblDefaultNumberOfTrials.Text
        txtSelectionMode.Text = lblDefaultSelectionMode.Text
        txtSettleTime.Text = lblDefaultSettleTime.Text
        txtTrialDuration.Text = lblDefaultTrialDuration.Text
        txtSeekTime.Text = lblDefaultSeekTime.Text
        txtInterTrialSettleTime.Text = lblDefaultInterTrialSettleTime.Text
        txtSettleLight.Text = lblDefaultSettleLight.Text
        txtAcceptLight.Text = lblDefaultAcceptLight.Text
        txtRejectLight.Text = lblDefaultRejectLight.Text
        txtWaitForStartLight.Text = lblDefaultWaitForStartLight.Text
        txtFaultOutTrials_Percent.Text = lblDefaultFaultOutTrials_Percent.Text
        txtFaultOutTrials_SideSwaps.Text = lblDefaultFaultOutTrials_SideSwaps.Text
        txtFaultOutPercent.Text = lblDefaultFaultOutPercent.Text
        txtShockVoltage.Text = lblDefaultShockVoltage.Text
        txtShockInterval.Text = lblDefaultShockInterval.Text
        txtShockDuration.Text = lblDefaultShockDuration.Text
        txtSuccessTrials.Text = lblDefaultSuccessTrials.Text
        '
        '   Set the Column Title to reflect its new contents as Default, System or Config params
        '
        lblParamsTitle.Text = lblDefaultParamsTitle.Text

    End Sub


    '************************************** Text Changed in Config Parameters Event Handler  ************************************************
    '
    Private Sub Parameters_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumberOfTrials.TextChanged, txtSelectionMode.TextChanged,
        txtSettleTime.TextChanged, txtTrialDuration.TextChanged, txtSeekTime.TextChanged, txtInterTrialSettleTime.TextChanged, txtSettleLight.TextChanged,
        txtAcceptLight.TextChanged, txtRejectLight.TextChanged, txtWaitForStartLight.TextChanged, txtFaultOutTrials_Percent.TextChanged, txtFaultOutTrials_SideSwaps.TextChanged, txtFaultOutPercent.TextChanged,
        txtShockVoltage.TextChanged, txtShockInterval.TextChanged, txtShockDuration.TextChanged, txtSuccessTrials.TextChanged
        '
        '   One of the config parameter textboxes has been changed by the operator.
        '   Update the column title to reflect it now contains custom parameters
        '
        lblParamsTitle.Text = "Custom Params"
        '
        '   Verify the parameters to catch an entry error
        '
        ErrorProvider1.Clear()
        warningProvider.Clear()
        VerifyTextboxParameters()
        VerifyDefaultParameters()

    End Sub



    '************************************** Config file "Browse" Button Event Handler  ************************************************
    '
    Private Sub btnConfigBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnConfigBrowse.Click

        ' Bring up a dialog to choose an existing file for the Config file. 
        ' Show the OpenFileBrowserDialog. 

        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim openFileDialogConfigFile As New OpenFileDialog()
        Dim strFileName As String = ""
        Dim sErrorMessage As String = ""

        '   First, if there's a filename already in the text box, use it
        If txtConfigFileName.Text <> "" Then
            openFileDialogConfigFile.InitialDirectory = txtConfigFileName.Text  ' If a config file name is in the textbox, go back to the directory

            '   Else, use the last config file that was loaded
        ElseIf status.LastConfigFileName <> "" Then
            openFileDialogConfigFile.InitialDirectory = status.LastConfigFileName  ' The textbox is empty, so if there's a path/name in StatusClass - open it.

            '   Finally, go to the default Config Files folder on the desktop - create it if it's not already there.
        Else
            Dim strConfigFileFolder As String = "Shuttle Box Config Files"
            Dim sFullPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), strConfigFileFolder)
            If Not System.IO.Directory.Exists(sFullPath) Then
                System.IO.Directory.CreateDirectory(sFullPath)
            End If
            openFileDialogConfigFile.InitialDirectory = sFullPath

        End If

        openFileDialogConfigFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialogConfigFile.FilterIndex = 1
        openFileDialogConfigFile.RestoreDirectory = False
        openFileDialogConfigFile.AddExtension = True
        openFileDialogConfigFile.DefaultExt = ".txt"
        openFileDialogConfigFile.CheckFileExists = True

        If openFileDialogConfigFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            strFileName = openFileDialogConfigFile.FileName

            '
            '   Load the filename into the form textbox and the StatusClass LastConfigFile property
            '
            txtConfigFileName.Text = strFileName
            status.LastConfigFileName = strFileName
            '
            '   Load the selected Config file into the old defaults column
            '
            If LoadConfigFile(strFileName, sErrorMessage) Then
                '   Config File read success:
                '   Change the title on the Default column to Config Params
                '
                lblDefaultParamsTitle.Text = "Config File Params"

            Else
                '
                '   Config File Read Failed - display error and restore defaults
                '
                MessageBox.Show("Config File Read Failed = Default params restored" & vbCrLf & "Error Message: " & sErrorMessage)
                ResetProgramDefaultParams()
                lblDefaultParamsTitle.Text = "Default Params"
            End If
            '
            '   Close button on OpenDialog form - do nothing
            '
        End If


    End Sub



    '************************  Load Default Parameter Column  *****************************
    '
    Public Sub LoadDefaultParams()
        '
        '   Determines which source from which the default parameters are to be loaded
        '   and calls the appropriate sub to load the default column.
        '   The order of precedence of the sources to load default parameters is:
        '   1) Configuration File field; 2) System Config File; 3) Hardcoded Default parameters
        '
        Dim sErrorMessage As String = ""
        '
        '   Try to load the selected Config File if the field is not empty
        '
        If txtConfigFileName.Text <> "" Then
            If LoadConfigFile(txtConfigFileName.Text, sErrorMessage) Then
                '  Success - Do nothing
            Else
                '   Read failed - show error message & reset Config File field to blank
                MessageBox.Show(sErrorMessage)
                txtConfigFileName.Text = ""
            End If
        End If
        '
        '   If no Config file is listed, try to load the System Config file
        '
        If txtConfigFileName.Text = "" Then

            If ResetSystemConfigFileParams() Then
                '   Success - do nothing
            Else
                '   Either no System Config file is selected, or the read failed
                '
                '   Load the Program Defaults
                '
                ResetProgramDefaultParams()

            End If
        End If
    End Sub


    '************************  Reset Parameters to System Config values  *****************************
    '
    Private Function ResetSystemConfigFileParams() As Boolean
        '
        '   Resets the Default column to the values in the System Configuration File
        '
        Dim strSystemConfigFile As String = ""
        Dim sErrorMessage As String = ""
        Dim strPath As String = ""
        Dim strFileName As String = ""

        '
        '   Get the System Default Config File path\name, if it exists
        '
        strSystemConfigFile = GetSystemConfigFileName()

        '
        '   If a System Config File Name was found - read the config parameters from the Config file
        '
        If strSystemConfigFile <> "" Then

            If LoadConfigFile(strSystemConfigFile, sErrorMessage) Then
                '   Successful read - put the System Config File name in the labels
                '       in case the file changed since the form was opened.
                '
                SeparateFilePathAndName(strSystemConfigFile, strPath, strFileName)
                lblDefaultPath.Text = strPath
                lblDefaultName.Text = strFileName
                '
                '   Set Title to show System Config File
                '
                lblDefaultParamsTitle.Text = "System Params"
                '
                '   Clear the Config File Name textbox
                '
                txtConfigFileName.Text = ""

                Return True

            Else
                '   Read failed, post error and return False
                MessageBox.Show(sErrorMessage)
                Return False
            End If
        Else
            '   No Default Config File found - clear the Default Config file labels
            '   and return False
            '
            lblDefaultPath.Text = ""
            lblDefaultName.Text = ""
            Return False

        End If

    End Function


    '************************  Reset Default Parameters to Hardcoded Program values  *****************************
    '
    Private Sub ResetProgramDefaultParams()
        '
        '   Resets the Default column to the hardcoded default values declared in MainForm
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   Move hardcoded Default values from Main form into the Default parameter labels
        '
        With MainForm
            lblDefaultNumberOfTrials.Text = .intNumberOfTrials.ToString
            lblDefaultSelectionMode.Text = .strSelectionMode
            lblDefaultSettleTime.Text = .intSettleTime.ToString
            lblDefaultTrialDuration.Text = .intTrialDuration.ToString
            lblDefaultSeekTime.Text = .intSeekTime.ToString
            lblDefaultInterTrialSettleTime.Text = .intInterTrialSettleTime.ToString
            lblDefaultSettleLight.Text = .strSettleLight
            lblDefaultAcceptLight.Text = .strAcceptLight
            lblDefaultRejectLight.Text = .strRejectLight
            lblDefaultWaitForStartLight.Text = .strWaitForStartLight
            lblDefaultFaultOutTrials_Percent.Text = .intFaultOutTrials_Percent.ToString
            lblDefaultFaultOutTrials_SideSwaps.Text = .intFaultOutTrials_SideSwaps.ToString
            lblDefaultFaultOutPercent.Text = .intFaultOutPercent.ToString
            lblDefaultShockVoltage.Text = .decShockVoltage.ToString
            lblDefaultShockInterval.Text = .intShockInterval.ToString
            lblDefaultShockDuration.Text = .intShockDuration.ToString
            lblDefaultSuccessTrials.Text = .intSuccessTrials.ToString
        End With
        '
        '   Set Title to Defaults
        '
        lblDefaultParamsTitle.Text = "Default Params"
        '
        '   Clear the Config File Name textbox
        '
        txtConfigFileName.Text = ""
        '
        '   Clear any previous errors and verify parameters
        '
        ErrorProvider1.Clear()
        warningProvider.Clear()
        VerifyDefaultParameters()
        VerifyTextboxParameters()

    End Sub


    '************************  Sub to Locate System Config File Container  *****************************
    '
    '   This sub locates the container file holding the System Config file name and
    '   reads and returns the file path\name. 
    '   An existing Config File can be identified as the System default config parameters using the separate VB application 
    '   ShuttleBox_Select_Default_File.  
    '
    Private Function GetSystemConfigFileName() As String

        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim strDefaultConfigFile As String = ""
        '
        '   Check for the existence of the container file that holds the default Config File name
        '
        Dim srContainerFile As IO.StreamReader

        If IO.File.Exists(status.strDefaultConfigContainerPathAndName) Then
            '
            '   The container file exists, so read the current Default Config File Path\Name
            '
            Try
                srContainerFile = IO.File.OpenText(status.strDefaultConfigContainerPathAndName)
                strDefaultConfigFile = srContainerFile.ReadLine
                srContainerFile.Close()
                Return strDefaultConfigFile
            Catch ex As Exception
                MessageBox.Show("Error reading Config File name from Container file:" & vbCrLf &
                                "System Error Message:  " & ex.Message &
                                vbCrLf & vbCrLf & "Hardcoded default configuration parameters will be used.")
                strDefaultConfigFile = ""
                Return strDefaultConfigFile
            End Try
        Else
            '
            '   Container does not exist, so return empty file name
            '
            Return strDefaultConfigFile

        End If

    End Function

    '************************  Sub to separate a file path\name  *****************************
    '
    '   This sub takes a full path\name string for a file and separates it into separate string variables for path and name
    '
    Private Sub SeparateFilePathAndName(ByVal strPathAndName As String, ByRef strPath As String, ByRef strFileName As String)

        '
        '   Find the last "\" in the string
        '
        Dim position As Integer = strPathAndName.LastIndexOf("\"c)
        '
        '   The filename starts after the position of the last "\", put it in the strFileName
        '
        strFileName = strPathAndName.Substring(position + 1)
        '
        '   The file path ends with the \, put it in the strPath
        '
        strPath = strPathAndName.Substring(0, position)

    End Sub


    '************************  Load Config File Function  *****************************
    '
    Private Function LoadConfigFile(ByVal sConfigFileName As String, ByRef sErrorMessage As String) As Boolean
        '
        '   Opens and reads the specified Configuration file.
        '   Places config parameters into the Default Params column and renames the column to Config Params
        '
        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim oRead As System.IO.StreamReader ' used to read in the file
        Dim blnGoodData As Boolean = True
        sErrorMessage = ""

        '
        ' Open the configuration file using ConfigFileName
        '
        Try
            oRead = IO.File.OpenText(sConfigFileName)
        Catch ex As Exception
            sErrorMessage = "Configuration File Open Error: " & ex.Message & vbCrLf & vbCrLf & "The hardcoded configuration parameters will be used."
            Return False
        End Try

        '***********  Read and verify the Config Parameters  ***********
        Try

            oRead.ReadLine()                                  '   Read and ignore the Config Parameters title
            oRead.ReadLine()                                  '   Read and ignore the Number of Trials title

            ' Read Number of Trials
            MainForm.frmConfigForm.lblDefaultNumberOfTrials.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Selection Mode title

            ' Read Selection Mode
            MainForm.frmConfigForm.lblDefaultSelectionMode.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Settle Time title

            ' Read Settle Time
            MainForm.frmConfigForm.lblDefaultSettleTime.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Trial Duration Time title

            ' Read Trial Duration Time
            MainForm.frmConfigForm.lblDefaultTrialDuration.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Seek Time title

            ' Read and verify Seek Time
            MainForm.frmConfigForm.lblDefaultSeekTime.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Inter-Trial Settle Time title

            ' Read Inter-Trial Settle Time
            MainForm.frmConfigForm.lblDefaultInterTrialSettleTime.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Settle Light title

            ' Read Settle Light
            MainForm.frmConfigForm.lblDefaultSettleLight.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Accept Light title

            ' Read Accept Light
            MainForm.frmConfigForm.lblDefaultAcceptLight.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Reject Light title

            ' Read Reject Light
            MainForm.frmConfigForm.lblDefaultRejectLight.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Wait-for-Start Light title

            ' Read Wait-for-Start Light
            MainForm.frmConfigForm.lblDefaultWaitForStartLight.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Fault Out Trials - Percent title

            ' Read Wait for Fault Out Trials - Percent
            MainForm.frmConfigForm.lblDefaultFaultOutTrials_Percent.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Fault Out Trials - SideSwaps title

            ' Read Wait for Fault Out Trials - SideSwaps
            MainForm.frmConfigForm.lblDefaultFaultOutTrials_SideSwaps.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Fault Out Percent title

            ' Read and verifty Fault Out Percent
            MainForm.frmConfigForm.lblDefaultFaultOutPercent.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Shock Voltage title

            ' Read and verify Shock Voltage
            MainForm.frmConfigForm.lblDefaultShockVoltage.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Shock Interval title

            ' Read Shock Interval Time
            MainForm.frmConfigForm.lblDefaultShockInterval.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Shock Duration title

            ' Read and verifty Shock Duration
            MainForm.frmConfigForm.lblDefaultShockDuration.Text = oRead.ReadLine

            oRead.ReadLine()                                  '   Read and ignore the Success Trials title

            ' Read Wait for SuccessTrials
            MainForm.frmConfigForm.lblDefaultSuccessTrials.Text = oRead.ReadLine

        Catch ex As Exception
            blnGoodData = False
            sErrorMessage = "Config File Read Error: " & ex.Message
        End Try
        '
        '   Close the file
        '
        oRead.Close()

        '
        '   Verify that the config parameters loaded from the file are valid
        '   The Verify function will flag the parameter errors on the form using ErrorProvider
        '
        MainForm.frmConfigForm.ErrorProvider1.Clear()
        MainForm.frmConfigForm.warningProvider.Clear()
        MainForm.frmConfigForm.VerifyDefaultParameters()
        MainForm.frmConfigForm.VerifyTextboxParameters()

        Return blnGoodData

    End Function


    '************************************** Verify the Default Parameters Column  ************************************************
    '
    Private Function VerifyDefaultParameters() As Boolean
        '
        '   Verifies the configuration parameters in the Default parameters column
        '
        Dim blnConfigParametersVerified = True
        Dim strColorError As String = ""
        Dim intTempParam1 As Integer
        Dim decTempParam As Decimal
        '
        '   Verify all the parameters parse to a valid value and
        '   their ranges are within bounds - includes errors and warnings
        '
        If Int32.TryParse(lblDefaultNumberOfTrials.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultNumberOfTrials, "Number of Trials must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtNumberOfTrials, "Number of Trials is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 50 And intTempParam1 <= 32000 Then
                warningProvider.SetError(lblDefaultNumberOfTrials, "Warning - Number of Trials is greater than 50")
            End If
        Else
            ErrorProvider1.SetError(lblDefaultNumberOfTrials, "Number of Trials must be an integer value")
            blnConfigParametersVerified = False
        End If

        '   Verify the selection mode text starts with "R"andom or "O"pposite.
        If Mid(lblDefaultSelectionMode.Text, 1, 1).ToUpper <> "R" And
                Mid(lblDefaultSelectionMode.Text, 1, 1).ToUpper <> "O" Then
            ErrorProvider1.SetError(lblDefaultSelectionMode, "Selection Mode must be Random or Opposite")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultSettleTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultSettleTime, "Settle Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultSettleTime, "Settle Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 2400 And intTempParam1 <= 32000 Then
                warningProvider.SetError(lblDefaultSettleTime, "Warning - Settle Time is greater than 2400 secs")
            End If
        Else
            ErrorProvider1.SetError(lblDefaultSettleTime, "Settle Time must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultTrialDuration.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultTrialDuration, "Trial Duration must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultTrialDuration, "Trial Duration is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 120 And intTempParam1 <= 32000 Then
                warningProvider.SetError(lblDefaultTrialDuration, "Warning - Trial Duration is greater than 120 secs")
            End If
        Else
            ErrorProvider1.SetError(lblDefaultTrialDuration, "Trial Duration must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultSeekTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultSeekTime, "Seek Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultSeekTime, "Seek Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultSeekTime, "Seek Time must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultInterTrialSettleTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultInterTrialSettleTime, "Inter-Trial Settle Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultInterTrialSettleTime, "Inter-Trial Settle Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 60 And intTempParam1 <= 32000 Then
                warningProvider.SetError(lblDefaultInterTrialSettleTime, "Warning - Inter-Trial Settle Time is greater than 60 secs")
            End If
        Else
            ErrorProvider1.SetError(lblDefaultInterTrialSettleTime, "Inter-Trial Settle Time must be an integer value")
            blnConfigParametersVerified = False
        End If
        '
        '   Verify the color parameters are valid colors
        '
        If VerifyColor(lblDefaultSettleLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(lblDefaultSettleLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(lblDefaultAcceptLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(lblDefaultAcceptLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(lblDefaultRejectLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(lblDefaultRejectLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(lblDefaultWaitForStartLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(lblDefaultWaitForStartLight, strColorError)
            blnConfigParametersVerified = False
        End If


        If Int32.TryParse(lblDefaultFaultOutTrials_Percent.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 20 Then
                ErrorProvider1.SetError(lblDefaultFaultOutTrials_Percent, "Fault Out Trials for Percent must be 1 - 20")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultFaultOutTrials_Percent, "Fault Out Trials for Percent must be an integer value 1-20")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultFaultOutTrials_SideSwaps.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 20 Then
                ErrorProvider1.SetError(lblDefaultFaultOutTrials_SideSwaps, "Fault Out Trials for SideSwaps must be 1 - 20")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultFaultOutTrials_SideSwaps, "Fault Out Trials for SideSwaps must be an integer value 1-20")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultFaultOutPercent.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 100 Then
                ErrorProvider1.SetError(lblDefaultFaultOutPercent, "Fault Out Percent must be 1 - 100")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultFaultOutPercent, "Fault Out Percent must be an integer value 1 - 100")
            blnConfigParametersVerified = False
        End If

        If Decimal.TryParse(lblDefaultShockVoltage.Text, decTempParam) Then
            If decTempParam > 50D Or decTempParam < 0.1D Then
                ErrorProvider1.SetError(lblDefaultShockVoltage, "Shock Voltage setting must be 0.1 - 50.0")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultShockVoltage, "Shock Voltage must be a decimal value: 0.1 - 50.0")
            blnConfigParametersVerified = False
        End If


        If Int32.TryParse(lblDefaultShockInterval.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultShockInterval, "Shock Interval must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultShockInterval, "Shock Interval is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 5000 And intTempParam1 <= 32000 Then
                warningProvider.SetError(lblDefaultShockInterval, "Warning - Shock Interval is greater than 5000 secs")
            End If
        Else
            ErrorProvider1.SetError(lblDefaultShockInterval, "Shock Interval must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultShockDuration.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(lblDefaultShockDuration, "Shock Duration must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(lblDefaultShockDuration, "Shock Duration is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultShockDuration, "Shock Duration must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(lblDefaultSuccessTrials.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 200 Then
                ErrorProvider1.SetError(lblDefaultSuccessTrials, "Success Trials must be 1 - 200")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(lblDefaultSuccessTrials, "Success Trials must be an integer value 1-200")
            blnConfigParametersVerified = False
        End If

        '
        '   Now, check parameter interdependencies for error conditions
        '
        '   Verify the seek time is less than the trial duration time
        '
        If ErrorProvider1.GetError(lblDefaultSeekTime) = "" And ErrorProvider1.GetError(lblDefaultTrialDuration) = "" Then
            If (Integer.Parse(lblDefaultSeekTime.Text) >= Integer.Parse(lblDefaultTrialDuration.Text)) Then
                ErrorProvider1.SetError(lblDefaultSeekTime, "Seek Time must be less than Trial Duration")
                blnConfigParametersVerified = False
            End If
        End If
        '
        '   Verify the Shock Duration is less than the Shock Interval
        '
        If ErrorProvider1.GetError(lblDefaultShockDuration) = "" And ErrorProvider1.GetError(lblDefaultShockInterval) = "" Then
            If (Integer.Parse(lblDefaultShockDuration.Text) >= Integer.Parse(lblDefaultShockInterval.Text)) Then
                ErrorProvider1.SetError(lblDefaultShockDuration, "Shock Duration must be less than Shock Interval")
                blnConfigParametersVerified = False
            End If
        End If

        If blnConfigParametersVerified = True Then
            Return True
        Else
            Return False
        End If

    End Function



    '************************************** Verify the TextBox Parameters Column  ************************************************
    '
    Public Function VerifyTextboxParameters() As Boolean
        '
        '   Verifies the configuration parameters in the textboxes column
        '
        Dim blnConfigParametersVerified = True
        Dim strColorError As String = ""
        Dim intTempParam1 As Integer
        Dim decTempParam As Decimal
        '
        '   Verify all the parameters parse to a valid value and
        '   their ranges are within bounds - includes errors and warnings
        '
        If Int32.TryParse(txtNumberOfTrials.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtNumberOfTrials, "Number of Trials must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtNumberOfTrials, "Number of Trials is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 50 And intTempParam1 <= 32000 Then
                warningProvider.SetError(txtNumberOfTrials, "Warning - Number of Trials is greater than 50")
            End If
        Else
            ErrorProvider1.SetError(txtNumberOfTrials, "Number of Trials must be an integer value")
            blnConfigParametersVerified = False
        End If

        '   Verify the selection mode text starts with "R"andom or "O"pposite.
        If Mid(txtSelectionMode.Text, 1, 1).ToUpper <> "R" And
                Mid(txtSelectionMode.Text, 1, 1).ToUpper <> "O" Then
            ErrorProvider1.SetError(txtSelectionMode, "Selection Mode must be Random or Opposite")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtSettleTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtSettleTime, "Settle Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtSettleTime, "Settle Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 2400 And intTempParam1 <= 32000 Then
                warningProvider.SetError(txtSettleTime, "Warning - Settle Time is greater than 2400 secs")
            End If
        Else
            ErrorProvider1.SetError(txtSettleTime, "Settle Time must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtTrialDuration.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtTrialDuration, "Trial Duration must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtTrialDuration, "Settle Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 120 And intTempParam1 <= 32000 Then
                warningProvider.SetError(txtTrialDuration, "Warning - Trial Duration is greater than 120 secs")
            End If
        Else
            ErrorProvider1.SetError(txtTrialDuration, "Trial Duration must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtSeekTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtSeekTime, "Seek Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtSeekTime, "Seek Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtSeekTime, "Seek Time must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtInterTrialSettleTime.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtInterTrialSettleTime, "Inter-Trial Settle Time must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtInterTrialSettleTime, "Inter-Trial Settle Time is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 60 And intTempParam1 <= 32000 Then
                warningProvider.SetError(txtInterTrialSettleTime, "Warning - Inter-Trial Settle Time is greater than 60 secs")
            End If
        Else
            ErrorProvider1.SetError(txtInterTrialSettleTime, "Inter-Trial Settle Time must be an integer value")
            blnConfigParametersVerified = False
        End If

        '
        '   Verify the color parameters are valid colors
        '
        If VerifyColor(txtSettleLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(txtSettleLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(txtAcceptLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(txtAcceptLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(txtRejectLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(txtRejectLight, strColorError)
            blnConfigParametersVerified = False
        End If
        If VerifyColor(txtWaitForStartLight.Text, strColorError) = False Then
            ErrorProvider1.SetError(txtWaitForStartLight, strColorError)
            blnConfigParametersVerified = False
        End If


        If Int32.TryParse(txtFaultOutTrials_Percent.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 20 Then
                ErrorProvider1.SetError(txtFaultOutTrials_Percent, "Fault Out Trials for Percent must 1 - 20")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtFaultOutTrials_Percent, "Fault Out Trials for Percent must be an integer value 1-20")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtFaultOutTrials_SideSwaps.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 20 Then
                ErrorProvider1.SetError(txtFaultOutTrials_SideSwaps, "Fault Out Trials for SideSwaps must be 1 - 20")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtFaultOutTrials_SideSwaps, "Fault Out Trials for SideSwaps must be an integer value 1-20")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtFaultOutPercent.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 100 Then
                ErrorProvider1.SetError(txtFaultOutPercent, "Fault Out Percent must be 1 - 100")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtFaultOutPercent, "Fault Out Percent must be an integer value 1 - 100")
            blnConfigParametersVerified = False
        End If

        If Decimal.TryParse(txtShockVoltage.Text, decTempParam) Then
            If decTempParam > 50D Or decTempParam < 0.1D Then
                ErrorProvider1.SetError(txtShockVoltage, "Shock Voltage setting must be 0.1 - 50.0")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtShockVoltage, "Shock Voltage must be a decimal value: 0.1 - 50.0")
            blnConfigParametersVerified = False
        End If


        If Int32.TryParse(txtShockInterval.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtShockInterval, "Shock Interval must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtShockInterval, "Shock Interval is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 5000 And intTempParam1 <= 32000 Then
                warningProvider.SetError(txtShockInterval, "Warning - Shock Interval is greater than 5000 milliseconds")
            End If
        Else
            ErrorProvider1.SetError(txtShockInterval, "Shock Interval must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtShockDuration.Text, intTempParam1) Then
            If intTempParam1 < 1 Then
                ErrorProvider1.SetError(txtShockDuration, "Shock Duration must be at least 1")
                blnConfigParametersVerified = False
            End If
            If intTempParam1 > 32000 Then
                ErrorProvider1.SetError(txtShockDuration, "Shock Duration is an integer and must be less than 32,000")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtShockDuration, "Shock Duration must be an integer value")
            blnConfigParametersVerified = False
        End If

        If Int32.TryParse(txtSuccessTrials.Text, intTempParam1) Then
            If intTempParam1 < 1 Or intTempParam1 > 200 Then
                ErrorProvider1.SetError(txtSuccessTrials, "Success Trials must be 1 - 200")
                blnConfigParametersVerified = False
            End If
        Else
            ErrorProvider1.SetError(txtSuccessTrials, "Success Trials must be an integer value 1-200")
            blnConfigParametersVerified = False
        End If

        '
        '   Now, check parameter interdependencies for error conditions
        '
        '   Verify the seek time is less than the trial duration time
        '
        If ErrorProvider1.GetError(txtSeekTime) = "" And ErrorProvider1.GetError(txtTrialDuration) = "" Then
            If (Integer.Parse(txtSeekTime.Text) >= Integer.Parse(txtTrialDuration.Text)) Then
                ErrorProvider1.SetError(txtSeekTime, "Seek Time must be less than Trial Duration")
                blnConfigParametersVerified = False
            End If
        End If
        '
        '   Verify the Shock Duration is less than the Shock Interval
        '
        If ErrorProvider1.GetError(txtShockDuration) = "" And ErrorProvider1.GetError(txtShockInterval) = "" Then
            If (Integer.Parse(txtShockDuration.Text) >= Integer.Parse(txtShockInterval.Text)) Then
                ErrorProvider1.SetError(txtShockDuration, "Shock Duration must be less than Shock Interval")
                blnConfigParametersVerified = False
            End If
        End If

        If blnConfigParametersVerified = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function VerifyColor(ByVal strColorText As String, ByRef strError As String) As Boolean
        '
        '   This function verifies a color parameter contains a valid color name
        '
        strError = "Light colors must be White, Red, Green, Blue or Off"

        Select Case strColorText.ToUpper
            Case "WHITE"
                Return True
            Case "RED"
                Return True
            Case "GREEN"
                Return True
            Case "BLUE"
                Return True
            Case "OFF"
                Return True
            Case Else
                Return False
        End Select
    End Function


End Class