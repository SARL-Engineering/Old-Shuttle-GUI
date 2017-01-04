Public Class StatusClass
    '
    '   This class is the link between the MainForm thread (includes ConfigForm) and the ShuttleboxIOClass thread
    '   running the asynchronous server handling the Arduino I/O.
    '
    '   The properties below are the status flags and parameter values used to coordinate the forms UI and the Arduino
    '   interface.
    '
    '   This is a Singleton class, so only one instance exists.
    '
    '
    '******  Serial Port Number - ie., COM11  **********
    Private m_strCOMPort As String
    Public Property COMPort() As String
        Get
            Return m_strCOMPort
        End Get
        Set(ByVal value As String)
            m_strCOMPort = value
        End Set
    End Property

    '******  Start button flag - signals the server to send the Start Test command  **********
    Private m_blnStartTest As Boolean
    Public Property StartTest() As Boolean
        Get
            Return m_blnStartTest
        End Get
        Set(ByVal value As Boolean)
            m_blnStartTest = value
        End Set
    End Property

    '******  Abort button flag - signals the server to send the Abort Test command  **********
    Private m_blnAbortTest As Boolean
    Public Property AbortTest() As Boolean
        Get
            Return m_blnAbortTest
        End Get
        Set(ByVal value As Boolean)
            m_blnAbortTest = value
        End Set
    End Property

    '******  Read Config Params flag - signals the server to read the current Arduino config parameters  **********
    Private m_blnReadConfigParams As Boolean
    Public Property ReadArduinoConfigParams() As Boolean
        Get
            Return m_blnReadConfigParams
        End Get
        Set(ByVal value As Boolean)
            m_blnReadConfigParams = value
        End Set
    End Property

    '******  Download Config Params flag - signals the server to download the config parameters to the Arduino  **********
    Private m_blnDownloadConfigParams As Boolean
    Public Property DownloadConfigParams() As Boolean
        Get
            Return m_blnDownloadConfigParams
        End Get
        Set(ByVal value As Boolean)
            m_blnDownloadConfigParams = value
        End Set
    End Property

    '******  Configuration Parameters - used for both Read Config Params and Download Config Params  *******************

    Public Property NumberOfTrials As Integer
    Public Property SelectionMode As String
    Public Property SettleTime As Integer
    Public Property TrialDuration As Integer
    Public Property SeekTime As Integer
    Public Property InterTrialSettleTime As Integer
    Public Property SettleLight As String
    Public Property AcceptLight As String
    Public Property RejectLight As String
    Public Property WaitForStartLight As String
    Public Property FaultOutTrials_Percent As Integer
    Public Property FaultOutTrials_SideSwaps As Integer
    Public Property FaultOutPercent As Integer
    Public Property ShockVoltage As Decimal
    Public Property ShockInterval As Integer
    Public Property ShockDuration As Integer
    Public Property SuccessTrials As Integer

    '
    '****************************  Last Config File Path \ Filename  ********************************
    Private m_LastConfigFileName As String
    Public Property LastConfigFileName() As String
        Get
            Return m_LastConfigFileName
        End Get
        Set(ByVal value As String)
            m_LastConfigFileName = value
        End Set
    End Property
    '
    '****************************  Log File Output flag  ********************************
    Private m_blnLogFileWrite As Boolean
    Public Property LogFileWrite() As Boolean
        Get
            Return m_blnLogFileWrite
        End Get
        Set(ByVal value As Boolean)
            m_blnLogFileWrite = value
        End Set
    End Property
    '
    '****************************  Log File Filename  ********************************
    Private m_strLogFilename As String
    Public Property LogFilename() As String
        Get
            Return m_strLogFilename
        End Get
        Set(ByVal value As String)
            m_strLogFilename = value
        End Set
    End Property
    '
    '   Setup the Default Config File Container path\name
    '
    Public Property strConfigFilesFolderPath As String = "C:"
    Property strConfigFolderName As String = "ShuttleBox Control Panel"
    Property strDefaultConfigContainerFileName As String = "DEFAULT_CONFIG_FILE_PATH.TXT"
    Public Property strDefaultConfigContainerPathAndName As String = strConfigFilesFolderPath & "\" & strConfigFolderName & "\" & strDefaultConfigContainerFileName
    '
    '   Capture the Test Start Time and SBox number as the Index for Trial Results
    '
    Private m_strTestIndex As String
    Public Property TestIndex() As String
        Get
            Return m_strTestIndex
        End Get
        Set(ByVal value As String)
            m_strTestIndex = value
        End Set
    End Property



    '
    '   Singleton Class Methods
    '
    Private Shared m_Instance As StatusClass

    '   The GetInstance method returns the existing instance, or creates
    '       a new instance if none has been previously created.
    '
    Public Shared Function GetInstance() As StatusClass
        If m_Instance Is Nothing Then
            m_Instance = New StatusClass
        End If
        Return m_Instance
    End Function
    '
    '   Make default constructor Private to avoid extra instances
    '
    Private Sub New()
    End Sub
End Class
