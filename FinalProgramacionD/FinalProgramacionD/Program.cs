using System;
using System.Xml.Serialization;

namespace FinalProgramacionD
{
    internal class Program
    {
        static string[,] usuarios = new string[5, 5];
        static void Main(string[] args)
        {
        }


        static void Menu()
        {
            Console.WriteLine("-------------menu---------------");
            Console.WriteLine("1.Gestionar usuarios       2.Gestionar Articulos");
            Console.WriteLine("3.Gestionar Ventas         4.Salir del programa");
            int i = 0;
            switch (i)
            {
                case 1:

                  break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;

                default:
                    break;  
            }

        }
        static void GestionUsuarios()
        {
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1. Ver lista de usuarios      2.Nuevo Usuario");
            Console.WriteLine("3.Editar informacion          4.Volver al menu");
        }

        static void CrearUsuario()
        {
            int cantidad = 0;
            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < usuarios.GetLength(1); j++)
                {
                    Console.WriteLine("Ingrese nuevo usuario");
                    usuarios[cantidad, j] = Console.ReadLine();
                }
                cantidad++;
            }
        }

        static void VerUsuarios()
        {
            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < usuarios.GetLength(1); j++)
                {
                    Console.Write(usuarios[i, j]);
                }
                Console.WriteLine();
            }
            
        }

        static void VolverMenu()
        {
            Console.Clear();
            Menu();
        }
    }
}
