using Core22.Contract;
using Core22.Contract.v1.Requests;
using Core22.Contract.v1.Responses;
using Core22.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Controllers
{
    public class PostsController :Controller
    {
        private List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post {ID = Guid.NewGuid().ToString() });
            }
        }


        [HttpGet(APIRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(APIRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { ID = postRequest.ID};


            if (string.IsNullOrEmpty(post.ID))
            {
                post.ID = Guid.NewGuid().ToString();
            }

            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + APIRoutes.Posts.Get.Replace("postId",post.ID);


            var response = new PostRespons { ID = post.ID};

            return Created(locationUrl,response);
        }
    }
}
