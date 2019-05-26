using GraphQL.Types;
using System;
using TY.GraphQL.Graphql.Mutation;
using TY.GraphQL.Graphql.Query;

namespace TY.GraphQL.Schema
{
    public class TYGraphQLSchema : global::GraphQL.Types.Schema
    {
        [Obsolete]
        public TYGraphQLSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (TYGraphqlQuery) resolveType(typeof(TYGraphqlQuery));
            Mutation = (TYGraphqlMutation) resolveType(typeof(TYGraphqlMutation));
        }

    }
}