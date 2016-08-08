'
' Created by SharpDevelop.
' User: Get
' Date: 01/08/2016
' Time: 11:04
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.button1 = New System.Windows.Forms.Button()
		Me.textBox1 = New System.Windows.Forms.TextBox()
		Me.textBox2 = New System.Windows.Forms.TextBox()
		Me.textBox3 = New System.Windows.Forms.TextBox()
		Me.button2 = New System.Windows.Forms.Button()
		Me.button3 = New System.Windows.Forms.Button()
		Me.SuspendLayout
		'
		'button1
		'
		Me.button1.Location = New System.Drawing.Point(12, 371)
		Me.button1.Name = "button1"
		Me.button1.Size = New System.Drawing.Size(711, 36)
		Me.button1.TabIndex = 0
		Me.button1.Text = "VAI"
		Me.button1.UseVisualStyleBackColor = true
		AddHandler Me.button1.Click, AddressOf Me.Button1Click
		'
		'textBox1
		'
		Me.textBox1.Location = New System.Drawing.Point(12, 12)
		Me.textBox1.Multiline = true
		Me.textBox1.Name = "textBox1"
		Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox1.Size = New System.Drawing.Size(233, 353)
		Me.textBox1.TabIndex = 1
		'
		'textBox2
		'
		Me.textBox2.Location = New System.Drawing.Point(251, 12)
		Me.textBox2.Multiline = true
		Me.textBox2.Name = "textBox2"
		Me.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox2.Size = New System.Drawing.Size(233, 353)
		Me.textBox2.TabIndex = 2
		'
		'textBox3
		'
		Me.textBox3.Location = New System.Drawing.Point(490, 12)
		Me.textBox3.Multiline = true
		Me.textBox3.Name = "textBox3"
		Me.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox3.Size = New System.Drawing.Size(233, 353)
		Me.textBox3.TabIndex = 3
		'
		'button2
		'
		Me.button2.Location = New System.Drawing.Point(12, 416)
		Me.button2.Name = "button2"
		Me.button2.Size = New System.Drawing.Size(711, 36)
		Me.button2.TabIndex = 4
		Me.button2.Text = "Treina"
		Me.button2.UseVisualStyleBackColor = true
		AddHandler Me.button2.Click, AddressOf Me.Button2Click
		'
		'button3
		'
		Me.button3.Location = New System.Drawing.Point(12, 460)
		Me.button3.Name = "button3"
		Me.button3.Size = New System.Drawing.Size(711, 36)
		Me.button3.TabIndex = 5
		Me.button3.Text = "Erro"
		Me.button3.UseVisualStyleBackColor = true
		AddHandler Me.button3.Click, AddressOf Me.Button3Click
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(737, 508)
		Me.Controls.Add(Me.button3)
		Me.Controls.Add(Me.button2)
		Me.Controls.Add(Me.textBox3)
		Me.Controls.Add(Me.textBox2)
		Me.Controls.Add(Me.textBox1)
		Me.Controls.Add(Me.button1)
		Me.Name = "MainForm"
		Me.Text = "tcc"
		AddHandler Load, AddressOf Me.MainFormLoad
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private button3 As System.Windows.Forms.Button
	Private button2 As System.Windows.Forms.Button
	Private textBox3 As System.Windows.Forms.TextBox
	Private textBox2 As System.Windows.Forms.TextBox
	Private textBox1 As System.Windows.Forms.TextBox
	Private button1 As System.Windows.Forms.Button
	
End Class
