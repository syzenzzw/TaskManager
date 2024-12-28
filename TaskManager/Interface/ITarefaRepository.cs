using TaskManager.Dtos;
using TaskManager.Models;
using TaskManager.Pesquisa;

namespace TaskManager.Interface
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetAllExibicaoAsync(PagePesquisa page);
        Task<List<Tarefa>> GetByTitleAsync(PesquisaObjeto pesquisa);
        Task<List<Tarefa>> GetAllAsync(PagePesquisa page);
        Task<Tarefa> GetByIdAsync(int id);
        Task<Tarefa> CreateAsync(Tarefa tarefaModel);
        Task<Tarefa?> UpdateAsync(UpdateRequestTarefa tarefaDto, int id);
        Task<Tarefa?> DeleteAsync(int id);

    }
}
