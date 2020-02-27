using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cakes.Gateway
{
    public static class Mapper
    {
        public static IEnumerable<PodcastMobileViewModel> ToViewModel(this IEnumerable<Podcast> source)
        {
            return source.Select(x => new PodcastMobileViewModel
            {
                Id = x.Id,
                Title = x.Title
            });
        }
    }
    public class PodcastMobileViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}