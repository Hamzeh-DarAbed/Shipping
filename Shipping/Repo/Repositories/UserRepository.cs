using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shipping.Context;
using Shipping.Dto;
using Shipping.Entities;
using Shipping.repo.IRepositories;

namespace Shipping.repo.Repositories
{
    public class UserRepository : Repository<UserModel, string>, IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(ApplicationDbContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public UserModel Authenticate(LogInUserDto user)
        {
            var currentUser = _context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password) ;
            if (currentUser == null)
                return null;
            return currentUser.First();
        }

        public string GenerateToken(UserModel user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(9), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public UserModel Login([FromBody] LogInUserDto user)
        {

            UserModel currentUser = Authenticate(user);
            if (currentUser == null)
                return null;
            return currentUser;


        }

        public void Register(CreateUserDto user)
        {
            UserModel newUser = new UserModel()
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role
            };
            this.Add(newUser);
        }

    }

}