using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public class FooterRepository: RepositoryBase<Footer>
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
