Public Partial Class MainForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub MainFormLoad(sender As Object, e As EventArgs)
		inicializaInputsOutputs()
		inicializaNos()
	End Sub
	
	Sub Button1Click(sender As Object, e As EventArgs)
		showTB()
	End Sub
	
	
	Sub Button2Click(sender As Object, e As EventArgs)
		' treinando a funcao a+b=c
		Dim n As Integer = 500
		
		rollOut()
		showTB()
		
	End Sub
	
	Private Sub showTB
		
		textBox1.Clear()
		textBox2.Clear()
		textBox3.Clear()
		
		For i = 0 To inputNodes.Count - 1
			textBox1.Text = textBox1.Text & "Node: " & inputNodes(i).id & ": " & inputNodes(i).value & vbCrLf
			For j = 0 To inputNodes(i).connOut.Count-1
				textBox1.Text = textBox1.Text & "> " & inputNodes(i).connOut(j).nodeOut.id & "; " & inputNodes(i).connOut(j).weight & vbCrLf
			Next
		Next
		For i = 0 To hiddenNodes.Count - 1
			textBox2.Text = textBox2.Text & "Node: " & hiddenNodes(i).id & ": " & hiddenNodes(i).value & vbCrLf
			For j = 0 To hiddenNodes(i).connOut.Count-1
				textBox2.Text = textBox2.Text & "> " & hiddenNodes(i).connOut(j).nodeOut.id & "; " & hiddenNodes(i).connOut(j).weight & vbCrLf
			Next
		Next
		For i = 0 To outputNodes.Count - 1
			textBox3.Text = textBox3.Text & "Node: " & outputNodes(i).id & ": " & outputNodes(i).value & vbCrLf
			For j = 0 To outputNodes(i).connOut.Count-1
				textBox3.Text = textBox3.Text & "> " & outputNodes(i).connOut(j).nodeOut.id & "; " & outputNodes(i).connOut(j).weight & vbCrLf
			Next
		Next
	End Sub
	
	Sub Button3Click(sender As Object, e As EventArgs)
		msgbox(totalError())
	End Sub
	
End Class
