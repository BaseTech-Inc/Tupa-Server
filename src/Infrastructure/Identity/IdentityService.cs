﻿using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using Microsoft.Extensions.Configuration;

using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Security;
using Application.Common.Enumerations;
using Domain.Entities;
using Domain.Enumerations;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            RoleManager<IdentityRole> roleManager,
            IApplicationDbContext context,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<Response<LoginResponse>> AuthenticateAsync(string email, string password)
        {
            // verifica se o usuário existe, para não gerar futuros erros
            var user = await _userManager.FindByEmailAsync(email);

            if (!(user == null))
            {
                // verifica se a senha passada é correta
                var checkPassword = await _userManager.CheckPasswordAsync(user, password);

                if (checkPassword)
                {
                    if (user.EmailConfirmed)
                    {
                        var authenticatedRole = new IdentityRole(Roles.Authenticated.ToString());

                        if (_roleManager.Roles.All(r => r.Name != authenticatedRole.Name))
                        {
                            await _roleManager.CreateAsync(authenticatedRole);
                        }

                        await _userManager.AddToRolesAsync(user, new[] { authenticatedRole.Name });

                        var usuario = _context.Usuario.Where(x => x.ApplicationUserID == user.Id).FirstOrDefault();

                        var token = await _tokenService.GenerateTokenJWT(usuarioId: usuario.Id, userId: user.Id);

                        var response = new LoginResponse()
                        {
                            uid = usuario.Id,
                            access_token = token.tokenString,
                            token_type = "bearer",
                            expiration = token.validTo
                        };

                        return new Response<LoginResponse>(response, message: $"Authenticated { user.UserName }");
                    }
                }
            }

            return new Response<LoginResponse>(message: $"An error occurred while authenticating user.");
        }

        public async Task<Response<string>> RegisterAsync(string username, string email, string password)
        {
            var userExist = await _userManager.FindByNameAsync(username);
            var emailExist = await _userManager.FindByEmailAsync(email);

            // verifica se não existe nenhum usuário cadastrado com esse username e email
            if ((userExist == null) && (emailExist == null))
            {
                var listUsuario = new List<Usuario>();

                var usuario = new Usuario
                { 
                    Email = email,
                    TipoUsuario = new TipoUsuario
                    {
                        Descricao = EnumTipoUsuario.Comum
                    }
                };

                listUsuario.Add(usuario);                

                var appUser = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    Usuario = listUsuario
                };

                var resultCreateAppUser = await _userManager.CreateAsync(appUser, password);

                if (resultCreateAppUser.Succeeded)
                {
                    var tokenEmail = await _tokenService.GenerateTokenEmail(appUser.Id);
                    var url = $"{ _configuration["baseUrl"] }api/Account/verify-email?userId=" + HttpUtility.UrlEncode(usuario.Id) + "&tokenEmail=" + HttpUtility.UrlEncode(tokenEmail);

                    await _emailService.SendEmailAsync(
                        appUser.Email,
                        _emailService.templateBodyVerifyEmail(
                            appUser.UserName,
                            url),
                        "Tupa - Verification");

                    return new Response<string>(usuario.Id, message: $"User Registered. Please confirm your account by visiting this URL { url }");
                }
            } 
            else
            {
                return new Response<string>(message: $"You already have a registered user with this credential.");
            }

            return new Response<string>(message: $"Error during registration.");
        }

        public async Task<Response<string>> VerifyEmailAsync(string userId, string tokenEmail)
        {
            var usuario = _context.Usuario.Where(x => x.Id == userId).FirstOrDefault();

            var user = await _userManager.FindByIdAsync(usuario.ApplicationUserID);

            if (user != null)
            {
                var resultConfirmEmail = await _userManager.ConfirmEmailAsync(user, tokenEmail);

                if (resultConfirmEmail.Succeeded)
                {
                    return new Response<string>(usuario.Id, message: $"Email confirmed successfully.");
                }
            }

            return new Response<string>(message: $"Failed to verify email.");
        }

        public async Task<Response<string>> GeneretPasswordResetAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                await _emailService.SendEmailAsync(
                    user.Email,
                    token,
                    "Tupa - Change Password");

                return new Response<string>(token, message: $"Successfully generated token.");
            }

            return new Response<string>(message: $"This email was not registered.");
        }

        public async Task<Response<string>> ChangePasswordAsync(string userId, string token, string password)
        {
            return new Response<string>(message: $"Failed to change password.");
        }
    }
}
