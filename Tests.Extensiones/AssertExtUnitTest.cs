using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests.Extensiones
{
    public class ObjPropiedades
    {
        public int? prop1 { get; set; }
        public int? prop2 { get; set; }
        public int? prop3 { get; set; }
    }

    public class ObjCampos
    {
        public int? campo1;
        public int? campo2;
    }

    [TestClass]
    public class AssertExtUnitTest
    {
        [TestMethod]
        public void CunadoIngresaDosObjetosIgualesPropiedadesIgualesRetornaTrue()
        {
            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = 1,
                prop2 = 2
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = 1,
                prop2 = 2
            };

            Assert.IsTrue(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresaDosObjetosConPropiedadesNulasIgualesRetornaTrue()
        {
            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = null,
                prop2 = 2
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = null,
                prop2 = 2
            };

            Assert.IsTrue(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosVaciosDelMismoTipoPropieadadesIgualesEsTrue()
        {
            ObjPropiedades item1 = new ObjPropiedades();
            ObjPropiedades item2 = new ObjPropiedades();

            Assert.IsTrue(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConPropiedadesDiferentesConNUlosPropiedadesIgualesRetornaFalse()
        {
            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = null,
                prop2 = 2,
                prop3 = 3
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = 1,
                prop2 = null,
                prop3 = 3
            };

            Assert.IsFalse(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConPropiedadesDiferentesSinNulosPropiedadesIgualesRetornaFalse()
        {
            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = 7,
                prop2 = 4,
                prop3 = 3
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = 0,
                prop2 = 9,
                prop3 = 1
            };

            Assert.IsFalse(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConCamposIgualesRetornaTrue()
        {
            ObjCampos item1 = new ObjCampos
            {
                campo1 = 1,
                campo2 = 2
            };

            ObjCampos item2 = new ObjCampos
            {
                campo1 = 1,
                campo2 = 2
            };

            Assert.IsTrue(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConCamposIgualesNulosRetornaTrue()
        {
            ObjCampos item1 = new ObjCampos
            {
                campo1 = null,
                campo2 = 2
            };

            ObjCampos item2 = new ObjCampos
            {
                campo1 = null,
                campo2 = 2
            };

            Assert.IsTrue(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConCamposDiferentesRetornaFalse()
        {
            ObjCampos item1 = new ObjCampos
            {
                campo1 = 2,
                campo2 = 2
            };

            ObjCampos item2 = new ObjCampos
            {
                campo1 = 1,
                campo2 = 2
            };

            Assert.IsFalse(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConCamposConValoresNulosDiferentesRetornaFalse()
        {
            ObjCampos item1 = new ObjCampos
            {
                campo1 = null,
                campo2 = 2
            };

            ObjCampos item2 = new ObjCampos
            {
                campo1 = 1,
                campo2 = null
            };
            Assert.IsFalse(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoIngresoDosObjetosConCamposConValoresDiferentesRetornaFalse()
        {
            ObjCampos item1 = new ObjCampos
            {
                campo1 = 5,
                campo2 = 2
            };

            ObjCampos item2 = new ObjCampos
            {
                campo1 = 1,
                campo2 = 4
            };
            Assert.IsFalse(item1.PropiedadesIguales(item2));
        }

        [TestMethod]
        public void CuandoListasTienenCantidadesDiferentesDeObjetosRetornaFalse()
        {
            List<object> lista1 = new List<object> { 1, 2 };
            List<object> lista2 = new List<object> { 1, 2, 3 };

            Assert.IsFalse(lista1.ListasIguales(lista2));
        }

        [TestMethod]
        public void CunadoListasTienenObjetosIgualesRetornaTrue()
        {

            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = null,
                prop2 = 2,
                prop3 = 3
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = 1,
                prop2 = null,
                prop3 = 3
            };

            List<ObjPropiedades> lista1 = new List<ObjPropiedades> { item1, item2 };
            List<ObjPropiedades> lista2 = new List<ObjPropiedades> { item1, item2 };

            Assert.IsTrue(lista1.ListasIguales(lista2));
        }

        [TestMethod]
        public void CunadoListasTienenObjetosIgualesDesordenadosRetornaTrue()
        {

            ObjPropiedades item1 = new ObjPropiedades()
            {
                prop1 = null,
                prop2 = 2,
                prop3 = 3
            };

            ObjPropiedades item2 = new ObjPropiedades()
            {
                prop1 = 1,
                prop2 = null,
                prop3 = 3
            };

            List<ObjPropiedades> lista1 = new List<ObjPropiedades> { item2, item1 };
            List<ObjPropiedades> lista2 = new List<ObjPropiedades> { item1, item2 };

            Assert.IsTrue(lista1.ListasIguales(lista2));
        }
    }
}