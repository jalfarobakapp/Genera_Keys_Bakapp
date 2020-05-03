Imports DevComponents.DotNetBar
Imports System.IO

Public Class Frm_Genera_Key_Usuarios

    Dim _Grabar As Boolean

    Dim _SQLite As Class_SQLite
    Dim Consulta_sql As String
    Dim _Base_SQlLite_Local As String = Application.StartupPath & "\Db\" & "Genera_Keys_BakApp.db"

    Dim _Cadena_Conexion_Base_Cliente As String
    Dim _Base_BakApp As String
    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(ByVal Cadena_Conexion_Base_Cliente As String, _
                   ByVal Base_BakApp As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cadena_Conexion_Base_Cliente = Cadena_Conexion_Base_Cliente
        _Base_BakApp = Base_BakApp

        _SQLite = New Class_SQLite(_Base_SQlLite_Local)

    End Sub

    Private Sub Frm_Genera_Key_Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = TxtNombreEstacion
    End Sub
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        Dim _Cadena As String = UCase(Trim(TxtRut.Text) & "@" & TxtNombreEstacion.Text)
        TxtKeyLicencia.Text = Encripta_md5(_Cadena)

    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim _NombreEquipo As String = Trim(TxtNombreEstacion.Text)

        Dim _Class_SQL_Base_Cliente As New Class_SQL(_Cadena_Conexion_Base_Cliente)
        'Dim _Class_SQL_Mibase As New Class_SQL(_CadenaLocal)

        Dim _Reg As Boolean = CBool(Cuenta_registros("Zw_PcXEmpresa",
                    "Rut = '" & Trim(TxtRut.Text) & "' And Estacion_trabajo = '" & Trim(TxtNombreEstacion.Text) & "'",
                    4, _CadenaLocal))

        '_Reg = _SQLite.c


        If _Reg Then

            MessageBoxEx.Show(Me, "Esta estación de trabajo ya se encuentra registrada en el sistema",
                                 "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Consulta_sql = "Select Top 1 * From " & _Base_BakApp & ".dbo.Zw_EstacionesBkp" & vbCrLf &
                           "Where NombreEquipo = '" & _NombreEquipo & "'"

            Dim _TblRegCliente As DataTable = _Class_SQL_Base_Cliente.Fx_Get_Tablas(Consulta_sql)

            If Not CBool(_TblRegCliente.Rows.Count) Then

                If MessageBoxEx.Show(Me, "¿Desea registrar en la base del cliente?",
                                     "Registrar en base del cliente",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "INSERT INTO " & _Base_BakApp & ".dbo.Zw_EstacionesBkp (NombreEquipo,TipoEstacion,KeyReg) VALUES" & vbCrLf &
                                   "('" & _NombreEquipo & "','N','" & Trim(TxtKeyLicencia.Text) & "')"

                    If _Class_SQL_Base_Cliente.Ej_consulta_IDU(Consulta_sql) Then
                        MessageBoxEx.Show(Me, "Estación de trabajo registrada correctamente en la base del cliente", "Grabar equipo por empresa",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If
            End If



        Else

            Consulta_sql = "Insert Into Zw_PcXEmpresa (Rut,Estacion_trabajo,Llave,Fecha_Activacion) Values " & vbCrLf &
                           "('" & Trim(TxtRut.Text) & "','" & _NombreEquipo &
                           "','" & Trim(TxtKeyLicencia.Text) & "','" & Format(Now.Date, "yyyyMMdd") & "')"

            If _SQLite.Ej_consulta_IDU(Consulta_sql) Then ' _Class_SQL_Mibase.Ej_consulta_IDU(Consulta_sql) Then

                If MessageBoxEx.Show(Me, "Estación de trabajo registrada correctamente" & vbCrLf &
                                     "¿Desea registrarla inmediatamente en el equipo del cliente?",
                                     "Registrar usuario",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Insert Into [" & _Base_BakApp & "].dbo.Zw_EstacionesBkp (NombreEquipo,TipoEstacion,KeyReg) Values" & vbCrLf &
                                   "('" & _NombreEquipo & "','N','" & Trim(TxtKeyLicencia.Text) & "')"

                    If _Class_SQL_Base_Cliente.Ej_consulta_IDU(Consulta_sql) Then
                        MessageBoxEx.Show(Me, "Estación de trabajo registrada correctamente en la base del cliente", "Grabar equipo por empresa",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                _Grabar = True
                Me.Close()

            End If

        End If

    End Sub

End Class