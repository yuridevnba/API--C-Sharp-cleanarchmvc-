using CleanArchMvcApplication.DTOs;
using CleanArchMvcApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IPessoaService _pessoaService;

        public CategoriesController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> Get()
        {
            var categories = await _pessoaService.GetPessoa();
            if(categories == null)
            {
                return NotFound("Pessoas not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetPessoa")] // nome alternativo, para retornar a categoria que foi criada a pouco instantes.
        public async Task<ActionResult<PessoaDTO>> Get(int id)
        {
            var pessoa = await _pessoaService.GetById(id);
            if (pessoa == null)
            {
                return NotFound("Pessoa not found");
            }
            return Ok(pessoa);
        }


        [HttpPost()]
        public async Task<ActionResult> Post([FromBody]PessoaDTO pessoaDto)// frombody os dados vão vim no corpo da requisição.
        {
            if (pessoaDto == null) // verifica se o módelo é válido.
                return BadRequest("Invalid Data");
              
            await _pessoaService.Add(pessoaDto);

            return new CreatedAtRouteResult("GetCategory",new {id = pessoaDto.Id},pessoaDto);// código de status "201", retornar os dados da categoria que acabou de criar.
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody]PessoaDTO pessoaDTO)
        {
            if (id != pessoaDTO.Id)   // Id da categoria que estou alterando é igual ao id que recebi.
                return BadRequest(); //400

            if (pessoaDTO == null)
                return BadRequest();

            await _pessoaService.Update(pessoaDTO);

            return Ok(pessoaDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PessoaDTO>> Delete (int id)
        {
            var pessoa = await _pessoaService.GetById(id);
            if(pessoa == null)
            {
                return NotFound("Category not found");
            }
            await _pessoaService.Remove(id);
            return Ok(pessoa);
        }

    }   
}   
