using System;
using System.Collections.Generic;
using System.Linq;
using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders.Mappers
{
    public class HotModelMapper : ModelMapper<HotAnime[], hotanime>
    {
        public override HotAnime[] Map(hotanime h) {
            return ArrayOrEmpty(h.anime).Select(a => new HotAnime {
                Id = a.id,
                Restricted = a.restricted,
                EpisodeCount = a.episodecountSpecified ? a.episodecount : (int?)null,
                StartDate = a.startdate,
                EndDate = a.enddateSpecified ? a.enddate : (DateTime?)null,
                Picture = a.picture,
                Rating = a.ratings != null ? new Rating {
                    Permanent = a.ratings.permanent == null
                        ? (KeyValuePair<int, double>?)null
                        : new KeyValuePair<int, double>(a.ratings.permanent.count, Convert.ToDouble(a.ratings.permanent.Value)),
                    Temporary = a.ratings.temporary == null
                        ? (KeyValuePair<int, double>?)null
                        : new KeyValuePair<int, double>(a.ratings.temporary.count, Convert.ToDouble(a.ratings.temporary.Value)),
                    Review = a.ratings.review == null
                        ? (KeyValuePair<int, double>?)null
                        : new KeyValuePair<int, double>(a.ratings.review.count, Convert.ToDouble(a.ratings.review.Value))
                } : null
            }).ToArray();
        }
    }
}