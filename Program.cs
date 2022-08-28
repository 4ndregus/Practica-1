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
                    Nodo<Persona> nuevoNodo = new Nodo<Persona>(nuevaPersona);
                    AVLDpi.modificar(nuevoNodo, nuevaPersona.CompararDpi);
                    //AVLDpi.buscar(nuevoNodo, nuevaPersona.CompararNombre);




                    string jsonl = JsonSerializer.Serialize(AVLDpi.listaBusqueda);
                    File.WriteAllText($"{nuevaPersona.name}.jsonl", jsonl);                       

                }
            }
            Persona busqueda = new Persona("liliana", "", "", "");
            Nodo<Persona> nuevoNodo2 = new Nodo<Persona>(busqueda);
            AVLDpi.buscar(nuevoNodo2, busqueda.CompararNombre);

            foreach (var a in AVLDpi.listaBusqueda)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }

            Persona busqueda2 = new Persona("vince", "", "", "");
            Nodo<Persona> nuevoNodo3 = new Nodo<Persona>(busqueda2);
            AVLDpi.buscar(nuevoNodo3, busqueda2.CompararNombre);

            foreach (var a in AVLDpi.listaBusqueda)
            {
                Console.WriteLine($"Name: {a.name} DPI: {a.dpi} Datebirth: {a.datebirth} Address: {a.address}");
            }
            Console.ReadKey();
        }

        
    }
}
