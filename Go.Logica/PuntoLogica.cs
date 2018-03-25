using System;
using System.Collections.Generic;
using System.Text;
using Go.Entidades;

namespace Go.Logica
{
    public class PuntoLogica
    {
        private ICoordenada _coordenada;

        public PuntoLogica(ICoordenada coordenada)
        {
            _coordenada = coordenada;
        }

        public Punto CrearPunto(int dimension, int x, int y)
        {
            string coordenada = _coordenada.ObtenerLiteral(dimension, x, y);
            string puntoDerecha = _coordenada.ObtenerLiteralPuntoDerecha(dimension, x, y);

            Punto punto = new Punto
            {
                Id = coordenada,
                DimensionTablero = dimension,
                X = x,
                Y = y,
                IdPuntoDerecha = puntoDerecha
            };

            return punto;
        }
    }
}
