using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class Nodo
    {
        public int valor, FE;
        public Nodo nodoIzq, nodoDer;
        public Nodo(int valor)
        {
            this.valor = valor;
            this.FE = 0;
            this.nodoIzq = null;
            this.nodoDer = null;
        }
    }
}
