using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core22.Domain;

namespace Core22.Services
{
    public class PostService : IPostServices
    {
        private readonly List<Post> _posts;
        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    ID = Guid.NewGuid(),
                    Name = $"Post Name{i}"
                });
            }
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(x=>x.ID == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }
    }
}
