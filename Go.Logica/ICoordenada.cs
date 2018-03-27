namespace Go.Logica
{
    public interface ICoordenada
    {
        string ObtenerLiteral(int dimension, int x, int y);
        string ObtenerLiteralPuntoDerecha(int dimension, int x, int y);
        string ObtenerLiteralPuntoIzquierda(int dimension, int x, int y);
        string ObtenerLiteralPuntoArriba(int dimension, int x, int y);
        string ObtenerLiteralPuntoAbajo(int dimension, int x, int y);
    }
}