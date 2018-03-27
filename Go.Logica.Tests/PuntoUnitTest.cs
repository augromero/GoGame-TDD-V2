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
            int x = 2;
            int y = 2;

            Punto punto = _punto.CrearPunto(dimension, x, y);

            Assert.AreEqual("3B2", punto.Id);
            Assert.AreEqual(dimension, punto.DimensionTablero);
            Assert.AreEqual(x, punto.X);
            Assert.AreEqual(y, punto.Y);
            Assert.AreEqual("3C2", punto.IdPuntoDerecha);
            Assert.AreEqual("3A2", punto.IdPuntoIzquierda);
            Assert.AreEqual("3B1", punto.IdPuntoAbajo);
            Assert.AreEqual("3B3", punto.IdPuntoArriba);
        }
    }
}