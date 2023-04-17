using AutoMapper;
using LibraryStore.Domain.Models.DTO.User;
using LibraryStore.CrossCutting.Utils.Notification;
using LibraryStore.CrossCutting.Utils.Notification.Enums;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using LibraryStore.Domain.Commands.User;
using LibraryStore.Domain.Entities;
using LibraryStoreApp.Domain.Static;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryStore.Domain.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, IOperation>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public LoginCommandHandler(IMapper mapper, UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IOperation> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                return Result.CreateFailure(ErrorCodes.Unauthorized);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, command.Password);
            if (passwordValid == false)
            {
                return Result.CreateFailure(ErrorCodes.Unauthorized);
            }

            string tokenString = await GenerateToken(user);

            var response = new AuthResponse
            {
                Email = command.Email,
                Token = tokenString,
                UserId = user.Id,
            };

            return Result.CreateSuccess(response);
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e7fa77c8-111c-4645-8796-36c8e7e144e9"));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
