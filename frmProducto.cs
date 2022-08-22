using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {

            var adaptador = new dsAppTableAdapters.ProductoTableAdapter();
            var tabla = adaptador.GetData();
            dgvDatos.DataSource = tabla;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmProductoEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un Id válido", "Sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private int getId()
        {
            try
            {
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return 0;

            }

        }

            private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)

            {
                DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistemas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var adaptador = new dsAppTableAdapters.ProductoTableAdapter();
                    adaptador.Remove(id);
                    MessageBox.Show("Registro Eliminado", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarDatos();




                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Id Valido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmProductoEdit();
            frm.ShowDialog();
            cargarDatos();



        }
    }
}
