using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsCombosResidencias
    {
        public clsCombosResidencias()
        {

        }
        #region propiedades
        public Int32 codGarage1 { get; set; }
        public string EspacioGarage { get; set; }
        public DropDownList cboGarage { get; set; }
        public Int32 codInternet1 { get; set; }
        public string NombreInternet { get; set; }
        public DropDownList cboInternet { get; set; }
        public Int32 codUbicacion1 { get; set; }
        public string NombreUbicacion { get; set; }
        public DropDownList cboUbicacion { get; set; }
        public Int32 codPatio1 { get; set; }
        public string TipoPatio { get; set; }
        public DropDownList cboPatio { get; set; }
        public Int32 codTipoResidencia1 { get; set; }
        public string TipoResidencia { get; set; }
        public DropDownList cboTipoResidencia { get; set; }
        public Int32 codAmueblado1 { get; set; }
        public string Amueblacion { get; set; }
        public DropDownList cboAmueblacion { get; set; }
        public Int32 codPisina1 { get; set; }
        public string tamanoPisina { get; set; }
        public DropDownList cboPisina { get; set; }
        public Int32 codTerraza1 { get; set; }
        public string TipoTerraza { get; set; }
        public DropDownList cboTerraza { get; set; }
        private string SQL;
        public string Error { get; private set; }

        #endregion

        #region llenarmetodos
        public bool LlenarComboGarage()
        {
            SQL = "SELECT         codGarage1 AS ColumnaValor, EspacioGarage AS ColumnaTexto "+
                   "FROM dbo.tblGarage "+
                   "ORDER BY ColumnaValor; ";
            
            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;
            
            oCombo.cboGenericoWeb = cboGarage;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
               
                cboGarage = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboIntenet()
        {
            SQL = "SELECT       codInternet1 AS ColumnaValor, NombreInternet AS ColumnaTexto "+
                  "FROM         dbo.tblInternet "+
                  "ORDER BY     ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboInternet;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboInternet = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboUbicacion()
        {
            SQL = "SELECT        codUbicacion1 AS ColumnaValor, NombreUbicacion AS ColumnaTexto "+
                  "FROM          dbo.tblUbicacion "+
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboUbicacion;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboUbicacion = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboPatio()
        {
            SQL = "SELECT        codPatio1 AS ColumnaValor, TipoPatio AS ColumnaTexto " +
                  "FROM          dbo.tblPatio " +
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboPatio;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboPatio = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboTipoResidencia()
        {
            SQL = "SELECT        codTipoResidencia1 AS ColumnaValor, TipoResidencia AS ColumnaTexto " +
                  "FROM          dbo.tblTipoResidencia " +
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboTipoResidencia;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboTipoResidencia = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboAmueblado()
        {
            SQL = "SELECT        codAmueblado1 AS ColumnaValor, Amueblacion AS ColumnaTexto " +
                  "FROM          dbo.tblAmueblado " +
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboAmueblacion;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboAmueblacion = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboPisina()
        {
            SQL = "SELECT        codPisina1 AS ColumnaValor, tamanoPisina AS ColumnaTexto " +
                  "FROM          dbo.tblPisina " +
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboPisina;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboPisina = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        public bool LlenarComboTerraza()
        {
            SQL = "SELECT        codTerraza1 AS ColumnaValor, TipoTerraza AS ColumnaTexto " +
                  "FROM          dbo.tblTerraza " +
                  "ORDER BY      ColumnaValor; ";

            clsCombos oCombo = new clsCombos();

            oCombo.SQL = SQL;

            oCombo.cboGenericoWeb = cboTerraza;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {

                cboTerraza = oCombo.cboGenericoWeb;
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
