Imports System.IO
Imports System.Windows.Forms
Imports System.Math

Module globais

    Public estado As Integer = 1
    Public batedores As New List(Of String)
    Public imagens As New List(Of relacaoImagem)
    Public indiceImagem As Integer

    Public Function calcDistanciaPeApoio(ByVal i As Integer) As String
        Return (Pow(Pow(imagens(i).pontos(0).X - imagens(i).pontos(1).X, 2) + Pow(imagens(i).pontos(0).Y - imagens(i).pontos(1).Y, 2), 0.5))
    End Function
    Public Function calcInclinacaoPernas(ByVal i As Integer) As String
        Return Atan(Abs(imagens(i).pontos(1).Y - imagens(i).pontos(2).Y) / Abs(imagens(i).pontos(1).X - imagens(i).pontos(2).X)) * (180 / PI)
    End Function
    Public Function calcDistanciaOmbros(ByVal i As Integer) As String
        Return (Pow(Pow(imagens(i).pontos(3).X - imagens(i).pontos(4).X, 2) + Pow(imagens(i).pontos(3).Y - imagens(i).pontos(4).Y, 2), 0.5))
    End Function
    Public Function calcInclinacaoOmbros(ByVal i As Integer) As String
        Return Atan(Abs(imagens(i).pontos(3).Y - imagens(i).pontos(4).Y) / Abs(imagens(i).pontos(3).X - imagens(i).pontos(4).X)) * (180 / PI)
    End Function

    Public Function trataDados(ByVal i As Integer) As String

        Dim s As New List(Of String)

        's.Add(imagens(i).batedor)
        ' pega batedor
        ' s.Add("Vitor")

        ' distancia do pe de apoio
        s.Add(calcDistanciaPeApoio(i))

        ' inclinacao das pernas (graus)
        s.Add(calcInclinacaoPernas(i))

        ' distancia entre ombros
        s.Add(calcDistanciaOmbros(i))

        ' inclinacao ombros (graus)
        s.Add(calcInclinacaoOmbros(i))

        ' esquerda ou direita (meio)?
        s.Add(imagens(i).lado.ToLower)

        Return Format(CDbl(s(0)), "#.###").Replace(",", ".") + "," + Format(CDbl(s(1)), "#.###").Replace(",", ".") + "," + Format(CDbl(s(2)), "#.###").Replace(",", ".") + "," + Format(CDbl(s(3)), "#.###").Replace(",", ".") + "," + s(4)

    End Function


    Public Sub zeraIndiceImagem()
        indiceImagem = 0
    End Sub

    Public Function nomeArquivo(ByVal a As String) As String
        Return Path.GetFileName(a)
    End Function

    Public Sub saveArff()
        Dim tstamp As object = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
        My.Computer.FileSystem.CopyFile(
            Application.StartupPath + "/model_bkp.arff",
            Application.StartupPath + "/model_" + tstamp.ToString + ".arff")
        Using sw As StreamWriter = File.AppendText(Application.StartupPath + "/model_" + tstamp.ToString + ".arff")
            For i = 0 To imagens.Count - 1
                sw.WriteLine(trataDados(i))
            Next
        End Using
    End Sub

End Module
