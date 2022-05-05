using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_Guía_9
{
    class CGrafo
    {

        //Lista de nodos del grafo
        public List<CVertice> nodos;


        //==========================================//
        //            Constructores                 //
        //==========================================//
        public CGrafo()
        {
            nodos = new List<CVertice>();
        }


        //==========================================//
        //           Operaciones Básicas            //
        //==========================================//

        //Construye un nodo a partir de su valor y lo agrega a la lista de nodos
        public CVertice AgregarVertice (string valor)
        {
            CVertice nodo = new CVertice(valor);
            nodos.Add(nodo);
            return nodo;
        }

        //Agrega un nodo a la lista de nodos del grafo
        public void AgregarVertice (CVertice nuevoNodo)
        {
            nodos.Add(nuevoNodo);
        }

        //Busca un nodo en la lista de nodos del grafo
        public CVertice BuscarVertice (string valor)
        {
            return nodos.Find(v => v.Valor == valor);
        }

        //Crea una arista a partir de los valores de los nodos de origen y de destino
        public bool AgregarArco(string origen, string nDestino, int peso = 1)
        {
            CVertice vOrigen, vnDestino;

            //Si alguno de los nodos no existe, se activa una excepción
            if ((vOrigen = nodos.Find(v => v.Valor == origen)) == null) 
                throw new Exception("El nodo " + origen + " no exite dentro del grafo");

            if ((vnDestino = nodos.Find(v => v.Valor == nDestino)) == null)
                throw new Exception("El nodo " + nDestino + " no existe dentro del grafo");

            return AgregarArco(vOrigen, vnDestino);
        }

        //Crea la arista a partir de los nodos de origen y de destino
        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso = 1)
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null) 
            {
                origen.ListaAdyacencia.Add(new CArco(nDestino, peso));
                return true;
            }
            return false;
        }


        //==========================================//
        //                Métodos                   //
        //==========================================//

        //Método para dibujar el grafo
        public void DibujarGrafo(Graphics g)
        {
            //Dibujando los arcos
            foreach (CVertice nodo in nodos)
                nodo.DibujarArco(g);

            //Dibujando los vértices
            foreach (CVertice nodo in nodos)
                nodo.DibujarVertice(g);

        }

        //Método para detectar si se ha posicionado sobre algún nodo y lo devuelve
        public CVertice DetectarPunto (Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
                if (nodoActual.DetectarPunto(posicionMouse)) return nodoActual;
            return null;
        }

        //Método para regresar al estado original
        public void ReestablecerGrafo(Graphics g)
        {
            foreach(CVertice nodo in nodos)
            {
                nodo.Color = Color.White;
                nodo.FontColor = Color.Black;

                foreach(CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.Black;
                }
            }

            DibujarGrafo(g);
        }

        //======================================================//
        //Método para eliminar un vértice
        public void EliminarVertice(CVertice nodo)
        {
            nodos.Remove(nodo);
        }

        public void ColorArista(string o, string d)
        {
            foreach(CVertice nodo in nodos)
            {
                foreach(CArco a in nodo.ListaAdyacencia)
                {
                    if(nodo.ListaAdyacencia != null && nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        a.color = Color.Red;
                        a.grosor_flecha = 4;
                    }
                }
            }
        }

        public void Colorear(CVertice nodo)
        {
            nodo.Color = Color.AliceBlue;
            nodo.FontColor = Color.Black;
        }

        public CVertice nodoDistanciaMinima()
        {
            int min = int.MaxValue;
            CVertice temp = null;
            foreach(CVertice origen in nodos)
            {
                if(origen.Visitando)
                {
                    foreach (CVertice destino in nodos)
                    {
                        if(!destino.Visitando)
                        {
                            foreach(CArco a in origen.ListaAdyacencia)
                            {
                                if(a.nDestino == destino && min > a.peso)
                                {
                                    min = a.peso;
                                    temp = destino;
                                }
                            }
                        }


                    }
                }

            }

            return temp;
        }

        public int posicionNodo(string Nodo)
        {
            for(int i = 0; i<nodos.Count; i++)
            {
                if (String.Compare(nodos[i].Valor, Nodo) == 0)
                    return i;
            }
            return -1;
        }

        //Función para re-dibujar los arcos que llegan a un nodo
        public void DibujarEntrantes(CVertice nDestino)
        {
            foreach(CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if(a.nDestino == nDestino)
                    {
                        a.color = Color.Black;
                        a.grosor_flecha = 2;
                        break;
                    }
                }
            }
        }

        public void Desmarcar()
        {
            foreach (CVertice n in nodos)
            {
                n.Visitando = false;
                n.Padre = null;
                n.distanciaNodo = int.MaxValue;
                n.pesoAsignado = false;
            }
        }


    }
}
