using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public enum eEstilo
    {
        Arcade=1,
        Videoaventura,
        Shootemup,
        Estrategia,
        Deportivo
    }
    class Videojuego
    {
        public string Titulo { set; get; }
        public int Anho { set; get; }

        public eEstilo Estilo { set; get; }

        public Videojuego(string titulo, int anho, eEstilo estilo)
        {
            Titulo = titulo;
            Anho = anho;
            Estilo = estilo;
        }
    }
}
