using Go.API.Controllers;
using Go.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Extensiones;

namespace Go.Logica.Tests
{
    [TestClass]
    public class TableroControllerUnitTest
    {
        private Mock<ITablero> _tablero;
        private TableroController _tableroController;

        [TestInitialize]
        public void Inicializar()
        {
            _tablero = new Mock<ITablero>();
            _tableroController = new TableroController(_tablero.Object);
        }

        [TestMethod]
        public async Task CuandoIngresaDimensionTableroRetornaPuntosDelTablero()
        {
            List<Punto> puntosEsperados = new List<Punto>() { new Punto { Id ="3A1"}, new Punto { Id = "3A2"} };

            int dimension = 3;

            _tablero.Setup(metodo => metodo.ObtenerTableroAsync(It.IsNotNull<int>()))
                .Returns(async () => {
                    await Task.Yield();
                    return puntosEsperados;
                });

            OkObjectResult resultado = await _tableroController.ObtenerTableroAsync(dimension) as OkObjectResult;
            

            Assert.IsTrue(puntosEsperados.ListasIguales((List<Punto>)resultado.Value));
        }
    }
}