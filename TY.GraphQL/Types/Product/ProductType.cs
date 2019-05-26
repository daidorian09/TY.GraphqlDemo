using GraphQL.Types;
using TY.GraphQL.Application.ProductVariant.Interfaces;
using TY.GraphQL.Types.Variant;

namespace TY.GraphQL.Types.Product
{
    public class ProductType : ObjectGraphType<Data.Product>
    {
        public ProductType(IProductVariantControllerHandler productVariantControllerHandler)
        {
            Field(f => f.Id, type:typeof(IdGraphType)).Description("Product Id");
            Field(f => f.Name).Description("Product Name");
            Field(f => f.UnitPrice).Description("Product Price");
            Field(f => f.CreatedAt, true).Description("Product Created Date");
            Field(f => f.ModifiedAt, true).Description("Product Modification Date");
            Field(f => f.IsDiscountableProduct).Description("Product Discount Available");
            Field(f => f.LongDescription, true).Description("Product Long Description");
            Field(f => f.ShortDescription).Description("Product Short Description");
            Field(f => f.IsOutOfStock).Description("Product Is Out Of Stock");
            Field(f => f.ProductUrl).Description("Product Base Url");
            Field(f => f.ProductContentId).Description("Product Content Id");
            Field(f => f.StockCount).Description("Product Stock Count");
            Field(f => f.IsDeleted).Description("Is Product Deleted");
            Field<ListGraphType<VariantType>>(
                "variants",
                resolve: context => productVariantControllerHandler.GetProductVariantByProductId(context.Source.Id).Result
            );
        }
    }
}