using WebAppGlobal.Models;

namespace WebAppGlobal.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        public Endereco? ObterPorId(int id);
        public IEnumerable<Endereco> Listar();
        public void Cadastrar(Endereco endereco);
        public void Atualizar(Endereco endereco);
        public void Remover(Endereco endereco);
    }
}
