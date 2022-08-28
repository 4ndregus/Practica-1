using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class Numeros
    {
        public int dato { get; set; }
        public Comparison<int> CompararDato = delegate (int dato1, int dato2)
        {
            return dato1.CompareTo(dato2);
        };
    }
}
