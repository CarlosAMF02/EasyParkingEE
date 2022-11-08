using Microsoft.EntityFrameworkCore;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;

namespace WebAppGlobal.Repositories
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly WebAppGlobalDbContext _context;

        public EstacionamentoRepository(WebAppGlobalDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Estacionamento estacionamento)
        {
            Estacionamento estacionamentoDb = ObterPorId(estacionamento.Id);
            estacionamentoDb.Nome = estacionamento.Nome;
            estacionamentoDb.Endereco = estacionamento.Endereco;

            _context.SaveChanges();
        }

        public void Cadastrar(Estacionamento estacionamento)
        {
            _context.Estacionamentos.Add(estacionamento);

            _context.SaveChanges();
        }

        public IEnumerable<Estacionamento> Listar()
        {
            return _context.Estacionamentos.OrderBy(en => en.Id).Include(en => en.Endereco);
        }

        public Estacionamento? ObterPorId(int id)
        {
            return _context.Estacionamentos.Include(en => en.Endereco).FirstOrDefault(c => c.Id == id);
        }

        public void Remover(Estacionamento estacionamento)
        {
            _context.Estacionamentos.Remove(estacionamento);

            _context.SaveChanges();
        }
    }
}
