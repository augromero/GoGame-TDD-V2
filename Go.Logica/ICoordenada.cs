namespace Go.Logica
{
    public interface ICoordenada
    {
        string ObtenerLiteral(int dimension, int x, int y);
        string ObtenerLiteralPuntoDerecha(int dimension, int x, int y);
    }
}