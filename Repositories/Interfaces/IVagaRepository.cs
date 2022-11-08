using WebAppGlobal.Models;

namespace WebAppGlobal.Repositories.Interfaces
{
    public interface IVagaRepository
    {
        public Vaga? ObterPorId(int id);
        public IEnumerable<Vaga> Listar();
        public void Cadastrar(Vaga vaga);
        public void Atualizar(Vaga vaga);
        public void Remover(Vaga vaga);
        public IEnumerable<Vaga> ListarPorEstacionamento(int estacionamentoId);
    }
}
