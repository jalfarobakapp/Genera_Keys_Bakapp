Imports DevComponents.DotNetBar
'Imports System.IO
'Imports System.Data.SqlClient

Public Class Frm_Lista_UserXEmpresas


    Dim _SQLite As Class_SQLite
    Dim Consulta_sql As String
    Dim _Base_SQlLite_Local As String = Application.StartupPath & "\Db\" & "Genera_Keys_BakApp.db"

    Dim _Row_Empresa As DataRow

    Dim _Cadena_Conexion_Base_Cliente As String
    Dim _Base_BakApp As String

    Public Sub New(Row_Empresa As DataRow,
                   Cadena_Conexion_Base_Cliente As String,
                   Base_BakApp As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Cadena_Conexion_Base_Cliente = Cadena_Conexion_Base_Cliente
        _Base_BakApp = Base_BakApp
        _Row_Empresa = Row_Empresa

        _SQLite = New Class_SQLite(_Base_SQlLite_Local)

        Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, True, False)

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Rut = _Row_Empresa.Item("Rut")

        Consulta_sql = "Select * From Zw_PcXEmpresa Where Rut = '" & _Rut & "'"
        Dim _Tbl As DataTable = _SQLite.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Estacion_trabajo").Width = 200
            .Columns("Estacion_trabajo").HeaderText = "Estación de trabajo"
            .Columns("Estacion_trabajo").Visible = True

            .Columns("Llave").Width = 180
            .Columns("Llave").HeaderText = "Llave"
            .Columns("Llave").Visible = True

            .Columns("Fecha_Activacion").Width = 100
            .Columns("Fecha_Activacion").HeaderText = "Fecha vigencia"
            .Columns("Fecha_Activacion").Visible = True

        End With

    End Sub

    Private Sub Frm_Lista_UserXEmpresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        Dim Fm As New Frm_Genera_Key_Usuarios(_Cadena_Conexion_Base_Cliente, _Base_BakApp)
        Fm.TxtRut.Text = _Row_Empresa.Item("Rut")
        Fm.TxtNombreEmpresa.Text = _Row_Empresa.Item("Razon")
        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class