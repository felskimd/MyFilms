using System.Text.Json.Serialization;

namespace MyFilms.Models
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

    public class Vote
    {
        public readonly int Id;
        public readonly int UserId;
        public readonly int AuthorId;
        public readonly int CommentId;
        public readonly bool IsUpvote;
    }

    public class User
    {
        public readonly int Id;
        public readonly int UserName;
        public readonly DateOnly RegistrationDate;
    }

    public class Actor
    {
        public readonly string Id;
        public readonly string Name;
    }

    public class FilmDirector
    {
        public readonly string Id;
        public readonly string Name;
    }

    public class Release
    {
        public Release(string? id, string? name, string? enName, string? description, string? type, string? posterLink,
            string? previewPosterLink, string? movieLength, string? releaseYear, string[] genres, string[] actors)
        {

        }

        public readonly string? Id;
        public readonly string? Name;
        public readonly string? Description;
        public readonly string? Type;
        public readonly string? PosterLink;
        public readonly string? PreviewPosterLink;
        public readonly string? MovieLength;
        public readonly string? ReleaseYear;
        public readonly string[] Genres;
        public readonly string[] Actors;
    }

    public class ReleaseShort
    {
        public ReleaseShort(string? id, string? name, string? previewPosterLink, string? kpRating, string? type)
        {
            Id = id; Name = name; PreviewPosterLink = previewPosterLink; KpRating = kpRating;
            switch(type)
            {
                case "1":
                    Type = "фильм";
                    break; 
                case "2":
                    Type = "сериал";
                    break; 
                case "3":
                    Type = "мультфильм";
                    break;
                case "4":
                    Type = "аниме";
                    break;
                case "5":
                    Type = "мультсериал";
                    break;
            }
        }

        public readonly string? Id;
        public readonly string? Name;
        public readonly string? PreviewPosterLink;
        public readonly string? KpRating;
        public readonly string? Type;
    }
}
