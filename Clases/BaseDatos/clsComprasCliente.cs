using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;
using libComunes.CapaDatos;

namespace Clases.BaseDatos
{
    public class clsComprasCliente
    {
        public string Documento { get; set; }
        public GridView grdCompraCliente { get; set; }
        public GridView grdInfoCliente { get; set; }
        public Int32 codigo_Residencia { get; set; }
        public string Estado { get; set; }
        public String SQL;
        public String Error;

        public bool LlenarGridCompras()
        {
            SQL = "SELECT        TOP (100) PERCENT dbo.tblResidencias.codigo_Residencia, dbo.tblResidencias.Direccion, dbo.tblAlquilerVenta.DocumentoEmpleado, dbo.tblEmpleado.Nombre, dbo.tblEmpleado.PrimerApellido, "+
                         "dbo.tblTipoResidencia.TipoResidencia,dbo.tblAlquilerVenta.CodigoVentaAlquiler " +
                 "FROM            dbo.tblEmpleado INNER JOIN " +
                         "dbo.tblAlquilerVenta ON dbo.tblEmpleado.Documento = dbo.tblAlquilerVenta.DocumentoEmpleado INNER JOIN " +
                         "dbo.tblCliente ON dbo.tblAlquilerVenta.DocumentoCliente = dbo.tblCliente.Documento INNER JOIN " +
                         "dbo.tblTipoResidencia INNER JOIN " +
                         "dbo.tblResidencias ON dbo.tblTipoResidencia.codTipoResidencia1 = dbo.tblResidencias.codTipoResidencia ON dbo.tblAlquilerVenta.CodigoResidencia = dbo.tblResidencias.codigo_Residencia " +
                "WHERE(dbo.tblCliente.Documento = @prDocumento)";
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdCompraCliente;
            oGrid.AgregarParametro("@prDocumento", Documento);
            if (oGrid.LlenarGridWeb())
            {
                grdCompraCliente = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool LlenarGridCliente()
        {
            SQL = "SELECT        PrimerNombre, PrimerApellido, SegundoApellido, Edad, Direccion "+
                  "FROM           dbo.tblCliente " +
                  " WHERE         (Documento = @prDocumento)";
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdInfoCliente;
            oGrid.AgregarParametro("@prDocumento", Documento);
            if (oGrid.LlenarGridWeb())
            {
                grdInfoCliente = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
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
            SQL = "DELETE FROM tblAlquilerVenta WHERE CodigoVentaAlquiler = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", codigo_Residencia);

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
    }
}
