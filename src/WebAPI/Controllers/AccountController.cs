﻿using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Security;
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
        private readonly ITokenService _tokenService;
        private readonly IGoogleService _googleService;

        public AccountController(
            IIdentityService identityService,
            ITokenService tokenService,
            IGoogleService googleService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _googleService = googleService;
        }

        // POST: api/account/login/?email=email&password=password
        [HttpPost("login")]
        public async Task<ActionResult<Response<LoginResponse>>> Login(string email, string password)
        {
            var authorizeResult = await _identityService.AuthenticateAsync(email, password);

            if (!authorizeResult.Succeeded)
            {
                return BadRequest(authorizeResult);
            }

            return Ok(authorizeResult);
        }

        // POST: api/account/login-google/?idToken=idToken
        [HttpPost("login-google")]
        public async Task<ActionResult<Response<LoginResponse>>> LoginGoogle(string idToken)
        {
            var authorizeResult = await _googleService.AuthenticateGoogleAsync(idToken);

            if (!authorizeResult.Succeeded)
            {
                return BadRequest(authorizeResult);
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
                return BadRequest(createUserResult);
            }

            return Ok(createUserResult);
        }

        // POST: api/account/verify-email/?userId=userId&tokenEmail=tokenEmail
        [HttpPost("verify-email")]
        public async Task<ActionResult<Response<string>>> VerifyEmail(string userId, string tokenEmail)
        {
            var verifyEmailResult = await _identityService.VerifyEmailAsync(userId, tokenEmail);

            if (!verifyEmailResult.Succeeded)
            {
                return BadRequest(verifyEmailResult);
            }

            return Ok(verifyEmailResult);
        }

        // POST: api/account/generate-password-reset/?
        [HttpPost("generate-password-reset")]
        public async Task<ActionResult<Response<string>>> GeneretePasswordReset(string email)
        {
            var generetePasswordResetResult = await _identityService.GeneretPasswordResetAsync(email);

            if (!generetePasswordResetResult.Succeeded)
            {
                return BadRequest(generetePasswordResetResult);
            }

            return Ok(generetePasswordResetResult);
        }

        // POST: api/account/change-password/?
        [HttpPost("change-password")]
        public async Task<ActionResult<Response<string>>> ChangePassword(string email, string token, string password)
        {
            var changePasswordResult = await _identityService.ChangePasswordAsync(email, token, password);

            if (!changePasswordResult.Succeeded)
            {
                return BadRequest(changePasswordResult);
            }

            return Ok(changePasswordResult);
        }
    }
}
