using GraphQL.Types;
using TY.GraphQL.Application.Order.Interfaces;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Application.Product.Models;
using TY.GraphQL.Application.ProductOrder.Models;
using TY.GraphQL.Application.Variant.Interfaces;
using TY.GraphQL.Application.Variant.Models;
using TY.GraphQL.Types.Order;
using TY.GraphQL.Types.Product;
using TY.GraphQL.Types.Variant;

namespace TY.GraphQL.Graphql.Mutation
{
    public class TYGraphqlMutation : ObjectGraphType
    {
        public TYGraphqlMutation(IProductControllerHandler productControllerHandler, IVariantControllerHandler variantControllerHandler, IOrderControllerHandler orderController)
        {
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: context =>
                {
                    var product = context.GetArgument<ProductViewModel>("product");
                    return productControllerHandler.CreateProductAsync(product).Result;
                });

            Field<VariantType>(
                "createVariant",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<VariantInputType>> { Name = "variant" }
                ),
                resolve: context =>
                {
                    var variant = context.GetArgument<VariantViewModel>("variant");
                    return variantControllerHandler.CreateVariantAsync(variant).Result;
                });

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }
                ),
                resolve: context =>
                {
                    var order = context.GetArgument<OrderViewModel>("order");
                    return orderController.CreateOrderAsync(order).Result;
                });
        }
    }
}