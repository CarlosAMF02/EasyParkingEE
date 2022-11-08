using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;

namespace WebAppGlobal.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Listar()
        {
            IEnumerable<Endereco> enderecos = _enderecoRepository.Listar();
            return View(enderecos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Rua,Bairro,Numero,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Cadastrar(endereco);
                return RedirectToAction(nameof(Listar));
            }
            return View(endereco);
        }

        public IActionResult Alterar(int id)
        {
            Endereco endereco = _enderecoRepository.ObterPorId(id);
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Rua,Bairro,Numero,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Atualizar(endereco);
                return RedirectToAction(nameof(Listar));
            }
            return View(endereco);
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Endereco endereco = _enderecoRepository.ObterPorId(id);

            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConfirmado(int id)
        {
            Endereco endereco = _enderecoRepository.ObterPorId(id);
            _enderecoRepository.Remover(endereco);
            return RedirectToAction(nameof(Listar));
        }
    }
}
