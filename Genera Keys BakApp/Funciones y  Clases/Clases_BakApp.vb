'Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
'Imports System.Math
Imports System.Data
Imports System.Data.SqlClient


Imports System.Data.OleDb


#Region "CLASES"

Public Class SQL_Server


    Sub Sb_Abrir_Conexion_SQLServer(ConexionSQL As SqlConnection, _
                                    _BaseDatos_SQL As String, _
                                    Optional MostrarError As Boolean = True)

        Dim _sCnn = "data source = " & Servidor_SQL & "; initial catalog = " & _BaseDatos_SQL & _
                             "; user id = " & Usuario_SQL & "; password = " & Clave_SQL

        Try
            If ConexionSQL.State = ConnectionState.Open Then
                ConexionSQL.Close()
            End If

            ConexionSQL.ConnectionString = _sCnn
            ConexionSQL.Open()

        Catch ex As SqlClient.SqlException 'Exception
            If MostrarError = True Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub



    Sub AbrirConexion_SQLServer(ConexionSQL As SqlConnection, _
                                Optional BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                Optional CadenaLocal As String = "", Optional MostrarError As Boolean = True)

        'Dim ConexionSQL As SqlConnection
        Dim sCnn As String = ""

        If String.IsNullOrEmpty(Servidor_SQL) Then
            If BaseConexion = 1 Then
                sCnn = Cadena_ConexionSQL_Server
            ElseIf BaseConexion = 2 Then
                sCnn = Cadena_ConexionSQL_Server_Base_Paso
            ElseIf BaseConexion = 3 Then
                sCnn = CadenaLocal
            Else
                sCnn = CadenaLocal
            End If
        Else
            sCnn = "data source = " & Servidor_SQL & "; initial catalog = " & BaseDatos_SQL & _
                                 "; user id = " & Usuario_SQL & "; password = " & Clave_SQL
        End If

        Try
            If ConexionSQL.State = ConnectionState.Open Then
                ' Cerrar conexion
                ConexionSQL.Close()
            End If
            ConexionSQL.ConnectionString = sCnn

            ConexionSQL.Open()
            'MsgBox(sCnn)

        Catch ex As SqlClient.SqlException 'Exception
            If MostrarError = True Then
                MsgBox(ex.Message)
                'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
                '                ex.Message, "Conectar con la base", _
                '                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub


    

    Sub CerrarConexion(ConexionSQL As SqlConnection)
        Try
            If ConexionSQL.State = ConnectionState.Open Then
                '' Cerrar conexion
                ConexionSQL.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "PROCEDIMIENTO QUE EJECUTA INSERT, UPDATE Y DELETE EN LA BASE DE DATOS DE SQL"
    Public Function Ej_consulta_IDU(ConsultaSql As String, _
                                    cn As SqlConnection, _
                                    Optional BaseConexion As Integer = ArchivoConexion.BasePrincipal)
        Try
            AbrirConexion_SQLServer(cn, BaseConexion)
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.Connection = cn
            cmd.CommandText = _
                ConsultaSql
            'cmd = New System.Data.SqlServerCe.SqlCeCommand(sqlCreateTableStatement, connection)
            cmd.ExecuteNonQuery()
            CerrarConexion(cn)
        Catch ex As Exception
            MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                   , MsgBoxStyle.Critical, "Modificar Datos Motor SQL Server")
            MsgBox(ex.Message)
        End Try

    End Function
#End Region

#Region "PROCEDIMIENTO QUE EJECUTA UN COMADO SELECT EN LA BASE Y TRAE COMO RESULTADO UNA TABLA CON REGISTROS"
    Function LlenarTabla_SQLServer(SQL As String, _
                                   Cnn As SqlConnection, _
                                   Optional BaseConexion As Integer = ArchivoConexion.BasePrincipal) As DataTable
        Try
            Dim DSCE As New DataSet
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            da = New SqlDataAdapter(SQL, Cnn)
            tb = New DataTable
            da.Fill(tb)
            Return tb

        Catch ex As Exception
            MsgBox(ex.Message)
            'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
            '                ex.Message, "Conectar con la base", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
