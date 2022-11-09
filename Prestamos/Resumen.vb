Imports System.Data.SqlClient

Public Class FrmCuadro
    Dim Sentencia, variable, variable2, variable3 As String
    Private Sub Resumen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Posicion(Me)
        cboTipo.Items.Add("Por Persona")
        cboTipo.Items.Add("Por Banco")
        cboTipo.Items.Add("Ninguno")
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Call CancelaCuenta(DataGridView1, Form2)
    End Sub
    Public Sub TituloGridRes()
        Me.DataGridView1.Columns.Item(1).HeaderText = "Titular"
        Me.DataGridView1.Columns.Item(2).HeaderText = "Banco"
        Me.DataGridView1.Columns.Item(3).HeaderText = "Cuota #"
        Me.DataGridView1.Columns.Item(4).HeaderText = "Fecha"
        Me.DataGridView1.Columns.Item(5).HeaderText = "Boucher"
        Me.DataGridView1.Columns.Item(6).HeaderText = "Estado"
        Me.DataGridView1.Columns.Item(0).Visible = False
        Me.DataGridView1.Columns.Item(1).Width = 250
        Me.DataGridView1.Columns.Item(2).Width = 150
        Me.DataGridView1.Columns.Item(3).Width = 40
        Me.DataGridView1.Columns.Item(4).Width = 80
        Me.DataGridView1.Columns.Item(5).Width = 150
        Me.DataGridView1.Columns.Item(6).Width = 40
    End Sub

    Private Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'DataGridView1.DataSource = Nothing
        'DataGridView1.Refresh()
        If rbPagado.Checked = True Then
            Sentencia = "Select BDP.id_detprestamo, BPE.apynom, BB.banco, BDP.cuota, BDP.fecha_pago, BDP.boucher, BDP.pagado from db_detprestamo BDP " & _
                   "inner join db_prestamo BP on BDP.id_prestamo = BP.id_prestamo " & _
                   "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                   "inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                   "Where BDP.pagado = '1' " & variable2 & " " & cboCondicion.SelectedValue & " " & _
                   "order by apynom, banco, cuota, fecha_pago"

        ElseIf rbPorPagar.Checked = True Then
            Sentencia = "Select BDP.id_detprestamo, BPE.apynom, BB.banco, BDP.cuota, BDP.fecha_pago, BDP.boucher, BDP.pagado from db_detprestamo BDP " & _
                    "inner join db_prestamo BP on BDP.id_prestamo = BP.id_prestamo " & _
                    "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                    "inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                    "Where BDP.pagado = '" & DBNull.Value & "' " & variable2 & " " & cboCondicion.SelectedValue & " " & _
                    "order by apynom, banco, cuota, fecha_pago"

        ElseIf rbTotal.Checked = True Then
            Sentencia = "Select BDP.id_detprestamo, BPE.apynom, BB.banco, BDP.cuota, BDP.fecha_pago, BDP.boucher, BDP.pagado from db_detprestamo BDP " & _
                    "inner join db_prestamo BP on BDP.id_prestamo = BP.id_prestamo " & _
                    "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                    "inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                    "where BDP.cuota >=0 " & variable2 & " " & cboCondicion.SelectedValue & " " & _
                    "order by apynom, banco, cuota, fecha_pago"
        End If
        Call Cargar_Grid(Sentencia, Me.DataGridView1)
        Call TituloGridRes()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(DataGridView1, "DATOS CUENTAS BANCARIAS")
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        'cboTipo.SelectedIndex.ToString
        Select Case cboTipo.SelectedIndex
            Case 0
                variable = "Select id_personal, apynom from db_personal order by apynom"
                variable2 = " and BPE.id_personal = "
                cboCondicion.Enabled = True
            Case 1
                variable = "Select id_banco, banco from db_banco order by banco"
                variable2 = " and BB.id_banco = "
                cboCondicion.Enabled = True

            Case 2
                'variable = Nothing
                cboCondicion.Enabled = False
        End Select
        Call CargaDatos(cboCondicion, variable, 0, 1)
    End Sub
    Public Sub CargaDatos(ByVal Combo As ComboBox, ByVal Ssql As String, ByVal Columna1 As Integer, ByVal Columna2 As Integer)
        On Error Resume Next
        con.Open()
        Dim sql As String = Ssql
        Dim Sda As New SqlDataAdapter(sql, con)
        Dim Dtt As New DataTable
        Sda.Fill(Dtt)
        With (Combo)
            .DataSource = Dtt
            .ValueMember = Dtt.Columns(Columna1).ToString
            .DisplayMember = Dtt.Columns(Columna2).ToString
        End With
        con.Close()
        Exit Sub


    End Sub


End Class