Imports System.Data.SQLite

Public Class Class_SQLite

    Dim _Directorio_Base_Sqlite As String
    Dim _Error As String
    ':::Ahora creamos un objeto de nombre "con" de tipo SQLiteConnetion
    ':::Y le asignamos nuestra cadena de conexión con la ruta de nuestra base de datos
    Dim _Cn As New SQLiteConnection

    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Sub New(Directorio_Base_Sqlite As String)
        _Directorio_Base_Sqlite = Directorio_Base_Sqlite
    End Sub

    Function Sb_Abrir_Conexion(ByRef _Cn As SQLiteConnection)
        _Error = String.Empty
        ':::Nuestro objeto SQLiteConnection con la cadena de conexión y la ruta de la base
        _Cn = New SQLiteConnection("Data Source=" & _Directorio_Base_Sqlite & "; Version=3") ' "Data Source=C:\Pueba SqlLite\PruebaDB.db; Version=3")
        ':::Utilizamos el try para capturar posibles errores
        Try
            ':::Abrimos la conexión
            _Cn.Open()
            ':::Si se estableció conexión correctamente dirá "Conectado"
        Catch ex As Exception
            ':::Si no se conecta nos mostrara el posible fallo en la conexión
            _Error = ex.Message
            'MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Function

    Sub Sb_Cerrar_Conexion(_Cn As SQLiteConnection)
        Try
            If _Cn.State = ConnectionState.Open Then
                '' Cerrar conexion
                _Cn.Close()
            End If
        Catch ex As Exception
            _Error = String.Empty
        End Try
    End Sub

    Function Ej_consulta_IDU(ConsultaSql As String) As Boolean
        Try
            'Abrimos la conexión con la base de datos
            Sb_Abrir_Conexion(_Cn)
            'System.Windows.Forms.Application.DoEvents()
            Dim cmd As System.Data.SQLite.SQLiteCommand
            cmd = New System.Data.SQLite.SQLiteCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ConsultaSql
            cmd.CommandTimeout = 0
            cmd.Connection = _Cn

            cmd.ExecuteNonQuery()

            'Cerramos la conexión con la base de datos
            Sb_Cerrar_Conexion(_Cn)

            System.Windows.Forms.Application.DoEvents()
            Return True
        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Fx_Get_DataSet(Consulta_sql As String) As DataSet

        Try
            Sb_Abrir_Conexion(_Cn)

            Dim dt As DataTable = New DataTable()

            Dim _SqlDa As New SQLiteDataAdapter
            Dim _DataSt As New DataSet

            _SqlDa = New SQLite.SQLiteDataAdapter(Consulta_sql, _Cn)
            _SqlDa.SelectCommand.CommandTimeout = 8000

            _SqlDa.MissingSchemaAction = MissingSchemaAction.AddWithKey
            _SqlDa.Fill(_DataSt)

            Sb_Cerrar_Conexion(_Cn)

            Return _DataSt
            ' errores
        Catch ex As Exception
            _Error = String.Empty
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function

    Function Fx_Get_Tablas(Consulta_sql As String) As DataTable

        Dim _Tbl As New DataTable
        _Error = String.Empty
        'Dim _Cn As SQLiteConnection

        Try
            Sb_Abrir_Conexion(_Cn)

            Dim _SqlDa As New SQLiteDataAdapter
            Dim _DataSt As New DataSet

            _SqlDa = New SQLite.SQLiteDataAdapter(Consulta_sql, _Cn)
            _SqlDa.SelectCommand.CommandTimeout = 8000

            _SqlDa.Fill(_Tbl)
            Sb_Cerrar_Conexion(_Cn)

            ' retornar el dataTable
            Return _Tbl

            ' errores
        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Fx_Get_DataRow(Consulta_sql As String) As DataRow

        Try

            Dim _Tbl As DataTable = Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl.Rows.Count) Then
                Return _Tbl.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function selectClave(clave As Integer) As SQLiteDataReader

        Dim con As SQLiteConnection = New SQLiteConnection("Data Source=basedatos.bd")
        Dim param As SQLiteParameter = New SQLiteParameter()
        param.Value = clave
        Dim cmdStr As String = "SELECT campo2 FROM tabla1 WHERE campo1 = ?;"
        Dim cmd As SQLiteCommand = New SQLiteCommand(cmdStr, con)
        cmd.Parameters.Add(param)
        Dim reader As SQLiteDataReader = cmd.ExecuteReader()
        Return reader

    End Function

    Function Fx_Reader(Consulta_Sql As String) As SQLiteDataReader

        Dim con As SQLiteConnection = New SQLiteConnection("Data Source=basedatos.bd")
        Dim param As SQLiteParameter = New SQLiteParameter()
        ' param.Value = clave
        Dim cmdStr As String = "SELECT campo2 FROM tabla1 WHERE campo1 = ?;"
        Dim cmd As SQLiteCommand = New SQLiteCommand(cmdStr, con)
        cmd.Parameters.Add(param)
        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

        Return reader

    End Function


    Sub Sb_Probar_Conexion(_Fm As Form)
        Sb_Abrir_Conexion(_Cn)

        If String.IsNullOrEmpty(_Error) Then
            MessageBox.Show(_Fm, "Conexión OK", "Probar conexión", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(_Fm, _Error, "Erro de conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Enum Enum_Type
        _String
        _Double
        _Boolean
        _Date
        _ComboBox
    End Enum

    Function Fx_Trae_Dato(_Tabla As String,
                         _Campo As String,
                         Optional _Condicion As String = "",
                         Optional _DevNumero As Boolean = False,
                         Optional _MostrarError As Boolean = True,
                         Optional _Dato_Default As String = "") As String
        Try
            _Error = String.Empty
            Dim _Valor
            Dim _Valor_Si_No_Encuentra As String

            If Not String.IsNullOrEmpty(_Condicion) Then
                _Condicion = vbCrLf & "And " & _Condicion
            End If

            If _DevNumero Then

            End If
            'Then Valor_Si_No_Encuentra = 0

            Dim _Sql As String = "SELECT " & _Campo & " AS CAMPO FROM " & _Tabla & vbCrLf &
                                 "Where 1 > 0" & _Condicion


            Dim _Tbl As DataTable = Fx_Get_Tablas(_Sql)

            Dim cuenta As Long = _Tbl.Rows.Count

            If CBool(_Tbl.Rows.Count) Then

                _Valor = _Tbl.Rows(0).Item("CAMPO")

                If _DevNumero Then
                    _Valor = NuloPorNro(_Valor, 0)
                Else
                    _Valor = NuloPorNro(_Valor, "")
                End If

            Else
                If _DevNumero Then
                    _Valor = 0
                Else
                    _Valor = ""
                End If
            End If

            If String.IsNullOrEmpty(_Valor) Then
                _Valor = _Dato_Default
            End If

            Return _Valor


        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Sub Sb_Parametro_Informe_Sqlite(ByRef _Objeto As Object,
                                    _Informe As String,
                                    _Campo As String,
                                    _Tipo As Enum_Type,
                                    ByRef _Valor_x_defecto As String)
        Dim Consulta_sql As String
        Dim _Row_Fila As DataRow
        Dim _Valor

        'If Not (_Objeto Is Nothing) Then
        'Select Case _Tipo
        'Case Enum_Type._String, Enum_Type._ComboBox
        '_Valor_x_defecto = _Objeto.SelectedValue
        'Case Enum_Type._Double
        '_Valor_x_defecto = _Objeto.Value
        'Case Enum_Type._Boolean
        '_Valor_x_defecto = _Objeto.Checked
        'Case Enum_Type._Date
        '_Valor_x_defecto = Format(_Objeto.Value, "dd-MM-yyyy")
        'End Select
        'End If

        Dim _Insertar_dato = True

        Consulta_sql = "Select * From Tbl_Prm_Informes Where Informe = '" & _Informe & "' And Campo = '" & _Campo & "'"
        _Row_Fila = Fx_Get_DataRow(Consulta_sql)

        If (_Row_Fila Is Nothing) Then

            Select Case _Tipo
                Case Enum_Type._String, Enum_Type._ComboBox
                    _Valor = _Valor_x_defecto
                Case Enum_Type._Double
                    _Valor = De_Txt_a_Num_01(_Valor_x_defecto)
                Case Enum_Type._Boolean
                    _Valor = CBool(_Valor_x_defecto)
                Case Enum_Type._Date
                    _Valor = CDate(_Valor_x_defecto)
            End Select

            If _Insertar_dato Then
                Consulta_sql = "INSERT INTO Tbl_Prm_Informes (Informe,Campo,Tipo,Valor) VALUES" & Space(1) &
                          "('" & _Informe & "','" & _Campo & "','" & Replace(_Tipo.ToString, "_", "") & "','" & _Valor & "')"
                Ej_consulta_IDU(Consulta_sql)
            End If

        Else

            Select Case _Tipo
                Case Enum_Type._String, Enum_Type._ComboBox
                    _Valor = _Row_Fila.Item("Valor")
                Case Enum_Type._Double
                    _Valor = De_Txt_a_Num_01(_Row_Fila.Item("Valor"))
                Case Enum_Type._Boolean
                    _Valor = CBool(_Row_Fila.Item("Valor"))
                Case Enum_Type._Date
                    _Valor = CDate(_Row_Fila.Item("Valor"))
            End Select

        End If

        If Not (_Objeto Is Nothing) Then
            Select Case _Tipo
                Case Enum_Type._String
                    _Objeto.Text = _Valor
                Case Enum_Type._Double
                    _Objeto.Value = De_Txt_a_Num_01(_Valor)
                Case Enum_Type._Date
                    _Objeto.Value = CDate(_Valor)
                Case Enum_Type._Boolean
                    _Objeto.Checked = _Valor
                Case Enum_Type._ComboBox
                    _Objeto.SelectedValue = _Valor
            End Select
        End If

        _Valor_x_defecto = _Valor

    End Sub

End Class
