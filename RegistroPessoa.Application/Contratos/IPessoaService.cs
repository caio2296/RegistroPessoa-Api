using RegistroPessoa.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Application.Contratos
{
    public interface IPessoaService
    {
        Task<PessoaDto> AddPessoa(PessoaDto model);
        Task<bool> DeletePessoa(int pessoaId);
        Task<PessoaDto> UpdatePessoa(int pessoaId, PessoaDto model);
        Task<PessoaDto[]> GetAllPessoasAsync();
        Task<PessoaDto> GetPessoaByIdAsync(int pessoaId);
    }
}
