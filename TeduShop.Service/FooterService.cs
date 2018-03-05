using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructor;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Service
{
    public interface IFooterService
    {
        void Add(Footer menu);

        void Update(Footer menu);

        void Delete(int id);

        IEnumerable<Footer> GetAll();

        IEnumerable<Footer> GetAllPaging(int page, int pagesize, out int total);

        Footer GetById(int id);

        void SaveChanges();
    }

    public class FooterService : IFooterService
    {
        private IFooterRepository _menuRepository;
        private IUnitOfWork _unitOfWork;
        public FooterService(IFooterRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Footer menu)
        {
            _menuRepository.Add(menu);
        }

        public void Update(Footer menu)
        {
            _menuRepository.Update(menu);
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Footer> GetAllPaging(int page, int pagesize, out int total)
        {
            return _menuRepository.GetMultiPaging(x=>!String.IsNullOrEmpty(x.ID), out total, page, pagesize);
        }

        public Footer GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }
        
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


    }
}