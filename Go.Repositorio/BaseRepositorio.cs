using Go.Logica.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Repositorio
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity>
        where TEntity: class 
    {
        private CoreContext _contexto;

        public BaseRepositorio(CoreContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> ActualizarAsync(int id, TEntity entidad)
        {
            _contexto.Set<TEntity>().Update(entidad);
            await _contexto.SaveChangesAsync();
            return 1;

        }

        public async Task<int> AgregarAsync(TEntity entidad)
        {
            await _contexto.Set<TEntity>().AddAsync(entidad);
            await _contexto.SaveChangesAsync();
            return 1;
        }

        public async Task<int> AgregarListaAsync(List<TEntity> entidades)
        {
            foreach (TEntity entidad in entidades)
            {
                await _contexto.Set<TEntity>().AddAsync(entidad);
            }
            await _contexto.SaveChangesAsync();
            return entidades.Count;
        }


        public async Task<int> EliminarPorIdAsync<TypeId>(TypeId id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            _contexto.Set<TEntity>().Remove(entidad);
            await _contexto.SaveChangesAsync();
            return 1;
        }

        public IQueryable<TEntity> EncontrarTodos()
        {
            IQueryable<TEntity> entidades = _contexto.Set<TEntity>();
            return entidades;
        }

        public async Task<TEntity> ObtenerPorIdAsync<TypeId>(TypeId id)
        {
            return await _contexto.Set<TEntity>().FindAsync(id);
        }
    }

    
}
