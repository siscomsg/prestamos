Imports System.Data.SqlClient
Public Class det_prestamo
    Public indice As Integer

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
    Public Sub NumCuota(ByVal Ssql As String, ByVal Txt As TextBox)
        con.Open()
        Dim sql As String = Ssql
        Dim Sda As New SqlDataAdapter(sql, con)
        Dim Dtt As New DataTable
        Sda.Fill(Dtt)

        If Not IsDBNull(Dtt.Rows(0)("TOTAL")) Then
            Txt.Text = Val(Dtt.Rows(0)("TOTAL") + 1)
        Else
            Txt.Text = 1
        End If

        con.Close()

    End Sub

    Public Sub Grabar(ByVal sql As String)
        Dim cmdgrabar As SqlCommand
        Try
            con.Open()
            cmdgrabar = New SqlCommand(sql, con)
            cmdgrabar.ExecuteNonQuery()
            cmdgrabar.Dispose()
            con.Close()
            MsgBox("Ingreso Correcto")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub det_prestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargaDatos(Me.cboPersonal, "Select * from db_Personal Order by Apynom", 0, 2)
        Call CargaDatos(Me.cboBanco, "Select * from db_Banco Order By Banco", 0, 1)
        Call Posicion(Me)
    End Sub

    Private Sub txtPrestamo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrestamo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtMonto.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.DateTimePicker1.Focus()
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtTazaInt.Focus()
        End If
    End Sub

    Private Sub txtTazaInt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTazaInt.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtTazaAnual.Focus()
        End If
    End Sub

    Private Sub txtTazaAnual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTazaAnual.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtCuotas.Focus()
        End If
    End Sub

    Private Sub txtCuotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuotas.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btnGrabar.Focus()
        End If
    End Sub
    Public Sub limpiargral()
        Me.cboPersonal.Text = Nothing
        Me.cboBanco.Text = Nothing
        Me.txtPrestamo.Text = Nothing
        Me.txtMonto.Text = Nothing
        Me.txtTazaInt.Text = Nothing
        Me.txtTazaAnual.Text = Nothing
        Me.txtCuotas.Text = Nothing
        Me.cboPersonal.Focus()

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim sql As String = "insert into db_prestamo Values ('" & Me.cboPersonal.SelectedValue & "', '" & Me.cboBanco.SelectedValue & " ', " & _
            "'" & Me.txtPrestamo.Text & "', '" & Me.txtMonto.Text & "','" & DateTimePicker1.Value.Date & "','" & Me.txtTazaInt.Text & "', '" & Me.txtTazaAnual.Text & "', " & _
            "'" & Me.txtCuotas.Text & " ', 0)"
        Call Grabar(sql)
        Call limpiargral()
    End Sub


    Private Sub cboPersonal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPersonal.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.cboBanco.Focus()
        End If
    End Sub


    Private Sub cboBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBanco.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPrestamo.Focus()
        End If
    End Sub


    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
        Cargar_Grid("Select BP.id_prestamo, BPE.apynom, BB.banco, BP.monto_prest, BP.fecha, BP.num_cuotas From db_prestamo BP " & _
                    "Inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                    "Inner join db_banco BB on BP.id_banco = BB.id_banco Where BP.estado = 0 Order By fecha", gridPrestamo)
        Me.gridPrestamo.Columns.Item(1).HeaderText = "Titular"
        Me.gridPrestamo.Columns.Item(2).HeaderText = "Banco"
        Me.gridPrestamo.Columns.Item(3).HeaderText = "Prestamo"
        Me.gridPrestamo.Columns.Item(4).HeaderText = "Fecha"
        Me.gridPrestamo.Columns.Item(5).HeaderText = "# Cuotas"
        Me.gridPrestamo.Columns.Item(0).Visible = False
        If Me.gridPrestamo.Enabled = False Then Me.gridPrestamo.Enabled = True
        Call DesactivarControles()
    End Sub

    Public Sub ActivarControles()
        Me.txtDetCuota.Enabled = True
        Me.DateDetFecha.Enabled = True
        Me.txtDetCapital.Enabled = True
        Me.txtDetDesgra.Enabled = True
        Me.txtDetInteres.Enabled = True
        Me.txtDetMonto.Enabled = True
        Me.txtDetTotal.Enabled = True
        Me.btnDetGrabar.Enabled = True
        Me.txtDetCuota.Focus()
    End Sub

    Public Sub DesactivarControles()
        Me.txtDetCuota.Enabled = False
        Me.DateDetFecha.Enabled = False
        Me.txtDetCapital.Enabled = False
        Me.txtDetDesgra.Enabled = False
        Me.txtDetInteres.Enabled = False
        Me.txtDetMonto.Enabled = False
        Me.txtDetTotal.Enabled = False
        Me.btnDetGrabar.Enabled = False
    End Sub
    Public Sub LimpiarControles()
        Me.txtDetCuota.Text = txtDetCuota.Text + 1
        Me.txtDetCapital.Text = Nothing
        Me.txtDetDesgra.Text = Nothing
        Me.txtDetInteres.Text = Nothing
        Me.txtDetMonto.Text = Nothing
        Me.txtDetTotal.Text = Nothing
        Me.btnDetGrabar.Enabled = False
        Me.txtDetCuota.Focus()
    End Sub

    

    Private Sub txtDetCuota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetCuota.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.DateDetFecha.Focus()
        End If
    End Sub

    Private Sub DateDetFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateDetFecha.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDetCapital.Focus()
        End If
    End Sub

    Private Sub txtDetCapital_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetCapital.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDetDesgra.Focus()
        End If
    End Sub

    Private Sub txtDetDesgra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetDesgra.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDetInteres.Focus()
        End If
    End Sub

    Private Sub txtDetInteres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetInteres.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDetMonto.Focus()
        End If
    End Sub

    Private Sub txtDetMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetMonto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtDetTotal.Focus()
        End If
    End Sub

    Private Sub txtDetTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetTotal.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btnDetGrabar.Enabled = True
            Me.btnDetGrabar.Focus()
        End If
    End Sub

    Private Sub btnDetGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetGrabar.Click
        Call Grabar("Insert Into db_detprestamo(id_prestamo,cuota, fecha_pago, capital, desgrav, interes, monto_cuota, total_pago, pagado) " & _
                    "Values ('" & indice & "', '" & Me.txtDetCuota.Text & "', '" & Me.DateDetFecha.Value.Date & "', '" & Me.txtDetCapital.Text & "', " & _
                    "'" & Me.txtDetDesgra.Text & "', '" & Me.txtDetInteres.Text & "', '" & Me.txtDetMonto.Text & "', " & _
                    "'" & Me.txtDetTotal.Text & "', '" & 0 & "')")

        Call LimpiarControles()

    End Sub

    
    Private Sub btnDetActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetActivar.Click
        Me.gridPrestamo.Enabled = True
        Me.gridPrestamo.Focus()
    End Sub


    Private Sub gridPrestamo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPrestamo.DoubleClick
        On Error Resume Next
        indice = Me.gridPrestamo.Item(0, Me.gridPrestamo.CurrentCell.RowIndex).Value.ToString()
        lblPrestamo.Text = Me.gridPrestamo.Item(1, Me.gridPrestamo.CurrentCell.RowIndex).Value.ToString() & " " & Me.gridPrestamo.Item(2, Me.gridPrestamo.CurrentCell.RowIndex).Value.ToString() & " " & Me.gridPrestamo.Item(3, Me.gridPrestamo.CurrentCell.RowIndex).Value.ToString() & " " & Me.gridPrestamo.Item(4, Me.gridPrestamo.CurrentCell.RowIndex).Value.ToString()
        Dim respuesta As String = MsgBox("Desea cargar detalles a este registro??", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cargar??")
        If respuesta = vbYes Then
            Me.gridPrestamo.Enabled = False
            Me.txtDetCuota.Text = Nothing
            Call NumCuota("Select max(cuota) as Total from db_detprestamo where id_prestamo = " & indice, txtDetCuota)
            Call ActivarControles()
        End If
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged

    End Sub
End Class