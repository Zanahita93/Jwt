using Generation.DbContext;
using JwtTokenGenerationAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;


namespace JwtTokenGenerationAPI.Repository
{

    public class JwtService : IJwtService
    {
        //private static string ConnectionString = "Data Source = .;Initial Catalog=Jwt_DB;Integrated Security = True;";
        private readonly DapperContext _context;
        public JwtService(DapperContext context)
        {
            _context = context;
        }

        public  string Generate(User user)
        {
            var secreteKey = Encoding.UTF8.GetBytes("MySecreteKey123456789");
            var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secreteKey), SecurityAlgorithms.HmacSha256Signature);
            var claims = _getClaims(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "Zameni",
                Audience = "zameni",
                //IssuedAt = DateTime.UtcNow,
                //NotBefore = DateTime.UtcNow,
                //Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = SigningCredentials,
                Subject = new ClaimsIdentity(claims),
            };
            try
            {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            
            try
            {
                //List<User> list;
                //using (IDbConnection db = new SqlConnection(ConnectionString))
                //{
                //    list = db.Query<User>("Select * From Users").ToList();
                //}
                //return list;
                var query = "Select * From Users";
                using (var connection = _context.CreateConnection())
                {
                    var user = await connection.QueryAsync<User>(query);
                    return user.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetByUserAndPass(string username, string password)
        {
            try
            {
            var query = ("SELECT * FROM Users Where UserName = @UserName");
            var query2 = ("SELECT * FROM Users Where Password = @Password");
            using (var connection = _context.CreateConnection())
            {
                //var user = await connection.QueryAsync<User>(query, new { UserName = username , PasswordHash = password });
                var user = await connection.QueryAsync<User>(query, new { UserName = username });
                    user = await connection.QueryAsync<User>(query2, new { password = password });
                var result = user.Single();
                return result;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IEnumerable<Claim> _getClaims(User user)
        {
            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.ID.ToString()),
            };
            return Claims;
        }

        public async Task<string> AddUser(UserDto user)
        {
            try
            {
            UserDto newuser = new UserDto()
            {
                UserName = user.UserName,
                Password = user.Password,
                FullName = user.FullName,
            };
            using (var connection = _context.CreateConnection())
            {
                string sqlQuery = "INSERT INTO Users (UserName, Password, FullName) VALUES(@UserName, @Password, @FullName)";

                int rowsAffected = connection.Execute(sqlQuery, newuser);
            }

            return "ok";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

