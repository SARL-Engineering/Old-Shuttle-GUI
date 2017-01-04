<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigForm))
        Me.lblSelectionMode = New System.Windows.Forms.Label()
        Me.txtSelectionMode = New System.Windows.Forms.TextBox()
        Me.lblDefaultSelectionMode = New System.Windows.Forms.Label()
        Me.lblDefaultNumberOfTrials = New System.Windows.Forms.Label()
        Me.txtNumberOfTrials = New System.Windows.Forms.TextBox()
        Me.lblNumberOfTrials = New System.Windows.Forms.Label()
        Me.lblDefaultSettleTime = New System.Windows.Forms.Label()
        Me.txtSettleTime = New System.Windows.Forms.TextBox()
        Me.lblSettleTime = New System.Windows.Forms.Label()
        Me.lblDefaultShockVoltage = New System.Windows.Forms.Label()
        Me.txtShockVoltage = New System.Windows.Forms.TextBox()
        Me.lblShockVoltage = New System.Windows.Forms.Label()
        Me.lblDefaultSeekTime = New System.Windows.Forms.Label()
        Me.txtSeekTime = New System.Windows.Forms.TextBox()
        Me.lblSeekTime = New System.Windows.Forms.Label()
        Me.lblDefaultInterTrialSettleTime = New System.Windows.Forms.Label()
        Me.txtInterTrialSettleTime = New System.Windows.Forms.TextBox()
        Me.lblInterTrialSettleTime = New System.Windows.Forms.Label()
        Me.lblDefaultSettleLight = New System.Windows.Forms.Label()
        Me.txtSettleLight = New System.Windows.Forms.TextBox()
        Me.lblSettleLight = New System.Windows.Forms.Label()
        Me.lblConfigFormTitle = New System.Windows.Forms.Label()
        Me.btnResetDefaults = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReadConfigParams = New System.Windows.Forms.Button()
        Me.btnTransferValues = New System.Windows.Forms.Button()
        Me.txtConfigFileName = New System.Windows.Forms.TextBox()
        Me.btnDownloadConfigParams = New System.Windows.Forms.Button()
        Me.btnConfigBrowse = New System.Windows.Forms.Button()
        Me.lblParamsTitle = New System.Windows.Forms.Label()
        Me.lblDefaultParamsTitle = New System.Windows.Forms.Label()
        Me.lblConfigFileTitle = New System.Windows.Forms.Label()
        Me.OpenFileDialogConfigFile = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBoxNum = New System.Windows.Forms.Label()
        Me.lblDefaultTrialDuration = New System.Windows.Forms.Label()
        Me.txtTrialDuration = New System.Windows.Forms.TextBox()
        Me.lblTrialDuration = New System.Windows.Forms.Label()
        Me.lblDefaultAcceptLight = New System.Windows.Forms.Label()
        Me.txtAcceptLight = New System.Windows.Forms.TextBox()
        Me.lblAcceptLight = New System.Windows.Forms.Label()
        Me.lblDefaultRejectLight = New System.Windows.Forms.Label()
        Me.txtRejectLight = New System.Windows.Forms.TextBox()
        Me.lblRejectLight = New System.Windows.Forms.Label()
        Me.lblDefaultWaitForStartLight = New System.Windows.Forms.Label()
        Me.txtWaitForStartLight = New System.Windows.Forms.TextBox()
        Me.lblWaitForStartLight = New System.Windows.Forms.Label()
        Me.lblDefaultFaultOutTrials_SideSwaps = New System.Windows.Forms.Label()
        Me.txtFaultOutTrials_SideSwaps = New System.Windows.Forms.TextBox()
        Me.lblFaultOutTrials_SideSwaps = New System.Windows.Forms.Label()
        Me.lblDefaultFaultOutPercent = New System.Windows.Forms.Label()
        Me.txtFaultOutPercent = New System.Windows.Forms.TextBox()
        Me.lblFaultOutPercent = New System.Windows.Forms.Label()
        Me.lblDefaultShockInterval = New System.Windows.Forms.Label()
        Me.txtShockInterval = New System.Windows.Forms.TextBox()
        Me.lblShockInterval = New System.Windows.Forms.Label()
        Me.lblDefaultShockDuration = New System.Windows.Forms.Label()
        Me.txtShockDuration = New System.Windows.Forms.TextBox()
        Me.lblShockDuration = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDefaultFaultOutTrials_Percent = New System.Windows.Forms.Label()
        Me.txtFaultOutTrials_Percent = New System.Windows.Forms.TextBox()
        Me.lblFaultOutTrials_Percent = New System.Windows.Forms.Label()
        Me.lblDefault = New System.Windows.Forms.Label()
        Me.lblDefaultConfigFile = New System.Windows.Forms.Label()
        Me.lblDefaultPath = New System.Windows.Forms.Label()
        Me.lblDefaultName = New System.Windows.Forms.Label()
        Me.lblDefaultSuccessTrials = New System.Windows.Forms.Label()
        Me.txtSuccessTrials = New System.Windows.Forms.TextBox()
        Me.lblSuccessTrials = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSelectionMode
        '
        Me.lblSelectionMode.AutoSize = True
        Me.lblSelectionMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectionMode.Location = New System.Drawing.Point(11, 228)
        Me.lblSelectionMode.Name = "lblSelectionMode"
        Me.lblSelectionMode.Size = New System.Drawing.Size(93, 15)
        Me.lblSelectionMode.TabIndex = 3
        Me.lblSelectionMode.Text = "Selection Mode"
        '
        'txtSelectionMode
        '
        Me.txtSelectionMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectionMode.Location = New System.Drawing.Point(323, 225)
        Me.txtSelectionMode.Name = "txtSelectionMode"
        Me.txtSelectionMode.Size = New System.Drawing.Size(75, 21)
        Me.txtSelectionMode.TabIndex = 5
        '
        'lblDefaultSelectionMode
        '
        Me.lblDefaultSelectionMode.AutoSize = True
        Me.lblDefaultSelectionMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSelectionMode.Location = New System.Drawing.Point(191, 228)
        Me.lblDefaultSelectionMode.Name = "lblDefaultSelectionMode"
        Me.lblDefaultSelectionMode.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultSelectionMode.TabIndex = 4
        Me.lblDefaultSelectionMode.Text = "Default"
        Me.lblDefaultSelectionMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDefaultNumberOfTrials
        '
        Me.lblDefaultNumberOfTrials.AutoSize = True
        Me.lblDefaultNumberOfTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultNumberOfTrials.Location = New System.Drawing.Point(191, 202)
        Me.lblDefaultNumberOfTrials.Name = "lblDefaultNumberOfTrials"
        Me.lblDefaultNumberOfTrials.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultNumberOfTrials.TabIndex = 1
        Me.lblDefaultNumberOfTrials.Text = "Default"
        Me.lblDefaultNumberOfTrials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumberOfTrials
        '
        Me.txtNumberOfTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfTrials.Location = New System.Drawing.Point(323, 199)
        Me.txtNumberOfTrials.Name = "txtNumberOfTrials"
        Me.txtNumberOfTrials.Size = New System.Drawing.Size(75, 21)
        Me.txtNumberOfTrials.TabIndex = 2
        '
        'lblNumberOfTrials
        '
        Me.lblNumberOfTrials.AutoSize = True
        Me.lblNumberOfTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberOfTrials.Location = New System.Drawing.Point(11, 202)
        Me.lblNumberOfTrials.Name = "lblNumberOfTrials"
        Me.lblNumberOfTrials.Size = New System.Drawing.Size(115, 15)
        Me.lblNumberOfTrials.TabIndex = 0
        Me.lblNumberOfTrials.Text = "Total Number Trials"
        '
        'lblDefaultSettleTime
        '
        Me.lblDefaultSettleTime.AutoSize = True
        Me.lblDefaultSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSettleTime.Location = New System.Drawing.Point(191, 254)
        Me.lblDefaultSettleTime.Name = "lblDefaultSettleTime"
        Me.lblDefaultSettleTime.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultSettleTime.TabIndex = 7
        Me.lblDefaultSettleTime.Text = "Default"
        Me.lblDefaultSettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSettleTime
        '
        Me.txtSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSettleTime.Location = New System.Drawing.Point(323, 251)
        Me.txtSettleTime.Name = "txtSettleTime"
        Me.txtSettleTime.Size = New System.Drawing.Size(75, 21)
        Me.txtSettleTime.TabIndex = 8
        '
        'lblSettleTime
        '
        Me.lblSettleTime.AutoSize = True
        Me.lblSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettleTime.Location = New System.Drawing.Point(11, 254)
        Me.lblSettleTime.Name = "lblSettleTime"
        Me.lblSettleTime.Size = New System.Drawing.Size(66, 15)
        Me.lblSettleTime.TabIndex = 6
        Me.lblSettleTime.Text = "SettleTime"
        '
        'lblDefaultShockVoltage
        '
        Me.lblDefaultShockVoltage.AutoSize = True
        Me.lblDefaultShockVoltage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultShockVoltage.Location = New System.Drawing.Point(191, 540)
        Me.lblDefaultShockVoltage.Name = "lblDefaultShockVoltage"
        Me.lblDefaultShockVoltage.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultShockVoltage.TabIndex = 40
        Me.lblDefaultShockVoltage.Text = "Default"
        Me.lblDefaultShockVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtShockVoltage
        '
        Me.txtShockVoltage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShockVoltage.Location = New System.Drawing.Point(323, 537)
        Me.txtShockVoltage.Name = "txtShockVoltage"
        Me.txtShockVoltage.Size = New System.Drawing.Size(75, 21)
        Me.txtShockVoltage.TabIndex = 41
        '
        'lblShockVoltage
        '
        Me.lblShockVoltage.AutoSize = True
        Me.lblShockVoltage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShockVoltage.Location = New System.Drawing.Point(11, 540)
        Me.lblShockVoltage.Name = "lblShockVoltage"
        Me.lblShockVoltage.Size = New System.Drawing.Size(85, 15)
        Me.lblShockVoltage.TabIndex = 39
        Me.lblShockVoltage.Text = "Shock Voltage"
        '
        'lblDefaultSeekTime
        '
        Me.lblDefaultSeekTime.AutoSize = True
        Me.lblDefaultSeekTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSeekTime.Location = New System.Drawing.Point(191, 306)
        Me.lblDefaultSeekTime.Name = "lblDefaultSeekTime"
        Me.lblDefaultSeekTime.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultSeekTime.TabIndex = 13
        Me.lblDefaultSeekTime.Text = "Default"
        Me.lblDefaultSeekTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSeekTime
        '
        Me.txtSeekTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeekTime.Location = New System.Drawing.Point(323, 303)
        Me.txtSeekTime.Name = "txtSeekTime"
        Me.txtSeekTime.Size = New System.Drawing.Size(75, 21)
        Me.txtSeekTime.TabIndex = 14
        '
        'lblSeekTime
        '
        Me.lblSeekTime.AutoSize = True
        Me.lblSeekTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeekTime.Location = New System.Drawing.Point(11, 306)
        Me.lblSeekTime.Name = "lblSeekTime"
        Me.lblSeekTime.Size = New System.Drawing.Size(66, 15)
        Me.lblSeekTime.TabIndex = 12
        Me.lblSeekTime.Text = "Seek Time"
        '
        'lblDefaultInterTrialSettleTime
        '
        Me.lblDefaultInterTrialSettleTime.AutoSize = True
        Me.lblDefaultInterTrialSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultInterTrialSettleTime.Location = New System.Drawing.Point(191, 332)
        Me.lblDefaultInterTrialSettleTime.Name = "lblDefaultInterTrialSettleTime"
        Me.lblDefaultInterTrialSettleTime.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultInterTrialSettleTime.TabIndex = 16
        Me.lblDefaultInterTrialSettleTime.Text = "Default"
        Me.lblDefaultInterTrialSettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInterTrialSettleTime
        '
        Me.txtInterTrialSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterTrialSettleTime.Location = New System.Drawing.Point(323, 329)
        Me.txtInterTrialSettleTime.Name = "txtInterTrialSettleTime"
        Me.txtInterTrialSettleTime.Size = New System.Drawing.Size(75, 21)
        Me.txtInterTrialSettleTime.TabIndex = 17
        '
        'lblInterTrialSettleTime
        '
        Me.lblInterTrialSettleTime.AutoSize = True
        Me.lblInterTrialSettleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterTrialSettleTime.Location = New System.Drawing.Point(11, 332)
        Me.lblInterTrialSettleTime.Name = "lblInterTrialSettleTime"
        Me.lblInterTrialSettleTime.Size = New System.Drawing.Size(124, 15)
        Me.lblInterTrialSettleTime.TabIndex = 15
        Me.lblInterTrialSettleTime.Text = "Inter-Trial Settle Time"
        '
        'lblDefaultSettleLight
        '
        Me.lblDefaultSettleLight.AutoSize = True
        Me.lblDefaultSettleLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSettleLight.Location = New System.Drawing.Point(191, 358)
        Me.lblDefaultSettleLight.Name = "lblDefaultSettleLight"
        Me.lblDefaultSettleLight.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultSettleLight.TabIndex = 19
        Me.lblDefaultSettleLight.Text = "Default"
        Me.lblDefaultSettleLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSettleLight
        '
        Me.txtSettleLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSettleLight.Location = New System.Drawing.Point(323, 355)
        Me.txtSettleLight.Name = "txtSettleLight"
        Me.txtSettleLight.Size = New System.Drawing.Size(75, 21)
        Me.txtSettleLight.TabIndex = 20
        '
        'lblSettleLight
        '
        Me.lblSettleLight.AutoSize = True
        Me.lblSettleLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettleLight.Location = New System.Drawing.Point(11, 358)
        Me.lblSettleLight.Name = "lblSettleLight"
        Me.lblSettleLight.Size = New System.Drawing.Size(100, 15)
        Me.lblSettleLight.TabIndex = 18
        Me.lblSettleLight.Text = "Settle Light Color"
        '
        'lblConfigFormTitle
        '
        Me.lblConfigFormTitle.AutoSize = True
        Me.lblConfigFormTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfigFormTitle.Location = New System.Drawing.Point(10, 6)
        Me.lblConfigFormTitle.Name = "lblConfigFormTitle"
        Me.lblConfigFormTitle.Size = New System.Drawing.Size(219, 20)
        Me.lblConfigFormTitle.TabIndex = 59
        Me.lblConfigFormTitle.Text = "Configuration Parameters:"
        '
        'btnResetDefaults
        '
        Me.btnResetDefaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetDefaults.Location = New System.Drawing.Point(155, 166)
        Me.btnResetDefaults.Name = "btnResetDefaults"
        Me.btnResetDefaults.Size = New System.Drawing.Size(121, 25)
        Me.btnResetDefaults.TabIndex = 55
        Me.btnResetDefaults.Text = "Reset to Defaults"
        Me.btnResetDefaults.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(369, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 30)
        Me.btnClose.TabIndex = 52
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReadConfigParams
        '
        Me.btnReadConfigParams.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadConfigParams.Location = New System.Drawing.Point(295, 166)
        Me.btnReadConfigParams.Name = "btnReadConfigParams"
        Me.btnReadConfigParams.Size = New System.Drawing.Size(132, 25)
        Me.btnReadConfigParams.TabIndex = 56
        Me.btnReadConfigParams.Text = "Read from Arduino"
        Me.btnReadConfigParams.UseVisualStyleBackColor = True
        '
        'btnTransferValues
        '
        Me.btnTransferValues.Font = New System.Drawing.Font("Wingdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnTransferValues.Location = New System.Drawing.Point(264, 263)
        Me.btnTransferValues.Name = "btnTransferValues"
        Me.btnTransferValues.Size = New System.Drawing.Size(27, 268)
        Me.btnTransferValues.TabIndex = 54
        Me.btnTransferValues.Text = "à" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnTransferValues.UseVisualStyleBackColor = True
        '
        'txtConfigFileName
        '
        Me.txtConfigFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfigFileName.Location = New System.Drawing.Point(24, 105)
        Me.txtConfigFileName.Name = "txtConfigFileName"
        Me.txtConfigFileName.Size = New System.Drawing.Size(331, 22)
        Me.txtConfigFileName.TabIndex = 57
        '
        'btnDownloadConfigParams
        '
        Me.btnDownloadConfigParams.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownloadConfigParams.Location = New System.Drawing.Point(318, 650)
        Me.btnDownloadConfigParams.Name = "btnDownloadConfigParams"
        Me.btnDownloadConfigParams.Size = New System.Drawing.Size(87, 32)
        Me.btnDownloadConfigParams.TabIndex = 51
        Me.btnDownloadConfigParams.Text = "Download"
        Me.btnDownloadConfigParams.UseVisualStyleBackColor = True
        '
        'btnConfigBrowse
        '
        Me.btnConfigBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfigBrowse.Location = New System.Drawing.Point(365, 105)
        Me.btnConfigBrowse.Name = "btnConfigBrowse"
        Me.btnConfigBrowse.Size = New System.Drawing.Size(54, 23)
        Me.btnConfigBrowse.TabIndex = 53
        Me.btnConfigBrowse.Text = "Browse"
        Me.btnConfigBrowse.UseVisualStyleBackColor = True
        '
        'lblParamsTitle
        '
        Me.lblParamsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParamsTitle.Location = New System.Drawing.Point(282, 140)
        Me.lblParamsTitle.Name = "lblParamsTitle"
        Me.lblParamsTitle.Size = New System.Drawing.Size(161, 18)
        Me.lblParamsTitle.TabIndex = 58
        Me.lblParamsTitle.Text = "Arduino Params"
        Me.lblParamsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDefaultParamsTitle
        '
        Me.lblDefaultParamsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultParamsTitle.Location = New System.Drawing.Point(129, 140)
        Me.lblDefaultParamsTitle.Name = "lblDefaultParamsTitle"
        Me.lblDefaultParamsTitle.Size = New System.Drawing.Size(161, 18)
        Me.lblDefaultParamsTitle.TabIndex = 57
        Me.lblDefaultParamsTitle.Text = "Default Params"
        Me.lblDefaultParamsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblConfigFileTitle
        '
        Me.lblConfigFileTitle.AutoSize = True
        Me.lblConfigFileTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfigFileTitle.Location = New System.Drawing.Point(22, 86)
        Me.lblConfigFileTitle.Name = "lblConfigFileTitle"
        Me.lblConfigFileTitle.Size = New System.Drawing.Size(125, 15)
        Me.lblConfigFileTitle.TabIndex = 50
        Me.lblConfigFileTitle.Text = "Configuration File:"
        '
        'OpenFileDialogConfigFile
        '
        Me.OpenFileDialogConfigFile.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 18)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Test Parameters"
        '
        'lblBoxNum
        '
        Me.lblBoxNum.AutoSize = True
        Me.lblBoxNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxNum.Location = New System.Drawing.Point(224, 6)
        Me.lblBoxNum.Name = "lblBoxNum"
        Me.lblBoxNum.Size = New System.Drawing.Size(122, 20)
        Me.lblBoxNum.TabIndex = 60
        Me.lblBoxNum.Text = "Shuttlebox Num"
        '
        'lblDefaultTrialDuration
        '
        Me.lblDefaultTrialDuration.AutoSize = True
        Me.lblDefaultTrialDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultTrialDuration.Location = New System.Drawing.Point(191, 280)
        Me.lblDefaultTrialDuration.Name = "lblDefaultTrialDuration"
        Me.lblDefaultTrialDuration.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultTrialDuration.TabIndex = 10
        Me.lblDefaultTrialDuration.Text = "Default"
        Me.lblDefaultTrialDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTrialDuration
        '
        Me.txtTrialDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrialDuration.Location = New System.Drawing.Point(323, 277)
        Me.txtTrialDuration.Name = "txtTrialDuration"
        Me.txtTrialDuration.Size = New System.Drawing.Size(75, 21)
        Me.txtTrialDuration.TabIndex = 11
        '
        'lblTrialDuration
        '
        Me.lblTrialDuration.AutoSize = True
        Me.lblTrialDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrialDuration.Location = New System.Drawing.Point(11, 280)
        Me.lblTrialDuration.Name = "lblTrialDuration"
        Me.lblTrialDuration.Size = New System.Drawing.Size(81, 15)
        Me.lblTrialDuration.TabIndex = 9
        Me.lblTrialDuration.Text = "Trial Duration"
        '
        'lblDefaultAcceptLight
        '
        Me.lblDefaultAcceptLight.AutoSize = True
        Me.lblDefaultAcceptLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultAcceptLight.Location = New System.Drawing.Point(191, 384)
        Me.lblDefaultAcceptLight.Name = "lblDefaultAcceptLight"
        Me.lblDefaultAcceptLight.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultAcceptLight.TabIndex = 22
        Me.lblDefaultAcceptLight.Text = "Default"
        Me.lblDefaultAcceptLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAcceptLight
        '
        Me.txtAcceptLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcceptLight.Location = New System.Drawing.Point(323, 381)
        Me.txtAcceptLight.Name = "txtAcceptLight"
        Me.txtAcceptLight.Size = New System.Drawing.Size(75, 21)
        Me.txtAcceptLight.TabIndex = 23
        '
        'lblAcceptLight
        '
        Me.lblAcceptLight.AutoSize = True
        Me.lblAcceptLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcceptLight.Location = New System.Drawing.Point(11, 384)
        Me.lblAcceptLight.Name = "lblAcceptLight"
        Me.lblAcceptLight.Size = New System.Drawing.Size(105, 15)
        Me.lblAcceptLight.TabIndex = 21
        Me.lblAcceptLight.Text = "Accept Light Color"
        '
        'lblDefaultRejectLight
        '
        Me.lblDefaultRejectLight.AutoSize = True
        Me.lblDefaultRejectLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultRejectLight.Location = New System.Drawing.Point(191, 410)
        Me.lblDefaultRejectLight.Name = "lblDefaultRejectLight"
        Me.lblDefaultRejectLight.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultRejectLight.TabIndex = 25
        Me.lblDefaultRejectLight.Text = "Default"
        Me.lblDefaultRejectLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRejectLight
        '
        Me.txtRejectLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectLight.Location = New System.Drawing.Point(323, 407)
        Me.txtRejectLight.Name = "txtRejectLight"
        Me.txtRejectLight.Size = New System.Drawing.Size(75, 21)
        Me.txtRejectLight.TabIndex = 26
        '
        'lblRejectLight
        '
        Me.lblRejectLight.AutoSize = True
        Me.lblRejectLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectLight.Location = New System.Drawing.Point(11, 410)
        Me.lblRejectLight.Name = "lblRejectLight"
        Me.lblRejectLight.Size = New System.Drawing.Size(104, 15)
        Me.lblRejectLight.TabIndex = 24
        Me.lblRejectLight.Text = "Reject Light Color"
        '
        'lblDefaultWaitForStartLight
        '
        Me.lblDefaultWaitForStartLight.AutoSize = True
        Me.lblDefaultWaitForStartLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultWaitForStartLight.Location = New System.Drawing.Point(191, 436)
        Me.lblDefaultWaitForStartLight.Name = "lblDefaultWaitForStartLight"
        Me.lblDefaultWaitForStartLight.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultWaitForStartLight.TabIndex = 28
        Me.lblDefaultWaitForStartLight.Text = "Default"
        Me.lblDefaultWaitForStartLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtWaitForStartLight
        '
        Me.txtWaitForStartLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWaitForStartLight.Location = New System.Drawing.Point(323, 433)
        Me.txtWaitForStartLight.Name = "txtWaitForStartLight"
        Me.txtWaitForStartLight.Size = New System.Drawing.Size(75, 21)
        Me.txtWaitForStartLight.TabIndex = 29
        '
        'lblWaitForStartLight
        '
        Me.lblWaitForStartLight.AutoSize = True
        Me.lblWaitForStartLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitForStartLight.Location = New System.Drawing.Point(11, 436)
        Me.lblWaitForStartLight.Name = "lblWaitForStartLight"
        Me.lblWaitForStartLight.Size = New System.Drawing.Size(138, 15)
        Me.lblWaitForStartLight.TabIndex = 27
        Me.lblWaitForStartLight.Text = "Wait for Start Light Color"
        '
        'lblDefaultFaultOutTrials_SideSwaps
        '
        Me.lblDefaultFaultOutTrials_SideSwaps.AutoSize = True
        Me.lblDefaultFaultOutTrials_SideSwaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultFaultOutTrials_SideSwaps.Location = New System.Drawing.Point(191, 488)
        Me.lblDefaultFaultOutTrials_SideSwaps.Name = "lblDefaultFaultOutTrials_SideSwaps"
        Me.lblDefaultFaultOutTrials_SideSwaps.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultFaultOutTrials_SideSwaps.TabIndex = 34
        Me.lblDefaultFaultOutTrials_SideSwaps.Text = "Default"
        Me.lblDefaultFaultOutTrials_SideSwaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFaultOutTrials_SideSwaps
        '
        Me.txtFaultOutTrials_SideSwaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaultOutTrials_SideSwaps.Location = New System.Drawing.Point(323, 485)
        Me.txtFaultOutTrials_SideSwaps.Name = "txtFaultOutTrials_SideSwaps"
        Me.txtFaultOutTrials_SideSwaps.Size = New System.Drawing.Size(75, 21)
        Me.txtFaultOutTrials_SideSwaps.TabIndex = 35
        '
        'lblFaultOutTrials_SideSwaps
        '
        Me.lblFaultOutTrials_SideSwaps.AutoSize = True
        Me.lblFaultOutTrials_SideSwaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaultOutTrials_SideSwaps.Location = New System.Drawing.Point(11, 488)
        Me.lblFaultOutTrials_SideSwaps.Name = "lblFaultOutTrials_SideSwaps"
        Me.lblFaultOutTrials_SideSwaps.Size = New System.Drawing.Size(161, 15)
        Me.lblFaultOutTrials_SideSwaps.TabIndex = 33
        Me.lblFaultOutTrials_SideSwaps.Text = "Fault Out Trials - SideSwaps"
        '
        'lblDefaultFaultOutPercent
        '
        Me.lblDefaultFaultOutPercent.AutoSize = True
        Me.lblDefaultFaultOutPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultFaultOutPercent.Location = New System.Drawing.Point(191, 514)
        Me.lblDefaultFaultOutPercent.Name = "lblDefaultFaultOutPercent"
        Me.lblDefaultFaultOutPercent.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultFaultOutPercent.TabIndex = 37
        Me.lblDefaultFaultOutPercent.Text = "Default"
        Me.lblDefaultFaultOutPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFaultOutPercent
        '
        Me.txtFaultOutPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaultOutPercent.Location = New System.Drawing.Point(323, 511)
        Me.txtFaultOutPercent.Name = "txtFaultOutPercent"
        Me.txtFaultOutPercent.Size = New System.Drawing.Size(75, 21)
        Me.txtFaultOutPercent.TabIndex = 38
        '
        'lblFaultOutPercent
        '
        Me.lblFaultOutPercent.AutoSize = True
        Me.lblFaultOutPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaultOutPercent.Location = New System.Drawing.Point(11, 514)
        Me.lblFaultOutPercent.Name = "lblFaultOutPercent"
        Me.lblFaultOutPercent.Size = New System.Drawing.Size(101, 15)
        Me.lblFaultOutPercent.TabIndex = 36
        Me.lblFaultOutPercent.Text = "Fault Out Percent"
        '
        'lblDefaultShockInterval
        '
        Me.lblDefaultShockInterval.AutoSize = True
        Me.lblDefaultShockInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultShockInterval.Location = New System.Drawing.Point(191, 566)
        Me.lblDefaultShockInterval.Name = "lblDefaultShockInterval"
        Me.lblDefaultShockInterval.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultShockInterval.TabIndex = 43
        Me.lblDefaultShockInterval.Text = "Default"
        Me.lblDefaultShockInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtShockInterval
        '
        Me.txtShockInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShockInterval.Location = New System.Drawing.Point(323, 563)
        Me.txtShockInterval.Name = "txtShockInterval"
        Me.txtShockInterval.Size = New System.Drawing.Size(75, 21)
        Me.txtShockInterval.TabIndex = 44
        '
        'lblShockInterval
        '
        Me.lblShockInterval.AutoSize = True
        Me.lblShockInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShockInterval.Location = New System.Drawing.Point(11, 566)
        Me.lblShockInterval.Name = "lblShockInterval"
        Me.lblShockInterval.Size = New System.Drawing.Size(111, 15)
        Me.lblShockInterval.TabIndex = 42
        Me.lblShockInterval.Text = "Shock Interval (ms)"
        '
        'lblDefaultShockDuration
        '
        Me.lblDefaultShockDuration.AutoSize = True
        Me.lblDefaultShockDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultShockDuration.Location = New System.Drawing.Point(191, 592)
        Me.lblDefaultShockDuration.Name = "lblDefaultShockDuration"
        Me.lblDefaultShockDuration.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultShockDuration.TabIndex = 46
        Me.lblDefaultShockDuration.Text = "Default"
        Me.lblDefaultShockDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtShockDuration
        '
        Me.txtShockDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShockDuration.Location = New System.Drawing.Point(323, 589)
        Me.txtShockDuration.Name = "txtShockDuration"
        Me.txtShockDuration.Size = New System.Drawing.Size(75, 21)
        Me.txtShockDuration.TabIndex = 47
        '
        'lblShockDuration
        '
        Me.lblShockDuration.AutoSize = True
        Me.lblShockDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShockDuration.Location = New System.Drawing.Point(11, 592)
        Me.lblShockDuration.Name = "lblShockDuration"
        Me.lblShockDuration.Size = New System.Drawing.Size(119, 15)
        Me.lblShockDuration.TabIndex = 45
        Me.lblShockDuration.Text = "Shock Duration (ms)"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblDefaultFaultOutTrials_Percent
        '
        Me.lblDefaultFaultOutTrials_Percent.AutoSize = True
        Me.lblDefaultFaultOutTrials_Percent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultFaultOutTrials_Percent.Location = New System.Drawing.Point(191, 462)
        Me.lblDefaultFaultOutTrials_Percent.Name = "lblDefaultFaultOutTrials_Percent"
        Me.lblDefaultFaultOutTrials_Percent.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultFaultOutTrials_Percent.TabIndex = 31
        Me.lblDefaultFaultOutTrials_Percent.Text = "Default"
        Me.lblDefaultFaultOutTrials_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFaultOutTrials_Percent
        '
        Me.txtFaultOutTrials_Percent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaultOutTrials_Percent.Location = New System.Drawing.Point(323, 459)
        Me.txtFaultOutTrials_Percent.Name = "txtFaultOutTrials_Percent"
        Me.txtFaultOutTrials_Percent.Size = New System.Drawing.Size(75, 21)
        Me.txtFaultOutTrials_Percent.TabIndex = 32
        '
        'lblFaultOutTrials_Percent
        '
        Me.lblFaultOutTrials_Percent.AutoSize = True
        Me.lblFaultOutTrials_Percent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaultOutTrials_Percent.Location = New System.Drawing.Point(11, 462)
        Me.lblFaultOutTrials_Percent.Name = "lblFaultOutTrials_Percent"
        Me.lblFaultOutTrials_Percent.Size = New System.Drawing.Size(141, 15)
        Me.lblFaultOutTrials_Percent.TabIndex = 30
        Me.lblFaultOutTrials_Percent.Text = "Fault Out Trials - Percent"
        '
        'lblDefault
        '
        Me.lblDefault.AutoSize = True
        Me.lblDefault.Location = New System.Drawing.Point(11, 34)
        Me.lblDefault.Name = "lblDefault"
        Me.lblDefault.Size = New System.Drawing.Size(133, 13)
        Me.lblDefault.TabIndex = 61
        Me.lblDefault.Text = "System Default Config File:"
        '
        'lblDefaultConfigFile
        '
        Me.lblDefaultConfigFile.AutoSize = True
        Me.lblDefaultConfigFile.Location = New System.Drawing.Point(65, 43)
        Me.lblDefaultConfigFile.Name = "lblDefaultConfigFile"
        Me.lblDefaultConfigFile.Size = New System.Drawing.Size(0, 13)
        Me.lblDefaultConfigFile.TabIndex = 62
        '
        'lblDefaultPath
        '
        Me.lblDefaultPath.AutoSize = True
        Me.lblDefaultPath.Location = New System.Drawing.Point(11, 48)
        Me.lblDefaultPath.Name = "lblDefaultPath"
        Me.lblDefaultPath.Size = New System.Drawing.Size(0, 13)
        Me.lblDefaultPath.TabIndex = 63
        '
        'lblDefaultName
        '
        Me.lblDefaultName.AutoSize = True
        Me.lblDefaultName.Location = New System.Drawing.Point(11, 61)
        Me.lblDefaultName.Name = "lblDefaultName"
        Me.lblDefaultName.Size = New System.Drawing.Size(0, 13)
        Me.lblDefaultName.TabIndex = 64
        '
        'lblDefaultSuccessTrials
        '
        Me.lblDefaultSuccessTrials.AutoSize = True
        Me.lblDefaultSuccessTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSuccessTrials.Location = New System.Drawing.Point(191, 619)
        Me.lblDefaultSuccessTrials.Name = "lblDefaultSuccessTrials"
        Me.lblDefaultSuccessTrials.Size = New System.Drawing.Size(46, 15)
        Me.lblDefaultSuccessTrials.TabIndex = 49
        Me.lblDefaultSuccessTrials.Text = "Default"
        Me.lblDefaultSuccessTrials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSuccessTrials
        '
        Me.txtSuccessTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuccessTrials.Location = New System.Drawing.Point(323, 616)
        Me.txtSuccessTrials.Name = "txtSuccessTrials"
        Me.txtSuccessTrials.Size = New System.Drawing.Size(75, 21)
        Me.txtSuccessTrials.TabIndex = 50
        '
        'lblSuccessTrials
        '
        Me.lblSuccessTrials.AutoSize = True
        Me.lblSuccessTrials.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuccessTrials.Location = New System.Drawing.Point(11, 619)
        Me.lblSuccessTrials.Name = "lblSuccessTrials"
        Me.lblSuccessTrials.Size = New System.Drawing.Size(86, 15)
        Me.lblSuccessTrials.TabIndex = 48
        Me.lblSuccessTrials.Text = "Success Trials"
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 692)
        Me.Controls.Add(Me.lblDefaultSuccessTrials)
        Me.Controls.Add(Me.txtSuccessTrials)
        Me.Controls.Add(Me.lblSuccessTrials)
        Me.Controls.Add(Me.lblDefaultName)
        Me.Controls.Add(Me.lblDefaultPath)
        Me.Controls.Add(Me.lblDefaultConfigFile)
        Me.Controls.Add(Me.lblDefault)
        Me.Controls.Add(Me.lblDefaultFaultOutTrials_Percent)
        Me.Controls.Add(Me.txtFaultOutTrials_Percent)
        Me.Controls.Add(Me.lblFaultOutTrials_Percent)
        Me.Controls.Add(Me.lblDefaultShockDuration)
        Me.Controls.Add(Me.txtShockDuration)
        Me.Controls.Add(Me.lblShockDuration)
        Me.Controls.Add(Me.lblDefaultShockInterval)
        Me.Controls.Add(Me.txtShockInterval)
        Me.Controls.Add(Me.lblShockInterval)
        Me.Controls.Add(Me.lblDefaultFaultOutPercent)
        Me.Controls.Add(Me.txtFaultOutPercent)
        Me.Controls.Add(Me.lblFaultOutPercent)
        Me.Controls.Add(Me.lblDefaultFaultOutTrials_SideSwaps)
        Me.Controls.Add(Me.txtFaultOutTrials_SideSwaps)
        Me.Controls.Add(Me.lblFaultOutTrials_SideSwaps)
        Me.Controls.Add(Me.lblDefaultWaitForStartLight)
        Me.Controls.Add(Me.txtWaitForStartLight)
        Me.Controls.Add(Me.lblWaitForStartLight)
        Me.Controls.Add(Me.lblDefaultRejectLight)
        Me.Controls.Add(Me.txtRejectLight)
        Me.Controls.Add(Me.lblRejectLight)
        Me.Controls.Add(Me.lblDefaultAcceptLight)
        Me.Controls.Add(Me.txtAcceptLight)
        Me.Controls.Add(Me.lblAcceptLight)
        Me.Controls.Add(Me.lblDefaultTrialDuration)
        Me.Controls.Add(Me.txtTrialDuration)
        Me.Controls.Add(Me.lblTrialDuration)
        Me.Controls.Add(Me.lblBoxNum)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblConfigFileTitle)
        Me.Controls.Add(Me.lblDefaultParamsTitle)
        Me.Controls.Add(Me.lblParamsTitle)
        Me.Controls.Add(Me.btnConfigBrowse)
        Me.Controls.Add(Me.txtConfigFileName)
        Me.Controls.Add(Me.btnTransferValues)
        Me.Controls.Add(Me.btnReadConfigParams)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnResetDefaults)
        Me.Controls.Add(Me.btnDownloadConfigParams)
        Me.Controls.Add(Me.lblConfigFormTitle)
        Me.Controls.Add(Me.lblDefaultSettleLight)
        Me.Controls.Add(Me.txtSettleLight)
        Me.Controls.Add(Me.lblSettleLight)
        Me.Controls.Add(Me.lblDefaultInterTrialSettleTime)
        Me.Controls.Add(Me.txtInterTrialSettleTime)
        Me.Controls.Add(Me.lblInterTrialSettleTime)
        Me.Controls.Add(Me.lblDefaultSeekTime)
        Me.Controls.Add(Me.txtSeekTime)
        Me.Controls.Add(Me.lblSeekTime)
        Me.Controls.Add(Me.lblDefaultShockVoltage)
        Me.Controls.Add(Me.txtShockVoltage)
        Me.Controls.Add(Me.lblShockVoltage)
        Me.Controls.Add(Me.lblDefaultSettleTime)
        Me.Controls.Add(Me.txtSettleTime)
        Me.Controls.Add(Me.lblSettleTime)
        Me.Controls.Add(Me.lblDefaultNumberOfTrials)
        Me.Controls.Add(Me.txtNumberOfTrials)
        Me.Controls.Add(Me.lblNumberOfTrials)
        Me.Controls.Add(Me.lblDefaultSelectionMode)
        Me.Controls.Add(Me.txtSelectionMode)
        Me.Controls.Add(Me.lblSelectionMode)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Behavior_Serial_VB_Test.My.MySettings.Default, "MainFormLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = Global.Behavior_Serial_VB_Test.My.MySettings.Default.MainFormLocation
        Me.Name = "ConfigForm"
        Me.Text = "ConfigForm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSelectionMode As System.Windows.Forms.Label
    Friend WithEvents txtSelectionMode As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultSelectionMode As System.Windows.Forms.Label
    Friend WithEvents lblDefaultNumberOfTrials As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfTrials As System.Windows.Forms.TextBox
    Friend WithEvents lblNumberOfTrials As System.Windows.Forms.Label
    Friend WithEvents lblDefaultSettleTime As System.Windows.Forms.Label
    Friend WithEvents txtSettleTime As System.Windows.Forms.TextBox
    Friend WithEvents lblSettleTime As System.Windows.Forms.Label
    Friend WithEvents lblDefaultShockVoltage As System.Windows.Forms.Label
    Friend WithEvents txtShockVoltage As System.Windows.Forms.TextBox
    Friend WithEvents lblShockVoltage As System.Windows.Forms.Label
    Friend WithEvents lblDefaultSeekTime As System.Windows.Forms.Label
    Friend WithEvents txtSeekTime As System.Windows.Forms.TextBox
    Friend WithEvents lblSeekTime As System.Windows.Forms.Label
    Friend WithEvents lblDefaultInterTrialSettleTime As System.Windows.Forms.Label
    Friend WithEvents txtInterTrialSettleTime As System.Windows.Forms.TextBox
    Friend WithEvents lblInterTrialSettleTime As System.Windows.Forms.Label
    Friend WithEvents lblDefaultSettleLight As System.Windows.Forms.Label
    Friend WithEvents txtSettleLight As System.Windows.Forms.TextBox
    Friend WithEvents lblSettleLight As System.Windows.Forms.Label
    Friend WithEvents lblConfigFormTitle As System.Windows.Forms.Label
    Friend WithEvents btnResetDefaults As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReadConfigParams As System.Windows.Forms.Button
    Friend WithEvents btnTransferValues As System.Windows.Forms.Button
    Friend WithEvents txtConfigFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnDownloadConfigParams As System.Windows.Forms.Button
    Friend WithEvents btnConfigBrowse As System.Windows.Forms.Button
    Friend WithEvents lblParamsTitle As System.Windows.Forms.Label
    Friend WithEvents lblDefaultParamsTitle As System.Windows.Forms.Label
    Friend WithEvents lblConfigFileTitle As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialogConfigFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBoxNum As System.Windows.Forms.Label
    Friend WithEvents lblDefaultTrialDuration As System.Windows.Forms.Label
    Friend WithEvents txtTrialDuration As System.Windows.Forms.TextBox
    Friend WithEvents lblTrialDuration As System.Windows.Forms.Label
    Friend WithEvents lblDefaultAcceptLight As System.Windows.Forms.Label
    Friend WithEvents txtAcceptLight As System.Windows.Forms.TextBox
    Friend WithEvents lblAcceptLight As System.Windows.Forms.Label
    Friend WithEvents lblDefaultRejectLight As System.Windows.Forms.Label
    Friend WithEvents txtRejectLight As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectLight As System.Windows.Forms.Label
    Friend WithEvents lblDefaultWaitForStartLight As System.Windows.Forms.Label
    Friend WithEvents txtWaitForStartLight As System.Windows.Forms.TextBox
    Friend WithEvents lblWaitForStartLight As System.Windows.Forms.Label
    Friend WithEvents lblDefaultFaultOutTrials_SideSwaps As System.Windows.Forms.Label
    Friend WithEvents txtFaultOutTrials_SideSwaps As System.Windows.Forms.TextBox
    Friend WithEvents lblFaultOutTrials_SideSwaps As System.Windows.Forms.Label
    Friend WithEvents lblDefaultFaultOutPercent As System.Windows.Forms.Label
    Friend WithEvents txtFaultOutPercent As System.Windows.Forms.TextBox
    Friend WithEvents lblFaultOutPercent As System.Windows.Forms.Label
    Friend WithEvents lblDefaultShockInterval As System.Windows.Forms.Label
    Friend WithEvents txtShockInterval As System.Windows.Forms.TextBox
    Friend WithEvents lblShockInterval As System.Windows.Forms.Label
    Friend WithEvents lblDefaultShockDuration As System.Windows.Forms.Label
    Friend WithEvents txtShockDuration As System.Windows.Forms.TextBox
    Friend WithEvents lblShockDuration As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDefaultFaultOutTrials_Percent As System.Windows.Forms.Label
    Friend WithEvents txtFaultOutTrials_Percent As System.Windows.Forms.TextBox
    Friend WithEvents lblFaultOutTrials_Percent As System.Windows.Forms.Label
    Friend WithEvents lblDefaultConfigFile As System.Windows.Forms.Label
    Friend WithEvents lblDefault As System.Windows.Forms.Label
    Friend WithEvents lblDefaultName As System.Windows.Forms.Label
    Friend WithEvents lblDefaultPath As System.Windows.Forms.Label
    Friend WithEvents lblDefaultSuccessTrials As System.Windows.Forms.Label
    Friend WithEvents txtSuccessTrials As System.Windows.Forms.TextBox
    Friend WithEvents lblSuccessTrials As System.Windows.Forms.Label

End Class
