using Go.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Go.Logica
{
    public interface ITablero
    {
        Task CrearPuntosTableroAsync(int dimension);
        Task<List<Punto>> ObtenerTableroAsync(int dimension);
        Task<bool> ExisteTableroAsync(int dimension);
    }
}