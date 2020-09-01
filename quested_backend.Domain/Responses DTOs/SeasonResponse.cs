using System.Collections.Generic;

namespace quested_backend.Domain.Responses_DTOs
{
    public class SeasonResponse
    {
        public int? Id { get; set; }
        
        public string Name { get; set; }

        public IEnumerable<EpisodeResponse> HasEpisodes;
    }
}