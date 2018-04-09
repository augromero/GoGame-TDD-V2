using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go.Entidades;
using Go.InterfacesLogica;
using Go.Logica.RepoInterfaces;

namespace Go.Logica
{
    public class PartidaServicio : IPartidaServicio
    {
        private IPartidaRepositorio _partidaRepositorio;

        public PartidaServicio(IPartidaRepositorio partidaRepositorio)
        {
            _partidaRepositorio = partidaRepositorio;
        }

        public async Task<int> Guardar(int tamaño, int idJugadorBlanco, int idJugadorNegro)
        {
            Partida partidaAGuardar = new Partida
            {
                tamañoTablero = tamaño,
                JugadorNegroId = idJugadorNegro,
                JugadorBlancoId = idJugadorBlanco
            };

            await _partidaRepositorio.AgregarAsync(partidaAGuardar);
            return partidaAGuardar.Id;
        }

        public async Task<Partida> ObtenerPorId(int idPartida)
        {
            Partida partida= await _partidaRepositorio.ObtenerPorIdAsync(idPartida);

            if (partida == null)
                throw new KeyNotFoundException("No existe la partida.");

            return partida;
        }
    }
}
