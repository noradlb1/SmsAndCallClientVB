Imports System.Threading.Tasks

Namespace MatthiWare.SmsAndCallClient.Api
	Public Interface IResponse
		''' <summary>
		''' The response status
		''' </summary>
		Property Status() As String

		''' <summary>
		''' Indicates if the response can update
		''' </summary>
		ReadOnly Property CanUpdate() As Boolean

		''' <summary>
		''' Updates the response asynchronously 
		''' </summary>
		''' <returns>An awaitable task</returns>
		Function UpdateAsync() As Task
	End Interface
End Namespace
