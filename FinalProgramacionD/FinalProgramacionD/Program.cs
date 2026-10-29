using System;
using System.Runtime.Versioning;
using System.Threading;
using System.Xml.Serialization;

namespace FinalProgramacionD
{
    internal class Program
    {

        static string[,] usuarios = new string[20, 6];
        static string[,] articulos = new string[20, 4];
        static int[] filasCarrito = new int[20];
        static int[] cantidadesCarrito = new int[20];
        static int itemsCarrito = 0;
        
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
                if (id == usuarios[i, 0])
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
            Console.WriteLine("Nombre: " + usuarios[usuario, 1]);
            Console.WriteLine("Apellido: " + usuarios[usuario, 2]);
            Console.WriteLine("Direccion: " + usuarios[usuario, 3]);
            Console.WriteLine("Telefono: " + usuarios[usuario, 4]);
            Console.WriteLine("Email: " + usuarios[usuario, 5]);
            SeleccionArticulos();
            GenerarFactura(usuario);
        }

        static void GenerarFactura(int fila)
        {
            if (itemsCarrito == 0)
            {
                Console.WriteLine("No se seleccionaron articulos, no se genera factura");
                return;
            }

            Console.WriteLine($"Factura generada para el usuario: {usuarios[fila, 1]} {usuarios[fila, 2]}");
            Console.WriteLine("CC: " + usuarios[fila, 0]);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Articulo | Precio | Cantidad | Subtotal");

            int total = 0;

            for (int i = 0; i < itemsCarrito; i++)
            {
                int filaArticulo = filasCarrito[i];
                int cantidad = cantidadesCarrito[i];
                int precio = int.Parse(articulos[filaArticulo, 2]);
                int subtotal = precio * cantidad;

                total = total + subtotal;

                Console.WriteLine($"{articulos[filaArticulo, 1]} | ${precio} | {cantidad} | ${subtotal}");

                int stock = int.Parse(articulos[filaArticulo, 3]);
                articulos[filaArticulo, 3] = (stock - cantidad).ToString();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Total a pagar: ${total}");

            itemsCarrito = 0;
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        static int BuscarArticulo(string id)
        {
            for (int i = 0; i < articulos.GetLength(0); i++)
            {
                if (id == articulos[i, 0]) return i;
            }
            return -1;
        }

        static void SeleccionArticulos()
        {
            string seguir = "s";
            while (seguir == "s" && itemsCarrito < filasCarrito.Length)
            {
                VerArticulos();
                Console.WriteLine("Ingrese el id del articulo");
                int fila = BuscarArticulo(Console.ReadLine());
                if (fila == -1)
                {
                    Console.WriteLine("Articulo no encontrado");
                    continue;                       
                }

                int stock = int.Parse(articulos[fila, 3]);
                Console.WriteLine($"Ingrese la cantidad (disponible: {stock})");
                int cantidad = int.Parse(Console.ReadLine());
                if (cantidad <= 0 || cantidad > stock)
                {
                    Console.WriteLine("Cantidad no valida");
                    continue;
                }
                filasCarrito[itemsCarrito] = fila;
                cantidadesCarrito[itemsCarrito] = cantidad;
                itemsCarrito++;
                Console.WriteLine("¿Agregar otro articulo? (s/n)");
                seguir = Console.ReadLine();
            }
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
                    Menu();
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
                cantidad++;
                if (seguir == 'n')
                {

                    Console.Clear();
                    GestionArticulos();
                }
                
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
