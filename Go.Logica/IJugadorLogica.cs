using Go.Entidades;

namespace Go.Logica
{
    public interface IJugadorLogica
    {
        Jugador Crear(string nombre);
    }
}