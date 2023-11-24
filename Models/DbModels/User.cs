namespace MyFilms.Models.DbModels
{
    public class User
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Email;
        public readonly string PasswordHash;
        public readonly bool IsStaff;
    }
}
