using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Logica.RepoInterfaces
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        IQueryable<TEntity> EncontrarTodos();

        Task<TEntity> ObtenerPorIdAsync<TypeId>(TypeId id);

        Task<int> AgregarAsync(TEntity entidad);

        Task<int> AgregarListaAsync(List<TEntity> entidades);

        Task<int> ActualizarAsync(int id, TEntity entidad);

        Task<int> EliminarPorIdAsync<TypeId>(TypeId id);

    }
}
