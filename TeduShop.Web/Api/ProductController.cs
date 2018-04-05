using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extensions;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService)
            : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                
                var model = _productService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
                var responese = request.CreateResponse(HttpStatusCode.OK, responseData);
                return responese;
            });
        }





        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize=20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x=>x.CreateDate).Skip(page*pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);
                PaginationSet<ProductViewModel> paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page =  page,
                    TotalCount = totalRow,
                    TotalPages =(int) Math.Ceiling((decimal)totalRow/pageSize),
                };
                var responese = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return responese;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productVm);
                    newProduct.CreateDate = DateTime.Now;
                    _productService.Add(newProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
           

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Product, ProductViewModel>(model);
                var responese = request.CreateResponse(HttpStatusCode.OK, responseData);
                return responese;
            });
        }


        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;


                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProduct = _productService.GetById(productVm.ID);
                    dbProduct.UpdateProduct(productVm);
                    dbProduct.UpdateDate = DateTime.Now;
                    _productService.Update(dbProduct);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Product, ProductViewModel>(dbProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }


                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                
                var oldProduct = _productService.Delete(id);
                _productService.SaveChanges();

                var responseData = Mapper.Map<Product, ProductViewModel>(oldProduct);
                response = request.CreateResponse(HttpStatusCode.OK, responseData);


                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage deleteMulti(HttpRequestMessage request, string checkedProducts)
        {
            return CreateHttpResponse(request, () =>
            {

                HttpResponseMessage response = null;
                var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                foreach (var item in listProduct)
                {
                    _productService.Delete(item);
                }
              
                _productService.SaveChanges();
                response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);


                return response;
            });
        }
    }
}