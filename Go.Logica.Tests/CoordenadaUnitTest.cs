using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Logica.Tests
{
    [TestClass]
    public class CoordenadaUnitTest
    {
        Coordenada _coordenada;

        [TestInitialize]
        public void Inicializar()
        {
            _coordenada = new Coordenada();
        }

        [TestMethod]
        public void CuandoIngresa_X1Y1_RetornaA1()
        {
            int dimension = 3;
            int x = 1;
            int y = 1;

            string literalCoordenada = _coordenada.ObtenerLiteral(dimension, x, y);

            Assert.AreEqual("3A1", literalCoordenada);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYRetornaPuntoDerecha()
        {
            int dimension = 3;
            int x = 1;
            int y = 1;

            string puntoDerecha = _coordenada.ObtenerLiteralPuntoDerecha(dimension, x, y);

            Assert.AreEqual("3B1", puntoDerecha);
        }
    }
}
