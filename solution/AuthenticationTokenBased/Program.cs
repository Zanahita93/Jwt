using Dapper;
using Generation.DbContext;
using JwtTokenGenerationAPI.Configuration;
using JwtTokenGenerationAPI.Models;
using JwtTokenGenerationAPI.Repository;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//public class sth 
//{
//    private static string ConnectionString = "Server=.;Database=AutheniticationTokenBased;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true";
//    public static User GetUser(string username, string password)
//    {
//        var user = new User();
//        var query = ("SELECT * FROM User Where UserName = @UserName, PasswordHash = @PasswordHash");
//        using (IDbConnection db = new SqlConnection("Server=.;Database=AutheniticationTokenBased;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true"))
//        {
//            var Newuser = db.Query<User>(query, new { UserName = username, PasswordHash = password }).SingleOrDefault();
//        }
//        return user;
//    }

//};

//Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddJwtAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
