namespace MyFilms.Models.DbModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ReleaseId { get; set; }
        public string Text { get; set; }
        public decimal Mark { get; set; }
        public int Rating { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public DateTime PublishingDate { get; set; }

        public void Publish()
        {

        }
    }
}
