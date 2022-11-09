Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Timer1.Enabled = False
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call coneccion()
        Call Cargar_Grid("Select BDP.id_detprestamo, BPE.apynom, BB.banco, BDP.cuota, BDP.fecha_pago, BDP.total_pago " & _
                         " from db_detprestamo BDP" & _
                         " Inner join db_prestamo BP on BDP.id_prestamo = BP.id_prestamo " & _
                         " Inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                         " Inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                         " where pagado = 0 and (fecha_pago between  '" & DateAdd(DateInterval.Day, -90, Now.Date) & "' and '" & DateAdd(DateInterval.Day, +15, Now.Date) & "') " & _
                         " Order by Fecha_pago", Me.DataGridView1)
        Call TituloGrid()
        Call Posicion(Me)
    End Sub
   
    Public Sub TituloGrid()
        Me.DataGridView1.Columns.Item(1).HeaderText = "Titular"
        Me.DataGridView1.Columns.Item(2).HeaderText = "Banco"
        Me.DataGridView1.Columns.Item(3).HeaderText = "Cuota #"
        Me.DataGridView1.Columns.Item(4).HeaderText = "Fecha"
        Me.DataGridView1.Columns.Item(5).HeaderText = "Monto a Pagar"
        Me.DataGridView1.Columns.Item(0).Visible = False
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call Cargar_Grid("Select BDP.id_detprestamo, BPE.apynom, BB.banco, BDP.cuota, BDP.fecha_pago, BDP.total_pago " & _
                         " from db_detprestamo BDP" & _
                         " Inner join db_prestamo BP on BDP.id_prestamo = BP.id_prestamo " & _
                         " Inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                         " Inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                         " where pagado = 0 and (fecha_pago between  '" & DateAdd(DateInterval.Day, -90, Now.Date) & "' and '" & DateAdd(DateInterval.Day, +15, Now.Date) & "') " & _
                         " Order by Fecha_pago", Me.DataGridView1)
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        'On Error Resume Next
        'DataGridView1.CurrentCell = Nothing
        'Me.DataGridView1.SelectedRows(0).Selected = False
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Call CancelaCuenta(DataGridView1, Form2)
    End Sub

    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        On Error Resume Next
        Dim fecha As Integer
        Me.DataGridView1.Columns("total_pago").DefaultCellStyle.Format = "c"
        'fecha = DateDiff("d", DateInterval.Day, Me.DataGridView1.Rows(e.RowIndex).Cells("fecha_pago").Value.ToString)
        fecha = DateDiff(DateInterval.Day, Now.Date, Me.DataGridView1.Rows(e.RowIndex).Cells("fecha_pago").Value)
        Select Case fecha
            Case Is <= 0
                DataGridView1.Rows(e.RowIndex).Cells("fecha_pago").Style.ForeColor = Color.Red
            Case 1 To 3
                DataGridView1.Rows(e.RowIndex).Cells("fecha_pago").Style.ForeColor = Color.Green
            Case Is >= 4
                DataGridView1.Rows(e.RowIndex).Cells("fecha_pago").Style.ForeColor = Color.Blue
            Case Else
                DataGridView1.Rows(e.RowIndex).Cells("Estado").Style.ForeColor = Color.Black
        End Select

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        det_prestamo.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FrmCuadro.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Grafica.ShowDialog()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(DataGridView1, "RESUMEN DE CUENTAS")
    End Sub

    Private Sub btnResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResumen.Click
        FrmDatos.ShowDialog()
    End Sub
End Class
