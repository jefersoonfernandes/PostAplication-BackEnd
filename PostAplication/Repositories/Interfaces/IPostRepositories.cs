using PostAplication.Models;

namespace PostAplication.Repositories.Interfaces
{
    public interface IPostRepositories
    {
        Task<List<Post>> BuscarPorTodos();
        Task<Post> BuscarPorId (int id);
        Task<Post> Cadastrar (Post post);
        Task<Post> Atualizar (Post post, int id);
        Task<bool> Delete (int id);
    }
}
