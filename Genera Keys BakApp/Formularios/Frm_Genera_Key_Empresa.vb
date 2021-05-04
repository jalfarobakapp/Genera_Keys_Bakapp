Imports System.Globalization
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports DevComponents.DotNetBar


Public Class Frm_Genera_Key_Empresa

    Dim _Grabar As Boolean
    Dim _Row_Empresa As DataRow

    Dim _Base_BakApp As String
    Dim _Cadena_Base As String

    Dim _Servidor, _Puerto, _Usuario, _Clave, _BaseDeDatos As String

    Dim _SQLite As Class_SQLite
    Dim Consulta_sql As String
    Dim _Base_SQlLite_Local As String = Application.StartupPath & "\Db\" & "Genera_Keys_BakApp.db"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _SQLite = New Class_SQLite(_Base_SQlLite_Local)

    End Sub

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Row_Empresa As DataRow
        Get
            Return _Row_Empresa
        End Get
        Set(value As DataRow)
            _Row_Empresa = value
        End Set
    End Property

    Private Sub Frm_Genera_Key_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ', , , , , , , , Servidor, 
        'Puerto, Usuario, Clave, BaseDeDatos, , 

        TxtRut.Text = _Row_Empresa.Item("Rut")
        TxtRazonSocial.Text = _Row_Empresa.Item("Razon")
        TxtNombreCorto.Text = _Row_Empresa.Item("NombreCorto")
        TxtDireccion.Text = _Row_Empresa.Item("Direccion")
        TxtGiro.Text = _Row_Empresa.Item("Giro")

        '        Convert.ToDateTime(cadenastring)
        '        Tambien puedes probar con
        'DateTime.Parse(cadenastring)

        Dim _Fecha_caduca As String = NuloPorNro(_Row_Empresa.Item("Fecha_caduca"), Now.Date)

        If String.IsNullOrEmpty(_Fecha_caduca) Then
            _Fecha_caduca = Now.Date
        End If

        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        'Dim expenddt As Date
        Date.TryParseExact(_Fecha_caduca, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, DtpFechaExpiracion.Value)

        'DtpFechaExpiracion.Value = Convert.ToDateTime(_F)

        TxtPais.Text = _Row_Empresa.Item("Pais")
        TxtCiudad.Text = _Row_Empresa.Item("Ciudad")
        TxtTelefonos.Text = _Row_Empresa.Item("Telefonos")

        TxtCant_licencias.Text = _Row_Empresa.Item("Cant_licencias")
        Txt_Llave1.Text = _Row_Empresa.Item("Llave1")
        Txt_Llave2.Text = _Row_Empresa.Item("Llave2")
        Txt_Llave3.Text = _Row_Empresa.Item("Llave3")
        Txt_Llave4.Text = _Row_Empresa.Item("Llave4")

        TxtCant_licencias.Enabled = False
        DtpFechaExpiracion.Enabled = False
        BtnGrabar.Enabled = False
        BtnGenerarKey.Enabled = False

        _Servidor = _Row_Empresa.Item("Servidor")

        _Base_BakApp = _Row_Empresa.Item("BaseDeDatos_BakApp")
        _Puerto = _Row_Empresa.Item("Puerto")

        If Not String.IsNullOrEmpty(Trim(_Puerto)) Then
            _Puerto = "," & _Puerto
        End If


        _Usuario = _Row_Empresa.Item("Usuario")
        _Clave = _Row_Empresa.Item("Clave")
        _BaseDeDatos = _Row_Empresa.Item("BaseDeDatos")

        _Cadena_Base = "data source = " & _Servidor & _Puerto &
                          "; initial catalog = " & _BaseDeDatos &
                          "; user id = " & _Usuario &
                          "; password = " & _Clave & ""


    End Sub

    Private Sub BtnEstaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstaciones.Click

        Dim Fm As New Frm_Lista_UserXEmpresas(_Row_Empresa, _Cadena_Base, _Base_BakApp)
        Fm.Text = TxtRut.Text & ", " & TxtRazonSocial.Text
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub BtnGenerarKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerarKey.Click

        If DtpFechaExpiracion.Value < Now.Date Then
            MessageBoxEx.Show(Me, "La fecha no puede ser menor que la fecha de hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            DtpFechaExpiracion.Focus()
            Return
        End If

        If Not CBool(CInt(Val(TxtCant_licencias.Text))) Then
            MessageBoxEx.Show(Me, "Falta cantidad de licencias", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TxtCant_licencias.Focus()
            Return
        End If

        Dim _LLaves = Fx_Genera_Licencia_BakApp(TxtRut.Text, DtpFechaExpiracion.Value, TxtCant_licencias.Text, "b4s1ng4")

        Txt_Llave1.Text = _LLaves(0)
        Txt_Llave2.Text = _LLaves(1)
        Txt_Llave3.Text = _LLaves(2)
        Txt_Llave4.Text = _LLaves(3)

        '_Licencia += TxtRut.Text & "@"
        '_Licencia += Format(DtpFechaExpiracion.Value, "yyyyMMdd") & "@"
        '_Licencia += TxtCant_licencias.Text

        'Dim _Lc = UCase(Fx_Encriptar(_Licencia, "ARDILLA."))
        'Dim _Md5 = Encripta_md5("ARDILLA." & TxtRut.Text & Format(DtpFechaExpiracion.Value, "yyyyMMdd") & TxtCant_licencias.Text)

        'Txt_Llave1.Text = _Lc ' Fx_Generar_Llave(_Lc)
        'Txt_Llave2.Text = _Md5


        TxtCant_licencias.Enabled = False
        DtpFechaExpiracion.Enabled = False

        BtnGenerarKey.Enabled = False
        BtnGrabar.Enabled = True

        Beep()

    End Sub

    Private Sub Btn_Exportar_Licencia_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Licencia.Click

        Consulta_sql = "Select * From Zw_Empresas Where Rut = '" & TxtRut.Text & "'"
        Dim _Ds As DataSet = _SQLite.Fx_Get_DataSet(Consulta_sql)

        Dim _Ruta_Licencia = Application.StartupPath & "\Licencias"

        If Not Directory.Exists(_Ruta_Licencia) Then
            System.IO.Directory.CreateDirectory(_Ruta_Licencia)
        End If

        _Ruta_Licencia += "\" & Replace(TxtRazonSocial.Text.ToString.Trim, " ", "_")

        _Ds.WriteXml(_Ruta_Licencia, XmlWriteMode.IgnoreSchema)

        ToastNotification.Show(Me, "Archivo Xml guardado correctamente" & Environment.NewLine &
                               "Ruta esta en el portapapeles", Nothing,
                                        3 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        Clipboard.SetText(_Ruta_Licencia)

    End Sub

    Function Fx_Genera_Licencia_BakApp(ByVal _RutEmpresa As String,
                                       ByVal _FechaCaduca As Date,
                                       ByVal _CantLicencias As Integer, ByVal _Palabra_X As String) As String()

        Dim _Llave1, _Llave2, _Llave3, _Llave4 As String

        _Llave1 = Encripta_md5(Trim(_RutEmpresa) & _Palabra_X)
        _Llave2 = Encripta_md5(Format(_FechaCaduca, "yyyyMMdd"))
        _Llave3 = Encripta_md5(_CantLicencias & _Palabra_X)
        _Llave4 = Encripta_md5(_Llave1 & _Llave2 & _Llave3 & _Palabra_X)

        Dim Licencia(3) As String

        Licencia(0) = _Llave1
        Licencia(1) = _Llave2
        Licencia(2) = _Llave3
        Licencia(3) = _Llave4

        Return Licencia

    End Function

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim _Fecha As String = Format(DtpFechaExpiracion.Value, "dd-MM-yyyy")
        Dim _DiasExpira As Integer = DateDiff(DateInterval.Day, Now.Date, DtpFechaExpiracion.Value)

        Dim _Llave1 = Replace(Txt_Llave1.Text, "'", "''")
        Dim _Llave2 = Replace(Txt_Llave2.Text, "'", "''")
        Dim _Llave3 = Replace(Txt_Llave3.Text, "'", "''")
        Dim _Llave4 = Replace(Txt_Llave4.Text, "'", "''")

        Consulta_sql = "Update Zw_Empresas Set  Fecha_caduca = '" & _Fecha & "'" & vbCrLf &
                       ",Cant_licencias = " & CInt(TxtCant_licencias.Text) & vbCrLf &
                       ",Llave1 = '" & _Llave1 & "'" & vbCrLf &
                       ",Llave2 = '" & _Llave2 & "'" & vbCrLf &
                       ",Llave3 = '" & _Llave3 & "'" & vbCrLf &
                       ",Llave4 = '" & _Llave4 & "'" & vbCrLf &
                       "Where Rut = '" & TxtRut.Text & "'"

        If _SQLite.Ej_consulta_IDU(Consulta_sql) Then

            MessageBoxEx.Show(Me, "Estaciones: " & TxtCant_licencias.Text & vbCrLf & vbCrLf &
                             "Valida hasta el " & FormatDateTime(DtpFechaExpiracion.Value, DateFormat.LongDate) & vbCrLf & vbCrLf &
                             "Días que faltan para que expire: " & FormatNumber(_DiasExpira, 0),
                             "Licencia asignada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If MessageBoxEx.Show(Me, "¿Desea actualizar la licencia remotamente al cliente?", "Actualizar licencia remota",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim _Sql As New Class_SQL(_Cadena_Base)

                Consulta_sql = "Delete [" & _Base_BakApp & "].dbo.Zw_Licencia" & vbCrLf &
                      "Insert Into [" & _Base_BakApp & "].dbo.Zw_Licencia (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos," &
                      "Fecha_caduca,Cant_licencias,Llave1,Llave2,Llave3,Llave4,Libre) Values " & vbCrLf &
                      "('" & TxtRut.Text & "','" & TxtRazonSocial.Text & "','" & TxtNombreCorto.Text &
                      "','" & TxtDireccion.Text & "','" & TxtGiro.Text & "','" & TxtCiudad.Text &
                      "','" & TxtPais.Text & "','" & TxtTelefonos.Text &
                      "','" & Format(DtpFechaExpiracion.Value, "yyyyMMdd") & "'," & TxtCant_licencias.Text &
                      ",'" & Txt_Llave1.Text & "','" & Txt_Llave2.Text &
                      "','" & Txt_Llave3.Text & "','" & Txt_Llave4.Text & "',0)"

                If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                    MessageBoxEx.Show(Me, "Licencia Activa corresctamente en la base del cliente", "Activar licencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If

            _Grabar = True
            Me.Close()

        End If

    End Sub

    Private Sub BtnCambiarLicencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambiarLicencia.Click

        TxtCant_licencias.Enabled = True
        DtpFechaExpiracion.Enabled = True

        Txt_Llave1.Text = String.Empty
        Txt_Llave2.Text = String.Empty
        Txt_Llave3.Text = String.Empty
        Txt_Llave4.Text = String.Empty

        BtnGenerarKey.Enabled = True

    End Sub

    Private Sub BtnModalidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModalidades.Click

        Dim Fm As New Frm_Lista_ModXEmpresas
        Fm._RutEmpresa = TxtRut.Text
        Fm.Text = "Modulos empresa: " & TxtRazonSocial.Text
        Fm._Cadena_Base = _Cadena_Base
        Fm.ShowDialog(Me)

    End Sub

End Class