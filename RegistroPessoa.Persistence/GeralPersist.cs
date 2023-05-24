using RegistroPessoa.Persistence.Contexto;
using RegistroPessoa.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace RegistroPessoa.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly PessoaContextDb _context;

        public GeralPersist(PessoaContextDb context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
