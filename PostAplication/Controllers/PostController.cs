using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostAplication.Models;
using PostAplication.Repositories.Interfaces;

namespace PostAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepositories _repo;
        public PostController(IPostRepositories repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> BuscarTodos()
        {
            List<Post> posts = await _repo.BuscarPorTodos();
            return Ok(posts);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Task<Post>>> BuscarPorIds(int id)
        {
            Post model = await _repo.BuscarPorId(id);
            return Ok(model);
        }

        [HttpPost]

        public async Task<ActionResult<Post>> Cadastrar([FromBody] Post usuario)
        {
            Post model = await _repo.Cadastrar(usuario);
            return Ok(model);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Post>> Atualizar([FromBody] Post usuario, int id)
        {
            usuario.Id = id;
            Post model = await _repo.Atualizar(usuario, id);
            return Ok(model);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Post>> Delete(int id)
        {
            bool model = await _repo.Delete(id);
            return Ok(model);
        }

    }
}
