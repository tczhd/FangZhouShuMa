using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Services.ApiServices.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FangZhouShuMa.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/access_token")]
    public class UsersController : Controller
    {
        private TokenService TokenService { get; }
        //private ILoginService LoginService { get; }


        //public UsersController(TokenService tokenService, ILoginService loginService)
        //{
        //    TokenService = tokenService;
        //    LoginService = loginService;
        //}

        //// GET: api/access_token
        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    string authHeader = HttpContext.Request.Headers["Authorization"];

        //    var authenticatedUser = LoginService.Authenticate(authHeader);
        //    if (!authenticatedUser.SignInResult.Succeeded)
        //        return Unauthorized();

        //    var userIsAuthorized = LoginService.Authorize(authenticatedUser);
        //    if (!userIsAuthorized)
        //        return Unauthorized();

        //    var token = TokenService.GenerateToken(authenticatedUser);
        //    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //}
    }
}