using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructor;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Service
{
    public interface IMenuService
    {
        void Add(Menu menu);

        void Update(Menu menu);

        void Delete(int id);

        IEnumerable<Menu> GetAll();

        IEnumerable<Menu> GetAllPaging(int page, int pagesize, out int total);

        Menu GetById(int id);

        void SaveChanges();
    }

    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _unitOfWork;
        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Menu menu)
        {
            _menuRepository.Add(menu);
        }

        public void Update(Menu menu)
        {
            _menuRepository.Update(menu);
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll(new string[] {"MenuGroup"});
        }

        public IEnumerable<Menu> GetAllPaging(int page, int pagesize, out int total)
        {
            return _menuRepository.GetMultiPaging(x => x.ID!=0, out total, page, pagesize);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


    }
}