using System;
using System.Collections.Generic;

namespace AniDb.Api.Models
{
    public class Anime : IEquatable<Anime>
    {
        public int Id { get; set; }
        public bool Restricted { get; set; }
        public string Type { get; set; }

        public string Url { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public int EpisodeCount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Title[] Titles { get; set; }
        public Similar[] Similar { get; set; }
        public IdTypeValue[] Related { get; set; }
        public Recommendations Recommendations { get; set; }
        public IdTypeValue[] Creators { get; set; }
        public Rating Rating { get; set; }
        public AnimeCategory[] Categories { get; set; }
        public AnimeResource[] Resources { get; set; }
        public AnimeTag[] Tags { get; set; }
        public Character[] Characters { get; set; }
        public Episode[] Episodes { get; set; }

        #region equality members

        public bool Equals(Anime other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Anime)obj);
        }

        public override int GetHashCode() {
            return Id;
        }

        #endregion
    }

    public class Title
    {
        public string Type { get; set; }
        public string Lang { get; set; }
        public string Value { get; set; }
    }

    public class Similar
    {
        public int Id { get; set; }
        public int Approval { get; set; }
        public int Total { get; set; }
        public string Value { get; set; }
    }

    public class Recommendations
    {
        public int Total { get; set; }
        public IdTypeValue[] Entries { get; set; }
    }

    public class Rating
    {
        public KeyValuePair<int, double> Permanent { get; set; }
        public KeyValuePair<int, double> Temporary { get; set; }
        public KeyValuePair<int, double>? Review { get; set; }
    }

    public class AnimeCategory
    {
        public int Id { get; set; }
        public int Parentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsHentai { get; set; }
    }

    public class AnimeResource
    {
        public int Type { get; set; }
        public ResourceExternal External { get; set; }
    }

    public class ResourceExternal
    {
        public string Url { get; set; }
        public string[] Identifier { get; set; }
    }

    public class AnimeTag
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Approval { get; set; }
        public bool GlobalSpoiler { get; set; }
        public bool LocalSpoiler { get; set; }
        public bool Spoiler { get; set; }
        public DateTime? Update { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }

        public KeyValuePair<int, double> Rating { get; set; }
        public KeyValuePair<int, string> Charactertype { get; set; }
        public Seiyuu Seiyuu { get; set; }

        public DateTime Update { get; set; }
    }

    public class Seiyuu
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Value { get; set; }
    }

    public class Episode
    {
        public int Id { get; set; }
        public DateTime Update { get; set; }
        public int Length { get; set; }
        public DateTime? AirDate { get; set; }
        public KeyValuePair<int, string>? Epno { get; set; }
        public KeyValuePair<int, double>? Rating { get; set; }
        public KeyValuePair<string, string>[] Titles { get; set; }
    }

    public class IdTypeValue
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}