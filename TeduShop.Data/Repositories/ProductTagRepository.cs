using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    class ProductTagRepository : RepositoryBase<ProductTag>
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
