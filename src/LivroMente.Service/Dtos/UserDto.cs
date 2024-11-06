namespace LivroMente.Service.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public bool IsActive {get; set;}
        public List<string> Roles { get; set; }
    }
}