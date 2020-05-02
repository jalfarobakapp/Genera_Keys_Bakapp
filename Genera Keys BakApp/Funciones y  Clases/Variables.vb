Public Module Variables


    Public Dst_Licencia_Empresa As Object

    Public RutEmpresaActiva As String

    Public Servidor_SQL As String = ""
    Public Cadena_ConexionSQL_Server As String = "" '= Ruta_conexion(AppPath(True) & "Cadena_conexion.txt")
    Public Cadena_ConexionSQL_Server_Base_Paso As String = ""
    Public BaseDatos_SQL As String = ""
    Public Usuario_SQL As String = ""
    Public Clave_SQL As String = ""

    Public KeyReg As String

    Public BaseDeConexion As Integer


    Public Const _CadenaLocal = "data source = SIERRALTA; initial catalog = BAKAPP; user id = BAKAPP; password = BAKAPP"


#Region "VARIABLES DE CONEXION"

    Public Enum ArchivoConexion As Integer
        BasePrincipal = 1
        BaseDeInterfaz = 2
        BaseLocalSql = 3
    End Enum



#End Region


    Public Modalidad As String
    Public ModEmpresa As String
    Public ModSucursal As String
    Public ModBodega As String
    Public ModCaja As String
    Public ModListaPrecioVenta As String
    Public ModListaPrecioCosto As String


    Public EditFrConsultaPre As Boolean




#Region "FORMULARIOS"

    Public Form_Modulo_Compras As Form
    Public Form_Modulo_Ventas As Form

#End Region

    Public Cadena_ConexionBkPost As String
    Public BaseCompacSQL As String '= "BdTmp.sdf"'DbTools.sdf



#Region "VARIABLES VERDADERO O FALSO"
    Public sesion As Boolean
    Public AccesoAdministrador As Boolean = False
    Public VerSolicitud As Boolean
#End Region

#Region "VARIABLES INTEGER"
    Public fila_da As Integer
    Public MargkupAceptable As Integer = 8
    Public MesesPeriodoEstacional As Integer
    Public EditarFuncionatioLibro As Boolean
#End Region

#Region "VARIABLES DE MODULOS"

    Public Compras As Boolean
    Public Ventas As Boolean

#End Region

#Region "COMPRAS"
    Public AccionSubMenu As String

    Public CantPropuestaAnual As String
    Public CantPropuestaEstacional As String
    Public FiltroEstralla As String

#End Region

#Region "VARIABLES DE SISTEMA DE BARRAS"

    Public IDdocumentoSeleccionado As String
    Public CodEntidadDocumento As String
    Public CodEtiqueta As String

#End Region



#Region "VARIABLES BUSQUEDA"

    Public ListaPrecio_BusquedaPR As String

#End Region

#Region "VARIABLES DE VERSIONES"


    'Public currentversion As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\AntBru.exe").FileVersion
    ' Public VersionBKbusquedas As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BKbusquedas.dll").FileVersion
    'Public VersionBkCompras As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BkCompras.dll").FileVersion
    'Public VersionBKpost As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BKpost.dll").FileVersion
    'Public VersionBkSpecialPrograms As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BkSpecialPrograms.dll").FileVersion
    'Public VersionFunciones_BakApp As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\Funciones_BakApp.dll").FileVersion
    'Public VersionConsultaPrecios As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BkConsultaPrecios.dll").FileVersion
    'Public VersionBkInformes As String = FileVersionInfo.GetVersionInfo(Environment.CurrentDirectory & "\BkInformes.dll").FileVersion
    'BkInformes
#End Region

    Public Consulta_sql As String
    Public Nombre_barra As String = ""
    Public Puerto As String = ""
    Public Buscar(,) As String
    Public Maquina As String
    Public NroOT As String

    Public Nombre_funcionario_activo As String
    Public FUNCIONARIO As String
    Public RazonEmpresa As String = ""
    Public RutEmpresa As String = ""
    Public DireccionEmpresa As String = ""
    Public ENTIDAD As String
    Public SUCURSAL As String

    Public Codigo_abuscar As String
    Public IDMAEEDO As String

    Public CodUsuarioPermisos As String


    Public CodEmpresa As String
    Public CodSucursal As String
    Public CodBodega As String
    Public CodUbicacion As String
    Public CodPasilloEstante As String
    Public CodFila As String
    Public CodColumna As String

    Public CodigoMTS As String
    Public CodigoRandom As String

    Public ObservacionesInv As String
    Public TipoBusquedaproductos As String

    Public IdSolicitud As String

    Public SolicitudDeCompra As String
    Public TipoFiltro As String
    Public Idmaeedo_Local As String
    Public CodProveedor As String
    Public CodSucProveedor As String
    Public CantidadPRUd1 As String
    Public SQL_ServerClass As New SQL_Server
    Public IdBodega As String ' Indice de bodega seleccionada en sistema de toma de inventario



    Public TablaDePasoBodegas As String
    Public TablaDePasoProEstrellas As String
    Public TablaSeleccionada As String
    Public UnidadDeTransaccionActual As Integer
    Public CantidadUnidad1 As String
    Public CantidadUnidad2 As String
    Public CantidadAComprar As String


    Public ModalidadDeCompra As String = ""
    Public CompraModalidad As String

    Public Nro As String

    Public UnidadSeleccionada As Boolean






