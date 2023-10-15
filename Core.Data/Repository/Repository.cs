using Core.DataContract;

namespace Core.Data.Repository
{
    public partial class Repository: IRepository
    {
        private  IContext _context { get; set; }
        public Repository(IContext context)
        {
            _context = context;
        }
    }
}
