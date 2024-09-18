using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
        public void ModificarProductos(TextBox Nombre, TextBox Descripcion, TextBox Precio, int id)
        {
            MessageBox.Show(f.Modificar($"CALL p_ModificarProductos({id}, '{Nombre.Text}', '{Descripcion.Text}', {Precio.Text})"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;
        }
    }
}
