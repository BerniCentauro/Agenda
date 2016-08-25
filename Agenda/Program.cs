using System;
using System.IO;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (salir == false)
            {
                Console.Clear();
                Console.WriteLine("AGENDA\n");
                Console.WriteLine("Seleccione una opción o presione cualquier otra tecla para salir: ");
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Imprimir Agenda");

                char opcion = Console.ReadKey().KeyChar;

                switch (opcion)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Agregar Nuevo Contacto\n");

                        Console.WriteLine("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el teléfono: ");
                        string telefono = Console.ReadLine();

                        Console.WriteLine("Ingrese la ciudad: ");
                        string ciudad = Console.ReadLine();

                        Contacto nuevoContacto = new Contacto();
                        nuevoContacto.Nombre = nombre;
                        nuevoContacto.Telefono = telefono;
                        nuevoContacto.Ciudad = ciudad;

                        Agenda.Agregar(nuevoContacto);

                        Console.WriteLine("\nContacto agregado! Presione cualquier tecla para volver al menu");
                        Console.ReadKey();

                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Lista De Contactos\n");

                        string texto = Agenda.Listar();
                        Console.WriteLine(texto);

                        Console.WriteLine("\nPresione cualquier tecla para volver al menu");
                        Console.ReadKey();

                        break;
                    default:
                        salir = true;
                        break;
                }
            }
        }
    }

    static class Agenda
    {
        public static void Agregar(Contacto contact)
        {
            StreamWriter agenda = File.AppendText("C:/Users/Berni Hidalgo/Desktop/Agenda.txt");
            agenda.WriteLine(contact.Nombre + "," + contact.Telefono + "," + contact.Ciudad);
            agenda.Close();
        }

        public static string Listar()
        {
            TextReader agenda = new StreamReader("C:/Users/Berni Hidalgo/Desktop/Agenda.txt");
            string texto = agenda.ReadToEnd();
            agenda.Close();

            return texto;
        }
    }

    class Contacto
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Ciudad { get; set; }
    }
}
