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
        public static void Main(string[] args)
        {
            string ubicacionArchivo = "C:\\Users\\agust\\OneDrive - Universidad Rafael Landivar\\URL\\6) Segundo Ciclo 2022\\Estructura de datos II\\Practica-1\\CSV datos.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string linea;

            AVL<Persona> AVLNombre = new AVL<Persona>();
            AVL<Persona> AVLDpi = new AVL<Persona>();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(';'); //Separador

                if (fila[0] == "INSERT")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    AVLNombre.insertar(nuevaPersona, nuevaPersona.CompararNombre);
                    AVLDpi.insertar(nuevaPersona, nuevaPersona.CompararDpi);
                }
                if (fila[0] == "DELETE")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    AVLDpi.eliminar(nuevaPersona, nuevaPersona.CompararDpi);
                    AVLNombre.eliminar(nuevaPersona, nuevaPersona.CompararDpi);                  
                }     
                if (fila[0] == "PATCH")
                {
                    string json = fila[1];
                    Persona nuevaPersona = JsonSerializer.Deserialize<Persona>(json);
                    Nodo<Persona> nuevoNodo = new Nodo<Persona>();
                    nuevoNodo.valor = nuevaPersona;                  
                    AVLNombre.buscar(nuevoNodo, nuevaPersona.CompararNombre);

                    AVLNombre.listaBusqueda.Add(nuevaPersona);
                    //string jsonl = JsonSerializer.Serialize(AVLNombre.listaBusqueda);
                    List<string> listaJsonl = new List<string>();
                    string jsonll = JsonSerializer.Serialize(nuevaPersona);
                    listaJsonl.Add(jsonll);
                    //File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);
                    for (int i = 0; i < AVLNombre.listaBusqueda.Count; i++)
                    {
                        string jsonl = JsonSerializer.Serialize(AVLNombre.listaBusqueda[i]);
                        File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);
                    }
                    //foreach (var a in listaJsonl)
                    //{
                    //    File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);
                    //}               

                }
            }

            foreach (var a in AVLNombre.lista)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }

            Console.ReadKey();
        }

        
    }
}
