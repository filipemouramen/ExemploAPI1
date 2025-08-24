using Microsoft.AspNetCore.Mvc;
using ExemploAPI1.Models;

namespace ExemploAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        [HttpPost("calcular-imc")]

        public IActionResult CalcularImc([FromBody] Pessoa _pessoa)
        {
            if (_pessoa == null)
            {
                return BadRequest("Os dados da pessoa são obrigatórios.");
            }

            if (_pessoa.Altura <= 0)
            {
                return BadRequest("A altura de uma pessoa deve ser maior que zero :).");
            }

            double imc = _pessoa.Peso / (_pessoa.Altura * _pessoa.Altura);

            return Ok(new
            {
                Nome = _pessoa.Nome,
                IMC = imc
            });
        }

        [HttpGet("consulta-tabela-imc/{imc}")]
        public IActionResult ConsultaTabelaImc(double imc)
        {
            string descricao;

            if (imc < 18.5)
            {
                descricao = "Abaixo do peso";
            }
            else if (imc >= 18.5 && imc < 24.9)
            {
                descricao = "Peso normal";
            }
            else if (imc >= 25 && imc < 29.9)
            {
                descricao = "Sobrepeso";
            }
            else if (imc >= 30 && imc < 34.9)
            {
                descricao = "Obesidade grau I";
            }
            else if (imc >= 35 && imc < 39.9)
            {
                descricao = "Obesidade grau II";
            }
            else
            {
                descricao = "Obesidade graus III e IV";
            }

            return Ok(new
            {
                IMC = imc,
                Descricao = descricao
            });
        }
    }
}