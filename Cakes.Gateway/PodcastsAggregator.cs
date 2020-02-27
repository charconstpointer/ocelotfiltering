using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Cakes.Gateway
{
    public class PodcastsAggregator : IDefinedAggregator
    {

        private PodcastsResponse DeserializePodcasts(string response)
        {
            try
            {
                var podcasts = JsonConvert.DeserializeObject<PodcastsResponse>(response);
                return podcasts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            var podcastsResponse = responses.FirstOrDefault(r => r.DownstreamReRoute.Key.Equals("Podcasts"));
            if (podcastsResponse == null) throw new Exception("later");
            var podcasts = await podcastsResponse.DownstreamResponse.Content.ReadAsStringAsync();
            var deserialized = DeserializePodcasts(podcasts);
            var podcastsMobile = deserialized.Items.ToViewModel();
            var responseBuilder = new StringBuilder();
            responseBuilder.Append(JsonConvert.SerializeObject(podcastsMobile));
            var stringContent = new StringContent(responseBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK,
                new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}