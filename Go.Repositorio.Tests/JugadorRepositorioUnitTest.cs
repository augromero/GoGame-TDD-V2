using System;
using System.Threading.Tasks;
using Go.Entidades;
using Go.Logica;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Repositorio.Tests
{
    [TestClass]
    public class JugadorRepositorioUnitTest
    {
        private JugadorRepositorio _jugadorRepositorio;

        [TestInitialize]
        public void Inicializar()
        {
            var _option = new DbContextOptionsBuilder<CoreContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            
            _jugadorRepositorio = new JugadorRepositorio(new CoreContext(_option));
        }


    }
}