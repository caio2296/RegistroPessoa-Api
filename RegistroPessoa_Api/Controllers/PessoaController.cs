using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroPessoa.Application.Contratos;
using RegistroPessoa.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPessoa_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService,
            IWebHostEnvironment hostEnvironment)
        {
            _pessoaService = pessoaService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pessoa = await _pessoaService.GetAllPessoasAsync();
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as pessoas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
                if (pessoa == null) return NoContent();
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Pessoa não encontrada. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaDto model)
        {
            try
            {
                var pessoa = await _pessoaService.AddPessoa(model);
                if (pessoa == null) return NoContent();
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar uma pessoa. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PessoaDto model)
        {
            try
            {
                var pessoa = await _pessoaService.UpdatePessoa(id, model);
                if (pessoa == null) return NoContent();
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar pessoa. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
                if (pessoa == null) return NoContent();

                if (await _pessoaService.DeletePessoa(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao deletar a pessoa.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar pessoa. Erro: {ex.Message}");
            }
        }
    }
}
