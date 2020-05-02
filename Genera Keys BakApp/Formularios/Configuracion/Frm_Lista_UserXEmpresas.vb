Imports DevComponents.DotNetBar
'Imports System.IO
'Imports System.Data.SqlClient

Public Class Frm_Lista_UserXEmpresas

    Public _RutEmpresa As String
    Public _NombreEmpresa As String

    Dim _Class_SQL_Mibase As New Class_SQL(_CadenaLocal)

    Dim _Cadena_Conexion_Base_Cliente As String
    Dim _Base_BakApp As String

    Public Sub New(ByVal Cadena_Conexion_Base_Cliente As String, _
                   ByVal Base_BakApp As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Cadena_Conexion_Base_Cliente = Cadena_Conexion_Base_Cliente
        _Base_BakApp = Base_BakApp

    End Sub

    Sub Sb_Actualizar_Grilla()

        Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, True, False)

        Consulta_sql = "Select *,CONVERT(VARCHAR, Fecha_Activacion, 103) Fecha From Zw_PcXEmpresa" & vbCrLf & _
                   "Where Rut = '" & _RutEmpresa & "'"

        With Grilla

            .DataSource = _Class_SQL_Mibase.Fx_Get_Tablas(Consulta_sql) 'get_Tablas(_Sql, cn3, 4, _CadenaLocal)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Estacion_trabajo").Width = 200
            .Columns("Estacion_trabajo").HeaderText = "Estación de trabajo"
            .Columns("Estacion_trabajo").Visible = True

            .Columns("Llave").Width = 180
            .Columns("Llave").HeaderText = "Llave"
            .Columns("Llave").Visible = True

            .Columns("Fecha").Width = 100
            .Columns("Fecha").HeaderText = "Fecha vigencia"
            .Columns("Fecha").Visible = True

        End With

        'MarcarGrilla()

    End Sub

    Private Sub Frm_Lista_UserXEmpresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        Dim Fm As New Frm_Genera_Key_Usuarios(_Cadena_Conexion_Base_Cliente, _Base_BakApp)
        Fm.TxtRut.Text = _RutEmpresa
        Fm.TxtNombreEmpresa.Text = _NombreEmpresa
        Fm.ShowDialog(Me)
        If Fm._Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

    End Sub

End Class