using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            AVL<Persona> arbolAVL = new AVL<Persona>();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(';'); //Separador

                if (fila[0] == "INSERT")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    arbolAVL.insertar(nuevaPersona, nuevaPersona.CompararNombre);
                }
                
            }

            foreach (var a in arbolAVL.lista)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }

            Console.ReadKey();
        }

        
    }
}
