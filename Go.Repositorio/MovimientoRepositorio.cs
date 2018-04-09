using System;
using System.Linq;
using System.Threading.Tasks;
using Go.Entidades;

namespace Go.Repositorio
{
    public class MovimientoRepositorio : BaseRepositorio<Movimiento>
    {
        public MovimientoRepositorio(CoreContext contexto) : base(contexto)
        {
        }

		public Movimiento ObtenerUltimoMovimientoPorPartida(int idPartida)
		{
            Movimiento ultimoMovimiento = EncontrarTodos()
                .Where(movimiento => movimiento.PartidaId == idPartida)
                .OrderBy(movimiento => movimiento.OrdenMovimiento)
                .LastOrDefault();

            return ultimoMovimiento;
		}
	}
}
