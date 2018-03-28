using System.Threading.Tasks;

namespace Go.Logica
{
    public interface ITablero
    {
        Task CrearTableroAsync(int dimension);
    }
}