using System;
using System.Threading.Tasks;
using Go.Entidades;
using Go.InterfacesLogica;

namespace Go.Logica
{
    public class Juego
    {
        private IPartidaServicio _partidaServicio;
        private IJugadorServicio _jugadorServicio;

       

        public Juego(IPartidaServicio partidaServicio, IJugadorServicio jugadorServicio)
        {
            _partidaServicio = partidaServicio;
            _jugadorServicio = jugadorServicio;

        }

        public async Task<Partida> CrearNuevoJuego(int tamaño, string nombreNegro, string nombreBlanco)
        {
            int idJugadorNegro = await _jugadorServicio.CrearAsync(nombreNegro);
            int idJugadorBlanco = await _jugadorServicio.CrearAsync(nombreBlanco);

            int idPartida = await _partidaServicio.Guardar(tamaño, idJugadorBlanco, idJugadorNegro);

            Partida partidaCreada = await _partidaServicio.ObtenerPorId(idPartida);

            return partidaCreada;
        }
    }
}
