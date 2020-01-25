using Core22.Contract;
using Core22.Contract.v1.Requests;
using Core22.Contract.v1.Responses;
using Core22.Domain;
using Core22.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Controllers
{
    public class PostsController :Controller
    {
        private readonly IPostServices _postService;
        public PostsController(IPostServices postServices)
        {
            _postService = postServices;
        }

        [HttpGet(APIRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet(APIRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpPost(APIRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {

            var post = new Post { ID = postRequest.ID};


            if (post.ID != Guid.Empty)
            {
                post.ID = Guid.NewGuid();
            }

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + APIRoutes.Posts.Get.Replace("postId",post.ID.ToString());


            var response = new PostRespons { ID = post.ID};

            return Created(locationUrl,response);
        }
    }
}
