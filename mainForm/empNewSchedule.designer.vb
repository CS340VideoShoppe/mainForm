<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class empNewSchedule
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.starttxt = New System.Windows.Forms.TextBox()
        Me.endtxt = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.workDaytxt = New System.Windows.Forms.TextBox()
        Me.daysAvl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(253, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enter Start Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(193, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Enter End Time"
        '
        'starttxt
        '
        Me.starttxt.Location = New System.Drawing.Point(309, 183)
        Me.starttxt.Name = "starttxt"
        Me.starttxt.Size = New System.Drawing.Size(154, 20)
        Me.starttxt.TabIndex = 4
        '
        'endtxt
        '
        Me.endtxt.Location = New System.Drawing.Point(309, 222)
        Me.endtxt.Name = "endtxt"
        Me.endtxt.Size = New System.Drawing.Size(153, 20)
        Me.endtxt.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(621, 243)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 46)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(21, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 46)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'workDaytxt
        '
        Me.workDaytxt.Location = New System.Drawing.Point(308, 35)
        Me.workDaytxt.Name = "workDaytxt"
        Me.workDaytxt.Size = New System.Drawing.Size(154, 20)
        Me.workDaytxt.TabIndex = 8
        '
        'daysAvl
        '
        Me.daysAvl.Location = New System.Drawing.Point(308, 116)
        Me.daysAvl.Name = "daysAvl"
        Me.daysAvl.Size = New System.Drawing.Size(155, 20)
        Me.daysAvl.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(144, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 18)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Days/Hours Available"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.workDaytxt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.endtxt)
        Me.GroupBox1.Controls.Add(Me.daysAvl)
        Me.GroupBox1.Controls.Add(Me.starttxt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(97, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(754, 295)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Schedule"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(222, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(322, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Enter Start and End Times as ##:##, Ex: 11:30 or 04:00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(305, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Enter Available Timeframe "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(305, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Enter Date as YYYY/MM/DD"
        '
        'empNewSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InfoText
        Me.ClientSize = New System.Drawing.Size(924, 363)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "empNewSchedule"
        Me.Text = "Employee Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents starttxt As System.Windows.Forms.TextBox
    Friend WithEvents endtxt As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents workDaytxt As System.Windows.Forms.TextBox
    Friend WithEvents daysAvl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
