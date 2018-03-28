using Go.Entidades;
using Go.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Go.Logica
{
    public class Tablero : ITablero
    {
        private IPuntoLogica _puntoLogica;
        private IPuntoRepositorio _puntoRepositorio;

        public Tablero(IPuntoLogica puntoLogica, IPuntoRepositorio puntoRepositorio)
        {
            _puntoLogica = puntoLogica;
            _puntoRepositorio = puntoRepositorio;
        }

        public async Task CrearTableroAsync(int dimension)
        {
            Punto punto;
            for (int x = 1; x <= dimension; x++)
            {
                for (int y = 1; y <= dimension; y++)
                {
                    punto = _puntoLogica.CrearPunto(dimension, x, y);

                    Task guardarPunto = _puntoRepositorio.AgregarAsync(punto);
                    await guardarPunto;
                }
            }
        }

        public async Task<List<Punto>> ObtenerTableroAsync(int dimension)
        {
            return await _puntoRepositorio.ObtenerPuntosPorDimensionTableroAsync(dimension);
        }
    }
}
