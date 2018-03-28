﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Logica.Interfaces
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        IQueryable<TEntity> EncontrarTodos();

        Task<TEntity> ObtenerPorIdAsync<TypeId>(TypeId id);

        Task AgregarAsync(TEntity entidad);

        Task ActualizarAsync(int id, TEntity entidad);

        Task EliminarPorIdAsync<TypeId>(TypeId id);

    }
}
