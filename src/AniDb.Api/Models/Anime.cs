using System;

namespace AniDb.Api.Models
{
    public class Anime : IEquatable<Anime>
    {
        public string Title { get; set; }

        #region equality members

        public bool Equals(Anime other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Title, other.Title);
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
            return (Title != null ? Title.GetHashCode() : 0);
        }

        #endregion
    }
}