﻿using FrasesCurtas.Data;
using FrasesCurtas.Interfaces;
using FrasesCurtas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrasesCurtas.Services
{
    public class FraseService : IFraseService {

        // injecao de depencia do dbcontext p/ armezar op em memory
        private readonly AplicacaoDbContexto dbContexto;
       
        public FraseService(AplicacaoDbContexto appDbContexto) {
            dbContexto = appDbContexto;
        }

        // metodo asincrono para adicionar frases
        public async Task Adicionar(Frase frase) {
            await dbContexto.AddAsync(frase);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para atualizar frases
        public async Task Atualizar(Frase frase) {
            dbContexto.Update(frase);
            await dbContexto.SaveChangesAsync();
        }

        // metodo asincrono para apagar frases
        public async Task Apagar(Frase frase) {
            dbContexto.Remove(frase);
            await dbContexto.SaveChangesAsync();
        }

        // metodo para retornar uma frase com base no id
        public  async Task<Frase> BuscarPor(Guid id) {
            var frase = await dbContexto.Frases.FirstOrDefaultAsync(f => f.Id == id);
            return frase;
        }

        // metodo para listar todas frases
        public async Task<IQueryable<Frase>> BuscarTodas() {
            var frase = await dbContexto.Frases.ToListAsync();
            return frase.AsQueryable();
        }

        // metodo para listar todas frases de um autor
        public async Task<IQueryable<Frase>> BuscarPorAutorId(Guid autorId) {
            var frases = await dbContexto.Frases
                .Where(f => f.IdAutor == autorId)
                .ToListAsync();

            return frases.AsQueryable();
        }

        public async Task<IQueryable<Frase>> BuscarPorIdCategoria(Guid categoriaId) {
            var frases = await dbContexto.Frases
                .Where(f => f.IdCategoriaFrase == categoriaId)
                .ToListAsync();

            return frases.AsQueryable();
        }

    }
}
