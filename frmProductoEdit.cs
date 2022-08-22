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
    public partial class frmProductoEdit : Form
    {
        private int? Id;

        public frmProductoEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsAppTableAdapters.ProductoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.Id);
                var fila = (dsApp.ProductoRow)tabla.Rows[0];

                txtNombre.Text = fila.Nombre;
                txtMarca.Text = fila.Marca;
                txtPrecio.Text = fila.Precio.ToString();
                txtStock.Text = fila.Stock.ToString();
                txtCategoria.Text = fila.IdCategoria.ToString();
            }
            else
            {
                this.Text = "Nuevo";
            }

        }

            private void btnSave_Click(object sender, EventArgs e)
            {
            
            string nombre = txtNombre.Text;
            string marca = txtMarca.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);
            int? categoria = int.Parse(txtCategoria.Text);

            var adaptador = new dsAppTableAdapters.ProductoTableAdapter();
            if (precio >= 2500 && stock <= 5)
            {

                MessageBox.Show("Cantidades no requediras");


            }
            else if (this.Id == null)
            {

                adaptador.Add(nombre, marca, precio, stock, categoria);
            }

            else
            {
                adaptador.Edit(nombre, marca, precio, stock, categoria, (int)this.Id);
            }
            this.Close();
        }
        
    }

}

