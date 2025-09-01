using Notero.Application.Base;

namespace Notero.Application.Features.Categories.Results
{
    public class GetCategoryQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
