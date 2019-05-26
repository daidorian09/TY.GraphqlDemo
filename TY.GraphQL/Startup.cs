using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TY.GraphQL.Application.Order;
using TY.GraphQL.Application.Order.Interfaces;
using TY.GraphQL.Application.Product;
using TY.GraphQL.Application.Product.Interfaces;
using TY.GraphQL.Application.ProductOrder;
using TY.GraphQL.Application.ProductOrder.Interfaces;
using TY.GraphQL.Application.ProductVariant;
using TY.GraphQL.Application.ProductVariant.Interfaces;
using TY.GraphQL.Application.Variant;
using TY.GraphQL.Application.Variant.Interfaces;
using TY.GraphQL.Graphql.Mutation;
using TY.GraphQL.Graphql.Query;
using TY.GraphQL.Persistence;
using TY.GraphQL.Persistence.Infrastructure;
using TY.GraphQL.Schema;
using TY.GraphQL.Types.Order;
using TY.GraphQL.Types.Product;
using TY.GraphQL.Types.Variant;

namespace TY.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<GraphqlDemoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TYGraphqlDemoDb"))
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging());


            services.AddScoped<GraphqlDemoDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductControllerHandler, ProductControllerHandler>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IVariantControllerHandler, VariantControllerHandler>();
            services.AddScoped<IProductVariantControllerHandler, ProductVariantControllerHandler>();
            services.AddScoped<IVariantManager, VariantManager>();
            services.AddScoped<IProductVariantManager, ProductVariantManager>();
            services.AddScoped<IOrderControllerHandler, OrderControllerHandler>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IProductOrderControllerHandler, ProductOrderControllerHandler>();
            services.AddScoped<IProductOrderManager, ProductOrderManager>();


            services.AddScoped<TYGraphqlQuery>();
            services.AddScoped<TYGraphqlMutation>();
            services.AddScoped<GuidGraphType>();
            services.AddTransient<ProductInputType>();
            services.AddTransient<ProductType>();
            services.AddTransient<ListGraphType<ProductType>>();
            services.AddTransient<VariantInputType>();
            services.AddTransient<VariantType>();
            services.AddTransient<ProductOrderInputType>();
            services.AddTransient<OrderInputType>();
            services.AddTransient<ListGraphType<VariantType>>();
            services.AddTransient<VariantEnumType>();
            services.AddTransient<OrderType>();
            services.AddTransient<OrderTransactionEnumType>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new TYGraphQLSchema(type => (GraphType)sp.GetService(type))
            {
                Query = sp.GetService<TYGraphqlQuery>(),
                Mutation = sp.GetService<TYGraphqlMutation>()
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphiQl("/graphql");

           // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

        }
    }
}
