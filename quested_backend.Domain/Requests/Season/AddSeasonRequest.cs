using System.Collections.Generic;

namespace quested_backend.Domain.Requests.Season
{
    public class AddSeasonRequest
    {
        public string Name { get; set; }
        //
        // public virtual ICollection<int> CourseIds { get; set; }
        //
        // public virtual ICollection<int> EpisodeIds { get; set; }
        //
        // public virtual ICollection<int> SchoolOwnsSeasonIds { get; set; }
    }
}