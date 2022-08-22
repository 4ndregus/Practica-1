using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class AVL<T>
    {
        private Nodo<T> raiz;
        public List<T> lista;
        public AVL()
        {
            raiz = null;
            lista = new List<T>();
        }
        public Nodo<T> obtenerRaiz()
        {
            return raiz;
        }

        //Buscar
        //public Nodo<T> buscar(int valor, Nodo<T> r)
        //{
        //    if(raiz == null)
        //    {
        //        return null;
        //    }else if(r.valor == valor)
        //    {
        //        return r;
        //    }else if(r.valor < valor)
        //    {
        //        return buscar(valor, r.nodoDer);
        //    }
        //    else
        //    {
        //        return buscar(valor, r.nodoIzq);
        //    }
        //}

        //Obtener el Factor de equilibrio
        public int obtenerFE(Nodo<T> x)
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

        //Rotaciones
        public Nodo<T> rotacionSimpleIzquierda(Nodo<T> A)
        {
            Nodo<T> aux = A.nodoIzq;
            A.nodoIzq = aux.nodoDer;
            aux.nodoDer = A;
            A.FE = Math.Max(obtenerFE(A.nodoIzq), obtenerFE(A.nodoDer)) + 1;
            aux.FE = Math.Max(obtenerFE(aux.nodoIzq), obtenerFE(aux.nodoDer)) + 1;
            return aux;
        }

        public Nodo<T> rotacionSimpleDerecha(Nodo<T> A)
        {
            Nodo<T> aux = A.nodoDer;
            A.nodoDer = aux.nodoIzq;
            aux.nodoIzq = A;
            A.FE = Math.Max(obtenerFE(A.nodoIzq), obtenerFE(A.nodoDer)) + 1;
            aux.FE = Math.Max(obtenerFE(aux.nodoIzq), obtenerFE(aux.nodoDer)) + 1;
            return aux;
        }

        public Nodo<T> rotacionDobleIzquierda(Nodo<T> A)
        {
            Nodo<T> aux;
            A.nodoIzq = rotacionSimpleDerecha(A.nodoIzq);
            aux = rotacionSimpleIzquierda(A);
            return aux;
        }

        public Nodo<T> rotacionDobleDerecha(Nodo<T> A)
        {
            Nodo<T> aux;
            A.nodoDer = rotacionSimpleIzquierda(A.nodoDer);
            aux = rotacionSimpleDerecha(A);
            return aux;
        }

        public Nodo<T> insertarAVL(Nodo<T> nuevo, Delegate delegado1, Nodo<T> subArbol)
        {
            Nodo<T> nuevoPadre = subArbol;
            if(Convert.ToInt32(delegado1.DynamicInvoke(nuevo.valor, subArbol.valor)) < 0)
            {
                if (subArbol.nodoIzq == null)
                {
                    subArbol.nodoIzq = nuevo;
                }
                else
                {
                    subArbol.nodoIzq = insertarAVL(nuevo, delegado1, subArbol.nodoIzq);
                    if (obtenerFE(subArbol.nodoIzq) - obtenerFE(subArbol.nodoDer) == 2)
                    {
                        if (Convert.ToInt32(delegado1.DynamicInvoke(nuevo.valor, subArbol.nodoIzq.valor)) < 0)
                        {
                            nuevoPadre = rotacionSimpleIzquierda(subArbol);
                        }
                        else
                        {
                            nuevoPadre = rotacionDobleIzquierda(subArbol);
                        }
                    }
                }
            }
            else if (Convert.ToInt32(delegado1.DynamicInvoke(nuevo.valor, subArbol.valor)) > 0)
            {
                if (subArbol.nodoDer == null)
                {
                    subArbol.nodoDer = nuevo;
                }
                else {

                    subArbol.nodoDer = insertarAVL(nuevo, delegado1, subArbol.nodoDer);
                    if(obtenerFE(subArbol.nodoDer) - obtenerFE(subArbol.nodoIzq) == 2)
                    {
                        if (Convert.ToInt32(delegado1.DynamicInvoke(nuevo.valor, subArbol.nodoDer.valor)) > 0)
                        {
                            nuevoPadre = rotacionSimpleDerecha(subArbol);
                        } else{
                            nuevoPadre = rotacionDobleDerecha(subArbol);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nodo duplicado");
            }
            //Actualizando la altura FE
            if((subArbol.nodoIzq == null) && (subArbol.nodoDer != null)) {
                subArbol.FE = subArbol.nodoDer.FE + 1;
            }else if((subArbol.nodoDer == null) && (subArbol.nodoIzq != null)) {
                subArbol.FE = subArbol.nodoIzq.FE + 1;
            }else {
                subArbol.FE = Math.Max(obtenerFE(subArbol.nodoIzq), obtenerFE(subArbol.nodoDer));
            }

            return nuevoPadre;
        }

        //Insertar
        public void insertar(T valor, Delegate delegado1)
        {
            Nodo<T> nuevo = new Nodo<T>();
            nuevo.valor = valor;
            nuevo.nodoIzq = null;
            nuevo.nodoDer = null;
            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                raiz = insertarAVL(nuevo, delegado1, raiz);
            }
            inOrder(raiz);
        }

        //Recorridos
        public void inOrder(Nodo<T> r)
        {
            lista.Clear();
            Recorrido(r);
        }

        public void Recorrido(Nodo<T> r)
        {
            if (r != null)
            {
                Recorrido(r.nodoIzq);
                lista.Add(r.valor);
                Recorrido(r.nodoDer);
            }
        }

    }
}
