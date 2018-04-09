using System;
using System.Threading.Tasks;
using Go.Entidades;
using Go.Logica;
using Go.Logica.RepoInterfaces;
using Go.Repositorio;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Go.Servicios.Tests
{
    [TestFixture]
    public class JugadorServicioUnitTest
    {
        private IJugadorRepositorio _jugadorRepositorio;
        private JugadorServicio _jugadorServicio;

        [SetUp]
        public void Inicializar()
        {
            var _options = new DbContextOptionsBuilder<CoreContext>()
                .UseInMemoryDatabase(databaseName:  Guid.NewGuid().ToString())
                .Options;

            _jugadorRepositorio = new JugadorRepositorio(new CoreContext(_options));
            _jugadorServicio = new JugadorServicio(_jugadorRepositorio);
        }

        [Test]
        public async Task CuandoIngresaNombreCreaJugador()
        {
            string nombre = "Jugador Blanco";

            int jugadorId = await _jugadorServicio.CrearAsync(nombre);

            Jugador jugador = await _jugadorServicio.ObtenerPorId(jugadorId);

            Assert.AreEqual(nombre, jugador.Nombre);
        }
    }
}
