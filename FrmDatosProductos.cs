using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace ProyectoTienda
{
    public partial class FrmDatosProductos : Form
    {
        ManejadorProductos mp;
        public FrmDatosProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            txtNombre.Text = FrmProductos.nombre;
            txtDescripcion.Text = FrmProductos.descripcion;
            txtPrecio.Text = FrmProductos.precio.ToString("F2");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmProductos.id > 0)
            {
                mp.ModificarProductos(txtNombre, txtDescripcion, txtPrecio, FrmProductos.id);
            }
            else
            {
                mp.GuardarProducto(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Comprobar si el carácter es un número, punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Rechazar el carácter
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Rechazar si ya hay un punto decimal
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
