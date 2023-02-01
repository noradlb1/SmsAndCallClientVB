Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks
Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Namespace MatthiWare.SmsAndCallClient.Api
	Public Class TwilioWrapperClient
		Implements IClient

		''' <summary>
		''' the authentication items
		''' </summary>
		Private ReadOnly m_sid, m_auth As String

		Public Sub New(ByVal sid As String, ByVal auth As String)
			m_sid = sid
			m_auth = auth
		End Sub

		Public ReadOnly Property CanCall() As Boolean Implements IClient.CanCall
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property CanSendSms() As Boolean Implements IClient.CanSendSms
			Get
				Return True
			End Get
		End Property

		Public ReadOnly Property FromNumberRequired() As Boolean Implements IClient.FromNumberRequired
			Get
				Return True
			End Get
		End Property

		Public Property IsInitialized() As Boolean Implements IClient.IsInitialized

		Public Sub Init() Implements IClient.Init
			TwilioClient.Init(m_sid, m_auth)

			IsInitialized = True
		End Sub

		Public Async Function CallAsync(ByVal from As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse) Implements IClient.CallAsync
			Dim pnFrom = New PhoneNumber(from)
			Dim pnTo = New PhoneNumber([to])

			Dim body = WebUtility.UrlEncode(msg)

			Dim [call] = Await CallResource.CreateAsync(pnTo, pnFrom, url:= New Uri($"https://handler.twilio.com/twiml/EH551ae48b51b996d131ebe9a19372ad6f?body={body}"))

			Return New CallResponse([call])
		End Function

		Public Async Function SendSmsAsync(ByVal form As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse) Implements IClient.SendSmsAsync
			Dim pnFrom = New PhoneNumber(form)
			Dim pnTo = New PhoneNumber([to])

			Dim text = Await MessageResource.CreateAsync(pnTo, from:= pnFrom, body:= msg)

			Return New TextResponse(text)
		End Function

		Public Overrides Function ToString() As String Implements IClient.ToString
			Return "Twilio API"
		End Function

		Public Class CallResponse
			Implements IResponse

			Private m_sid As String

			Public ReadOnly Property CanUpdate() As Boolean Implements IResponse.CanUpdate
				Get
					Return True
				End Get
			End Property

			Public Property Status() As String Implements IResponse.Status

			Public Sub New(ByVal [call] As CallResource)
				SetCall([call])
			End Sub

			Private Sub SetCall(ByVal [call] As CallResource)
				m_sid = [call].Sid
				Status = [call].Status.ToString()
			End Sub

			Public Async Function UpdateAsync() As Task Implements IResponse.UpdateAsync
				Dim [call] = Await CallResource.FetchAsync(m_sid)
				SetCall([call])
			End Function
		End Class

		Public Class TextResponse
			Implements IResponse

			Private m_sid As String

			Public ReadOnly Property CanUpdate() As Boolean Implements IResponse.CanUpdate
				Get
					Return True
				End Get
			End Property

			Public Property Status() As String Implements IResponse.Status

			Public Sub New(ByVal [call] As MessageResource)
				SetMessage([call])
			End Sub

			Private Sub SetMessage(ByVal [call] As MessageResource)
				m_sid = [call].Sid
				Status = [call].Status.ToString()
			End Sub

			Public Async Function UpdateAsync() As Task Implements IResponse.UpdateAsync
				Dim [call] = Await MessageResource.FetchAsync(m_sid)

				SetMessage([call])
			End Function
		End Class
	End Class
End Namespace
