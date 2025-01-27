﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Guía_9
{
    class CVertice //Esta clase sirve para definir los nodos (Vértices) del grafo
    {
        public int distanciaNodo; //Variable para guardar la distancia que hay entre el nodo inicio en el algoritmo de Dijkstra
        public Boolean Visitando; //Variable que sirve para marcar como visto el nodo en un recorrido
        public CVertice Padre;    //Nodo que sirve en los recorridos como antecesor
        public Boolean pesoAsignado; //Variable que se usa en el algoritmo de Dijkstra

        public string Valor; //Valor para almacenar y representar el nodo
        public List<CArco> ListaAdyacencia; //Lista de adyacencia del nodo
        //Los diccionarios representan una colección de claves y valores.
        //El primer parámetro representa el tipo de las claves del diccionario
        //El segundo parámetro representa el tipo de los valores del diccionario
        Dictionary<string, short> _banderas;
        Dictionary<string, short> _banderas_predeterminado;


        static int size = 35; //Tamaño del nodo
        Size dimensiones;
        Color color_nodo;   //Color definido para el nodo
        Color color_fuente; //Color definido para la fuente del nombre del nodo
        Point _posicion;    //Lugar en donde se dibujará el nodo
        int radio;          //Radio del objeto que representa el nodo


        //==========================================//
        //               Propiedades                //
        //==========================================//
        public Color Color
        {
            get { return color_nodo; }
            set { color_nodo = value; }
        }

        public Color FontColor
        {
            get { return color_fuente; }
            set { color_fuente = value; }
        }

        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public Size Dimensiones
        {
            get { return dimensiones; }
            set { radio = value.Width / 2; dimensiones = value;}
        }


        //==========================================//
        //            Constructores                 //
        //==========================================//

        //Constructor de la clase que recibe como parámetro el nombre del nodo (Es decir, el valor que tendrá)//
        public CVertice (string Valor)
        {
            this.Valor = Valor;
            this.ListaAdyacencia = new List<CArco>();
            this._banderas = new Dictionary<string, short>();
            this._banderas_predeterminado = new Dictionary<string, short>();
            this.Color = Color.FromArgb(222, 17, 84); //Color del nodo
            this.Dimensiones = new Size(size, size);
            this.FontColor = Color.White; //Color de la letra del vértice
        }

        //Constructor por defecto//
        public CVertice() : this("") { }


        //==========================================//
        //               Métodos                    //
        //==========================================//

        //Método para dibujar el nodo
        public void DibujarVertice(Graphics g)
        {
            SolidBrush b = new SolidBrush(this.color_nodo);

            //Definiendo donde dibujaremos el nodo
            Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio,
                                               this.dimensiones.Width, this.dimensiones.Height);

            //Para rellenar el circulo
            g.FillEllipse(b, areaNodo);

            //Para dibujar el texto y el tipo de letra que tendrá
            g.DrawString(this.Valor, new Font("Time New Roman", 10), new SolidBrush(color_fuente), //Tipo de fuente y tamaño del texto del nodo
                         this._posicion.X, this._posicion.Y,
                         new StringFormat()
                         {
                             Alignment = StringAlignment.Center,
                             LineAlignment = StringAlignment.Center
                         });

            //Para dibujar el circulo
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);
            b.Dispose(); //Para liberar los recursos utilizados por el objeto
        }

        //Método para dibujar los arcos (Es decir, las líneas que unen los nodos)
        public void DibujarArco(Graphics g)
        {
            float distancia;
            int difY, difX;

            foreach(CArco arco in ListaAdyacencia)
            {
                difX = this.Posicion.X - arco.nDestino.Posicion.X;
                difY = this.Posicion.Y - arco.nDestino.Posicion.Y;

                distancia = (float)Math.Sqrt((difX * difX + difY * difY));

                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha)
                { CustomEndCap = bigArrow, Alignment = PenAlignment.Center },
                _posicion, new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia),
                                     arco.nDestino.Posicion.Y + (int)(radio * difY / distancia)));

                g.DrawString(
                    arco.peso.ToString(),
                    new Font("Time New Roman ", 12),
                    new SolidBrush(Color.Black), //Color del peso
                    this._posicion.X - (int)((difX / 3)),
                    this._posicion.Y - (int)((difY / 3)),
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    }
                );
            }
        }

        //Método para detectar la posición en el panel en donde se va a dibujar el nodo
        public bool DetectarPunto(Point p)
        {
            GraphicsPath posicion = new GraphicsPath();

            posicion.AddEllipse(new Rectangle(this._posicion.X - this.dimensiones.Width / 2,
                                              this._posicion.Y - this.dimensiones.Height / 2,
                                              this.dimensiones.Width, this.dimensiones.Height));

            bool retval = posicion.IsVisible(p);
            posicion.Dispose();
            return retval;
        }

        public string ToString()
        {
            this.Color = Color.FromArgb(51, 204, 255); //Definiendo el color del nodo
            this.FontColor = Color.Black;              //Color de la fuente
            this.Visitando = false;
            return this.Valor;
        }

        public void colorear(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(15, 157, 88));
            //Definiendo donde se dibujara el nodo
            Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio,
                this.dimensiones.Width, this.dimensiones.Height);
            g.FillEllipse(b, areaNodo);
            g.DrawString(this.Valor, new Font("Time New Roman", 10), new SolidBrush(color_fuente),
                this._posicion.X, this._posicion.Y,
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center

                });
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);
            b.Dispose();
        }

    }
}
