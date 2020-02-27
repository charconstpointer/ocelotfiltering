using System.Collections;
using System.Collections.Generic;

namespace Cakes.Gateway
{
    public class PodcastsResponse
    {
        public IEnumerable<Podcast> Items { get; set; }
    }
}