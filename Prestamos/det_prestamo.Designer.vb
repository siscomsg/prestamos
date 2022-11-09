<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class det_prestamo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(det_prestamo))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboPersonal = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCuotas = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTazaAnual = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTazaInt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnDetActivar = New System.Windows.Forms.Button()
        Me.btnDetGrabar = New System.Windows.Forms.Button()
        Me.txtDetTotal = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDetMonto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDetInteres = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDetDesgra = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDetCapital = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateDetFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtDetCuota = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPrestamo = New System.Windows.Forms.Label()
        Me.gridPrestamo = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(652, 366)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.cboBanco)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cboPersonal)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.btnExportar)
        Me.TabPage1.Controls.Add(Me.btnGrabar)
        Me.TabPage1.Controls.Add(Me.btnCargar)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtCuotas)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtTazaAnual)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtTazaInt)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtMonto)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtPrestamo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(644, 340)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dato Gral."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cboBanco
        '
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(239, 75)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(190, 21)
        Me.cboBanco.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(129, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Banco::."
        '
        'cboPersonal
        '
        Me.cboPersonal.FormattingEnabled = True
        Me.cboPersonal.Location = New System.Drawing.Point(239, 48)
        Me.cboPersonal.Name = "cboPersonal"
        Me.cboPersonal.Size = New System.Drawing.Size(264, 21)
        Me.cboPersonal.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(129, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Titular::."
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = Global.WindowsApplication1.My.Resources.Resources.busc_clie
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.Location = New System.Drawing.Point(164, 297)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(70, 28)
        Me.btnExportar.TabIndex = 21
        Me.btnExportar.Text = "Excel"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Image = Global.WindowsApplication1.My.Resources.Resources.aceptar
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.Location = New System.Drawing.Point(9, 297)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(73, 28)
        Me.btnGrabar.TabIndex = 20
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Enabled = False
        Me.btnCargar.Image = Global.WindowsApplication1.My.Resources.Resources.cons_vent
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.Location = New System.Drawing.Point(88, 297)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(70, 28)
        Me.btnCargar.TabIndex = 19
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(80, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(478, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = ".:: INGRESE AQUI LOS DATOS GENERALES DEL PRESTAMO REALIZADO ::."
        '
        'txtCuotas
        '
        Me.txtCuotas.Location = New System.Drawing.Point(239, 235)
        Me.txtCuotas.Name = "txtCuotas"
        Me.txtCuotas.Size = New System.Drawing.Size(121, 20)
        Me.txtCuotas.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(129, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Num. Cuotas::."
        '
        'txtTazaAnual
        '
        Me.txtTazaAnual.Location = New System.Drawing.Point(239, 209)
        Me.txtTazaAnual.Name = "txtTazaAnual"
        Me.txtTazaAnual.Size = New System.Drawing.Size(121, 20)
        Me.txtTazaAnual.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(129, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Taza Anual::."
        '
        'txtTazaInt
        '
        Me.txtTazaInt.Location = New System.Drawing.Point(239, 183)
        Me.txtTazaInt.Name = "txtTazaInt"
        Me.txtTazaInt.Size = New System.Drawing.Size(121, 20)
        Me.txtTazaInt.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(129, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Taza Interes:."
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(239, 156)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(129, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Fecha Prestamo::."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(129, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Monto a Pagar::."
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(239, 128)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(121, 20)
        Me.txtMonto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(129, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Prestamo::."
        '
        'txtPrestamo
        '
        Me.txtPrestamo.Location = New System.Drawing.Point(239, 102)
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.Size = New System.Drawing.Size(121, 20)
        Me.txtPrestamo.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.btnDetActivar)
        Me.TabPage2.Controls.Add(Me.btnDetGrabar)
        Me.TabPage2.Controls.Add(Me.txtDetTotal)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtDetMonto)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtDetInteres)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtDetDesgra)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtDetCapital)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.DateDetFecha)
        Me.TabPage2.Controls.Add(Me.txtDetCuota)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.lblPrestamo)
        Me.TabPage2.Controls.Add(Me.gridPrestamo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(644, 340)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalle Cta."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnDetActivar
        '
        Me.btnDetActivar.Image = Global.WindowsApplication1.My.Resources.Resources.ventas
        Me.btnDetActivar.Location = New System.Drawing.Point(612, 79)
        Me.btnDetActivar.Name = "btnDetActivar"
        Me.btnDetActivar.Size = New System.Drawing.Size(27, 28)
        Me.btnDetActivar.TabIndex = 16
        Me.btnDetActivar.UseVisualStyleBackColor = True
        '
        'btnDetGrabar
        '
        Me.btnDetGrabar.Enabled = False
        Me.btnDetGrabar.Image = Global.WindowsApplication1.My.Resources.Resources.aceptar
        Me.btnDetGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetGrabar.Location = New System.Drawing.Point(9, 277)
        Me.btnDetGrabar.Name = "btnDetGrabar"
        Me.btnDetGrabar.Size = New System.Drawing.Size(74, 23)
        Me.btnDetGrabar.TabIndex = 15
        Me.btnDetGrabar.Text = "Grabar"
        Me.btnDetGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetGrabar.UseVisualStyleBackColor = True
        '
        'txtDetTotal
        '
        Me.txtDetTotal.Enabled = False
        Me.txtDetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetTotal.Location = New System.Drawing.Point(320, 230)
        Me.txtDetTotal.Name = "txtDetTotal"
        Me.txtDetTotal.Size = New System.Drawing.Size(86, 21)
        Me.txtDetTotal.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(218, 233)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 15)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Pago Total-->"
        '
        'txtDetMonto
        '
        Me.txtDetMonto.Enabled = False
        Me.txtDetMonto.Location = New System.Drawing.Point(523, 180)
        Me.txtDetMonto.Name = "txtDetMonto"
        Me.txtDetMonto.Size = New System.Drawing.Size(86, 20)
        Me.txtDetMonto.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(421, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Monto Cuota-->"
        '
        'txtDetInteres
        '
        Me.txtDetInteres.Enabled = False
        Me.txtDetInteres.Location = New System.Drawing.Point(523, 154)
        Me.txtDetInteres.Name = "txtDetInteres"
        Me.txtDetInteres.Size = New System.Drawing.Size(86, 20)
        Me.txtDetInteres.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(421, 157)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Interes-->"
        '
        'txtDetDesgra
        '
        Me.txtDetDesgra.Enabled = False
        Me.txtDetDesgra.Location = New System.Drawing.Point(320, 180)
        Me.txtDetDesgra.Name = "txtDetDesgra"
        Me.txtDetDesgra.Size = New System.Drawing.Size(86, 20)
        Me.txtDetDesgra.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(218, 183)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Desgravamen-->"
        '
        'txtDetCapital
        '
        Me.txtDetCapital.Enabled = False
        Me.txtDetCapital.Location = New System.Drawing.Point(320, 154)
        Me.txtDetCapital.Name = "txtDetCapital"
        Me.txtDetCapital.Size = New System.Drawing.Size(86, 20)
        Me.txtDetCapital.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(218, 157)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Capital-->"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Pago-->"
        '
        'DateDetFecha
        '
        Me.DateDetFecha.Enabled = False
        Me.DateDetFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDetFecha.Location = New System.Drawing.Point(107, 177)
        Me.DateDetFecha.Name = "DateDetFecha"
        Me.DateDetFecha.Size = New System.Drawing.Size(87, 20)
        Me.DateDetFecha.TabIndex = 1
        '
        'txtDetCuota
        '
        Me.txtDetCuota.Enabled = False
        Me.txtDetCuota.Location = New System.Drawing.Point(107, 151)
        Me.txtDetCuota.Name = "txtDetCuota"
        Me.txtDetCuota.Size = New System.Drawing.Size(26, 20)
        Me.txtDetCuota.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cuota-->"
        '
        'lblPrestamo
        '
        Me.lblPrestamo.AutoSize = True
        Me.lblPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrestamo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrestamo.Location = New System.Drawing.Point(9, 110)
        Me.lblPrestamo.Name = "lblPrestamo"
        Me.lblPrestamo.Size = New System.Drawing.Size(2, 18)
        Me.lblPrestamo.TabIndex = 1
        '
        'gridPrestamo
        '
        Me.gridPrestamo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gridPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowFrame
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPrestamo.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridPrestamo.Location = New System.Drawing.Point(9, 16)
        Me.gridPrestamo.Name = "gridPrestamo"
        Me.gridPrestamo.Size = New System.Drawing.Size(600, 91)
        Me.gridPrestamo.TabIndex = 0
        '
        'det_prestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 390)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "det_prestamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".::--::. Ingreso de Datos de Prestamo .::--::."
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.gridPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTazaAnual As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTazaInt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPersonal As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gridPrestamo As System.Windows.Forms.DataGridView
    Friend WithEvents lblPrestamo As System.Windows.Forms.Label
    Friend WithEvents txtDetTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDetMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDetInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDetDesgra As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDetCapital As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateDetFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDetCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDetGrabar As System.Windows.Forms.Button
    Friend WithEvents btnDetActivar As System.Windows.Forms.Button
End Class
