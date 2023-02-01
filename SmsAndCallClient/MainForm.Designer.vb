Namespace MatthiWare.SmsAndCallClient
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.cbApis = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.cbSms = New System.Windows.Forms.CheckBox()
			Me.cbCall = New System.Windows.Forms.CheckBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.txtFrom = New System.Windows.Forms.TextBox()
			Me.txtTo = New System.Windows.Forms.TextBox()
			Me.txtBody = New System.Windows.Forms.TextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.btnText = New System.Windows.Forms.Button()
			Me.btnCall = New System.Windows.Forms.Button()
			Me.lblStatus = New System.Windows.Forms.Label()
			Me.btnUpdateStatus = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' cbApis
			' 
			Me.cbApis.FormattingEnabled = True
			Me.cbApis.Location = New System.Drawing.Point(110, 12)
			Me.cbApis.Name = "cbApis"
			Me.cbApis.Size = New System.Drawing.Size(203, 21)
			Me.cbApis.TabIndex = 0
'			Me.cbApis.SelectedValueChanged += New System.EventHandler(Me.cbApis_SelectedValueChanged)
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(92, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Select API to use:"
			' 
			' cbSms
			' 
			Me.cbSms.AutoSize = True
			Me.cbSms.Enabled = False
			Me.cbSms.Location = New System.Drawing.Point(15, 43)
			Me.cbSms.Name = "cbSms"
			Me.cbSms.Size = New System.Drawing.Size(141, 17)
			Me.cbSms.TabIndex = 2
			Me.cbSms.Text = "Can send text messages"
			Me.cbSms.UseVisualStyleBackColor = True
			' 
			' cbCall
			' 
			Me.cbCall.AutoSize = True
			Me.cbCall.Enabled = False
			Me.cbCall.Location = New System.Drawing.Point(15, 66)
			Me.cbCall.Name = "cbCall"
			Me.cbCall.Size = New System.Drawing.Size(64, 17)
			Me.cbCall.TabIndex = 3
			Me.cbCall.Text = "Can call"
			Me.cbCall.UseVisualStyleBackColor = True
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 90)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(33, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "From:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(10, 116)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(26, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = "To: "
			' 
			' txtFrom
			' 
			Me.txtFrom.Location = New System.Drawing.Point(51, 87)
			Me.txtFrom.Name = "txtFrom"
			Me.txtFrom.Size = New System.Drawing.Size(262, 20)
			Me.txtFrom.TabIndex = 6
			' 
			' txtTo
			' 
			Me.txtTo.Location = New System.Drawing.Point(51, 113)
			Me.txtTo.Name = "txtTo"
			Me.txtTo.Size = New System.Drawing.Size(262, 20)
			Me.txtTo.TabIndex = 7
			' 
			' txtBody
			' 
			Me.txtBody.Location = New System.Drawing.Point(15, 157)
			Me.txtBody.Multiline = True
			Me.txtBody.Name = "txtBody"
			Me.txtBody.Size = New System.Drawing.Size(298, 146)
			Me.txtBody.TabIndex = 8
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(12, 141)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(56, 13)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Message: "
			' 
			' btnText
			' 
			Me.btnText.Enabled = False
			Me.btnText.Location = New System.Drawing.Point(15, 309)
			Me.btnText.Name = "btnText"
			Me.btnText.Size = New System.Drawing.Size(141, 23)
			Me.btnText.TabIndex = 10
			Me.btnText.Text = "Sms"
			Me.btnText.UseVisualStyleBackColor = True
'			Me.btnText.Click += New System.EventHandler(Me.btnText_Click)
			' 
			' btnCall
			' 
			Me.btnCall.Enabled = False
			Me.btnCall.Location = New System.Drawing.Point(162, 309)
			Me.btnCall.Name = "btnCall"
			Me.btnCall.Size = New System.Drawing.Size(151, 23)
			Me.btnCall.TabIndex = 11
			Me.btnCall.Text = "Call"
			Me.btnCall.UseVisualStyleBackColor = True
'			Me.btnCall.Click += New System.EventHandler(Me.btnCall_Click)
			' 
			' lblStatus
			' 
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Location = New System.Drawing.Point(12, 341)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New System.Drawing.Size(82, 13)
			Me.lblStatus.TabIndex = 12
			Me.lblStatus.Text = "Status: waiting.."
			' 
			' btnUpdateStatus
			' 
			Me.btnUpdateStatus.Location = New System.Drawing.Point(238, 336)
			Me.btnUpdateStatus.Name = "btnUpdateStatus"
			Me.btnUpdateStatus.Size = New System.Drawing.Size(75, 23)
			Me.btnUpdateStatus.TabIndex = 13
			Me.btnUpdateStatus.Text = "Refresh"
			Me.btnUpdateStatus.UseVisualStyleBackColor = True
'			Me.btnUpdateStatus.Click += New System.EventHandler(Me.btnUpdateStatus_Click)
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(330, 365)
			Me.Controls.Add(Me.btnUpdateStatus)
			Me.Controls.Add(Me.lblStatus)
			Me.Controls.Add(Me.btnCall)
			Me.Controls.Add(Me.btnText)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.txtBody)
			Me.Controls.Add(Me.txtTo)
			Me.Controls.Add(Me.txtFrom)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.cbCall)
			Me.Controls.Add(Me.cbSms)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.cbApis)
			Me.Name = "MainForm"
			Me.Text = "MainForm"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents cbApis As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private cbSms As System.Windows.Forms.CheckBox
		Private cbCall As System.Windows.Forms.CheckBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private txtFrom As System.Windows.Forms.TextBox
		Private txtTo As System.Windows.Forms.TextBox
		Private txtBody As System.Windows.Forms.TextBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents btnText As System.Windows.Forms.Button
		Private WithEvents btnCall As System.Windows.Forms.Button
		Private lblStatus As System.Windows.Forms.Label
		Private WithEvents btnUpdateStatus As System.Windows.Forms.Button
	End Class
End Namespace

