using FrasesCurtas.Models;

namespace FrasesCurtas.Services {
    public interface ICategoriaFraseService {

        // assinatura dos metodos a serem implemntados
        Task Adicionar(CategoriaFrase categoria);
        Task Atualizar(CategoriaFrase categoria);
        Task Apagar(CategoriaFrase categoria);
        Task <CategoriaFrase> BuscarPor(Guid id);
        Task<IQueryable<CategoriaFrase>> BuscarTodas();
    }
}
