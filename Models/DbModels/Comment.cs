namespace MyFilms.Models.DbModels
{
    public class Comment
    {
        public readonly int Id;
        public readonly int AuthorId;
        public readonly int ReleaseId;
        public readonly string Text;
        public readonly decimal Mark;
        public readonly int Rating;
        public readonly int UpVotes;
        public readonly int DownVotes;
        public readonly DateTime PublishingDate;

        public void Publish()
        {

        }
    }
}
