using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(String accion)
        {
            objent.codigo = txtCodigo.Text;
            objent.autor = txtAutor.Text;
            objent.titulo = txtTitulo.Text;
            objent.editorial = txtEditorial.Text;
            objent.cantidad = Convert.ToInt32(txtCantidad.Text);
            objent.precio = Convert.ToSingle(txtPrecio.Text);

            objent.accion = accion;
            String men = objneg.N_mantenimiento_libros(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtEditorial.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtBuscar.Text = "";
            dataGridView2.DataSource = objneg.N_listar_libros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = objneg.N_listar_libros();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if(MessageBox.Show("¿Deseas Registar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
                
            }
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas Modificar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }

            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas Modificar a " + txtTitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            { 
                objent.autor = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_libros(objent);
                dataGridView2.DataSource = dt;
            
            }
            else 
            {
                dataGridView2.DataSource=objneg.N_listar_libros();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView2.CurrentCell.RowIndex;
            txtCodigo.Text = dataGridView2[0,fila].Value.ToString();
            txtTitulo.Text = dataGridView2[1, fila].Value.ToString();
            txtAutor.Text = dataGridView2[2, fila].Value.ToString();
            txtEditorial.Text = dataGridView2[3, fila].Value.ToString();
            txtPrecio.Text = dataGridView2[4, fila].Value.ToString();
            txtCantidad.Text = dataGridView2[5, fila].Value.ToString();
        }
    }
}


