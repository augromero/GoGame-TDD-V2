using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Repositorio.Tests
{
    [TestClass]
    public class PartidaRepositorioUnitTest
    {
        private PartidaRepositorio _partidaRepositorio;

        [TestInitialize]
        public void Inicializar()
        {
            var _option = new DbContextOptionsBuilder<CoreContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            
            _partidaRepositorio = new PartidaRepositorio(new CoreContext(_option));

        }

    }
}
