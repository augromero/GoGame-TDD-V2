using System.Threading.Tasks;
using Go.Entidades;

namespace Go.InterfacesLogica
{
    public interface IJugadorServicio
    {
        Task<int> CrearAsync(string nombre);
        Task<Jugador> ObtenerPorId(int jugadorId);
    }
}