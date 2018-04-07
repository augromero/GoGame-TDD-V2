using System;
using Go.Entidades;

namespace Go.Logica
{
    public class JugadorLogica : IJugadorLogica
    {
        public Jugador Crear(string nombre)
        {
            Jugador jugador = new Jugador
            {
                Nombre = nombre
            };

            return jugador;
        }
    }
}