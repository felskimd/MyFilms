﻿using Microsoft.Net.Http.Headers;
using System.Text.Json;
using MyFilms.Models;
using MyFilms.Models.APIModels;
using MyFilms.Models.DbModels;
using Azure.Core;

namespace MyFilms.Services
{
    public static class KinopoiskAPIService
    {
        private static readonly HttpClient _httpClient;
        private const string NewestShortRequest = $"/v1.4/movie?page=1&limit=5&selectFields=year&selectFields=id&selectFields=name&selectFields=poster&selectFields=rating&selectFields=typeNumber&notNullFields=poster.url&notNullFields=rating.kp&notNullFields=name&sortField=premiere.world&sortType=-1&year=1874-2050";
        private const string PopularShortRequest = $"/v1.4/movie?page=1&limit=5&selectFields=year&selectFields=id&selectFields=name&selectFields=poster&selectFields=rating&selectFields=typeNumber&notNullFields=poster.url&notNullFields=rating.kp&notNullFields=name&sortField=rating.kp&sortType=-1&year=1874-2050";
        private const string RequestById = $"/v1.4/movie/";
        private const string SearchRequest = $"/v1.4/movie/search?limit=20&query=";

        static KinopoiskAPIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.kinopoisk.dev");
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", APITicketProvider.GetTicket());
        }

        public static async Task<ReleaseShort> GetReleaseById(string id)
        {
            string text = await _httpClient.GetStringAsync(RequestById + id);
            var json = JsonDocument.Parse(text);
            var doc = json.RootElement;
            var release = new ReleaseShort(
                doc.GetProperty("id").ToString(),
                doc.GetProperty("name").ToString(),
                doc.GetProperty("poster").GetProperty("previewUrl").ToString(),
                doc.GetProperty("rating").GetProperty("kp").ToString(),
                doc.GetProperty("typeNumber").ToString(),
                doc.GetProperty("year").ToString());
            return release;
        }

        public static Task<string> GetReleasesByPersonId(string personId)
        {
            return null;
        }

        public static async Task<List<ReleaseShort>> GetPopularReleases()
        {
            return await GetShortReleasesByEnum(APIRequests.PopularShorts);
        }

        public static async Task<List<ReleaseShort>> GetNewestReleases()
        {
            return await GetShortReleasesByEnum(APIRequests.NewestShorts);
        }

        private static async Task<List<ReleaseShort>> GetShortReleasesByEnum(APIRequests request)
        {
            string requestString;
            switch(request)
            {
                case APIRequests.NewestShorts: requestString = NewestShortRequest;
                    break;
                case APIRequests.PopularShorts: requestString = PopularShortRequest;
                    break;
                default: requestString = "";
                    break;
            }
            var releases = new List<ReleaseShort>();
            string text = await _httpClient.GetStringAsync(requestString);
            var json = JsonDocument.Parse(text);
            var docs = json.RootElement.GetProperty("docs");
            foreach (var doc in docs.EnumerateArray())
            {
                releases.Add(new ReleaseShort(
                    doc.GetProperty("id").ToString(),
                    doc.GetProperty("name").ToString(),
                    doc.GetProperty("poster").GetProperty("previewUrl").ToString(),
                    doc.GetProperty("rating").GetProperty("kp").ToString(),
                    doc.GetProperty("typeNumber").ToString(),
                    doc.GetProperty("year").ToString()));
            }
            return releases;
        }

        public static async Task<List<ReleaseShort>> Search(string searchString, int? page = null)
        {
            var releases = new List<ReleaseShort>();
            string text = await _httpClient.GetStringAsync(SearchRequest+searchString);
            var json = JsonDocument.Parse(text);
            var docs = json.RootElement.GetProperty("docs");
            foreach (var doc in docs.EnumerateArray())
            {
                releases.Add(new ReleaseShort(
                    doc.GetProperty("id").ToString(),
                    doc.GetProperty("name").ToString(),
                    doc.GetProperty("poster").GetProperty("previewUrl").ToString(),
                    doc.GetProperty("rating").GetProperty("kp").ToString(),
                    doc.GetProperty("typeNumber").ToString(),
                    doc.GetProperty("year").ToString()));
            }
            return releases;
        }

        private enum APIRequests
        {
            NewestShorts,
            PopularShorts,
        }
    }
}