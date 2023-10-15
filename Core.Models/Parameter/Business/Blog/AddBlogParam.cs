using Core.Common.Base;

namespace Core.Models.Parameter.Business.Blog
{
    public class AddBlogParam : BaseParam
    {
        public string Title { get; set; }

        public int CdnFileId { get; set; }

        public string Text { get; set; }
    }
}
