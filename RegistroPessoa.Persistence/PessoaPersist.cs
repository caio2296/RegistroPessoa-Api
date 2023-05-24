using Microsoft.EntityFrameworkCore;
using RegistroPessoa.Domain;
using RegistroPessoa.Persistence.Contexto;
using RegistroPessoa.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Persistence
{
    public class PessoaPersist: IPessoaPersist
    {
        private readonly PessoaContextDb _context;
        
        public PessoaPersist(PessoaContextDb context)
        {
            _context = context;
        }

        public Task<Pessoa> GetPessoaByIdAsync(int pessoaId)
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            query = query.AsNoTracking()
                 .OrderBy(e => e.Id)
                  .Where(p => p.Id == pessoaId);
            return query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa[]> GetPessoasAllAsync()
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            query = query.AsNoTracking()
                  .OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
    }
}
