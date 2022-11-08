using Microsoft.AspNetCore.Mvc;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;
using WebAppGlobal.ViewModels;

namespace WebAppGlobal.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EstacionamentoController(IEstacionamentoRepository estacionamentoRepository, IEnderecoRepository enderecoRepository)
        {
            _estacionamentoRepository = estacionamentoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Listar()
        {
            IEnumerable<Estacionamento> estacionamentos = _estacionamentoRepository.Listar();
            return View(estacionamentos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome,EnderecoId")] EstacionamentoVM estacionamentoVM)
        {
            Endereco endereco = _enderecoRepository.ObterPorId(estacionamentoVM.EnderecoId);
            if (endereco == null)
            {
                return View(estacionamentoVM);
            }

            Estacionamento estacionamentoDb = new Estacionamento()
            {
                Nome = estacionamentoVM.Nome,
                Endereco = endereco,
            };

            if (ModelState.IsValid)
            {
                _estacionamentoRepository.Cadastrar(estacionamentoDb);
                return RedirectToAction(nameof(Listar));
            }
            return View(estacionamentoVM);
        }

        public IActionResult Alterar(int id)
        {
            Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(id);

            EstacionamentoVM estacionamentoVM = new EstacionamentoVM()
            {
                Id = estacionamento.Id,
                Nome = estacionamento.Nome,
                EnderecoId = estacionamento.Endereco.Id
            };

            return View(estacionamentoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Nome,EnderecoId")] EstacionamentoVM estacionamentoVM)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = _enderecoRepository.ObterPorId(estacionamentoVM.EnderecoId);
                if (endereco == null)
                {
                    return View(estacionamentoVM);
                }
                Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(estacionamentoVM.Id);
                if (estacionamento == null)
                {
                    return RedirectToAction(nameof(Listar));
                }
                estacionamento.Nome = estacionamentoVM.Nome;
                estacionamento.Endereco = endereco;

                _estacionamentoRepository.Atualizar(estacionamento);
                return RedirectToAction(nameof(Listar));
            }
            return View(estacionamentoVM);
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(id);

            if (estacionamento == null)
            {
                return NotFound();
            }
            return View(estacionamento);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            Estacionamento estacionamento = _estacionamentoRepository.ObterPorId(id);
            _estacionamentoRepository.Remover(estacionamento);
            return RedirectToAction(nameof(Listar));
        }
    }
}
