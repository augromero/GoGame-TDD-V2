using Go.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Logica.RepoInterfaces
{
    public interface IPuntoRepositorio : IBaseRepositorio<Punto>
    {
        Task<List<Punto>> ObtenerPuntosPorDimensionTableroAsync(int dimension);
    }
}
