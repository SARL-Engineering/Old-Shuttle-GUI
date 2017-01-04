Imports System.IO.Ports
Imports System.Threading

Public Class ShuttleboxIOClass
    '
    '   This class is a separate BackgroundWorker thread providing the asynchronous server to handle all I/O with the Shuttlebox Arduino
    '   microcontroller.  The interface is a serial over USB link that appears as a ComPort in the Windows Device Manager application.
    '   
    '   The program is a loop that runs continuously.  The primary input is the ReadLine() call at the top of the loop.  It is a blocking Read that
    '   waits for input from the Arduino.  However, it has a 1 second timeout that frees up the loop to check for other command requests from the MainForm
    '   that need to be processed, before looping back to issue the next ReadLine.
    '

    Public Shared Sub COMPortIO(ByVal worker As System.ComponentModel.BackgroundWorker,
                                   ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim strResult As String
        Dim comPort As IO.Ports.SerialPort = Nothing
        Dim ErrorCheck As String
        Dim returnStr As String = ""
        '
        '   Open the port for the COMxx serial port specified in the StatusClass property COMPort.
        '   The specific COMxx port for this instance of the application is hardcoded at the top of the MainForm
        '
        Try
            comPort = My.Computer.Ports.OpenSerialPort(status.COMPort)
            comPort.ReadTimeout = 1000

        Catch ex As Exception
            strResult = "Error: Serial Port Open error: " & ex.Message
            worker.ReportProgress(2, strResult)
            If comPort IsNot Nothing And comPort.IsOpen Then comPort.Close()
            
            Exit Sub
        End Try

        '*****************  Main Server Loop for Arduino interface  **********************

        While (True)

            '**************************  comPort Read for Arduino inputs  ***********************
            Try
                strResult = comPort.ReadLine()

            Catch ex As TimeoutException
                '   Note the timeout is set to 1 sec to allow the other actions in the loop to occur
                '   between comPort reads.  Serial port timeout errors are not reported since they occur normally.
                '   The error message is put into strResult for use in debugging
                strResult = "Timeout Error on Serial Port Read: " & ex.Message

            Catch ex As Exception
                '   Non-timeout errors will be reported in the results textbox.
                strResult = "Error: Serial Port read error: " & ex.Message
            End Try
            '
            '   Send Result to MainForm
            '   Use Progress Percentage to differentiate between error messages & results
            '   Progress Percentage = 0 indicates an error message
            '   Progress Percentage = 100 indicates status messages
            '   Progress Percentage = 50 indicates Trial results (added to allow output to raw Trial results file)
            '
            If strResult.StartsWith("Error") Then
                worker.ReportProgress(0, strResult)

            ElseIf strResult.StartsWith("Timeout") Then
                '   Don't report Read timeout errors - happen 1/sec normally

            ElseIf strResult.StartsWith("New") Then
                '   If the message is "New", this is the start of a new Test
                '   The Arduino sends the config parameters immediately following the New Test message,
                '   so call the ReceiveConfigParams params to receive and load the parameters into StatusClass
                ErrorCheck = ReceiveConfigParams(comPort)
                If ErrorCheck = "" Then
                Else
                    MessageBox.Show("IOClass New Test receipt: Error on ReceiveConfigParams: " & ErrorCheck)
                End If
                '  Now forward the New Test message to Mainform
                worker.ReportProgress(100, strResult)

            ElseIf strResult.StartsWith("Fault") Or strResult.StartsWith("SUCCESS") Or strResult.StartsWith("Settle") Then
                '   These are early test termination messages.  They are sent to the Mainform
                '   with the same code as the New test message
                worker.ReportProgress(100, strResult)

            ElseIf strResult.StartsWith("Test") Then
                '   These are the Test End and Test Abort messages.
                '   They are also sent with the 100 code.
                worker.ReportProgress(100, strResult)

            Else
                '
                '   Otherwise, these are Trial results - send to MainForm with code = 50
                '
                worker.ReportProgress(50, strResult)
            End If
            '
            '*****************************  Requests to Start Test   ***********************
            '   Check for a Start button request
            '   Send Start code (250) to Arduino
            '
            If status.StartTest = True Then
                ErrorCheck = ""
                ErrorCheck = SendSerialData(250, comPort) ' 250 Tells Arduino to Start Test
                If ErrorCheck = "" Then
                Else
                    worker.ReportProgress(0, ErrorCheck)
                End If
                status.StartTest = False
            End If
            '
            '*****************************  Requests to Abort Test   ***********************
            '   Check for a Abort button request
            '   Send Abort code (255) to Arduino
            '
            If status.AbortTest = True Then
                ErrorCheck = ""
                ErrorCheck = SendSerialData(255, comPort)  ' 255 Tells Arduino to Abort Test
                If ErrorCheck = "" Then
                Else
                    worker.ReportProgress(0, ErrorCheck)
                End If
                '
                '   Reset the AbortTest request flag
                '
                status.AbortTest = False
            End If
            '
            '*****************************  Request to Read Config Parameters from Arduino  ***********************
            '   Check for Read Config parameters request
            '   Sub ReadConfigParams sends Read request code (252) to Arduino
            '
            If status.ReadArduinoConfigParams = True Then
                ErrorCheck = ""
                ErrorCheck = ReadConfigParams(comPort)
                If ErrorCheck = "" Then
                    worker.ReportProgress(10, ErrorCheck)
                Else
                    worker.ReportProgress(0, ErrorCheck)
                End If
                '
                '   Reset the ReadConfigParams request flag
                '
                status.ReadArduinoConfigParams = False
                Thread.Sleep(20)
            End If
            '
            '*****************************  Request to Download Config Parameters to Arduino  ***********************
            '   Check for Config parameters download request
            '   Sub DownloadConfigParams handles download handshakes & sends parameters
            '
            If status.DownloadConfigParams = True Then

                ErrorCheck = ""
                ErrorCheck = DownloadConfigParams(comPort, worker, e)

                If ErrorCheck.StartsWith("Error") Then
                    worker.ReportProgress(0, ErrorCheck)
                    
                Else
                    worker.ReportProgress(100, ErrorCheck)

                End If
                '
                '   Reset the ConfigParamsDownload request flag
                '
                status.DownloadConfigParams = False
                Thread.Sleep(20)
            End If

        End While  ' End of While(True) server loop

        '   Should never get there - closing application will close ComPort
        worker.ReportProgress(0, "COMPortIO Exiting")
        If comPort IsNot Nothing And comPort.IsOpen Then comPort.Close()

    End Sub


    '********************  SendSerialData  **************************
    '
    '   Used to send command text to the Arduino
    '   
    Public Shared Function SendSerialData(ByVal data As Integer, comPort As IO.Ports.SerialPort) As String
        ' Send strings to a serial port.

        Dim returnStr As String = ""
        Try
            comPort.Write(data.ToString)
        Catch ex As Exception
            returnStr = "Error: Serial Port write error: " & ex.Message
            
        End Try
        Return returnStr

    End Function


    '********************  Read Config Params  **************************
    '
    '   Reads the Arduino's current configuration parameter set
    '   Sends request code = 252, then calls ReceiveConfigParams() to receive the parameters.
    '
    Public Shared Function ReadConfigParams(comport As IO.Ports.SerialPort) As String

        Dim status As StatusClass
        status = StatusClass.GetInstance

        '
        '   Set up request code
        '
        Dim strResult As String = ""
        Dim returnStr As String = ""
        Dim strParamReadRequestCode As Integer = 252
        Dim ErrorCheck As String = ""
        '
        '   Send Read Request Code to get the current Config Params from the Arduino
        '
        ErrorCheck = ""
        ErrorCheck = SendSerialData(strParamReadRequestCode, comport)
        If ErrorCheck = "" Then
            Thread.Sleep(100)

            '
            '   Read config parameters from Arduino
            '
            ErrorCheck = ReceiveConfigParams(comport)
            If ErrorCheck = "" Then
            Else
                returnStr = ErrorCheck
            End If
        Else
            returnStr = "Error: ConfigParam ReadRequestCode send error: " & ErrorCheck
        End If

        Return returnStr

    End Function

    '********************  Receive the Config Params  **************************
    '
    '   Receives the Arduino's current configuration parameter set after
    '   a read request code has been sent.  Called by ReadConfigParams(). 
    '   Thread.Sleep(100) required to avoid missing data - don't know why.
    '
    Public Shared Function ReceiveConfigParams(comport As IO.Ports.SerialPort) As String

        Dim status As StatusClass
        status = StatusClass.GetInstance
        '
        '   Set up return strings
        '
        Dim strResult As String = ""
        Dim returnStr As String = ""
        '
        '   Receive the parameters and store in StatusClass
        '
        Try
            strResult = comport.ReadLine()
            status.NumberOfTrials = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            Dim intSelectionMode As Integer = Integer.Parse(strResult)
            If intSelectionMode = 2 Then
                status.SelectionMode = "Random"
            Else
                status.SelectionMode = "Opposite"
            End If


            strResult = comport.ReadLine()
            status.SettleTime = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.TrialDuration = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.SeekTime = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.InterTrialSettleTime = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.SettleLight = ColorWords(strResult)

            strResult = comport.ReadLine()
            status.AcceptLight = ColorWords(strResult)

            strResult = comport.ReadLine()
            status.RejectLight = ColorWords(strResult)

            strResult = comport.ReadLine()
            status.WaitForStartLight = ColorWords(strResult)

            strResult = comport.ReadLine()
            status.FaultOutTrials_Percent = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.FaultOutTrials_SideSwaps = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.FaultOutPercent = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.ShockVoltage = Decimal.Parse(strResult)

            strResult = comport.ReadLine()
            status.ShockInterval = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.ShockDuration = Integer.Parse(strResult)

            strResult = comport.ReadLine()
            status.SuccessTrials = Integer.Parse(strResult)

        Catch ex As Exception
            returnStr = "Error: Receive Config Params - Parameter Read error: " & ex.Message
            MessageBox.Show(returnStr)
        End Try

        Return returnStr

    End Function


    '**************************  DownloadConfigParams  *******************
    '
    '   Download the parameter set to the Arduino
    '   Sends request code (253) and waits for echo before proceeding.
    '   A Thread.Sleep(500) is issued after each comPort.Write to allow the Arduino
    '   time to respond.  The comPort.ReadLine timeout is set to 1 sec for the main Read above
    '   so Thread.Sleep is used here to avoid timing out before the Arduino responds.  The 500ms
    '   time was empirically determined.
    '
    '   Note: if the download process fails, the Arduino is left in a loop waiting for input.
    '           It must be reset to recover - power off/on.  
    '           Not the Reset button on the top - that is used for Abort test.
    '
    Public Shared Function DownloadConfigParams(comPort As IO.Ports.SerialPort, ByVal worker As System.ComponentModel.BackgroundWorker,
                                   ByVal e As System.ComponentModel.DoWorkEventArgs) As String

        Dim status As StatusClass
        status = StatusClass.GetInstance

        Dim returnStr As String = ""
        Dim strDownloadRequestCode As String = "253"
        Dim strResult As String = ""
        Dim blnDownloadSuccess As Boolean = True

        Try
            '
            '******   Send Config Download request to Arduino  ********
            '
            comPort.Write(strDownloadRequestCode)

        Catch ex As Exception
            returnStr = "Error: Download Request Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try
        Thread.Sleep(500)

        Try
            '
            '   Wait for echo to check Download Request receipt
            '
            strResult = comPort.ReadLine()

        Catch ex As Exception
            returnStr = "Error: Download Request Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        '
        '   Send Download Starting status message to MainForm
        '
        Dim StatusMessage As String = "Starting Download"
        worker.ReportProgress(3, StatusMessage)


        '***************  Send the Number of Trials  ***********
        Try
            comPort.Write(status.NumberOfTrials.ToString)
        Catch ex As Exception
            returnStr = "Error: Download NumberOfTrials Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download NumberOfTrials Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        '   Send parameter download status update message to MainForm
        StatusMessage = "NumberOfTrials = " & status.NumberOfTrials.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Selection Mode  *****************
        Dim intSelectionMode As Integer
        If Mid(status.SelectionMode.ToUpper, 1, 1) = "R" Then
            intSelectionMode = 2
        Else
            intSelectionMode = 1
        End If
        Try
            comPort.Write(intSelectionMode.ToString)
        Catch ex As Exception
            returnStr = "Error: Download SelectionMode Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download SelectionMode Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "SelectionMode = " & status.SelectionMode
        worker.ReportProgress(4, StatusMessage)


        '****************  Send SettleTime  *********************
        Try
            comPort.Write(status.SettleTime.ToString)
        Catch ex As Exception
            returnStr = "Error: Download SettleTime Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download SettleTime Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "SettleTime = " & status.SettleTime.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Trial Duration  *********************
        Try
            comPort.Write(status.TrialDuration.ToString)
        Catch ex As Exception
            returnStr = "Error: Download TrialDuration Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download TrialDuration Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "TrialDuration = " & status.TrialDuration.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Seek Time  *********************
        Try
            comPort.Write(status.SeekTime.ToString)
        Catch ex As Exception
            returnStr = "Error: Download SeekTime Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download SeekTime Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "SeekTime = " & status.SeekTime.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Inter-Trial Settle Time  *********************
        Try
            comPort.Write(status.InterTrialSettleTime.ToString)
        Catch ex As Exception
            returnStr = "Error: Download InterTrialSettleTime Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download InterTrialSettleTime Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "InterTrialSettleTime = " & status.InterTrialSettleTime.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Settle Light Color  *********************
        Try
            comPort.Write(Mid(status.SettleLight, 1, 1).ToUpper)  ' send 1st character of color
        Catch ex As Exception
            returnStr = "Error: Download SettleLight Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download SettleLight Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "SettleLight = " & status.SettleLight
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Accept Light Color  *********************
        Try
            comPort.Write(Mid(status.AcceptLight, 1, 1).ToUpper)  ' send 1st character of color
        Catch ex As Exception
            returnStr = "Error: Download AcceptLight Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download AcceptLight Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "AcceptLight = " & status.AcceptLight
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Reject Light Color  *********************
        Try
            comPort.Write(Mid(status.RejectLight, 1, 1).ToUpper)  ' send 1st character of color
        Catch ex As Exception
            returnStr = "Error: Download RejectLight Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download RejectLight Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "RejectLight = " & status.RejectLight
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Wait For Start Light Color  *********************
        Try
            comPort.Write(Mid(status.WaitForStartLight, 1, 1).ToUpper)  ' send 1st character of color
        Catch ex As Exception
            returnStr = "Error: Download WaitForStartLight Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download WaitForStartLight Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "WaitForStartLight = " & status.WaitForStartLight
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Fault Out Trials - Percent  *********************
        Try
            comPort.Write(status.FaultOutTrials_Percent.ToString)
        Catch ex As Exception
            returnStr = "Error: Download FaultOutTrials_Percent Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download FaultOutTrials_Percent Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "FaultOutTrials_Percent = " & status.FaultOutTrials_Percent.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Fault Out Trials - SideSwaps  *********************
        Try
            comPort.Write(status.FaultOutTrials_SideSwaps.ToString)
        Catch ex As Exception
            returnStr = "Error: Download FaultOutTrials_SideSwaps Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download FaultOutTrials_SideSwaps Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "FaultOutTrials_SideSwaps = " & status.FaultOutTrials_SideSwaps.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Fault Out Percent  *********************
        Try
            comPort.Write(status.FaultOutPercent.ToString)
        Catch ex As Exception
            returnStr = "Error: Download FaultOutPercent Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download FaultOutPercent Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "FaultOutPercent = " & status.FaultOutPercent.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send ShockVoltage  *********************
        Try
            comPort.Write(status.ShockVoltage.ToString)
        Catch ex As Exception
            returnStr = "Error: Download ShockVoltage Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download ShockVoltage Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "ShockVoltage = " & status.ShockVoltage.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Shock Interval  *********************
        Try
            comPort.Write(status.ShockInterval.ToString)
        Catch ex As Exception
            returnStr = "Error: Download ShockInterval Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download ShockInterval Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "ShockInterval = " & status.ShockInterval.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Shock Duration  *********************
        Try
            comPort.Write(status.ShockDuration.ToString)
        Catch ex As Exception
            returnStr = "Error: Download ShockDuration Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download ShockDuration Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "ShockDuration = " & status.ShockDuration.ToString
        worker.ReportProgress(4, StatusMessage)


        '****************  Send Success Trials  *********************
        Try
            comPort.Write(status.SuccessTrials.ToString)
        Catch ex As Exception
            returnStr = "Error: Download SuccessTrials Serial Port Write error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            blnDownloadSuccess = False
            Return returnStr
        End Try
        Thread.Sleep(250)

        Try
            '   Wait for Echo
            strResult = comPort.ReadLine()
        Catch ex As Exception
            returnStr = "Error: Download SuccessTrials Serial Port Read error: " & ex.Message & vbCrLf
            MessageBox.Show(returnStr)
            Return returnStr
        End Try

        StatusMessage = "SuccessTrials = " & status.SuccessTrials.ToString
        worker.ReportProgress(4, StatusMessage)





        '****************  Send Success/Fail Code  *********************

        If blnDownloadSuccess = True Then
            comPort.Write("1")
            Thread.Sleep(500)
            strResult = comPort.ReadLine()

            returnStr = "Config Params Download Success at: " & Format(Now, "MM/dd/yyyy HH:mm:ss") & vbCrLf &
                status.NumberOfTrials & " | " & status.SelectionMode & " | " & status.SettleTime &
                " | " & status.TrialDuration & " | " & status.SeekTime & " | " & status.InterTrialSettleTime & " | " & status.SettleLight &
                " | " & status.AcceptLight & " | " & status.RejectLight & " | " & status.WaitForStartLight &
                " | " & status.FaultOutTrials_Percent & " | " & status.FaultOutTrials_SideSwaps & " | " & status.FaultOutPercent & " | " & status.ShockVoltage &
                " | " & status.ShockInterval & " | " & status.ShockDuration & " | " & status.SuccessTrials & vbCrLf & vbCrLf

            Return returnStr
        Else
            comPort.Write("0")
            Thread.Sleep(500)
            strResult = comPort.ReadLine()
            returnStr = "Config Params Download Failed" & vbCrLf

            Return returnStr
        End If

        Return "At Download End Function"  ' Should never be here

    End Function

    Public Shared Function ColorWords(ByVal strColorLetter As String) As String
        '
        '   This function expands the single letter color code returned from the
        '   Arduino into the full color word for use in the UI.
        '
        strColorLetter = Left(strColorLetter, 1)
        strColorLetter = strColorLetter.ToUpper

        If strColorLetter.Equals("W") Then
            Return "White"
        ElseIf strColorLetter.Equals("O") Then
            Return "Off"
        ElseIf strColorLetter.Equals("R") Then
            Return "Red"
        ElseIf strColorLetter.Equals("G") Then
            Return "Green"
        ElseIf strColorLetter.Equals("B") Then
            Return "Blue"
        Else
            MessageBox.Show("Error in ColorWords - Rcvd from Arduino: " & strColorLetter)
            Return "ERROR COLOR: " & strColorLetter
        End If
    End Function
End Class
