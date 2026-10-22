using System;
using System.Xml.Serialization;

namespace FinalProgramacionD
{
    internal class Program
    {
        static string[,] usuarios = new string[5, 5];
        static void Main(string[] args)
        {
            Menu();
        }


        static void Menu()
        {
            Console.WriteLine("-------------menu---------------");
            Console.WriteLine("1.Gestionar usuarios       2.Gestionar Articulos");
            Console.WriteLine("3.Gestionar Ventas         4.Salir del programa");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.Clear();
                    GestionUsuarios();
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
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    VerUsuarios();
                    break;
                case 2:
                    CrearUsuario();
                    break;
                case 3:
                    EditarUsuario();
                    break;
                case 4:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void CrearUsuario()
        {
            int cantidad = 0;
            char siono = 's';
                for (int i = 0; i < usuarios.GetLength(0); i++)
                {
                    for (int j = 0; j < usuarios.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            Console.WriteLine("Ingrese el id del usuario");
                            usuarios[cantidad, 0] = Console.ReadLine();
                        }
                        else if (j == 1)
                        {
                            Console.WriteLine("Ingrese el nombre del usuario");
                            usuarios[cantidad, 1] = Console.ReadLine();
                        }
                        else if (j == 2)
                        {
                            Console.WriteLine("Ingrese el apellido del usuario");
                            usuarios[cantidad, 2] = Console.ReadLine();
                        }
                        else if (j == 3)
                        {
                            Console.WriteLine("Ingrese la direccion del usuario");
                            usuarios[cantidad, 3] = Console.ReadLine();
                        }
                        else if (j == 4)
                        {
                            Console.WriteLine("Ingrese el telefono del usuario");
                            usuarios[cantidad, 4] = Console.ReadLine();
                        }
                        else if (j == 5)
                        {
                            Console.WriteLine("Ingrese el email del usuario");
                            usuarios[cantidad, 5] = Console.ReadLine();
                        }

                    }
                    Console.WriteLine("Desea agregar otro usuario? (s/n)");
                    siono = char.Parse(Console.ReadLine());
                    if (siono == 'n')
                    {
                        Console.Clear();
                        GestionUsuarios();
                        break;  
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
                    Console.Write(usuarios[i, j] + "/");
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
                GestionUsuarios();
                break;
            }
            
        }

        static void EditarUsuario()
        {
            Console.WriteLine("Ingrese el id del usuario a editar");
            int id = int.Parse(Console.ReadLine());
            char siono = 's';

            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < usuarios.GetLength(1); j++)
                {
                    if (usuarios[i, j] == id.ToString())
                    {
                        Console.WriteLine("Ingrese que desea editar");
                        string edicion = Console.ReadLine();
                        int usuarioId = i;
                        switch (edicion)
                        {
                            case "nombre":
                                Console.WriteLine("Ingrese el nuevo nombre del usuario");
                                usuarios[usuarioId, 1] = Console.ReadLine();
                                break;
                            case "apellido":
                                Console.WriteLine("Ingrese el nuevo apellido del usuario");
                                usuarios[usuarioId, 2] = Console.ReadLine();
                                break;
                            case "direccion":
                                Console.WriteLine("Ingrese la nueva direccion del usuario");
                                usuarios[usuarioId, 3] = Console.ReadLine();
                                break;
                            case "telefono":
                                Console.WriteLine("Ingrese el nuevo telefono del usuario");
                                usuarios[usuarioId, 4] = Console.ReadLine();
                                break;
                            case "email":
                                Console.WriteLine("Ingrese el nuevo email del usuario");
                                usuarios[usuarioId, 5] = Console.ReadLine();
                                break;

                            default:
                                Console.WriteLine("Opción no válida");
                                break;
                        }
                        Console.WriteLine("Desea editar otro usuario? (s/n)");
                        siono = char.Parse(Console.ReadLine());
                        if (siono == 'n')
                        {
                            Console.Clear();
                            GestionUsuarios();
                            break;
                        }
                    }
                }
            }
        }

        static void VolverMenu()
        {
            Console.Clear();
            Menu();
        }
    }
}
