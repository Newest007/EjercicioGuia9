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
    public partial class NodoDijkstra : Form
    {
        public bool control; //Variable de control
        public string dato;  //El dato que almacenara el arco

        public NodoDijkstra()
        {
            InitializeComponent();
            control = false;
            dato = " ";
        }

        private void NodoDijkstra_Load(object sender, EventArgs e)
        {
            cmbDijkstra.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = cmbDijkstra.Text.Trim();
            if((valor == "")||(valor == " "))
            {
                MessageBox.Show("Debes de ingresar un valor","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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

        private void NodoDijkstra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void NodoDijkstra_Shown(object sender, EventArgs e)
        {
            cmbDijkstra.Focus();
        }
    }
}
