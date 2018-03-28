using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go.Logica;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Go.API.Controllers
{
    [Route("api/[controller]")]
    public class TableroController : Controller
    {
        private ITablero _tablero;

        public TableroController(ITablero tablero)
        {
            _tablero = tablero;
        }

        // GET: api/<controller>
        [HttpGet]
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

        public Task<OkObjectResult> ObtenerTablero(object dimension)
        {
            throw new NotImplementedException();
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
