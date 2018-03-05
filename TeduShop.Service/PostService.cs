using System.Collections.Generic;
using TeduShop.Data.Infrastructor;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        Post GetById(int id);
        IEnumerable<Post> GetAllPaging(int page, int pagesize, out int total);

        IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pagesize, out int total);
        
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, out int total);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] {"PostCategory"});
        }

        public IEnumerable<Post> GetAllPaging(int page, int pagesize, out int total)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, page, pagesize);
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pagesize, out int total)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out total, page, pagesize,
                new string[] {"PostCategory"});
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, out int total)
        {
            return _postRepository.GetAllByTagPaging(tag, page, pagesize, out total);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}