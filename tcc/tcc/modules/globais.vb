Imports System.IO

Public Module globais
	
	Public node(100) As nodes
	Public inputNodes As New List(Of nodes)
	Public outputNodes As New List(Of nodes)
	Public hiddenNodes As New List(Of nodes)
	Public n_inputs, n_hidden, n_outputs, n_training_sets As Integer
	
	Public inputs As New List(Of List(Of double))
	Public outputs As New List(Of List(Of double))
	
	Public Sub inicializaNos
		
		' 8x3x8
		' instancia os nós
		For i = 0 To n_inputs - 1
			node(i) = New nodes
			node(i).id = i
			inputNodes.Add(node(i))
		Next
		For i = n_inputs To n_inputs + n_hidden - 1
			node(i) = New nodes
			node(i).id = i
			hiddenNodes.Add(node(i))
		Next
		For i = n_inputs + n_hidden To n_inputs + n_hidden + n_outputs - 1
			node(i) = New nodes
			node(i).id = i
			outputNodes.Add(node(i))
		Next
		
		' seta conexoes dos inputs
		For i = 0 To inputNodes.Count - 1
			For j = 0 To hiddenNodes.Count - 1
				Dim conAux As New connections
				conAux.nodeOut = hiddenNodes(j)
				conAux.weight = Rnd() - 0.5
				inputNodes(i).connOut.Add(conAux)
			Next
		Next
		' seta conexoes dos hidden layers
		For i = 0 To hiddenNodes.Count - 1
			For j = 0 To outputNodes.Count - 1
				Dim conAux As New connections
				conAux.nodeOut = outputNodes(j)
				conAux.weight = Rnd() - 0.5
				hiddenNodes(i).connOut.Add(conAux)
			Next
		Next
		
		For i = 0 To inputNodes.Count-1
			inputNodes(i).value = inputs(0)(i)
		Next
		
	End Sub
	
	Public Sub inicializaInputsOutputs
		getInputData("test.txt")
		MsgBox("breakpoint")
	End Sub
	
	Public Sub getInputData(ByVal texto As String)
		
		Dim paramAux As String = ""
		Dim listAux As new List(Of Double)
		Dim params As Integer = 1
		Dim inputsLidos, outputsLidos As Integer
		Dim addToListInputs, addToListOutputs As Boolean
		
		inputsLidos = 0
		outputsLidos = 0
		addToListInputs = False
		addToListOutputs = false
		
		For Each line As String In File.ReadLines(Application.StartupPath & "\" & texto)
			Try
				For Each caracter As Char In line
					If caracter <> "@" Then
						If params = 1 Then
							n_inputs = Int(line)
							params = params + 1
						elseIf params = 2 Then
							n_hidden = int(line)
							params = params + 1	
						elseIf params = 3 Then
							n_outputs = int(line)
							params = params + 1
						elseIf params = 4 Then
							n_training_sets = int(line)
							params = params + 1
						elseIf params = 5 then
							If caracter = ";" Then
								listAux.Add(CDbl(paramAux))
								paramAux = ""
							Else
								paramAux = paramAux & caracter	
							End If
							addToListInputs = true
						elseIf params = 6 then
							If caracter = ";" Then
								listAux.Add(CDbl(paramAux))
								paramAux = ""
							Else
								paramAux = paramAux & caracter	
							End If
							addToListOutputs = True
						End If
					Else
						Exit for
					End if
				Next
			Catch ex As Exception
				MsgBox("Nao foi possivel pegar os dados. Parece q a formatacao do txt ta cagada hein")	
			End Try
			If addToListInputs = True Then
				If inputsLidos <= n_inputs Then
					inputs.add(listAux)
					listAux = New List(Of Double)
					addToListInputs = False
				End If
				inputsLidos += 1
				If n_training_sets = inputsLidos Then
					params = 6
				End If
			End If
			If addToListOutputs = True Then
				If outputsLidos <= n_outputs Then
					outputs.add(listAux)
					listAux = New List(Of Double)
					addToListOutputs = False
				End If
				outputsLidos += 1
				If n_training_sets = outputsLidos Then
					params = 7
				End If
			End If
		Next

	End Sub
	
End Module
