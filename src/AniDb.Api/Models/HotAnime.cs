using System;

namespace AniDb.Api.Models
{
    public class HotAnime : IEquatable<HotAnime>
    {
        public int Id { get; set; }
        public int? EpisodeCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Restricted { get; set; }
        public string Picture { get; set; }

        public Rating Rating { get; set; }

        #region equality members

        public bool Equals(HotAnime other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && EpisodeCount == other.EpisodeCount && StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate) &&
                   Restricted.Equals(other.Restricted) && string.Equals(Picture, other.Picture) && Equals(Rating, other.Rating);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((HotAnime)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Id;
                hashCode = (hashCode*397) ^ EpisodeCount.GetHashCode();
                hashCode = (hashCode*397) ^ StartDate.GetHashCode();
                hashCode = (hashCode*397) ^ EndDate.GetHashCode();
                hashCode = (hashCode*397) ^ Restricted.GetHashCode();
                hashCode = (hashCode*397) ^ (Picture != null ? Picture.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Rating != null ? Rating.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("EpisodeCount: {0}, StartDate: {1}, EndDate: {2}, Id: {3}, Restricted: {4}, Picture: {5}", 
                EpisodeCount, StartDate, EndDate, Id, Restricted, Picture);
        }
    }
}