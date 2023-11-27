namespace MyFilms.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsStaff { get; set; }
        //May be add role
    }
}
