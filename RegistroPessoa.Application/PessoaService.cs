using AutoMapper;
using RegistroPessoa.Application.Contratos;
using RegistroPessoa.Application.Dtos;
using RegistroPessoa.Domain;
using RegistroPessoa.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace RegistroPessoa.Application
{
    public class PessoaService : IPessoaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPessoaPersist _pessoaPersist;
        private readonly IMapper _mapper;
        public PessoaService(
            IGeralPersist geralPesist,
            IPessoaPersist pessoaPersist,
            IMapper mapper)
        {
            _geralPersist = geralPesist;
            _pessoaPersist = pessoaPersist;
            _mapper = mapper;
        }
        public async Task<PessoaDto> AddPessoa(PessoaDto model)
        {
            try
            {
                var pessoa = _mapper.Map<Pessoa>(model);
                _geralPersist.Add(pessoa);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var pessoaRetorno = await _pessoaPersist.GetPessoaByIdAsync(pessoa.Id);
                    return _mapper.Map<PessoaDto>(pessoaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePessoa(int pessoaId)
        {
            try
            {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId);
                if (pessoa == null) throw new Exception("Erro ao excluir a pessoa. Pessoa não encontrado!");
                _geralPersist.Delete(pessoa);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto[]> GetAllPessoasAsync()
        {
            try
            {
                var pessoa = await _pessoaPersist.GetPessoasAllAsync();
                if (pessoa == null) return null;

                var resultado = _mapper.Map<PessoaDto[]>(pessoa);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto> GetPessoaByIdAsync(int pessoaId)
        {
            try
            {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId);
                if (pessoa == null) return null;

                var resultado = _mapper.Map<PessoaDto>(pessoa);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PessoaDto> UpdatePessoa(int pessoaId, PessoaDto model)
        {
            try
            {
                var pessoa = await _pessoaPersist.GetPessoaByIdAsync(pessoaId);
                if (pessoa == null) return null;

                model.Id = pessoa.Id;

                _mapper.Map(model, pessoa);
                _geralPersist.Update(pessoa);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var pessoaRetorno = await _pessoaPersist.GetPessoaByIdAsync(pessoaId);
                    return _mapper.Map<PessoaDto>(pessoaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
