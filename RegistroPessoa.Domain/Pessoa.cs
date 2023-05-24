using System;

namespace RegistroPessoa.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int Idade { get; set; }
    }
}
