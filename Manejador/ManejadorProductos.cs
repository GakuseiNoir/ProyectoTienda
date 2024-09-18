using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorProductos
    {
        Funciones f = new Funciones();
        public void GuardarProducto(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"CALL p_InsertarProductos( '{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
