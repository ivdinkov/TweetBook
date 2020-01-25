using Core22.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Services
{
    public interface IPostServices
    {
        Task<bool> CreatePostAsync(Post post);
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostByIdASync(Guid postId);
        Task<bool> UpdatePostAsync(Post updatedPost);
        Task<bool> DeletePostAsync(Guid guid);
    }
}
