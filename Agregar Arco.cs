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
    public partial class Arco : Form
    {
        public bool control; //Variable de control
        public string dato;     //El dato que almacenará el vértice

        public Arco()
        {
            InitializeComponent();
            control = false;
            dato = "";
        }

        private void Arco_Load(object sender, EventArgs e)
        {
            txtArco.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dato = txtArco.Text.Trim();

            if ((dato == "") || (dato == " "))
            {
                MessageBox.Show("Hola rey debes de ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void Arco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Arco_Shown(object sender, EventArgs e)
        {
            txtArco.Clear();
            txtArco.Focus();
        }

        private void Arco_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null,null);
            }
        }
    }
}
