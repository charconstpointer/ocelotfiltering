using System;
using System.Collections.Generic;

namespace Cakes.Gateway
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RadioStation { get; set; }
        public string Audition { get; set; }
        public string Language { get; set; }
        public string PodcastUrl { get; set; }
        public string ItunesKeywords { get; set; }
        public string ItunesCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid Guid { get; set; }
        public int ViewCount { get; set; }
        public int ItemCount { get; set; }
        public DateTime LastItemUpdate { get; set; }
        public string Announcer { get; set; }
        public string AnnouncerImg { get; set; }
        public string Email { get; set; }
    }
}