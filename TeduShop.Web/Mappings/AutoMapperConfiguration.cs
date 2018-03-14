
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
                //cfg.CreateMap<List<Post>, List<PostViewModel>>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
                // .ForMember(p => p.Posts, pvm => pvm.MapFrom(src => src.Posts));
                //.ForMember(p => p.Name, pvm => pvm.MapFrom(src => src.Name))
                //.ForMember(p => p.Alias, pvm => pvm.MapFrom(src => src.Alias))
                //.ForMember(p => p.Description, pvm => pvm.MapFrom(src => src.Description))
                //.ForMember(p => p.ParentID, pvm => pvm.MapFrom(src => src.ParentID))
                //.ForMember(p => p.DisplayOrder, pvm => pvm.MapFrom(src => src.DisplayOrder))
                //.ForMember(p => p.Image, pvm => pvm.MapFrom(src => src.Image))
                //.ForMember(p => p.HomeFlag, pvm => pvm.MapFrom(src => src.HomeFlag))
                //.ForMember(p => p.CreateDate, pvm => pvm.MapFrom(src => src.CreateDate))
                //.ForMember(p => p.CreateBy, pvm => pvm.MapFrom(src => src.CreateBy))
                //.ForMember(p => p.UpdateDate, pvm => pvm.MapFrom(src => src.UpdateDate))
                //.ForMember(p => p.UpdateBy, pvm => pvm.MapFrom(src => src.UpdateBy))
                //.ForMember(p => p.MetaKeyword, pvm => pvm.MapFrom(src => src.MetaKeyword))
                //.ForMember(p => p.MetaDescription, pvm => pvm.MapFrom(src => src.MetaDescription))
                //.ForMember(p => p.Status, pvm => pvm.MapFrom(src => src.Status));
                // cfg.CreateMap<List<PostCategory>, List<PostCategoryViewModel>>();
                cfg.CreateMap<Tag, TagViewModel>();
                //cfg.CreateMap<List<Tag>, List<TagViewModel>>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                //cfg.CreateMap<List<PostTag>, List<PostTagViewModel>>();
            });

        }
    }
}