using Microsoft.Extensions.Configuration;

namespace MyFilms.Models
{
    public class APITicketProvider
    {
        private readonly IConfiguration configuration;

        public APITicketProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetTicket() => configuration["APITicket"];
    }
}
