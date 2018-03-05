using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;


namespace TeduShop.Data.Repositories
{
    public interface ISlideTagRepository : IRepository<Slide>
    {

    }
    public class SlideRepository : RepositoryBase<Slide>, ISlideTagRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
