using Go.Entidades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Extensiones;
using Go.Logica.RepoInterfaces;
using Moq;
using Go.Logica;
using Microsoft.EntityFrameworkCore;
using Go.Repositorio;

namespace Go.Servicios.Tests
{
    [TestFixture]
    public class PartidaServicioUnitTest
    {
        private PartidaServicio _partidaServicio;
        private PartidaRepositorio _partidaRepositorio;

        [SetUp]
        public void Inicializar()
        {
            var _option = new DbContextOptionsBuilder<CoreContext>()
             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
             .Options;

            _partidaRepositorio = new PartidaRepositorio(new CoreContext(_option));
            _partidaServicio = new PartidaServicio(_partidaRepositorio);

        }

        [Test]
        public async Task CuandoIngresaTamañoIdsJugadoresCreaNuevapartida()
        {
            int tamaño = 9;
            int idJugadorBlanco = 1;
            int idJugadorNegro = 2;

            int idPartida = await _partidaServicio.Guardar(tamaño, idJugadorBlanco, idJugadorNegro);
            Partida partidaObtenida = await _partidaServicio.ObtenerPorId(idPartida);

            Assert.AreEqual(tamaño, partidaObtenida.tamañoTablero);
            Assert.AreEqual(idJugadorBlanco, partidaObtenida.JugadorBlancoId);
            Assert.AreEqual(idJugadorNegro, partidaObtenida.JugadorNegroId);
        }

        [Test]
        public async Task CuandoIngresaIdPartidaExistenteRetornaPartida()
        {
            int idPartida = await _partidaServicio.Guardar(19, 1, 2);

            Partida partidaObtenida = await _partidaServicio.ObtenerPorId(idPartida);

            Assert.AreEqual(idPartida, partidaObtenida.Id);
        }

        [Test]
        public void CuandoIngresaIdPartidaInexistenteRetornaError()
        {
            Assert.ThrowsAsync(Is.TypeOf<KeyNotFoundException>().And.Message.EqualTo("No existe la partida."),
                               async delegate
                               {
                                   Partida partidaObtenida = await _partidaServicio.ObtenerPorId(-1);
                               });
        }
    }
}
