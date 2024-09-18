using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProyectoTienda
{
    public partial class FrmProductos : Form
    {
        int fila = 0, columna = 0;
        public static int id = 0;
        public static decimal precio = 0;
        public static string nombre = "", descripcion = "";
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            id = 0; nombre = ""; descripcion = ""; precio = 0;
            dtgvProductos.Visible = false;
            FrmDatosProductos de = new FrmDatosProductos();
            de.ShowDialog();
            txtProductos.Focus();
        }
    }
}
