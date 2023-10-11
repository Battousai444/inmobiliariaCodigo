using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsResidencias
    {
        public clsResidencias() 
        {
        }
        #region atributos
        public Int32 codigo_Residencia { get; set; }
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
        public string Estado { get; set; }
        public GridView grdResidencias { get; set; }

        private string SQL;
        public string Error { get; private set; }

        #endregion

        #region metodos
        public bool LlenarGrid()
        {
            SQL = "SELECT        TOP (100) PERCENT dbo.tblResidencias.codigo_Residencia AS CODIGO, dbo.tblResidencias.Direccion AS DIRRECCION, dbo.tblResidencias.tamaño AS TAMAÑO, dbo.tblAmueblado.Amueblacion AS AMUEBLADO, "+
                         "dbo.tblGarage.EspacioGarage AS GARAGE, dbo.tblInternet.NombreInternet AS[COMPAÑIA INTERNET], dbo.tblPatio.TipoPatio AS PATIO, dbo.tblPisina.tamanoPisina AS PISINA, dbo.tblTerraza.TipoTerraza AS TERRAZA, "+
                         "dbo.tblTipoResidencia.TipoResidencia AS[TIPO DE RESIDENCIA], dbo.tblUbicacion.NombreUbicacion AS UBICACION, dbo.tblResidencias.precio AS PRECIO "+
                " FROM            dbo.tblAmueblado INNER JOIN "+
                         "dbo.tblResidencias ON dbo.tblAmueblado.codAmueblado1 = dbo.tblResidencias.codAmueblado INNER JOIN "+
                         "dbo.tblGarage ON dbo.tblResidencias.codGarage = dbo.tblGarage.codGarage1 INNER JOIN "+
                         "dbo.tblInternet ON dbo.tblResidencias.codInternet = dbo.tblInternet.codInternet1 INNER JOIN "+
                         "dbo.tblPatio ON dbo.tblResidencias.codPatio = dbo.tblPatio.codPatio1 INNER JOIN "+
                         "dbo.tblPisina ON dbo.tblResidencias.codPisina = dbo.tblPisina.codPisina1 INNER JOIN "+
                         "dbo.tblTerraza ON dbo.tblResidencias.codterraza = dbo.tblTerraza.codTerraza1 INNER JOIN "+
                         "dbo.tblTipoResidencia ON dbo.tblResidencias.codTipoResidencia = dbo.tblTipoResidencia.codTipoResidencia1 INNER JOIN "+
                         "dbo.tblUbicacion ON dbo.tblResidencias.codUbicacion = dbo.tblUbicacion.codUbicacion1 "+
                " WHERE (dbo.tblResidencias.estado = 'DESOCUPADO') "+
                " ORDER BY CODIGO";

            
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdResidencias;
           
            if (oGrid.LlenarGridWeb())
            {
               
                grdResidencias = oGrid.grdGenerico;
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
            SQL = "INSERT INTO tblResidencias (Direccion, tamaño, codUbicacion, codGarage, codAmueblado, codPisina, " +
                                        "codInternet, codPatio, codterraza, codTipoResidencia, precio, estado) " +
                  "VALUES (@prDireccion, @prTamaño, @prUbicacion, @prGarage, @prAmueblado, @prPisina, @prInternet, @prPatio, @prTerraza," +
                           "@prTipoResidencia, @prPrecio, @prEstado )";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prTamaño", Tamaño);
            oConexion.AgregarParametro("@prUbicacion", codUbicacion);
            oConexion.AgregarParametro("@prGarage", codGarage);
            oConexion.AgregarParametro("@prAmueblado", codAmueblado);
            oConexion.AgregarParametro("@prPisina", codPisina);
            oConexion.AgregarParametro("@prInternet",codInternet);
            oConexion.AgregarParametro("@prPatio",codPatio);
            oConexion.AgregarParametro("@prTerraza",codterraza);
            oConexion.AgregarParametro("@prTipoResidencia",codTipoResidencia);
            oConexion.AgregarParametro("@prPrecio",precio);
            oConexion.AgregarParametro("@prEstado",Estado);

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
                  "SET          Direccion = @prDireccion, " +
                               "tamaño = @prTamaño, " +
                               "codUbicacion = @prUbicacion, " +
                               "codGarage = @prGarage, " +
                               "codAmueblado = @prAmueblado, " +
                               "codPisina = @prPisina, " +
                               "codInternet = @prInternet, " +
                               "codPatio = @prPatio, " +
                               "codterraza = @prTerraza, " +
                               "codTipoResidencia = @prTipoResidencia, " +
                               "precio = @prPrecio," +
                               "estado = @prEstado " +
                  "WHERE        codigo_Residencia = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", codigo_Residencia);
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prTamaño", Tamaño);
            oConexion.AgregarParametro("@prUbicacion", codUbicacion);
            oConexion.AgregarParametro("@prGarage", codGarage);
            oConexion.AgregarParametro("@prAmueblado", codAmueblado);
            oConexion.AgregarParametro("@prPisina", codPisina);
            oConexion.AgregarParametro("@prInternet", codInternet);
            oConexion.AgregarParametro("@prPatio", codPatio);
            oConexion.AgregarParametro("@prTerraza", codterraza);
            oConexion.AgregarParametro("@prTipoResidencia", codTipoResidencia);
            oConexion.AgregarParametro("@prPrecio", precio);
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
            SQL = "DELETE FROM  tblResidencias " +
                  "WHERE        codigo_Residencia = @prCodigo";

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
        #endregion
    }
}
