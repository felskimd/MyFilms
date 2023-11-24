namespace MyFilms.Models.DbModels
{
    public class Vote
    {
        public readonly int Id;
        public readonly int UserId;
        public readonly int CommentAuthorId;
        public readonly int CommentId;
        public readonly bool IsUpvote;
    }
}
