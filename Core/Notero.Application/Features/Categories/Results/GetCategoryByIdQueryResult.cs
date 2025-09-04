using Notero.Application.Base;

namespace Notero.Application.Features.Categories.Results
{
    public class GetCategoryByIdQueryResult : BaseDto
    {
        public string CategoryName { get; set; }
        //public IList<GetCategoryQueryResult> Blogs { get; set; }
    }
}
