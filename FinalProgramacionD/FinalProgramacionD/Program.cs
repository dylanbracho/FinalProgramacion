using System;
using System.Runtime.Versioning;
using System.Threading;
using System.Xml.Serialization;

namespace FinalProgramacionD
{
    internal class Program
    {
<<<<<<< HEAD
        static string [,] articulos = new string[20, 4];
=======
        static string[,] usuarios = new string[20, 6];
>>>>>>> 868e92359cda51086255be8d077b38b2746a2c3c
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("-------------menu---------------");
            Console.WriteLine("1.Gestionar usuarios       2.Gestionar Articulos");
            Console.WriteLine("3.Gestionar Ventas         4.Salir del programa");
<<<<<<< HEAD
            int i;
            i = int.Parse(Console.ReadLine());
=======
            int i = int.Parse(Console.ReadLine());
>>>>>>> 868e92359cda51086255be8d077b38b2746a2c3c
            switch (i)
            {
                case 1:
                    Console.Clear();
                    GestionUsuarios();
                  break;
                case 2:
                    GestionArticulos();
                    break;
                case 3:
                    Console.Clear();
                    SeleccionUsuario();
                    break;
                case 4:

                    break;

                default:
                    break;  
            }
        }
<<<<<<< HEAD
=======
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
                    if (usuarios[i, j] == null)
                    {
                        Console.WriteLine("No hay usuarios registrados");
                        break;
                    }
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

        static int BuscarUsuario(string id)
        {
            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                if (id == usuarios[i,0])
                {
                    return i;
                } 
            }
            return 21;
        }

        static void SeleccionUsuario()
        {
            Console.WriteLine("Ingrese el id del usuario");
            string id = Console.ReadLine();

            int usuario = BuscarUsuario(id);
            if (usuario == 21)
            {
                Console.WriteLine("Usuario no encontrado");
                Console.WriteLine("Desea crear un usuario nuevo(s/n)");
                char siono = char.Parse(Console.ReadLine());
                if (siono == 's')
                {
                    Console.Clear();
                    CrearUsuario();
                }
                return;
            }
            Console.WriteLine("Usuario encontrado");
            Console.WriteLine("Nombre: " + usuarios[usuario, 1]);
            Console.WriteLine("Apellido: " + usuarios[usuario, 2]);
            Console.WriteLine("Direccion: " + usuarios[usuario, 3]);
            Console.WriteLine("Telefono: " + usuarios[usuario, 4]);
            Console.WriteLine("Email: " + usuarios[usuario, 5]);

            GenerarFactura(usuario);
        }

        static void GenerarFactura(int fila)
        {
            Console.WriteLine($"Factura generada para el usuario: {usuarios[fila, 1]} {usuarios[fila, 2]}");
            Console.WriteLine("CC: " + usuarios[fila, 0]);
        }

>>>>>>> 868e92359cda51086255be8d077b38b2746a2c3c
        static void VolverMenu()
        {
            Console.Clear();
            Menu();
        }
        static void GestionArticulos()
        {
            Console.WriteLine("1. Ver lista de articulos");
            Console.WriteLine("2. Nuevo articulo");
            Console.WriteLine("3. Editar información de articulo");
            Console.WriteLine("4. Volver al menú");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.Clear();
                    VerArticulos();
                    break;
                case 2:
                    Console.Clear();
                    CrearArticulo();
                    break;
                case 3:
                    EditarArticulo();
                    break;
                case 4:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    GestionArticulos();
                    break;
            }
        }
        static void VerArticulos()
        {
            for (int i = 0; i < articulos.GetLength(0); i++)
            {
                Console.Write($"{i + 1}.");
                for (int j = 0; j < articulos.GetLength(1); j++)
                {
                    Console.Write($" |{articulos[i, j]}| ");
                }
                Console.WriteLine();
            }            
        }
        static int SaltarFila() 
        {
            int i = 0;
            return i + 1;
        }
        static void CrearArticulo() 
        {
            int cantidad = 0;
            char seguir;
            for (int i = 0;i < articulos.GetLength(0); i++)
            {
                for (int j = 0;j < articulos.GetLength(1); j++)
                {
                    if (articulos[cantidad, j] == null)
                    {
                       switch (j)
                        {
                            case 0:
                                Console.WriteLine("Ingrese el id del articulo");
                                articulos[cantidad, j] = Console.ReadLine();

                                break;
                            case 1:
                                Console.WriteLine("Ingrese el nombre del articulo");
                                articulos[cantidad, j] = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingrese el precio del articulo");
                                articulos[cantidad, j] = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Ingrese la cantidad disponible del articulo");
                                articulos[cantidad, j] = Console.ReadLine();
                                break;        
                        }     
                    }
                    SaltarFila();
                }                
                Console.WriteLine("¿Desea seguir ingresando articulos? (s/n)");
                seguir = Convert.ToChar(Console.ReadLine());
                if (seguir == 'n')
                {
                    
                    Console.Clear();
                    GestionArticulos();
                }
                cantidad++;
            }                        
        }
        static void EditarArticulo()
        {
            char seguir;
            int articuloEdit;
            
            Console.WriteLine("Seleccione el articulo a editar:");
            articuloEdit = int.Parse(Console.ReadLine());
            for (int i = articuloEdit-1;i < articulos.GetLength(0); i++)
            {
                for (int j = 0; j < articulos.GetLength(1); j++)
                {
                    switch (j)
                    {
                        case 2:
                            Console.WriteLine("Ingrese el nuevo precio");
                            articulos[i, j] = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Ingrese la nueva cantidad");
                            articulos[i, j] = Console.ReadLine();
                            break;
                    }
                }
                Console.WriteLine("¿Desea seguir editando articulos? (s/n)");
                seguir = Convert.ToChar(Console.ReadLine());
                if (seguir == 'n')
                {
                    Console.Clear();
                    GestionArticulos();
                }
            }
        }        
    }
}
