using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core22.Data;
using Core22.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core22.Services
{
    public class PostService : IPostServices
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreatePostAsync(Post post) 
        {
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await GetPostByIdASync(id);

            if (post == null)
                return false;

            _dataContext.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Post> GetPostByIdASync(Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x=>x.ID == postId);
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            var post = await GetPostByIdASync(postToUpdate.ID);

            if (post == null)
                return false;

            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking().SingleOrDefaultAsync(p=>p.ID == postId);

            if (post == null)
            {
                return false;
            }

            if (post.UserId != userId)
            {
                return false;
            }

            return true;
        }
    }
}
