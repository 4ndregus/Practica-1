using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ubicacionArchivo = "C:\\Users\\agust\\OneDrive - Universidad Rafael Landivar\\URL\\6) Segundo Ciclo 2022\\Estructura de datos II\\Practica-1\\CSV datos.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string linea;

            archivo.ReadLine();
            AVL<Persona> arbolAVL = new AVL<Persona>();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(','); //Separador

                Persona nuevaPersona = new Persona(fila[0], fila[1], fila[2], fila[3]);
                arbolAVL.insertar(nuevaPersona, nuevaPersona.CompararNombre);
            }

            foreach (var a in arbolAVL.lista)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }

            Console.ReadKey();
        }

        
    }
}
