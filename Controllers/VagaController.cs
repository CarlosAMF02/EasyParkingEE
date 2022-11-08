using Microsoft.AspNetCore.Mvc;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;
using WebAppGlobal.ViewModels;

namespace WebAppGlobal.Controllers
{
    public class VagaController : Controller
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;

        public VagaController(IVagaRepository vagaRepository, IEstacionamentoRepository estacionamentoRepository)
        {
            _vagaRepository = vagaRepository;
            _estacionamentoRepository = estacionamentoRepository;
        }

        public IActionResult Listar()
        {
            IEnumerable<Vaga> vagas = _vagaRepository.Listar();
            return View(vagas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome,Andar,Status,EstacionamentoId")] VagaVM vagaVM)
        {
            Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(vagaVM.EstacionamentoId);
            if (estacionamento == null)
            {
                return View(vagaVM);
            }

            Vaga vagaDb = new Vaga()
            {
                Nome = vagaVM.Nome,
                Andar = vagaVM.Andar,
                Status = vagaVM.Status,
                Estacionamento = estacionamento
            };

            if (ModelState.IsValid)
            {
                _vagaRepository.Cadastrar(vagaDb);
                return RedirectToAction(nameof(Listar));
            }
            return View(vagaVM);
        }

        public IActionResult Alterar(int id)
        {
            Vaga vaga = _vagaRepository.ObterPorId(id);

            VagaVM vagaVM = new VagaVM()
            {
                Id = vaga.Id,
                Nome = vaga.Nome,
                Status = vaga.Status,
                Andar = vaga.Andar,
                EstacionamentoId = vaga.Estacionamento.Id
            };

            return View(vagaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Nome,Andar,Status,EstacionamentoId")] VagaVM vagaVM)
        {
            if (ModelState.IsValid)
            {
                Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(vagaVM.EstacionamentoId);
                if (estacionamento == null)
                {
                    return View(vagaVM);
                }
                Vaga vagaDb = _vagaRepository.ObterPorId(vagaVM.Id);
                if (estacionamento == null)
                {
                    return RedirectToAction(nameof(Listar));
                }
                vagaDb.Nome = vagaVM.Nome;
                vagaDb.Andar = vagaVM.Andar;
                vagaDb.Status = vagaVM.Status;
                vagaDb.Estacionamento = estacionamento;

                _vagaRepository.Atualizar(vagaDb);
                return RedirectToAction(nameof(Listar));
            }
            return View(vagaVM);
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vaga vaga = _vagaRepository.ObterPorId(id);

            if (vaga == null)
            {
                return NotFound();
            }
            return View(vaga);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            Vaga vaga = _vagaRepository.ObterPorId(id);
            _vagaRepository.Remover(vaga);
            return RedirectToAction(nameof(Listar));
        }

        public IActionResult ListarPorEstacionamento(int estacionamentoId)
        {
            IEnumerable<Vaga> vagas = _vagaRepository.Listar();
            return View(vagas);
        }
    }
}
