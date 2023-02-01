Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO

Namespace MatthiWare.SmsAndCallClient.Api
    Public Class ClickatellWrapperClient
        Implements IClient
        Private Const URL As String = "https://platform.clickatell.com/messages"
        Private Const CONTENT_TYPE_JSON As String = "application/json"

        Private ReadOnly m_auth As String

        Public ReadOnly Property CanCall As Boolean Implements IClient.CanCall
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property CanSendSms As Boolean Implements IClient.CanSendSms
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property FromNumberRequired As Boolean Implements IClient.FromNumberRequired
            Get
                Return False
            End Get
        End Property

        Public Property IsInitialized As Boolean Implements IClient.IsInitialized

        Public Sub New(ByVal api As String)
            m_auth = api
        End Sub

        Public Sub Init() Implements IClient.Init
            IsInitialized = True

            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol Or CType(3072, SecurityProtocolType)
        End Sub

        Public Overrides Function ToString() As String Implements IClient.ToString
            Return "Clickatell API"
        End Function

        Public Function CallAsync(ByVal from As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse) Implements IClient.CallAsync
            Throw New NotImplementedException()
        End Function

        Public Async Function SendSmsAsync(ByVal form As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse) Implements IClient.SendSmsAsync
            Dim req = WebRequest.CreateHttp(URL)

            req.ContentType = CONTENT_TYPE_JSON
            req.Accept = CONTENT_TYPE_JSON
            req.Method = "POST"

            req.PreAuthenticate = True
            req.Headers.Add(HttpRequestHeader.Authorization, m_auth)

            Using writer = New StreamWriter(Await req.GetRequestStreamAsync())
                Await writer.WriteAsync(New Request([to], msg).ToJson())
                Await writer.FlushAsync()
            End Using

            Using reader = New StreamReader((Await req.GetResponseAsync()).GetResponseStream())
                Dim json = Await reader.ReadToEndAsync()

                Return JsonConvert.DeserializeObject(Of Response)(json)
            End Using

        End Function

        Private Class Request
            <JsonProperty("content")>
            Public Property Content As String

            <JsonProperty("to")>
            Public Property [To] As List(Of String) = New List(Of String)()

            Public Sub New(ByVal [to] As String, ByVal msg As String)
                Content = msg
                Me.To.Add([to])
            End Sub

            Public Function ToJson() As String
                Return JsonConvert.SerializeObject(Me)
            End Function
        End Class

        Public Class Message
            <JsonProperty("apiMessageId")>
            Public Property ApiMessageId As String

            <JsonProperty("accepted")>
            Public Property Accepted As Boolean

            <JsonProperty("to")>
            Public Property [To] As String

            <JsonProperty("error")>
            Public Property [Error] As Object
        End Class

        Public Class Response
            Implements IResponse
            <JsonProperty("messages")>
            Public Property Messages As List(Of Message)

            <JsonProperty("error")>
            Public Property [Error] As Object

            Public Property Status As String Implements IResponse.Status
                Get
                    If [Error] IsNot Nothing Then
                        Return [Error].ToString()
                    ElseIf Messages(0).Error IsNot Nothing Then
                        Return Messages(0).Error.ToString()
                    Else
                        Return If(Messages(0).Accepted, "Delivered", "Failed")
                    End If
                End Get
                Set(ByVal value As String)
                End Set
            End Property

            Public ReadOnly Property CanUpdate As Boolean Implements IResponse.CanUpdate
                Get
                    Return False
                End Get
            End Property

            Public Function UpdateAsync() As Task Implements IResponse.UpdateAsync
                Throw New NotImplementedException()
            End Function
        End Class

    End Class
End Namespace
