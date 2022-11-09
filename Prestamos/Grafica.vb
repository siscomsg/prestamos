Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.SqlClient
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Grafica

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        If Chart1.Titles.Count <= 0 Then
            ' add and format the title
            Chart1.Titles.Add("Prestamos Bancarios")
            Chart1.Titles(0).Font = New Font("Utopia", 16)
            'Chart1.BackColor = Color.Gray
            Chart1.BackSecondaryColor = Color.WhiteSmoke
            Chart1.BackGradientStyle = GradientStyle.DiagonalRight
            Chart1.BorderlineDashStyle = ChartDashStyle.Solid
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Sunken
            Chart1.BorderlineColor = Color.Gray
            ' format the chart area
            Chart1.ChartAreas(0).BackColor = Color.Wheat
            'insert label to bar
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart1.Series(1).IsValueShownAsLabel = True

        End If
        ' create the connection to the database
        Call chart("Select BP.id_prestamo, BP.monto_pagar , sum(BDP.total_pago) as Cancelado, BPE.apynom, BB.banco from db_prestamo BP " & _
                   "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                   "inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                   "inner join db_detprestamo BDP on BP.id_prestamo = BDP.id_prestamo " & _
                   "where BDP.pagado = '1' " & _
                   "Group by  BP.id_prestamo,BB.banco,BPE.apynom, BP.monto_pagar")


    End Sub
    Public Sub chart(ByVal Sentencia As String)

        Dim sql As String = Sentencia
        Dim Sda As New SqlDataAdapter(sql, con)
        Dim Dtt As New DataTable
        con.Open()
        Sda.Fill(Dtt)
        Chart1.DataSource = Dtt
        'MsgBox(Dtt.Rows.Count)
        'Exit Sub
        For x = 1 To Dtt.Rows.Count
            Chart1.Series(0).Points.AddY(Dtt.Rows(x - 1)("Cancelado"))
            Chart1.Series(1).Points.AddY(Dtt.Rows(x - 1)("monto_pagar") - Dtt.Rows(x - 1)("Cancelado"))
            Chart1.Series(0).Points(x - 1).AxisLabel = Dtt.Rows(x - 1)("monto_pagar") & vbCrLf & Dtt.Rows(x - 1)("apynom") & vbCrLf & Dtt.Rows(x - 1)("Banco")

        Next (x)

        con.Close()
        'insert name to series one o two
        Chart1.Series(0).Name = "Monto Pagado"
        Chart1.Series(1).Name = "Monto por Pagar"
        'lineas para formatear chart
        
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Else
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Grafica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Posicion(Me)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Chart1.Series(0).ChartType = SeriesChartType.StackedColumn100
            Chart1.Series(1).ChartType = SeriesChartType.StackedColumn100
        Else
            Chart1.Series(0).ChartType = SeriesChartType.StackedColumn
            Chart1.Series(1).ChartType = SeriesChartType.StackedColumn
        End If

    End Sub

    
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim sql As String = "Select BP.id_prestamo,  sum(BDP.total_pago) as Cancelado,BP.monto_pagar , BB.banco, BPE.apynom from db_prestamo BP " & _
                            "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                            "inner join db_banco BB on BP.id_banco = BB.id_banco " & _
                            "inner join db_detprestamo BDP on BP.id_prestamo = BDP.id_prestamo " & _
                            "where BDP.pagado = '1' " & _
                            "Group by  BP.id_prestamo,BB.banco,BPE.apynom, BP.monto_pagar"
        Dim Sda As New SqlDataAdapter(sql, con)
        Dim Dtt As New DataTable
        con.Open()
        Sda.Fill(Dtt)
        DataGridView1.DataSource = Dtt
        con.Close()


        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim rango As String
        'bar.Maximum = DataGridView1.Rows.Count
        With (objHojaExcel)
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "Exportación - ARGUS SAC"
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = "Datos Grafico"
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hoja de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        'aqui lineas para graficar

        rango = ("B3:C" & DataGridView1.Rows.Count + 2)
        m_Excel.Range(rango).Select()
        m_Excel.Charts.Add()
        m_Excel.ActiveChart.ChartType = Excel.XlChartType.xl3DColumnStacked
        m_Excel.ActiveChart.SeriesCollection(2).XValues = "=Hoja1!$D$4:$E$" & DataGridView1.Rows.Count + 2
        m_Excel.ActiveChart.ChartStyle = 34
        ' m_Excel.ActiveChart.ClearToMatchStyle()
        m_Excel.ActiveChart.Location(1, "Prestamos Bancarios")
        m_Excel.ActiveChart.HasLegend = False
        m_Excel.ActiveChart.HasTitle = True
        m_Excel.ActiveChart.ChartTitle.Text = "Estadistica Prestamos Bancarios"
        'elegimos si estara visible las lineas que viene por defecto
        m_Excel.ActiveChart.Axes(2).HasMajorGridlines = True
        'le ponemos el interior de color de area de trazado
        m_Excel.ActiveChart.PlotArea.Interior.Color = RGB(255, 255, 255)
        'aqui colocamos un titulo al grafico

        ' add and format the title



        'lineas para la creacion de la tabla dinamica

        'Seleccionamos la Hoja de datos
        m_Excel.Sheets("HOJA1").Select()
        'Activamos la hoja
        m_Excel.Sheets("HOJA1").Activate()
        'Contamos las hojas que hay en el libro
        Dim contar As Integer = m_Excel.Worksheets.Count - 1
        'Asignamos a una variable el nombre de la hoja activa
        Dim NombreHoja As String = m_Excel.ActiveSheet.Name
        'Asignamos a una variable el nombre de la Tabla Dinamica
        Dim NombreTabla As String = "Tabla dinámica" & contar - 1
        'Indicamos en donde iniciara la seleccion de datos
        m_Excel.Cells.Range("B4").Select()

        m_Excel.ActiveWorkbook.PivotCaches.Add(SourceType:=Excel.XlPivotTableSourceType.xlDatabase, SourceData:= _
        "'HOJA1 '!B3:E" & DataGridView1.Rows.Count + 2).CreatePivotTable(TableDestination:="", _
        TableName:="Tabla dinámica" & contar - 1, DefaultVersion:=Excel.XlPivotTableVersionList.xlPivotTableVersion2000)
        m_Excel.Sheets("Hoja4").Select()
        m_Excel.Cells(3, 1).Select()
        With m_Excel.ActiveSheet.PivotTables(NombreTabla).PivotFields("banco")
            .Orientation = Excel.XlPivotFieldOrientation.xlRowField
            .Position = 1
        End With
        With m_Excel.ActiveSheet.PivotTables(NombreTabla).PivotFields("apynom")
            .Orientation = Excel.XlPivotFieldOrientation.xlRowField
            .Position = 1
        End With
        m_Excel.ActiveSheet.PivotTables(NombreTabla).AddDataField(m_Excel.ActiveSheet.PivotTables _
        (NombreTabla).PivotFields("monto_pagar"), "Suma de monto_pagar", _
        Excel.XlConsolidationFunction.xlSum)
        m_Excel.ActiveSheet.PivotTables(NombreTabla).AddDataField(m_Excel.ActiveSheet.PivotTables _
        (NombreTabla).PivotFields("Cancelado"), "Suma de Cancelado", _
        Excel.XlConsolidationFunction.xlSum)
        'm_Excel.ActiveSheet.PivotTables(NombreTabla).TableStyle2 = "PivotStyleMedium11"
        'm_Excel.ActiveSheet.PivotTables(NombreTabla).TableStyle2 = "PivotStyleMedium16"
        m_Excel.ActiveSheet.PivotTables(NombreTabla).RowAxisLayout(Excel.XlLayoutFormType.xlOutline)
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        m_Excel = Nothing
        'Close()
    End Sub
    

End Class

