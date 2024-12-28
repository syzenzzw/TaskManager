using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Mappers
{
    public static class TarefaMappers
    {
      
        public static ExibicaoDto ToTarefaExibicao(this Tarefa tarefaDtoExibicao)
        {
            return new ExibicaoDto
            {
                Id = tarefaDtoExibicao.Id,
                Tittle = tarefaDtoExibicao.Tittle
            };
        }

        public static TarefaDto ToTarefaDto(this Tarefa tarefaModel)
        {
            return new TarefaDto
            {
             Id = tarefaModel.Id,
             Content = tarefaModel.Content,
             Tittle = tarefaModel.Tittle,
             CreatedOn = tarefaModel.CreatedOn
            };
        }

        public static Tarefa ToTarefaFromCreateDTO(this CreateRequestTarefa tarefaDto)
        {
            return new Tarefa
            {
                Content = tarefaDto.Content,
                Tittle = tarefaDto.Tittle
            };
        }

        public static Tarefa ToTarefaFromUpdateDTO(this UpdateRequestTarefa tarefaDto)
        {
            return new Tarefa
            {
                Content = tarefaDto.Content,
                Tittle = tarefaDto.Tittle
            };
        }
    }
}
