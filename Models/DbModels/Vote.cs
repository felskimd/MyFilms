namespace MyFilms.Models.DbModels
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentAuthorId { get; set; }
        public int CommentId { get; set; }
        public bool IsUpvote { get; set; }
    }
}
