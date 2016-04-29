<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inventory
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.titlechk = New System.Windows.Forms.CheckBox()
        Me.genreChk = New System.Windows.Forms.CheckBox()
        Me.directorChk = New System.Windows.Forms.CheckBox()
        Me.actorChk = New System.Windows.Forms.CheckBox()
        Me.languagechk = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(70, 91)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(171, 20)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search Inventory"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Add Item to Inventory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(40, 179)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 45)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'titlechk
        '
        Me.titlechk.AutoSize = True
        Me.titlechk.Location = New System.Drawing.Point(22, 129)
        Me.titlechk.Name = "titlechk"
        Me.titlechk.Size = New System.Drawing.Size(46, 17)
        Me.titlechk.TabIndex = 4
        Me.titlechk.Text = "Title"
        Me.titlechk.UseVisualStyleBackColor = True
        '
        'genreChk
        '
        Me.genreChk.AutoSize = True
        Me.genreChk.Location = New System.Drawing.Point(70, 129)
        Me.genreChk.Name = "genreChk"
        Me.genreChk.Size = New System.Drawing.Size(55, 17)
        Me.genreChk.TabIndex = 5
        Me.genreChk.Text = "Genre"
        Me.genreChk.UseVisualStyleBackColor = True
        '
        'directorChk
        '
        Me.directorChk.AutoSize = True
        Me.directorChk.Location = New System.Drawing.Point(131, 152)
        Me.directorChk.Name = "directorChk"
        Me.directorChk.Size = New System.Drawing.Size(63, 17)
        Me.directorChk.TabIndex = 7
        Me.directorChk.Text = "Director"
        Me.directorChk.UseVisualStyleBackColor = True
        '
        'actorChk
        '
        Me.actorChk.AutoSize = True
        Me.actorChk.Location = New System.Drawing.Point(40, 156)
        Me.actorChk.Name = "actorChk"
        Me.actorChk.Size = New System.Drawing.Size(51, 17)
        Me.actorChk.TabIndex = 8
        Me.actorChk.Text = "Actor"
        Me.actorChk.UseVisualStyleBackColor = True
        '
        'languagechk
        '
        Me.languagechk.AutoSize = True
        Me.languagechk.Location = New System.Drawing.Point(131, 129)
        Me.languagechk.Name = "languagechk"
        Me.languagechk.Size = New System.Drawing.Size(74, 17)
        Me.languagechk.TabIndex = 9
        Me.languagechk.Text = "Language"
        Me.languagechk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(200, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(381, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Search For Item or Add New Item To Inventory"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(40, 342)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 45)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Main Menu"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(423, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(369, 282)
        Me.DataGridView1.TabIndex = 12
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(318, 152)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 61)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "View All Inventory"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(568, 342)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(102, 39)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Select Title"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(40, 280)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(173, 56)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "Financial Reports"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(455, 267)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 39)
        Me.Button7.TabIndex = 16
        Me.Button7.Text = "Log Out"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.actorChk)
        Me.GroupBox1.Controls.Add(Me.languagechk)
        Me.GroupBox1.Controls.Add(Me.directorChk)
        Me.GroupBox1.Controls.Add(Me.titlechk)
        Me.GroupBox1.Controls.Add(Me.genreChk)
        Me.GroupBox1.Location = New System.Drawing.Point(142, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 396)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventory"
        '
        'inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InfoText
        Me.ClientSize = New System.Drawing.Size(1099, 508)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button7)
        Me.Name = "inventory"
        Me.Text = "Inventory Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents titlechk As System.Windows.Forms.CheckBox
    Friend WithEvents genreChk As System.Windows.Forms.CheckBox
    Friend WithEvents directorChk As System.Windows.Forms.CheckBox
    Friend WithEvents actorChk As System.Windows.Forms.CheckBox
    Friend WithEvents languagechk As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
