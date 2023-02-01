Imports System
Imports System.Windows.Forms
Imports Twilio.TwiML

Namespace MatthiWare.SmsAndCallClient
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Console.WriteLine((New VoiceResponse()).Say("{body}", language:= "en", voice:= "alice").Hangup())

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New MainForm())
		End Sub
	End Class
End Namespace
