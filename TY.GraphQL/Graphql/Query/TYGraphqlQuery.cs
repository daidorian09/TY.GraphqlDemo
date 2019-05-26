using GraphQL.Types;
using System;
using System.Linq;
using TY.GraphQL.Application.Order.Interfaces;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Data;
using TY.GraphQL.Types.Order;
using TY.GraphQL.Types.Product;
using TY.GraphQL.Utils.Extensions;

namespace TY.GraphQL.Graphql.Query
{
    public class TYGraphqlQuery : ObjectGraphType
    {
        public TYGraphqlQuery(IProductControllerHandler productControllerHandler,
            IOrderControllerHandler orderControllerHandler)
        {
            Field<ProductType>(
                "getProductById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Product id"
                    }
                ),
                resolve: context => productControllerHandler.GetProductByIdAsync(context.GetArgument<Guid>("id")).Result
            );

            Field<OrderType>(
                "getOrderById",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Order id"
                    }
                ),
                resolve: context => orderControllerHandler.GetOrderById(context.GetArgument<Guid>("id")).Result
            );


            Field<ListGraphType<ProductType>>(
                "getPaginatedProducts",
                resolve: context =>
                {
                    var products = productControllerHandler.GetAll().Result;
                    return PaginatedList<Product>.CreateAsync(products, 1, 10);
                });
        }
    }
}