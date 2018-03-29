using System.Collections.Generic;
using System.Linq;

namespace Tests.Extensiones
{
    public static class AssertExt
    {
        public static bool PropiedadesIguales<T>(this T actual, T comparado) where T : class
        {
            var propiedadesObjeto = actual.GetType().GetProperties();

            foreach (var propiedad in propiedadesObjeto)
            {
                if (propiedad.GetValue(actual) == null && propiedad.GetValue(comparado) == null)
                    continue;

                var valorPropiedadActual = propiedad.GetValue(actual);
                var valorPropiedadComparada = propiedad.GetValue(comparado);

                if (valorPropiedadActual is null || valorPropiedadComparada is null)
                    return false;

                if (!(valorPropiedadActual.Equals(valorPropiedadComparada)))
                    return false;
            }

            var camposObjeto = actual.GetType().GetFields();

            foreach (var campo in camposObjeto)
            {
                if (campo.GetValue(actual) == null && campo.GetValue(comparado) == null)
                    continue;

                var valorCampoActual = campo.GetValue(actual);
                var valorCampoComparado = campo.GetValue(comparado);

                if (valorCampoActual is null || valorCampoComparado is null)
                    return false;

                if (!(valorCampoActual.Equals(valorCampoComparado)))
                    return false;
            }
            return true;
        }

        public static bool ListasIguales<T>(this List<T> actual, List<T> comparado) where T : class
        {
            if (actual.Count != comparado.Count)
                return false;

            return actual.TrueForAll(cursorActual =>
                   comparado.Any(cursorComparado =>
                           cursorComparado.PropiedadesIguales(cursorActual)));
        }
    }
}
