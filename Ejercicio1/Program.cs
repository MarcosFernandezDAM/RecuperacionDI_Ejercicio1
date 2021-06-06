using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static Videojuego juego;
        static void Main(string[] args)
        {
            Videojuegos v = new Videojuegos();

            Videojuego videojuego2 = new Videojuego("Fortnite", 2017, eEstilo.Shootemup);
            v.videojuegos.Insert(v.Posicion(videojuego2.Anho), videojuego2);

            Videojuego videojuego3 = new Videojuego("Fall guys", 2019, eEstilo.Arcade);
            v.videojuegos.Insert(v.Posicion(videojuego3.Anho), videojuego3);

            Videojuego videojuego1 = new Videojuego("FIFA 21", 2020, eEstilo.Deportivo);
            v.videojuegos.Insert(v.Posicion(videojuego1.Anho), videojuego1);

            int opcion = 0;
            do
            {
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("1.- Insertar un nuevo juego");
                Console.WriteLine("2.- Eliminar videojuegos");
                Console.WriteLine("3.- Visualizar lista de videojuegos");
                Console.WriteLine("4.- Visualizar videojuegos de un estilo determinado");
                Console.WriteLine("5.- Modificar videojuego");
                Console.WriteLine("6.- Salir del programa");
                opcion = PedirInt();
                switch (opcion)
                {
                    case 1:
                        string titulo;
                        int anho;
                        eEstilo est=eEstilo.Arcade;
                        
                        Console.WriteLine("Introduce el título del videojuego");
                        titulo = Console.ReadLine();
                        Console.WriteLine("Introduce el estilo del juego (1: Arcade, 2: Videoaventura, 3: Shootemup, 4: Estrategia, 5: Deportivo)");
                        est=PedirEstilo();
                        Console.WriteLine("Introduce el año del videojuego");
                        anho = PedirInt();

                        juego = new Videojuego(titulo, anho, est);

                        v.videojuegos.Insert(v.Posicion(juego.Anho), juego);
                        Console.WriteLine("Juego: " + juego.Titulo + ". Año: " + juego.Anho + ". Estilo: " + juego.Estilo);

                        break;

                    case 2:
                        int pIn;
                        int pFi;
                        if (v.videojuegos.Count() <= 0)
                        {
                            Console.WriteLine("No hay videojuegos");
                        }
                        else
                        {
                            Console.WriteLine("Dime la posición inicial (entre 0 y " + (v.videojuegos.Count() - 1) + ")");
                            pIn = PedirInt();
                            Console.WriteLine("Dime la posición final (entre 0 y " + (v.videojuegos.Count() - 1) + ")");
                            pFi = PedirInt();
                            String op;

                            if (pIn < 0 || pFi < 0 || pIn > v.videojuegos.Count() || pFi >= v.videojuegos.Count() || pIn > pFi)
                            {
                                Console.WriteLine("Error, posiciones no válidas");
                            }
                            else
                            {
                                for (int i = pIn; i <= pFi; i++)
                                {
                                    Console.WriteLine("Juego: " + v.videojuegos[i].Titulo + " Año: " + v.videojuegos[i].Anho + " Estilo: " + v.videojuegos[i].Estilo);
                                }
                                do
                                {
                                    Console.WriteLine("¿Seguro que quieres borrar los juegos? (S/N)");
                                    op = Console.ReadLine().ToLower();
                                    if (op == "s")
                                    {
                                        Console.WriteLine("Se van a borrar los juegos");
                                        v.Eliminar(pFi, pIn);
                                    }
                                    if (op == "n")
                                    {
                                        Console.WriteLine("No se han borrado los juegos");
                                    }
                                    if (op != "s" && op != "n")
                                    {
                                        Console.WriteLine("Error, opción no válida");
                                    }
                                } while (op != "s" && op != "n");
                            }
                        }


                        break;

                    case 3:
                        if (v.videojuegos.Count() == 0)
                        {
                            Console.WriteLine("No hay videojuegos");
                        }
                        for (int i = 0; i < v.videojuegos.Count(); i++)
                        {
                            Console.WriteLine("{0,2} {1,12} {2,12} {3,12}", i, v.videojuegos[i].Titulo, v.videojuegos[i].Anho, v.videojuegos[i].Estilo);
                        }
                        break;

                    case 4:
                        if (v.videojuegos.Count() == 0)
                        {
                            Console.WriteLine("No hay videojuegos");
                        }
                        else
                        {

                            eEstilo e = eEstilo.Arcade;
                            Console.WriteLine("Dime el estilo que quieres buscar (1: Arcade, 2: Videoaventura, 3: Shootemup, 4: Estrategia, 5: Deportivo)");
                            e = PedirEstilo();
                            v.Busqueda(e);
                            
                        }
                        break;

                    case 5:
                        if (v.videojuegos.Count() == 0)
                        {
                            Console.WriteLine("No hay videojuegos");
                        }
                        else
                        {
                            int pos;
                            String nNombre;
                            eEstilo es=eEstilo.Arcade;
                            int nAnho;
                            Console.WriteLine("Dime la posición del videojuego (entre 0 y " + (v.videojuegos.Count() - 1) + ")");

                            pos = PedirInt();
                            if (pos < 0 || pos > v.videojuegos.Count())
                            {
                                Console.WriteLine("Error, posición no válida");
                            }
                            else
                            {
                                for (int i = 0; i < v.videojuegos.Count(); i++)
                                {
                                    if (i == pos)
                                    {
                                        Console.WriteLine("El juego es: " + v.videojuegos[i].Titulo + " el estilo es: " + v.videojuegos[i].Estilo + " y el año es: " + v.videojuegos[i].Anho);
                                        Console.WriteLine("Dime el nuevo nombre del videojuego");
                                        nNombre = Console.ReadLine();
                                        v.videojuegos[i].Titulo = nNombre;

                                        Console.WriteLine("Dime el nuevo estilo (1: Arcade, 2: Videoaventura, 3: Shootemup, 4: Estrategia, 5: Deportivo)");
                                        es = PedirEstilo();
                                        v.videojuegos[i].Estilo = es;
                                        Console.WriteLine("Dime el nuevo año");
                                        nAnho = PedirInt();
                                        v.videojuegos[i].Anho = nAnho;

                                        Console.WriteLine("Has cambiado con éxito. Los nuevos datos son: \nNombre: " + v.videojuegos[i].Titulo + "\nEstilo: " + v.videojuegos[i].Estilo + "\nAño: " + v.videojuegos[i].Anho);
                                    }
                                }

                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.WriteLine("Error, valor no válido");
                        break;
                }
            } while (opcion != 6);
        }

        public static eEstilo PedirEstilo()
        {
            eEstilo est = eEstilo.Arcade;
            int num=0;
            do
            {
                try
                {

                    num = Convert.ToInt32(Console.ReadLine());
                    est = (eEstilo)num;
                    if(num>5 || num <= 0)
                    {
                        Console.WriteLine("Error, valor no válido, introduce otro");
                    }
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }
            } while (num > 5 || num <= 0);

            return est;
        }

        public static int PedirInt()
        {
            int num = 0;
            do
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    return num;
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error, valor no válido, introduce otro");
                }

            } while (num == 0);
            return 0;
        }
    }
}