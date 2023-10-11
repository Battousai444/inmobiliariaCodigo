using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;
using System.Xml;

namespace Clases.BaseDatos
{
    public class clsCliente
    {
        #region Constructor
        public clsCliente()
        {

        }
        #endregion
        #region Atributos/propiedades
        public string Documento { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Int32 Edad { get; set; }
        public string Direccion { get; set; }
        public GridView grdClientes { get; set; }
        public GridView grdTelefonosCliente { get; set; }
        public Int32 CodTelCliente { get; set; }
        public string NumTelCliente { get; set; }
        public string CodTipoTelefono { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            SQL = "SELECT        Documento, PrimerNombre, PrimerApellido, SegundoApellido, Edad, Direccion "+
                   " FROM         dbo.tblCliente ";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdClientes;
            if (oGrid.LlenarGridWeb())
            {
                grdClientes = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool CalcularEdad()
        {
            XmlDocument oDocumento = new XmlDocument();
            oDocumento.Load(@"C:\Users\Felipe\Downloads\Final Inmobiliaria\Clases\XML\xmlRNedad.xml");
            string consultaXML = "/CALCULAR_EDAD/EDAD[@MIN=" + Edad + " >= @MAX=" + Edad + "]";

            XmlNodeList olistaNodos = oDocumento.SelectNodes(consultaXML);
            if (olistaNodos.Count == 0)
            {
                Error = "No se puede ingresar al cliente por ser menor de edad o ser mayor de 100 años";
                return false;
            }
            else
            {
                if (olistaNodos.Count > 1)
                {
                    Error = "Se encontraron más respuestas";
                    return false;
                }
                else
                {
                   Error= olistaNodos[0].InnerText;
                   return true;
                }
            }

        }
        public bool Insertar()
        {
            if (CalcularEdad()) { 
                SQL = "INSERT INTO tblCliente ( Documento, PrimerNombre, PrimerApellido, SegundoApellido, Edad, Direccion ) " +
                     "VALUES (@prDocumento, @prPrimerNombre, @prPrimerApellido, @prSegundoApellido, @prEdad, @prDireccion ) ";

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento", Documento);
                oConexion.AgregarParametro("@prPrimerNombre", PrimerNombre);
                oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
                oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
                oConexion.AgregarParametro("@prEdad", Edad);
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
            else
            {
                return false;
            }
        }
        public bool Actualizar()
        {
            if (CalcularEdad())
            {
                SQL = "UPDATE       tblCliente " +
                  "SET          PrimerNombre=@prPrimerNombre, " +
                               "PrimerApellido=@prPrimerApellido, " +
                               "SegundoApellido=@prSegundoApellido, " +
                               "Direccion=@prDireccion, " +
                               "Edad=@prEdad " +
                 "WHERE         Documento=@prDocumento";

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento", Documento);
                oConexion.AgregarParametro("@prPrimerNombre", PrimerNombre);
                oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
                oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
                oConexion.AgregarParametro("@prEdad", Edad);
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
            else
            {
                return false;
            }
        }
        public bool Eliminar()
        {
            SQL = "DELETE FROM tblCliente WHERE Documento=@prDocumento";

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
            SQL = " SELECT          PrimerNombre, PrimerApellido, SegundoApellido, Edad, Direccion " +
                  " FROM             dbo.tblCliente " +
                  " WHERE          Documento = @prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    PrimerNombre = oConexion.Reader.GetString(0);
                    PrimerApellido = oConexion.Reader.GetString(1);
                    SegundoApellido = oConexion.Reader.GetString(2);
                    Edad= oConexion.Reader.GetInt32(3);
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
            SQL = "SELECT        dbo.tblTipoTelefono.Codigo, dbo.tblTelefonoCliente.CodTelCliente, dbo.tblTelefonoCliente.NumTelCliente, dbo.tblTipoTelefono.NombreTipoTelefono "+
                  " FROM          dbo.tblCliente INNER JOIN "+
                                "dbo.tblTelefonoCliente ON dbo.tblCliente.Documento = dbo.tblTelefonoCliente.DocumentoCliente INNER JOIN "+
                                "dbo.tblTipoTelefono ON dbo.tblTelefonoCliente.CodigoTipoTelefono = dbo.tblTipoTelefono.Codigo "+
                  " WHERE         dbo.tblTelefonoCliente.DocumentoCliente = @prDocumento "+
                   " ORDER BY     dbo.tblTipoTelefono.NombreTipoTelefono";


            
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdTelefonosCliente;
            oGrid.AgregarParametro("@prDocumento", Documento);
            
            if (oGrid.LlenarGridWeb())
            {
                grdTelefonosCliente = oGrid.grdGenerico;
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
            SQL = "INSERT INTO tblTelefonoCliente (NumTelCliente, DocumentoCliente, CodigoTipoTelefono) " +
              "VALUES (@prTelefono, @prDocumento, @prCodigo) ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prTelefono", NumTelCliente);
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prCodigo", CodTipoTelefono);


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
            SQL = "UPDATE       tblTelefonoCliente " +
                "SET            NumTelCliente= @prTelefono, " +
                                "DocumentoCliente= @prDocumento, " +
                                "CodigoTipoTelefono= @prCodigo " +
                "WHERE          CodTelCliente= @prCodigoTelefono; ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodTelCliente);
            oConexion.AgregarParametro("@prTelefono", NumTelCliente);
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prCodigo", CodTipoTelefono);


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
            SQL = "DELETE FROM   tblTelefonoCliente " +
               "WHERE             CodTelCliente= @prCodigoTelefono ";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodTelCliente);


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
    }
}

