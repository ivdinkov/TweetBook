using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Contract
{
    
    public static class APIRoutes
    {
        //public const string Route = "api";
        //public const string Version = "v1";
        //public const string Base = $"{Route}/{Version}";

        public static class Posts
        {
            public const string GetAll = "api/v1/posts";
            public const string Get = "api/v1/posts/{postId}";
            public const string Create = "api/v1/posts";
        }
    }
}
