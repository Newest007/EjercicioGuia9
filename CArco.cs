using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ejercicio_Guía_9
{
    class CArco
    {
        //Los arcos son las líneas que unen los nodos

        //==========================================//
        //               Atributos                  //
        //==========================================//
        public CVertice nDestino;
        public int peso; //Peso (valor) de cada arco (Arista)

        public float grosor_flecha;
        public Color color;

        //==========================================//
        //               Métodos                    //
        //==========================================//
        public CArco(CVertice destino): this(destino,1)
        {
            this.nDestino = destino;
        }

        public CArco(CVertice destino, int peso)
        {
            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 2;
            this.color = Color.Black; //Color del arco
        }

    }
}
