using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace Clases.BaseDatos
{
    public class clsTelefonoEmpleado
    {

        #region atributos/propiedades
        public DropDownList cboTipoTelefono { get; set; }
        public string Error { get; private set; }
        private string SQL;

        #endregion
        #region metodos
        public bool LlenarCombo()
        {
            SQL = "SELECT        Codigo_Telefono_empleado AS ColumnaValor, Nombre_Tipo_telefono AS ColumnaTexto, blnActivo " +
                  "FROM           dbo.tblTelefonoEmpleado " +
                  "WHERE          blnActivo = 1 " +
                  "ORDER BY         ColumnaTexto; ";
            //Se crea el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el SQL
            oCombo.SQL = SQL;
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboTipoTelefono;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                //Capturo el combo lleno
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