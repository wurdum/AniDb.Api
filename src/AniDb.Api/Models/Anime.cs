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
            return Id == other.Id && Restricted.Equals(other.Restricted) && string.Equals(Type, other.Type) && string.Equals(Url, other.Url) &&
                   string.Equals(Picture, other.Picture) && string.Equals(Description, other.Description) && EpisodeCount == other.EpisodeCount &&
                   StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate) && Titles.SafeSequenceEqual(other.Titles) &&
                   Similar.SafeSequenceEqual(other.Similar) && Related.SafeSequenceEqual(other.Related) && Equals(Recommendations, other.Recommendations) &&
                   Creators.SafeSequenceEqual(other.Creators) && Equals(Rating, other.Rating) && Categories.SafeSequenceEqual(other.Categories) &&
                   Resources.SafeSequenceEqual(other.Resources) && Tags.SafeSequenceEqual(other.Tags) && Characters.SafeSequenceEqual(other.Characters) &&
                   Episodes.SafeSequenceEqual(other.Episodes);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Anime)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ Restricted.GetHashCode();
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Picture != null ? Picture.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EpisodeCount;
                hashCode = (hashCode * 397) ^ StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Titles != null ? Titles.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Similar != null ? Similar.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Related != null ? Related.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Recommendations != null ? Recommendations.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Creators != null ? Creators.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Rating != null ? Rating.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Categories != null ? Categories.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Resources != null ? Resources.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Characters != null ? Characters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Episodes != null ? Episodes.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Restricted: {1}, Type: {2}, Url: {3}, Picture: {4}, Description: {5}, EpisodeCount: {6}, " +
                                 "StartDate: {7}, EndDate: {8}", Id, Restricted, Type, Url, Picture, Description, EpisodeCount, StartDate, EndDate);
        }
    }

    public class Title : IEquatable<Title>
    {
        public string Type { get; set; }
        public string Lang { get; set; }
        public string Value { get; set; }

        #region equality members

        public bool Equals(Title other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Type, other.Type) && string.Equals(Lang, other.Lang) && string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Title)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Lang != null ? Lang.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Type: {0}, Lang: {1}, Value: {2}", Type, Lang, Value);
        }
    }

    public class Similar : IEquatable<Similar>
    {
        public int Id { get; set; }
        public int Approval { get; set; }
        public int Total { get; set; }
        public string Value { get; set; }

        #region equality members

        public bool Equals(Similar other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && Approval == other.Approval && Total == other.Total && string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Similar)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Approval;
                hashCode = (hashCode * 397) ^ Total;
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Approval: {1}, Total: {2}, Value: {3}", Id, Approval, Total, Value);
        }
    }

    public class Recommendations : IEquatable<Recommendations>
    {
        public int Total { get; set; }
        public IdTypeValue[] Entries { get; set; }

        #region equality members

        public bool Equals(Recommendations other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Total == other.Total && Entries.SafeSequenceEqual(other.Entries);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Recommendations)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Total * 397) ^ (Entries != null ? Entries.GetHashCode() : 0);
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Total: {0}", Total);
        }
    }

    public class Rating : IEquatable<Rating>
    {
        public KeyValuePair<int, double>? Permanent { get; set; }
        public KeyValuePair<int, double>? Temporary { get; set; }
        public KeyValuePair<int, double>? Review { get; set; }

        #region equality members

        public bool Equals(Rating other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Permanent.Equals(other.Permanent) && Temporary.Equals(other.Temporary) && Review.Equals(other.Review);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Rating)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Permanent.GetHashCode();
                hashCode = (hashCode * 397) ^ Temporary.GetHashCode();
                hashCode = (hashCode * 397) ^ Review.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Permanent: {0}, Temporary: {1}, Review: {2}", Permanent, Temporary, Review);
        }
    }

    public class AnimeCategory : IEquatable<AnimeCategory>
    {
        public int Id { get; set; }
        public int Parentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsHentai { get; set; }

        #region equality members

        public bool Equals(AnimeCategory other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && Parentid == other.Parentid && string.Equals(Name, other.Name) && string.Equals(Description, other.Description) &&
                   Weight == other.Weight && IsHentai.Equals(other.IsHentai);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((AnimeCategory)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ Parentid;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Weight;
                hashCode = (hashCode * 397) ^ IsHentai.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Parentid: {1}, Name: {2}, Description: {3}, Weight: {4}, IsHentai: {5}",
                Id, Parentid, Name, Description, Weight, IsHentai);
        }
    }

    public class AnimeResource : IEquatable<AnimeResource>
    {
        public int Type { get; set; }
        public ResourceExternal[] External { get; set; }

        #region equality members

        public bool Equals(AnimeResource other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Type == other.Type && External.SafeSequenceEqual(other.External);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((AnimeResource)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Type * 397) ^ (External != null ? External.GetHashCode() : 0);
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Type: {0}", Type);
        }
    }

    public class ResourceExternal : IEquatable<ResourceExternal>
    {
        public string Url { get; set; }
        public string[] Identifier { get; set; }

        #region equality members

        public bool Equals(ResourceExternal other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Url, other.Url) && Identifier.SafeSequenceEqual(Identifier);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((ResourceExternal)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Url != null ? Url.GetHashCode() : 0) * 397) ^ (Identifier != null ? Identifier.GetHashCode() : 0);
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Url: {0}, Identifier: {1}", Url, Identifier);
        }
    }

    public class AnimeTag : IEquatable<AnimeTag>
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

        #region equality members

        public bool Equals(AnimeTag other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && Count == other.Count && string.Equals(Name, other.Name) && string.Equals(Description, other.Description) &&
                   Approval == other.Approval && GlobalSpoiler.Equals(other.GlobalSpoiler) && LocalSpoiler.Equals(other.LocalSpoiler) &&
                   Spoiler.Equals(other.Spoiler) && Update.Equals(other.Update);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((AnimeTag)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ Count;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Approval;
                hashCode = (hashCode * 397) ^ GlobalSpoiler.GetHashCode();
                hashCode = (hashCode * 397) ^ LocalSpoiler.GetHashCode();
                hashCode = (hashCode * 397) ^ Spoiler.GetHashCode();
                hashCode = (hashCode * 397) ^ Update.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Count: {1}, Name: {2}, Description: {3}, Approval: {4}, GlobalSpoiler: {5}, " +
                                 "LocalSpoiler: {6}, Spoiler: {7}, Update: {8}", Id, Count, Name, Description, Approval, GlobalSpoiler,
                                 LocalSpoiler, Spoiler, Update);
        }
    }

    public class Character : IEquatable<Character>
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

        #region equality members

        public bool Equals(Character other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && string.Equals(Name, other.Name) && string.Equals(Description, other.Description) &&
                   string.Equals(Picture, other.Picture) && string.Equals(Type, other.Type) && string.Equals(Gender, other.Gender) &&
                   Rating.Equals(other.Rating) && Charactertype.Equals(other.Charactertype) && Seiyuu.SafeSequenceEqual(other.Seiyuu) &&
                   Update.Equals(other.Update);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Character)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Picture != null ? Picture.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Gender != null ? Gender.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Rating.GetHashCode();
                hashCode = (hashCode * 397) ^ Charactertype.GetHashCode();
                hashCode = (hashCode * 397) ^ (Seiyuu != null ? Seiyuu.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Update.GetHashCode();
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, Picture: {3}, Type: {4}, Gender: {5}, Update: {6}",
                Id, Name, Description, Picture, Type, Gender, Update);
        }
    }

    public class Seiyuu : IEquatable<Seiyuu>
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Value { get; set; }

        #region equality members

        public bool Equals(Seiyuu other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && string.Equals(Picture, other.Picture) && string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Seiyuu)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Picture != null ? Picture.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Picture: {1}, Value: {2}", Id, Picture, Value);
        }
    }

    public class Episode : IEquatable<Episode>
    {
        public int Id { get; set; }
        public DateTime Update { get; set; }
        public int Length { get; set; }
        public bool? Recap { get; set; }
        public DateTime? AirDate { get; set; }
        public KeyValuePair<int, string>? Epno { get; set; }
        public KeyValuePair<int, double>? Rating { get; set; }
        public KeyValuePair<string, string>[] Titles { get; set; }

        #region equality members

        public bool Equals(Episode other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && Update.Equals(other.Update) && Length == other.Length && AirDate.Equals(other.AirDate) && Epno.Equals(other.Epno) &&
                   Rating.Equals(other.Rating) && Titles.SafeSequenceEqual(other.Titles);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Episode)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode * 397) ^ Update.GetHashCode();
                hashCode = (hashCode * 397) ^ Length;
                hashCode = (hashCode * 397) ^ AirDate.GetHashCode();
                hashCode = (hashCode * 397) ^ Epno.GetHashCode();
                hashCode = (hashCode * 397) ^ Rating.GetHashCode();
                hashCode = (hashCode * 397) ^ (Titles != null ? Titles.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Update: {1}, Length: {2}, AirDate: {3}", Id, Update, Length, AirDate);
        }
    }

    public class IdTypeValue : IEquatable<IdTypeValue>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        #region equality members

        public bool Equals(IdTypeValue other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && string.Equals(Type, other.Type) && string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((IdTypeValue)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Type: {1}, Value: {2}", Id, Type, Value);
        }
    }
}