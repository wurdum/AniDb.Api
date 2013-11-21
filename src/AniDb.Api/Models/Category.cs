using System;

namespace AniDb.Api.Models
{
    public class Category : IEquatable<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHentai { get; set; }
        public int ParentId { get; set; }

        #region equality members

        public bool Equals(Category other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id == other.Id && string.Equals(Name, other.Name) && string.Equals(Description, other.Description) &&
                   IsHentai.Equals(other.IsHentai) && ParentId == other.ParentId;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Category)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Id;
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IsHentai.GetHashCode();
                hashCode = (hashCode*397) ^ ParentId;
                return hashCode;
            }
        }

        #endregion

        public override string ToString() {
            return string.Format("Id: {0}, Name: {1}, Description: {2}, IsHentai: {3}, ParentId: {4}", Id, Name, Description, IsHentai, ParentId);
        }
    }
}