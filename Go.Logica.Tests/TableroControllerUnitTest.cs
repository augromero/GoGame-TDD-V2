using Go.API.Controllers;
using Go.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            List<Punto> puntosEsperados = new List<Punto>();

            int dimension = 3;

           // _tablero.Setup(metodo => metodo.)

            OkObjectResult puntosTablero = await _tableroController.ObtenerTablero(dimension);

            Assert.IsInstanceOfType(puntosTablero.Value.GetType(), typeof(List<Punto>));
        }
    }
}