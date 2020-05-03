Imports DevComponents.DotNetBar
Imports System.Data.SqlClient

Public Class Frm_Conectar

    Dim _Grabar As Boolean
    Dim _Sql As Class_SQL
    Dim _Cadena_Conexion_Base_Cliente As String

    Dim _SQLite As Class_SQLite
    Dim _Base_SQlLite_Local As String = Application.StartupPath & "\Db\" & "Genera_Keys_BakApp.db"

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _SQLite = New Class_SQLite(_Base_SQlLite_Local)

    End Sub

    Private Sub Frm_Conectar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = TxtServidor
    End Sub
    Private Sub BtnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConectar.Click

        If Fx_Conectar() Then
            BtnGrabar.Enabled = True
            GrupoConexion.Enabled = False
        End If

    End Sub

    Function Fx_Conectar() As Boolean

        _Cadena_Conexion_Base_Cliente = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        SV = TxtServidor.Text
        PT = TxtPuerto.Text
        BD = TxtBaseDeDatos.Text
        US = TxtUsuario.Text
        PW = TxtClave.Text

        If Trim(PT) <> "" Then
            SV = Trim(SV & "," & PT)
        End If

        _Cadena_Conexion_Base_Cliente = Replace(_Cadena_Conexion_Base_Cliente, "#SV#", SV)
        _Cadena_Conexion_Base_Cliente = Replace(_Cadena_Conexion_Base_Cliente, "#BD#", BD)
        _Cadena_Conexion_Base_Cliente = Replace(_Cadena_Conexion_Base_Cliente, "#US#", US)
        _Cadena_Conexion_Base_Cliente = Replace(_Cadena_Conexion_Base_Cliente, "#PW#", PW)

        Dim _Sql As New Class_SQL(_Cadena_Conexion_Base_Cliente)

        Try

            Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '01'"
            Dim _Row_Config As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            TxtRut.Text = _Row_Config.Item("RUT").ToString.Trim
            TxtRazonSocial.Text = _Row_Config.Item("RAZON").ToString.Trim
            TxtNombreCorto.Text = _Row_Config.Item("NCORTO").ToString.Trim

            TxtDireccion.Text = _Row_Config.Item("DIRECCION").ToString.Trim
            TxtGiro.Text = _Row_Config.Item("GIRO").ToString.Trim
            TxtPais.Text = _Row_Config.Item("PAIS").ToString.Trim
            TxtCiudad.Text = _Row_Config.Item("CIUDAD").ToString.Trim
            TxtTelefonos.Text = _Row_Config.Item("TELEFONOS").ToString.Trim

            Dim Rt = Split(_Row_Config.Item("RUT").ToString.Trim, "-")

            Dim info As New TaskDialogInfo("Conectar con base de datos",
                                         eTaskDialogIcon.ShieldOk,
                                         "CONEXIÓN EXITOSA",
                                         "la conexión con la base de datos resulto exitosa." & vbCrLf & vbCrLf &
                                         "Rut: " & FormatNumber(Rt(0), 0) & "-" & Rt(1) & vbCrLf &
                                         "Empresa: " & TxtRazonSocial.Text,
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

        Dim _Sql As New Class_SQL(_Cadena_Conexion_Base_Cliente)

        Consulta_sql = "Select * From Zw_Empresas Where Rut = '" & TxtRut.Text & "'"

        Dim _Row_Empresa As DataRow = _SQLite.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_Empresa) Then

            If MessageBoxEx.Show(Me, "¿Desea actualizar los datos?", "Esta empresa ya esta registrada",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Consulta_sql = "Update Zw_Empresas Set Servidor = '" & TxtServidor.Text & "'," &
                                                      "Puerto = '" & TxtPuerto.Text & "'," &
                                                      "Usuario = '" & TxtUsuario.Text & "'," &
                                                      "Clave = '" & TxtClave.Text & "'," &
                                                      "BaseDeDatos = '" & TxtBaseDeDatos.Text & "'" & vbCrLf &
                                                      "Where Rut = '" & TxtRut.Text & "'"

                If _SQLite.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar empresa",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Grabar = True
                    Me.Close()

                End If

            Else

                Return

            End If

        Else

            Consulta_sql = "Insert Into Zw_Empresas (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos," &
                           "Servidor,Puerto,Usuario,Clave,BaseDeDatos,Cant_licencias,BaseDeDatos_BakApp) Values " & vbCrLf &
                           "('" & TxtRut.Text & "','" & TxtRazonSocial.Text & "','" & TxtNombreCorto.Text &
                           "','" & TxtDireccion.Text & "','" & TxtGiro.Text & "','" & TxtCiudad.Text &
                           "','" & TxtPais.Text & "','" & TxtTelefonos.Text & "','" & TxtServidor.Text &
                           "','" & TxtPuerto.Text & "','" & TxtUsuario.Text & "','" & TxtClave.Text &
                           "','" & TxtBaseDeDatos.Text & "',0,'" & TxtBaseDeDatosBakApp.Text & "')"

            If _SQLite.Ej_consulta_IDU(Consulta_sql) Then

                MessageBoxEx.Show(Me, "Datos insertados correctamente", "Grabar empresa",
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


End Class