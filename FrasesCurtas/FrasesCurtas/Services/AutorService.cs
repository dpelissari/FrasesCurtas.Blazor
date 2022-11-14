using FrasesCurtas.Data;
using FrasesCurtas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrasesCurtas.Services {
    public class AutorService : IAutorService {

        // injecao de depencia do dbcontext p/ armezar op em memory
        private readonly AplicacaoDbContexto dbContexto;
       
        public AutorService(AplicacaoDbContexto appDbContexto) {
            dbContexto = appDbContexto;
        }

        // metodo asincrono para adicionar autores
        public async Task Adicionar(Autor autor) {
            await dbContexto.AddAsync(autor);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para atualizar autores
        public async Task Atualizar(Autor autor) {
            dbContexto.Update(autor);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para apagar autorews
        public async Task Apagar(Autor autor) {
            dbContexto.Remove(autor);
            await dbContexto.SaveChangesAsync();
        }

        // metodo para retornar um autor com base no id
        public  async Task<Autor> BuscarPor(Guid id) {
            var autor = await dbContexto.Autores.FirstOrDefaultAsync(f => f.Id == id);
            return autor;
        }

        // metodo para listar todos autores
        public async Task<IQueryable<Autor>> BuscarTodas() {
            var autor = await dbContexto.Autores.ToListAsync();
            return autor.AsQueryable();
        }

    }
}
