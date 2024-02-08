using CleanArchMvcApplication.DTOs;
using CleanArchMvcApplication.Interfaces;
using CleanArchMvcApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class PessoaController : Controller
    {


        private readonly IPessoaService _pessoaService;


        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;//atribui a variavel ao serviço.
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
         var pessoa = await _pessoaService.GetPessoa();
            return View(pessoa);
        }
        [HttpGet()]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(PessoaDTO pessoa)
        {
            if (ModelState.IsValid) // verifica se o módelo é válido.
            {
                await _pessoaService.Add(pessoa);
                return RedirectToAction(nameof(Index));

            }
            return View(pessoa);
        }

 
    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

            var pessoaDto = await _pessoaService.GetById(id);// geralmente os dto são chamados de VM.

        if(pessoaDto == null) return NotFound();

            return View(pessoaDto);

    }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pessoaDto =  _pessoaService.Remove(id);

            if (pessoaDto == null) return NotFound();

            return View(pessoaDto);

        }

        [HttpPost()]

        public async Task<IActionResult> Edit(PessoaDTO pessoaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _pessoaService.Update(pessoaDto);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDto);// devolve a category com os erros de validação
        }
    }

}

