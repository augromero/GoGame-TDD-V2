using System;
using System.Collections.Generic;
using System.Text;

namespace Go.Entidades
{
    public class Punto
    {
        public string Id { get; set; }
        public int DimensionTablero { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string IdPuntoDerecha { get; set; }
        public string IdPuntoIzquierda { get; set; }
        public string IdPuntoAbajo { get; set; }
        public string IdPuntoArriba { get; set; }
    }
}
