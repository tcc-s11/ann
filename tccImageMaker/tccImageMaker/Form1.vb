Imports System.Math

Public Class Form1

    Private _Previous As System.Nullable(Of Point) = Nothing
    Public sideSize As Integer
    Dim farol As Boolean = True

    'Private Sub pictureBox1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDown
    '    _Previous = e.Location
    '    pictureBox1_MouseClick(sender, e)
    'End Sub

    Private Sub pictureBox1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseClick
        If imagens.Count > 0 Then
            If farol = True Then
                farol = False
                Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
                    ' g.DrawPie(Pens.White, _Previous.Value, e.Location)
                    ' g.DrawRectangle(Pens.White, e.Location.X - CInt(sideSize / 2), e.Location.Y - CInt(sideSize / 2), sideSize, sideSize)
                    g.FillEllipse(Brushes.Red, e.Location.X - CInt(sideSize / 2), e.Location.Y - CInt(sideSize / 2), sideSize, sideSize)
                    g.DrawString(estado, New Drawing.Font("Arial", 22, FontStyle.Bold), Brushes.DarkOrange, e.Location.X + CInt(sideSize / 2), e.Location.Y + CInt(sideSize / 2))
                    estado += 1
                    imagens(indiceImagem).pontos.Add(New Point(e.Location.X - CInt(sideSize / 2), e.Location.Y - CInt(sideSize / 2)))
                    atualizaTextBox()
                End Using
                PictureBox1.Invalidate()
                _Previous = e.Location
                farol = True
            End If
        End If
    End Sub

    Private Sub pictureBox1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseUp
        _Previous = Nothing
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sideSize = 6
        batedores.Add("Higa")
        batedores.Add("Davi")
        batedores.Add("Zatz")
        batedores.Add("Bruno")
        batedores.Add("Vitor")
        For i = 0 To batedores.Count - 1
            ComboBox1.Items.Add(batedores(i))
        Next
        Label4.Text = ""
        ComboBox1.SelectedIndex = 0
        InitializeOpenFileDialog()
        zeraIndiceImagem()
        atualizaEstadoBotoes()
        atualizaTextBox()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        Dim dr As DialogResult = Me.OpenFileDialog1.ShowDialog()
        Dim achouUmaImagem As Boolean = False
        If (dr = System.Windows.Forms.DialogResult.OK) Then
            ' Read the files
            imagens.Clear()
            Dim file As String
            Dim count As Integer = 0
            For Each file In OpenFileDialog1.FileNames
                ' Create a PictureBox for each file, and add that file to the FlowLayoutPanel.
                Try
                    Dim loadedImage As Image = Image.FromFile(file)
                    Dim loadedImage2 As Image = Image.FromFile(file)
                    Dim rAux As New relacaoImagem
                    rAux.imagem = loadedImage
                    rAux.imagemOriginal = loadedImage2
                    rAux.path = file
                    rAux.nome = nomeArquivo(file)
                    rAux.lado = (rAux.nome.Split(".")(0)).Split("_")(2)
                    imagens.Add(rAux)
                    achouUmaImagem = True
                    count += 1
                Catch SecEx As Security.SecurityException
                    ' The user lacks appropriate permissions to read files, discover paths, etc.
                    MessageBox.Show("Deu ruim: Sem permissao pra isso")
                Catch ex As Exception
                    ' Could not load the image - probably permissions-related.
                    MessageBox.Show("Deu ruim: Nao conseguiu parsear pra ImageList")
                End Try
            Next file
        End If
        If achouUmaImagem Then
            zeraIndiceImagem()
            PictureBox1.Image = imagens(indiceImagem).imagem
            estado = 1
        End If
        atualizaEstadoBotoes()
        atualizaTextBox()
    End Sub

    Public Sub InitializeOpenFileDialog()
        ' Set the file dialog to filter for graphics files.
        Me.OpenFileDialog1.Filter = _
                "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" + _
                "All files (*.*)|*.*"
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Selecionar as imagens"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        indiceImagem = Max(indiceImagem - 1, 0)
        PictureBox1.Image = imagens(indiceImagem).imagem
        atualizaEstadoBotoes()
        estado = imagens(indiceImagem).pontos.Count + 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        indiceImagem = Min(indiceImagem + 1, imagens.Count - 1)
        PictureBox1.Image = imagens(indiceImagem).imagem
        atualizaEstadoBotoes()
        estado = imagens(indiceImagem).pontos.Count + 1
    End Sub

    Private Sub atualizaTextBox()
        TextBox1.Clear()
        If imagens.Count > 0 Then
            For i = 0 To imagens(indiceImagem).pontos.Count - 1
                TextBox1.Text = TextBox1.Text & (i + 1 & ":" & imagens(indiceImagem).pontos(i).X & "; " & imagens(indiceImagem).pontos(i).Y & vbCrLf)
            Next
            Label3.Text = imagens(indiceImagem).path
            If imagens(indiceImagem).lado.ToLower = "esq" Then
                Label4.Text = "Esquerda"
            ElseIf imagens(indiceImagem).lado.ToLower = "dir" Then
                Label4.Text = "Direita"
            ElseIf imagens(indiceImagem).lado.ToLower = "meio" Then
                Label4.Text = "Meio"
            End If
        End If
    End Sub

    Private Sub atualizaEstadoBotoes()
        Button1.Enabled = True
        Button2.Enabled = True
        If imagens.Count = 0 Then
            Button1.Enabled = False
            Button2.Enabled = False
        End If
        If indiceImagem = 0 Then
            Button1.Enabled = False
        End If
        If indiceImagem = imagens.Count - 1 Then
            Button2.Enabled = False
        End If
        If imagens.Count <> 0 Then
            atualizaTextBox()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If imagens.Count > 0 Then
            imagens(indiceImagem).pontos.Clear()
            imagens(indiceImagem).imagem = imagens(indiceImagem).imagemOriginal.Clone
            PictureBox1.Image = imagens(indiceImagem).imagem
            PictureBox1.Invalidate()
            estado = 1
            atualizaEstadoBotoes()
        End If
    End Sub

    Private Sub SalvarNoTxtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarNoTxtToolStripMenuItem.Click
        Try
            saveArff()
        Catch ex As Exception
            MsgBox("ERRO: vc selecionou pontos em todas as imagens?")
        End Try
    End Sub

End Class