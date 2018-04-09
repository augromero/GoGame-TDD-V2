using System;
using System.ComponentModel.DataAnnotations;

namespace Go.Entidades
{
    public class Movimiento
    {
        
        public int Id { get; set; }
        public int OrdenMovimiento { get; set; }
        public int PartidaId { get; set; }
        public int JugadorId { get; set; }
        public string PuntoId { get; set; }
        public Color color { get; set; }

    }
}
