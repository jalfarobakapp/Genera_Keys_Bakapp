Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_Lista_Empresas

    Dim Directorio As String = Application.StartupPath & "\Data\"
    
    Private Sub Frm_Lista_Empresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Conectar_SQL("JALFARO-PC\SQL_2008_R2", "BAKAPP", "BAKAPP", "BAKAPP", cn3)
        Sb_Actualizar_Grilla()


    End Sub


    Sub Sb_Actualizar_Grilla()


        Dim _Sql = "Select *,CONVERT(VARCHAR, Fecha_caduca, 103) Fecha From Zw_Empresas"

        With Grilla

            .DataSource = get_Tablas(_Sql, cn3, 4, _CadenaLocal)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Rut").Width = 80
            .Columns("Rut").HeaderText = "Rut"
            .Columns("Rut").Visible = True

            .Columns("Razon").Width = 230
            .Columns("Razon").HeaderText = "Empresa"
            .Columns("Razon").Visible = True

            .Columns("Cant_licencias").Width = 50
            .Columns("Cant_licencias").HeaderText = "Licencias"
            .Columns("Cant_licencias").Visible = True

            .Columns("Fecha").Width = 100
            .Columns("Fecha").HeaderText = "Nro Licencia"
            .Columns("Fecha").Visible = True

        End With

        'MarcarGrilla()

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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim Fm As New Frm_Conectar
        Fm.ShowDialog(Me)

        If Fm._Grabar Then Sb_Actualizar_Grilla()

    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        End
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _RutFila As String = _Fila.Cells("Rut").Value
        Dim _RazonFila As String = _Fila.Cells("Razon").Value

        Consulta_sql = "Select * From Zw_Empresas Where Rut = '" & _RutFila & "'"

        Dim _TblEmpresa As DataTable = get_Tablas(Consulta_sql, cn3, 4, _CadenaLocal)
        Dim _FilaR As DataRow = _TblEmpresa.Rows(0)

        Dim Fm As New Frm_Genera_Key_Empresa
        Fm._TblEmpresa = _FilaR

        Fm.Text = _RutFila & ", " & _RazonFila
        Fm.ShowDialog(Me)

        If Fm._Grabar Then Sb_Actualizar_Grilla()

    End Sub
End Class