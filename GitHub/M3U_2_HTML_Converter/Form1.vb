Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1
     
        Private Sub Btn_Convert_Click(sender As Object, e As EventArgs) Handles Btn_Convert.Click
            Dim openFileDialog1 As New OpenFileDialog()

            ' Define o filtro de extensão do arquivo
            openFileDialog1.Filter = "Arquivos de lista (*.m3u)|*.m3u"

            ' Exibe a janela de seleção de arquivo
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                ' Abre o arquivo selecionado
                Dim sr As New StreamReader(openFileDialog1.FileName)
                Dim line As String = sr.ReadLine()

                ' Define o padrão Regex para as tags tvg-logo e group-title
                Dim tvgLogoRegex As New Regex("tvg-logo=""(.*?)""")
                Dim groupTitleRegex As New Regex("group-title=""(.*?)""")

                ' Define o caminho do arquivo de saída
                Dim outputFile As String = Path.Combine(Path.GetDirectoryName(openFileDialog1.FileName), TextBox1.Text + ".html")

                ' Cria o arquivo de saída e escreve o cabeçalho do HTML
                Dim sw As New StreamWriter(outputFile, False)
                sw.WriteLine("<html>")
                sw.WriteLine("<head>")
                sw.WriteLine("<meta charset=""utf-8"">")
                sw.WriteLine("<meta name=""viewport"" content=""width=device-width, initial-scale=1"">")
                sw.WriteLine("<link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"" integrity=""sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE5yi9TK3j5MYYd+5QwoXI"" crossorigin=""anonymous"">")
                sw.WriteLine("<style>")
                sw.WriteLine(".container { display: grid; grid-template-columns: repeat(auto-fit, minmax(240px, 1fr)); grid-gap: 10px; margin: 20px; }")
                sw.WriteLine(".cell { border: 1px solid #ddd; padding: 10px; text-align: center; border-radius: 10px; transition: all 0.3s ease; }")
                sw.WriteLine(".cell img { width: 100%; height: 200px; object-fit: cover; margin-bottom: 10px; }")
                sw.WriteLine(".cell h3 { margin: 0; font-size: 18px; font-weight: bold; font-family: 'Roboto', sans-serif; color: #383838; }")
                sw.WriteLine(".cell p { margin: 0; font-size: 14px; font-family: 'Roboto', sans-serif; color: #383838; }")
                sw.WriteLine(".cell a { color: #007bff; text-decoration: none; }")
                sw.WriteLine(".cell:focus, .cell:hover { border-color: #7d7d7d; box-shadow: 0 0 5px #7d7d7d; }")
                sw.WriteLine(".cell:focus h3, .cell:hover h3, .cell:focus p, .cell:hover p { color: #6a0dad; }")
                sw.WriteLine("</style>")
                sw.WriteLine("</head>")
                sw.WriteLine("<body>")
                sw.WriteLine("<div class=""container"">")


                ' Inicia o contador de tabindex
                Dim tabIndexCount As Integer = 1

                ' Percorre todas as linhas do arquivo de entrada
                Do While Not line Is Nothing
                    If line.StartsWith("#EXTINF:") Then
                        ' Inicia uma nova célula com tabindex
                        sw.WriteLine("<div class=""cell"" tabindex=""" & tabIndexCount & """>")
                        tabIndexCount += 1

                        ' Extrai as informações da tag tvg-logo, se existir
                        Dim tvgLogoMatch As Match = tvgLogoRegex.Match(line)
                        If tvgLogoMatch.Success Then
                            sw.WriteLine("<img src=""" & tvgLogoMatch.Groups(1).Value & """ />")
                        End If

                        ' Extrai as informações da tag group-title e do nome do conteúdo
                        Dim groupTitleMatch As Match = groupTitleRegex.Match(line)
                        If groupTitleMatch.Success Then
                            Dim groupTitle As String = groupTitleMatch.Groups(1).Value
                            Dim contentName As String = line.Split(","c)(1).Trim()
                            sw.WriteLine("<h3>" & groupTitle & " - " & contentName & "</h3>")
                        End If

                        ' Extrai o link do conteúdo final
                        Dim link As String = sr.ReadLine()

                        ' Escreve o link no HTML
                        sw.WriteLine("<p><a href=""" & link & """>Link</a></p>")

                        ' Fecha a célula
                        sw.WriteLine("</div>")
                    End If

                    ' Lê a próxima linha
                    line = sr.ReadLine()
                Loop


                'ALTERNATIVO
                Dim script As String = "<script>" & Environment.NewLine
                script += "var cells = document.querySelectorAll('.cell');" & Environment.NewLine
                script += "cells.forEach(function(cell) {" & Environment.NewLine
                script += "    cell.addEventListener('keydown', function(event) {" & Environment.NewLine
                script += "        if (event.keyCode === 13) {" & Environment.NewLine
                script += "            var link = cell.querySelector('a');" & Environment.NewLine
                script += "            if (link) {" & Environment.NewLine
                script += "                link.click();" & Environment.NewLine
                script += "            }" & Environment.NewLine
                script += "        }" & Environment.NewLine
                script += "    });" & Environment.NewLine
                script += "});" & Environment.NewLine
                script += "</script>" & Environment.NewLine


                ' Escreve o script no arquivo
                sw.WriteLine(script)

                ' Fecha o arquivo de saída e exibe a mensagem de sucesso
                sw.WriteLine("</div>")
                sw.WriteLine("</body>")
                sw.WriteLine("</html>")
                sw.Close()
                MessageBox.Show("Arquivo exportado com sucesso: " & outputFile)

                Dim htmlFile As String = Path.Combine(Path.GetDirectoryName(openFileDialog1.FileName), TextBox1.Text + ".html")
                Process.Start(htmlFile)


            End If
        End Sub



    End Class
