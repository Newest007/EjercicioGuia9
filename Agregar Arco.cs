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
        public int dato;     //El dato que almacenará el vértice

        public Arco()
        {
            InitializeComponent();
            control = false;
            dato = 0;
        }

        private void Arco_Load(object sender, EventArgs e)
        {
            txtArco.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                dato = Convert.ToInt16(txtArco.Text.Trim());
                if(dato < 0)
                {
                    MessageBox.Show("Debes ingresar un valor positivo","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    control = true;
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debes de ingresar un valor numerico","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

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
