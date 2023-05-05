<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Btn_Convert = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.TextBox1.Location = New System.Drawing.Point(32, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(371, 29)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "NAME YOUR FILE"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Convert
        '
        Me.Btn_Convert.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.Btn_Convert.Location = New System.Drawing.Point(32, 60)
        Me.Btn_Convert.Name = "Btn_Convert"
        Me.Btn_Convert.Size = New System.Drawing.Size(371, 35)
        Me.Btn_Convert.TabIndex = 9
        Me.Btn_Convert.Text = "Open ""M3U"" list and convert to HTML:"
        Me.Btn_Convert.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 140)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Btn_Convert)
        Me.Name = "Form1"
        Me.Text = "M3U Converter 1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Convert As System.Windows.Forms.Button

End Class
