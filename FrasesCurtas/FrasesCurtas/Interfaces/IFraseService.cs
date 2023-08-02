using FrasesCurtas.Models;

namespace FrasesCurtas.Interfaces
{
    public interface IFraseService
    {

        // assinatura dos metodos a serem implemntados
        Task Adicionar(Frase frase);
        Task Atualizar(Frase frase);
        Task Apagar(Frase frase);
        Task<Frase> BuscarPor(Guid id);
        Task<IQueryable<Frase>> BuscarPorAutorId(Guid id);
        Task<IQueryable<Frase>> BuscarPorIdCategoria(Guid id);
        Task<IQueryable<Frase>> BuscarTodas();
    }
}
