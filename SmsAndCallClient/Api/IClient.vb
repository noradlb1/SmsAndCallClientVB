Imports System.Threading.Tasks

Namespace MatthiWare.SmsAndCallClient.Api
	Public Interface IClient
		''' <summary>
		''' Indicates if the client is initialized or not
		''' use <see cref="Init"/> to initialize the client.
		''' </summary>
		Property IsInitialized() As Boolean

		''' <summary>
		''' Indicates if the client supports sending text messages
		''' </summary>
		ReadOnly Property CanSendSms() As Boolean

		''' <summary>
		''' Inidicates if the client supports calls
		''' </summary>
		ReadOnly Property CanCall() As Boolean

		''' <summary>
		''' Inidicates if the from number is required
		''' </summary>
		ReadOnly Property FromNumberRequired() As Boolean

		''' <summary>
		''' Initializes the client and marks the client as <see cref="IsInitialized"/> 
		''' </summary>
		Sub Init()

		''' <summary>
		''' Calls the number asynchronously
		''' </summary>
		''' <param name="from">The from number can be optional <see cref="FromNumberRequired"/> </param>
		''' <param name="to">The number to call</param>
		''' <param name="msg">What we want to say</param>
		''' <returns>The response</returns>
		Function CallAsync(ByVal from As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse)

		''' <summary>
		''' Sends a text message asynchronously
		''' </summary>
		''' <param name="from">The from number can be optional <see cref="FromNumberRequired"/> </param>
		''' <param name="to">The number to text</param>
		''' <param name="msg">The message</param>
		''' <returns>The response</returns>
		Function SendSmsAsync(ByVal form As String, ByVal [to] As String, ByVal msg As String) As Task(Of IResponse)

		''' <summary>
		''' The client name
		''' </summary>
		Overloads Function ToString() As String
	End Interface
End Namespace
