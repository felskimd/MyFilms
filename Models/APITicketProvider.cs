using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MyFilms.Models
{
    public static class APITicketProvider
    {
        public static string GetTicket() 
        { 
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config.GetSection("APITicket").Value;
        }
    }
}
