using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    class TagRepository : RepositoryBase<Tag>
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
