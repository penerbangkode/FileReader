<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.title = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.filepath = New System.Windows.Forms.TextBox()
        Me.browse = New System.Windows.Forms.Button()
        Me.content = New System.Windows.Forms.RichTextBox()
        Me.save = New System.Windows.Forms.Button()
        Me.save_as = New System.Windows.Forms.Button()
        Me.content_csv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.content_csv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Segoe UI", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.title.Location = New System.Drawing.Point(12, 9)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(300, 36)
        Me.title.TabIndex = 0
        Me.title.Text = "File Reader: TXT and CSV"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "File :"
        '
        'filepath
        '
        Me.filepath.Location = New System.Drawing.Point(49, 84)
        Me.filepath.Name = "filepath"
        Me.filepath.ReadOnly = True
        Me.filepath.Size = New System.Drawing.Size(495, 23)
        Me.filepath.TabIndex = 2
        '
        'browse
        '
        Me.browse.Location = New System.Drawing.Point(550, 87)
        Me.browse.Name = "browse"
        Me.browse.Size = New System.Drawing.Size(75, 23)
        Me.browse.TabIndex = 3
        Me.browse.Text = "Browse"
        Me.browse.UseVisualStyleBackColor = True
        '
        'content
        '
        Me.content.Location = New System.Drawing.Point(12, 172)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(776, 290)
        Me.content.TabIndex = 4
        Me.content.Text = ""
        Me.content.Visible = False
        '
        'save
        '
        Me.save.Location = New System.Drawing.Point(12, 129)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(134, 23)
        Me.save.TabIndex = 5
        Me.save.Text = "Save"
        Me.save.UseVisualStyleBackColor = True
        Me.save.Visible = False
        '
        'save_as
        '
        Me.save_as.Location = New System.Drawing.Point(171, 129)
        Me.save_as.Name = "save_as"
        Me.save_as.Size = New System.Drawing.Size(134, 23)
        Me.save_as.TabIndex = 6
        Me.save_as.Text = "Save As"
        Me.save_as.UseVisualStyleBackColor = True
        Me.save_as.Visible = False
        '
        'content_csv
        '
        Me.content_csv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.content_csv.Location = New System.Drawing.Point(12, 172)
        Me.content_csv.Name = "content_csv"
        Me.content_csv.RowTemplate.Height = 25
        Me.content_csv.Size = New System.Drawing.Size(776, 290)
        Me.content_csv.TabIndex = 7
        Me.content_csv.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(342, 327)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 543)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.content_csv)
        Me.Controls.Add(Me.save_as)
        Me.Controls.Add(Me.save)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.browse)
        Me.Controls.Add(Me.filepath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.title)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.content_csv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents title As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents filepath As TextBox
    Friend WithEvents browse As Button
    Friend WithEvents content As RichTextBox
    Friend WithEvents save As Button
    Friend WithEvents save_as As Button
    Friend WithEvents content_csv As DataGridView
    Friend WithEvents Label1 As Label
End Class
