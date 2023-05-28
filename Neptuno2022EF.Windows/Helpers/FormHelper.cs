using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2022EF.Windows.Helpers
{
    public static class FormHelper
    {
        public static void MostrarDatosEnGrilla<T>(DataGridView dataGrid, List<T> lista) where T : class
        {
            GridHelper.LimpiarGrilla(dataGrid);
            foreach (var obj in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGrid);
                GridHelper.SetearFila(r, obj);
                GridHelper.AgregarFila(dataGrid, r);
            }
        }
    }
}
