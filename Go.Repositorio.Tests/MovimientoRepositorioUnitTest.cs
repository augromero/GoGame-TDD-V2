using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Go.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Repositorio.Tests
{
    [TestClass]
    public class MovimientoRepositorioUnitTest
    {
        private MovimientoRepositorio _movimientoRepositorio;
        private Faker<Movimiento> fakerInicial;
        private List<Movimiento> movimientosIniciales;

        [TestInitialize]
        public async Task Inicializar()
        {
            var _option = new DbContextOptionsBuilder<CoreContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            _movimientoRepositorio = new MovimientoRepositorio(new CoreContext(_option));

            fakerInicial = new Faker<Movimiento>()
                .StrictMode(false)
                .Rules((fake, objeto) =>
                {
                    objeto.Id = fake.IndexGlobal;
                    objeto.OrdenMovimiento = fake.IndexFaker;
                    objeto.JugadorId = fake.Random.Number(10);
                    objeto.PartidaId = (int)fake.Random.UInt(2, 20);
                    objeto.PuntoId = new Randomizer().Replace("?#");
                    objeto.color = Color.Blanco;
                });
            fakerInicial.UseSeed(1);
            movimientosIniciales = fakerInicial.Generate(20);

            await _movimientoRepositorio.AgregarListaAsync(movimientosIniciales);            
        }

        [TestMethod]
        public async Task CuandoIngresaIdPartidaRetornaUltimoMovimiento()
        {
            
            var movimientosBlancos = new Faker<Movimiento>()
                .StrictMode(false)
                .Rules((fake, objeto) =>
                {
                    objeto.Id = fake.IndexGlobal;
                    objeto.OrdenMovimiento = fake.IndexFaker * 2;
                    objeto.JugadorId = 1;
                    objeto.PartidaId = 1;
                    objeto.PuntoId = new Randomizer().Replace("?#");
                    objeto.color = Color.Blanco;
                });
            movimientosBlancos.UseSeed(1);


            var movimientosNegros = new Faker<Movimiento>()
                .StrictMode(false)
                .Rules((fake, objeto) =>
                {
                    objeto.Id = fake.IndexGlobal;
                    objeto.OrdenMovimiento = fake.IndexFaker * 2 + 1;
                    objeto.JugadorId = 2;
                    objeto.PartidaId = 1;
                    objeto.PuntoId = new Randomizer().Replace("?#");
                    objeto.color = Color.Negro;
                });
            movimientosNegros.UseSeed(1);

            List<Movimiento> negros = movimientosNegros.Generate(10);
            List<Movimiento> blancos = movimientosBlancos.Generate(10);
            await _movimientoRepositorio.AgregarListaAsync(blancos);
            await _movimientoRepositorio.AgregarListaAsync(negros);

            int idPartida = 1;
            int idUltimoMovimiento = _movimientoRepositorio.ObtenerUltimoMovimientoPorPartida(idPartida).OrdenMovimiento;

            Assert.AreEqual(19, idUltimoMovimiento);
        }
    }
}
