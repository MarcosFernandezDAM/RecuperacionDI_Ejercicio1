using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Videojuegos
    {

        public List<Videojuego> videojuegos = new List<Videojuego>();

        public int Posicion(int anho)
        {
            int posInsercion = 0;

            for (int i = 0; i < videojuegos.Count(); i++)
            {
                if (anho > videojuegos[i].Anho)
                {
                    posInsercion = i + 1;
                }
            }
            
            return posInsercion;
        }

        public bool Eliminar(int posMax, int posMin = 0)
        {
            if (posMin < 0 || posMax < 0 || posMin > videojuegos.Count() || posMax > videojuegos.Count())
            {
                return false;
            }
            else
            {
                if (posMax < posMin)
                {
                   // Console.WriteLine("Error, la posición final no puede ser menor que la posición inicial");
                    return false;
                }
                else
                {
                    for (int i = posMax; i >= posMin; i--)
                    {
                        videojuegos.RemoveAt(i);
                    }
                    return true;
                }

            }
        }

        public List<Videojuego> Busqueda(eEstilo estilo) // sin interface de usuario
        {
            List<Videojuego> juegosEstilo = new List<Videojuego>();
            for (int i = 0; i < videojuegos.Count(); i++)
            {
                if (videojuegos[i].Estilo.Equals(estilo))
                {

                    juegosEstilo.Add(videojuegos[i]);
                }
            }
            if (juegosEstilo.Count() == 0)
            {
                Console.WriteLine("No hay videojuegos con ese estilo");
            }
            else
            {
                for(int i=0; i < juegosEstilo.Count(); i++)
                {
                    Console.WriteLine("{0,2} {1,12} {2,12} {3,12}", i, juegosEstilo[i].Titulo, juegosEstilo[i].Anho, juegosEstilo[i].Estilo);
                }
            }
            return juegosEstilo;
        }
    }
}