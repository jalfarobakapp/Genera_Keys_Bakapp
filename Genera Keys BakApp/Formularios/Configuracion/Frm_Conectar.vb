Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_Conectar

    Public _Grabar As Boolean

    Private Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click

        If Fx_Conectar() Then
            BtnGrabar.Enabled = True
            GrupoConexion.Enabled = False
        End If

    End Sub


    Function Fx_Conectar() As Boolean

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        SV = TxtServidor.Text
        PT = TxtPuerto.Text
        BD = TxtBaseDeDatos.Text
        US = TxtUsuario.Text
        PW = TxtClave.Text

        If Trim(PT) <> "" Then
            SV = Trim(SV & "," & PT)
        End If

        Cadena = Replace(Cadena, "#SV#", SV)
        Cadena = Replace(Cadena, "#BD#", BD)
        Cadena = Replace(Cadena, "#US#", US)
        Cadena = Replace(Cadena, "#PW#", PW)

        Dim SqlCn As New SQL_Server

        Dim ConexionSQL As SqlConnection
        ConexionSQL = cn1

        If ConexionSQL.State = ConnectionState.Open Then
            ' Cerrar conexion
            ConexionSQL.Close()
        End If

        ConexionSQL.ConnectionString = Cadena
        Cadena_ConexionSQL_Server = Cadena

        Try
            ConexionSQL.Open()

            Consulta_sql = "SELECT TOP 1 RAZON,RUT,NCORTO,DIRECCION,CIUDAD,PAIS,TELEFONOS,GIRO FROM CONFIGP"

            Dim Tabla = get_Tablas(Consulta_sql, cn1)

            Dim Fila As DataRow
            Fila = Tabla.Rows(0)

            TxtRut.Text = Trim(Fila.Item("RUT"))
            TxtRazonSocial.Text = Trim(Fila.Item("RAZON"))
            TxtNombreCorto.Text = Trim(Fila.Item("NCORTO"))

            TxtDireccion.Text = Trim(Fila.Item("DIRECCION"))
            TxtGiro.Text = Trim(Fila.Item("GIRO"))
            TxtPais.Text = Trim(Fila.Item("PAIS"))
            TxtCiudad.Text = Trim(Fila.Item("CIUDAD"))
            TxtTelefonos.Text = Trim(Fila.Item("TELEFONOS"))

            Dim Rt = Split(Trim(Fila.Item("RUT")), "-")

            Dim info As New TaskDialogInfo("Conectar con base de datos", _
                                         eTaskDialogIcon.ShieldOk, _
                                         "CONEXIÓN EXITOSA", _
                                         "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf & _
                                         "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf & _
                                         "Empresa: " & Trim(Fila.Item("RAZON")), _
                                         eTaskDialogButton.Ok _
                                         , eTaskDialogBackgroundColor.Blue, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim result As eTaskDialogResult = TaskDialog.Show(info)


            Return True


        Catch ex As Exception
            MsgBox("No es posible conectar con la base de datos", MsgBoxStyle.Critical, "Conexión")
            TxtServidor.SelectAll()
            TxtServidor.Focus()
        End Try

    End Function

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim _Reg As Boolean = CBool(Cuenta_registros("Zw_Empresas", "Rut = '" & TxtRut.Text & "'", 4, _CadenaLocal))

        If _Reg Then

            If MessageBoxEx.Show(Me, "¿Desea actualizar los datos?", "Esta empresa ya esta registrada", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Servidor, Puerto, Usuario, Clave, BaseDeDatos
                Consulta_sql = "Update Zw_Empresas Set Servidor = '" & TxtServidor.Text & "'," & _
                                                      "Puerto = '" & TxtPuerto.Text & "'," & _
                                                      "Usuario = '" & TxtUsuario.Text & "'," & _
                                                      "Clave = '" & TxtClave.Text & "'," & _
                                                      "BaseDeDatos = '" & TxtBaseDeDatos.Text & "'" & vbCrLf & _
                                                      "Where Rut = '" & TxtRut.Text & "'"

                If Ej_consulta_IDU(Consulta_sql, cn3, 4, _CadenaLocal) Then

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar empresa", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Grabar = True
                    Me.Close()

                End If

            Else
                Return
            End If

        Else

            Consulta_sql = "Insert Into Zw_Empresas (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos," & _
                                        "Servidor,Puerto,Usuario,Clave,BaseDeDatos,Cant_licencias,BaseDeDatos_BakApp) Values " & vbCrLf & _
                                        "('" & TxtRut.Text & "','" & TxtRazonSocial.Text & "','" & TxtNombreCorto.Text & _
                                        "','" & TxtDireccion.Text & "','" & TxtGiro.Text & "','" & TxtCiudad.Text & _
                                        "','" & TxtPais.Text & "','" & TxtTelefonos.Text & "','" & TxtServidor.Text & _
                                        "','" & TxtPuerto.Text & "','" & TxtUsuario.Text & "','" & TxtClave.Text & _
                                        "','" & TxtBaseDeDatos.Text & "',0,'" & TxtBaseDeDatosBakApp.Text & "')"

            If Ej_consulta_IDU(Consulta_sql, cn3, 4, _CadenaLocal) Then
                MessageBoxEx.Show(Me, "Datos insertados correctamente", "Grabar empresa", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        TxtRut.Text = String.Empty
        TxtRazonSocial.Text = String.Empty
        TxtNombreCorto.Text = String.Empty
        TxtDireccion.Text = String.Empty
        TxtGiro.Text = String.Empty
        TxtPais.Text = String.Empty
        TxtCiudad.Text = String.Empty
        TxtTelefonos.Text = String.Empty

        TxtServidor.Text = String.Empty
        TxtUsuario.Text = String.Empty
        TxtClave.Text = String.Empty
        TxtBaseDeDatos.Text = String.Empty

        GrupoConexion.Enabled = True
        TxtServidor.Focus()

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        _Grabar = False
        Me.Close()
    End Sub
End Class