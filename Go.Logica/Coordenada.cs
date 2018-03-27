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
            if (x == dimension)
                return null;

            string puntoDerecha = ObtenerLiteral(dimension, x + 1, y);

            return puntoDerecha;
        }

        public string ObtenerLiteralPuntoIzquierda(int dimension, int x, int y)
        {
            if (x == 1)
                return null;

            string puntoIzquierda = ObtenerLiteral(dimension, x - 1, y);

            return puntoIzquierda;
        }

        public string ObtenerLiteralPuntoArriba(int dimension, int x, int y)
        {
            if (y == dimension)
                return null;

            string puntoArriba = ObtenerLiteral(dimension, x, y + 1);

            return puntoArriba;
        }

        public string ObtenerLiteralPuntoAbajo(int dimension, int x, int y)
        {
            if (y == 1)
                return null;

            string puntoAbajo = ObtenerLiteral(dimension, x, y - 1);

            return puntoAbajo;
        }
    }
}
