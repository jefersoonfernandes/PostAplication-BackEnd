using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PostAplication.Data;
using PostAplication.Models;
using PostAplication.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PostAplication.Repositories
{
    public class PostRepositories : IPostRepositories
    {

        private readonly PostDbContext _context;
        public PostRepositories(PostDbContext context)
        {
            _context = context;
        }
        public async Task<Post> Atualizar(Post post, int id)
        {
            Post postId = await BuscarPorId(id);

            if (postId == null)
            {
                throw new NotImplementedException();
            }

            postId.Name = post.Name;
            postId.Description = post.Description;

            _context.Posts.Update(postId);
            await _context.SaveChangesAsync();

            return postId;
        }

        public async Task<Post> BuscarPorId(int id)
        {
            Post valor = await _context.Posts.FirstOrDefaultAsync(h => h.Id == id);

            if (valor == null)
            {
                throw new NotImplementedException();
            }

            return valor;
        }

        public async Task<List<Post>> BuscarPorTodos()
        {
            return await _context.Posts.ToListAsync();
           
        }

        public async Task<Post> Cadastrar(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            Post taskId = await BuscarPorId(id);

            if (taskId == null)
            {
                throw new NotImplementedException();
            }

            _context.Posts.Remove(taskId);
            await _context.SaveChangesAsync();
            return true;
            
        }
    }
}
