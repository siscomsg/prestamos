﻿Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FrmDatos
    
    Dim senten As String
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        senten = "SELECT " & _
                 "BPE.apynom, BP.fecha, BB.banco, BP.monto_pagar, BP.num_cuotas, " & _
                 "SUM(CASE BDP.pagado WHEN '1' THEN BDP.total_pago ELSE 0 END) AS Pagado, " & _
                 "SUM(CASE BDP.pagado WHEN '0' THEN BDP.total_pago ELSE 0 END) AS Falta, " & _
                 "SUM(CASE BDP.pagado WHEN '1' THEN 1 ELSE 0 END) AS Cuotas_pagadas, " & _
                 "SUM(CASE BDP.pagado WHEN '0' THEN 1 ELSE 0 END) AS Cuotas_por_Pagar " & _
                 "FROM db_prestamo AS BP INNER JOIN " & _
                 "db_personal AS BPE ON BP.id_personal = BPE.id_personal INNER JOIN " & _
                 "db_banco AS BB ON BP.id_banco = BB.id_banco INNER JOIN " & _
                 "db_detprestamo AS BDP ON BP.id_prestamo = BDP.id_prestamo " & _
                 "GROUP BY BDP.id_prestamo, BP.fecha, BB.banco, BPE.apynom, BP.monto_pagar, BP.num_cuotas "

        Cargar_Grid(senten, Me.DataGridView1)
        Call TituloGridResumen()
    End Sub


    Public Sub TituloGridResumen()
        Me.DataGridView1.Columns.Item(0).HeaderText = "Titular"
        Me.DataGridView1.Columns.Item(1).HeaderText = "Fecha"
        Me.DataGridView1.Columns.Item(2).HeaderText = "Banco"
        Me.DataGridView1.Columns.Item(3).HeaderText = "Deuda Total"
        Me.DataGridView1.Columns.Item(4).HeaderText = "Cuotas #"
        Me.DataGridView1.Columns.Item(5).HeaderText = "Monto Pagado"
        Me.DataGridView1.Columns.Item(6).HeaderText = "Monto Pend."
        Me.DataGridView1.Columns.Item(7).HeaderText = "Cuotas Pagadas"
        Me.DataGridView1.Columns.Item(8).HeaderText = "Cuotas Pend."

    End Sub

    Private Sub btnHistorial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHistorial.Click
        senten = "Select BPE.apynom, sum( BP.monto_pagar) as Total,  " & _
                 "count (BP.monto_pagar) as prestamos " & _
                 "from db_prestamo BP " & _
                 "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                 "Group by BPE.apynom " & _
                 "order by total DESC"
        Cargar_Grid(senten, Me.DataGridView1)
        Call TituloGridHistorial()
    End Sub
    Public Sub TituloGridHistorial()
        Me.DataGridView1.Columns.Item(0).HeaderText = "Titular"
        Me.DataGridView1.Columns.Item(1).HeaderText = "Monto General"
        Me.DataGridView1.Columns.Item(2).HeaderText = "Prestamos Realizados"

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call ExportarDatosExcel(Me.DataGridView1, "Datos Generales de Prestamos")
    End Sub

    Private Sub FrmDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Posicion(Me)
    End Sub

    Public Sub PasarExcel()
        Dim ds As New DataSet

        Dim da As New SqlDataAdapter("Select BPE.apynom, sum( BP.monto_pagar) as Total,  " & _
                 "count (BP.monto_pagar) as prestamos " & _
                 "from db_prestamo BP " & _
                 "inner join db_personal BPE on BP.id_personal = BPE.id_personal " & _
                 "Group by BPE.apynom ", con)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

        '/////////////////////////////
        '// Creamos el Objeto Excel
        '/////////////////////////////
        Dim m_Excel
        Dim objLibroExcel
        Dim objHojaExcel
        m_Excel = CreateObject("Excel.Application")
        objLibroExcel = m_Excel.Workbooks.Add()
        objHojaExcel = objLibroExcel.Worksheets(1)
        objHojaExcel.Name = "Customers"
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        '/////////////////////////////////////////////////////////
        '// Definimos dos variables para controlar fila y columna
        '/////////////////////////////////////////////////////////
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////
        objHojaExcel.Range("A1").Select()
        For Each dc In ds.Tables(0).Columns
            objHojaExcel.Range(nombreColumna(columna) & 1).Value = dc.ColumnName
            columna += 1
        Next
        fila += 1

        '/////////////////////////////////////////////
        '// Le damos formato a la fila de los títulos
        '/////////////////////////////////////////////
        Dim objRango As Excel.Range = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & "1")
        objRango.Font.Bold = True
        objRango.Cells.Interior.ColorIndex = 35

        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        '//////////////////////////////////////////
        '// Cargamos todas las filas del datatable
        '//////////////////////////////////////////
        ProgressBar1.Maximum = ds.Tables(0).Rows.Count
        columna = 1
        ProgressBar1.Value = 0
        For Each dr In ds.Tables(0).Rows
            columna = 1
            For Each dc In ds.Tables(0).Columns
                objHojaExcel.Range(nombreColumna(columna) & fila).Value = dr(dc.ColumnName)
                columna += 1
            Next
            fila += 1
            ProgressBar1.Value += 1
        Next

        '//////////////////////////////////////
        '// Ajustamos automaticamente el ancho
        '// de todas las columnas utilizada
        '//////////////////////////////////////
        objRango = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & ds.Tables(0).Rows.Count.ToString)
        objRango.Select()
        objRango.Columns.AutoFit()

        '/////////////////////////////////////
        '// Le decimos a Excel que se muestre
        '/////////////////////////////////////
        MsgBox("Exportación a Excel completa", MsgBoxStyle.Information, ".:: solovb.net ::.")
        m_Excel.Visible = True

    End Sub

    Public Function nombreColumna(ByVal numero As Integer) As String
        Dim columna(256) As String

        columna(1) = "A"
        columna(2) = "B"
        columna(3) = "C"
        columna(4) = "D"
        columna(5) = "E"
        columna(6) = "F"
        columna(7) = "G"
        columna(8) = "H"
        columna(9) = "I"
        columna(10) = "J"
        columna(11) = "K"
        columna(12) = "L"
        columna(13) = "M"
        columna(14) = "N"
        columna(15) = "O"
        columna(16) = "P"
        columna(17) = "Q"
        columna(18) = "R"
        columna(19) = "S"
        columna(20) = "T"
        columna(21) = "U"
        columna(22) = "V"
        columna(23) = "W"
        columna(24) = "X"
        columna(25) = "Y"
        columna(26) = "Z"
        columna(27) = "AA"
        columna(28) = "AB"
        columna(29) = "AC"
        columna(30) = "AD"
        columna(31) = "AE"
        columna(32) = "AF"
        columna(33) = "AG"
        columna(34) = "AH"
        columna(35) = "AI"
        columna(36) = "AJ"
        columna(37) = "AK"
        columna(38) = "AL"
        columna(39) = "AM"
        columna(40) = "AN"
        columna(41) = "AO"
        columna(42) = "AP"
        columna(43) = "AQ"
        columna(44) = "AR"
        columna(45) = "AS"
        columna(46) = "AT"
        columna(47) = "AU"
        columna(48) = "AV"
        columna(49) = "AW"
        columna(50) = "AX"
        columna(51) = "AY"
        columna(52) = "AZ"
        columna(53) = "BA"
        columna(54) = "BB"
        columna(55) = "BC"
        columna(56) = "BD"
        columna(57) = "BE"
        columna(58) = "BF"
        columna(59) = "BG"
        columna(60) = "BH"
        columna(61) = "BI"
        columna(62) = "BJ"
        columna(63) = "BK"
        columna(64) = "BL"
        columna(65) = "BM"
        columna(66) = "BN"
        columna(67) = "BO"
        columna(68) = "BP"
        columna(69) = "BQ"
        columna(70) = "BR"
        columna(71) = "BS"
        columna(72) = "BT"
        columna(73) = "BU"
        columna(74) = "BV"
        columna(75) = "BW"
        columna(76) = "BX"
        columna(77) = "BY"
        columna(78) = "BZ"
        columna(79) = "CA"
        columna(80) = "CB"
        columna(81) = "CC"
        columna(82) = "CD"
        columna(83) = "CE"
        columna(84) = "CF"
        columna(85) = "CG"
        columna(86) = "CH"
        columna(87) = "CI"
        columna(88) = "CJ"
        columna(89) = "CK"
        columna(90) = "CL"
        columna(91) = "CM"
        columna(92) = "CN"
        columna(93) = "CO"
        columna(94) = "CP"
        columna(95) = "CQ"
        columna(96) = "CR"
        columna(97) = "CS"
        columna(98) = "CT"
        columna(99) = "CU"
        columna(100) = "CV"
        columna(101) = "CW"
        columna(102) = "CX"
        columna(103) = "CY"
        columna(104) = "CZ"
        columna(105) = "DA"
        columna(106) = "DB"
        columna(107) = "DC"
        columna(108) = "DD"
        columna(109) = "DE"
        columna(110) = "DF"
        columna(111) = "DG"
        columna(112) = "DH"
        columna(113) = "DI"
        columna(114) = "DJ"
        columna(115) = "DK"
        columna(116) = "DL"
        columna(117) = "DM"
        columna(118) = "DN"
        columna(119) = "DO"
        columna(120) = "DP"
        columna(121) = "DQ"
        columna(122) = "DR"
        columna(123) = "DS"
        columna(124) = "DT"
        columna(125) = "DU"
        columna(126) = "DV"
        columna(127) = "DW"
        columna(128) = "DX"
        columna(129) = "DY"
        columna(130) = "DZ"
        columna(131) = "EA"
        columna(132) = "EB"
        columna(133) = "EC"
        columna(134) = "ED"
        columna(135) = "EE"
        columna(136) = "EF"
        columna(137) = "EG"
        columna(138) = "EH"
        columna(139) = "EI"
        columna(140) = "EJ"
        columna(141) = "EK"
        columna(142) = "EL"
        columna(143) = "EM"
        columna(144) = "EN"
        columna(145) = "EO"
        columna(146) = "EP"
        columna(147) = "EQ"
        columna(148) = "ER"
        columna(149) = "ES"
        columna(150) = "ET"
        columna(151) = "EU"
        columna(152) = "EV"
        columna(153) = "EW"
        columna(154) = "EX"
        columna(155) = "EY"
        columna(156) = "EZ"
        columna(157) = "FA"
        columna(158) = "FB"
        columna(159) = "FC"
        columna(160) = "FD"
        columna(161) = "FE"
        columna(162) = "FF"
        columna(163) = "FG"
        columna(164) = "FH"
        columna(165) = "FI"
        columna(166) = "FJ"
        columna(167) = "FK"
        columna(168) = "FL"
        columna(169) = "FM"
        columna(170) = "FN"
        columna(171) = "FO"
        columna(172) = "FP"
        columna(173) = "FQ"
        columna(174) = "FR"
        columna(175) = "FS"
        columna(176) = "FT"
        columna(177) = "FU"
        columna(178) = "FV"
        columna(179) = "FW"
        columna(180) = "FX"
        columna(181) = "FY"
        columna(182) = "FZ"
        columna(183) = "GA"
        columna(184) = "GB"
        columna(185) = "GC"
        columna(186) = "GD"
        columna(187) = "GE"
        columna(188) = "GF"
        columna(189) = "GG"
        columna(190) = "GH"
        columna(191) = "GI"
        columna(192) = "GJ"
        columna(193) = "GK"
        columna(194) = "GL"
        columna(195) = "GM"
        columna(196) = "GN"
        columna(197) = "GO"
        columna(198) = "GP"
        columna(199) = "GQ"
        columna(200) = "GR"
        columna(201) = "GS"
        columna(202) = "GT"
        columna(203) = "GU"
        columna(204) = "GV"
        columna(205) = "GW"
        columna(206) = "GX"
        columna(207) = "GY"
        columna(208) = "GZ"
        columna(209) = "HA"
        columna(210) = "HB"
        columna(211) = "HC"
        columna(212) = "HD"
        columna(213) = "HE"
        columna(214) = "HF"
        columna(215) = "HG"
        columna(216) = "HH"
        columna(217) = "HI"
        columna(218) = "HJ"
        columna(219) = "HK"
        columna(220) = "HL"
        columna(221) = "HM"
        columna(222) = "HN"
        columna(223) = "HO"
        columna(224) = "HP"
        columna(225) = "HQ"
        columna(226) = "HR"
        columna(227) = "HS"
        columna(228) = "HT"
        columna(229) = "HU"
        columna(230) = "HV"
        columna(231) = "HW"
        columna(232) = "HX"
        columna(233) = "HY"
        columna(234) = "HZ"
        columna(235) = "IA"
        columna(236) = "IB"
        columna(237) = "IC"
        columna(238) = "ID"
        columna(239) = "IE"
        columna(240) = "IF"
        columna(241) = "IG"
        columna(242) = "IH"
        columna(243) = "II"
        columna(244) = "IJ"
        columna(245) = "IK"
        columna(246) = "IL"
        columna(247) = "IM"
        columna(248) = "IN"
        columna(249) = "IO"
        columna(250) = "IP"
        columna(251) = "IQ"
        columna(252) = "IR"
        columna(253) = "IS"
        columna(254) = "IT"
        columna(255) = "IU"
        columna(256) = "IV"

        Return columna(numero)
    End Function

End Class