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
            string ubicacionArchivo = "C:\\Users\\agust\\OneDrive - Universidad Rafael Landivar\\URL\\6) Segundo Ciclo 2022\\Estructura de datos II\\Practica-1\\input.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string linea;

            //Linea 108 archivo input
            AVL<Persona> AVLDpi = new AVL<Persona>();
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
                    Nodo<Persona> nuevoNodo = new Nodo<Persona>();
                    nuevoNodo.valor = nuevaPersona;
                    AVLDpi.modificar(nuevoNodo, nuevaPersona.CompararDpi);
                    AVLDpi.buscar2(nuevoNodo, nuevaPersona.CompararNombre);

                    string jsonl = JsonSerializer.Serialize(AVLDpi.listaBusqueda);
                    File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);

                    //for (int i = 0; i < AVLDpi.listaBusqueda.Count; i++)
                    //{
                    //    string jsonl = JsonSerializer.Serialize(AVLDpi.listaBusqueda[i]);
                    //    File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);
                    //}                          

                }
            }

            foreach (var a in AVLDpi.lista)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }
            Console.ReadKey();
        }

        
    }
}
