namespace MyFilms.Models.DbModels
{
    public class Mark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReleaseId { get; set; }
        public MarkEnum? MarkEnum { get; set; }
        public bool IsFavourite { get; set; }
    }

    public enum MarkEnum
    {
        Watching,
        Planned,
        Watched,
        Delayed,
        Abandoned,
    }
}
