<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Genera_Key_Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Genera_Key_Usuarios))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtRut = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNombreEstacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNombreEmpresa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TxtKeyLicencia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnGrabar = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TxtRut)
        Me.GroupPanel1.Controls.Add(Me.TxtNombreEstacion)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.TxtNombreEmpresa)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 11)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(508, 165)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
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
        'TxtNombreEstacion
        '
        Me.TxtNombreEstacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreEstacion.Border.Class = "TextBoxBorder"
        Me.TxtNombreEstacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreEstacion.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreEstacion.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtNombreEstacion.FocusHighlightEnabled = True
        Me.TxtNombreEstacion.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreEstacion.Location = New System.Drawing.Point(6, 122)
        Me.TxtNombreEstacion.Name = "TxtNombreEstacion"
        Me.TxtNombreEstacion.Size = New System.Drawing.Size(276, 22)
        Me.TxtNombreEstacion.TabIndex = 60
        Me.TxtNombreEstacion.WatermarkText = "Largo max. 13"
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
        Me.LabelX1.Location = New System.Drawing.Point(6, 102)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(210, 23)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX1.TabIndex = 61
        Me.LabelX1.Text = "Nombre del equipo"
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
        'TxtNombreEmpresa
        '
        Me.TxtNombreEmpresa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtNombreEmpresa.Border.Class = "TextBoxBorder"
        Me.TxtNombreEmpresa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreEmpresa.DisabledBackColor = System.Drawing.Color.White
        Me.TxtNombreEmpresa.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtNombreEmpresa.FocusHighlightEnabled = True
        Me.TxtNombreEmpresa.ForeColor = System.Drawing.Color.Black
        Me.TxtNombreEmpresa.Location = New System.Drawing.Point(6, 74)
        Me.TxtNombreEmpresa.Name = "TxtNombreEmpresa"
        Me.TxtNombreEmpresa.Size = New System.Drawing.Size(482, 22)
        Me.TxtNombreEmpresa.TabIndex = 51
        Me.TxtNombreEmpresa.WatermarkText = "Razón Social (Largo max. 50 caracteres)"
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
        'TxtKeyLicencia
        '
        Me.TxtKeyLicencia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtKeyLicencia.Border.Class = "TextBoxBorder"
        Me.TxtKeyLicencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtKeyLicencia.DisabledBackColor = System.Drawing.Color.White
        Me.TxtKeyLicencia.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtKeyLicencia.FocusHighlightEnabled = True
        Me.TxtKeyLicencia.ForeColor = System.Drawing.Color.Black
        Me.TxtKeyLicencia.Location = New System.Drawing.Point(97, 182)
        Me.TxtKeyLicencia.MaxLength = 50
        Me.TxtKeyLicencia.Name = "TxtKeyLicencia"
        Me.TxtKeyLicencia.ReadOnly = True
        Me.TxtKeyLicencia.Size = New System.Drawing.Size(423, 22)
        Me.TxtKeyLicencia.TabIndex = 66
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnAceptar, Me.BtnGrabar})
        Me.Bar1.Location = New System.Drawing.Point(0, 224)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(533, 41)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 64
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Text = "Generar Licencia"
        '
        'BtnGrabar
        '
        Me.BtnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnGrabar.ForeColor = System.Drawing.Color.Black
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Tooltip = "Grabar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(13, 181)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(78, 23)
        Me.LabelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro
        Me.LabelX2.TabIndex = 69
        Me.LabelX2.Text = "N° Licencias"
        '
        'Frm_Genera_Key_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 265)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.TxtKeyLicencia)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Genera_Key_Usuarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GENERAR LICENCIA POR USUARIO"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtRut As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNombreEmpresa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Public WithEvents TxtKeyLicencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNombreEstacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
