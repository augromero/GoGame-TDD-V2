using Go.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Go.Logica
{
    public interface ITablero
    {
        Task CrearTableroAsync(int dimension);
        Task<List<Punto>> ObtenerTableroAsync(int dimension);
    }
}