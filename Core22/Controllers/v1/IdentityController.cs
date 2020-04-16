using Core22.Contract;
using Core22.Contract.v1.Requests;
using Core22.Contract.v1.Responses;
using Core22.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22.Controllers.v1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;

        }


        [HttpPost(APIRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( new AuthFailResponse
                {
                    Errors = ModelState.Values.SelectMany(x=>x.Errors.Select(e=>e.ErrorMessage))
                });
            }

            var authResonse = await _identityService.RegiterAsync(request.Email, request.Password);

            if (!authResonse.Success)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = authResonse.Errors
                });
            }

            return Ok(new AuthSuccessResponse { 
                Token = authResonse.Token
            });
        }

        [HttpPost(APIRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage))
                });
            }

            var authResonse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResonse.Success)
            {
                return BadRequest(new AuthFailResponse
                {
                    Errors = authResonse.Errors
                });
            }

            return Ok(new AuthSuccessResponse { 
                Token = authResonse.Token
            });
        }
    }
}
