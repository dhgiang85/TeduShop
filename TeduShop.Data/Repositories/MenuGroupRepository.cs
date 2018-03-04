using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    internal class MenuGroupRepository :RepositoryBase<MenuGroup>
    {
        public MenuGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}