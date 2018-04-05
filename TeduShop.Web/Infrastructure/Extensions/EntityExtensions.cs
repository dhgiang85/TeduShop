﻿using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreateDate = postCategoryVm.CreateDate;
            postCategory.CreateBy = postCategoryVm.CreateBy;
            postCategory.UpdateDate = postCategoryVm.UpdateDate;
            postCategory.UpdateBy = postCategoryVm.UpdateBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;

        }
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreateDate = postVm.CreateDate;
            post.CreateBy = postVm.CreateBy;
            post.UpdateDate = postVm.UpdateDate;
            post.UpdateBy = postVm.UpdateBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
            productCategory.Description = productCategoryVm.Description;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.ParentID = productCategoryVm.ParentID;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.Image = productCategoryVm.Image;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;

            productCategory.CreateDate = productCategoryVm.CreateDate;
            productCategory.CreateBy = productCategoryVm.CreateBy;
            productCategory.UpdateDate = productCategoryVm.UpdateDate;
            productCategory.UpdateBy = productCategoryVm.UpdateBy;
            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;

        }
        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Description = productVm.Description;
            product.Alias = productVm.Alias;
            product.CategoryID = productVm.CategoryID;
            product.Image = productVm.Image;
            product.MoreImage = productVm.MoreImage;
            product.Price = productVm.Price;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.Description = productVm.Description;
            product.Content = productVm.Content;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.ViewCount = productVm.ViewCount;
            product.CreateDate = productVm.CreateDate;
            product.CreateBy = productVm.CreateBy;
            product.UpdateDate = productVm.UpdateDate;
            product.UpdateBy = productVm.UpdateBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;

        }
    }
}   