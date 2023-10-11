using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsVenta_Alquiler
    {
        public clsVenta_Alquiler()
        {
        }
        #region Atributos/Propiedades
        public Int32 CodigoVentaAlquiler { get; set; }
        public Int32 MetodoPago { get; set; }
        public string DocumentoEmpleado { get; set; }
        public string Direccion { get; set; }
        public string Tamaño { get; set; }
        public Int32 codUbicacion { get; set; }
        public Int32 codGarage { get; set; }
        public Int32 codAmueblado { get; set; }
        public Int32 codPisina { get; set; }
        public Int32 codInternet { get; set; }
        public Int32 codPatio { get; set; }
        public Int32 codterraza { get; set; }
        public Int32 codTipoResidencia { get; set; }
        public Int32 precio { get; set; }
        public Int32 codigo_Residencia { get; set; }
        public string DocumentoCliente { get; set; }
        public String Estado { get; set; }
        public GridView grdVentaAlquiler { get; set; }
        //
        public string NombreEmpleado { get; set; }
        public DropDownList cboEmpleado { get; set; }
        //
        public string DireccionResidencia { get; set; }
        public DropDownList cboPago { get; set; }
        //
        public string NombreCliente { get; set; }
        public DropDownList cboCliente { get; set; }

        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGridVenta()
        {
            SQL = SQL = "SELECT        TOP (100) PERCENT dbo.tblResidencias.codigo_Residencia AS CODIGO, dbo.tblResidencias.Direccion AS DIRRECCION, dbo.tblResidencias.tamaño AS TAMAÑO, dbo.tblAmueblado.Amueblacion AS AMUEBLADO, " +
                         "dbo.tblGarage.EspacioGarage AS GARAGE, dbo.tblInternet.NombreInternet AS[COMPAÑIA INTERNET], dbo.tblPatio.TipoPatio AS PATIO, dbo.tblPisina.tamanoPisina AS PISINA, dbo.tblTerraza.TipoTerraza AS TERRAZA, " +
                         "dbo.tblTipoResidencia.TipoResidencia AS[TIPO DE RESIDENCIA], dbo.tblUbicacion.NombreUbicacion AS UBICACION, dbo.tblResidencias.precio AS PRECIO " +
                " FROM            dbo.tblAmueblado INNER JOIN " +
                         "dbo.tblResidencias ON dbo.tblAmueblado.codAmueblado1 = dbo.tblResidencias.codAmueblado INNER JOIN " +
                         "dbo.tblGarage ON dbo.tblResidencias.codGarage = dbo.tblGarage.codGarage1 INNER JOIN " +
                         "dbo.tblInternet ON dbo.tblResidencias.codInternet = dbo.tblInternet.codInternet1 INNER JOIN " +
                         "dbo.tblPatio ON dbo.tblResidencias.codPatio = dbo.tblPatio.codPatio1 INNER JOIN " +
                         "dbo.tblPisina ON dbo.tblResidencias.codPisina = dbo.tblPisina.codPisina1 INNER JOIN " +
                         "dbo.tblTerraza ON dbo.tblResidencias.codterraza = dbo.tblTerraza.codTerraza1 INNER JOIN " +
                         "dbo.tblTipoResidencia ON dbo.tblResidencias.codTipoResidencia = dbo.tblTipoResidencia.codTipoResidencia1 INNER JOIN " +
                         "dbo.tblUbicacion ON dbo.tblResidencias.codUbicacion = dbo.tblUbicacion.codUbicacion1 " +
                " WHERE (dbo.tblResidencias.estado = 'DESOCUPADO') " +
                " ORDER BY CODIGO";


            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdVentaAlquiler;

            if (oGrid.LlenarGridWeb())
            {
                grdVentaAlquiler = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        
        public bool Insertar()
        {
            SQL = "INSERT INTO tblAlquilerVenta ( DocumentoEmpleado, CodigoResidencia, DocumentoCliente, MetodoPago) " +
                  "VALUES (@prDocumentoEmpleado, @prcodigo_Residencia, @prDocumentoCliente, @prMetodoPago)";
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumentoEmpleado", DocumentoEmpleado);
            oConexion.AgregarParametro("@prcodigo_Residencia", codigo_Residencia);
            oConexion.AgregarParametro("@prDocumentoCliente", DocumentoCliente);
            oConexion.AgregarParametro("@prMetodoPago", MetodoPago);
            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE       tblResidencias " +
                  "SET         estado = @prEstado " +
                  "WHERE        codigo_Residencia = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", codigo_Residencia);
            oConexion.AgregarParametro("@prEstado", Estado);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Eliminar()
        {
            SQL = "DELETE FROM  tblAlquilerVenta " +
                  "WHERE        CodigoVentaAlquiler = @prCodigoVentaAlquiler";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoVentaAlquiler", CodigoVentaAlquiler);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        #endregion
        #region LlenarCombos
        public bool LlenarComboEmpleado()
        {
            SQL = "SELECT         Documento AS ColumnaValor, Nombre AS ColumnaTexto " +
                   "FROM          dbo.tblEmpleado " +
                   "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboEmpleado;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboEmpleado = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool ConsultarCliente()
        {
            SQL = "SELECT         PrimerNombre " +
                   "FROM          dbo.tblCliente " +
                   "WHERE         Documento=@prDocumento";


            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento",DocumentoCliente);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    NombreCliente = oConexion.Reader.GetString(0);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el cliente de documento: " + DocumentoCliente;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
            
        }
        public bool LlenarComboPago()
        {
            SQL = "SELECT         CodigoPago AS ColumnaValor, NombrePago AS ColumnaTexto " +
                   "FROM          dbo.tblMetodoPago " +
                   "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboPago;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboPago = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        #endregion
    }
}
