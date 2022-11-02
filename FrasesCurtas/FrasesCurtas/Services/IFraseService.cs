using FrasesCurtas.Models;

namespace FrasesCurtas.Services {
    public interface IFraseService {

        // assinatura dos metodos a serem implemntados
        Task Adicionar(Frase frase);
        Task Atualizar(Frase frase);
        Task Apagar(Frase frase);
        Task <Frase>BuscarPor(Guid id);
        Task<List<Frase>> BuscarTodas();
    }
}
