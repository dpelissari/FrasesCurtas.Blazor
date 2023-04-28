using FrasesCurtas.Data;
using FrasesCurtas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrasesCurtas.Services {
    public class CategoriaFraseService : ICategoriaFraseService{

        // injecao de depencia do dbcontext p/ armezar op em memory
        private readonly AplicacaoDbContexto dbContexto;
       
        public CategoriaFraseService(AplicacaoDbContexto appDbContexto) {
            dbContexto = appDbContexto;
        }

        // metodo asincrono para adicionar autores
        public async Task Adicionar(CategoriaFrase categoria) {
            await dbContexto.AddAsync(categoria);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para atualizar autores
        public async Task Atualizar(CategoriaFrase categoria) {
            dbContexto.Update(categoria);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para apagar autorews
        public async Task Apagar(CategoriaFrase categoria) {
            dbContexto.Remove(categoria);
            await dbContexto.SaveChangesAsync();
        }

        // metodo para retornar um autor com base no id
        public  async Task<CategoriaFrase> BuscarPor(Guid id) {
            var categoria = await dbContexto.Categorias.FirstOrDefaultAsync(f => f.Id == id);
            return categoria;
        }

        // metodo para listar todos autores
        public async Task<IQueryable<CategoriaFrase>> BuscarTodas() {
            var categoria = await dbContexto.Categorias.ToListAsync();
            return categoria.AsQueryable();
        }

    }
}