#End Region

#Region "PROCEDIMIENTO PARA EDITAR TABLA DE SQL DESDE UNA GRILLA"

    Function ActualizarGrillaUpInsDel(ConsultaSQLGrilla As String, _
                                      Grilla As Object, _
                                      Cnn As SqlConnection, _
                                      Optional BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                      Optional EsGrilla As Boolean = True)
        Try
            'Abrimos la conexión con SQL
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            Dim dt As DataTable

            If EsGrilla Then
                dt = DirectCast(Grilla.DataSource, DataTable)
            Else
                dt = Grilla
            End If

            ' Procedemos a actualizar la base de datos.
            Dim n As Integer = UpInsDelDatabase(dt, ConsultaSQLGrilla, Cnn)
            CerrarConexion(Cnn)
            Return n
            'MessageBox.Show("Nº de registros afectados: " & CStr(n))
        Catch ex As Exception
            ' Se ha producido un error
            CerrarConexion(Cnn)
            MessageBox.Show(ex.Message)

        End Try
    End Function


    Function ActualizaTablaSQLUpInsDel(ConsultaSQLGrilla As String, _
                                       dt As DataTable, _
                                       Cnn As SqlConnection, _
                                       Optional BaseConexion As Integer = ArchivoConexion.BasePrincipal)
        Try
            'Abrimos la conexión con SQL
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            'Dim dt As DataTable = DirectCast(Grilla.DataSource, DataTable)
            ' Procedemos a actualizar la base de datos.
            Dim n As Integer = UpInsDelDatabase(dt, ConsultaSQLGrilla, Cnn)
            CerrarConexion(Cnn)
            Return n
            'MessageBox.Show("Nº de registros afectados: " & CStr(n))
        Catch ex As Exception
            ' Se ha producido un error
            CerrarConexion(Cnn)
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Function UpInsDelDatabase(dt As DataTable, _
                              sql As String, _
                              cn As SqlConnection) As Integer

        ' Si el valor del objeto DataTable es Nothing, provocamos
        ' una excepción.
        '
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException()

        Try

            Dim da As New SqlDataAdapter(sql, cn)

            ' Creamos un objeto CommandBuilder para configurar los comandos
            ' apropiados del adaptador de datos. Se requiere que la tabla
            ' de la base de datos tenga establecida su correspondiente
            ' clave principal.
            '
            Dim cb As New SqlCommandBuilder(da)

            With da
                .InsertCommand = cb.GetInsertCommand()
                .DeleteCommand = cb.GetDeleteCommand()
                .UpdateCommand = cb.GetUpdateCommand()
            End With

            ' Procedemos a actualizar la base de datos, devolviendo
            ' el número de registros afectados.
            '
            Return da.Update(dt)

            'End Using

        Catch ex As Exception
            Throw
            MsgBox(ex.Message)
        End Try

    End Function

#End Region

End Class

Public Class ClaseConectaAccess


    Public strConexion As String
    Public cnnConex As OleDb.OleDbConnection
    Public comand As OleDb.OleDbCommand
    Public dtrDatos As OleDb.OleDbDataReader
    Public Cb As OleDbCommandBuilder

    Public dbDataAdapter As OleDbDataAdapter



    'consultas insert,delete,update
    Sub consultaAccion(consulta As String) 'para hacer las consultar

        Try
            comand = New OleDb.OleDbCommand(consulta, cnnConex)
            System.Windows.Forms.Application.DoEvents()
            comand.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Sub cerrarConexion()
        Try
            cnnConex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



End Class

