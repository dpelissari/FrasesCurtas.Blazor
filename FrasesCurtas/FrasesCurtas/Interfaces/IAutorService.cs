using FrasesCurtas.Models;

namespace FrasesCurtas.Interfaces
{
    public interface IAutorService
    {

        // assinatura dos metodos a serem implemntados
        Task Adicionar(Autor autor);
        Task Atualizar(Autor autor);
        Task Apagar(Autor autor);
        Task<Autor> BuscarPor(Guid id);
        Task<IQueryable<Autor>> BuscarTodas();
    }
}
