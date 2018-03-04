using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;


namespace TeduShop.Data.Repositories
{
    public class SlideRepository : RepositoryBase<Slide>
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
