﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
        private Vertice ventanaVertice; //Ventana para agregar los vértices (Que es el form de Agregar Vertice)

        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;

            ventanaVertice = new Vertice();
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
                    if((NodoDestino = grafo.DetectarPunto(e.Location))!= null && NodoOrigen != NodoDestino)
                    {
                        if(grafo.AgregarArco(NodoOrigen,NodoDestino)) //Creando la arista
                        {
                            int distancia = 0;
                            NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
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
                case 2:
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
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    { CustomEndCap = bigArrow },
                    NodoOrigen.Posicion, e.Location);
                    break;
    
            }

        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left) //Si se ha presionado el botón izquierdo del mouse
            {

                if((NodoOrigen = grafo.DetectarPunto(e.Location))!=null)
                {
                    var_control = 1; //Como var_control = 1, significa que la pizarra esta en el estado
                                     //de dibujando arco
                }

                if(nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    ventanaVertice.ShowDialog();

                    if(ventanaVertice.control)
                    {
                        if(grafo.BuscarVertice(ventanaVertice.txtVertice.Text)==null)
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                            grafo.AgregarVertice(nuevoNodo);
                        }
                        else
                        {
                            MessageBox.Show("El Nodo "+ventanaVertice.txtVertice.Text+" ya existe en el grafo","Error nuevo Nodo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }    
                    }
                    nuevoNodo = null;
                    var_control = 0;
                    Pizarra.Refresh();
                }

            }

            if(e.Button == System.Windows.Forms.MouseButtons.Right) //Si se ha presionado el botón derecho del mouse
            {
                if(var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo" + NodoOrigen.Valor;
                    }
                    else
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                }


            }

        }
    }

}
