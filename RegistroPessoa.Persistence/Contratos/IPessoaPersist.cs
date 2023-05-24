using RegistroPessoa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Persistence.Contratos
{
    public interface IPessoaPersist
    {
        Task<Pessoa[]> GetPessoasAllAsync();
        Task<Pessoa> GetPessoaByIdAsync(int pessoaId);
    }
}
