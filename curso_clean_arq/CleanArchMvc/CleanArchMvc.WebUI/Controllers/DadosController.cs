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
    }
}
