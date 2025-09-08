using Notero.Domain.Entities.Common;

namespace Notero.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
