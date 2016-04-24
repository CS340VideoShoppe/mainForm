<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newCard
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.creditNum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.expDate = New System.Windows.Forms.MaskedTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(117, 96)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 18)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Experiration Date"
        '
        'creditNum
        '
        Me.creditNum.BackColor = System.Drawing.SystemColors.MenuBar
        Me.creditNum.Location = New System.Drawing.Point(246, 55)
        Me.creditNum.Margin = New System.Windows.Forms.Padding(4)
        Me.creditNum.Name = "creditNum"
        Me.creditNum.Size = New System.Drawing.Size(200, 20)
        Me.creditNum.TabIndex = 86
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(98, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 18)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Credit Card Number"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(234, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 38)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "Go"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'expDate
        '
        Me.expDate.Location = New System.Drawing.Point(245, 96)
        Me.expDate.Mask = "00/00/0000"
        Me.expDate.Name = "expDate"
        Me.expDate.Size = New System.Drawing.Size(201, 20)
        Me.expDate.TabIndex = 90
        Me.expDate.ValidatingType = GetType(Date)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(60, 179)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 40)
        Me.Button2.TabIndex = 91
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'newCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(557, 231)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.expDate)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.creditNum)
        Me.Controls.Add(Me.Label5)
        Me.Name = "newCard"
        Me.Text = "newCard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents creditNum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents expDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
