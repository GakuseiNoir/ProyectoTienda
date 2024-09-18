using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void Borrar(int id, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {id}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"CALL p_EliminarProductos({id})");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from Productos where nombre like'%{filtro}%'", "store").Tables[0];
            tabla.Columns.Insert(6, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(7, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
