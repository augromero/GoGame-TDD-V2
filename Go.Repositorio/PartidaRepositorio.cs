using System;
using Go.Entidades;
using Go.Logica.RepoInterfaces;

namespace Go.Repositorio
{
    public class PartidaRepositorio : BaseRepositorio<Partida>, IPartidaRepositorio
    {
        public PartidaRepositorio(CoreContext contexto) : base(contexto)
        {
        }
    }
}
