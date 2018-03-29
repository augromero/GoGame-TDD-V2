using Go.Entidades;
using Go.Logica.Interfaces;
using Go.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go.Logica.Tests
{
    [TestClass]
    public class TableroUnitTest
    {
        private IPuntoLogica _puntoLogica;
        private ICoordenada _coordenada;

        private Tablero _tablero;
        private IPuntoRepositorio _puntoRepositorio; 

        [TestInitialize]
        public void Inicializar()
        {
            var _option = new DbContextOptionsBuilder<CoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _puntoRepositorio = new PuntoRepositorio(new CoreContext(_option));

            _coordenada = new Coordenada();
            _puntoLogica = new PuntoLogica(_coordenada);
            _tablero = new Tablero(_puntoLogica, _puntoRepositorio);
        }

        [TestMethod]
        public async Task CuandoIngersaDimensionesCreaPuntosDelTablero()
        {
            int dimension = 3;

            Task guardarPuntos = _tablero.CrearPuntosTableroAsync(dimension);
            await guardarPuntos;

            List<Punto> puntosGuardados = await _puntoRepositorio.ObtenerPuntosPorDimensionTableroAsync(dimension);

            Assert.AreEqual(9, puntosGuardados.Count);
            Assert.AreEqual("3C3", puntosGuardados.Find(punto => punto.Id == "3C3").Id);
        }

        [TestMethod]
        public async Task CuandoIngresaDimensionesYNoExistenCreaTableroYRetornaPuntosDelTablero()
        {
            int dimension = 3;

            List<Punto> puntosTablero = await _tablero.ObtenerTableroAsync(dimension);

            Assert.AreEqual(9, puntosTablero.Count);
        }

        [TestMethod]
        public async Task CuandoIngresaDimensionesRetornaFalseSiTableroNoExiste()
        {
            int dimension = 3;

            bool existeTablero = await _tablero.ExisteTableroAsync(dimension);

            Assert.IsFalse(existeTablero);
        }

        [TestMethod]
        public async Task CuandoIngresaDimensionesRetornaTrueSiTableroExiste()
        {
            int dimension = 3;

            Task guardarPuntos = _tablero.CrearPuntosTableroAsync(dimension);
            await guardarPuntos;

            bool existeTablero = await _tablero.ExisteTableroAsync(dimension);

            Assert.IsTrue(existeTablero);
        }
    }
}