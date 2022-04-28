using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Guía_9
{
    public partial class Vertice : Form
    {
        public bool control; //Variable de control
        public string dato; //El dato que almacenará el vértice

        public Vertice()
        {
            InitializeComponent();
            control = false;
            dato = "";
        }

        private void Agregar_Vertice_Load(object sender, EventArgs e)
        {
            txtVertice.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = txtVertice.Text.Trim();

            if((valor == "")|| (valor == " "))
            {
                MessageBox.Show("Hola rey debes de ingresar un valor","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                control = true;
                Hide();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false;
            Hide();
        }

        private void Agregar_Vertice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Agregar_Vertice_Shown(object sender, EventArgs e)
        {
            txtVertice.Clear();
            txtVertice.Focus();
        }

        private void Agregar_Vertice_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }
    }
}
