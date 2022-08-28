using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class AVL
    {
        private Nodo raiz;
        public AVL()
        {
            raiz = null;
        }
        //Buscar
        public Nodo buscar(int v, Nodo r)
        {
            if(raiz == null)
            {
                return null;
            }else if(r.valor == v)
            {
                return r;
            }else if(r.valor < v)
            {
                return buscar(v, r.nodoIzq);
            }
            else{
                return buscar(v, r.nodoIzq);
            }
        }
        //Obtener FE
        public int obtenerFE(Nodo x)
        {
            if (x == null)
            {
                return -1;
            }
            else
            {
                return x.FE;
            }
        }

    }
}
