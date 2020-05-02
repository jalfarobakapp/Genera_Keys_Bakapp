Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports DevComponents.DotNetBar


Public Class Frm_Genera_Key_Empresa

    Public _Grabar As Boolean
    Public _TblEmpresa As DataRow

    Dim _Base_BakApp As String
    Dim _Cadena_Base As String

    Dim _Servidor, _Puerto, _Usuario, _Clave, _BaseDeDatos As String

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        _Grabar = False
        Me.Close()
    End Sub

    Private Sub Frm_Genera_Key_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ', , , , , , , , Servidor, 
        'Puerto, Usuario, Clave, BaseDeDatos, , 

        TxtRut.Text = _TblEmpresa.Item("Rut")
        TxtRazonSocial.Text = _TblEmpresa.Item("Razon")
        TxtNombreCorto.Text = _TblEmpresa.Item("NombreCorto")
        TxtDireccion.Text = _TblEmpresa.Item("Direccion")
        TxtGiro.Text = _TblEmpresa.Item("Giro")
        DtpFechaExpiracion.Value = NuloPorNro(_TblEmpresa.Item("Fecha_caduca"), Now.Date)
        TxtPais.Text = _TblEmpresa.Item("Pais")
        TxtCiudad.Text = _TblEmpresa.Item("Ciudad")
        TxtTelefonos.Text = _TblEmpresa.Item("Telefonos")

        TxtCant_licencias.Text = _TblEmpresa.Item("Cant_licencias")
        Txt_Llave1.Text = _TblEmpresa.Item("Llave1")
        Txt_Llave2.Text = _TblEmpresa.Item("Llave2")
        Txt_Llave3.Text = _TblEmpresa.Item("Llave3")
        Txt_Llave4.Text = _TblEmpresa.Item("Llave4")

        TxtCant_licencias.Enabled = False
        DtpFechaExpiracion.Enabled = False
        BtnGrabar.Enabled = False
        BtnGenerarKey.Enabled = False

        _Servidor = _TblEmpresa.Item("Servidor")

        _Base_BakApp = _TblEmpresa.Item("BaseDeDatos_BakApp")
        _Puerto = _TblEmpresa.Item("Puerto")

        If Not String.IsNullOrEmpty(Trim(_Puerto)) Then
            _Puerto = "," & _Puerto
        End If


        _Usuario = _TblEmpresa.Item("Usuario")
        _Clave = _TblEmpresa.Item("Clave")
        _BaseDeDatos = _TblEmpresa.Item("BaseDeDatos")

        _Cadena_Base = "data source = " & _Servidor & _Puerto & _
                          "; initial catalog = " & _BaseDeDatos & _
                          "; user id = " & _Usuario & _
                          "; password = " & _Clave & ""


    End Sub

    Private Sub BtnEstaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstaciones.Click

        Dim Fm As New Frm_Lista_UserXEmpresas(_Cadena_Base, _Base_BakApp)
        Fm._NombreEmpresa = TxtRazonSocial.Text
        Fm._RutEmpresa = TxtRut.Text
        Fm.Text = TxtRut.Text & ", " & TxtRazonSocial.Text
        Fm.ShowDialog(Me)

    End Sub


    Private Sub BtnGenerarKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerarKey.Click

        Dim _Licencia As String


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

    Function Fx_Genera_Licencia_BakApp(ByVal _RutEmpresa As String, _
                                       ByVal _FechaCaduca As Date, _
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

        Dim _Fecha As String = Format(DtpFechaExpiracion.Value, "yyyyMMdd")
        Dim _DiasExpira As Integer = DateDiff(DateInterval.Day, Now.Date, DtpFechaExpiracion.Value)

        Dim _Llave1 = Replace(Txt_Llave1.Text, "'", "''")
        Dim _Llave2 = Replace(Txt_Llave2.Text, "'", "''")
        Dim _Llave3 = Replace(Txt_Llave3.Text, "'", "''")
        Dim _Llave4 = Replace(Txt_Llave4.Text, "'", "''")

        Consulta_sql = "Update Zw_Empresas Set  Fecha_caduca = '" & _Fecha & "'" & vbCrLf & _
                       ",Cant_licencias = " & CInt(TxtCant_licencias.Text) & vbCrLf & _
                       ",Llave1 = '" & _Llave1 & "'" & vbCrLf & _
                       ",Llave2 = '" & _Llave2 & "'" & vbCrLf & _
                       ",Llave3 = '" & _Llave3 & "'" & vbCrLf & _
                       ",Llave4 = '" & _Llave4 & "'" & vbCrLf & _
                       "Where Rut = '" & TxtRut.Text & "'"

        Ej_consulta_IDU(Consulta_sql, cn3, 4, _CadenaLocal)

        MessageBoxEx.Show(Me, "Estaciones: " & TxtCant_licencias.Text & vbCrLf & vbCrLf & _
                             "Valida hasta el " & FormatDateTime(DtpFechaExpiracion.Value, DateFormat.LongDate) & vbCrLf & vbCrLf & _
                             "Días que faltan para que expire: " & FormatNumber(_DiasExpira, 0), _
                             "Licencia asignada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MessageBoxEx.Show(Me, "¿Desea actualizar la licencia remotamente al cliente?", "Actualizar licencia remota", _
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Consulta_sql = "Delete [" & _Base_BakApp & "].dbo.Zw_Licencia" & vbCrLf & _
                      "Insert Into [" & _Base_BakApp & "].dbo.Zw_Licencia (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos," & _
                      "Fecha_caduca,Cant_licencias,Llave1,Llave2,Llave3,Llave4,Libre) Values " & vbCrLf & _
                      "('" & TxtRut.Text & "','" & TxtRazonSocial.Text & "','" & TxtNombreCorto.Text & _
                      "','" & TxtDireccion.Text & "','" & TxtGiro.Text & "','" & TxtCiudad.Text & _
                      "','" & TxtPais.Text & "','" & TxtTelefonos.Text & _
                      "','" & Format(DtpFechaExpiracion.Value, "yyyyMMdd") & "'," & TxtCant_licencias.Text & _
                      ",'" & Txt_Llave1.Text & "','" & Txt_Llave2.Text & _
                      "','" & Txt_Llave3.Text & "','" & Txt_Llave4.Text & "',0)"


            If Ej_consulta_IDU(Consulta_sql, cn1, 4, _Cadena_Base) Then

                MessageBoxEx.Show(Me, "Licencia Activa corresctamente en la base del cliente", "Activar licencia", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Grabar = True
                Me.Close()

            End If
        End If
       
       
        ' Ej_consulta_IDU Consulta_sql,





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