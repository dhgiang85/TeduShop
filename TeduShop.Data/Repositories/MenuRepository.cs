using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
namespace TeduShop.Data.Repositories
{
    public class MenuRepository: RepositoryBase<Menu>
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
