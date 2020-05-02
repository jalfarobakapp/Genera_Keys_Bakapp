

Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_Lista_ModXEmpresas

    Public _RutEmpresa As String
    Public _NombreEmpresa As String

    Public _Cadena_Base As String

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub Sb_Actualizar_Grilla()


        Dim _Sql = "Select  Rut,Cod_Modulo,(Select top 1 Modulo From" & vbCrLf & _
                   "Zw_Modulos Zm Where Zm.Cod_Modulo = Zmm.Cod_Modulo) As Modulo,Llave,CONVERT(VARCHAR, Fecha_Expiracion, 103) Fecha" & vbCrLf & _
                   "From Zw_ModulosXEmpresa Zmm" & vbCrLf & _
                   "Where Rut = '" & _RutEmpresa & "'"

        With Grilla

            .DataSource = get_Tablas(_Sql, cn3, 4, _CadenaLocal)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("Modulo").Width = 200
            .Columns("Modulo").HeaderText = "Modulo"
            .Columns("Modulo").Visible = True

            .Columns("Llave").Width = 200
            .Columns("Llave").HeaderText = "Llave"
            .Columns("Llave").Visible = True

            .Columns("Fecha").Width = 100
            .Columns("Fecha").HeaderText = "Fecha"
            .Columns("Fecha").Visible = True

        End With


    End Sub

    Private Sub BtnxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnxSalir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Lista_ModXEmpresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click

        Dim Fm As New Frm_Genera_Key_Modalidad
        Fm._Cadena_Base = _Cadena_Base
        Fm._RutEmpresa = _RutEmpresa
        Fm._AgregarModalidad = True
        Fm.ShowDialog(Me)

        If Fm._Grabar Then Sb_Actualizar_Grilla()

    End Sub


End Class

