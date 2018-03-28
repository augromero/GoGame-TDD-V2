using Go.Entidades;
using Go.Logica;
using Go.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go.Repositorio.Tests
{
    [TestClass]
    public class PuntoRepositorioUnitTest
    {
        private PuntoRepositorio _puntoRepositorio;
        private PuntoLogica _puntoLogica;

        private async Task AgregarPunto(int dimension, int x, int y)
        {
            Punto punto = _puntoLogica.CrearPunto(dimension, x, y);
            Task guardarPunto = _puntoRepositorio.AgregarAsync(punto);
            await guardarPunto;
        }

        [TestInitialize]
        public async Task Inicializar()
        {
            _puntoLogica = new PuntoLogica(new Coordenada());
            
            var _option = new DbContextOptionsBuilder<CoreContext>()
                .UseInMemoryDatabase(databaseName: "Punto")
                .Options;

            _puntoRepositorio = new PuntoRepositorio(new CoreContext(_option));

            await AgregarPunto(3, 1, 1);
            await AgregarPunto(3, 1, 2);
            await AgregarPunto(4, 1, 1);

        }

        [TestMethod]
        public async Task CuandoIngresaPuntoGuardaEnRepositorio()
        {

            Task<Punto> obtenerPuntoTask = _puntoRepositorio.ObtenerPorIdAsync<string>("3A1");

            Punto puntoRetornado = await obtenerPuntoTask;

            Assert.AreEqual("3A1", puntoRetornado.Id);
        }

        [TestMethod]
        public async Task CuandoIngresaDimensionTableroRetornaPuntosTablero()
        {
            

            int dimension = 3;

            Task<List<Punto>> obtenerPuntosTask = _puntoRepositorio.ObtenerPuntosPorDimensionTableroAsync(dimension);
            List<Punto> puntosRetornados = await obtenerPuntosTask;

            Assert.AreEqual(2, puntosRetornados.Count);
        }

        private async Task EliminarPunto(string idPunto)
        {
            Task eliminarTask = _puntoRepositorio.EliminarPorIdAsync(idPunto);
            await eliminarTask;
        }

        [TestCleanup]
        public async Task Limpiar()
        {
            await EliminarPunto("3A1");
            await EliminarPunto("3A2");
            await EliminarPunto("4A1");
        }
    }
}