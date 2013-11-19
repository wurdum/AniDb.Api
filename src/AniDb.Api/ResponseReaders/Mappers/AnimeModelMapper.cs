using System;
using System.Collections.Generic;
using System.Linq;
using AniDb.Api.Models;

namespace AniDb.Api.ResponseReaders.Mappers
{
    public class AnimeModelMapper : ModelMapper<Anime, anime>
    {
        public override Anime Map(anime a) {
            return new Anime {
                Id = a.id,
                Restricted = a.restricted,
                Type = a.type,
                Url = a.url,
                Picture = a.picture,
                Description = a.description,
                EpisodeCount = a.episodecount,
                StartDate = a.startdate,
                EndDate = a.enddateSpecified ? a.enddate : (DateTime?)null,
                Titles = ArrayOrEmpty(a.titles).Select(t => new Title { Lang = t.lang, Type = t.type, Value = t.Value }).ToArray(),
                Similar = ArrayOrEmpty(a.similaranime).Select(s => new Similar { Approval = s.approval, Id = s.id, Total = s.total, Value = s.Value}).ToArray(),
                Related = ArrayOrEmpty(a.relatedanime).Select(r => new IdTypeValue {Id = r.id, Type = r.type, Value = r.Value}).ToArray(),
                Recommendations = a.recommendations == null ? null : new Recommendations {
                    Total = a.recommendations.total,
                    Entries = ArrayOrEmpty(a.recommendations.recommendation).Select(r => new IdTypeValue { Id = Convert.ToInt32(r.uid), Type = r.type, Value = r.Value }).ToArray()
                },
                Creators = ArrayOrEmpty(a.creators).Select(c => new IdTypeValue {Id = c.id, Type = c.type, Value = c.Value}).ToArray(),
                Rating = new Rating {
                    Permanent = new KeyValuePair<int, double>(a.ratings.permanent.count, Convert.ToDouble(a.ratings.permanent.Value)),
                    Temporary = new KeyValuePair<int, double>(a.ratings.temporary.count, Convert.ToDouble(a.ratings.temporary.Value)),
                    Review = a.ratings.review == null 
                        ? (KeyValuePair<int, double>?)null
                        : new KeyValuePair<int, double>(a.ratings.review.count, Convert.ToDouble(a.ratings.review.Value))
                },
                Categories = ArrayOrEmpty(a.categories).Select(c => new AnimeCategory {
                    Id = c.id, Parentid = c.parentid, Name = c.name, Description = c.description, IsHentai = c.hentai, Weight = c.weight
                }).ToArray(),
                Resources = ArrayOrEmpty(a.resources).Select(r => new AnimeResource {
                    External = ArrayOrEmpty(r.externalentity).Select(e => new ResourceExternal {
                        Url = e.url,
                        Identifier = e.identifier
                    }).ToArray(),
                    Type = r.type
                }).ToArray(),
                Tags = ArrayOrEmpty(a.tags).Select(t => new AnimeTag {
                    Id = t.id, Count = t.count, Approval = t.approval, Description = t.description, GlobalSpoiler = t.globalspoiler,
                    LocalSpoiler = t.localspoiler, Name = t.name, Spoiler = t.spoiler, Update = t.update
                }).ToArray(),
                Characters = ArrayOrEmpty(a.characters).Select(c => new Character {
                    Id = c.id, Type = c.type, Description = c.description, Name = c.name, Gender = c.gender, Picture = c.picture,
                    Seiyuu = ArrayOrEmpty(c.seiyuu).Select(s => new Seiyuu { Id = s.id, Picture = s.picture, Value = s.Value }).ToArray(),
                    Rating = c.rating != null ? new KeyValuePair<int, double>(c.rating.votes, Convert.ToDouble(c.rating.Value)) : (KeyValuePair<int, double>?)null,
                    Update = c.update,
                    Charactertype = c.charactertype != null ? new KeyValuePair<int, string>(c.charactertype.id, c.charactertype.Value) : (KeyValuePair<int, string>?)null
                }).ToArray(),
                Episodes = ArrayOrEmpty(a.episodes).Select(ParseEpisode).ToArray()
            };
        }

        protected virtual Episode ParseEpisode(animeEpisode e) {
            var episode = new Episode {Id = Convert.ToInt32(e.id), Update = e.update};
            var titles = new List<KeyValuePair<string, string>>();
            foreach (var item in e.Items) {
                var type = item.GetType();
                if (type == typeof (DateTime)) {
                    episode.AirDate = (DateTime)item;
                } else if (type == typeof (animeEpisodeEpno)) {
                    var epno = (animeEpisodeEpno)item;
                    episode.Epno = new KeyValuePair<int, string>(epno.type, epno.Value);
                } else if (type == typeof (ushort)) {
                    episode.Length = (ushort)item;
                } else if (type == typeof (animeEpisodeRating)) {
                    var rating = (animeEpisodeRating)item;
                    episode.Rating = new KeyValuePair<int, double>(rating.votes, Convert.ToDouble(rating.Value));
                } else if (type == typeof (animeEpisodeTitle)) {
                    var title = (animeEpisodeTitle)item;
                    titles.Add(new KeyValuePair<string, string>(title.lang, title.Value));
                } else {
                    throw new InvalidCastException("Unknown type in episode encountered: " + type);
                }
            }

            episode.Titles = titles.ToArray();
            return episode;
        }
    }
}