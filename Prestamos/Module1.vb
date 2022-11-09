Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.IO


Module Module1
    Public con As New SqlConnection
    Public id As Integer
    Public Sub coneccion()
        Dim host, db, id, pwd, resultado As String
        host = "192.168.1.30\sqlexpress" '192.168.1.48"
        db = "prestamos"
        id = "sa"
        pwd = ""
        con.ConnectionString = ("Data Source=" & host & "; Initial Catalog=" & db & ";Persist Security Info=True;User ID=" & id & ";Pwd=" & pwd & ";")
        Try
            con.Open()
            'MsgBox("Conección Exitosa", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Conexión")
            con.Close()

        Catch ex As Exception
            resultado = MsgBox("Error de conección desea reintentar???", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conección")
            If resultado = vbYes Then
                MsgBox("Error al conectar a db", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Conexión")
            End If
        End Try
    End Sub
    Public Sub Cargar_Grid(ByVal Sentencia As String, ByVal Grid As DataGridView)
        On Error GoTo rafael
        con.Open()
        Dim sql As String = Sentencia
        Dim Sda As New SqlDataAdapter(sql, con)
        Dim Dtt As New DataTable
        Sda.Fill(Dtt)
        Grid.DataSource = Dtt
        con.Close()
        Exit Sub
rafael:
        MsgBox("error de conexión")
        End
    End Sub
    Public Sub abririmagen(ByVal abre As OpenFileDialog, ByVal picture As PictureBox)
        'Si en el diseño no hemos añadido el Openfiledialog pondremos esto sin el apostrofe al principio:
        'Dim abre As OpenFileDialog 
        abre.Title = "Seleccione su Imagen" 'Título de la ventana que se abrirá para seleccionar el archivo.
        abre.Filter = "Jpeg|*.jpeg|Jpg|*.jpg|Png|*.png|Gif|*.gif|Todos los archivos|*.*" 'Tipo de extensiones soportadas, fijaros como en la primera parte se pone el nombre, el que se quiera, después ponemos una barra vertical a modo de separación y ponemos *."extensión", el asterisco significa que nos permitirá cualquier nombre de archivo, la extensión hay que ponerla IGUAL que las que queramos abrir, lo de todos los archivos es opcional..
        abre.FilterIndex = 0 'Elegimos que se quede por defecto la primera extensión a la vista.
        abre.InitialDirectory = "C:\Documents and Settings\" & My.User.Name & "\Escritorio" 'Con esto haremos que el directorio inicial sea nuestro escritorio, podemos modificarlo a nuestro antojo si quisieramos abrirlo en mis documentos o en algún otro lugar lo ponemos y ya está.
        abre.RestoreDirectory = True 'De esta forma, mientras no cerremos la aplicación se "guardará" el último directorio seleccionado para no tener que elegirlo cada vez.
        abre.FileName = "" 'Con esto hacemos que al abrir la ventana no haya un nombre escrito, de la manera contraria en la ventana ya pondria "abre", además que esto nos viene bien para otra cosa que explicaré luego.

        If abre.ShowDialog() = Windows.Forms.DialogResult.OK Then 'Si pulsamos aceptar en la ventanita.
            picture.ImageLocation = abre.FileName 'La ruta de la imagen que contiene el picturebox es el nombre de archivo del OpenFileDialog.
            Form2.Button2.Enabled = True
            Form2.Button3.Enabled = True
            Form2.Button4.Enabled = True
        ElseIf abre.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            MsgBox("No se seleccionó ninguna imagen")
            Form2.Button2.Enabled = False
            Form2.Button3.Enabled = False
            Form2.Button4.Enabled = False
        End If

    End Sub

    Public Sub guardarimagenpc(ByVal guarda As SaveFileDialog, ByVal picture As PictureBox, ByVal abre As OpenFileDialog)
        'Si en el diseño no hemos añadido el SaveFileDialog pondremos esto sin el apostrofe:
        'Dim guarda As SaveFileDialog
        Dim foto As New Bitmap(picture.Image) 'esta linea es para asignar el tamaño del picture a la imagen -->(New Bitmap(picture.Image), picture.Width, picture.Height)
        'Creamos una variable llamada foto que será un Bitmap con la imagen del picturebox, su anchura y su altura.
        guarda.Title = "Seleccione donde quiere guardar su Imagen"
        guarda.Filter = "Jpeg|*.jpeg|Jpg|*.jpg|Png|*.png|Gif|*.gif|Todos los archivos|*.*"
        guarda.FilterIndex = 0
        guarda.InitialDirectory = "C:\Documents and Settings\" & My.User.Name & "\Escritorio"
        guarda.RestoreDirectory = True
        guarda.FileName = ""
        'Lo mismo que antes pero esta vez para el SaveFileDialog
        If guarda.ShowDialog() = Windows.Forms.DialogResult.OK Then 'Si el pulsamos aceptar en la ventanita
            If abre.FileName <> "" Then
                'Si la ruta del archivo del OpenFileDialog es diferente a nada, es decir, si tiene un nombre será que hemos cargado una foto, de lo contrario nos dejaría guardar una foto que realmente no tenemos.
                If guarda.FilterIndex = 0 Then 'Si elegimos la extensión jpg
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Jpeg) 'Formateamos el Bitmap a Jpeg y lo guardamos
                ElseIf guarda.FilterIndex = 1 Then
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Png)
                ElseIf guarda.FilterIndex = 2 Then
                    foto.Save(guarda.FileName.ToString, System.Drawing.Imaging.ImageFormat.Gif)
                    'Con los demás es exactamente igual, pero cambiando el formato.
                End If
            End If
        End If

    End Sub
    Function ExtraerImagen(ByVal Foto As Integer) As Byte()
        Dim SqlSelect As String = "Select boucher From db_detprestamo Where id_detprestamo = " & Foto
        con.Open()
        Dim Command As New SqlCommand(SqlSelect, con)
        Dim MyPhoto() As Byte = CType(Command.ExecuteScalar(), Byte())
        con.Close()
        Return MyPhoto
    End Function
    Public Sub GuardarImagen(ByVal picture As PictureBox, ByVal fecha As DateTimePicker)
        Try
            con.Open()
            Dim ms As New MemoryStream
            picture.Image.Save(ms, picture.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer

            Dim cmd As New SqlCommand("Update db_detprestamo Set fecha_cancela = @date, " & _
                                      "boucher= @Imagen, pagado = @cancela " & _
                                      "Where id_detprestamo = '" & id & "'", con)
            With cmd
                .Parameters.Add(New SqlParameter("@date", SqlDbType.DateTime)).Value = fecha.Value.Date
                .Parameters.Add(New SqlParameter("@Imagen", SqlDbType.Image)).Value = arrImage
                .Parameters.Add(New SqlParameter("@cancela", SqlDbType.Int)).Value = 1
            End With
            MessageBox.Show("Se insertado el registro correctamente", "El Sistema informa", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd.ExecuteNonQuery()
            '
        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If ConnectionState.Open Then
                con.Close()
            End If
        End Try

    End Sub
    Public Sub CancelaCuenta(ByVal Grid As DataGridView, ByVal form As Form)
        On Error GoTo rafael
        id = Grid.Item(0, Grid.CurrentCell.RowIndex).Value.ToString()
        Dim mensaje As String = MsgBox("Desea Ingresar datos de pago de esta cuota seleccionada??", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Pago de Cuota")
        If mensaje = vbYes Then
            form.ShowDialog()
        End If
        Exit Sub
rafael:
        MsgBox("Error al Obtener Id")
    End Sub
    Public Sub Posicion(ByVal form As Form)
        Dim margen As Long
        Dim barra As Long

        'Asignamos un margen de 20 pixels
        'y atura de barra de tareas
        margen = 20
        barra = 512

        'Posicionamos en la esquina superior derecha
        form.Left = Screen.PrimaryScreen.WorkingArea.Width - form.Width - margen
        form.Top = 0
        'En la esquina inferior derecha
        form.Left = Screen.PrimaryScreen.WorkingArea.Width - form.Width - margen
        form.Top = Screen.PrimaryScreen.WorkingArea.Height - form.Width - barra

        'En la esquina inferior izquierda
        form.Left = 0
        form.Top = Screen.PrimaryScreen.WorkingArea.Height - form.Height - barra

        'En la esquina superior izquierda
        form.Left = 0
        form.Top = 0
    End Sub

    'aqui la codificacion para exportacion
    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String) ', ByVal bar As ProgressBar)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        'bar.Maximum = DataGridView1.Rows.Count
        With (objHojaExcel)
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            : .Range("A1:L1").Merge()
            : .Range("A1:L1").Value = "Exportación - ARGUS SAC"
            .Range("A1:L1").Font.Bold = True
            : .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            : Dim Letra As Char, UltimaLetra As Char
            : Dim Numero As Integer, UltimoNumero As Integer
            : Dim cod_letra As Byte = Asc(primeraLetra) - 1
            : Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            : Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hoja de cálculo  
            : Dim strColumna As String = ""
            : Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            : Numero = primerNumero
            : Dim objCelda As Excel.Range
            : For Each c As DataGridViewColumn In DataGridView1.Columns
                : If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                        : Else
                        : cod_letra += 1
                        : Letra = Chr(cod_letra)
                        : End If
                    : strColumna = LetraIzq + Letra + Numero.ToString
                    : objCelda = .Range(strColumna, Type.Missing)
                    : objCelda.Value = c.HeaderText
                    : objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    : If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        : objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                        : End If
                    : End If
                : Next

            : Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            : objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            : UltimaLetra = Letra
            : Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            : Dim i As Integer = Numero + 1

            : For Each reg As DataGridViewRow In DataGridView1.Rows
                : LetraIzq = ""
                : cod_LetraIzq = Asc(primeraLetra) - 1
                : Letra = primeraLetra
                : cod_letra = Asc(primeraLetra) - 1
                : For Each c As DataGridViewColumn In DataGridView1.Columns
                    : If c.Visible Then
                        : If Letra = "Z" Then
                            : Letra = primeraLetra
                            : cod_letra = Asc(primeraLetra)
                            : cod_LetraIzq += 1
                            : LetraIzq = Chr(cod_LetraIzq)
                            : Else
                            : cod_letra += 1
                            : Letra = Chr(cod_letra)
                            : End If
                        : strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                        : End If
                    : Next
                : Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                : objRangoReg.Rows.BorderAround()
                : objRangoReg.Select()
                : i += 1
                : Next
            : UltimoNumero = i

            'Dibujar las líneas de las columnas  
            : LetraIzq = ""
            : cod_LetraIzq = Asc("A")
            : cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    : objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    : objCelda.BorderAround()
                    : If Letra = "Z" Then
                        : Letra = primeraLetra
                        : cod_letra = Asc(primeraLetra)
                        : LetraIzq = Chr(cod_LetraIzq)
                        : cod_LetraIzq += 1
                        : Else
                        : cod_letra += 1
                        Letra = Chr(cod_letra)
                        : End If
                    : End If
                : Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            : objRango.Columns.AutoFit()
            : objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

End Module