namespace MyFilms.Models.APIModels
{
    public class ReleaseShort
    {
        public ReleaseShort(string? id, string? name, string? previewPosterLink, string? kpRating, string? type, string? year)
        {
            Id = id;
            Name = name;
            PreviewPosterLink = previewPosterLink;
            KpRating = kpRating;
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
            Year = year;
        }

        public readonly string? Id;
        public readonly string? Name;
        public readonly string? PreviewPosterLink;
        public readonly string? KpRating;
        public readonly string? Type;
        public readonly string? Year;
    }
}
