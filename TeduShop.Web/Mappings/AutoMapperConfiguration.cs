
using AutoMapper;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>().MaxDepth(2);
     
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
                
                cfg.CreateMap<Tag, TagViewModel>();
     
                cfg.CreateMap<PostTag, PostTagViewModel>();

                cfg.CreateMap<Product, ProductViewModel>().MaxDepth(2);

                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);

                cfg.CreateMap<ProductTag, ProductTagViewModel>();

            });

        }
    }
}