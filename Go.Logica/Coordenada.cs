using System;

namespace Go.Logica
{
    public class Coordenada : ICoordenada
    {
        const int unicodeAntesDeLetraA = 64;
        public string ObtenerLiteral(int dimension, int x, int y)
        {
            int unicodeCoordenadaX = unicodeAntesDeLetraA + x;
            string literalCoordenadaX = ((char)unicodeCoordenadaX).ToString();

            return dimension + literalCoordenadaX + y;
        }

        public string ObtenerLiteralPuntoDerecha(int dimension, int x, int y)
        {
            string puntoDerecha = ObtenerLiteral(dimension, x + 1, y);

            return puntoDerecha;
        }
    }
}
