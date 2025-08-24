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
    }
}