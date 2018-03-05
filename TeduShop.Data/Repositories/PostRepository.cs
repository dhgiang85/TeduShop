using System.Collections.Generic;

using System.Linq;
using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetByAlias(string alias);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, out int total);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetByAlias(string alias)
        {
            return this.DbContext.Posts.Where(x => x.Alias == alias).ToList();
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, out int total)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status
                        orderby p.CreateDate descending
                        select p
                        ;
            total = query.Count();
            query = query.Skip((page - 1) * pagesize).Take(pagesize);
            return query;
        }
    }
}