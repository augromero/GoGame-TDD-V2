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

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Tablero")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/Tableros/{dimension}")]
        public async Task<IActionResult> ObtenerTableroAsync(int dimension)
        {
            List<Punto> puntosRetornados = await _tablero.ObtenerTableroAsync(dimension);
            return Ok(puntosRetornados);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
