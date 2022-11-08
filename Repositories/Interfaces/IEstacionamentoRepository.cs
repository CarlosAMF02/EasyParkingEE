using WebAppGlobal.Models;

namespace WebAppGlobal.Repositories.Interfaces
{
    public interface IEstacionamentoRepository
    {
        public Estacionamento? ObterPorId(int id);
        public IEnumerable<Estacionamento> Listar();
        public void Cadastrar(Estacionamento estacionamento);
        public void Atualizar(Estacionamento estacionamento);
        public void Remover(Estacionamento estacionamento);
    }
}
