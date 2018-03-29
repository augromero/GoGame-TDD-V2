using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go.Entidades;
using Go.Logica;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Go.API.Controllers
{
    public class TableroController : Controller
    {
        private ITablero _tablero;

        public TableroController(ITablero tablero)
        {
            _tablero = tablero;
        }

        [HttpGet]
        [Route("api/Tableros/{dimension}")]
        public async Task<IActionResult> ObtenerTableroAsync(int dimension)
        {
            List<Punto> puntosRetornados = await _tablero.ObtenerTableroAsync(dimension);
            return Ok(puntosRetornados);
        }
    }
}
