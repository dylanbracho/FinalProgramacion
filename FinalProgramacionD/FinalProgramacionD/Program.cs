using System;
using System.Xml.Serialization;

namespace FinalProgramacionD
{
    internal class Program
    {
        static string [,] articulos = new string[20, 4];
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("-------------menu---------------");
            Console.WriteLine("1.Gestionar usuarios       2.Gestionar Articulos");
            Console.WriteLine("3.Gestionar Ventas         4.Salir del programa");
            int i;
            i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:

                  break;
                case 2:
                    GestionArticulos();
                    break;
                case 3:

                    break;
                case 4:

                    break;

                default:
                    break;  
            }
        }
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
