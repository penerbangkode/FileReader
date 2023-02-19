Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Private openedFilePath As String
    Private openedFileExtension As String
    Private Const CSV = ".csv"
    Private Const TXT = ".txt"
    Private Const FILE_OPEN_FILTER_TXT = "Text files (*.txt)|*.txt"
    Private Const FILE_OPEN_FILTER_CSV = "CSV files (*.csv)|*.csv"

    Private Sub browseFile(sender As Object, e As EventArgs) Handles browse.Click
        ' Open a file dialog to let the user select a file
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = FILE_OPEN_FILTER_TXT + "|" + FILE_OPEN_FILTER_CSV
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Read the contents of the file into a string
            Dim fileContents As String = System.IO.File.ReadAllText(openFileDialog.FileName)
            openedFileExtension = Path.GetExtension(openFileDialog.FileName)
            If (openedFileExtension = TXT) Then
                ' Display the contents of the file in the text editor
                content.Text = fileContents
                filepath.Text = openFileDialog.FileName

                ' Store the path of the opened file
                openedFilePath = openFileDialog.FileName
                ' Show rich text for place content txt
                content.Visible = True
                ' Hide csv datagrid
                content_csv.Visible = False
                ' Show save button
                save.Visible = True
                ' Show save as button
                save_as.Visible = True
            ElseIf (openedFileExtension = CSV) Then
                ' Declare new datatable when open csv file
                Dim dt As New DataTable()

                ' Parse data from csv and set delimited comma
                Using parser As New TextFieldParser(openFileDialog.FileName)
                    parser.TextFieldType = FieldType.Delimited
                    parser.SetDelimiters(",")
                    parser.HasFieldsEnclosedInQuotes = True

                    ' Read the first line to get the column names
                    Dim columnNames As String() = parser.ReadFields()

                    ' Add the columns to the DataTable
                    For Each columnName In columnNames
                        dt.Columns.Add(columnName)
                    Next

                    ' Loop through the remaining lines of the CSV file
                    While Not parser.EndOfData
                        Dim fields As String() = parser.ReadFields()

                        ' Check if the number of fields in the current row exceeds the number of columns in the DataTable
                        If fields.Length > dt.Columns.Count Then
                            ' Add new columns to the DataTable
                            For i As Integer = dt.Columns.Count To fields.Length - 1
                                dt.Columns.Add("Column " & (i + 1))
                            Next
                        End If

                        ' Create a new DataRow and add it to the DataTable
                        Dim newRow As DataRow = dt.NewRow()

                        ' Loop through the fields in the current line and add them to the DataRow
                        For i As Integer = 0 To fields.Length - 1
                            newRow(i) = fields(i)
                        Next

                        ' Add row to datatable
                        dt.Rows.Add(newRow)
                    End While
                End Using

                ' Display the DataTable in a DataGridView
                content_csv.DataSource = dt

                filepath.Text = openFileDialog.FileName
                ' Store the path of the opened file
                openedFilePath = openFileDialog.FileName
                ' Hide richtext txt when open csv file
                content.Visible = False
                ' Show datagridview 
                content_csv.Visible = True
                ' Show save button
                save.Visible = True
                ' Shiw save as button
                save_as.Visible = True
            End If

        End If
    End Sub

    Private Sub saveFile(sender As Object, e As EventArgs) Handles save.Click

        ' If opened file extenstion is TXT .txt
        If (openedFileExtension = TXT) Then
            ' Save changes to the previously opened file
            System.IO.File.WriteAllText(openedFilePath, content.Text)
            ' Show message box after save
            MessageBox.Show("File has been saved at " + openedFilePath)

            ' If opened file extestion is CSV .csv
        ElseIf (openedFileExtension = CSV) Then
            ' Save csv file to opened csv file if returrn true show message box 
            If (saveCsv(openedFilePath)) Then
                MessageBox.Show("File has been saved at " + openedFilePath)
            Else
                ' Show message box failed
                MessageBox.Show("Failed saved file")
            End If

        End If
    End Sub

    Private Sub saveAs(sender As Object, e As EventArgs) Handles save_as.Click
        ' Open save dialog and filter by opened file extension
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = If(openedFileExtension = TXT, FILE_OPEN_FILTER_TXT, FILE_OPEN_FILTER_CSV)

        ' Check dialog show
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Check extension openedfile
            If (openedFileExtension = TXT) Then
                ' Write the contents of the text box control to the selected file
                System.IO.File.WriteAllText(saveFileDialog.FileName, content.Text)
                ' Update the label with the file path
                filepath.Text = saveFileDialog.FileName
                ' Store the path of the saved file
                openedFilePath = saveFileDialog.FileName
                ' Get file extension from save dialog
                openedFileExtension = Path.GetExtension(saveFileDialog.FileName)
                ' Show message box
                MessageBox.Show("File has been saved at " + openedFilePath)
            ElseIf (openedFileExtension = CSV) Then
                If (saveCsv(saveFileDialog.FileName)) Then
                    ' Update the label with the file path
                    filepath.Text = saveFileDialog.FileName
                    ' Store the path of the saved file
                    openedFilePath = saveFileDialog.FileName
                    openedFileExtension = Path.GetExtension(saveFileDialog.FileName)
                    MessageBox.Show("File has been saved at " + saveFileDialog.FileName)
                Else
                    MessageBox.Show("Failed saved file")
                End If
            End If

        End If
    End Sub

    Private Function saveCsv(filePath As String) As Boolean

        ' Create a StreamWriter to write the updated data to a new file
        Dim writer As New StreamWriter(filePath)

        ' Write the column headers to the new file
        Dim column_list = DirectCast(content_csv.Columns, IList)

        For i = 0 To column_list.Count - 1
            Dim column As DataGridViewColumn = DirectCast(column_list(i), DataGridViewColumn)
            If (Not String.IsNullOrEmpty(column.HeaderText)) Then
                writer.Write(column.HeaderText)
                If (Not i = column_list.Count - 1) Then
                    writer.Write(",")
                End If
            End If

        Next
        ' Write new line
        writer.WriteLine()

        ' Write the data rows to the new file
        Dim rowList = DirectCast(content_csv.Rows, IList)

        For i = 0 To rowList.Count - 1
            Dim row As DataGridViewRow = DirectCast(rowList(i), DataGridViewRow)
            Dim cellList = DirectCast(row.Cells, IList)
            Dim rowVal = ""
            For j = 0 To cellList.Count - 1
                Dim cell As DataGridViewCell = DirectCast(cellList(j), DataGridViewCell)
                rowVal += cell.Value?.ToString()
                If (Not j = cellList.Count - 1) Then
                    rowVal += ","
                End If
            Next

            ' Check all column before write to file : if all is empty skip prevent increment row every save
            If (Not String.IsNullOrEmpty(Replace(rowVal, ",", ""))) Then

                writer.Write(rowVal)

                If (Not i = rowList.Count - 1) Then
                    writer.WriteLine()
                End If
            End If

        Next

        ' Close the StreamWriter
        writer.Close()

        Return True
    End Function
End Class
