using CleanArchMvcApplication.DTOs;
using CleanArchMvcApplication.Interfaces;
using CleanArchMvcApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class DadosController : Controller
    {

        private readonly IDadosService _dadosService;

        public DadosController(IDadosService dadosService)
        {
            _dadosService = dadosService;
        }

        [HttpGet]
        public async  Task< IActionResult> Index()
        {
            var dados = await _dadosService.GetdadosDto();
            return View(dados);
        }



        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Create(DadosDTO dados)
        {
            if (ModelState.IsValid) // verifica se o módelo é válido.
            {
                await _dadosService.Add(dados);
                return RedirectToAction(nameof(Index));

            }
            return View(dados);
        }




        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dadosDto = await _dadosService.GetById(id);

            if (dadosDto == null) return NotFound();

            return View(dadosDto);

        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dadosDto = _dadosService.Remove(id);

            if (dadosDto == null) return NotFound();

            return View(dadosDto);

        }

         [HttpPost()]

        public async Task<IActionResult> Edit(DadosDTO dadoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dadosService.Update(dadoDto);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(dadoDto);
        }
    }

}


    




       

        



       

       
