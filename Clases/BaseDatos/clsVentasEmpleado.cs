using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsVentasEmpleado
    {
        public string Documento { get; set; }
        public GridView grdVentasEmpleado { get; set; }
        public GridView grdInfoEmpleado { get; set; }
        public String SQL;
        public String Error;

        public bool LlenarGridVentas()
        {
            SQL = "SELECT        TOP (100) PERCENT dbo.tblCliente.Documento, dbo.tblCliente.PrimerNombre, dbo.tblCliente.PrimerApellido, dbo.tblCliente.SegundoApellido, dbo.tblResidencias.Direccion, dbo.tblAlquilerVenta.MetodoPago, " +
                 "               dbo.tblAlquilerVenta.CodigoVentaAlquiler, dbo.tblTipoResidencia.TipoResidencia " +
                 " FROM          dbo.tblAlquilerVenta INNER JOIN " +
                 "               dbo.tblResidencias ON dbo.tblAlquilerVenta.CodigoResidencia = dbo.tblResidencias.codigo_Residencia INNER JOIN " +
                 "               dbo.tblTipoResidencia ON dbo.tblResidencias.codTipoResidencia = dbo.tblTipoResidencia.codTipoResidencia1 INNER JOIN " +
                 "               dbo.tblCliente ON dbo.tblAlquilerVenta.DocumentoCliente = dbo.tblCliente.Documento INNER JOIN " +
                 "               dbo.tblEmpleado ON dbo.tblAlquilerVenta.DocumentoEmpleado = dbo.tblEmpleado.Documento " +
                 " WHERE         (dbo.tblEmpleado.Documento = @prDocumento) " +
                 " ORDER         BY dbo.tblAlquilerVenta.CodigoVentaAlquiler";
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdVentasEmpleado;
            oGrid.AgregarParametro("@prDocumento",Documento);
            if (oGrid.LlenarGridWeb())
            {
                grdVentasEmpleado = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool LlenarGridEmpleado()
        {
            SQL = "SELECT         Nombre, PrimerApellido, SegundoApellido, Correo, Direccion " +
                  " FROM          dbo.tblEmpleado " +
                  " WHERE         (Documento = @prDocumento)";
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdInfoEmpleado;
            oGrid.AgregarParametro("@prDocumento", Documento);
            if (oGrid.LlenarGridWeb())
            {
                grdInfoEmpleado = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
    }
}

