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

            int x = 1;
            int y = 1;

            string literalCoordenada = _coordenada.ObtenerLiteral(x, y);

            Assert.AreEqual("A1", literalCoordenada);
        }
    }
}
