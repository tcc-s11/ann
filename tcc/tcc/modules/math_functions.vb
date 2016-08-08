Imports System.Math

Public module math_functions
	
	Public Sub backpropragation_algorithm 
		
		
	End Sub
	
	
	Public Sub rollOut
		For i = 0 To hiddenNodes.Count - 1
			Dim sumValue As Double = 0.0
			For k = 0 To inputNodes.Count -1
				For j = 0 To inputNodes(k).connOut.Count -1
					If inputNodes(k).connOut(j).nodeOut.id = hiddenNodes(i).id Then
						sumValue += inputNodes(k).connOut(j).weight * inputNodes(k).value 
					End If
				Next
			Next
			hiddenNodes(i).value = sumValue
		Next
		For i = 0 To outputNodes.Count - 1
			Dim sumValue As Double = 0.0
			For k = 0 To hiddenNodes.Count -1
				For j = 0 To hiddenNodes(k).connOut.Count -1
					If hiddenNodes(k).connOut(j).nodeOut.id = outputNodes(i).id Then
						sumValue += hiddenNodes(k).connOut(j).weight * hiddenNodes(k).value 
					End If
				Next
			Next
			outputNodes(i).value = sumValue
		Next
	End Sub
	
	Public Function totalError() As Double
		Dim sumError As Double
		For k = 0 To inputs.Count-1
			For i = 0 To inputNodes.Count-1
				inputNodes(i).value = inputs(k)(i)
			Next
			rollOut()
			For i = 0 To outputNodes.Count-1
				sumError = 1/2*pow(outputNodes(i).value - outputs(k)(i), 2)
			Next
		Next
		Return sumError
	End Function
	
	Public Function	sigmoid(ByVal net As Double) As Double
		Dim k As Double = 1.0
		Return (1 / (1 + Pow(E, -k*net)))		
	End Function
	
	
End Module
