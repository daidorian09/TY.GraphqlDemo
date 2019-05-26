using Microsoft.EntityFrameworkCore;
using TY.GraphQL.Persistence.Infrastructure;

namespace TY.GraphQL.Persistence
{
    public class GraphqlDemoDbFactory : AbstractGraphqlDemoDbFactory<GraphqlDemoDbContext>
    {
        protected override GraphqlDemoDbContext CreateNewInstance(DbContextOptions<GraphqlDemoDbContext> options)
        {
            return new GraphqlDemoDbContext(options);
        }
    }
}