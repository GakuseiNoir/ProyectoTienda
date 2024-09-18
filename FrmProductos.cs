using Manejador;
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
        ManejadorProductos mp;
        int fila = 0, columna = 0;
        public static int id = 0;
        public static decimal precio = 0;
        public static string nombre = "", descripcion = "";

        private void dtgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;

            switch (columna)
            {
                case 6:
                    {/*
                        id = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        mp.Borrar(id, dtgvProductos.Rows[fila].Cells[1].Value.ToString());
                        dtgvProductos.Visible = false;*/
                    }
                    break;
                case 7:
                    {
                        id = int.Parse(dtgvProductos.Rows[fila].Cells[0].Value.ToString());
                        nombre = dtgvProductos.Rows[fila].Cells[1].Value.ToString();
                        descripcion = dtgvProductos.Rows[fila].Cells[2].Value.ToString();
                        precio = decimal.Parse(dtgvProductos.Rows[fila].Cells[3].Value.ToString());
                        FrmDatosProductos dp = new FrmDatosProductos();
                        dp.ShowDialog();
                        dtgvProductos.Visible = false;
                    }
                    break;
            }
        }

        private void txtProductos_TextChanged(object sender, EventArgs e)
        {
            dtgvProductos.Visible = true;
            mp.Mostrar(dtgvProductos, txtProductos.Text);
        }

        public FrmProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
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
