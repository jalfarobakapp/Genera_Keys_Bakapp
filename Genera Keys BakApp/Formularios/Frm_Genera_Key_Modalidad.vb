Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_Genera_Key_Modalidad

    Public _AgregarModalidad As Boolean


    Public _RutEmpresa As String
    Public _NombreEmpresa As String
    Public _Grabar As Boolean
    Public _Cadena_Base As String

    Sub Sb_Actualizar_Grilla()

        Dim _Sql As String

        _Sql = "Select Cod_Modulo,Modulo,0 as Marca" & vbCrLf & _
               "From Zw_Modulos"

        With Grilla

            .DataSource = get_Tablas(_Sql, cn3, 4, _CadenaLocal)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Cod_Modulo").Width = 200
            .Columns("Cod_Modulo").HeaderText = "Código"
            .Columns("Cod_Modulo").Visible = True

            .Columns("Modulo").Width = 180
            .Columns("Modulo").HeaderText = "Modulo"
            .Columns("Modulo").Visible = True

        End With

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _BaseBk = trae_dato(tb, cn1, "BaseDeDatos", "Zw_BakApp", , , 4, _Cadena_Base) & ".dbo."

        If _AgregarModalidad Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Cod_Modulo As String = _Fila.Cells("Cod_Modulo").Value
            Dim _Modulo As String = _Fila.Cells("Modulo").Value

            Dim _Reg As Boolean = CBool(Cuenta_registros("Zw_ModulosXEmpresa", _
                                                         "Rut = '" & _RutEmpresa & "' And Cod_Modulo = '" & _Cod_Modulo & "'", _
                                                         4, _CadenaLocal))

            If _Reg Then

                MessageBoxEx.Show(Me, "Este modulo ya esta vigente para la empresa", "Incorporar modulo", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If MessageBoxEx.Show(Me, "¿Desea eliminar el modulo para volver a hacer gestión?", "Eliminar modulo", _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Consulta_sql = "Delete Zw_ModulosXEmpresa Where Rut = '" & _RutEmpresa & "' And Cod_Modulo = '" & _Cod_Modulo & "'"
                    Ej_consulta_IDU(Consulta_sql, cn3, 4, _CadenaLocal)


                End If

                Return
            Else

                Dim _Llave As String
                Dim _Fecha As Date

                Try
                    _Fecha = InputBox("Ingrese fecha de expiración para el modulo" & vbCrLf & _
                                           "Formatod dd/mm/aaaa", "Fecha de expiración")
                Catch ex As Exception
                    MessageBoxEx.Show(ex.Message)
                    Return
                End Try
                

                Dim _FechaExpiracion As String = Format(_Fecha, "yyyyMMdd")

                _Llave = Encripta_md5(_RutEmpresa & "@" & _Cod_Modulo & "@" & _FechaExpiracion)

                Consulta_sql = "Insert into Zw_ModulosXEmpresa (Rut,Cod_Modulo,Llave,Fecha_Expiracion) Values " & vbCrLf & _
                               "('" & _RutEmpresa & "','" & _Cod_Modulo & "','" & _Llave & "','" & _FechaExpiracion & "')"
                Ej_consulta_IDU(Consulta_sql, cn3, 4, _CadenaLocal)

                Consulta_sql = "Delete " & _BaseBk & "Zw_Licencia_Mod Where Cod_Modulo = '" & _Cod_Modulo & "'" & vbCrLf & _
                               "Insert into " & _BaseBk & "Zw_Licencia_Mod (Cod_Modulo,Modulo,Llave,Fecha_Expiracion) Values " & vbCrLf & _
                               "('" & _Cod_Modulo & "','" & _Modulo & "','" & _Llave & "','" & _FechaExpiracion & "')"

                If Ej_consulta_IDU(Consulta_sql, cn3, 4, _Cadena_Base) Then

                    MessageBoxEx.Show(Me, "Licencia Activa en base del cliente", "Activar licencia", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _Grabar = True
                    Me.Close()
                End If

            End If
        End If

    End Sub

    Private Sub Frm_Genera_Key_Modalidad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub
End Class