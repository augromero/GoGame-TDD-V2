using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Go.Entidades
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaInicio { get; set; }

        public int JugadorBlancoId { get; set; }

        public int JugadorNegroId { get; set;  }

        [ForeignKey("IdJugadorBlanco")]
        public Jugador JugadorBlanco { get; set; }

        [ForeignKey("IdJugadorNegro")]
        public Jugador JugadorNegro { get; set; }


    }
}
