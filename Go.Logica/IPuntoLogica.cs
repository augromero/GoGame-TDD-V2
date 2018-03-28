using Go.Entidades;

namespace Go.Logica
{
    public interface IPuntoLogica
    {
        Punto CrearPunto(int dimension, int x, int y);
    }
}