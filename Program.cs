using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace Practica_1
{
    public class Program
    {
        public static AVL<Persona> AVLDpi;
        public static void Main(string[] args)
        {
            string ubicacionArchivo = "C:\\Users\\agust\\OneDrive - Universidad Rafael Landivar\\URL\\6) Segundo Ciclo 2022\\Estructura de datos II\\Practica-1\\input.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string linea;

            AVLDpi = new AVL<Persona>();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(';'); //Separador

                if (fila[0] == "INSERT")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    AVLDpi.insertar(nuevaPersona, nuevaPersona.CompararDpi);
                }
                if (fila[0] == "DELETE")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    AVLDpi.eliminar(nuevaPersona, nuevaPersona.CompararDpi);
                }
                if (fila[0] == "PATCH")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    Nodo<Persona> nuevoNodo = new Nodo<Persona>(nuevaPersona);
                    AVLDpi.modificar(nuevoNodo, nuevaPersona.CompararDpi);

                }
            }

            Persona busqueda = new Persona("ali", "", "", "");
            AVLDpi.buscar(busqueda, busqueda.CompararNombre);

            File.WriteAllText($"{busqueda.name}.jsonl", "");
            for (int i = 0; i < AVLDpi.listaBusqueda.Count(); i++)
            {
                string jsonl = JsonSerializer.Serialize(AVLDpi.listaBusqueda[i]);
                File.AppendAllText($"{busqueda.name}.jsonl", jsonl + Environment.NewLine);
            }

            foreach (var a in AVLDpi.listaBusqueda)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }

            Console.WriteLine(AVLDpi.lista.Count());

            Console.ReadKey();
        }
            
    }
}
