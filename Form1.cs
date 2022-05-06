using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace Ejercicio_Guía_9
{
    public partial class Simulador : Form
    {

        private CGrafo grafo;           //Para instanciar la clase CGrafo
        private CVertice nuevoNodo;     //Instanciando la clase CVertice para crear un "NuevoNodo"
        private CVertice NodoOrigen;    //Instanciando la clase CVertice para crear un "NodoOrigen"
        private CVertice NodoDestino;   //Instanciando la clase CVertice para crear un "NodoDestino"
        private int var_control = 0;    //Se utiliza para determinar el estado de la pizarra teniendo que:
                                        //0: Sin acción, 1:Dibujando el arco, 2:Nuevo Vértice

        //Variables para el control de ventanas modales
        private Vertice ventanaVertice; //Ventana para agregar los vértices (Que es el form Agregar Vertice)
        private Arco ventanaArco; //Ventana para agregar el valor de los arco (Que es el form Agregar Arco)
        List<CVertice> nodosRuta; //Lista de nodos utilizada para almacenar la ruta
        List<CVertice> nodosOrdenados; //Lista de nodos ordenados a partir del nodo origen
        bool buscarRuta = false, nuevoVertice = false, nuevoArco = false;
        private int numeroNodos = 0; //Enteros para definir las diferentes opciones y el numero de nodos
        bool profundidad = false, anchura = false, nodoEncontrado = false;
        Queue cola = new Queue();
        private string destino = "", origen = "";
        private int distancia = 0;


        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            ventanaArco = new Arco();
            nodosRuta = new List<CVertice>();
            ventanaArco = new Arco();
            nodosRuta = new List<CVertice>();
            nodosOrdenados = new List<CVertice>();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
                if(nuevoVertice)
                {
                    CBVertice.Items.Clear();
                    CBVertice.SelectedIndex = -1;
                    CBNodoPartida.Items.Clear();
                    CBNodoPartida.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        CBVertice.Items.Add(nodo.Valor);
                        CBNodoPartida.Items.Add(nodo.Valor);
                    }
                    nuevoVertice = false;
                }

                if(nuevoArco)
                {
                    CBArco.Items.Clear();
                    CBArco.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        foreach (CArco arco in nodo.ListaAdyacencia)
                            CBArco.Items.Add("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso);
                    }
                    nuevoArco = false;
                }

                if(buscarRuta)
                {
                    foreach (CVertice nodo in nodosRuta)
                    {
                        nodo.colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    buscarRuta = false;
                }

                if(profundidad)
                {
                    //Ordenando los nodos desde el que indica el usuario
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitando)
                            recorridoProfundidad(nodo, e.Graphics);
                    }
                    profundidad = false;
                    //Reestableciendo los valores
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitando = false;
                }

                if(anchura)
                {
                    distancia = 0;
                    //Ordenando los nodos desde el que indica el usuario
                    cola = new Queue();
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitando && !nodoEncontrado)
                            recorridoAnchura(nodo, e.Graphics, destino);
                    }
                    anchura = false;
                    nodoEncontrado = false;
                    //Reestableciendo los valores
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitando = false;
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh();
        }

        private void nuevoVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2;
            //Recordando que cuando var_control = 2: Nuevo vértice
        }

        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch(var_control)
            {
                case 1: //Dibujando arco
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.Visible = false;
                        ventanaArco.control = false;
                        ventanaArco.ShowDialog();
                        if (ventanaArco.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino,ventanaArco.dato)) //Creando la arista
                            {
                                int distancia = ventanaArco.dato;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                            nuevoArco = true;
                        }


                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    Pizarra.Refresh();
                    break;
            }
        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 2: //Crenado nuevo nodo
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;

                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;

                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2;

                        nuevoNodo.Posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;

                case 1: //Dibujando el arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = LineCap.Triangle;

                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    { CustomEndCap = bigArrow },
                    NodoOrigen.Posicion, e.Location);
                    break;
    
            }

        }

        private void CMSVertice_Opening(object sender, CancelEventArgs e)
        {

        }

        private void añadirVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2;
            //Recordando que cuando var_control = 2: Nuevo vértice
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (CBVertice.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    if(nodo.Valor == CBVertice.SelectedItem.ToString())
                    {
                        grafo.nodos.Remove(nodo);
                        //Borrando arcos que posea el nodo eliminado
                        nodo.ListaAdyacencia = new List<CArco>();
                        break;
                    }
                }

                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if(arco.nDestino.Valor == CBVertice.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }

                nuevoArco = true;
                nuevoVertice = true;
                CBVertice.SelectedIndex = -1;
                Pizarra.Refresh();

            }
            else if(CBVertice.SelectedIndex == -1)
            {
                errorProvider1.SetError(CBVertice, "Debes de seleccionar un nodo");
            }

            if(CBArco.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso == CBArco.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }

                    }


                }

                nuevoVertice = true;
                nuevoArco = true;
                CBArco.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else if(CBArco.SelectedIndex == -1)
            {
                errorProvider1.SetError(CBArco, "Debes de seleccionar un arco");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (CBNodoPartida.SelectedIndex > -1) 
            {
                profundidad = true;
                origen = CBNodoPartida.SelectedItem.ToString();
                Pizarra.Refresh();
                CBNodoPartida.SelectedItem = -1;
            }
            else
            {
                errorProvider1.SetError(CBNodoPartida, "Seleccione nodo de partida");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(CBNodoPartida.SelectedIndex > -1)
            {
                origen = CBNodoPartida.SelectedItem.ToString();
                anchura = true;
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
            }

            else
            {
                errorProvider1.SetError(CBNodoPartida, "Seleccione nodo de partida");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Trim() != "")
            {
                if(grafo.BuscarVertice(txtBuscar.Text)!= null)
                {
                    MessageBox.Show("El vértice " + txtBuscar.Text + " si se encuentra");
                }
                else
                {
                    MessageBox.Show("El vértice " + txtBuscar.Text + " no se encuentra");
                }
            }

        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) //Si se ha presionado el botón izquierdo del mouse
            {

                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null) 
                {
                    var_control = 1; //Como var_control = 1, significa que la pizarra esta en el estado de dibujando arco
                }

                if(nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    ventanaVertice.ShowDialog();
                    numeroNodos = grafo.nodos.Count;

                    if(ventanaVertice.control)
                    {
                        if(grafo.BuscarVertice(ventanaVertice.dato)==null)
                        {
                            grafo.AgregarVertice(nuevoNodo);
                            nuevoNodo.Valor = ventanaVertice.dato;
                            
                        }
                        else
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.dato + " ya existe en el grafo", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    nuevoNodo = null;
                    nuevoVertice = true;
                    var_control = 0;
                    Pizarra.Refresh();
                }

                if (e.Button == MouseButtons.Right) //Si se ha presionado el botón derecho del mouse
                {
                    if (var_control == 0)
                    {
                        if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                        {
                            Pizarra.ContextMenuStrip = this.CMSVertice;
                            nombreVerticeToolStripMenuItem.Text = "Nodo " + NodoOrigen.Valor;
                            nombreVerticeToolStripMenuItem.Enabled = false;
                        }
                        else
                            Pizarra.ContextMenuStrip = this.contextMenuStrip1;

                    }
                }

            }
                
            if(e.Button == MouseButtons.Right) //Si se ha presionado el botón derecho del mouse
            {
                if(var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        Pizarra.ContextMenuStrip = this.CMSVertice;
                        nombreVerticeToolStripMenuItem.Text = "Nodo " + NodoOrigen.Valor;
                        nombreVerticeToolStripMenuItem.Enabled = false;
                    }
                    else
                        Pizarra.ContextMenuStrip = this.contextMenuStrip1;

                }
            }

        }

        private void eliminarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NodoOrigen != null)
                grafo.EliminarVertice(NodoOrigen);
            NodoOrigen = null;
            Pizarra.Refresh();
        }

        public void ordenarNodos()
        {
            nodosOrdenados = new List<CVertice>();
            bool est = false;
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    nodosOrdenados.Add(nodo);
                    est = true;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }

            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    est = false; break;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);

            }
        }

        private void recorridoProfundidad(CVertice vertice, Graphics g)
        {
            vertice.Visitando = true;
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            foreach (CArco adya in vertice.ListaAdyacencia)
            {
                if (!adya.nDestino.Visitando) recorridoProfundidad(adya.nDestino, g);
            }
        }

        private void recorridoAnchura(CVertice vertice, Graphics g, string destino)
        {
            vertice.Visitando = true;
            cola.Enqueue(vertice);
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            if(vertice.Valor == destino)
            {
                nodoEncontrado = true;
                return;
            }
            while(cola.Count > 0)
            {
                CVertice aux = (CVertice)cola.Dequeue();
                foreach (CArco adya in aux.ListaAdyacencia)
                {
                    if (!nodoEncontrado)
                    {
                        adya.nDestino.Visitando = true;
                        adya.nDestino.colorear(g);
                        Thread.Sleep(1000);
                        adya.nDestino.DibujarVertice(g);
                        if (destino != "")
                            distancia += adya.peso;
                        cola.Enqueue(adya.nDestino);
                        if(adya.nDestino.Valor == destino)
                        {
                            nodoEncontrado = true;
                            return;
                        }
                    }
                }
            }
        }
    }

}
