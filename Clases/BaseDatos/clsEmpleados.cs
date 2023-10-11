using System;
using libComunes.CapaDatos; 
using libComunes.CapaObjetos; 
using System.Web.UI.WebControls; 
namespace Clases.BaseDatos
{
    public class clsEmpleados
    {
        #region Constructor
        public clsEmpleados()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public GridView grdEmpleados { get; set; }
        public GridView grdTelefonosEmpleado { get; set; }
        public Int32 CodigoTelefono { get; set; }
        public string Telefono { get; set; }
        public Int32 TipoTelefono { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos

        public bool LlenarGrid()
        {
            SQL = "SELECT         Documento, Nombre, PrimerApellido, SegundoApellido, Correo, Direccion " +
                   "FROM          dbo.tblEmpleado "+
                   "ORDER BY Nombre; ";

            //Se crea el objeto grid
            clsGrid oGrid = new clsGrid();
            //Paso el sql y el grid vacío
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdEmpleados;
            //Invocar el llenado del grid
            if (oGrid.LlenarGridWeb())
            {
                //lee el grid lleno
                grdEmpleados = oGrid.grdGenerico;
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
            SQL = "INSERT INTO tblEmpleado ( Documento, Nombre, PrimerApellido, SegundoApellido, Correo, Direccion ) " +
                 "VALUES (@prDocumento, @prNombre, @prPrimerApellido, @prSegundoApellido, @prCorreo, @prDireccion ) ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prCorreo", Correo);
            oConexion.AgregarParametro("@prDireccion", Direccion);
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
            SQL = "UPDATE       tblEmpleado " +
                  "SET          Nombre=@prNombre, " +
                               "PrimerApellido=@prPrimerApellido, " +
                               "SegundoApellido=@prSegundoApellido, " +
                               "Direccion=@prDireccion, " +
                               "Correo=@prCorreo " +
                 "WHERE         Documento=@prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prCorreo", Correo);
            oConexion.AgregarParametro("@prDireccion", Direccion);
           

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
            SQL = "DELETE FROM tblEmpleado WHERE Documento=@prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

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
        public bool Consultar()
        {
            SQL = " SELECT          Nombre, PrimerApellido, SegundoApellido, Correo, Direccion " +
                  "FROM             dbo.tblEmpleado " +
                  " WHERE           Documento=@prDocumento";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Nombre = oConexion.Reader.GetString(0);
                    PrimerApellido = oConexion.Reader.GetString(1);
                    SegundoApellido = oConexion.Reader.GetString(2);
                    Correo = oConexion.Reader.GetString(3);
                    Direccion = oConexion.Reader.GetString(4);
                    

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el cliente de documento: " + Documento;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool LlenarGridTelefono()
        {
            SQL = "SELECT       dbo.tblTelefonoEmpleado.Codigo_Telefono_empleado AS [COD TELEGONO], dbo.tblTelefonoEmpleado.Nombre_Tipo_telefono AS [TIPO TELEFONO], dbo.tblCon_Empleado_Telefono.Codigo AS CODIGOS, " +
                               " dbo.tblCon_Empleado_Telefono.Numero AS TELEFONO, dbo.tblCon_Empleado_Telefono.DocumentoEmpleado AS DOCUMENTO " +
                   "FROM            dbo.tblEmpleado INNER JOIN " +
                         "dbo.tblCon_Empleado_Telefono ON dbo.tblEmpleado.Documento = dbo.tblCon_Empleado_Telefono.DocumentoEmpleado INNER JOIN " +
                         "dbo.tblTelefonoEmpleado ON dbo.tblCon_Empleado_Telefono.CodigoTelefono = dbo.tblTelefonoEmpleado.Codigo_Telefono_empleado " +
                         "WHERE        dbo.tblCon_Empleado_Telefono.DocumentoEmpleado=  @prDocumento " +
                         "ORDER BY      [TIPO TELEFONO]; ";
                
                  
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdTelefonosEmpleado;

            oGrid.AgregarParametro("@prDocumento", Documento);
            
            if (oGrid.LlenarGridWeb())
            {
                grdTelefonosEmpleado = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }


        }
       
            public bool InsertarTelefono()
            {
                SQL = "INSERT INTO tblCon_Empleado_Telefono (Numero, DocumentoEmpleado, CodigoTelefono) " +
                  "VALUES (@prTelefono, @prDocumento, @prCodigo) ";

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prTelefono", Telefono);
                oConexion.AgregarParametro("@prDocumento", Documento);
                oConexion.AgregarParametro("@prCodigo", TipoTelefono);


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
        public bool ActualizarTelefono()
        {
            SQL = "UPDATE tblCon_Empleado_Telefono " +
                "SET            Numero= @prTelefono, " +
                                "DocumentoEmpleado= @prDocumento, " +
                                "CodigoTelefono= @prCodigo " +
                "WHERE          Codigo= @prCodigoTelefono; ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodigoTelefono);
            oConexion.AgregarParametro("@prTelefono", Telefono);
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prCodigo", TipoTelefono);


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
        public bool EliminarTelefono()
        {
            SQL = "delete from    tblCon_Empleado_Telefono " +
               "WHERE             Codigo= @prCodigoTelefono ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodigoTelefono);



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

    #endregion
}