#Region "VARIABLES PARA CREAR PRODUCTOS"
    'Public ProductoCreado As Boolean
    'Public ConsultaSQLGrilladePaso As String

    'Public CodAlternativoProveedorProducto As String ' Codigo Alternativo
    'Public CodProveedorProducto As String ' Codigo entidad

    ''Seleccion del tipo de producto
    'Public NewTipoProducto As String

    ''Antecedentes de identificación
    'Public NewCodigoProducto As String ' Codigo principal
    'Public NewCodigoRapidoProducto As String ' Codigo rapido
    'Public NewCodigoTecnicoProducto As String ' Codigo tecnico
    'Public NewCodigoGenerico As String ' Codigo Generico/Madre
    'Public NewDescripcionProducto As String ' Descripcion del producto


    'Public NewUnidad1Producto As String ' Primera unidad
    'Public NewUnidad2Producto As String ' Segunda unidad
    'Public NewRtuProducto As String ' R.T.U. Razon de transformación

    'Public NewNmarcaProducto As String ' Comportamiento entre unidades de medida

    'Public NewBloqueaPR As String ' Condicion de bloqueo del producto [V]entas, [C]ompras, [T] compras y ventas 
    'Public NewFechaCreacionPR As Date

    ''Antecedentes comerciales basicos
    'Public NewIvaProducto As String ' Iva del producto
    'Public NewListaCostoPR As String ' Lista de costos asignada al producto
    'Public NewExentoIva As Integer ' Exento de Iva
    'Public NewDescIva As String ' % Desc.Iva (Caso especial empresas constructoras)
    'Public NewRegimenProduto As String

    ''Clasificaciones y familias
    'Public NewMarcaProducto As String = "" ' Marca
    'Public NewRubroProducto As String = "" ' Rubro
    'Public NewSuperFamilia As String = "" ' Super Familia
    'Public NewFamilia As String = "" ' Familia
    'Public NewSubFamilia As String = "" ' Sub Familia
    'Public NewPlanoDirFoto As String = "" ' Dirección de Foto
    'Public NewClasifLibre As String = "" ' Clasificacion libre
    'Public NewCodFuncionarioPR As String = "" ' Jefe de producto
    'Public NewZonaProducto As String = "" ' Zona del producto

    'Public NewNumeroImpuestos As String

    ''Seleccion tratamientos especiales
    'Public NewTratalotePr As Integer ' Stock por lote según origen
    'Public NewLoteCajaPR As Integer ' Stock por Lote según contenedor
    'Public NewConUbicPR As Integer ' Con Ubicacion en bodega
    'Public NewDivisibleUd1 As String ' Divisible unidad 1 S = Acepta fracciones, N = Solo enteros
    'Public NewDivisibleUd2 As String ' Divisible unidad 2 S = Acepta fracciones, N = Solo enteros
    'Public NewPrrGDescripModif As Integer ' Descripcion modificable
    'Public NewEsActivoFijoPR As Integer ' Activo fijo (*)
    'Public NewMovPorEtiqueta As Integer ' Controla movimientos por etiqueta
    'Public NewTratamedia As Integer ' Tratamiento según Vida media
    'Public NewStockAsegurado As Integer ' Con Stock fisico certificado


    '' Adicionales
    'Public NewMensajeAdicionalPR As String = "" ' Mensaje <01>
    'Public NewToleranciaLote As String = "0" ' Tolerancia para captura por lotes
    'Public NewValorVidaMedia As String = "0" ' Valor vida media
    'Public NewPesoPR As String = "0" ' Peso(Kg)
    'Public NewVolumenPR As String = "0" ' Volumen(Lt)

    'Public NewCostoProductoUD1 As Double
    'Public NewCostoProductoUD2 As Double

#End Region

End Module
