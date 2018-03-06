using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data.Infrastructor;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoyTest
    {
        private IDbFactory dbFactory;
        private IPostCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category  = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test category";
            category.Status = true;
            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ID,3);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3,list.Count);
        }
    }
}