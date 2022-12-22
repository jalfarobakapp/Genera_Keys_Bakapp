<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Conectar
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Conectar))
        Me.TxtBaseDeDatos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPuerto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtServidor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnConectar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonItem()
        Me.GrupoConexion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtBaseDeDatosBakApp = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtTelefonos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPais = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtGiro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtRut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNombreCorto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDireccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoConexion.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtBaseDeDatos
        '
        Me.TxtBaseDeDatos.BackColor = System.Drawing.Color.White
        Me.TxtBaseDeDatos.ForeColor = System.Drawing.Color.Black
        Me.TxtBaseDeDatos.Location = New System.Drawing.Point(118, 115)
        Me.TxtBaseDeDatos.Name = "TxtBaseDeDatos"
        Me.TxtBaseDeDatos.Size = New System.Drawing.Size(207, 22)
        Me.TxtBaseDeDatos.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Base de datos"
        '
        'TxtClave
        '
        Me.TxtClave.BackColor = System.Drawing.Color.White
        Me.TxtClave.ForeColor = System.Drawing.Color.Black
        Me.TxtClave.Location = New System.Drawing.Point(118, 87)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(207, 22)
        Me.TxtClave.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(7, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Clave"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BackColor = System.Drawing.Color.White
        Me.TxtUsuario.ForeColor = System.Drawing.Color.Black
        Me.TxtUsuario.Location = New System.Drawing.Point(118, 60)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(207, 22)
        Me.TxtUsuario.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'TxtPuerto
        '
        Me.TxtPuerto.BackColor = System.Drawing.Color.White
        Me.TxtPuerto.ForeColor = System.Drawing.Color.Black
        Me.TxtPuerto.Location = New System.Drawing.Point(118, 32)
        Me.TxtPuerto.Name = "TxtPuerto"
        Me.TxtPuerto.Size = New System.Drawing.Size(207, 22)
        Me.TxtPuerto.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Puerto"
        '
        'TxtServidor
        '
        Me.TxtServidor.BackColor = System.Drawing.Color.White
        Me.TxtServidor.ForeColor = System.Drawing.Color.Black
        Me.TxtServidor.Location = New System.Drawing.Point(118, 3)
        Me.TxtServidor.Name = "TxtServidor"
        Me.TxtServidor.Size = New System.Drawing.Size(207, 22)
        Me.TxtServidor.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnConectar, Me.BtnGrabar, Me.BtnLimpiar})
        Me.Bar1.Location = New System.Drawing.Point(0, 542)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(534, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 34
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnConectar
        '
        Me.BtnConectar.ForeColor = System.Drawing.Color.Black
        Me.BtnConectar.Image = CType(resources.GetObject("BtnConectar.Image"), System.Drawing.Image)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Tooltip = "Conectar"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar conexión"
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Tooltip = "Limpiar"
        '
        'GrupoConexion
        '
        Me.GrupoConexion.BackColor = System.Drawing.Color.White
        Me.GrupoConexion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GrupoConexion.Controls.Add(Me.TxtBaseDeDatosBakApp)
        Me.GrupoConexion.Controls.Add(Me.Label6)
        Me.GrupoConexion.Controls.Add(Me.TxtBaseDeDatos)
        Me.GrupoConexion.Controls.Add(Me.TxtServidor)
        Me.GrupoConexion.Controls.Add(Me.Label5)
        Me.GrupoConexion.Controls.Add(Me.Label1)
        Me.GrupoConexion.Controls.Add(Me.TxtClave)
        Me.GrupoConexion.Controls.Add(Me.Label2)
        Me.GrupoConexion.Controls.Add(Me.Label4)
        Me.GrupoConexion.Controls.Add(Me.TxtPuerto)
        Me.GrupoConexion.Controls.Add(Me.TxtUsuario)
        Me.GrupoConexion.Controls.Add(Me.Label3)
        Me.GrupoConexion.DisabledBackColor = System.Drawing.Color.Empty
        Me.GrupoConexion.Location = New System.Drawing.Point(12, 12)
        Me.GrupoConexion.Name = "GrupoConexion"
        Me.GrupoConexion.Size = New System.Drawing.Size(341, 212)
        '
        '
        '
        Me.GrupoConexion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GrupoConexion.Style.BackColorGradientAngle = 90
        Me.GrupoConexion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GrupoConexion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoConexion.Style.BorderBottomWidth = 1
        Me.GrupoConexion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GrupoConexion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoConexion.Style.BorderLeftWidth = 1
        Me.GrupoConexion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoConexion.Style.BorderRightWidth = 1
        Me.GrupoConexion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GrupoConexion.Style.BorderTopWidth = 1
        Me.GrupoConexion.Style.CornerDiameter = 4
        Me.GrupoConexion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GrupoConexion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GrupoConexion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GrupoConexion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GrupoConexion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GrupoConexion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GrupoConexion.TabIndex = 37
        Me.GrupoConexion.Text = "Datos de conexión"
        '
        'TxtBaseDeDatosBakApp
        '
        Me.TxtBaseDeDatosBakApp.BackColor = System.Drawing.Color.White
        Me.TxtBaseDeDatosBakApp.ForeColor = System.Drawing.Color.Black
        Me.TxtBaseDeDatosBakApp.Location = New System.Drawing.Point(118, 164)
        Me.TxtBaseDeDatosBakApp.Name = "TxtBaseDeDatosBakApp"
        Me.TxtBaseDeDatosBakApp.Size = New System.Drawing.Size(207, 22)
        Me.TxtBaseDeDatosBakApp.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(7, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Base BakApp"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TxtTelefonos)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.TxtCiudad)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.TxtPais)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.TxtGiro)
        Me.GroupPanel2.Controls.Add(Me.TxtRut)
        Me.GroupPanel2.Controls.Add(Me.TxtNombreCorto)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.TxtRazonSocial)
        Me.GroupPanel2.Controls.Add(Me.LabelX16)
        Me.GroupPanel2.Controls.Add(Me.TxtDireccion)
        Me.GroupPanel2.Controls.Add(Me.LabelX14)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 250)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(508, 286)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 38
        Me.GroupPanel2.Text = "Datos de la empresa"
        '
        'TxtTelefonos
        '
        Me.TxtTelefonos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTelefonos.Border.Class = "TextBoxBorder"
        Me.TxtTelefonos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefonos.DisabledBackColor = System.Drawing.Color.White
        Me.TxtTelefonos.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTelefonos.FocusHighlightEnabled = True
        Me.TxtTelefonos.ForeColor = System.Drawing.Color.Black
        Me.TxtTelefonos.Location = New System.Drawing.Point(307, 229)
        Me.TxtTelefonos.Name = "TxtTelefonos"
        Me.TxtTelefonos.Size = New System.Drawing.Size(181, 22)
        Me.TxtTelefonos.TabIndex = 66
        Me.TxtTelefonos.WatermarkText = "Largo max. 13"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(307, 209)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(134, 23)
        Me.LabelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX5.TabIndex = 67
        Me.LabelX5.Text = "Teléfonos"
        '
        'TxtCiudad
        '
        Me.TxtCiudad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCiudad.Border.Class = "TextBoxBorder"
        Me.TxtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad.DisabledBackColor = System.Drawing.Color.White
        Me.TxtCiudad.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtCiudad.FocusHighlightEnabled = True
        Me.TxtCiudad.ForeColor = System.Drawing.Color.Black
        Me.TxtCiudad.Location = New System.Drawing.Point(101, 229)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(200, 22)
        Me.TxtCiudad.TabIndex = 64
        Me.TxtCiudad.WatermarkText = "Largo max. 13"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(101, 209)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(89, 23)
        Me.LabelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX3.TabIndex = 65
        Me.LabelX3.Text = "Ciudad"
        '
        'TxtPais
        '
        Me.TxtPais.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtPais.Border.Class = "TextBoxBorder"
        Me.TxtPais.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPais.DisabledBackColor = System.Drawing.Color.White
        Me.TxtPais.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPais.FocusHighlightEnabled = True
        Me.TxtPais.ForeColor = System.Drawing.Color.Black
        Me.TxtPais.Location = New System.Drawing.Point(6, 229)
        Me.TxtPais.Name = "TxtPais"
        Me.TxtPais.Size = New System.Drawing.Size(89, 22)
        Me.TxtPais.TabIndex = 62
        Me.TxtPais.WatermarkText = "Largo max. 13"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(6, 209)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 63
        Me.LabelX2.Text = "Pais"
        '
        'TxtGiro
        '
        Me.TxtGiro.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtGiro.Border.Class = "TextBoxBorder"
        Me.TxtGiro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtGiro.DisabledBackColor = System.Drawing.Color.White
        Me.TxtGiro.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtGiro.FocusHighlightEnabled = True
        Me.TxtGiro.ForeColor = System.Drawing.Color.Black
        Me.TxtGiro.Location = New System.Drawing.Point(6, 181)
        Me.TxtGiro.Name = "TxtGiro"
        Me.TxtGiro.Size = New System.Drawing.Size(482, 22)
        Me.TxtGiro.TabIndex = 53
        Me.TxtGiro.WatermarkText = "Griro (Largo Max. 100 caracteres)"
        '
        'TxtRut
        '
        Me.TxtRut.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRut.Border.Class = "TextBoxBorder"
        Me.TxtRut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRut.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRut.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRut.FocusHighlightEnabled = True
        Me.TxtRut.ForeColor = System.Drawing.Color.Black
        Me.TxtRut.Location = New System.Drawing.Point(6, 23)
        Me.TxtRut.Name = "TxtRut"
        Me.TxtRut.Size = New System.Drawing.Size(140, 22)
        Me.TxtRut.TabIndex = 50
        Me.TxtRut.WatermarkText = "Largo max. 13"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreCorto.Border.Class = "TextBoxBorder"
        Me.TxtNombreCorto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreCorto.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreCorto.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtNombreCorto.FocusHighlightEnabled = True
        Me.TxtNombreCorto.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreCorto.Location = New System.Drawing.Point(212, 23)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.Size = New System.Drawing.Size(276, 22)
        Me.TxtNombreCorto.TabIndex = 60
        Me.TxtNombreCorto.WatermarkText = "Largo max. 13"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(212, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 61
        Me.LabelX1.Text = "Nombre corto"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(6, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 23)
        Me.LabelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX4.TabIndex = 56
        Me.LabelX4.Text = "Rut"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRazonSocial.Border.Class = "TextBoxBorder"
        Me.TxtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazonSocial.DisabledBackColor = System.Drawing.Color.White
        Me.TxtRazonSocial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtRazonSocial.FocusHighlightEnabled = True
        Me.TxtRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.TxtRazonSocial.Location = New System.Drawing.Point(6, 74)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(482, 22)
        Me.TxtRazonSocial.TabIndex = 51
        Me.TxtRazonSocial.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(6, 162)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(89, 23)
        Me.LabelX16.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX16.TabIndex = 59
        Me.LabelX16.Text = "Giro"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtDireccion.Border.Class = "TextBoxBorder"
        Me.TxtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDireccion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtDireccion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtDireccion.FocusHighlightEnabled = True
        Me.TxtDireccion.ForeColor = System.Drawing.Color.Black
        Me.TxtDireccion.Location = New System.Drawing.Point(6, 129)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(482, 22)
        Me.TxtDireccion.TabIndex = 52
        Me.TxtDireccion.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(6, 109)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(89, 23)
        Me.LabelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX14.TabIndex = 58
        Me.LabelX14.Text = "Dirección"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(6, 55)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(89, 23)
        Me.LabelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX6.TabIndex = 57
        Me.LabelX6.Text = "Razón social"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.ForeColor = System.Drawing.Color.Black
        Me.ReflectionImage1.Image = CType(resources.GetObject("ReflectionImage1.Image"), System.Drawing.Image)
        Me.ReflectionImage1.Location = New System.Drawing.Point(353, 12)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.ReflectionEnabled = False
        Me.ReflectionImage1.Size = New System.Drawing.Size(167, 179)
        Me.ReflectionImage1.TabIndex = 39
        '
        'Frm_Conectar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 583)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GrupoConexion)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Conectar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GRABAR EMPRESAS EN BAKAPP"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoConexion.ResumeLayout(False)
        Me.GrupoConexion.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnConectar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GrupoConexion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtGiro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNombreCorto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents TxtPais As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelefonos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents TxtBaseDeDatos As TextBox
    Public WithEvents TxtClave As TextBox
    Public WithEvents TxtUsuario As TextBox
    Public WithEvents TxtPuerto As TextBox
    Public WithEvents TxtServidor As TextBox
    Public WithEvents TxtBaseDeDatosBakApp As TextBox
End Class
