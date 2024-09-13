using LivrosAPI.Models;
using LivrosAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MySqlX.XDevAPI;
using Swashbuckle.AspNetCore.Annotations;

namespace AlunosAPI.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosRepository _livrosRepository;

        public LivrosController(LivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        // GET: api/livros/listar
        [HttpGet]
        [Route("listar")]
        [SwaggerOperation(Summary = "Listar todos os livros", Description = "Este endpoint retorna uma listagem de livros cadastrados.")]
        public async Task<IEnumerable<Livros>> Listar([FromQuery] bool? ativo = null)
        {
            return await _livrosRepository.ListarTodosLivros(ativo);
        }

        // GET api/livros/detalhes/5
        [HttpGet("detalhes/{id}")]
        [SwaggerOperation(
            Summary = "Obtém dados de um livro pelo ID",
            Description = "Este endpoint retorna todos os dados de um livro cadastrado filtrando pelo ID.")]
        public async Task<Livros> BuscarPorId(int id)
        {
            return await _livrosRepository.BuscarPorId(id);
        }

        // POST api/livros
        [HttpPost]
        [SwaggerOperation(
            Summary = "Cadastrar um novo livro",
            Description = "Este endpoint é responsável por cadastrar um novo livro.")]
        public async void Post([FromBody] Livros dados)
        {
            await _livrosRepository.Salvar(dados);
        }

        // PUT api/livros/5
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar os dados de um livro filtrando por ID",
            Description = "Este endpoint é responsável por atualizar os dados de um livro no banco.")]
        public async Task<IActionResult> Put(int id, [FromBody] Livros dados)
        {
            dados.Id = id;
            await _livrosRepository.Atualizar(dados);
            return Ok();
        }

        // DELETE api/livros/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Remover um livro filtrando pelo Id",
            Description = "Este endpoint é responsável por remover os dados de um livro no banco.")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livrosRepository.DeletarPorId(id);
            return Ok();
        }
    }
}
