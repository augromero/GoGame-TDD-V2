using System;

namespace Go.Logica
{
    public class Coordenada
    {
        const int unicodeAntesDeLetraA = 64;
        public string ObtenerLiteral(int x, int y)
        {
            int unicodeCoordenadaX = unicodeAntesDeLetraA + x;
            string literalCoordenadaX = ((char)unicodeCoordenadaX).ToString();

            return literalCoordenadaX + y;
        }
    }
}
