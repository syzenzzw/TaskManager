using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Dtos;
using TaskManager.Interface;
using TaskManager.Mappers;
using TaskManager.Pesquisa;


namespace TaskManager.Controllers
{
    //Crio uma rota para o meu controlador
    [Microsoft.AspNetCore.Mvc.Route("api/TaskManager")]


    //Declaro que minha rota é baseada em uma apicontroller
    [ApiController]

    //Classe do meu controlador, que herda a base necessário do ControllerBase
    public class TarefaController : ControllerBase
    {
        //Crio duas instâncias a partir do contexto do banco de dados e da interface para serem usadas aqui dentro desse arquivo
        private readonly ApplicationDbContext? _context;
        private readonly ITarefaRepository? _tarefaRepo;

        //Crio uma classe que faz duas instâncias a partir do contexto e inteface
        public TarefaController(ApplicationDbContext? context, ITarefaRepository? tarefaRepo)
        {
            //Dou o valor de das instâncias criadas para as instâncias que ficam somente neste arquivo
            _context = context;
            _tarefaRepo = tarefaRepo;
        }

   

        [HttpGet("Exibição")]

        public async Task<IActionResult> GetExibicao([FromQuery] PagePesquisa page)
        {
            var tarefas = await _tarefaRepo!.GetAllExibicaoAsync(page);
            var tarefaDto =  tarefas.Select(s => s.ToTarefaExibicao()).ToList();

            if (tarefas == null)
            {
                return NotFound();
            }


            return Ok(tarefaDto);
        }


        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] PagePesquisa page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarefas = await _tarefaRepo!.GetAllAsync(page);
            var tarefaDto = tarefas.Select(s => s.ToTarefaDto());

            if (tarefas == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(tarefas);
            }
        }

        [HttpGet("PegarIdentificador/{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var tarefa = await _tarefaRepo!.GetByIdAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa.ToTarefaDto());
        }

        [HttpGet("pesquisar")]

        public async Task<IActionResult> GetByTitle([FromQuery] PesquisaObjeto pesquisa)
        {

            var tarefas = await _tarefaRepo!.GetByTitleAsync(pesquisa);

            return Ok(tarefas);
        }

        [HttpPost("metodocriartarefa")]

        public async Task<IActionResult> Create([FromBody] CreateRequestTarefa tarefaDto)
        {
            if(!ModelState.IsValid)
                { return BadRequest(); }


            var tarefaModel = tarefaDto.ToTarefaFromCreateDTO();
            await _tarefaRepo!.CreateAsync(tarefaModel);
            return Ok(tarefaModel);
        }

        [HttpPut("{id:int}")]
        

        public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] UpdateRequestTarefa updateDto)   
        {
            if(!ModelState.IsValid)
                { return BadRequest(); }

            var tarefaModel = await _tarefaRepo!.UpdateAsync(updateDto, id);

            if (tarefaModel == null)
            {
                return NotFound();
            }
             
            return Ok(tarefaModel);
        }


        [HttpDelete("{id:int}")]
        

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                { return BadRequest(); }
            var tarefaModel = await _tarefaRepo!.DeleteAsync(id);

            if (tarefaModel == null)
            {
                return NotFound();
            }

                return NoContent();

        }
    }
}
