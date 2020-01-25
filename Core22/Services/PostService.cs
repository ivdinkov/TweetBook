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


        public bool DeletePost(Guid id)
        {
            var post = GetPostById(id);
            if (post == null)
                return false;

            _posts.Remove(post);

            return true;
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.SingleOrDefault(x=>x.ID == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public bool UpdatePost(Post postToUpdate)
        {
            var exist = GetPostById(postToUpdate.ID) != null;
            if (!exist)
                return false;

            var index = _posts.FindIndex(x => x.ID == postToUpdate.ID);

            _posts[index] = postToUpdate;

            return true;
        }
    }
}
