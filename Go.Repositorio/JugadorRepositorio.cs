using System;
using Go.Entidades;
using Go.Logica.RepoInterfaces;

namespace Go.Repositorio
{
    public class JugadorRepositorio : BaseRepositorio<Jugador>
    {
        public JugadorRepositorio(CoreContext contexto) : base(contexto)
        {
        }

    }
}