Public Class CrearDocumentoRandom

    Dim Codempresa As String
    Dim Codsucursal As String
    Dim NuevoNroDocumento As String
    Dim CodEntidad As String
    Dim Nudonodefi As Integer
    Dim Tipodocumento As String


    Dim NULIDO As String
    Dim BOSULIDO As String
    Dim KOPRCT As String
    Dim RLUDPR As String
    Dim TIPR As String

    'DIM ARCHIRST AS string = ''
    Dim SULIDO As String
    Dim KOFULIDO As String
    Dim CAPRCO1 As String
    Dim CAPRAD1 As String
    Dim CAPREX1 As String
    Dim CAPRNC1 As String
    Dim UD01PR As String
    Dim UDTRPR As String
    Dim CAPRCO2 As String
    Dim CAPRAD2 As String
    Dim CAPREX2 As String
    Dim CAPRNC2 As String
    Dim UD02PR As String
    Dim KOLTPR As String
    Dim MOPPPR As String
    Dim TIMOPPPR As String
    Dim TAMOPPPR As String
    Dim PPPRNELT As String
    Dim PPPRNE As String
    Dim PPPRBRLT As String
    Dim PPPRBR As String
    Dim PODTGLLI As String
    Dim POIMGLLI As String
    Dim VADTNELI As String
    Dim VADTBRLI As String
    Dim POIVLI As String
    Dim VAIVLI As String
    Dim VAIMLI As String
    Dim VANELI As String
    Dim VABRLI As String
    Dim FEEMLI As String
    Dim FEERLI As String

    Dim PPPRPM As String
    Dim PPPRNERE1 As String
    Dim PPPRNERE2 As String
    Dim NOKOPR As String
    Dim PPOPPR As String
    Dim LINCONDESP As String
    Dim PPPRPMSUC As String

    Sub GrabarDatos(Empresa As String, _
                        Sucursal As String, _
                        Bodega As String, _
                        ListaDeCosto As String, _
                        TIDO As String, _
                        BarEncabezados As Object, _
                        BarDetalle As Object, _
                        TxtProducto As TextBox, _
                        TxtProveedor As TextBox, _
                        TablaDePaso As String)

        Consulta_sql = "SELECT CodEntidad, CodSucursal FROM " & TablaDePaso & " WHERE Marca = '' and Fcc <> ''"
        Ejecutar_consulta_SQL(Consulta_sql, cn1)

        Dim tb1 = New DataTable
        da.Fill(tb1)

        Dim dfd As DataRow

        Dim CanFilas As Long = tb1.Rows.Count

        BarEncabezados.Maximum = CanFilas

        If tb1.Rows.Count > 0 Then

            Dim CodEnt As String
            Dim SucEnt As String

            For i As Integer = 0 To tb1.Rows.Count - 1
                System.Windows.Forms.Application.DoEvents()
                dfd = tb1.Rows(i)
                CodEnt = dfd.Item("CodEntidad").ToString
                SucEnt = dfd.Item("CodSucursal").ToString

                Dim Sigue As Long = 0

                Sigue = Cuenta_registros(TablaDePaso, "Marca = '' and CodEntidad = '" & CodEnt & _
                                         "' and CodSucursal = '" & SucEnt & "'")


                While Sigue <> 0

                    Consulta_sql = "TRUNCATE TABLE Tbl_PasoGrab"
                    Ej_consulta_IDU(Consulta_sql, cn1)

                    Consulta_sql = "SELECT top 20 CodEntidad, CodSucursal, Codigo, Comprar, CostoFcc,RazonSocial " & _
                                   "FROM " & TablaDePaso & vbCrLf & _
                                   "WHERE CodEntidad = '" & CodEnt & "' and CodSucursal = '" & SucEnt & "' " & _
                                   "and Marca = ''"
                    Ejecutar_consulta_SQL(Consulta_sql, cn1)

                    tb2 = New DataTable
                    da.Fill(tb2)

                    Dim dfd2 As DataRow '
                    Dim CodEnt2 As String
                    Dim SucEnt2 As String
                    Dim CodigoPR As String
                    Dim CantidadPR As String
                    Dim CostoPR As String

                    If tb2.Rows.Count > 0 Then
                        For u As Integer = 0 To tb2.Rows.Count - 1
                            dfd2 = tb2.Rows(u)
                            CodEnt2 = dfd2.Item("CodEntidad").ToString
                            SucEnt2 = dfd2.Item("CodSucursal").ToString
                            CodigoPR = dfd2.Item("Codigo").ToString
                            CantidadPR = De_Num_a_Tx_01(dfd2.Item("Comprar").ToString, False, 2)
                            CostoPR = De_Num_a_Tx_01(dfd2.Item("CostoFcc").ToString, False, 2)

                            TxtProveedor.Text = dfd2.Item("RazonSocial").ToString

                            Consulta_sql = "INSERT INTO Tbl_PasoGrab (ENDO,SUENDO,KOPR,CANTIDAD,PRECIO,BOSULIDO) VALUES " & _
                                           "('" & CodEnt2 & "','" & SucEnt2 & "','" & CodigoPR & _
                                           "'," & CantidadPR & "," & CostoPR & ",'" & Bodega & "')"
                            Ej_consulta_IDU(Consulta_sql, cn1)

                            Consulta_sql = "UPDATE " & TablaDePaso & " SET Marca = 'X' WHERE " & _
                                           "CodEntidad = '" & CodEnt & _
                                           "' and CodSucursal = '" & SucEnt & _
                                           "' and Codigo = '" & CodigoPR & "'"
                            Ej_consulta_IDU(Consulta_sql, cn1)


                        Next
                        Dim Nro As String
                        Nro = numero_(Val(trae_dato(tb, cn1, "COALESCE(MAX(NUDO),'0000000000')+1", "MAEEDO  WITH ( NOLOCK )", _
                                        "TIDO='OCC'  AND EMPRESA = '" & Empresa & "'")), 10)


                        'GrabarDocumentoRandom(cn1, Empresa, Sucursal, TIDO, Nro, CodEnt, SucEnt, ListaDeCosto, BarDetalle)


                    End If

                    Sigue = Cuenta_registros("Tbl_PasoCompras", "Marca = '' and CodEntidad = '" & CodEnt & _
                                         "' and CodSucursal = '" & SucEnt & "'")

                End While
                BarEncabezados.Value += 1
            Next
            BarEncabezados.value = 0
            MsgBox("Proceso terminado correctamemte", MsgBoxStyle.Information, "Generer Ordenes de Compra")
        Else
            MsgBox("No hay mas datos que insertar", MsgBoxStyle.Information, "Generar Ordenes de Compra")
        End If

    End Sub

    

    Private Function CrearEncabezadoInsertar(EMPRESA As String, TIDO As String, NUDO As String, _
                             ENDO As String, Optional NUDONODEFI As Integer = 0, _
                             Optional TIDOELEC As Integer = 0)
        Consulta_sql = "INSERT INTO MAEEDO ( EMPRESA,TIDO,NUDO,ENDO,NUDONODEFI,TIDOELEC ) VALUES " & _
                       "( '" & EMPRESA & "','" & TIDO & "','" & NUDO & "','" & ENDO & "'," & NUDONODEFI & ",0 ) "
        Return Consulta_sql
    End Function

    Private Function CrearEncabezadoActualizar(IDMAEEDO As String, SUENDO As String, ENDOFI As String, TIGEDO As String, _
    SUDO As String, LUVTDO As String, FEEMDO As String, KOFUDO As String, ESDO As String, ESPGDO As String, _
    CAPRCO As String, CAPRAD As String, CAPREX As String, CAPRNC As String, MEARDO As String, MODO As String, _
    TIMODO As String, TAMODO As String, NUCTAP As String, VACTDTNEDO As String, VACTDTBRDO As String, NUIVDO As String, _
    POIVDO As String, VAIVDO As String, NUIMDO As String, VAIMDO As String, VANEDO As String, VABRDO As String, _
    POPIDO As String, VAPIDO As String, FE01VEDO As String, FEULVEDO As String, NUVEDO As String, VAABDO As String, _
    MARCA As String, FEER As String, NUTRANSMI As String, NUCOCO As String, KOTU As String, LIBRO As String, LCLV As String, _
    ESFADO As String, KOTRPCVH As String, NULICO As String, PERIODO As String, NUDONODEFI As String, TRANSMASI As String, _
    POIVARET As String, VAIVARET As String, RESUMEN As String, LAHORA As String, KOFUAUDO As String, KOOPDO As String, _
    ESPRODDO As String, DESPACHO As String, HORAGRAB As String, RUTCONTACT As String, SUBTIDO As String, TIDOELEC As String, _
    ESDOIMP As String, CUOGASDIF As String, BODESTI As String, PROYECTO As String, FECHATRIB As String, NUMOPERVEN As String, _
    BLOQUEAPAG As String, VALORRET As String, FLIQUIFCV As String, VADEIVDO As String, KOCANAL As String)



        Consulta_sql = _
        "UPDATE MAEEDO SET " & _
        "SUENDO = '" & SUENDO & "'," & _
        "ENDOFI = '" & ENDOFI & "'," & _
        "TIGEDO = '" & TIGEDO & "'," & _
        "SUDO = '" & SUDO & "'," & _
        "LUVTDO = '" & LUVTDO & "'," & _
        "FEEMDO = '" & FEEMDO & "'," & _
        "KOFUDO = '" & KOFUDO & "'," & _
        "ESDO = '" & ESDO & "'," & _
        "ESPGDO = '" & ESPGDO & "'," & _
        "CAPRCO = " & CAPRCO & "," & _
        "CAPRAD = " & CAPRAD & "," & _
        "CAPREX = " & CAPREX & "," & _
        "CAPRNC = " & CAPRNC & "," & _
        "MEARDO = '" & MEARDO & "'," & _
        "MODO = '" & MODO & "'," & _
        "TIMODO = '" & TIMODO & "'," & _
        "TAMODO = " & TAMODO & "," & _
        "NUCTAP = " & NUCTAP & "," & _
        "VACTDTNEDO = " & VACTDTNEDO & "," & _
        "VACTDTBRDO = " & VACTDTBRDO & "," & _
        "NUIVDO = " & NUIVDO & "," & _
        "POIVDO = " & POIVDO & "," & _
        "VAIVDO = " & VAIVDO & "," & _
        "NUIMDO = " & NUIMDO & "," & _
        "VAIMDO = " & VAIMDO & "," & _
        "VANEDO = " & VANEDO & "," & _
        "VABRDO = " & VABRDO & "," & _
        "POPIDO = " & POPIDO & "," & _
        "VAPIDO = " & VAPIDO & "," & _
        "FE01VEDO = '" & FE01VEDO & "'," & _
        "FEULVEDO = '" & FEULVEDO & "'," & _
        "NUVEDO = " & NUVEDO & "," & _
        "VAABDO = " & VAABDO & "," & _
        "MARCA = '" & MARCA & "'," & _
        "FEER = '" & FEER & "'," & _
        "NUTRANSMI = '" & NUTRANSMI & "'," & _
        "NUCOCO = '" & NUCOCO & "'," & _
        "KOTU = '" & KOTU & "'," & _
        "LIBRO = '" & LIBRO & "'," & _
        "ESFADO = '" & ESFADO & "'," & _
        "KOTRPCVH = '" & KOTRPCVH & "'," & _
        "NULICO = '" & NULICO & "'," & _
        "PERIODO = '" & PERIODO & "'," & _
        "NUDONODEFI = " & NUDONODEFI & "," & _
        "TRANSMASI = '" & TRANSMASI & "'," & _
        "POIVARET = " & POIVARET & "," & _
        "VAIVARET = " & VAIVARET & "," & _
        "RESUMEN = '" & RESUMEN & "'," & _
        "LAHORA = '" & LAHORA & "'," & _
        "KOFUAUDO = '" & KOFUAUDO & "'," & _
        "KOOPDO = '" & KOOPDO & "'," & _
        "ESPRODDO = '" & ESPRODDO & "'," & _
        "DESPACHO = " & DESPACHO & "," & _
        "HORAGRAB = " & HORAGRAB & "," & _
        "RUTCONTACT = '" & RUTCONTACT & "'," & _
        "SUBTIDO = '" & SUBTIDO & "'," & _
        "TIDOELEC = " & TIDOELEC & "," & _
        "ESDOIMP = '" & ESDOIMP & "'," & _
        "CUOGASDIF = " & CUOGASDIF & "," & _
        "BODESTI = '" & BODESTI & "'," & _
        "PROYECTO = '" & PROYECTO & "'," & _
        "NUMOPERVEN = " & NUMOPERVEN & "," & _
        "BLOQUEAPAG = '" & BLOQUEAPAG & "'," & _
        "VALORRET = " & VALORRET & "," & _
        "VADEIVDO = " & VADEIVDO & "," & _
        "KOCANAL = '" & KOCANAL & "' " & _
        "WHERE IDMAEEDO=" & IDMAEEDO

        '"LCLV = '" & LCLV & "'," & _ NULL   SE GRABARAN VALORES NULOS EN ESTOS CAMPOS
        '"FECHATRIB = '" & FECHATRIB & "'," & _ NULL
        '"FLIQUIFCV = '" & FLIQUIFCV & "'," & _

        Return Consulta_sql

    End Function

    Private Function CrearDetalle(IDMAEEDO As String, _
    ARCHIRST As String, _
    EMPRESA As String, _
    TIDO As String, _
    NUDO As String, _
    ENDO As String, _
    SUENDO As String, _
    NULIDO As String, _
    SULIDO As String, _
    BOSULIDO As String, _
    KOFULIDO As String, _
    KOPRCT As String, _
    RLUDPR As String, _
    UDTRPR As String, _
    CAPRCO1 As String, _
    CAPRAD1 As String, _
    CAPREX1 As String, _
    CAPRNC1 As String, _
    UD01PR As String, _
    CAPRCO2 As String, _
    CAPRAD2 As String, _
    CAPREX2 As String, _
    CAPRNC2 As String, _
    UD02PR As String, _
    KOLTPR As String, _
    MOPPPR As String, _
    TIMOPPPR As String, _
    TAMOPPPR As String, _
    PPPRNELT As String, _
    PPPRNE As String, _
    PPPRBRLT As String, _
    PPPRBR As String, _
    PODTGLLI As String, _
    VADTNELI As String, _
    VADTBRLI As String, _
    POIVLI As String, _
    VAIVLI As String, _
    VAIMLI As String, _
    VANELI As String, _
    VABRLI As String, _
    FEEMLI As String, _
    FEERLI As String, _
    PPPRPM As String, _
    PPPRNERE1 As String, _
    PPPRNERE2 As String, _
    NOKOPR As String, _
    PPOPPR As String, _
    LINCONDESP As String, _
    PPPRPMSUC As String, _
    Optional IDRST As String = "0", _
    Optional ENDOFI As String = "", _
    Optional LILG As String = "SI", _
    Optional LUVTLIDO As String = "", _
    Optional NULILG As String = "", _
    Optional PRCT As String = "0", _
    Optional TICT As String = "", _
    Optional TIPR As String = "", _
    Optional NUSEPR As String = "", _
    Optional NUDTLI As String = "0", _
    Optional NUIMLI As String = "0", _
    Optional POIMGLLI As String = "0", _
    Optional TIGELI As String = "I", _
    Optional EMPREPA As String = "", _
    Optional TIDOPA As String = "", _
    Optional NUDOPA As String = "", _
    Optional ENDOPA As String = "", _
    Optional NULIDOPA As String = "", _
    Optional LLEVADESP As String = "0", _
    Optional OPERACION As String = "", _
    Optional CODMAQ As String = "", _
    Optional ESLIDO As String = "", _
    Optional ESFALI As String = "", _
    Optional CAFACO As String = "0", _
    Optional CAFAAD As String = "0", _
    Optional CAFAEX As String = "0", _
    Optional CMLIDO As String = "0", _
    Optional NULOTE As String = "", _
    Optional FVENLOTE As String = "", _
    Optional ARPROD As String = "", _
    Optional NULIPROD As String = "", _
    Optional NUCOCO As String = "", _
    Optional NULICO As String = "", _
    Optional PERIODO As String = "", _
    Optional FCRELOTE As String = "", _
    Optional SUBLOTE As String = "", _
    Optional ALTERNAT As String = "", _
    Optional PRENDIDO As String = "0", _
    Optional OBSERVA As String = "", _
    Optional KOFUAULIDO As String = "", _
    Optional KOOPLIDO As String = "", _
    Optional MGLTPR As String = "0", _
    Optional TIPOMG As String = "0", _
    Optional ESPRODLI As String = "", _
    Optional CAPRODCO As String = "0", _
    Optional CAPRODAD As String = "0", _
    Optional CAPRODEX As String = "0", _
    Optional CAPRODRE As String = "0", _
    Optional TASADORIG As String = "0", _
    Optional CUOGASDIF As String = "0", _
    Optional PROYECTO As String = "", _
    Optional POTENCIA As String = "0", _
    Optional HUMEDAD As String = "0", _
    Optional IDTABITPRE As String = "0", _
    Optional IDODDGDV As String = "0", _
    Optional PODEIVLI As String = "0", _
    Optional VADEIVLI As String = "0", _
    Optional PRIIDETIQ As String = "0", _
    Optional KOLORESCA As String = "", _
    Optional KOENVASE As String = "")

        FCRELOTE = "'" & Format(Now.Date, "yyyyMMdd") & "'"
        FVENLOTE = FCRELOTE


        Consulta_sql = "INSERT INTO MAEDDO(IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,ENDOFI,LILG,NULIDO,SULIDO,LUVTLIDO,BOSULIDO,KOFULIDO,NULILG,PRCT,TICT,TIPR," & _
                        "NUSEPR,KOPRCT,UDTRPR,RLUDPR,CAPRCO1,CAPRAD1,CAPREX1,CAPRNC1,UD01PR,CAPRCO2,CAPRAD2,CAPREX2,CAPRNC2,UD02PR,KOLTPR,MOPPPR,TIMOPPPR," & _
                        "TAMOPPPR,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,NUDTLI,PODTGLLI,VADTNELI,VADTBRLI,POIVLI,VAIVLI,NUIMLI,POIMGLLI,VAIMLI,VANELI,VABRLI,TIGELI," & _
                        "EMPREPA,TIDOPA,NUDOPA,ENDOPA,NULIDOPA,LLEVADESP,FEEMLI,FEERLI,PPPRPM,OPERACION,CODMAQ,ESLIDO,PPPRNERE1,PPPRNERE2,ESFALI,CAFACO,CAFAAD," & _
                        "CAFAEX,CMLIDO,NULOTE,FVENLOTE,ARPROD,NULIPROD,NUCOCO,NULICO,PERIODO,FCRELOTE,SUBLOTE,NOKOPR,ALTERNAT,PRENDIDO,OBSERVA,KOFUAULIDO,KOOPLIDO, " & _
                        "MGLTPR,PPOPPR,TIPOMG,ESPRODLI,CAPRODCO,CAPRODAD,CAPRODEX,CAPRODRE,TASADORIG,CUOGASDIF,PROYECTO,POTENCIA,HUMEDAD,IDTABITPRE,IDODDGDV," & _
                        "LINCONDESP,PODEIVLI,VADEIVLI,PRIIDETIQ,KOLORESCA,KOENVASE,PPPRPMSUC) " & _
                        "VALUES ( " & IDMAEEDO & ",'" & ARCHIRST & "'," & IDRST & ",'" & EMPRESA & "','" & TIDO & "','" & NUDO & "','" & ENDO & "','" & SUENDO & "','" & ENDOFI & "','" & LILG & "','" & NULIDO & "','" & SULIDO & "','" & LUVTLIDO & "','" & BOSULIDO & "','" & KOFULIDO & "','" & NULILG & "'," & PRCT & ",'" & TICT & "','" & TIPR & "'," & _
                        "'" & NUSEPR & "','" & KOPRCT & "'," & UDTRPR & "," & RLUDPR & "," & CAPRCO1 & "," & CAPRAD1 & "," & CAPREX1 & "," & CAPRNC1 & ",'" & UD01PR & "'," & CAPRCO2 & "," & CAPRAD2 & "," & CAPREX2 & "," & CAPRNC2 & ",'" & UD02PR & "','TABPP" & KOLTPR & "','" & MOPPPR & "','" & TIMOPPPR & "'," & _
                        TAMOPPPR & "," & PPPRNELT & "," & PPPRNE & "," & PPPRBRLT & "," & PPPRBR & "," & NUDTLI & "," & PODTGLLI & "," & VADTNELI & "," & VADTBRLI & "," & POIVLI & "," & VAIVLI & "," & NUIMLI & "," & POIMGLLI & "," & VAIMLI & "," & VANELI & "," & VABRLI & ",'" & TIGELI & "'," & _
                        "'" & EMPREPA & "','" & TIDOPA & "','" & NUDOPA & "','" & ENDOPA & "','" & NULIDOPA & "'," & LLEVADESP & ",'" & FEEMLI & "','" & FEERLI & "'," & PPPRPM & ",'" & OPERACION & "','" & CODMAQ & "','" & ESLIDO & "'," & PPPRNERE1 & "," & PPPRNERE2 & ",'" & ESFALI & "'," & CAFACO & "," & CAFAAD & "," & _
                        CAFAEX & "," & CMLIDO & ",'" & NULOTE & "'," & FVENLOTE & ",'" & ARPROD & "','" & NULIPROD & "','" & NUCOCO & "','" & NULICO & "','" & PERIODO & "'," & FCRELOTE & ",'" & SUBLOTE & "','" & NOKOPR & "','" & ALTERNAT & "'," & PRENDIDO & ",'" & OBSERVA & "','" & KOFUAULIDO & "','" & KOOPLIDO & "'," & _
                        MGLTPR & "," & PPOPPR & "," & TIPOMG & ",'" & ESPRODLI & "'," & CAPRODCO & "," & CAPRODAD & "," & CAPRODEX & "," & CAPRODRE & "," & TASADORIG & "," & CUOGASDIF & ",'" & PROYECTO & "'," & POTENCIA & "," & HUMEDAD & "," & IDTABITPRE & "," & IDODDGDV & "," & _
                        LINCONDESP & "," & PODEIVLI & "," & VADEIVLI & "," & PRIIDETIQ & ",'" & KOLORESCA & "','" & KOENVASE & "'," & PPPRPMSUC & ")"
        Return Consulta_sql


    End Function

    Private Function InsertaDescuentosEnDetalle(IDMAEEDO As Integer, _
                                        NULIDO As String, _
                                        KODT As String, _
                                        PODT As Double, _
                                        VADT As Double, _
                                        LILG As String, _
                                        OPERA As String, _
                                        UNITAR As Double)

        Consulta_sql = "INSERT INTO MAEDTLI( IDMAEEDO,NULIDO,KODT,PODT,VADT,LILG,OPERA,UNITAR) VALUES " & _
        "( " & IDMAEEDO & ",'" & NULIDO & "','" & KODT & "'," & PODT & "," & VADT & ",'" & LILG & "','" & OPERA & "'," & UNITAR & ")"

        Return Consulta_sql
    End Function

    Private Function InsertarObservacionDocumento()
        Consulta_sql = "INSERT INTO MAEEDOOB ( IDMAEEDO,OBDO,OCDO,CPDO,DIENDESP,MOTIVO,TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5," & _
                       "TEXTO6,TEXTO7,TEXTO8,TEXTO9,TEXTO10,TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,TEXTO16,TEXTO17,TEXTO18," & _
                       "TEXTO19,TEXTO20,TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27,TEXTO28,TEXTO29,TEXTO30,TEXTO31," & _
                       "TEXTO32,CARRIER,BOOKING,LADING,AGENTE,MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE,KOPAD,KOCID," & _
                       "KOCMD,FECHAD,HORAD,OBDOEXPO,PLACAPAT)" & _
                       "VALUES ( 99550,'OBSERVACIONES EN EL DOCUMENTO','','30 60 90 DIAS','','','','','','','','','','','',''," & _
                       "'','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',NULL,''," & _
                       "'','','',NULL,'','','')"
        Return Consulta_sql

    End Function




End Class












#End Region



