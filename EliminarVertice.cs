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
    public partial class EliminarVertice : Form
    {
        private CGrafo grafo;
        public bool prueba;
        public string asd;

        public EliminarVertice()
        {
            InitializeComponent();
            prueba = false;
            asd = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = txtEliminar.Text.Trim();

            if ((valor == "") || (valor == " "))
            {
                MessageBox.Show("Hola rey debes de ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                prueba = true;
                Hide();
            }


        }

        private void EliminarVertice_Load(object sender, EventArgs e)
        {

        }
    }
}
