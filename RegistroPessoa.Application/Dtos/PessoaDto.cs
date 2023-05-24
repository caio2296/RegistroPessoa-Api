using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Application.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
         StringLength(25, MinimumLength = 3, ErrorMessage = "Insira de 3 a 30 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
            Range(12, 130)]
        public int Idade { get; set; }


    }
}
