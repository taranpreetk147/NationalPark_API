using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NationalPark_API_C3.Data;
using NationalPark_API_C3.Models;
using NationalPark_API_C3.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NationalPark_API_C3.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string userName, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == u.Password);
            if (userInDb == null) return null;
            //JWT Authentication
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role,userInDb.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            userInDb.Token = tokenHandler.WriteToken(token);
            //****

            userInDb.Password = "";
            return userInDb;
        }

        public bool IsUniqueUser(string userName)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (userInDb == null) return true;
            return false;
        }

        public User Register(string userName, string password)
        {
            User user = new User()
            {
                UserName=userName,
                Password=password,
                Role="Admin"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
