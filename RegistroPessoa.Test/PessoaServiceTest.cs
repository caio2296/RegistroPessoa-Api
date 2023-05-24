using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using RegistroPessoa.Application;
using RegistroPessoa.Application.Dtos;
using RegistroPessoa.Application.Helpers;
using RegistroPessoa.Domain;
using RegistroPessoa.Persistence.Contratos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RegistroPessoa.Test
{
    public class PessoaServiceTest
    {
        private readonly IPessoaPersist _pessoaPersist;

        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;


        private readonly PessoaService _spessoa;


        public PessoaServiceTest()
        {
            _pessoaPersist = Substitute.For<IPessoaPersist>();
            _geralPersist = Substitute.For<IGeralPersist>();
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<PessoaProfile>(); // Adicione o profile real do AutoMapper aqui
            });
            _mapper = new Mapper(configuration);

            _spessoa = new PessoaService(_geralPersist, _pessoaPersist, _mapper);

        }


        [Fact]
        public async Task GetByIdAsync_ShouldReturnPessoa()
        {
            //Arrange
            var pessoaId = _fixture.Create<int>();
            //var pessoa = _fixture.Build<Pessoa>().With(p => p.Cpf, int.Parse("1234567890")).Create();
            var pessoa = _fixture.Create<Pessoa>();
            //var pessoa = new Pessoa() { Id =  pessoaId, Nome= "string", Cpf = 123456, Idade = 123 };
            _pessoaPersist.GetPessoaByIdAsync(pessoaId).Returns(Task.FromResult(pessoa));

            //Act

            var result = await _spessoa.GetPessoaByIdAsync(pessoaId);

            //Assert
            result.Should().NotBeNull();  // Verificar se result não é nulo
            pessoa.Should().NotBeNull();  // Verificar se pessoa não é nulo
            result.Id.Should().Be(pessoa.Id);  // Verificar se o Id de result é igual ao Id de pessoa
            result.Nome.Should().Be(pessoa.Nome);  // Verificar se o Nome de result é igual ao Nome de pessoa
            result.Idade.Should().Be(pessoa.Idade);  // Verificar se a Idade de result é igual à Idade de pessoa
        }
    }
}
