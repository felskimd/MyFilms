namespace MyFilms.Models.DbModels
{
    public class Release
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReleaseKpId { get; set; }
        public string? Status { get; set; }
        public bool? IsFavourite { get; set; }
    }
}
