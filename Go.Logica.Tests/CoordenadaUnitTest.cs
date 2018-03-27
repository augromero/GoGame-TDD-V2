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

        [TestMethod]
        public void CuandoIngresaDimensionesXYEnBordeDerechoRetornaNull()
        {
            int dimension = 3;
            int x = 3;
            int y = 1;

            string puntoDerecha = _coordenada.ObtenerLiteralPuntoDerecha(dimension, x, y);

            Assert.IsNull(puntoDerecha);
        }

        [TestMethod]
        public void CuandoIngresaDimensionesXYRetornaPuntoIzquierda()
        {
            int dimension = 3;
            int x = 2;
            int y = 1;

            string puntoIzquierda = _coordenada.ObtenerLiteralPuntoIzquierda(dimension, x, y);

            Assert.AreEqual("3A1", puntoIzquierda);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYEnBordeIzquierdoRetornaPuntoIzquierdoNull()
        {
            int dimension = 3;
            int x = 1;
            int y = 1;

            string puntoIzquierdo = _coordenada.ObtenerLiteralPuntoIzquierda(dimension, x, y);

            Assert.IsNull(puntoIzquierdo);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYRetornaPuntoArriba()
        {
            int dimension = 3;
            int x = 1;
            int y = 1;

            string puntoArriba = _coordenada.ObtenerLiteralPuntoArriba(dimension, x, y);

            Assert.AreEqual("3A2", puntoArriba);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYEnBordeSuperiorRetornaPuntoArribaNull()
        {
            int dimension = 3;
            int x = 1;
            int y = 3;

            string puntoArriba = _coordenada.ObtenerLiteralPuntoArriba(dimension, x, y);

            Assert.IsNull(puntoArriba);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYRetornaPuntoAbajo()
        {
            int dimension = 3;
            int x = 1;
            int y = 2;

            string puntoAbajo = _coordenada.ObtenerLiteralPuntoAbajo(dimension, x, y);

            Assert.AreEqual("3A1", puntoAbajo);
        }

        [TestMethod]
        public void CuandoIngresaDimensionXYEnBordeInferiorRetornaPuntoAbajoNull()
        {
            int dimension = 3;
            int x = 2;
            int y = 1;

            string puntoAbajo = _coordenada.ObtenerLiteralPuntoAbajo(dimension, x, y);

            Assert.IsNull(puntoAbajo);
        }
    }
}
