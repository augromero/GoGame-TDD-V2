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

        public async Task CrearPuntosTableroAsync(int dimension)
        {
            Punto punto;
            List<Punto> puntos = new List<Punto>();
            for (int x = 1; x <= dimension; x++)
            {
                for (int y = 1; y <= dimension; y++)
                {
                    punto = _puntoLogica.CrearPunto(dimension, x, y);
                    puntos.Add(punto);
                }
            }

            await _puntoRepositorio.AgregarListaAsync(puntos);
            return;
        }

        public async Task<List<Punto>> ObtenerTableroAsync(int dimension)
        {
            if (await ExisteTableroAsync(dimension) is false)
                await CrearPuntosTableroAsync(dimension);

            return await _puntoRepositorio.ObtenerPuntosPorDimensionTableroAsync(dimension);
        }

        public async Task<bool> ExisteTableroAsync(int dimension)
        {
            List<Punto> puntosTablero = await _puntoRepositorio.ObtenerPuntosPorDimensionTableroAsync(dimension);

            if (puntosTablero.Count > 0)
                return true;

            return false;
        }
    }
}
