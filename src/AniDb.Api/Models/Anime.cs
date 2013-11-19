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

        public override string ToString() {
            return string.Format("Id: {0}, Restricted: {1}, Type: {2}, Url: {3}, Picture: {4}, Description: {5}, EpisodeCount: {6}, " +
                                 "StartDate: {7}, EndDate: {8}", Id, Restricted, Type, Url, Picture, Description, EpisodeCount, StartDate, EndDate);
        }
    }

    public class Title
    {
        public string Type { get; set; }
        public string Lang { get; set; }
        public string Value { get; set; }

        public override string ToString() {
            return string.Format("Type: {0}, Lang: {1}, Value: {2}", Type, Lang, Value);
        }
    }

    public class Similar
    {
        public int Id { get; set; }
        public int Approval { get; set; }
        public int Total { get; set; }
        public string Value { get; set; }

        public override string ToString() {
            return string.Format("Id: {0}, Approval: {1}, Total: {2}, Value: {3}", Id, Approval, Total, Value);
        }
    }

    public class Recommendations
    {
        public int Total { get; set; }
        public IdTypeValue[] Entries { get; set; }

        public override string ToString() {
            return string.Format("Total: {0}", Total);
        }
    }

    public class Rating
    {
        public KeyValuePair<int, double> Permanent { get; set; }
        public KeyValuePair<int, double> Temporary { get; set; }
        public KeyValuePair<int, double>? Review { get; set; }

        public override string ToString() {
            return string.Format("Permanent: {0}, Temporary: {1}, Review: {2}", Permanent, Temporary, Review);
        }
    }

    public class AnimeCategory
    {
        public int Id { get; set; }
        public int Parentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsHentai { get; set; }

        public override string ToString() {
            return string.Format("Id: {0}, Parentid: {1}, Name: {2}, Description: {3}, Weight: {4}, IsHentai: {5}", 
                Id, Parentid, Name, Description, Weight, IsHentai);
        }
    }

    public class AnimeResource
    {
        public int Type { get; set; }
        public ResourceExternal[] External { get; set; }

        public override string ToString() {
            return string.Format("Type: {0}", Type);
        }
    }

    public class ResourceExternal
    {
        public string Url { get; set; }
        public string[] Identifier { get; set; }

        public override string ToString() {
            return string.Format("Url: {0}, Identifier: {1}", Url, Identifier);
        }
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

        public override string ToString() {
            return string.Format("Id: {0}, Count: {1}, Name: {2}, Description: {3}, Approval: {4}, GlobalSpoiler: {5}, " +
                                 "LocalSpoiler: {6}, Spoiler: {7}, Update: {8}", Id, Count, Name, Description, Approval, GlobalSpoiler, 
                                 LocalSpoiler, Spoiler, Update);
        }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }

        public KeyValuePair<int, double>? Rating { get; set; }
        public KeyValuePair<int, string>? Charactertype { get; set; }
        public Seiyuu[] Seiyuu { get; set; }

        public DateTime Update { get; set; }

        public override string ToString() {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, Picture: {3}, Type: {4}, Gender: {5}, Update: {6}", 
                Id, Name, Description, Picture, Type, Gender, Update);
        }
    }

    public class Seiyuu
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Value { get; set; }

        public override string ToString() {
            return string.Format("Id: {0}, Picture: {1}, Value: {2}", Id, Picture, Value);
        }
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

        public override string ToString() {
            return string.Format("Id: {0}, Update: {1}, Length: {2}, AirDate: {3}", Id, Update, Length, AirDate);
        }
    }

    public class IdTypeValue
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public override string ToString() {
            return string.Format("Id: {0}, Type: {1}, Value: {2}", Id, Type, Value);
        }
    }
}