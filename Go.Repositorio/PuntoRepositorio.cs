using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Go.Entidades;
using Go.Logica.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace Go.Repositorio
{
    public class PuntoRepositorio : BaseRepositorio<Punto>, IPuntoRepositorio
    {

        public PuntoRepositorio(CoreContext contexto) : base(contexto)
        {
        }

        public async Task<List<Punto>> ObtenerPuntosPorDimensionTableroAsync(int dimension)
        {
            Task<List<Punto>> obtenerPuntos = EncontrarTodos()
                .Where(punto => punto.DimensionTablero == dimension)
                .ToListAsync();

            List<Punto> puntos = await obtenerPuntos;
            return puntos;
        }
    }

    
}
