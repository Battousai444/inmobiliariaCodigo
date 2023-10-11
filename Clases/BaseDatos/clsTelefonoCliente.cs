using System;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsTelefonoCliente
    {

        #region atributos/propiedades
        public DropDownList cboTipoTelefono { get; set; }
        public string Error { get; private set; }
        private string SQL;
        #endregion

        #region metodos
        public bool LlenarCombo()
        {
            SQL = "SELECT        Codigo AS ColumnaValor, NombreTipoTelefono AS ColumnaTexto, Activo " +
                  "FROM           dbo.tblTipoTelefono " +
                  "WHERE          Activo = 1 " +
                  "ORDER BY         ColumnaTexto; ";
            
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboTipoTelefono;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboTipoTelefono = oCombo.cboGenericoWeb;
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
