Imports MatthiWare.SmsAndCallClient.Api
Imports System
Imports System.Windows.Forms

Namespace MatthiWare.SmsAndCallClient
	Partial Public Class MainForm
		Inherits Form

		Private m_currentApi As IClient
		Private m_lastResponse As IResponse

		Public Sub New()
			InitializeComponent()
			LoadAPIs()
		End Sub

		Private Sub LoadAPIs()
			cbApis.Items.Add(New ClickatellWrapperClient(Credentials.CLICKATELL_API_KEY))
			cbApis.Items.Add(New TwilioWrapperClient(Credentials.TWILIO_ACC_SID, Credentials.TWILIO_AUTH_TOKEN))
		End Sub

		Private Sub cbApis_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbApis.SelectedValueChanged
			m_currentApi = TryCast(cbApis.SelectedItem, IClient)

			If m_currentApi Is Nothing Then
				Return
			End If

			If Not m_currentApi.IsInitialized Then
				m_currentApi.Init()
			End If

			cbCall.Checked = m_currentApi.CanCall
			cbSms.Checked = m_currentApi.CanSendSms

			btnCall.Enabled = m_currentApi.CanCall
			btnText.Enabled = m_currentApi.CanSendSms

			txtFrom.Enabled = m_currentApi.FromNumberRequired
		End Sub

		Private Async Sub btnText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnText.Click
			btnText.Enabled = False

			Dim from As String = txtFrom.Text
			Dim [to] As String = txtTo.Text
			Dim body As String = txtBody.Text

			SetStatus("Sending...")

			m_lastResponse = Await m_currentApi.SendSmsAsync(from, [to], body)


			btnText.Enabled = True
			SetStatus()
		End Sub

		Private Async Sub btnCall_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCall.Click
			btnCall.Enabled = False

			Dim from As String = txtFrom.Text
			Dim [to] As String = txtTo.Text
			Dim body As String = txtBody.Text

			SetStatus("Sending...")

			m_lastResponse = Await m_currentApi.CallAsync(from, [to], body)

			btnCall.Enabled = True
			SetStatus()
		End Sub

		Private Sub SetStatus()
			If m_lastResponse Is Nothing Then
				Return
			End If

			SetStatus(m_lastResponse.Status)
		End Sub

		Private Sub SetStatus(ByVal value As String)
			lblStatus.Text = $"Status: {value}"
		End Sub

		Private Async Sub btnUpdateStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateStatus.Click
			If m_lastResponse Is Nothing OrElse (Not m_lastResponse.CanUpdate) Then
				Return
			End If

			Await m_lastResponse.UpdateAsync()

			SetStatus()
		End Sub
	End Class
End Namespace
