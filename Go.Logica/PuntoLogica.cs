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

            Punto punto = new Punto
            {
                Id = coordenada,
                DimensionTablero = dimension,
                X = x,
                Y = y,
                IdPuntoDerecha = _coordenada.ObtenerLiteralPuntoDerecha(dimension, x, y),
                IdPuntoIzquierda = _coordenada.ObtenerLiteralPuntoIzquierda(dimension, x, y),
                IdPuntoArriba = _coordenada.ObtenerLiteralPuntoArriba(dimension, x, y),
                IdPuntoAbajo = _coordenada.ObtenerLiteralPuntoAbajo(dimension, x, y)
            };

            return punto;
        }
    }
}
