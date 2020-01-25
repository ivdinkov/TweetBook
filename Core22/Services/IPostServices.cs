using Core22.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Services
{
    public interface IPostServices
    {
        List<Post> GetPosts();
        Post GetPostById(Guid postId);
        bool UpdatePost(Post updatedPost);
        bool DeletePost(Guid guid);
    }
}
