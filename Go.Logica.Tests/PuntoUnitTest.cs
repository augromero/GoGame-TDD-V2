using Go.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Logica.Tests
{
    [TestClass]
    public class PuntoUnitTest
    {
        private PuntoLogica _punto;
        private ICoordenada _coordenada;

        [TestInitialize]
        public void Inicializar()
        {
            _coordenada = new Coordenada();
            _punto = new PuntoLogica(_coordenada);
        }

        [TestMethod]
        public void CunadoIngresaDimensionTableroCoordenadaCreaPunto()
        {
            int dimension = 3;
            int x = 1;
            int y = 1;

            Punto punto = _punto.CrearPunto(dimension, x, y);

            Assert.AreEqual("3A1", punto.Id);
            Assert.AreEqual(dimension, punto.DimensionTablero);
            Assert.AreEqual(x, punto.X);
            Assert.AreEqual(y, punto.Y);
            Assert.AreEqual("3B1", punto.IdPuntoDerecha);
        }
    }
}