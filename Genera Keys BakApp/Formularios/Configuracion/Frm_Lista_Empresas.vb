Imports DevComponents.DotNetBar

Public Class Frm_Lista_Empresas

    Dim _SQLite As Class_SQLite
    Dim Consulta_sql As String
    Dim _Base_SQlLite_Local As String = Application.StartupPath & "\Db\" & "Genera_Keys_BakApp.db"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _SQLite = New Class_SQLite(_Base_SQlLite_Local)

    End Sub

    Private Sub Frm_Lista_Empresas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim _Existe = System.IO.File.Exists(_Base_SQlLite_Local)

        If _Existe Then
            Sb_Actualizar_Grilla()
        Else
            MessageBoxEx.Show(Me, "No existe archivo de base de datos Genera_Keys_BakApp.db en la Ruta:" & vbCrLf &
                              _Base_SQlLite_Local, "Base de datos no existe", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Sub Sb_Actualizar_Grilla()

        Try
            Consulta_sql = "Select * From Zw_Empresas"
            Dim _Tbl As DataTable = _SQLite.Fx_Get_Tablas(Consulta_sql)

            With Grilla

                .DataSource = _Tbl 'get_Tablas(_Sql, cn3, 4, _CadenaLocal)

                OcultarEncabezadoGrilla(Grilla, True)

                .Columns("Rut").Width = 80
                .Columns("Rut").HeaderText = "Rut"
                .Columns("Rut").Visible = True

                .Columns("Razon").Width = 380
                .Columns("Razon").HeaderText = "Empresa"
                .Columns("Razon").Visible = True

                .Columns("Cant_licencias").Width = 60
                .Columns("Cant_licencias").HeaderText = "Licencias"
                .Columns("Cant_licencias").Visible = True

                .Columns("Fecha_caduca").Width = 100
                .Columns("Fecha_caduca").HeaderText = "Fecha"
                .Columns("Fecha_caduca").Visible = True

            End With
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Sub MarcarGrilla()
        With Grilla
            Dim Contador As Integer
            For Each row As DataGridViewRow In .Rows
                If .Rows(Contador).Cells("TipoConexion").Value <> "SqlServer" Then
                    .Rows(Contador).Visible = False
                End If
                Contador += 1
            Next
        End With
    End Sub

    Private Sub BtnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregar.Click

        Sb_Actualizar_Grilla()

        Dim Fm As New Frm_Conectar
        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _RutFila As String = _Fila.Cells("Rut").Value
        Dim _RazonFila As String = _Fila.Cells("Razon").Value

        Consulta_sql = "Select * From Zw_Empresas Where Rut = '" & _RutFila & "'"
        Consulta_sql = "Select * From Zw_Empresas Where Id = " & _Id
        Dim _FilaR As DataRow = _SQLite.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_Genera_Key_Empresa
        Fm.Row_Empresa = _FilaR
        Fm.Text = _RutFila & ", " & _RazonFila
        Fm.ShowDialog(Me)
        If Fm.Grabar Then Sb_Actualizar_Grilla()
        Fm.Dispose()

    End Sub

    Private Sub Btn_Raiz_Click(sender As Object, e As EventArgs) Handles Btn_Raiz.Click
        Dim _Temporales = Application.StartupPath
        Shell("explorer.exe " & _Temporales, AppWinStyle.NormalFocus)
    End Sub

End Class