<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.lblComPort = New System.Windows.Forms.Label()
        Me.lblComPortTitle = New System.Windows.Forms.Label()
        Me.lblBoxTitle = New System.Windows.Forms.Label()
        Me.lblBoxNum = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.txtResultFolderPath = New System.Windows.Forms.TextBox()
        Me.btnResultsFolderBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtResultFilename = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConfigParams = New System.Windows.Forms.Button()
        Me.btnOpenFileBrowse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblComPort
        '
        Me.lblComPort.AutoSize = True
        Me.lblComPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComPort.Location = New System.Drawing.Point(213, 36)
        Me.lblComPort.Name = "lblComPort"
        Me.lblComPort.Size = New System.Drawing.Size(60, 16)
        Me.lblComPort.TabIndex = 3
        Me.lblComPort.Text = "ComPort"
        '
        'lblComPortTitle
        '
        Me.lblComPortTitle.AutoSize = True
        Me.lblComPortTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComPortTitle.Location = New System.Drawing.Point(148, 36)
        Me.lblComPortTitle.Name = "lblComPortTitle"
        Me.lblComPortTitle.Size = New System.Drawing.Size(68, 16)
        Me.lblComPortTitle.TabIndex = 4
        Me.lblComPortTitle.Text = "COM Port:"
        '
        'lblBoxTitle
        '
        Me.lblBoxTitle.AutoSize = True
        Me.lblBoxTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxTitle.Location = New System.Drawing.Point(141, 9)
        Me.lblBoxTitle.Name = "lblBoxTitle"
        Me.lblBoxTitle.Size = New System.Drawing.Size(110, 24)
        Me.lblBoxTitle.TabIndex = 7
        Me.lblBoxTitle.Text = "ShuttleBox"
        '
        'lblBoxNum
        '
        Me.lblBoxNum.AutoSize = True
        Me.lblBoxNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxNum.Location = New System.Drawing.Point(246, 9)
        Me.lblBoxNum.Name = "lblBoxNum"
        Me.lblBoxNum.Size = New System.Drawing.Size(51, 24)
        Me.lblBoxNum.TabIndex = 8
        Me.lblBoxNum.Text = "num"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(2, 237)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(430, 226)
        Me.txtResults.TabIndex = 9
        Me.txtResults.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(70, 181)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(110, 50)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start Test"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnAbort
        '
        Me.btnAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbort.Location = New System.Drawing.Point(260, 181)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(110, 50)
        Me.btnAbort.TabIndex = 2
        Me.btnAbort.Text = "Abort Test"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'txtResultFolderPath
        '
        Me.txtResultFolderPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultFolderPath.Location = New System.Drawing.Point(17, 89)
        Me.txtResultFolderPath.Name = "txtResultFolderPath"
        Me.txtResultFolderPath.ReadOnly = True
        Me.txtResultFolderPath.Size = New System.Drawing.Size(320, 22)
        Me.txtResultFolderPath.TabIndex = 12
        '
        'btnResultsFolderBrowse
        '
        Me.btnResultsFolderBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResultsFolderBrowse.Location = New System.Drawing.Point(362, 87)
        Me.btnResultsFolderBrowse.Name = "btnResultsFolderBrowse"
        Me.btnResultsFolderBrowse.Size = New System.Drawing.Size(62, 26)
        Me.btnResultsFolderBrowse.TabIndex = 13
        Me.btnResultsFolderBrowse.TabStop = False
        Me.btnResultsFolderBrowse.Text = "Browse"
        Me.btnResultsFolderBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Results File Directory:"
        '
        'txtResultFilename
        '
        Me.txtResultFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultFilename.Location = New System.Drawing.Point(17, 142)
        Me.txtResultFilename.Name = "txtResultFilename"
        Me.txtResultFilename.Size = New System.Drawing.Size(320, 22)
        Me.txtResultFilename.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Results File Name:"
        '
        'btnConfigParams
        '
        Me.btnConfigParams.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfigParams.Location = New System.Drawing.Point(159, 471)
        Me.btnConfigParams.Name = "btnConfigParams"
        Me.btnConfigParams.Size = New System.Drawing.Size(120, 50)
        Me.btnConfigParams.TabIndex = 3
        Me.btnConfigParams.Text = "Configuration Parameters"
        Me.btnConfigParams.UseVisualStyleBackColor = True
        '
        'btnOpenFileBrowse
        '
        Me.btnOpenFileBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenFileBrowse.Location = New System.Drawing.Point(362, 140)
        Me.btnOpenFileBrowse.Name = "btnOpenFileBrowse"
        Me.btnOpenFileBrowse.Size = New System.Drawing.Size(62, 26)
        Me.btnOpenFileBrowse.TabIndex = 19
        Me.btnOpenFileBrowse.TabStop = False
        Me.btnOpenFileBrowse.Text = "Browse"
        Me.btnOpenFileBrowse.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 531)
        Me.Controls.Add(Me.btnOpenFileBrowse)
        Me.Controls.Add(Me.btnConfigParams)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtResultFilename)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnResultsFolderBrowse)
        Me.Controls.Add(Me.txtResultFolderPath)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.lblBoxNum)
        Me.Controls.Add(Me.lblBoxTitle)
        Me.Controls.Add(Me.lblComPortTitle)
        Me.Controls.Add(Me.lblComPort)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Behavior_Serial_VB_Test.My.MySettings.Default, "MainFormLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = Global.Behavior_Serial_VB_Test.My.MySettings.Default.MainFormLocation
        Me.Name = "MainForm"
        Me.Text = "Shuttle Box Control Panel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblComPort As System.Windows.Forms.Label
    Friend WithEvents lblComPortTitle As System.Windows.Forms.Label
    Friend WithEvents lblBoxTitle As System.Windows.Forms.Label
    Friend WithEvents lblBoxNum As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnAbort As System.Windows.Forms.Button
    Friend WithEvents txtResultFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents btnResultsFolderBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtResultFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConfigParams As System.Windows.Forms.Button
    Friend WithEvents btnOpenFileBrowse As System.Windows.Forms.Button

End Class
