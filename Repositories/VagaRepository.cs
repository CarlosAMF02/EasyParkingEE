using Microsoft.EntityFrameworkCore;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;

namespace WebAppGlobal.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly WebAppGlobalDbContext _context;

        public VagaRepository(WebAppGlobalDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Vaga vaga)
        {
            Vaga vagaDb = ObterPorId(vaga.Id);
            vagaDb.Nome = vaga.Nome;
            vagaDb.Andar = vaga.Andar;
            vagaDb.Status = vaga.Status;
            vagaDb.Estacionamento = vaga.Estacionamento;

            _context.SaveChanges();
        }

        public void Cadastrar(Vaga vaga)
        {
            _context.Vagas.Add(vaga);

            _context.SaveChanges();
        }

        public IEnumerable<Vaga> Listar()
        {
            return _context.Vagas.OrderBy(en => en.Id).Include(en => en.Estacionamento);
        }

        public Vaga? ObterPorId(int id)
        {
            return _context.Vagas.Include(en => en.Estacionamento).FirstOrDefault(c => c.Id == id);
        }

        public void Remover(Vaga vaga)
        {
            _context.Vagas.Remove(vaga);

            _context.SaveChanges();
        }

        public IEnumerable<Vaga> ListarPorEstacionamento(int estacionamentoId)
        {
            return _context.Vagas.Include(en => en.Estacionamento).Where(en => en.Estacionamento.Id == estacionamentoId).OrderBy(en => en.Id);
        }
    }
}
