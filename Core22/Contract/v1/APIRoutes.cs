﻿namespace Core22.Contract
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
            public const string Update = "api/v1/posts/{postId}";
            public const string Delete = "api/v1/posts/{postId}";
            public const string Create = "api/v1/posts";
        }

        public static class Identity
        {
            public const string Login = "api/v1/identity/login";
            public const string Register = "api/v1/identity/register";
            public const string Refresh = "api/v1/identity/refresh";
        }
    }
}
