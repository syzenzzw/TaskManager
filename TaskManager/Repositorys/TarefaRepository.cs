using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Dtos;
using TaskManager.Interface;
using TaskManager.Models;
using TaskManager.Pesquisa;

namespace TaskManager.Repositorys
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> CreateAsync(Tarefa tarefaModel)
        {
            await _context.Tarefas.AddAsync(tarefaModel);
            await _context.SaveChangesAsync();
            return tarefaModel;
        }

        public async Task<Tarefa?> DeleteAsync(int id)
        {
            var tarefaModel = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (tarefaModel == null)
            {
                return null;
            }
                _context.Tarefas.Remove(tarefaModel);
                await _context.SaveChangesAsync();
                return tarefaModel;
        }

        public async Task<List<Tarefa>> GetAllAsync(PagePesquisa page)
        {
            var tarefas = _context.Tarefas.AsQueryable();

            var pularPagina = (page.NumPagina - 1) * page.TamPagina;

            return await tarefas.Skip(pularPagina).Take(page.TamPagina).ToListAsync();
        }

        public async Task<List<Tarefa>> GetAllExibicaoAsync(PagePesquisa page)
        {
            var tarefas = _context.Tarefas.AsQueryable();

            var proximaPagina = (page.NumPagina - 1) * page.TamPagina;

            return await tarefas.Skip(proximaPagina).Take(page.TamPagina).ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            var tarefaModel = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            return tarefaModel!;
        }


        public async Task<List<Tarefa>> GetByTitleAsync(PesquisaObjeto pesquisa)
        {

            var tarefas = _context.Tarefas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pesquisa.Titulo))
            {
                tarefas = tarefas.Where(s => s.Tittle.Contains(pesquisa.Titulo));
            }

            return await tarefas.ToListAsync();
        }


        public async Task<Tarefa?> UpdateAsync(UpdateRequestTarefa tarefaDto, int id)
        {
            var existingTarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTarefa == null)
            {
                return null;
            }

            existingTarefa.Content = tarefaDto.Content;
            existingTarefa.Tittle = tarefaDto.Tittle;

            await _context.SaveChangesAsync();

            return existingTarefa;
        }
    }
}
