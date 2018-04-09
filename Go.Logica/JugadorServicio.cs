using System;
using System.Threading.Tasks;
using Go.Entidades;
using Go.InterfacesLogica;
using Go.Logica.RepoInterfaces;

namespace Go.Logica
{
    public class JugadorServicio : IJugadorServicio
    {
        private IJugadorRepositorio _jugadorRepositorio;

        public JugadorServicio(IJugadorRepositorio jugadorRepositorio)
        {
            _jugadorRepositorio = jugadorRepositorio;
        }

        public async  Task<int> CrearAsync(string nombre)
        {
            Jugador jugador = new Jugador()
            {
                Nombre = nombre
            };

            await _jugadorRepositorio.AgregarAsync(jugador);

            return jugador.Id;
        }

        public async Task<Jugador> ObtenerPorId(int jugadorId)
        {
            Jugador jugador = await _jugadorRepositorio.ObtenerPorIdAsync(jugadorId);

            return jugador;
        }
    }
}
