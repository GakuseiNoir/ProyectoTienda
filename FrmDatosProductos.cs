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
                //mp.Modificar(txtUsuario, txtEmail, txtTelefono, txtClave, cmbNivel, FrmNivel1.id);
            }
            else
            {
                mp.GuardarProducto(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }
    }
}
