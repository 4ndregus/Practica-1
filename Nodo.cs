using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class Nodo<T>
    {
        public T valor;
        public int FE;
        public Nodo<T> nodoIzq, nodoDer;
        public Nodo()
        {
            FE = 0;
            nodoIzq = null;
            nodoDer = null;
        }
    }
}
