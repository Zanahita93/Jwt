namespace JwtTokenGenerationAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
       
    }
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        
    }
}
