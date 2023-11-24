namespace MyFilms.Models.APIModels
{
    public class Release
    {
        public Release(string id, string name, string description, string type, string posterLink,
            string previewPosterLink, string movieLength, string releaseYear, string[] genres, string[] actors)
        {
            Id = id;
            Name = name;
            Description = description;
            switch (type)
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
            PosterLink = posterLink;
            PreviewPosterLink = previewPosterLink;
            MovieLength = movieLength;
            ReleaseYear = releaseYear;
            Genres = genres;
            Actors = actors;
        }

        public readonly string Id;
        public readonly string Name;
        public readonly string Description;
        public readonly string Type;
        public readonly string PosterLink;
        public readonly string PreviewPosterLink;
        public readonly string MovieLength;
        public readonly string ReleaseYear;
        public readonly string[] Genres;
        public readonly string[] Actors;
    }
}
