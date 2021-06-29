﻿using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IIdentityService _identityService;

        public AccountController(
            IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // POST: api/account/login/?email=email&password=password
        [HttpPost("login")]
        public async Task<ActionResult<Response<string>>> Login(string email, string password)
        {
            var authorizeResult = await _identityService.AuthenticateAsync(email, password);

            if (!authorizeResult.Succeeded)
            {
                return Unauthorized();
            }

            return Ok(authorizeResult);
        }

        // POST: api/account/register/?username=username&email=email&password=password
        [HttpPost("register")]
        public async Task<ActionResult<Response<string>>> Register(string username, string email, string password)
        {
            var createUserResult = await _identityService.RegisterAsync(username, email, password);

            if (!createUserResult.Succeeded)
            {
                return BadRequest();
            }

            return Ok(createUserResult);
        }

        // POST: api/account/verify-email/?userId=userId&tokenEmail=tokenEmail
        [HttpPost("verify-email")]
        public async Task<ActionResult<Response<string>>> VerifyEmail(string userId, string tokenEmail)
        {
            return BadRequest();
        }
    }
}
