using System;
using System.Threading.Tasks;
using Go.Entidades;
using Go.InterfacesLogica;
using Go.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Go.Logica.Tests
{
    [TestClass]
    public class JuegoUnitTest
    {
        private CoreContext _contexto;
        private IJugadorServicio _jugadorServicio;
        private IPartidaServicio _partidaServicio;
        private Juego _juego;

        [TestInitialize]
        public void Inicializar()
        {

            var _option = new DbContextOptionsBuilder<CoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _contexto = new CoreContext(_option);
            _jugadorServicio = new JugadorServicio(new JugadorRepositorio(_contexto));
            _partidaServicio = new PartidaServicio(new PartidaRepositorio(_contexto));

            _juego = new Juego(_partidaServicio, _jugadorServicio);
        }

        [TestMethod]
        public async Task CuandoIngresaNombreJugadoresYTamañoTableroCreaPartidaConJugadores()
        {
            string nombreBlanco = "blanco";
            string nombreNegro = "negro";
            int tamaño = 9;


            Partida partidaCreada = await _juego.CrearNuevoJuego(tamaño, nombreNegro, nombreBlanco);

            Assert.AreEqual(nombreBlanco, partidaCreada.JugadorBlanco.Nombre);
        }
    }
}
