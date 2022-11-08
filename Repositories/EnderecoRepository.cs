using WebAppGlobal.Models;
using WebAppGlobal.Repositories.Interfaces;

namespace WebAppGlobal.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly WebAppGlobalDbContext _context;

        public EnderecoRepository(WebAppGlobalDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Endereco endereco)
        {
            Endereco enderecoDb = ObterPorId(endereco.Id);
            enderecoDb.Rua = endereco.Rua;
            enderecoDb.Bairro = endereco.Bairro;
            enderecoDb.Numero = endereco.Numero;
            enderecoDb.Cidade = endereco.Cidade;
            enderecoDb.Estado = endereco.Estado;

            _context.SaveChanges();
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);

            _context.SaveChanges();
        }

        public IEnumerable<Endereco> Listar()
        {
            return _context.Enderecos.OrderBy(en => en.Id);
        }

        public Endereco? ObterPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(c => c.Id == id);
        }

        public void Remover(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);

            _context.SaveChanges();
        }
    }
}
