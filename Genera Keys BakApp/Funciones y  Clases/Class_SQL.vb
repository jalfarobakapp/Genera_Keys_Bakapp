Imports System.Data.SqlClient
Imports System.IO

Public Class Class_SQL

    Dim _SQL_String_conexion As String
    Dim _Cn As New SqlConnection

    Public Sub New(ByVal SQL_String_conexion As String)
        _SQL_String_conexion = SQL_String_conexion
    End Sub

    Function Ej_consulta_IDU(ByVal ConsultaSql As String, _
                             Optional ByVal MostrarError As Boolean = True) As Boolean
        Try
            'Abrimos la conexión con la base de datos


            Sb_Abrir_Conexion(_Cn)
            'System.Windows.Forms.Application.DoEvents()
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
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
            If MostrarError = True Then
                MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                       , MsgBoxStyle.Critical, "Modificar tabla")
                MsgBox(ex.Message)
            End If
            Return False
        End Try

    End Function

    Function Fx_Get_Tablas(ByVal _Consulta_sql As String) As DataTable

        Dim _Tbl As New DataTable

        Try
            Sb_Abrir_Conexion(_Cn)

            Dim _SqlDa As New SqlDataAdapter

            _SqlDa = New SqlDataAdapter(_Consulta_sql, _Cn)
            _SqlDa.SelectCommand.CommandTimeout = 8000

            _SqlDa.Fill(_Tbl)
            Sb_Cerrar_Conexion(_Cn)

            ' retornar el dataTable
            Return _Tbl

            ' errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function

    Function Fx_Extrae_Archivo_desde_BD(ByVal _Tabla As String, _
                                        ByVal _Campo As String, _
                                        ByVal _Condicion As String, _
                                        ByVal _Nom_Archivo As String, _
                                        ByVal _Dir_Temp As String) As Boolean

        Dim data As Byte() = Nothing

        Try
            ' Construimos los correspondientes objetos para
            ' conectarnos a la base de datos de SQL Server,
            ' utilizando la seguridad integrada de Windows NT.
            '
            Using cn As New SqlConnection
                Dim sCnn = _SQL_String_conexion
                cn.ConnectionString = sCnn
                Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
                ' Seleccionamos únicamente el campo que contiene
                ' los documentos, filtrándolo mediante su
                ' correspondiente campo identificador.
                '
                cmd.CommandText = "SELECT " & _Campo & " From " & _Tabla & " WHERE " & _Condicion
                ' Abrimos la conexión.
                cn.Open()
                ' Creamos un DataReader.
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                cmd.CommandTimeout = 8000
                ' Leemos el registro.
                dr.Read()
                ' El tamaño del búfer debe ser el adecuado para poder
                ' escribir en el archivo todos los datos leídos.
                '
                ' Si el parámetro 'buffer' lo pasamos como Nothing, obtendremos
                ' la longitud del campo en bytes.
                '
                Dim bufferSize As Integer = Convert.ToInt32(dr.GetBytes(0, 0, Nothing, 0, 0))

                ' Creamos el array de bytes. Como el índice está
                ' basado en cero, la longitud del array será la
                ' longitud del campo menos una unidad.
                '
                data = New Byte(bufferSize - 1) {}

                ' Leemos el campo.
                '
                dr.GetBytes(0, 0, data, 0, bufferSize)

                ' Cerramos el objeto DataReader, e implícitamente la conexión.
                '
                dr.Close()

            End Using

            ' Procedemos a crear el archivo, en el ejemplo
            ' un documento de Microsoft Word.
            '
            If File.Exists(_Dir_Temp & "\" & _Nom_Archivo) Then File.Delete(_Dir_Temp & "\" & _Nom_Archivo)

            Using fs As New IO.FileStream(_Dir_Temp & "\" & _Nom_Archivo, IO.FileMode.CreateNew, IO.FileAccess.Write)

                ' Crea el escritor para la secuencia.
                Dim bw As New IO.BinaryWriter(fs)

                ' Escribir los datos en la secuencia.
                bw.Write(data)

            End Using


            'Sb_WriteBinaryFile(Me, _Dir_Temp & "\" & _Nom_Archivo, data)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    'System.Windows.Forms.Application.DoEvents()
    Sub Sb_Abrir_Conexion(ByVal _Cn As SqlConnection)

        Try
            If _Cn.State = ConnectionState.Open Then
                ' Cerrar conexion
                _Cn.Close()
            End If

            _Cn.ConnectionString = _SQL_String_conexion
            _Cn.Open()
            'MsgBox(sCnn)

        Catch ex As SqlClient.SqlException 'Exception
            MsgBox(ex.Message)
            'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
            '                ex.Message, "Conectar con la base", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub Sb_Cerrar_Conexion(ByVal _Cn As SqlConnection)
        Try
            If _Cn.State = ConnectionState.Open Then
                '' Cerrar conexion
                _Cn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
